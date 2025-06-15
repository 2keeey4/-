using BarberShop.Code;
using System;
using System.Data;
using System.Data.Odbc;
using System.Security.Policy;
using System.Windows.Forms;

namespace BarberShop.Forms
{
    public partial class FormClient : Form
    {
        DialogMode dialogMode;
        public string Email;
        public string Password;
        public FormClient()
        {
            InitializeComponent();
            this.dialogMode = DialogMode.Create;
            this.Text = "Регистрация профиля клиента";
            buttonOK.Text = "Зарегистрировать";
        }
        public FormClient(DataRow row)
        {
            InitializeComponent();
            this.dialogMode = DialogMode.Edit;
            this.Text = "Редактирование профиля клиента";
            buttonOK.Text = "Изменить";
            clientBindingSource.DataSource = row;
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxName.Text))
                    throw new Exception("Введите ФИО");
                if (!textBoxPhone.MaskCompleted)
                    throw new Exception("Введите номер телефона");
                if (string.IsNullOrEmpty(textBoxEmail.Text))
                    throw new Exception("Введите Email");
                if (string.IsNullOrEmpty(textBoxPassword.Text))
                    throw new Exception("Введите пароль");
                if (string.IsNullOrEmpty(textBoxPasswordAgain.Text))
                    throw new Exception("Введите повторно пароль");
                if (textBoxPassword.Text != textBoxPasswordAgain.Text)
                    throw new Exception("Пароли не совпадают");

                long phone = Convert.ToInt64(textBoxPhone.Text);
                switch (dialogMode)
                {
                    case DialogMode.Create:
                        clientTableAdapter.Insert(textBoxName.Text, phone, textBoxEmail.Text, textBoxPassword.Text);
                        break;
                    case DialogMode.Edit:
                        if (clientBindingSource.Current != null)
                            clientTableAdapter.Update(clientBindingSource.Current as DataRow);
                        break;
                        
                }
                Email = textBoxEmail.Text;
                Password = textBoxPassword.Text;
                this.Close();
            }
            catch(OdbcException error)
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

        private void FormClient_Load(object sender, EventArgs e)
        {
            textBoxPasswordAgain.Text = textBoxPassword.Text;
        }
    }
}
