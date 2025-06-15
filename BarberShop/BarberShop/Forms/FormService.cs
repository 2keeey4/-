using BarberShop.BarberDBDataSetTableAdapters;
using BarberShop.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarberShop.Forms
{
    public partial class FormService : Form
    {
        DialogMode dialogMode;
        public FormService()
        {
            InitializeComponent();
            this.dialogMode = DialogMode.Create;
            this.Text = "Создание новой услуги";
            buttonOK.Text = "Создать";
        }
        public FormService(DataRow row)
        {
            InitializeComponent();
            this.dialogMode = DialogMode.Edit;
            this.Text = "Редактирование услуги";
            buttonOK.Text = "Изменить";
            serviceBindingSource.DataSource = row;
        }

        private void FormService_Load(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(richTextBoxName.Text))
                    throw new Exception("Введите название услуги");
                switch (dialogMode)
                {
                    case DialogMode.Create:
                        serviceTableAdapter.InsertQuery(richTextBoxName.Text, numericUpDownPrice.Value, dateTimePicker1.Value);
                        break;
                    case DialogMode.Edit:
                        if (serviceBindingSource.Current != null)
                            serviceTableAdapter.Update(serviceBindingSource.Current as DataRow);
                        break;

                }
                this.Close();
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

    }
}
