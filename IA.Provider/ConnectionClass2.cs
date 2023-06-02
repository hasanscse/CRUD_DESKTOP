using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IA.Provider
{
    public class ConnectionClass2
    {
        public static SqlConnection GetSqlConnection() {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString);
            return conn;
        
        
        
        }
    }
}
