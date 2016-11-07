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
namespace Studentikus_UI
{
    public partial class Frm_Kljuc : Form
    {
        public Frm_Kljuc()
        {
            InitializeComponent();
        }
        DS_Kljuc.KljucsDataTable dtKljucevi = new DS_Kljuc.KljucsDataTable();
        private int a = 5;
       
        DS_Studentikus.KorisniksDataTable dtKorisnici = new DS_Studentikus.KorisniksDataTable();
        private void Frm_Kljuc_Load(object sender, EventArgs e)
        {
            dgKljucevi.AutoGenerateColumns = false;
            button1_Click(null,null);
            dgKljucevi.DataSource = dtKljucevi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAGetKljucevi.GetKljucevi(dtKljucevi, Datumtxt.Text, Brojtxt.Text);
            dgKljucevi.DataSource = dtKljucevi;
        }

        private void Datumtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reports.Frm_Kljuc_rpt frm = new Reports.Frm_Kljuc_rpt(dtKljucevi);
            frm.Show();
        }
    }
}
