using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportsIntegration
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReportViewer2.ProcessingMode = ProcessingMode.Local;

                LocalReport localReport = ReportViewer2.LocalReport;

                localReport.ReportPath = "Reports/incidents.rdlc";

                DataSet dataset = new DataSet("DataSet1");
                string filterYear = "2024";

                GetReportData(filterYear, ref dataset);

                ReportDataSource dsSalesOrder = new ReportDataSource();
                dsSalesOrder.Name = "DataSet1";
                dsSalesOrder.Value = dataset.Tables["DataSet1"];

                localReport.DataSources.Add(dsSalesOrder);


            }
        }

        private void GetReportData(string filterYear, ref DataSet dsSalesOrder)
        {
            string sqlSalesOrder = "SELECT   tbl_test_chart_3.rowID   ,tbl_test_chart_3.typeOfIncident ,DateName(month,[dateSubmitted]) as [dateSubmitted]   ,tbl_test_chart_3.rnid ,month([dateSubmitted]) as mthOrder FROM   tbl_test_chart_3 WHERE  Year(tbl_test_chart_3.dateSubmitted) = @year";


               
           //     "WHERE  (SOH.SalesOrderNumber = @SalesOrderNumber)";

            SqlConnection connection = new
                SqlConnection("Data Source=DESKTOP-SPS7F6P; " +
                              "Initial Catalog=stakeholder; " +
                              "Integrated Security=SSPI");

            SqlCommand command =
                new SqlCommand(sqlSalesOrder, connection);

            command.Parameters.Add(
                new SqlParameter("year",
                filterYear));

            SqlDataAdapter salesOrderAdapter = new
                SqlDataAdapter(command);

            salesOrderAdapter.Fill(dsSalesOrder, "DataSet1");
        }
    }
}