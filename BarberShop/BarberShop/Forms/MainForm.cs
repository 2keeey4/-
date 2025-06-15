using BarberShop.BarberDBDataSetTableAdapters;
using BarberShop.Code;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BarberShop.Forms
{
    public enum UserType
    {
        Client, Hairdresser, Administrator
    }
    public enum StatusRegistration
    { 
        Create=0,Form=1,Process=2,Done=3
    }

    public enum DialogMode
    {
        Create, Edit
    }
    public partial class MainForm : Form
    {
        public int UserID;
        public Role UserRole = Role.Administrator;
        public MainForm(int userID)
        {
            InitializeComponent();
            dateTimePickerStart.Value = new DateTime(2020, 1, 1);
            dateTimePickerEnd.Value= new DateTime(2027, 1, 1);
            this.UserID = userID;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.statusTableAdapter.Fill(this.barberDBDataSet.status);
                this.Text = " Администратор - " + administratorTableAdapter.GetDataByID(UserID).Rows[0]["snp_administrator"].ToString();
                UpdateData();
                toolStripComboBoxUserType.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UpdateData()
        {
            UpdateRegistration();
            UpdateUser();
            UpdateServices();
        }
        void UpdateServices()
        {
            this.serviceTableAdapter.SearchBy(this.barberDBDataSet.service, toolStripTextBoxServiceName.Text);
        }
        void UpdateHeaders(DataGridView grid)
        {
            if (grid != null)
            {
                if (grid.DataSource != null)
                {
                    DataTable table = grid.DataSource as DataTable;
                    foreach (DataGridViewColumn col in grid.Columns)
                    {
                        col.HeaderText = table.Columns[col.Name].Caption;
                        //col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
        }

        void UpdateUser()
        {
            switch ((UserType)toolStripComboBoxUserType.SelectedIndex)
            {
                case UserType.Client:
                    dataGridViewUser.DataSource = clientTableAdapter.SearchDataBy(toolStripTextBoxFIO.Text);
                    UpdateHeaders(dataGridViewUser);
                    break;
                case UserType.Hairdresser:
                    dataGridViewUser.DataSource = hairdresserTableAdapter.SearchDataBy(toolStripTextBoxFIO.Text);
                    UpdateHeaders(dataGridViewUser);
                    break;
                case UserType.Administrator:
                    dataGridViewUser.DataSource = administratorTableAdapter.SearchDataBy(toolStripTextBoxFIO.Text);
                    UpdateHeaders(dataGridViewUser);
                    break;
            }
        }
        void UpdateRegistration()
        {
            if(comboBox1.SelectedValue!=null)
            {
                DateTime Start = dateTimePickerStart.Value.Date;
                DateTime End = dateTimePickerEnd.Value.Date;
                switch ((StatusRegistration)comboBox1.SelectedValue)
                {
                    case StatusRegistration.Create:
                        this.registrationviewTableAdapter.SearchBy(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Create);
                        break;
                    case StatusRegistration.Form:
                        this.registrationviewTableAdapter.SearchBy(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Form);
                        break;
                    case StatusRegistration.Process:
                        this.registrationviewTableAdapter.SearchBy(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Process);
                        break;
                    case StatusRegistration.Done:
                        this.registrationviewTableAdapter.SearchBy(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Done);
                        break;
                };
            }
        }


        private void toolStripComboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox userType = (ComboBox)sender;
                UpdateUser();
                if (dataGridViewUser.ColumnCount > 0)
                {
                    dataGridViewUser.Columns[0].Visible = false;
                    if (dataGridViewUser.RowCount > 0)
                    {
                        dataGridViewUser.Rows[0].Selected = true;
                        dataGridViewUser.CurrentCell = dataGridViewUser.Rows[0].Cells[1];
                    }
                }      
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButtonAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                Form form;
                switch (toolStripComboBoxUserType.SelectedIndex)
                {
                    case (int)UserType.Client:
                        form = new FormClient();
                        form.ShowDialog();
                        break;
                    case (int)UserType.Hairdresser:
                        form = new FormEmployee(UserType.Hairdresser);
                        form.ShowDialog();
                        break;
                    case (int)UserType.Administrator:
                        form = new FormEmployee(UserType.Administrator);
                        form.ShowDialog();
                        break;
                }
                toolStripTextBoxFIO.Clear();
                UpdateUser();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridViewUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < ((DataGridView)sender).RowCount)
                {
                    if(dataGridViewUser.CurrentRow!=null)
                    {
                        DataRow current_row = ((DataRowView)(dataGridViewUser.CurrentRow).DataBoundItem).Row;
                        switch (toolStripComboBoxUserType.SelectedIndex)
                        {
                            case (int)UserType.Client:
                                Form clientForm = new FormClient(current_row);
                                clientForm.ShowDialog();
                                break;
                            case (int)UserType.Hairdresser:
                                Form hairdresserForm = new FormEmployee(current_row, UserType.Hairdresser);
                                hairdresserForm.ShowDialog();
                                break;
                            case (int)UserType.Administrator:
                                Form administratorForm = new FormEmployee(current_row, UserType.Administrator);
                                administratorForm.ShowDialog();
                                break;
                        }
                        UpdateUser();
                        UpdateRegistration();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButtonDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewUser.CurrentRow != null)
                {
                    if (MessageBox.Show("При удалении пользователя, будут удалены все связанные с ним записи к парикмахеру. Продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        int user_id = Convert.ToInt32(((DataRowView)(dataGridViewUser.CurrentRow).DataBoundItem).Row[0]);
                        switch (toolStripComboBoxUserType.SelectedIndex)
                        {
                            case (int)UserType.Client:
                                clientTableAdapter.DeleteQuery(user_id);
                                break;
                            case (int)UserType.Hairdresser:
                                hairdresserTableAdapter.DeleteQuery(user_id);
                                break;
                            case (int)UserType.Administrator:
                                administratorTableAdapter.DeleteQuery(user_id);
                                break;
                        }
                        UpdateUser();
                        UpdateRegistration();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void toolStripButtonAddReg_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrationForm form = new RegistrationForm(UserID,UserRole);
                form.ShowDialog();
                UpdateRegistration();
            }
            catch(MyDataException error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridViewReg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                UpdateRegistration();
                DataGridView table = sender as DataGridView;
                if (e.RowIndex >= 0 && e.RowIndex < table.RowCount && table.CurrentRow!=null)
                {
                    DataRow current_row = ((DataRowView)(table.CurrentRow).DataBoundItem).Row;
                    RegistrationForm form = new RegistrationForm(current_row, UserID, UserRole);
                    form.ShowDialog();
                    UpdateRegistration();
                }
            }
            catch (MyDataException error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButtonDeleteReg_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateRegistration();
                if (dataGridViewReg.CurrentRow != null)
                {
                    int reg_id = Convert.ToInt32(((DataRowView)(dataGridViewReg.CurrentRow).DataBoundItem).Row[0]);
                    registrationTableAdapter.DeleteQuery(reg_id);
                    UpdateRegistration();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateData();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void toolStripButtonAddService_Click(object sender, EventArgs e)
        {
            try
            {
                FormService form = new FormService();
                form.ShowDialog();
                toolStripTextBoxServiceName.Clear();
                UpdateServices();
            }
            catch (MyDataException error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView table = sender as DataGridView;
                if (e.RowIndex >= 0 && e.RowIndex < table.RowCount && table.CurrentRow != null)
                {
                    DataRow current_row = ((DataRowView)(table.CurrentRow).DataBoundItem).Row;
                    FormService form = new FormService(current_row);
                    form.ShowDialog();
                    UpdateServices();
                    UpdateRegistration();
                }
            }
            catch (MyDataException error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonRemoveService_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewServices.CurrentRow != null)
                {
                    int reg_id = Convert.ToInt32(((DataRowView)(dataGridViewServices.CurrentRow).DataBoundItem).Row[0]);
                    serviceTableAdapter.DeleteQuery(reg_id);
                    UpdateServices();
                    UpdateRegistration();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripTextBoxFIO_TextChanged(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void toolStripTextBoxServiceName_TextChanged(object sender, EventArgs e)
        {
            UpdateServices();
        }

        private void PeriodChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerEnd.MinDate = dateTimePickerStart.Value;
                UpdateRegistration();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PeriodChangedKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dateTimePickerEnd.MinDate = dateTimePickerStart.Value;
                    UpdateRegistration();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuServicesReport_Click(object sender, EventArgs e)
        {
            ReportServiceForm form = new ReportServiceForm();
            form.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateRegistration();
        }
        bool exit = true;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(exit)
                Application.Exit();
        }

        private void ExitSystemButton_Click(object sender, EventArgs e)
        {
            exit = false;
            this.Close();
        }
    }
}
