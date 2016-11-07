using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Studentikus_DAL
{
    public class DAGetTrenutniKorisnici
    {

        public static void GetTrenutniKorisnici(DS_Studentikus.KorisniksDataTable dtKorisnici)
        {

            SqlConnection cn = Connection.GetConnection();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("si001_student.usp_TrenutniGosti", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtKorisnici);
            }
            finally { }

        }
    }
}
