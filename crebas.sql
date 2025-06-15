/*==============================================================*/
/* DBMS name:      PostgreSQL 8                                 */
/* Created on:     15.06.2025 23:29:52                          */
/*==============================================================*/


drop index Includes_FK;

drop index Includes2_FK;

drop index Includes_PK;

drop table Includes;

drop index administrator_PK;

drop table administrator;

drop index client_PK;

drop table client;

drop index hairdresser_PK;

drop table hairdresser;

drop index Have_FK;

drop index Attached_FK;

drop index SignUp_FK;

drop index Designs_FK;

drop index registration_PK;

drop table registration;

drop index service_PK;

drop table service;

drop index status_PK;

drop table status;

/*==============================================================*/
/* Table: Includes                                              */
/*==============================================================*/
create table Includes (
   id_registration      INT4                 not null,
   id_service           INT4                 not null,
   constraint PK_INCLUDES primary key (id_registration, id_service)
);

/*==============================================================*/
/* Index: Includes_PK                                           */
/*==============================================================*/
create unique index Includes_PK on Includes (
id_registration,
id_service
);

/*==============================================================*/
/* Index: Includes2_FK                                          */
/*==============================================================*/
create  index Includes2_FK on Includes (
id_service
);

/*==============================================================*/
/* Index: Includes_FK                                           */
/*==============================================================*/
create  index Includes_FK on Includes (
id_registration
);

/*==============================================================*/
/* Table: administrator                                         */
/*==============================================================*/
create table administrator (
   id_administrator     INT4                 not null,
   snp_administrator    VARCHAR(256)         not null,
   phone_administrator  INT8                 not null,
   passport_administrator INT8                 not null,
   email_administrator  VARCHAR(100)         not null,
   password_administrator VARCHAR(64)          not null,
   constraint PK_ADMINISTRATOR primary key (id_administrator)
);

/*==============================================================*/
/* Index: administrator_PK                                      */
/*==============================================================*/
create unique index administrator_PK on administrator (
id_administrator
);

/*==============================================================*/
/* Table: client                                                */
/*==============================================================*/
create table client (
   id_ñlient            INT4                 not null,
   snp_client           VARCHAR(256)         not null,
   phonenumber_client   INT8                 not null,
   email_ñlient         VARCHAR(100)         not null,
   password_client      VARCHAR(64)          not null,
   constraint PK_CLIENT primary key (id_ñlient)
);

/*==============================================================*/
/* Index: client_PK                                             */
/*==============================================================*/
create unique index client_PK on client (
id_ñlient
);

/*==============================================================*/
/* Table: hairdresser                                           */
/*==============================================================*/
create table hairdresser (
   id_hairdresser       INT4                 not null,
   snp_hairdresser      VARCHAR(256)         not null,
   phonenumber__Hairdresser INT8                 not null,
   passport_hairdresser INT8                 not null,
   email_hairdresser    VARCHAR(100)         not null,
   password_haidresser  VARCHAR(64)          not null,
   constraint PK_HAIRDRESSER primary key (id_hairdresser)
);

/*==============================================================*/
/* Index: hairdresser_PK                                        */
/*==============================================================*/
create unique index hairdresser_PK on hairdresser (
id_hairdresser
);

/*==============================================================*/
/* Table: registration                                          */
/*==============================================================*/
create table registration (
   id_registration      INT4                 not null,
   id_administrator     INT4                 null,
   id_ñlient            INT4                 not null,
   id_hairdresser       INT4                 not null,
   code_status          INT4                 not null,
   date_registration    DATE                 not null,
   constraint PK_REGISTRATION primary key (id_registration)
);

/*==============================================================*/
/* Index: registration_PK                                       */
/*==============================================================*/
create unique index registration_PK on registration (
id_registration
);

/*==============================================================*/
/* Index: Designs_FK                                            */
/*==============================================================*/
create  index Designs_FK on registration (
id_administrator
);

/*==============================================================*/
/* Index: SignUp_FK                                             */
/*==============================================================*/
create  index SignUp_FK on registration (
id_ñlient
);

/*==============================================================*/
/* Index: Attached_FK                                           */
/*==============================================================*/
create  index Attached_FK on registration (
id_hairdresser
);

/*==============================================================*/
/* Index: Have_FK                                               */
/*==============================================================*/
create  index Have_FK on registration (
code_status
);

/*==============================================================*/
/* Table: service                                               */
/*==============================================================*/
create table service (
   id_service           INT4                 not null,
   name_service         VARCHAR(256)         not null,
   price_service        DECIMAL(6,2)         not null,
   duration             TIME                 not null,
   constraint PK_SERVICE primary key (id_service)
);

/*==============================================================*/
/* Index: service_PK                                            */
/*==============================================================*/
create unique index service_PK on service (
id_service
);

/*==============================================================*/
/* Table: status                                                */
/*==============================================================*/
create table status (
   code_status          INT4                 not null,
   name_status          VARCHAR(100)         not null,
   constraint PK_STATUS primary key (code_status)
);

/*==============================================================*/
/* Index: status_PK                                             */
/*==============================================================*/
create unique index status_PK on status (
code_status
);

alter table Includes
   add constraint FK_INCLUDES_INCLUDES_REGISTRA foreign key (id_registration)
      references registration (id_registration)
      on delete restrict on update restrict;

alter table Includes
   add constraint FK_INCLUDES_INCLUDES2_SERVICE foreign key (id_service)
      references service (id_service)
      on delete restrict on update restrict;

alter table registration
   add constraint FK_REGISTRA_ATTACHED_HAIRDRES foreign key (id_hairdresser)
      references hairdresser (id_hairdresser)
      on delete restrict on update restrict;

alter table registration
   add constraint FK_REGISTRA_DESIGNS_ADMINIST foreign key (id_administrator)
      references administrator (id_administrator)
      on delete restrict on update restrict;

alter table registration
   add constraint FK_REGISTRA_HAVE_STATUS foreign key (code_status)
      references status (code_status)
      on delete restrict on update restrict;

alter table registration
   add constraint FK_REGISTRA_SIGNUP_CLIENT foreign key (id_ñlient)
      references client (id_ñlient)
      on delete restrict on update restrict;

