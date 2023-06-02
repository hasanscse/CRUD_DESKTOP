using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.Provider
{
    public class ConnectionClass
    {

        public static SqlConnection GetConnection()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString);
            return conn;
        }
        public static SqlConnection GetConnectionMaster()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString);
            return conn;
        }










    }
}
