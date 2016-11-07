using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentikus_DAL
{
  public  class DADesavanjaFilter
    {
        public static void GetDesavanjaByDatum(DS_Studentikus.DesavanjasDataTable dtDesavanja, DateTime datum)
        {
            dtDesavanja.Clear();
            SqlConnection cn = Connection.GetConnection();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("si001_student.usp_DesavanjaByDatum", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Datum", SqlDbType.DateTime).Value = datum;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dtDesavanja);
            }
            finally { }

        }
    }
}
