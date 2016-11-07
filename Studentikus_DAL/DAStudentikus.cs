using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Studentikus_DAL
{
    public class DAStudentikus
    {


        public static void getSlobodneSobe(DS_Studentikus.SobasDataTable dtSobe)
        {
            SqlConnection cm = Connection.GetConnection();
            if (cm.State == ConnectionState.Closed)
                cm.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("si001_student.procedura1", cm);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSobe);



            }

            finally
            {


            }

        }

    }
}


