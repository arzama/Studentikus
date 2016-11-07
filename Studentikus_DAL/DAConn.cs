using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentikus_DAL
{
    public class DAConn
    {
        SqlConnection GetConnection()
        {
            SqlConnection cm = new SqlConnection(Properties.Settings.Default.si001_studentConnectionString1);
            cm.Open();
            return cm;

        }
    }
}
