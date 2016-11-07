using Microsoft.Reporting.WinForms;
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

namespace Studentikus_UI.Reports
{
    public partial class Frm_Kljuc_rpt : Form
    {
        Studentikus_DAL.DS_Kljuc kljuccDS = new Studentikus_DAL.DS_Kljuc();


        public Frm_Kljuc_rpt(Studentikus_DAL.DS_Kljuc.KljucsDataTable dtKljuc)
        {

            InitializeComponent();
            DS_KljucBindingSource.DataSource = dtKljuc;
        }


        private void Frm_Kljuc_rpt_Load(object sender, EventArgs e)
        {
            
            ReportDataSource rds = new ReportDataSource("Kljuc", DS_KljucBindingSource);

            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            
        }
    }
}
