namespace BarberShop.Forms
{
    partial class MainFormClient
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormClient));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barberDBDataSet = new BarberShop.BarberDBDataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewReg = new System.Windows.Forms.DataGridView();
            this.idregistrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateregistrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enddataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idadministratorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idclientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idhairdresserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusregistrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countservicesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_services_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrationviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddReg = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteReg = new System.Windows.Forms.ToolStripButton();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridViewServices = new System.Windows.Forms.DataGridView();
            this.nameserviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceserviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idserviceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripAddService = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxServiceName = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitSystemButton = new System.Windows.Forms.ToolStripMenuItem();
            this.clientTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.clientTableAdapter();
            this.hairdresserTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.hairdresserTableAdapter();
            this.administratorTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.administratorTableAdapter();
            this.registrationviewTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.registrationviewTableAdapter();
            this.serviceTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.serviceTableAdapter();
            this.registrationTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.registrationTableAdapter();
            this.statusTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.statusTableAdapter();
            this.toolStripButtonAddUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxFIO = new System.Windows.Forms.ToolStripTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barberDBDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationviewBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            this.toolStripAddService.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 36);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1219, 562);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.dataGridViewReg);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1211, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Записи к парикмахеру";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(935, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 49);
            this.panel2.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.statusBindingSource;
            this.comboBox1.DisplayMember = "name_status";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(78, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(186, 33);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.ValueMember = "code_status";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // statusBindingSource
            // 
            this.statusBindingSource.DataMember = "status";
            this.statusBindingSource.DataSource = this.barberDBDataSet;
            // 
            // barberDBDataSet
            // 
            this.barberDBDataSet.DataSetName = "BarberDBDataSet";
            this.barberDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(2, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Статус:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.dateTimePickerEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePickerStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(137, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 49);
            this.panel1.TabIndex = 2;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(390, 12);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 30);
            this.dateTimePickerEnd.TabIndex = 3;
            this.dateTimePickerEnd.CloseUp += new System.EventHandler(this.PeriodChanged);
            this.dateTimePickerEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PeriodChangedKeyDown);
            this.dateTimePickerEnd.Leave += new System.EventHandler(this.PeriodChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(358, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "до";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(152, 12);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 30);
            this.dateTimePickerStart.TabIndex = 1;
            this.dateTimePickerStart.CloseUp += new System.EventHandler(this.PeriodChanged);
            this.dateTimePickerStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PeriodChangedKeyDown);
            this.dateTimePickerStart.Leave += new System.EventHandler(this.PeriodChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата записи: от";
            // 
            // dataGridViewReg
            // 
            this.dataGridViewReg.AllowUserToAddRows = false;
            this.dataGridViewReg.AllowUserToDeleteRows = false;
            this.dataGridViewReg.AutoGenerateColumns = false;
            this.dataGridViewReg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idregistrationDataGridViewTextBoxColumn,
            this.dateregistrationDataGridViewTextBoxColumn,
            this.enddataDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1,
            this.idadministratorDataGridViewTextBoxColumn,
            this.idclientDataGridViewTextBoxColumn,
            this.idhairdresserDataGridViewTextBoxColumn,
            this.statusregistrationDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn4,
            this.countservicesDataGridViewTextBoxColumn,
            this.price_services_column});
            this.dataGridViewReg.DataSource = this.registrationviewBindingSource;
            this.dataGridViewReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReg.Location = new System.Drawing.Point(4, 52);
            this.dataGridViewReg.MultiSelect = false;
            this.dataGridViewReg.Name = "dataGridViewReg";
            this.dataGridViewReg.ReadOnly = true;
            this.dataGridViewReg.RowHeadersVisible = false;
            this.dataGridViewReg.RowHeadersWidth = 51;
            this.dataGridViewReg.RowTemplate.Height = 24;
            this.dataGridViewReg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReg.Size = new System.Drawing.Size(1203, 467);
            this.dataGridViewReg.TabIndex = 1;
            this.dataGridViewReg.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReg_CellDoubleClick);
            // 
            // idregistrationDataGridViewTextBoxColumn
            // 
            this.idregistrationDataGridViewTextBoxColumn.DataPropertyName = "id_registration";
            this.idregistrationDataGridViewTextBoxColumn.HeaderText = "Номер записи";
            this.idregistrationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idregistrationDataGridViewTextBoxColumn.Name = "idregistrationDataGridViewTextBoxColumn";
            this.idregistrationDataGridViewTextBoxColumn.ReadOnly = true;
            this.idregistrationDataGridViewTextBoxColumn.Width = 158;
            // 
            // dateregistrationDataGridViewTextBoxColumn
            // 
            this.dateregistrationDataGridViewTextBoxColumn.DataPropertyName = "date_registration";
            this.dateregistrationDataGridViewTextBoxColumn.HeaderText = "Начало приема";
            this.dateregistrationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateregistrationDataGridViewTextBoxColumn.Name = "dateregistrationDataGridViewTextBoxColumn";
            this.dateregistrationDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateregistrationDataGridViewTextBoxColumn.Width = 168;
            // 
            // enddataDataGridViewTextBoxColumn
            // 
            this.enddataDataGridViewTextBoxColumn.DataPropertyName = "end_data";
            this.enddataDataGridViewTextBoxColumn.HeaderText = "Окончание приема";
            this.enddataDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.enddataDataGridViewTextBoxColumn.Name = "enddataDataGridViewTextBoxColumn";
            this.enddataDataGridViewTextBoxColumn.ReadOnly = true;
            this.enddataDataGridViewTextBoxColumn.Width = 199;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "snp_client";
            this.dataGridViewTextBoxColumn2.HeaderText = "ФИО клиента";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 156;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "snp_hairdresser";
            this.dataGridViewTextBoxColumn3.HeaderText = "ФИО парикмахера";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 197;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "snp_administrator";
            this.dataGridViewTextBoxColumn1.HeaderText = "ФИО администратора";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 230;
            // 
            // idadministratorDataGridViewTextBoxColumn
            // 
            this.idadministratorDataGridViewTextBoxColumn.DataPropertyName = "id_administrator";
            this.idadministratorDataGridViewTextBoxColumn.HeaderText = "id_administrator";
            this.idadministratorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idadministratorDataGridViewTextBoxColumn.Name = "idadministratorDataGridViewTextBoxColumn";
            this.idadministratorDataGridViewTextBoxColumn.ReadOnly = true;
            this.idadministratorDataGridViewTextBoxColumn.Visible = false;
            this.idadministratorDataGridViewTextBoxColumn.Width = 178;
            // 
            // idclientDataGridViewTextBoxColumn
            // 
            this.idclientDataGridViewTextBoxColumn.DataPropertyName = "id_client";
            this.idclientDataGridViewTextBoxColumn.HeaderText = "id_client";
            this.idclientDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idclientDataGridViewTextBoxColumn.Name = "idclientDataGridViewTextBoxColumn";
            this.idclientDataGridViewTextBoxColumn.ReadOnly = true;
            this.idclientDataGridViewTextBoxColumn.Visible = false;
            this.idclientDataGridViewTextBoxColumn.Width = 112;
            // 
            // idhairdresserDataGridViewTextBoxColumn
            // 
            this.idhairdresserDataGridViewTextBoxColumn.DataPropertyName = "id_hairdresser";
            this.idhairdresserDataGridViewTextBoxColumn.HeaderText = "id_hairdresser";
            this.idhairdresserDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idhairdresserDataGridViewTextBoxColumn.Name = "idhairdresserDataGridViewTextBoxColumn";
            this.idhairdresserDataGridViewTextBoxColumn.ReadOnly = true;
            this.idhairdresserDataGridViewTextBoxColumn.Visible = false;
            this.idhairdresserDataGridViewTextBoxColumn.Width = 164;
            // 
            // statusregistrationDataGridViewTextBoxColumn
            // 
            this.statusregistrationDataGridViewTextBoxColumn.DataPropertyName = "status_registration";
            this.statusregistrationDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusregistrationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusregistrationDataGridViewTextBoxColumn.Name = "statusregistrationDataGridViewTextBoxColumn";
            this.statusregistrationDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusregistrationDataGridViewTextBoxColumn.Visible = false;
            this.statusregistrationDataGridViewTextBoxColumn.Width = 107;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "name_status";
            this.dataGridViewTextBoxColumn4.HeaderText = "Статус";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 107;
            // 
            // countservicesDataGridViewTextBoxColumn
            // 
            this.countservicesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countservicesDataGridViewTextBoxColumn.DataPropertyName = "count_services";
            this.countservicesDataGridViewTextBoxColumn.HeaderText = "Количество услуг";
            this.countservicesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.countservicesDataGridViewTextBoxColumn.Name = "countservicesDataGridViewTextBoxColumn";
            this.countservicesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // price_services_column
            // 
            this.price_services_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.price_services_column.DataPropertyName = "price_services";
            this.price_services_column.HeaderText = "Стоимость услуг";
            this.price_services_column.MinimumWidth = 6;
            this.price_services_column.Name = "price_services_column";
            this.price_services_column.ReadOnly = true;
            // 
            // registrationviewBindingSource
            // 
            this.registrationviewBindingSource.DataMember = "registrationview";
            this.registrationviewBindingSource.DataSource = this.barberDBDataSet;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddReg,
            this.toolStripButtonDeleteReg});
            this.toolStrip1.Location = new System.Drawing.Point(4, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1203, 47);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddReg
            // 
            this.toolStripButtonAddReg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddReg.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddReg.Image")));
            this.toolStripButtonAddReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddReg.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.toolStripButtonAddReg.Name = "toolStripButtonAddReg";
            this.toolStripButtonAddReg.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonAddReg.Text = "Создать запись к парикмахеру";
            this.toolStripButtonAddReg.Click += new System.EventHandler(this.toolStripButtonAddReg_Click);
            // 
            // toolStripButtonDeleteReg
            // 
            this.toolStripButtonDeleteReg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteReg.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteReg.Image")));
            this.toolStripButtonDeleteReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteReg.Name = "toolStripButtonDeleteReg";
            this.toolStripButtonDeleteReg.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonDeleteReg.Text = "Удалить запись к парикмахеру";
            this.toolStripButtonDeleteReg.ToolTipText = "Удалить запись к парикмахеру";
            this.toolStripButtonDeleteReg.Click += new System.EventHandler(this.toolStripButtonDeleteReg_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridViewServices);
            this.tabPage4.Controls.Add(this.toolStripAddService);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1211, 524);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Услуги";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewServices
            // 
            this.dataGridViewServices.AllowUserToAddRows = false;
            this.dataGridViewServices.AllowUserToDeleteRows = false;
            this.dataGridViewServices.AutoGenerateColumns = false;
            this.dataGridViewServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameserviceDataGridViewTextBoxColumn,
            this.priceserviceDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.idserviceDataGridViewTextBoxColumn});
            this.dataGridViewServices.DataSource = this.serviceBindingSource;
            this.dataGridViewServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewServices.Location = new System.Drawing.Point(0, 34);
            this.dataGridViewServices.MultiSelect = false;
            this.dataGridViewServices.Name = "dataGridViewServices";
            this.dataGridViewServices.ReadOnly = true;
            this.dataGridViewServices.RowHeadersVisible = false;
            this.dataGridViewServices.RowHeadersWidth = 51;
            this.dataGridViewServices.RowTemplate.Height = 24;
            this.dataGridViewServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewServices.Size = new System.Drawing.Size(1211, 490);
            this.dataGridViewServices.TabIndex = 3;
            // 
            // nameserviceDataGridViewTextBoxColumn
            // 
            this.nameserviceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameserviceDataGridViewTextBoxColumn.DataPropertyName = "name_service";
            this.nameserviceDataGridViewTextBoxColumn.HeaderText = "Название";
            this.nameserviceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameserviceDataGridViewTextBoxColumn.Name = "nameserviceDataGridViewTextBoxColumn";
            this.nameserviceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceserviceDataGridViewTextBoxColumn
            // 
            this.priceserviceDataGridViewTextBoxColumn.DataPropertyName = "price_service";
            this.priceserviceDataGridViewTextBoxColumn.HeaderText = "Стоимость";
            this.priceserviceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceserviceDataGridViewTextBoxColumn.Name = "priceserviceDataGridViewTextBoxColumn";
            this.priceserviceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceserviceDataGridViewTextBoxColumn.Width = 250;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Продолжительность";
            this.durationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.ReadOnly = true;
            this.durationDataGridViewTextBoxColumn.Width = 250;
            // 
            // idserviceDataGridViewTextBoxColumn
            // 
            this.idserviceDataGridViewTextBoxColumn.DataPropertyName = "id_service";
            this.idserviceDataGridViewTextBoxColumn.HeaderText = "id_service";
            this.idserviceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idserviceDataGridViewTextBoxColumn.Name = "idserviceDataGridViewTextBoxColumn";
            this.idserviceDataGridViewTextBoxColumn.ReadOnly = true;
            this.idserviceDataGridViewTextBoxColumn.Visible = false;
            this.idserviceDataGridViewTextBoxColumn.Width = 106;
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataMember = "service";
            this.serviceBindingSource.DataSource = this.barberDBDataSet;
            // 
            // toolStripAddService
            // 
            this.toolStripAddService.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripAddService.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripAddService.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripAddService.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStripAddService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.toolStripTextBoxServiceName});
            this.toolStripAddService.Location = new System.Drawing.Point(0, 0);
            this.toolStripAddService.Name = "toolStripAddService";
            this.toolStripAddService.Size = new System.Drawing.Size(1211, 34);
            this.toolStripAddService.TabIndex = 2;
            this.toolStripAddService.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(199, 31);
            this.toolStripLabel2.Text = "Поиск по названию:";
            // 
            // toolStripTextBoxServiceName
            // 
            this.toolStripTextBoxServiceName.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxServiceName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripTextBoxServiceName.Name = "toolStripTextBoxServiceName";
            this.toolStripTextBoxServiceName.Size = new System.Drawing.Size(500, 34);
            this.toolStripTextBoxServiceName.TextChanged += new System.EventHandler(this.toolStripTextBoxServiceName_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обновитьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1219, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonUpdate,
            this.ExitSystemButton});
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(101, 32);
            this.обновитьToolStripMenuItem.Text = "Система";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(190, 32);
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // ExitSystemButton
            // 
            this.ExitSystemButton.Name = "ExitSystemButton";
            this.ExitSystemButton.Size = new System.Drawing.Size(190, 32);
            this.ExitSystemButton.Text = "Выйти";
            this.ExitSystemButton.Click += new System.EventHandler(this.ExitSystemButton_Click);
            // 
            // clientTableAdapter
            // 
            this.clientTableAdapter.ClearBeforeFill = true;
            // 
            // hairdresserTableAdapter
            // 
            this.hairdresserTableAdapter.ClearBeforeFill = true;
            // 
            // administratorTableAdapter
            // 
            this.administratorTableAdapter.ClearBeforeFill = true;
            // 
            // registrationviewTableAdapter
            // 
            this.registrationviewTableAdapter.ClearBeforeFill = true;
            // 
            // serviceTableAdapter
            // 
            this.serviceTableAdapter.ClearBeforeFill = true;
            // 
            // registrationTableAdapter
            // 
            this.registrationTableAdapter.ClearBeforeFill = true;
            // 
            // statusTableAdapter
            // 
            this.statusTableAdapter.ClearBeforeFill = true;
            // 
            // toolStripButtonAddUser
            // 
            this.toolStripButtonAddUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButtonAddUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddUser.Image")));
            this.toolStripButtonAddUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddUser.Name = "toolStripButtonAddUser";
            this.toolStripButtonAddUser.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonAddUser.Text = "toolStripButton1";
            this.toolStripButtonAddUser.ToolTipText = "Зарегистрировать пользователя";
            // 
            // toolStripButtonDeleteUser
            // 
            this.toolStripButtonDeleteUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDeleteUser.Image")));
            this.toolStripButtonDeleteUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteUser.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolStripButtonDeleteUser.Name = "toolStripButtonDeleteUser";
            this.toolStripButtonDeleteUser.Size = new System.Drawing.Size(44, 44);
            this.toolStripButtonDeleteUser.Text = "toolStripButton3";
            this.toolStripButtonDeleteUser.ToolTipText = "Удалить пользователя";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(152, 44);
            this.toolStripLabel1.Text = "Поиск по ФИО:";
            // 
            // toolStripTextBoxFIO
            // 
            this.toolStripTextBoxFIO.BackColor = System.Drawing.Color.White;
            this.toolStripTextBoxFIO.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripTextBoxFIO.Name = "toolStripTextBoxFIO";
            this.toolStripTextBoxFIO.Size = new System.Drawing.Size(470, 47);
            // 
            // MainFormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 598);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainFormClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Парикмахерская";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barberDBDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationviewBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            this.toolStripAddService.ResumeLayout(false);
            this.toolStripAddService.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddReg;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteReg;
        private System.Windows.Forms.DataGridView dataGridViewReg;
        private BarberDBDataSetTableAdapters.clientTableAdapter clientTableAdapter;
        private BarberDBDataSetTableAdapters.hairdresserTableAdapter hairdresserTableAdapter;
        private BarberDBDataSetTableAdapters.administratorTableAdapter administratorTableAdapter;
        private BarberDBDataSet barberDBDataSet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonUpdate;
        private System.Windows.Forms.BindingSource registrationviewBindingSource;
        private BarberDBDataSetTableAdapters.registrationviewTableAdapter registrationviewTableAdapter;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dataGridViewServices;
        private System.Windows.Forms.ToolStrip toolStripAddService;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private BarberDBDataSetTableAdapters.serviceTableAdapter serviceTableAdapter;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxServiceName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label2;
        private BarberDBDataSetTableAdapters.registrationTableAdapter registrationTableAdapter;
        private System.Windows.Forms.BindingSource statusBindingSource;
        private BarberDBDataSetTableAdapters.statusTableAdapter statusTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameserviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceserviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idserviceDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddUser;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteUser;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn idregistrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateregistrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enddataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idadministratorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idclientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idhairdresserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusregistrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn countservicesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_services_column;
        private System.Windows.Forms.ToolStripMenuItem ExitSystemButton;
    }
}

