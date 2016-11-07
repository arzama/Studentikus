using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentikus_DAL
{
    public class DAZaposlenici
    {
        public static void GetZaposlenici(DSZaposlenici.ZaposleniksDataTable dtZaposlenici)
        {
            dtZaposlenici.Clear();
            SqlConnection cn = Connection.GetConnection();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("si001_student2.usp_ZaposleniciStaz", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
               
                adapter.Fill(dtZaposlenici);
            }
            finally { }

        }
    }
}
