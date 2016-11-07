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
    public partial class frm_PrimljeniStudenti : Form
    {
        public frm_PrimljeniStudenti()
        {
            InitializeComponent();
        }

        private void frm_PrimljeniStudenti_Load(object sender, EventArgs e)
        {
            DSPrimljeniStudenti dsStudenti = new DSPrimljeniStudenti();
            DSPrimljeniStudentiTableAdapters.PrimljeniStudentiTableAdapter adapter = new DSPrimljeniStudentiTableAdapters.PrimljeniStudentiTableAdapter();

            adapter.Fill(dsStudenti.PrimljeniStudenti);
            bindingSource1.DataSource = dsStudenti.PrimljeniStudenti;
            ReportDataSource rds = new ReportDataSource("DSPrimljeniStudenti", bindingSource1);

            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
