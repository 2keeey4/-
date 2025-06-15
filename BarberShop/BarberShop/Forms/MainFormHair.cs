using BarberShop.BarberDBDataSetTableAdapters;
using BarberShop.Code;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BarberShop.Forms
{

    public partial class MainFormHair : Form
    {
        public int UserID;
        public Role UserRole = Role.Hairdresser;
        public MainFormHair(int userID)
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
                this.statusTableAdapter.FillBy(this.barberDBDataSet.status);
                this.Text=" Парикмахер - "+ hairdresserTableAdapter.GetDataByID(UserID).Rows[0]["snp_hairdresser"].ToString();
                UpdateData();
                comboBox1_SelectedIndexChanged_1(null, null);
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
                    case StatusRegistration.Form:
                        this.registrationviewTableAdapter.FillByHairID(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Form,UserID);
                        break;
                    case StatusRegistration.Process:
                        this.registrationviewTableAdapter.FillByHairID(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Process, UserID);
                        break;
                    case StatusRegistration.Done:
                        this.registrationviewTableAdapter.FillByHairID(this.barberDBDataSet.registrationview, Start, End, (int)StatusRegistration.Done, UserID);
                        break;
                };
            }
        }


        private void toolStripButtonAddReg_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateRegistration();
                if (dataGridViewReg.CurrentRow != null)
                {
                    int reg_id = Convert.ToInt32(((DataRowView)(dataGridViewReg.CurrentRow).DataBoundItem).Row[0]);
                    switch ((StatusRegistration)comboBox1.SelectedValue)
                    {
                        case StatusRegistration.Form:
                            registrationTableAdapter.UpdateQuery(2, reg_id);
                        break;
                        case StatusRegistration.Process:
                            registrationTableAdapter.UpdateQuery(3, reg_id);
                            break;
                    };
                    UpdateRegistration();
                }   
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
            switch ((StatusRegistration)comboBox1.SelectedValue)
            {
                case StatusRegistration.Form:
                    toolStripButtonReg.Visible = true;
                    toolStripButtonReg.Enabled = true;
                    toolStripButtonReg.Text = "Принять клиента";
                    break;
                case StatusRegistration.Process:
                    toolStripButtonReg.Visible = true;
                    toolStripButtonReg.Enabled = true;
                    toolStripButtonReg.Text = "Завершить прием";
                    break;
                case StatusRegistration.Done:
                    toolStripButtonReg.Visible = false;
                    toolStripButtonReg.Enabled = false;
                    toolStripButtonReg.Text = "";
                    break;
            };
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
