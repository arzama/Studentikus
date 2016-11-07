using Microsoft.Reporting.WinForms;
using Studentikus_DAL;
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
    public partial class frm_BrojDesavanja_rpt : Form
    {
        public frm_BrojDesavanja_rpt()
        {
            InitializeComponent();
        }

        private void frm_BrojDesavanja_rpt_Load(object sender, EventArgs e)
        {
            
           Studentikus_DAL.BrojDesavanja1 dsDesavanja = new BrojDesavanja1();
           Studentikus_DAL.BrojDesavanja1TableAdapters.usp_BrojDesavanja_PoMjesecuiGodiniTableAdapter adapter = new Studentikus_DAL.BrojDesavanja1TableAdapters.usp_BrojDesavanja_PoMjesecuiGodiniTableAdapter();


            adapter.Fill(dsDesavanja.usp_BrojDesavanja_PoMjesecuiGodini);


            //DSRezervacije.BrojDesavanjaDataTable ds = new DSRezervacije.BrojDesavanjaDataTable();
            //DAStudentikus.SelectBrojDesavanja(ds);

            bindingSource1.DataSource = dsDesavanja.usp_BrojDesavanja_PoMjesecuiGodini;
            ReportDataSource rds = new ReportDataSource("BrojDesavanja1", bindingSource1);
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
