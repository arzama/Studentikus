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
    public partial class frm_ZaposleniciUloge : Form
    {
        public frm_ZaposleniciUloge()
        {
            InitializeComponent();
        }

        private void frm_ZaposleniciUloge_Load(object sender, EventArgs e)
        {
            DSZaposlenikUloge dsZaposlenik = new DSZaposlenikUloge();
            Studentikus_DAL.DSZaposlenikUlogeTableAdapters.viewZaposlenikUlogaTableAdapter adapter = new Studentikus_DAL.DSZaposlenikUlogeTableAdapters.viewZaposlenikUlogaTableAdapter();
            adapter.Fill(dsZaposlenik.viewZaposlenikUloga);
            bindingSource1.DataSource = dsZaposlenik.viewZaposlenikUloga;
            ReportDataSource rds = new ReportDataSource("DataSet1", bindingSource1);

            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
