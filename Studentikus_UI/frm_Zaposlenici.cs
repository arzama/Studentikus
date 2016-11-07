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
    public partial class frm_Zaposlenici : Form
    {
        public frm_Zaposlenici()
        {
            InitializeComponent();
        }

        private void frm_Zaposlenici_Load(object sender, EventArgs e)
        {
            DSZaposlenici.ZaposleniksDataTable dtZaposlenici = new DSZaposlenici.ZaposleniksDataTable();
            DAZaposlenici.GetZaposlenici(dtZaposlenici);
 
            dgZaposlenici.AutoGenerateColumns = false;
            dgZaposlenici.DataSource = dtZaposlenici;
        }


      
    }
}
