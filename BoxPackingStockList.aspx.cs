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
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;


public partial class BoxPackingStockList : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        LocalReport lr = null;
        DataSet ds = new DataSet();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter("Select * from PackingEntryTable where remainingqty !=0", con);
        da.Fill(ds, "temp");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        lr = ReportViewer1.LocalReport;
        lr.ReportPath = "BoxPackingReport.rdlc";

        lr.DataSources.Add(new ReportDataSource("BoxPackingData_PackingEntryData", ds.Tables[0]));
        int q = ds.Tables[0].Rows.Count;
    }
}
