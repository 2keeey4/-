using BarberShop.BarberDBDataSetTableAdapters;
using BarberShop.Code;
using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;

namespace BarberShop.Forms
{
    public partial class FormEmployee : Form
    {
        UserType type;
        DialogMode dialogMode;
        void IniForm(DialogMode mode,string text)
        {
            switch (mode)
            {
                case DialogMode.Create:
                    this.Text = "Регистрация профиля "+ text;
                    buttonOK.Text = "Зарегистрировать";
                    break;
                case DialogMode.Edit:
                    this.Text = "Редактирование профиля "+ text;
                    buttonOK.Text = "Изменить";
                    break;
            }
        }
        public FormEmployee(UserType type)
        {
            InitializeComponent();
            this.type = type;
            dialogMode = DialogMode.Create;
            switch (type)
            {
                case UserType.Hairdresser:
                    IniForm(dialogMode, "парикмахера");
                    break;
                case UserType.Administrator:
                    IniForm(dialogMode, "администратора");
                    break;
            }
        }
        public FormEmployee(DataRow row, UserType type)
        {
            InitializeComponent();
            this.type = type;
            dialogMode = DialogMode.Edit;
            switch (type)
            {
                case UserType.Hairdresser:
                    IniForm(dialogMode, "парикмахера");
                    this.textBoxPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hairdresserBindingSource, "phone_hairdresser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hairdresserBindingSource, "snp_hairdresser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    this.textBoxPassport.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hairdresserBindingSource, "passport_hairdresser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    this.textBoxEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hairdresserBindingSource, "email_hairdresser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    this.textBoxPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.hairdresserBindingSource, "password_hairdresser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));   
                    hairdresserBindingSource.DataSource = row;
                    break;
                case UserType.Administrator:
                    IniForm(dialogMode, "администратора");
                    this.textBoxPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.administratorBindingSource, "phone_administrator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.administratorBindingSource, "snp_administrator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    this.textBoxPassport.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.administratorBindingSource, "passport_administrator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    this.textBoxEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.administratorBindingSource, "email_administrator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    this.textBoxPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.administratorBindingSource, "password_administrator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
                    administratorBindingSource.DataSource = row;
                    break;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxName.Text))
                    throw new Exception("Введите ФИО");
                if (!textBoxPassport.MaskCompleted)
                    throw new Exception("Введите данные паспорта");
                if (!textBoxPhone.MaskCompleted)
                    throw new Exception("Введите номер телефона");
                if (string.IsNullOrEmpty(textBoxEmail.Text))
                    throw new Exception("Введите Email");
                if (string.IsNullOrEmpty(textBoxPassword.Text))
                    throw new Exception("Введите пароль");
                if (string.IsNullOrEmpty(textBoxPasswordAgain.Text))
                    throw new Exception("Введите повторно пароль");
                if(textBoxPassword.Text!= textBoxPasswordAgain.Text)
                    throw new Exception("Пароли не совпадают");

                long phone = Convert.ToInt64(textBoxPhone.Text);
                long passport= Convert.ToInt64(textBoxPassport.Text);
                switch (dialogMode)
                {
                    case DialogMode.Create:
                        switch (type)
                        {
                            case UserType.Hairdresser:               
                                hairdresserTableAdapter.Insert(textBoxName.Text, phone, passport, textBoxEmail.Text,textBoxPassword.Text);
                                break;
                            case UserType.Administrator:
                                administratorTableAdapter.Insert(textBoxName.Text, phone, passport, textBoxEmail.Text, textBoxPassword.Text);
                                break;
                        }
                        break;
                    case DialogMode.Edit:
                        switch (type)
                        {
                            case UserType.Hairdresser:
                                if (hairdresserBindingSource.Current != null)
                                    hairdresserTableAdapter.Update(hairdresserBindingSource.Current as DataRow);
                                break;
                            case UserType.Administrator:
                                if (administratorBindingSource.Current != null)
                                    administratorTableAdapter.Update(administratorBindingSource.Current as DataRow);
                                break;
                        }
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

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            textBoxPasswordAgain.Text = textBoxPassword.Text;
        }
    }
}
