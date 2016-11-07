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
    public partial class frm_TrenutniGosti : Form
    {
        public frm_TrenutniGosti()
        {
            InitializeComponent();
        }

        private void frm_TrenutniGosti_Load(object sender, EventArgs e)
        {
            DS_Studentikus.KorisniksDataTable dtKorisnici = new DS_Studentikus.KorisniksDataTable();
            DAGetTrenutniKorisnici.GetTrenutniKorisnici(dtKorisnici);
            

            dgKorisnici.AutoGenerateColumns = false;
            dgKorisnici.DataSource = dtKorisnici;
        }
    }
}
