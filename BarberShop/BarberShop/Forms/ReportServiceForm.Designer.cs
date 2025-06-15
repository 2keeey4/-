namespace BarberShop.Forms
{
    partial class ReportServiceForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.servicereportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barberDBDataSet = new BarberShop.BarberDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.servicereportTableAdapter = new BarberShop.BarberDBDataSetTableAdapters.servicereportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.servicereportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barberDBDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // servicereportBindingSource
            // 
            this.servicereportBindingSource.DataMember = "servicereport";
            this.servicereportBindingSource.DataSource = this.barberDBDataSet;
            // 
            // barberDBDataSet
            // 
            this.barberDBDataSet.DataSetName = "BarberDBDataSet";
            this.barberDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.servicereportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BarberShop.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 67);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(916, 512);
            this.reportViewer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerEnd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePickerStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 49);
            this.panel1.TabIndex = 3;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(355, 10);
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
            this.label2.Location = new System.Drawing.Point(318, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "до";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(112, 10);
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
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата: от";
            // 
            // servicereportTableAdapter
            // 
            this.servicereportTableAdapter.ClearBeforeFill = true;
            // 
            // ReportServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 591);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportServiceForm";
            this.Text = "Статистика проданных услуг";
            this.Load += new System.EventHandler(this.ReportServiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servicereportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barberDBDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label1;
        private BarberDBDataSet barberDBDataSet;
        private System.Windows.Forms.BindingSource servicereportBindingSource;
        private BarberDBDataSetTableAdapters.servicereportTableAdapter servicereportTableAdapter;
    }
}