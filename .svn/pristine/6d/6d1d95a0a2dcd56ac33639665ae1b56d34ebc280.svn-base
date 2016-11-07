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
    public partial class frm_GostiiPet_rpt : Form
    {
        public frm_GostiiPet_rpt()
        {
            InitializeComponent();
        }

        private void frm_GostiiPet_rpt_Load(object sender, EventArgs e)
        {
            Studentikus_DAL.GostiiPet_DS dsGosti = new Studentikus_DAL.GostiiPet_DS();

            Studentikus_DAL.GostiiPet_DSTableAdapters.view_KorisniciPet1TableAdapter adapter = 
                new Studentikus_DAL.GostiiPet_DSTableAdapters.view_KorisniciPet1TableAdapter();

            adapter.Fill(dsGosti.view_KorisniciPet1);

            bindingSource1.DataSource = dsGosti.view_KorisniciPet1;

            ReportDataSource rds = new ReportDataSource("GostiPet", bindingSource1);

            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }
    }
}
