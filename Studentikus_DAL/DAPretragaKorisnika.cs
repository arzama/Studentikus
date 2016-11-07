using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentikus_DAL
{
    public class DAPretragaKorisnika
    {
        public static void GetKorisnici(DSKorisnici.KorisniksDataTable dtKorisniks)
        {

            dtKorisniks.Clear();
            SqlConnection cm = Connection.GetConnection();
            if (cm.State == ConnectionState.Closed)
                cm.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("proc_Korisnici", cm);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtKorisniks);
            }
            finally
            {

            }

        }


        public static void PretragaKorisnika(DSKorisnici.KorisniksDataTable dtKorisniks, string firstname, string lastname)
        {

            dtKorisniks.Clear();
            SqlConnection cm = Connection.GetConnection();
            if (cm.State == ConnectionState.Closed)
                cm.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("pretragaKorisnika2", cm);
                cmd.CommandType = CommandType.StoredProcedure;
                if (firstname != "")
                    cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = firstname;
                if (lastname != "")
                    cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = lastname;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtKorisniks);
            }
            finally
            {

            }
        }
    }
}
