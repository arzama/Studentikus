using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentikus_DAL
{
    public class DARezervacije
    {
        public static void GetAllSobe(DSRezervacije.SobasDataTable dtSobe)
        {
            dtSobe.Clear();
            SqlConnection cn = Connection.GetConnection();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("si001_student.usp_SelectAllSobe", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSobe);
            }
            finally { cn.Close(); }
        }
    }
}
