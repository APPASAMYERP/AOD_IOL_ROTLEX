using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class TumblingRunningReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        LocalReport lr = null;
        DataSet ds = new DataSet();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter("SELECT ModelNo, Power, SUM(Quantity) AS quantity FROM TumblingChild where flag=1 GROUP BY ModelNo, Power", con);
        da.Fill(ds, "temp");

        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        lr = ReportViewer1.LocalReport;
        lr.ReportPath = "TumblingRunningReport.rdlc";
        lr.DataSources.Add(new ReportDataSource("TumblingRunningReport_TumblingChild", ds.Tables[0]));
       
    }
 
}
