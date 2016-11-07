using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Studentikus_DAL
{
    public class DAGetKljucevi
    {
        public static void GetKljucevi(DS_Kljuc.KljucsDataTable dtKljucevi, string datum, string broj)
        {
            dtKljucevi.Clear();
            SqlConnection cn = Connection.GetConnection();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("si001_student.usp_Kljuc", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (datum != "")
                    cmd.Parameters.Add("@Datum", SqlDbType.DateTime).Value = Convert.ToDateTime(datum);
                if (broj != "")
                    cmd.Parameters.Add("@BrojKljuca", SqlDbType.Int).Value = Convert.ToInt32(broj);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtKljucevi);
            }
            finally { cn.Close(); }
        }
    }
}
