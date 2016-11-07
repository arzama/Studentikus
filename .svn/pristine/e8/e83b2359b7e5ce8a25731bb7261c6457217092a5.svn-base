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
    public partial class frm_ListofKorisnici : Form
    {
        public frm_ListofKorisnici()
        {
            InitializeComponent();
        }

        private void frm_ListofKorisnici_Load(object sender, EventArgs e)
        {

            DS_Studentikus.KorisniksDataTable dtKorisnici = new DS_Studentikus.KorisniksDataTable();
            DAGetAllKorisnici.GetAllKorisnici(dtKorisnici);

            dgKorisnicii.AutoGenerateColumns = false;
            dgKorisnicii.DataSource = dtKorisnici;


        }
    }
}
