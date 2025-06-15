using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BarberShop.Code;
using BarberShop.Properties;
using Npgsql;

namespace BarberShop.Forms
{
    public enum Role
    {
        Administrator=0, Hairdresser=1, Client=2
    }
    public partial class AuthorizeForm : Form
    {
        string connectionString;
        public int USER_ID = -1;
        int ROLE_ID = -1;

        string GetConnectionString()
        {
            string str_conn = null;
            string conn = Settings.Default.BarberDBConnectionString;
            if (!string.IsNullOrEmpty(conn))
            {
                int first_parameter = conn.IndexOf(';');
                str_conn = conn.Substring(first_parameter + 1);
            }
            return str_conn;
        }

        public AuthorizeForm()
        {
            InitializeComponent();
            connectionString = GetConnectionString();
        }

        private void buttonIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxEmail.Text))
                    throw new Exception("Введите Email");
                if (string.IsNullOrEmpty(textBoxPassword.Text))
                    throw new Exception("Введите пароль");

                string sql_command_text = "CALL public.authorize_user_proc(@p_email, @p_password,NULL,NULL);";
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql_command_text, connection))
                    {
                        // Входные параметры
                        cmd.Parameters.AddWithValue("p_email", textBoxEmail.Text);
                        cmd.Parameters.AddWithValue("p_password", textBoxPassword.Text);
                        // Выходные параметры
                        var userIdParam = new NpgsqlParameter("user_id", NpgsqlTypes.NpgsqlDbType.Integer)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(userIdParam);
                        var roleParam = new NpgsqlParameter("role", NpgsqlTypes.NpgsqlDbType.Integer)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(roleParam);
                        // Вызов процедуры
                        cmd.ExecuteNonQuery();
                        // Получение выходных значений
                        USER_ID = (userIdParam.Value == DBNull.Value) ? -1 : (int)userIdParam.Value;
                        ROLE_ID = (roleParam.Value == DBNull.Value) ? -1 : (int)roleParam.Value;
                    }
                }
                if (USER_ID == -1 || ROLE_ID == -1)
                    throw new Exception("Неправильная электронная почта или пароль");
               
                switch ((Role)ROLE_ID)
                {
                    case Role.Client:
                        this.Hide();
                        MainFormClient client_form = new MainFormClient(USER_ID);
                        client_form.ShowDialog();
                        this.Show();
                        textBoxEmail.Clear();
                        textBoxPassword.Clear();
                        break;
                    case Role.Hairdresser:
                        this.Hide();
                        MainFormHair hairdresser_form = new MainFormHair(USER_ID);
                        hairdresser_form.ShowDialog();
                        this.Show();
                        textBoxEmail.Clear();
                        textBoxPassword.Clear();
                        break;
                    case Role.Administrator:
                        this.Hide();
                        MainForm admin_form = new MainForm(USER_ID);
                        admin_form.ShowDialog();
                        this.Show();
                        textBoxEmail.Clear();
                        textBoxPassword.Clear();
                        break;
                }
                
            }
            catch (OdbcException error)
            {
                string errorCode = MyDataException.ExtractErrorCode(error.Message);
                if (errorCode != null && MyDataException.ErrorMessages.TryGetValue(errorCode, out string userMessage))
                {
                    MessageBox.Show(userMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(MyDataException.ErrorConnectServer, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormClient form = new FormClient();
            this.Hide();
            form.ShowDialog();
            this.Show();
            textBoxEmail.Text = form.Email;
            textBoxPassword.Text = form.Password;
        }
    }
}
