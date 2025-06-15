using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarberShop.Forms
{
    public partial class ReportServiceForm : Form
    {
        public ReportServiceForm()
        {
            InitializeComponent();
            PageSettings setting = new PageSettings();
            setting.Margins = new Margins(10, 10, 10, 10);
            //setting.PaperSize = new PaperSize() { RawKind = (int)PaperKind.A4 };
            setting.PaperSize = new PaperSize("A4", 827, 1169);
            reportViewer1.SetPageSettings(setting);
            dateTimePickerStart.Value = DateTime.Now.AddYears(-1);
            dateTimePickerEnd.Value = DateTime.Now.AddYears(1);
        }
        void UpdateReport()
        {
            ReportParameter date_start = new ReportParameter("ReportParameterStartDate", dateTimePickerStart.Value.ToShortDateString());
            ReportParameter date_end = new ReportParameter("ReportParameterEndDate", dateTimePickerEnd.Value.ToShortDateString());
            this.reportViewer1.LocalReport.SetParameters(date_start);
            this.reportViewer1.LocalReport.SetParameters(date_end);
            servicereportBindingSource.DataSource = servicereportTableAdapter.GetDataBy(dateTimePickerStart.Value.Date, dateTimePickerEnd.Value.Date);
            this.servicereportTableAdapter.Fill(this.barberDBDataSet.servicereport);
            this.reportViewer1.RefreshReport();
        }

        private void ReportServiceForm_Load(object sender, EventArgs e)
        {
            UpdateReport();
        }
        private void PeriodChanged(object sender, EventArgs e)
        {
            try
            {
                dateTimePickerEnd.MinDate = dateTimePickerStart.Value;
                UpdateReport();
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
                    UpdateReport();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно подключиться к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
