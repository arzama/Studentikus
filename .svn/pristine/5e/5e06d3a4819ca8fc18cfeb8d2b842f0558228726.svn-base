using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Studentikus_DAL
{
   public class DARezervacijeByRecepcioner
    {

       public static void GetRezervacijeByRecepcioner(DSRezervacije.RezervacijaSobesDataTable dtRezervacije, string ime, string prezime, int sobaId)
       {
           dtRezervacije.Clear();
           SqlConnection cn = Connection.GetConnection();
           if (cn.State == ConnectionState.Closed)
               cn.Open();
           try
           {
               SqlCommand cmd = new SqlCommand("si001_student.usp_RezervacijeByRecepcioner", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               if (ime != "")
               {
                   cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = ime;
               }

               if (prezime != "")
               {
                   cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = prezime;
               }


               if (sobaId != 0)
               {
                   cmd.Parameters.Add("@SobaId", SqlDbType.Int).Value = sobaId;
               }
               SqlDataAdapter adapter = new SqlDataAdapter(cmd);

               adapter.Fill(dtRezervacije);
           }
           finally { }

       }
    }
}
