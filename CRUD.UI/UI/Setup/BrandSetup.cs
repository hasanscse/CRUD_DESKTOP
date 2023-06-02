using CrystalDecisions.CrystalReports.Engine;
using IA.BIZ.MODEL.BRAND;
using IA.BIZ.Setup.Brand;
using IA.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.UI.UI.Setup
{
    public partial class BrandSetup : Form
    {
        // Ibrahim
        public BrandSetup()
        {
            InitializeComponent();
            dgBrandLoad();
        }

        private void clearfield() {
            txtBrandName.Text = "";
            txtBRAND_ID.Text = "";
        
        
        }
        private void  dgBrandLoad()
        {
            try {
                dgBrandList.AutoGenerateColumns = false;
                dgBrandList.DataSource = BrandFetch.getAllBrand();
            }
            catch { }     
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                SqlConnection conn = ConnectionClass.GetConnection();
                SqlCommand objSqlCommand = new SqlCommand();
                objSqlCommand.CommandText = "INSERT INTO PRODUCT_BRAND(BRAND_NAME,COMPANY_ID,BRANCH_ID,ACTIVE_STATUS) "
                    + "VALUES('" + txtBrandName.Text + "',1,1,1)";
                objSqlCommand.Connection = conn;
                conn.Open();
                i = objSqlCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    dgBrandLoad();
                    clearfield();
                    MessageBox.Show("Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Saved Not Successfully");

                }
                conn.Close();

            }
            catch { }        
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try {
                if (txtBRAND_ID.Text.Length==0) {
                    MessageBox.Show("Select Data");
                    return;
                }
                if (txtBrandName.Text.Length==0)
                {
                    MessageBox.Show("Brand Name Can not be empty!!");
                    return;
                
                }
                BRAND objBRAND = new BRAND();
                objBRAND.BRAND_ID = Convert.ToInt32(txtBRAND_ID.Text);
                objBRAND.BRAND_NAME= txtBrandName.Text.ToString();
                objBRAND.ACTIVE_STATUS = 1;
                int i= BrandSave.UpdateBrand(objBRAND);

                if (i > 0)
                {
                    dgBrandLoad();
                    clearfield();
                    MessageBox.Show("Update Successfully");

                }
                else {

                    MessageBox.Show("Update Not Successfully");
                }


             }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete this data?", "Confirm Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try {
                    if (txtBRAND_ID.Text.Length==0) {

                        MessageBox.Show("Select Data");
                        return;
                    
                    }

                    int BRAND_ID = Convert.ToInt32(txtBRAND_ID.Text);
                    int i = BrandSave.deleteBrand(BRAND_ID);
                    if (i > 0)
                    {
                        dgBrandLoad();
                        clearfield();
                        MessageBox.Show("Deleted Successfully");
                    }
                    else {

                        MessageBox.Show("Deleted Not Successfully");
                    }






                }
                catch { }
            }
        }

        private void dgBrandList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                int BRAND_ID = Convert.ToInt32(dgBrandList.Rows[e.RowIndex].Cells[0].Value);
                BRAND objBRAND = BrandFetch.getBRAND(BRAND_ID);
                txtBrandName.Text= objBRAND.BRAND_NAME.ToString();
                txtBRAND_ID.Text = objBRAND.BRAND_ID.ToString();
            }
            catch { }



        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn =ConnectionClass.GetConnection();    
                SqlCommand objSqlCommand = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter(objSqlCommand);
                DataTable dt = new DataTable();
                objSqlCommand.CommandText = "RSP_PRODUCT_BRAND";
                objSqlCommand.CommandType = CommandType.StoredProcedure;
                objSqlCommand.Connection = conn;
                conn.Open();
                da.Fill(dt);
                ReportDocument test_report = new ReportDocument();

                string reportPath = "C:\\Program Files\\BrandList.rpt";
                test_report.Load(reportPath);
                test_report.SetDataSource(dt);

                CrystalReportViewer reportViewer = new CrystalReportViewer(test_report);
                reportViewer.Show();
            }
            catch {

               
            }


        }







        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string BRANCH = cmbBranch.SelectedValue.ToString();

        //        if (chkBranch.Checked)
        //        {
        //            BRANCH = "";
        //        }
        //        if (chkExpense.Checked)
        //        {

        //        }


        //        SqlConnection conn = ConnectionClass.GetConnection();
        //        SqlCommand objSqlCommand = new SqlCommand();
        //        SqlDataAdapter da = new SqlDataAdapter(objSqlCommand);
        //        DataTable dt = new DataTable();
        //        objSqlCommand.CommandText = "RSP__LIST";
        //        objSqlCommand.CommandType = CommandType.StoredProcedure;
        //        objSqlCommand.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.DateTime));
        //        objSqlCommand.Parameters["@FROM_DATE"].Value = dtpFromDate.Value;
        //        objSqlCommand.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime));
        //        objSqlCommand.Parameters["@TO_DATE"].Value = dtpToDate.Value;
        //        objSqlCommand.Parameters.Add(new SqlParameter("@COMPANY_ID", SqlDbType.VarChar, 30));
        //        objSqlCommand.Parameters["@COMPANY_ID"].Value = DASSessionInfoClass.COMPANY_ID;
        //        objSqlCommand.Parameters.Add(new SqlParameter("@BRANCH_ID", SqlDbType.VarChar, 30));
        //        objSqlCommand.Parameters["@BRANCH_ID"].Value = BRANCH;



        //        objSqlCommand.Connection = conn;
        //        conn.Open();
        //        da.Fill(dt);
        //        ReportDocument test_report = new ReportDocument();

        //        string reportPath = "C:\\Program Files\\List.rpt";
        //        test_report.Load(reportPath);
        //        test_report.SetDataSource(dt);
        //        ReportViewer obj = new ReportViewer(test_report);
        //        obj.Show();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
