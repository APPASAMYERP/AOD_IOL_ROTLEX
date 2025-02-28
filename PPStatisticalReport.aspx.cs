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

public partial class PPStatisticalReport : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        LocalReport lr = null;
        DataSet ds = new DataSet();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter("Select Model,Power,sum(WaitingTumbling) as WaitingTumbling,sum(RunningTumbling) as RunningTumbling,sum(WaitingPowerSegregation) as WaitingPowerSegregation,sum(WaitingPouchPacking) as WaitingPouchPacking from Report_Table where (RetumblingNo is null) AND (Status=0 or Status=1 or Status=2 or Status=3) group by Model,Power", con);
        da.Fill(ds, "temp");

        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        lr = ReportViewer1.LocalReport;
        lr.ReportPath = "PPStatisticalReport.rdlc";
        lr.DataSources.Add(new ReportDataSource("Production_Planning_Report_Table", ds.Tables[0]));
    }

}
