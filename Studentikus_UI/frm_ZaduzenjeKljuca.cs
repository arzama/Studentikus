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
    public partial class frm_ZaduzenjeKljuca : Form
    {
        public frm_ZaduzenjeKljuca()
        {
            InitializeComponent();
        }


        private void frm_ZaduzenjeKljuca_Load(object sender, EventArgs e)
        {
            DSZaduzenjeKljuca.ZaduzenjeKljucasDataTable dtKljuc = new DSZaduzenjeKljuca.ZaduzenjeKljucasDataTable();
            DAZaduzenjeKljuceva.GetZaduzenjeKljuceva(dtKljuc);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtKljuc;
        }
    }
}
