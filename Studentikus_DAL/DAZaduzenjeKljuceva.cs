using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentikus_DAL
{
   public class DAZaduzenjeKljuceva
    {
       public static void GetZaduzenjeKljuceva(DSZaduzenjeKljuca.ZaduzenjeKljucasDataTable dtZaduzenje)
       {
           SqlConnection cm = Connection.GetConnection();
           if (cm.State == ConnectionState.Closed)
               cm.Open();

           try
           {
               SqlCommand cmd = new SqlCommand("procZaduzenjeKljuca", cm);
               cmd.CommandType =CommandType.StoredProcedure;
               SqlDataAdapter adapter=new SqlDataAdapter(cmd);
               adapter.Fill(dtZaduzenje);

           }

           finally
           {

           }
       }

    }
}
