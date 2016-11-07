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
    public partial class Frm_Rodjendan_rpt : Form
    {
        public Frm_Rodjendan_rpt()
        {
            InitializeComponent();
        }

        private void Frm_Rodjendan_rpt_Load(object sender, EventArgs e)
        {
            Studentikus_DAL.DS_Rodjendan dsRodjendan = new Studentikus_DAL.DS_Rodjendan();
            Studentikus_DAL.DS_RodjendanTableAdapters.view_Rodjendan1TableAdapter adapter = new Studentikus_DAL.DS_RodjendanTableAdapters.view_Rodjendan1TableAdapter();

            adapter.Fill(dsRodjendan.view_Rodjendan1);

            bindingSource1.DataSource = dsRodjendan.view_Rodjendan1;

            ReportDataSource rds = new ReportDataSource("Rodjendan", bindingSource1);

            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
