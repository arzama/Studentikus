using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Studentikus_DAL
{
    public class DAKorisniciByRezervacijaId
    {
        public static void GetKorisniciByRezervacijaId(DSKorisnici.KorisniksDataTable dtKorisnici, int rezervacijaId)
        {
            dtKorisnici.Clear();
            SqlConnection cn = Connection.GetConnection();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("si001_student.usp_SelectKorisniciByRezervacijaId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = rezervacijaId;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtKorisnici);
            }
            finally { cn.Close(); }
        }
    }
}
