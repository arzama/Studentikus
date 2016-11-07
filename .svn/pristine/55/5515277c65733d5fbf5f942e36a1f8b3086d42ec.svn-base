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
    public partial class frm_RezervacijeByRecepcioneri : Form
    {

      DSRezervacije dsRezervacije = new DSRezervacije();
        public frm_RezervacijeByRecepcioneri()
        {
            InitializeComponent();
        }

   
        private void frm_RezervacijeByRecepcioneri_Load(object sender, EventArgs e)
        {
           
            DARezervacije.GetAllSobe(dsRezervacije.Sobas);
            DSRezervacije.SobasRow soba = dsRezervacije.Sobas.NewSobasRow();
          
            soba.Id = 0;
            soba.BrojSobe =0;

            dsRezervacije.Sobas.Rows.InsertAt(soba, 0);

            cbxBrojeviSoba.DataSource = dsRezervacije.Sobas;
            cbxBrojeviSoba.DisplayMember = "BrojSobe";
            cbxBrojeviSoba.ValueMember = "Id";
            btn_Search_Click(null,null);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            DARezervacijeByRecepcioner.GetRezervacijeByRecepcioner(dsRezervacije.RezervacijaSobes, txtIme.Text, txtPrezime.Text, Convert.ToInt32(cbxBrojeviSoba.SelectedValue));
            dgRezervacije.AutoGenerateColumns = false;
            dgRezervacije.DataSource = dsRezervacije.RezervacijaSobes;

            lblNumber.Text = dsRezervacije.RezervacijaSobes.Count.ToString();
        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            
            Reports.frm_RezervacijePoPretrazi_rpt frm = new Reports.frm_RezervacijePoPretrazi_rpt(dsRezervacije.RezervacijaSobes);
            frm.Show();
        }

        
      


     
    }
}
