using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.UI
{
    public partial class CrystalReportViewer : Form
    {
        public CrystalReportViewer(ReportDocument test_report)
        {
            InitializeComponent();
            //string USER_ID = ConfigurationManager.AppSettings["USER_ID"].ToString();
            //string PASSWORD = ConfigurationManager.AppSettings["PASSWORD"].ToString();
            //string PC_NAME = ConfigurationManager.AppSettings["PC_NAME"].ToString();
            //string DATABASE_NAME = ConfigurationManager.AppSettings["DATABASE_NAME"].ToString();
            //test_report.SetDatabaseLogon(USER_ID, PASSWORD, PC_NAME, DATABASE_NAME);
            crystalReportViewer1.ReportSource = test_report;
        }
    }
}
