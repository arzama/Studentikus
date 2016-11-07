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
    public partial class frm_Inventar_Report : Form
    {
        public frm_Inventar_Report()
        {
            InitializeComponent();
        }

        private void frm_Inventar_Report_Load(object sender, EventArgs e)
        {
            // tabla se zove DSInventarZaposlenici
            DSSobeInventar dsinventar = new DSSobeInventar();
           DSSobeInventarTableAdapters.SobeInventarTableAdapter adapter = new DSSobeInventarTableAdapters.SobeInventarTableAdapter();
           adapter.Fill(dsinventar.SobeInventar);
            
            bindingSource1.DataSource = dsinventar.SobeInventar;
            ReportDataSource rds = new ReportDataSource("DSInventarZaposlenici", bindingSource1);
            reportViewer1.LocalReport.DataSources.Add(rds);
            
            this.reportViewer1.RefreshReport();
        }
    }
}
