using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studentikus_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            frm_Login frm = new frm_Login();
           
            Application.Run(frm);
            if(frm.DialogResult==DialogResult.OK)
                Application.Run(new frm_Main());
           
        }
    }
}
