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
using Studentikus_UI;
namespace Studentikus_UI
{
    public partial class frm_pretragaKorisnika : Form
    {
        DSKorisnici.KorisniksDataTable dtKorisnik = new DSKorisnici.KorisniksDataTable();
        public frm_pretragaKorisnika()
        {
            InitializeComponent();
        }

        private void frm_pretragaKorisnika_Load(object sender, EventArgs e)
        {

            DSKorisnici.KorisniksDataTable dtKorisnik = new DSKorisnici.KorisniksDataTable();
            DAPretragaKorisnika.GetKorisnici(dtKorisnik);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtKorisnik;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAPretragaKorisnika.PretragaKorisnika(dtKorisnik, txtFirstName.Text, txtLastName.Text);
            dataGridView1.DataSource = dtKorisnik;
        }

       
    }
}
