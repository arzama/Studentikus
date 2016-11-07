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
    public partial class frm_SobeInventari_rpt : Form
    {
        public frm_SobeInventari_rpt()
        {
            InitializeComponent();
        }

        private void frm_SobeInventari_rpt_Load(object sender, EventArgs e)
        {
            Studentikus_DAL.Neupotrebljivi_Inventari dsinventar = new Studentikus_DAL.Neupotrebljivi_Inventari();
            Studentikus_DAL.Neupotrebljivi_InventariTableAdapters.view_InventarZaposlenik2TableAdapter adapter = new Studentikus_DAL.Neupotrebljivi_InventariTableAdapters.view_InventarZaposlenik2TableAdapter();

            adapter.Fill(dsinventar.view_InventarZaposlenik2);
            bindingSource1.DataSource = dsinventar.view_InventarZaposlenik2;
            ReportDataSource rds = new ReportDataSource("Neupotrebljivi_Inventari", bindingSource1);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
