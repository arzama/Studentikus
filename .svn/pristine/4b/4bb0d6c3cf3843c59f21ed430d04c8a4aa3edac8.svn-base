using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Studentikus_DAL.Properties;
namespace Studentikus_DAL
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection cn = new SqlConnection(Properties.Settings.Default.si001_studentConnectionString1);
            cn.Open();
            return cn;
        }
    }
}
