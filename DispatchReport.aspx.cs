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


public partial class DespatchReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

   

    protected void txtDcNo_TextChanged(object sender, EventArgs e)
    {
        btnGenerate.Visible = true;
        LocalReport lr = ReportViewer1.LocalReport;
        lr.ReportPath = "";        
    }
    protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
    {
        LocalReport lr = null;
        DataSet ds = new DataSet();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter("Select * from DespatchChild where DcNo= '" + txtDcNo.Text + "'", con);
        da.Fill(ds, "temp");
        //SqlDataAdapter da1 = new SqlDataAdapter("SELECT SUM(InspectedQuantity) as Recqty from MillingCleanedLens WHERE Date='" + txtDate.Text + "'", con);
        //da1.Fill(ds, "temp");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.ProcessingMode = ProcessingMode.Local;
        lr = ReportViewer1.LocalReport;
        lr.ReportPath = "DispatchReportt.rdlc";

        SoftLensDataContext db = new SoftLensDataContext();
        var addr = from a in db.DespatchTables where a.DCNo == txtDcNo.Text select a;
        string ad = addr.Single().Address.ToString();
        string dc = addr.Single().DCNo.ToString();
        DateTime dat = addr.Single().DcDate.Value;
        string date = dat.ToString("dd/MM/yyyy");
        string mode = addr.Single().ModeOfDespatch.ToString();
        string nop = addr.Single().NoOfPacking.ToString();

        ReportViewer1.LocalReport.ReportPath = "DispatchReportt.rdlc";

        ReportParameter[] param = new ReportParameter[5];
        param[0] = new ReportParameter("ToAddress", ad, false);
        param[1] = new ReportParameter("DcNo", dc.ToString(), false);
        param[2] = new ReportParameter("Date", date, false);
        param[3] = new ReportParameter("DispatchMode", mode, false);
        param[4] = new ReportParameter("NoofPack", nop.ToString(), false);

        this.ReportViewer1.LocalReport.SetParameters(param);
        this.ReportViewer1.LocalReport.Refresh();

        lr.DataSources.Add(new ReportDataSource("Dispatch_DespatchChild", ds.Tables[0]));

        btnGenerate.Visible = false;
    }
}
