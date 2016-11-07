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
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DSKorisnici.KorisniksDataTable dsKorisnici = new DSKorisnici.KorisniksDataTable();

            if (Login.SelectLogin(dsKorisnici,txtKorisnickoIme.Text,txtLozinka.Text)==true)
            {
                this.DialogResult = DialogResult.OK;
              this.Close();

            }
            else lblInfo.Visible = true;
        }

   

      

      
    }
}
