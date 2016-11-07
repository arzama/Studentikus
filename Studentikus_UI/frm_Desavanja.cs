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

namespace Studentikus_UI
{
    public partial class frm_Desavanja : Form
    {
        DS_Studentikus.DesavanjasDataTable dtDesavanja = new DS_Studentikus.DesavanjasDataTable();
        public frm_Desavanja()
        {
            InitializeComponent();
        }

        private void frm_Desavanja_Load(object sender, EventArgs e)
        {
           
       
            PickerDesavanja_ValueChanged(null, null);

        }


        private void PickerDesavanja_ValueChanged(object sender, EventArgs e)
        {
               DADesavanjaFilter.GetDesavanjaByDatum(dtDesavanja, PickerDesavanja.Value);
               dgDesavanja.AutoGenerateColumns = false;
               dgDesavanja.DataSource = dtDesavanja;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Reports.frm_Desavanja_rpt frm = new Reports.frm_Desavanja_rpt(dtDesavanja);
            frm.Show();
        }

    }
}
