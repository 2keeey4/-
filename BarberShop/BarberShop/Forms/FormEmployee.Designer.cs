namespace BarberShop.Forms
{
    partial class FormEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxPhone = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassport = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPasswordAgain = new System.Windows.Forms.TextBox();
            this.barberDBDataSet = new BarberShop.BarberDBDataSet();
            this.hairdresserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hairdresserTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.hairdresserTableAdapter();
            this.administratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.administratorTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.administratorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.barberDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hairdresserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.administratorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(593, 294);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(171, 41);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "button1";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(583, 77);
            this.textBoxPhone.Mask = "+7(000) 000-00-00";
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(181, 30);
            this.textBoxPhone.TabIndex = 2;
            this.textBoxPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Паспорт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Номер телефона:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(108, 23);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(656, 30);
            this.textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "ФИО:";
            // 
            // textBoxPassport
            // 
            this.textBoxPassport.Location = new System.Drawing.Point(108, 74);
            this.textBoxPassport.Mask = "серия (0000) номер (000000)";
            this.textBoxPassport.Name = "textBoxPassport";
            this.textBoxPassport.Size = new System.Drawing.Size(289, 30);
            this.textBoxPassport.TabIndex = 1;
            this.textBoxPassport.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Пароль:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(108, 134);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(656, 30);
            this.textBoxEmail.TabIndex = 11;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(108, 189);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(656, 30);
            this.textBoxPassword.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 56);
            this.label6.TabIndex = 13;
            this.label6.Text = "Повтор пароля:";
            // 
            // textBoxPasswordAgain
            // 
            this.textBoxPasswordAgain.Location = new System.Drawing.Point(108, 244);
            this.textBoxPasswordAgain.Name = "textBoxPasswordAgain";
            this.textBoxPasswordAgain.Size = new System.Drawing.Size(656, 30);
            this.textBoxPasswordAgain.TabIndex = 12;
            // 
            // barberDBDataSet
            // 
            this.barberDBDataSet.DataSetName = "BarberDBDataSet";
            this.barberDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hairdresserBindingSource
            // 
            this.hairdresserBindingSource.DataMember = "hairdresser";
            this.hairdresserBindingSource.DataSource = this.barberDBDataSet;
            // 
            // hairdresserTableAdapter
            // 
            this.hairdresserTableAdapter.ClearBeforeFill = true;
            // 
            // administratorBindingSource
            // 
            this.administratorBindingSource.DataMember = "administrator";
            this.administratorBindingSource.DataSource = this.barberDBDataSet;
            // 
            // administratorTableAdapter
            // 
            this.administratorTableAdapter.ClearBeforeFill = true;
            // 
            // FormEmployee
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 350);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPasswordAgain);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPassport);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormEmployee";
            this.Load += new System.EventHandler(this.FormEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barberDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hairdresserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.administratorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.MaskedTextBox textBoxPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox textBoxPassport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPasswordAgain;
        private BarberDBDataSet barberDBDataSet;
        private System.Windows.Forms.BindingSource hairdresserBindingSource;
        private BarberDBDataSetTableAdapters.hairdresserTableAdapter hairdresserTableAdapter;
        private System.Windows.Forms.BindingSource administratorBindingSource;
        private BarberDBDataSetTableAdapters.administratorTableAdapter administratorTableAdapter;
    }
}