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

namespace Studentikus_UI.Reports
{
    public partial class frm_ObrociDanas : Form
    {
        public frm_ObrociDanas()
        {
            InitializeComponent();
        }

        private void frm_ObrociDanas_Load(object sender, EventArgs e)
        {
            Studentikus_DAL.ObrociDanas1 dsobroci = new Studentikus_DAL.ObrociDanas1();
            Studentikus_DAL.ObrociDanas1TableAdapters.usp_ObrociDanasTableAdapter adapter = new Studentikus_DAL.ObrociDanas1TableAdapters.usp_ObrociDanasTableAdapter();
          
            ReportParameter datum = new ReportParameter();
            


            adapter.Fill(dsobroci.usp_ObrociDanas);
            bindingSource1.DataSource = dsobroci.usp_ObrociDanas;
            ReportDataSource rds = new ReportDataSource("ObrociDanas1", bindingSource1);
            reportViewer1.LocalReport.DataSources.Add(rds);
            DateTime d= DateTime.Now;
            reportViewer1.LocalReport.SetParameters(new ReportParameter("DatumTrenutni",d.ToShortDateString()));
            this.reportViewer1.RefreshReport();
        }
    }
}
