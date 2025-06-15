namespace BarberShop.Forms
{
    partial class RegistrationForm
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
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.registrationviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barberDBDataSet = new BarberShop.BarberDBDataSet();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.administratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxHairDresser = new System.Windows.Forms.ComboBox();
            this.hairdresserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.statusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonOK = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selectserviceDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idserviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameserviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceserviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceRegBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.clientTableAdapter();
            this.registrationviewTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.registrationviewTableAdapter();
            this.hairdresserTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.hairdresserTableAdapter();
            this.administratorTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.administratorTableAdapter();
            this.statusTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.statusTableAdapter();
            this.tableAdapterManager = new BarberShop.BarberDBDataSetTableAdapters.TableAdapterManager();
            this.serviceRegTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.serviceRegTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxAdmin = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.registrationviewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barberDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.administratorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hairdresserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceRegBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.registrationviewBindingSource, "id_client", true));
            this.comboBoxClient.DataSource = this.clientBindingSource;
            this.comboBoxClient.DisplayMember = "snp_client";
            this.comboBoxClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(239, 20);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(526, 33);
            this.comboBoxClient.TabIndex = 0;
            this.comboBoxClient.ValueMember = "id_client";
            // 
            // registrationviewBindingSource
            // 
            this.registrationviewBindingSource.DataMember = "registrationview";
            this.registrationviewBindingSource.DataSource = this.barberDBDataSet;
            // 
            // barberDBDataSet
            // 
            this.barberDBDataSet.DataSetName = "BarberDBDataSet";
            this.barberDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.DataMember = "client";
            this.clientBindingSource.DataSource = this.barberDBDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ФИО клиента:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "ФИО парикмахера:";
            // 
            // administratorBindingSource
            // 
            this.administratorBindingSource.DataMember = "administrator";
            this.administratorBindingSource.DataSource = this.barberDBDataSet;
            // 
            // comboBoxHairDresser
            // 
            this.comboBoxHairDresser.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.registrationviewBindingSource, "id_hairdresser", true));
            this.comboBoxHairDresser.DataSource = this.hairdresserBindingSource;
            this.comboBoxHairDresser.DisplayMember = "snp_hairdresser";
            this.comboBoxHairDresser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHairDresser.FormattingEnabled = true;
            this.comboBoxHairDresser.Location = new System.Drawing.Point(239, 73);
            this.comboBoxHairDresser.Name = "comboBoxHairDresser";
            this.comboBoxHairDresser.Size = new System.Drawing.Size(526, 33);
            this.comboBoxHairDresser.TabIndex = 1;
            this.comboBoxHairDresser.ValueMember = "id_hairdresser";
            // 
            // hairdresserBindingSource
            // 
            this.hairdresserBindingSource.DataMember = "hairdresser";
            this.hairdresserBindingSource.DataSource = this.barberDBDataSet;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(446, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Статус:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.registrationviewBindingSource, "status_registration", true));
            this.comboBoxStatus.DataSource = this.statusBindingSource;
            this.comboBoxStatus.DisplayMember = "name_status";
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(530, 182);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(235, 33);
            this.comboBoxStatus.TabIndex = 6;
            this.comboBoxStatus.ValueMember = "code_status";
            // 
            // statusBindingSource
            // 
            this.statusBindingSource.DataMember = "status";
            this.statusBindingSource.DataSource = this.barberDBDataSet;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(530, 681);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(235, 44);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "button1";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerStart.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.registrationviewBindingSource, "date_registration", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "f"));
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(239, 185);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.ShowUpDown = true;
            this.dateTimePickerStart.Size = new System.Drawing.Size(201, 30);
            this.dateTimePickerStart.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Дата и время записи";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectserviceDataGridViewCheckBoxColumn,
            this.idserviceDataGridViewTextBoxColumn,
            this.nameserviceDataGridViewTextBoxColumn,
            this.priceserviceDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.serviceRegBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(17, 264);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(748, 411);
            this.dataGridView1.TabIndex = 11;
            // 
            // selectserviceDataGridViewCheckBoxColumn
            // 
            this.selectserviceDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.selectserviceDataGridViewCheckBoxColumn.DataPropertyName = "select_service";
            this.selectserviceDataGridViewCheckBoxColumn.FillWeight = 80.21391F;
            this.selectserviceDataGridViewCheckBoxColumn.HeaderText = "";
            this.selectserviceDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.selectserviceDataGridViewCheckBoxColumn.Name = "selectserviceDataGridViewCheckBoxColumn";
            this.selectserviceDataGridViewCheckBoxColumn.Width = 25;
            // 
            // idserviceDataGridViewTextBoxColumn
            // 
            this.idserviceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idserviceDataGridViewTextBoxColumn.DataPropertyName = "id_service";
            this.idserviceDataGridViewTextBoxColumn.HeaderText = "id_service";
            this.idserviceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idserviceDataGridViewTextBoxColumn.Name = "idserviceDataGridViewTextBoxColumn";
            this.idserviceDataGridViewTextBoxColumn.ReadOnly = true;
            this.idserviceDataGridViewTextBoxColumn.Visible = false;
            this.idserviceDataGridViewTextBoxColumn.Width = 25;
            // 
            // nameserviceDataGridViewTextBoxColumn
            // 
            this.nameserviceDataGridViewTextBoxColumn.DataPropertyName = "name_service";
            this.nameserviceDataGridViewTextBoxColumn.FillWeight = 311.8716F;
            this.nameserviceDataGridViewTextBoxColumn.HeaderText = "Название";
            this.nameserviceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameserviceDataGridViewTextBoxColumn.Name = "nameserviceDataGridViewTextBoxColumn";
            this.nameserviceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceserviceDataGridViewTextBoxColumn
            // 
            this.priceserviceDataGridViewTextBoxColumn.DataPropertyName = "price_service";
            this.priceserviceDataGridViewTextBoxColumn.FillWeight = 103.9572F;
            this.priceserviceDataGridViewTextBoxColumn.HeaderText = "Стоимость";
            this.priceserviceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceserviceDataGridViewTextBoxColumn.Name = "priceserviceDataGridViewTextBoxColumn";
            this.priceserviceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "duration";
            this.durationDataGridViewTextBoxColumn.FillWeight = 103.9572F;
            this.durationDataGridViewTextBoxColumn.HeaderText = "Продолжительность";
            this.durationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serviceRegBindingSource
            // 
            this.serviceRegBindingSource.DataMember = "serviceReg";
            this.serviceRegBindingSource.DataSource = this.barberDBDataSet;
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // registrationviewTableAdapter
            // 
            this.registrationviewTableAdapter.ClearBeforeFill = true;
            // 
            // hairdresserTableAdapter
            // 
            this.hairdresserTableAdapter.ClearBeforeFill = true;
            // 
            // administratorTableAdapter
            // 
            this.administratorTableAdapter.ClearBeforeFill = true;
            // 
            // statusTableAdapter
            // 
            this.statusTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.administratorTableAdapter = this.administratorTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.clientTableAdapter = this.clientTableAdapter;
            this.tableAdapterManager.hairdresserTableAdapter = this.hairdresserTableAdapter;
            this.tableAdapterManager.includesTableAdapter = null;
            this.tableAdapterManager.registrationTableAdapter = null;
            this.tableAdapterManager.serviceTableAdapter = null;
            this.tableAdapterManager.statusTableAdapter = this.statusTableAdapter;
            this.tableAdapterManager.UpdateOrder = BarberShop.BarberDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // serviceRegTableAdapter
            // 
            this.serviceRegTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Список услуг";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "ФИО администратора:";
            // 
            // comboBoxAdmin
            // 
            this.comboBoxAdmin.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.registrationviewBindingSource, "id_administrator", true));
            this.comboBoxAdmin.DataSource = this.administratorBindingSource;
            this.comboBoxAdmin.DisplayMember = "snp_administrator";
            this.comboBoxAdmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAdmin.Enabled = false;
            this.comboBoxAdmin.FormattingEnabled = true;
            this.comboBoxAdmin.Location = new System.Drawing.Point(239, 128);
            this.comboBoxAdmin.Name = "comboBoxAdmin";
            this.comboBoxAdmin.Size = new System.Drawing.Size(526, 33);
            this.comboBoxAdmin.TabIndex = 1;
            this.comboBoxAdmin.ValueMember = "id_administrator";
            // 
            // RegistrationForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 745);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.comboBoxAdmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxHairDresser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxClient);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RegistrationForm";
            this.Text = "Запись к парикмахеру";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registrationviewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barberDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.administratorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hairdresserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceRegBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxHairDresser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label5;
        private BarberDBDataSet barberDBDataSet;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private BarberDBDataSetTableAdapters.clientTableAdapter clientTableAdapter;
        private System.Windows.Forms.BindingSource registrationviewBindingSource;
        private BarberDBDataSetTableAdapters.registrationviewTableAdapter registrationviewTableAdapter;
        private System.Windows.Forms.BindingSource hairdresserBindingSource;
        private BarberDBDataSetTableAdapters.hairdresserTableAdapter hairdresserTableAdapter;
        private System.Windows.Forms.BindingSource administratorBindingSource;
        private BarberDBDataSetTableAdapters.administratorTableAdapter administratorTableAdapter;
        private System.Windows.Forms.BindingSource statusBindingSource;
        private BarberDBDataSetTableAdapters.statusTableAdapter statusTableAdapter;
        private BarberDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource serviceRegBindingSource;
        private BarberDBDataSetTableAdapters.serviceRegTableAdapter serviceRegTableAdapter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectserviceDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idserviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameserviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceserviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxAdmin;
    }
}