using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Studentikus_DAL;
using Microsoft.Reporting.WinForms;
namespace Studentikus_UI.Reports
{
    public partial class frm_RezervacijePoPretrazi_rpt : Form
    {
        DSRezervacije dsRezervacije = new DSRezervacije();
        public frm_RezervacijePoPretrazi_rpt(DSRezervacije.RezervacijaSobesDataTable dtRezervacije)
        {
            InitializeComponent();
            DSRezervacijeBindingSource.DataSource = dtRezervacije;
        }

        private void frm_RezervacijePoPretrazi_rpt_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1",DSRezervacijeBindingSource);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
