PGDMP                      }            BarberDB    17.2    17.2 L    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            �           1262    65750    BarberDB    DATABASE     ~   CREATE DATABASE "BarberDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "BarberDB";
                     postgres    false            �            1255    116762 9   authorize_user_proc(character varying, character varying) 	   PROCEDURE       CREATE PROCEDURE public.authorize_user_proc(IN p_email character varying, IN p_password character varying, OUT user_id integer, OUT role integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Поиск администратора
    SELECT id_administrator INTO user_id
    FROM administrator
    WHERE email_administrator = p_email AND password_administrator = p_password;

    IF FOUND THEN
        role := 0;
        RETURN;
    END IF;

    -- Поиск парикмахера
    SELECT id_hairdresser INTO user_id
    FROM hairdresser
    WHERE email_hairdresser = p_email AND password_hairdresser = p_password;

    IF FOUND THEN
        role := 1;
        RETURN;
    END IF;

    -- Поиск клиента
    SELECT id_client INTO user_id
    FROM client
    WHERE email_client = p_email AND password_client = p_password;

    IF FOUND THEN
        role := 2;
        RETURN;
    END IF;

    -- Если не найден ни один пользователь
    user_id := NULL;
    role := NULL;
END;
$$;
 �   DROP PROCEDURE public.authorize_user_proc(IN p_email character varying, IN p_password character varying, OUT user_id integer, OUT role integer);
       public               postgres    false            �            1255    124792 !   check_unique_email_across_roles()    FUNCTION       CREATE FUNCTION public.check_unique_email_across_roles() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
    email_to_check VARCHAR;
    user_id INTEGER;
    user_role INTEGER; -- 0 = админ, 1 = парикмахер, 2 = клиент
    conflict_found BOOLEAN := FALSE;
BEGIN
    -- Определяем email, роль и ID
    IF TG_TABLE_NAME = 'administrator' THEN
        email_to_check := NEW.email_administrator;
        user_id := NEW.id_administrator;
        user_role := 0;
    ELSIF TG_TABLE_NAME = 'hairdresser' THEN
        email_to_check := NEW.email_hairdresser;
        user_id := NEW.id_hairdresser;
        user_role := 1;
    ELSIF TG_TABLE_NAME = 'client' THEN
        email_to_check := NEW.email_client;
        user_id := NEW.id_client;
        user_role := 2;
    ELSE
        RAISE EXCEPTION 'Триггер вызван для неподдерживаемой таблицы: %', TG_TABLE_NAME;
    END IF;

    -- Проверка на совпадения по email
    SELECT TRUE INTO conflict_found
    FROM (
        SELECT id_administrator AS id, 0 AS role FROM administrator WHERE email_administrator = email_to_check
        UNION
        SELECT id_hairdresser AS id, 1 AS role FROM hairdresser WHERE email_hairdresser = email_to_check
        UNION
        SELECT id_client AS id, 2 AS role FROM client WHERE email_client = email_to_check
    ) AS all_users
    WHERE NOT (id = user_id AND role = user_role)
    LIMIT 1;

    IF conflict_found THEN
        RAISE EXCEPTION 'Email "%" уже используется другим пользователем', email_to_check;
    END IF;

    RETURN NEW;
END;
$$;
 8   DROP FUNCTION public.check_unique_email_across_roles();
       public               postgres    false            �            1255    141176 �   create_or_update_registration_with_services(integer, integer, integer, integer, timestamp without time zone, integer, integer[]) 	   PROCEDURE     4
  CREATE PROCEDURE public.create_or_update_registration_with_services(IN p_id_registration integer, IN p_id_administrator integer, IN p_id_client integer, IN p_id_hairdresser integer, IN p_date_registration timestamp without time zone, IN p_status integer, IN p_id_services integer[])
    LANGUAGE plpgsql
    AS $$
DECLARE
    registration_id INTEGER;
    i INTEGER;
    total_duration INTERVAL;
    end_time TIMESTAMP;
    overlap_count INTEGER;
BEGIN
    -- Вычисление общей продолжительности услуг
    SELECT SUM(s.duration)
    INTO total_duration
    FROM service s
    WHERE s.id_service = ANY(p_id_services);

    IF total_duration IS NULL THEN
        RAISE EXCEPTION 'Нет ни одной добавленной услуги';
    END IF;

    end_time := p_date_registration + total_duration;

    -- Проверка на занятость парикмахера
    SELECT COUNT(*)
    INTO overlap_count
    FROM registrationview rv
    WHERE rv.id_hairdresser = p_id_hairdresser
      AND (p_id_registration IS NULL OR rv.id_registration != p_id_registration)
      AND (p_date_registration BETWEEN rv.date_registration AND rv.end_data
         OR end_time           BETWEEN rv.date_registration AND rv.end_data
         OR rv.date_registration BETWEEN p_date_registration AND end_time
      );

    IF overlap_count > 0 THEN
        RAISE EXCEPTION 'Парикмахер занят в это время.';
    END IF;

    -- Вставка или обновление записи
    IF p_id_registration IS NULL THEN
        INSERT INTO registration (
            id_administrator,
            id_client,
            id_hairdresser,
			 status_registration,
            date_registration
        ) VALUES (
            p_id_administrator,
            p_id_client,
            p_id_hairdresser,
			p_status,
            p_date_registration
        )
        RETURNING id_registration INTO registration_id;
    ELSE
        UPDATE registration
        SET id_administrator = p_id_administrator,
            id_client = p_id_client,
            id_hairdresser = p_id_hairdresser,
			status_registration=p_status,
            date_registration = p_date_registration
        WHERE id_registration = p_id_registration;

        registration_id := p_id_registration;

        DELETE FROM includes WHERE id_registration = registration_id;
    END IF;

    -- Добавление новых услуг
    FOREACH i IN ARRAY p_id_services LOOP
        INSERT INTO includes (id_registration, id_service)
        VALUES (registration_id, i);
    END LOOP;
END;
$$;
   DROP PROCEDURE public.create_or_update_registration_with_services(IN p_id_registration integer, IN p_id_administrator integer, IN p_id_client integer, IN p_id_hairdresser integer, IN p_date_registration timestamp without time zone, IN p_status integer, IN p_id_services integer[]);
       public               postgres    false            �            1259    65773    administrator    TABLE     M  CREATE TABLE public.administrator (
    id_administrator integer NOT NULL,
    snp_administrator character varying(256) NOT NULL,
    phone_administrator bigint NOT NULL,
    passport_administrator bigint NOT NULL,
    email_administrator character varying(100) NOT NULL,
    password_administrator character varying(64) NOT NULL
);
 !   DROP TABLE public.administrator;
       public         heap r       postgres    false            �            1259    65776 "   administrator_id_administrator_seq    SEQUENCE     �   CREATE SEQUENCE public.administrator_id_administrator_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public.administrator_id_administrator_seq;
       public               postgres    false    221            �           0    0 "   administrator_id_administrator_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public.administrator_id_administrator_seq OWNED BY public.administrator.id_administrator;
          public               postgres    false    222            �            1259    65777 #   administrator_id_administrator_seq1    SEQUENCE     �   ALTER TABLE public.administrator ALTER COLUMN id_administrator ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.administrator_id_administrator_seq1
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    221            �            1259    65754    client    TABLE     �   CREATE TABLE public.client (
    id_client integer NOT NULL,
    snp_client character varying(256) NOT NULL,
    phone_client bigint NOT NULL,
    email_client character varying(100) NOT NULL,
    password_client character varying(64) NOT NULL
);
    DROP TABLE public.client;
       public         heap r       postgres    false            �            1259    65778    client_id_client_seq    SEQUENCE     �   ALTER TABLE public.client ALTER COLUMN id_client ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.client_id_client_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    217            �            1259    65779    client_id_сlient_seq    SEQUENCE     �   CREATE SEQUENCE public."client_id_сlient_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public."client_id_сlient_seq";
       public               postgres    false    217            �           0    0    client_id_сlient_seq    SEQUENCE OWNED BY     P   ALTER SEQUENCE public."client_id_сlient_seq" OWNED BY public.client.id_client;
          public               postgres    false    225            �            1259    65757    hairdresser    TABLE     ?  CREATE TABLE public.hairdresser (
    id_hairdresser integer NOT NULL,
    snp_hairdresser character varying(256) NOT NULL,
    phone_hairdresser bigint NOT NULL,
    passport_hairdresser bigint NOT NULL,
    email_hairdresser character varying(100) NOT NULL,
    password_hairdresser character varying(64) NOT NULL
);
    DROP TABLE public.hairdresser;
       public         heap r       postgres    false            �            1259    65780    hairdresser_id_hairdresser_seq    SEQUENCE     �   CREATE SEQUENCE public.hairdresser_id_hairdresser_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public.hairdresser_id_hairdresser_seq;
       public               postgres    false    218            �           0    0    hairdresser_id_hairdresser_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public.hairdresser_id_hairdresser_seq OWNED BY public.hairdresser.id_hairdresser;
          public               postgres    false    226            �            1259    65781    hairdresser_id_hairdresser_seq1    SEQUENCE     �   ALTER TABLE public.hairdresser ALTER COLUMN id_hairdresser ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.hairdresser_id_hairdresser_seq1
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    218            �            1259    65782    includes    TABLE     h   CREATE TABLE public.includes (
    id_registration integer NOT NULL,
    id_service integer NOT NULL
);
    DROP TABLE public.includes;
       public         heap r       postgres    false            �            1259    65760    registration    TABLE     �  CREATE TABLE public.registration (
    id_registration integer NOT NULL,
    id_administrator integer,
    id_client integer NOT NULL,
    id_hairdresser integer NOT NULL,
    status_registration integer DEFAULT 0 NOT NULL,
    date_registration timestamp without time zone NOT NULL,
    CONSTRAINT ckc_status_registrati_registra CHECK (((status_registration >= 0) AND (status_registration <= 3)))
);
     DROP TABLE public.registration;
       public         heap r       postgres    false                        0    0 '   COLUMN registration.status_registration    COMMENT     �   COMMENT ON COLUMN public.registration.status_registration IS '1-Не оплачена
2-Оплачена
3-В работе
4-Выполнена';
          public               postgres    false    219            �            1259    65799     registration_id_registration_seq    SEQUENCE     �   CREATE SEQUENCE public.registration_id_registration_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 7   DROP SEQUENCE public.registration_id_registration_seq;
       public               postgres    false    219                       0    0     registration_id_registration_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public.registration_id_registration_seq OWNED BY public.registration.id_registration;
          public               postgres    false    229            �            1259    65800 !   registration_id_registration_seq1    SEQUENCE     �   ALTER TABLE public.registration ALTER COLUMN id_registration ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.registration_id_registration_seq1
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    219            �            1259    65801    service    TABLE     �   CREATE TABLE public.service (
    id_service integer NOT NULL,
    name_service character varying(256) NOT NULL,
    price_service numeric(6,2) NOT NULL,
    duration time without time zone NOT NULL
);
    DROP TABLE public.service;
       public         heap r       postgres    false            �            1259    65765    status    TABLE     r   CREATE TABLE public.status (
    code_status integer NOT NULL,
    name_status character varying(100) NOT NULL
);
    DROP TABLE public.status;
       public         heap r       postgres    false            �            1259    132995    registrationview    VIEW     \  CREATE VIEW public.registrationview AS
 SELECT r.id_registration,
    r.id_administrator,
    r.id_client,
    r.id_hairdresser,
    r.status_registration,
    r.date_registration,
    (r.date_registration + sum((s.duration)::interval)) AS end_data,
    a.snp_administrator,
    c.snp_client,
    h.snp_hairdresser,
    st.name_status,
    count(s.id_service) AS count_services,
    sum(s.price_service) AS price_services
   FROM ((((((public.registration r
     LEFT JOIN public.administrator a ON ((r.id_administrator = a.id_administrator)))
     JOIN public.client c ON ((r.id_client = c.id_client)))
     JOIN public.hairdresser h ON ((r.id_hairdresser = h.id_hairdresser)))
     JOIN public.status st ON ((r.status_registration = st.code_status)))
     JOIN public.includes i ON ((r.id_registration = i.id_registration)))
     JOIN public.service s ON ((i.id_service = s.id_service)))
  GROUP BY r.id_registration, r.id_administrator, r.id_client, r.id_hairdresser, r.status_registration, r.date_registration, a.snp_administrator, c.snp_client, h.snp_hairdresser, st.name_status
  ORDER BY r.date_registration;
 #   DROP VIEW public.registrationview;
       public       v       postgres    false    220    217    217    218    218    219    219    219    219    219    219    220    221    221    228    228    231    231    231            �            1259    65804    service_id_service_seq    SEQUENCE     �   CREATE SEQUENCE public.service_id_service_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.service_id_service_seq;
       public               postgres    false    231                       0    0    service_id_service_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.service_id_service_seq OWNED BY public.service.id_service;
          public               postgres    false    232            �            1259    108542    service_id_service_seq1    SEQUENCE     �   ALTER TABLE public.service ALTER COLUMN id_service ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.service_id_service_seq1
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public               postgres    false    231            �            1259    133021    servicereport    VIEW     �  CREATE VIEW public.servicereport AS
 SELECT s.id_service,
    s.name_service,
    s.price_service,
    count(i.id_service) AS times_used,
    ((count(i.id_service))::numeric * s.price_service) AS total
   FROM (public.service s
     LEFT JOIN public.includes i ON ((s.id_service = i.id_service)))
  GROUP BY s.id_service, s.name_service, s.price_service
  ORDER BY ((count(i.id_service))::numeric * s.price_service) DESC;
     DROP VIEW public.servicereport;
       public       v       postgres    false    231    231    228    231            �          0    65773    administrator 
   TABLE DATA           �   COPY public.administrator (id_administrator, snp_administrator, phone_administrator, passport_administrator, email_administrator, password_administrator) FROM stdin;
    public               postgres    false    221   �x       �          0    65754    client 
   TABLE DATA           d   COPY public.client (id_client, snp_client, phone_client, email_client, password_client) FROM stdin;
    public               postgres    false    217   [z       �          0    65757    hairdresser 
   TABLE DATA           �   COPY public.hairdresser (id_hairdresser, snp_hairdresser, phone_hairdresser, passport_hairdresser, email_hairdresser, password_hairdresser) FROM stdin;
    public               postgres    false    218   4       �          0    65782    includes 
   TABLE DATA           ?   COPY public.includes (id_registration, id_service) FROM stdin;
    public               postgres    false    228   �       �          0    65760    registration 
   TABLE DATA           �   COPY public.registration (id_registration, id_administrator, id_client, id_hairdresser, status_registration, date_registration) FROM stdin;
    public               postgres    false    219   ;�       �          0    65801    service 
   TABLE DATA           T   COPY public.service (id_service, name_service, price_service, duration) FROM stdin;
    public               postgres    false    231   X�       �          0    65765    status 
   TABLE DATA           :   COPY public.status (code_status, name_status) FROM stdin;
    public               postgres    false    220   r�                  0    0 "   administrator_id_administrator_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public.administrator_id_administrator_seq', 1, false);
          public               postgres    false    222                       0    0 #   administrator_id_administrator_seq1    SEQUENCE SET     Q   SELECT pg_catalog.setval('public.administrator_id_administrator_seq1', 5, true);
          public               postgres    false    223                       0    0    client_id_client_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.client_id_client_seq', 25, true);
          public               postgres    false    224                       0    0    client_id_сlient_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public."client_id_сlient_seq"', 1, false);
          public               postgres    false    225                       0    0    hairdresser_id_hairdresser_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public.hairdresser_id_hairdresser_seq', 1, false);
          public               postgres    false    226                       0    0    hairdresser_id_hairdresser_seq1    SEQUENCE SET     M   SELECT pg_catalog.setval('public.hairdresser_id_hairdresser_seq1', 7, true);
          public               postgres    false    227            	           0    0     registration_id_registration_seq    SEQUENCE SET     O   SELECT pg_catalog.setval('public.registration_id_registration_seq', 1, false);
          public               postgres    false    229            
           0    0 !   registration_id_registration_seq1    SEQUENCE SET     P   SELECT pg_catalog.setval('public.registration_id_registration_seq1', 44, true);
          public               postgres    false    230                       0    0    service_id_service_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.service_id_service_seq', 1, false);
          public               postgres    false    232                       0    0    service_id_service_seq1    SEQUENCE SET     F   SELECT pg_catalog.setval('public.service_id_service_seq1', 25, true);
          public               postgres    false    233            A           2606    65816    administrator pk_administrator 
   CONSTRAINT     j   ALTER TABLE ONLY public.administrator
    ADD CONSTRAINT pk_administrator PRIMARY KEY (id_administrator);
 H   ALTER TABLE ONLY public.administrator DROP CONSTRAINT pk_administrator;
       public                 postgres    false    221            3           2606    65818    client pk_client 
   CONSTRAINT     U   ALTER TABLE ONLY public.client
    ADD CONSTRAINT pk_client PRIMARY KEY (id_client);
 :   ALTER TABLE ONLY public.client DROP CONSTRAINT pk_client;
       public                 postgres    false    217            6           2606    65820    hairdresser pk_hairdresser 
   CONSTRAINT     d   ALTER TABLE ONLY public.hairdresser
    ADD CONSTRAINT pk_hairdresser PRIMARY KEY (id_hairdresser);
 D   ALTER TABLE ONLY public.hairdresser DROP CONSTRAINT pk_hairdresser;
       public                 postgres    false    218            F           2606    65822    includes pk_includes 
   CONSTRAINT     k   ALTER TABLE ONLY public.includes
    ADD CONSTRAINT pk_includes PRIMARY KEY (id_registration, id_service);
 >   ALTER TABLE ONLY public.includes DROP CONSTRAINT pk_includes;
       public                 postgres    false    228    228            :           2606    65832    registration pk_registration 
   CONSTRAINT     g   ALTER TABLE ONLY public.registration
    ADD CONSTRAINT pk_registration PRIMARY KEY (id_registration);
 F   ALTER TABLE ONLY public.registration DROP CONSTRAINT pk_registration;
       public                 postgres    false    219            H           2606    65834    service pk_service 
   CONSTRAINT     X   ALTER TABLE ONLY public.service
    ADD CONSTRAINT pk_service PRIMARY KEY (id_service);
 <   ALTER TABLE ONLY public.service DROP CONSTRAINT pk_service;
       public                 postgres    false    231            >           2606    65836    status status_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public.status
    ADD CONSTRAINT status_pkey PRIMARY KEY (code_status);
 <   ALTER TABLE ONLY public.status DROP CONSTRAINT status_pkey;
       public                 postgres    false    220            ?           1259    65839    administrator_pk    INDEX     ]   CREATE UNIQUE INDEX administrator_pk ON public.administrator USING btree (id_administrator);
 $   DROP INDEX public.administrator_pk;
       public                 postgres    false    221            7           1259    65840    attached_fk    INDEX     N   CREATE INDEX attached_fk ON public.registration USING btree (id_hairdresser);
    DROP INDEX public.attached_fk;
       public                 postgres    false    219            1           1259    65841 	   client_pk    INDEX     H   CREATE UNIQUE INDEX client_pk ON public.client USING btree (id_client);
    DROP INDEX public.client_pk;
       public                 postgres    false    217            8           1259    65844 
   designs_fk    INDEX     O   CREATE INDEX designs_fk ON public.registration USING btree (id_administrator);
    DROP INDEX public.designs_fk;
       public                 postgres    false    219            4           1259    65845    hairdresser_pk    INDEX     W   CREATE UNIQUE INDEX hairdresser_pk ON public.hairdresser USING btree (id_hairdresser);
 "   DROP INDEX public.hairdresser_pk;
       public                 postgres    false    218            B           1259    65846    includes2_fk    INDEX     G   CREATE INDEX includes2_fk ON public.includes USING btree (id_service);
     DROP INDEX public.includes2_fk;
       public                 postgres    false    228            C           1259    65847    includes_fk    INDEX     K   CREATE INDEX includes_fk ON public.includes USING btree (id_registration);
    DROP INDEX public.includes_fk;
       public                 postgres    false    228            D           1259    65848    includes_pk    INDEX     ^   CREATE UNIQUE INDEX includes_pk ON public.includes USING btree (id_registration, id_service);
    DROP INDEX public.includes_pk;
       public                 postgres    false    228    228            ;           1259    65856    registration_pk    INDEX     Z   CREATE UNIQUE INDEX registration_pk ON public.registration USING btree (id_registration);
 #   DROP INDEX public.registration_pk;
       public                 postgres    false    219            I           1259    65857 
   service_pk    INDEX     K   CREATE UNIQUE INDEX service_pk ON public.service USING btree (id_service);
    DROP INDEX public.service_pk;
       public                 postgres    false    231            <           1259    65858 	   signup_fk    INDEX     G   CREATE INDEX signup_fk ON public.registration USING btree (id_client);
    DROP INDEX public.signup_fk;
       public                 postgres    false    219            R           2620    124793 +   administrator trg_check_email_administrator    TRIGGER     �   CREATE TRIGGER trg_check_email_administrator BEFORE INSERT OR UPDATE ON public.administrator FOR EACH ROW EXECUTE FUNCTION public.check_unique_email_across_roles();
 D   DROP TRIGGER trg_check_email_administrator ON public.administrator;
       public               postgres    false    221    249            P           2620    124795    client trg_check_email_client    TRIGGER     �   CREATE TRIGGER trg_check_email_client BEFORE INSERT OR UPDATE ON public.client FOR EACH ROW EXECUTE FUNCTION public.check_unique_email_across_roles();
 6   DROP TRIGGER trg_check_email_client ON public.client;
       public               postgres    false    249    217            Q           2620    124794 '   hairdresser trg_check_email_hairdresser    TRIGGER     �   CREATE TRIGGER trg_check_email_hairdresser BEFORE INSERT OR UPDATE ON public.hairdresser FOR EACH ROW EXECUTE FUNCTION public.check_unique_email_across_roles();
 @   DROP TRIGGER trg_check_email_hairdresser ON public.hairdresser;
       public               postgres    false    249    218            N           2606    65862 &   includes fk_includes_includes2_service    FK CONSTRAINT     �   ALTER TABLE ONLY public.includes
    ADD CONSTRAINT fk_includes_includes2_service FOREIGN KEY (id_service) REFERENCES public.service(id_service) ON UPDATE CASCADE ON DELETE CASCADE;
 P   ALTER TABLE ONLY public.includes DROP CONSTRAINT fk_includes_includes2_service;
       public               postgres    false    4680    231    228            O           2606    65867 &   includes fk_includes_includes_registra    FK CONSTRAINT     �   ALTER TABLE ONLY public.includes
    ADD CONSTRAINT fk_includes_includes_registra FOREIGN KEY (id_registration) REFERENCES public.registration(id_registration) ON UPDATE CASCADE ON DELETE CASCADE;
 P   ALTER TABLE ONLY public.includes DROP CONSTRAINT fk_includes_includes_registra;
       public               postgres    false    228    219    4666            J           2606    65897 *   registration fk_registra_attached_hairdres    FK CONSTRAINT     �   ALTER TABLE ONLY public.registration
    ADD CONSTRAINT fk_registra_attached_hairdres FOREIGN KEY (id_hairdresser) REFERENCES public.hairdresser(id_hairdresser) ON UPDATE CASCADE ON DELETE CASCADE;
 T   ALTER TABLE ONLY public.registration DROP CONSTRAINT fk_registra_attached_hairdres;
       public               postgres    false    219    218    4662            K           2606    65902 )   registration fk_registra_designs_administ    FK CONSTRAINT     �   ALTER TABLE ONLY public.registration
    ADD CONSTRAINT fk_registra_designs_administ FOREIGN KEY (id_administrator) REFERENCES public.administrator(id_administrator) ON UPDATE CASCADE ON DELETE CASCADE;
 S   ALTER TABLE ONLY public.registration DROP CONSTRAINT fk_registra_designs_administ;
       public               postgres    false    221    4673    219            L           2606    65907 &   registration fk_registra_signup_client    FK CONSTRAINT     �   ALTER TABLE ONLY public.registration
    ADD CONSTRAINT fk_registra_signup_client FOREIGN KEY (id_client) REFERENCES public.client(id_client) ON UPDATE CASCADE ON DELETE CASCADE;
 P   ALTER TABLE ONLY public.registration DROP CONSTRAINT fk_registra_signup_client;
       public               postgres    false    4659    219    217            M           2606    65912    registration fk_status    FK CONSTRAINT     �   ALTER TABLE ONLY public.registration
    ADD CONSTRAINT fk_status FOREIGN KEY (status_registration) REFERENCES public.status(code_status) ON UPDATE CASCADE ON DELETE CASCADE NOT VALID;
 @   ALTER TABLE ONLY public.registration DROP CONSTRAINT fk_status;
       public               postgres    false    219    220    4670            �   k  x�m��J�@��3O�n\��-�]q�F^��`C	i55Ю��+��e���R,--�3���gR+\�p�;�?��;���0�)L,x/GX�(�<a1)o��U�X�����K[J�Dr.���%QġnF�@�L�:=v��I�\�Dv�6�@ZyW���e�L`�i��6¦F��P>c��4�<�UR���1Ү㰟b��9R;��.���+)��a����F�Uь�`W9�ms�������":�i_�h�Β����:]�x��ᖤ�D[�����x�*�9JOaf6�����r!=�ن�1.�T$�C�}4N0�(��:��c�2c\��|C��%�-?��8�`��p�|�n��x}ӳ&��0
	t      �   �  x��V[OG~��F6/<D;��7lcA��X@��*Y[�+ֻ�mVu��(P�QiR�FiӔ�}i����_��G=3�؃IT?���>�9�e�	�/�M���{tH��=����5Ыt�^�m���'�]:L�����n���ѣbw��[^>h�-�mh���1�h�6|+�j_�o�s������W���p�n.�ύh964�MC������oa�x��|k��(:�����U����� .��g�I���@Rm��u]�A��fѭ֤��k�>�Yy��%9������E���A��aF�F7�a����G;�/0�#�)t���b"�l�C�!�+Ga�w�(P��ɘ}Cm�v�j~s{'����T9����d�+��	
���	���C��K c7�[�1Mh_��F������5ֽ.QUy�d]+�Όb#�	7`T� �0�A���p0V{<�c�0�fZh��{�JU*�/[���SD�J��C!����EPrO�1L��umOz\��Q6�yϵg�
���1�k~9dl�S[$c���������:�cD߲����9�w��y��룭��ܤ�����~������'F�3���5�0+9�����4��s8�zԀ {�Z���~�U*�5=�W�9C����F��O��~`�p�'�fن��W�qV�.`�Te�jVa�
�Ő�_���Qz�jL�>�A&P�W+���S��*��ą<`��s�3cG�g�1�A�a$��@f�2 
���N�(T�]ƾɜ#��iʬ�V$8;�b�'�q&6f/T{��L	`�5g��A�!ϯ�x��B2�O��Oh���1���k�q�p�=82�1��Z��X0��wU6@�s�uM�k�h@��'XL��z��߉�f|Ǭe;�Y�PcH�)(y$B��n���i��&I7mN�����ɂQ��p �,�#���H����U�%���3�V��VЅc�1uNl�V����)�|ƙ�pK����̪g ��-/*F[m��˫a�)$eHl&�=���=ޞR�eܚD��VC-zI�/�J�G�A�E3U�V���F��6���~y>�i���bT�2nw�E���B�� ��͖E�� ��s䙆FX � �@k趄���+��D�'�V�u�T�d4�������`�TE����~%��.�_��@mq`�͏Σ���%i���h��u���E�3��      �   �  x�u��o�@�绿�(e�`�O�o�X
,E���h��؎%'����bC**BB�
%����ox��x�$m
b��;[z��|�	�`Z��u
װ�5\�� ~���x����s���)��E�2��F��22g��#7re2(*���.ɂ�"'���S>i[*	|E�O\���] A�?�0/�����[fr΅��3�1�!3K��9,^Y\S7٧f��~������'X7+�m���[���cj��^��Z�#�sY2pAZ�AzW�w�Z�g��j\"��e��&����A��7�*)��$�Q.͊�0��9<y��4$�>o��k'�	�)?z��Mw�0�Z�&C!����Y�:��8��&>�:��-I���Ƴ��~�3�D�'g}��蘒��1�?�P\��XR%�(�W.ȋ�;N�w���a����(��8����n��η#�ǵ>�7	.�ԡ�J.��,黤l6�"�����kU      �      x������ � �      �      x������ � �      �   
  x��T[n�0��O�$%�������� NQ�RE�e�r�|��:�z�&a��L�wfge�S��s���SXQ��L�	3�S��1�(c&�O�9E������ЕK���S�'��G��P�wv�sd��@_0S�1�'�4�vm��	<G���i܆�LW�������0�J��B�1,h+��KW�G˧\�v�����R\�펢H�wEA{�훈^������j�F/�K?7��jѰ��p��X�-Wm���@9yfMb�Z�nhV��������V��	c�eK�Sy�J�]��Q,b�`z[���β�1�3qh->OFp�R�I��+mY@���X�ڙ�y[:��V��^t�/*��z��R����<"pb>�W)��e�n\�����I����>&Bo ;�#��~n൏r��DDkt�p�!<��8zO\��C>=8Z� �j< ��#f��̾BJp�[�n�>��	>�����_x�#�_~���Z������?-�,      �   R   x�3༰�¾�/l������9/̻�ra�ņ{.쾰,h�ya�PdÅ�@��[���"�/���TQ���� Jk1\     