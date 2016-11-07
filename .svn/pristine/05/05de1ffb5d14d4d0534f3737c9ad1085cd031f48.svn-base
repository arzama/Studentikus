using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentikus_DAL
{
   public class Login
    {
       public static bool SelectLogin(DSKorisnici.KorisniksDataTable dtKorisnici, string korisnickoIme, string lozinka)
       {

           SqlConnection cn = Connection.GetConnection();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           try
           {
               SqlCommand cmd = new SqlCommand("si001_student.usp_Login", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@KorisnickoIme", korisnickoIme);
               cmd.Parameters.AddWithValue("@Lozinka", lozinka);
               SqlDataReader r = cmd.ExecuteReader();
               if (r.HasRows)
               {
                   return true;
               }
               else return false;

           }




           finally { cn.Close(); }

       }
    }
}
