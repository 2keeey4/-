using System;
using System.Data;
using System.Windows.Forms;
using BarberShop.Properties;
using Npgsql;
using BarberShop.Code;
using BarberShop.BarberDBDataSetTableAdapters;
using System.Collections.Generic;
namespace BarberShop.Forms
{
    public partial class RegistrationForm : Form
    {
        DialogMode dialogMode;
        DataRow Row = null;
        string connectionString;
        int UserID;
        Role UserRole;
        string GetConnectionString()
        {
            string str_conn = null;
            string conn = Settings.Default.BarberDBConnectionString;
            if (!string.IsNullOrEmpty(conn))
            {
                int first_parameter = conn.IndexOf(';');
                str_conn = conn.Substring(first_parameter+1);
            }
            return str_conn;
        }

        List<int> GetSelectedServices()
        {
            List<int> selectedIds = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != DBNull.Value && Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    selectedIds.Add(Convert.ToInt32(row.Cells[1].Value));
                }
            }
            return selectedIds;
        }

        public RegistrationForm(int userID, Role role)
        {
            InitializeComponent();
            dialogMode = DialogMode.Create;
            UserID = userID;
            UserRole = role;
            this.Text = "Новая запись к парикмахеру";
            buttonOK.Text = "Добавить";

            connectionString = GetConnectionString();
            
            UpdateData();

        }
        public RegistrationForm(DataRow row, int userID, Role role)
        {
            InitializeComponent();
            dialogMode = DialogMode.Edit;
            this.Row = row;
            UserID = userID;
            UserRole = role;
            this.Text = "Изменение записи к парикмахеру";
            buttonOK.Text = "Изменить";
            connectionString = GetConnectionString();
            
            UpdateData();
            
        }
        void Ini()
        {
            switch (UserRole)
            {
                case Role.Administrator:
                    if(dialogMode == DialogMode.Create)
                    {
                        comboBoxStatus.Enabled = false;
                        comboBoxStatus.SelectedValue = 1;     
                    }
                    comboBoxAdmin.SelectedValue = UserID;
                    break;
                case Role.Hairdresser:
                    {
                        if (comboBoxStatus.SelectedIndex != 1)
                        {
                            comboBoxHairDresser.Enabled = false;
                            dateTimePickerStart.Enabled = false;
                            dataGridView1.ReadOnly = true;
                            this.Text = "Просмотр записи к парикмахеру";
                            buttonOK.Text = "Закрыть";
                        }
                        comboBoxStatus.Enabled = false;
                        comboBoxHairDresser.Enabled = false;
                        comboBoxClient.Enabled = false;
                    }
                    break;
                case Role.Client:
                    {
                        if (dialogMode == DialogMode.Create)
                        {
                            comboBoxClient.SelectedValue = UserID;
                        }
                        if (comboBoxStatus.SelectedIndex != 0) 
                        {
                            comboBoxHairDresser.Enabled = false;
                            dateTimePickerStart.Enabled = false;
                            dataGridView1.ReadOnly = true;
                            this.Text = "Просмотр записи к парикмахеру";
                            buttonOK.Text = "Закрыть";
                        }
                        comboBoxStatus.Enabled = false;
                        comboBoxClient.Enabled = false;
                    }
                    break;
            }

        }

        void UpdateData()
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "barberDBDataSet.status". При необходимости она может быть перемещена или удалена.
                this.statusTableAdapter.Fill(this.barberDBDataSet.status);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "barberDBDataSet.client". При необходимости она может быть перемещена или удалена.
                this.clientTableAdapter.Fill(this.barberDBDataSet.client);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "barberDBDataSet.hairdresser". При необходимости она может быть перемещена или удалена.
                this.hairdresserTableAdapter.Fill(this.barberDBDataSet.hairdresser);
                if(UserRole != Role.Client || (dialogMode == DialogMode.Edit && UserRole==Role.Client))
                {   
                    // TODO: данная строка кода позволяет загрузить данные в таблицу "barberDBDataSet.administrator". При необходимости она может быть перемещена или удалена.
                    this.administratorTableAdapter.Fill(this.barberDBDataSet.administrator);
                }


                if (comboBoxClient.Items.Count == 0)
                    throw new MyDataException("Нет ни одного клиента! Невозможно создать запись к парикмахеру!");
                if (comboBoxStatus.Items.Count == 0)
                    throw new MyDataException("В системе отсутствует список статусов записей к парикмахеру! Невозможно создать запись к парикмахеру!");
                
                if (comboBoxHairDresser.Items.Count == 0)
                    throw new MyDataException("Нет ни одного парикмахера! Невозможно создать запись к парикмахеру!");
                
                if (Row != null)
                {
                    registrationviewBindingSource.DataSource = Row;
                    int registration_id = (int)((registrationviewBindingSource.Current as DataRow)["id_registration"]);
                    serviceRegTableAdapter.Fill(this.barberDBDataSet.serviceReg, registration_id);
                }
                else
                {
                    serviceRegTableAdapter.FillByDefault(this.barberDBDataSet.serviceReg);
                }
                if(dataGridView1.Rows.Count==0)
                    throw new MyDataException("Отстутствуют услуги! Невозможно создать запись к парикмахеру!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> SelectedServices = GetSelectedServices();
                if (SelectedServices.Count == 0)
                    throw new Exception("Для создания или изменения записи к парикмахеру нужно добавить хотя бы одну услугу");
                switch (UserRole)
                {
                    case Role.Administrator:
                        {
                            string sql_command_text;
                            if (dialogMode == DialogMode.Edit)
                            {
                                comboBoxAdmin.SelectedValue = UserID;
                                int registration_id = (int)((registrationviewBindingSource.Current as DataRow)["id_registration"]);
                                sql_command_text = string.Format("CALL public.create_or_update_registration_with_services({0}, {1}, {2}, '{3}', '{4}', {5}, {6})",
                                registration_id, comboBoxAdmin.SelectedValue, comboBoxClient.SelectedValue, comboBoxHairDresser.SelectedValue,
                                dateTimePickerStart.Value, comboBoxStatus.SelectedValue, "ARRAY[" + string.Join(",", SelectedServices) + "]");
                            }
                            else
                            {
                                sql_command_text = string.Format("CALL public.create_or_update_registration_with_services({0}, {1}, {2}, '{3}', '{4}', {5}, {6})",
                                "null", UserID, comboBoxClient.SelectedValue, comboBoxHairDresser.SelectedValue,
                                dateTimePickerStart.Value, comboBoxStatus.SelectedValue, "ARRAY[" + string.Join(",", SelectedServices) + "]");
                            }

                            using (var connection = new NpgsqlConnection(connectionString))
                            {
                                connection.Open();
                                using (NpgsqlCommand cmd = new NpgsqlCommand(sql_command_text, connection))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        break;
                    case Role.Hairdresser:
                        {
                            if (comboBoxStatus.SelectedIndex == 1)
                            {
                                string sql_command_text;
                                if (dialogMode == DialogMode.Edit)
                                {
                                    comboBoxAdmin.SelectedValue = UserID;
                                    int registration_id = (int)((registrationviewBindingSource.Current as DataRow)["id_registration"]);
                                    sql_command_text = string.Format("CALL public.create_or_update_registration_with_services({0}, {1}, {2}, '{3}', '{4}', {5}, {6})",
                                    registration_id, comboBoxAdmin.SelectedValue, comboBoxClient.SelectedValue, comboBoxHairDresser.SelectedValue,
                                    dateTimePickerStart.Value, comboBoxStatus.SelectedValue, "ARRAY[" + string.Join(",", SelectedServices) + "]");

                                    using (var connection = new NpgsqlConnection(connectionString))
                                    {
                                        connection.Open();
                                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql_command_text, connection))
                                        {
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case Role.Client:
                        {
                            if (comboBoxStatus.SelectedIndex == 0) 
                            {
                                string sql_command_text;
                                if (dialogMode == DialogMode.Edit)
                                {
                                    int registration_id = (int)((registrationviewBindingSource.Current as DataRow)["id_registration"]);
                                    sql_command_text = string.Format("CALL public.create_or_update_registration_with_services({0}, {1}, {2}, '{3}', '{4}', {5}, {6})",
                                    registration_id, comboBoxAdmin.SelectedValue?.ToString() ?? "null", comboBoxClient.SelectedValue, comboBoxHairDresser.SelectedValue,
                                    dateTimePickerStart.Value, comboBoxStatus.SelectedValue, "ARRAY[" + string.Join(",", SelectedServices) + "]");
                                }
                                else
                                {
                                    sql_command_text = string.Format("CALL public.create_or_update_registration_with_services({0}, {1}, {2}, '{3}', '{4}', {5}, {6})",
                                    "null", "null", UserID, comboBoxHairDresser.SelectedValue,
                                    dateTimePickerStart.Value, comboBoxStatus.SelectedValue, "ARRAY[" + string.Join(",", SelectedServices) + "]");
                                }

                                using (var connection = new NpgsqlConnection(connectionString))
                                {
                                    connection.Open();
                                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql_command_text, connection))
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                                
                        }
                        break;
                }
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            Ini();
        }
    }
}
