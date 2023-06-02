using IA.BIZ.MODEL.BRAND;
using IA.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.BIZ.Setup.Brand
{
    public class BrandSave
    {
        public static int deleteBrand(int BRAND_ID)
        {
            int i = 0;
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_PRODUCT_BRAND_D";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add(new SqlParameter("@BRAND_ID", SqlDbType.Int));
            objSqlCommand.Parameters["@BRAND_ID"].Value = BRAND_ID;           
            objSqlCommand.Connection = conn;
            conn.Open();
            try
            {

                i = objSqlCommand.ExecuteNonQuery();

            }
            catch { }
            finally { conn.Close(); }
            return i;
        }


        public static int UpdateBrand(BRAND objBRAND)
        {

            if (objBRAND == null) { return 0; }
            int i = 0;
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_PRODUCT_BRAND_U";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add(new SqlParameter("@BRAND_ID", SqlDbType.Int));
            objSqlCommand.Parameters["@BRAND_ID"].Value = objBRAND.BRAND_ID;
            objSqlCommand.Parameters.Add(new SqlParameter("@BRAND_NAME", SqlDbType.VarChar, 60));
            objSqlCommand.Parameters["@BRAND_NAME"].Value = objBRAND.BRAND_NAME;
            objSqlCommand.Parameters.Add(new SqlParameter("@ACTIVE_STATUS", SqlDbType.Int));
            objSqlCommand.Parameters["@ACTIVE_STATUS"].Value = objBRAND.ACTIVE_STATUS;

            objSqlCommand.Connection = conn;
            conn.Open();
            try
            {

                i = objSqlCommand.ExecuteNonQuery();

            }
            catch { }
            finally { conn.Close(); }
            return i;



        }

    }
}
