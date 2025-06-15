using BarberShop.BarberDBDataSetTableAdapters;
using BarberShop.Code;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BarberShop.Forms
{

    public partial class MainFormClient : Form
    {
        public int UserID;
        public Role UserRole = Role.Client;
        public MainFormClient(int userID)
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
                this.Text=" Клиент - "+ clientTableAdapter.GetDataByID(UserID).Rows[0]["snp_client"].ToString();
                UpdateData();
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void UpdateData()
        {
            UpdateRegistration();
            UpdateServices();
        }
        void UpdateServices()
        {
            this.serviceTableAdapter.SearchBy(this.barberDBDataSet.service, toolStripTextBoxServiceName.Text);
        }


        void UpdateRegistration()
        {
            if (comboBox1.SelectedValue != null)
            {
                DateTime Start = dateTimePickerStart.Value.Date;
                DateTime End = dateTimePickerEnd.Value.Date;
                switch ((StatusRegistration)comboBox1.SelectedValue)
                {
                    case StatusRegistration.Create:
                        this.registrationviewTableAdapter.FillByID(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Create,UserID);
                        break;
                    case StatusRegistration.Form:
                        this.registrationviewTableAdapter.FillByID(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Form,UserID);
                        break;
                    case StatusRegistration.Process:
                        this.registrationviewTableAdapter.FillByID(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Process, UserID);
                        break;
                    case StatusRegistration.Done:
                        this.registrationviewTableAdapter.FillByID(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Done, UserID);
                        break;
                };
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
                if (e.RowIndex >= 0 && e.RowIndex < table.RowCount && table.CurrentRow != null)
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateRegistration();
        }

        bool exit = true;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
                Application.Exit();
        }

        private void ExitSystemButton_Click(object sender, EventArgs e)
        {
            exit = false;
            this.Close();
        }
    }
}
