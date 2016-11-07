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
    public partial class frm_Desavanja_rpt : Form
    {
        Studentikus_DAL.DS_Studentikus dsDesavanja = new Studentikus_DAL.DS_Studentikus();
        public frm_Desavanja_rpt(Studentikus_DAL.DS_Studentikus.DesavanjasDataTable dtDesavanja)
        {
            InitializeComponent();
            DS_StudentikusBindingSource.DataSource = dtDesavanja;
         

        }
        private void frm_Desavanja_rpt_Load(object sender, EventArgs e)
        {
            ReportDataSource rds = new ReportDataSource("Dešavanja",DS_StudentikusBindingSource);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
