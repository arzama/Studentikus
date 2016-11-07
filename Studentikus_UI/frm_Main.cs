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
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }


        private void gostiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void prikazSlobodnihSobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Sobe f = new frm_Sobe();
            f.Show();
        }

        private void realizovaneRezervacijeUTekućemMjesecuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frm_RezervacijeTKM_Rpt r = new Reports.frm_RezervacijeTKM_Rpt();
            r.Show();
        }

        private void pretragaRezervacijaPoRecepcioneruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_RezervacijeByRecepcioneri r = new frm_RezervacijeByRecepcioneri();
            r.Show();
        }

        private void prikazTrenutnihGostijuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TrenutniGosti t = new frm_TrenutniGosti();
            t.Show();
        }

        private void prikazGostijuKojiSuBoraviliVišeOd5PutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frm_GostiiPet_rpt g = new Reports.frm_GostiiPet_rpt();
            g.Show();
        }

        private void prikazStažaZaposlenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Zaposlenici z = new frm_Zaposlenici();
            z.Show();
        }

        private void prikazSvihKorisnikaSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ListofKorisnici l = new frm_ListofKorisnici();
            l.Show();
        }

    

        private void izvještajOInventaruSobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frm_SobeInventari_rpt frm = new Reports.frm_SobeInventari_rpt();
            frm.Show();
        }

        private void pretragaDešavanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Desavanja d = new frm_Desavanja();
            d.Show();
        }

        private void brojDešavanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frm_BrojDesavanja_rpt frm = new Reports.frm_BrojDesavanja_rpt();
            frm.Show();
        }

        private void izvještajOIskorištenimObrocimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frm_ObrociDanas frm = new Reports.frm_ObrociDanas();
            frm.Show();
        }

    

       
     

        private void korisniciKojiSuPreuzimaliKljučNaOdređenDatumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Kljuc k = new Frm_Kljuc();
            k.Show();
        }

        

        

       

        private void rođendanNaDanašnjiDanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.Frm_Rodjendan_rpt r = new Reports.Frm_Rodjendan_rpt();
            r.Show();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void prikazZaposlenikaPoUlogamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frm_ZaposleniciUloge a = new Reports.frm_ZaposleniciUloge();
            a.Show();
        }

        private void zaduženjeKljučevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ZaduzenjeKljuca hu = new frm_ZaduzenjeKljuca();
            hu.Show();
        }

        private void pretragaKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_pretragaKorisnika uz = new frm_pretragaKorisnika();
            uz.Show();
        }

        private void izvještajOStudentimaKojiTrenutnoBoraveUHoteluToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.frm_PrimljeniStudenti ddd = new Reports.frm_PrimljeniStudenti();
            ddd.Show();
        }

        
     
    
      
    }
}
