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

public partial class PowModelRep : System.Web.UI.Page
{

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
    {
        LocalReport lr = null;
        DataSet ds = new DataSet();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        DateTime dt1 = Convert.ToDateTime(txtFromDate.Text, provider);
        DateTime dt2 = Convert.ToDateTime(txtToDate.Text, provider);
        SqlDataAdapter da = new SqlDataAdapter("Select * from PowerModelView where cast(convert(varchar(8),Date,112)as Datetime) between '" + dt1.ToShortDateString() + "' and '" + dt2.ToShortDateString() + "'", con);
        da.Fill(ds, "temp");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        lr = ReportViewer1.LocalReport;
        lr.ReportPath = "PowervsModelReport.rdlc";


        SoftLensDataContext db = new SoftLensDataContext();

        ReportViewer1.LocalReport.ReportPath = "PowervsModelReport.rdlc";

        ReportParameter[] param = new ReportParameter[2];
        param[0] = new ReportParameter("FromDate", txtFromDate.Text, false);
        param[1] = new ReportParameter("ToDate", txtToDate.Text, false);


        this.ReportViewer1.LocalReport.SetParameters(param);
        this.ReportViewer1.LocalReport.Refresh();

        lr.DataSources.Add(new ReportDataSource("PowerModelReport_PowerModelView", ds.Tables[0]));
        int q = ds.Tables[0].Rows.Count;
    }
}
