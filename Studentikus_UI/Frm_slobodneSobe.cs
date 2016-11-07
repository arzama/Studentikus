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
    public partial class Frm_slobodneSobe : Form
    {
        public Frm_slobodneSobe()
        {
            InitializeComponent();
        }

        private void Frm_slobodneSobe_Load(object sender, EventArgs e)
        {
            DS_Studentikus.SobasDataTable dtSoba = new DS_Studentikus.SobasDataTable();
            DAStudentikus.getSlobodneSobe(dtSoba);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtSoba;
            
        }

      

        

      
    }
}
