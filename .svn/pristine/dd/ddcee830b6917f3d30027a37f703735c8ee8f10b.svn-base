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
    public partial class frm_RezervacijeTKM_Rpt : Form
    {
        public frm_RezervacijeTKM_Rpt()
        {
            InitializeComponent();
        }

        private void frm_RezervacijeTKM_Rpt_Load(object sender, EventArgs e)
        {
            Studentikus_DAL.Rezervacija_DS dsRezervacije = new Studentikus_DAL.Rezervacija_DS();
            Studentikus_DAL.Rezervacija_DSTableAdapters.view_Rezervacije1TableAdapter adapter =
                new Studentikus_DAL.Rezervacija_DSTableAdapters.view_Rezervacije1TableAdapter();

            adapter.Fill(dsRezervacije.view_Rezervacije1);

            bindingSource1.DataSource = dsRezervacije.view_Rezervacije1;

            ReportDataSource rds = new ReportDataSource("RezervacijeTKM",bindingSource1);

            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();

        }
    }
}
