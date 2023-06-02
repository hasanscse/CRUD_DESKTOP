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
    public class BrandFetch
    {

        public static List<BRAND> getAllBrand()
        {
            List<BRAND> objListBRAND = new List<BRAND>();
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_PRODUCT_BRAND_GA";
            objSqlCommand.Connection = conn;
            conn.Open();
            try
            {
                SqlDataReader dr = objSqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    BRAND objBRAND = new BRAND();
                    objBRAND.BRAND_ID = Convert.ToInt32(dr["BRAND_ID"]);
                    objBRAND.BRAND_NAME = dr["BRAND_NAME"].ToString();
                    objBRAND.COMPANY_ID = Convert.ToInt32(dr["COMPANY_ID"]);
                    objBRAND.BRAND_ID = Convert.ToInt32(dr["BRAND_ID"]);
                    objBRAND.STATUS = dr["STATUS"].ToString();
                    objListBRAND.Add(objBRAND);
                }

            }
            catch { }

            finally
            {

                conn.Close();
            }

            return objListBRAND;
        }


        public static BRAND getBRAND(int BRAND_ID)
        {

            BRAND objBRAND = new BRAND();
            SqlConnection conn = ConnectionClass.GetConnection();
            SqlCommand objSqlCommand = new SqlCommand();
            objSqlCommand.CommandText = "FSP_PRODUCT_BRAND_GK";
            objSqlCommand.CommandType = CommandType.StoredProcedure;
            objSqlCommand.Parameters.Add(new SqlParameter("@BRAND_ID", SqlDbType.Int));
            objSqlCommand.Parameters["@BRAND_ID"].Value= BRAND_ID;

            objSqlCommand.Connection = conn;
            conn.Open();
            try
            {
                SqlDataReader dr = objSqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    objBRAND.BRAND_ID = Convert.ToInt32(dr["BRAND_ID"]);
                    objBRAND.BRAND_NAME = dr["BRAND_NAME"].ToString();
                    objBRAND.COMPANY_ID = Convert.ToInt32(dr["COMPANY_ID"]);
                    objBRAND.BRAND_ID = Convert.ToInt32(dr["BRAND_ID"]);
                    objBRAND.STATUS = dr["STATUS"].ToString();
                }


            }
            catch { }
            finally { conn.Close(); }

            return objBRAND;




        }


    }
}
