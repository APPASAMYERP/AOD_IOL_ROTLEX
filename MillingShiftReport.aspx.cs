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


public partial class MillingShiftReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    
protected void  btnGenerate_Click(object sender, ImageClickEventArgs e)
{
            
        if (ddlShift.Text == "Select")
        {
            messagebox("Please Choose Shift");
        }
             else
        {
            LocalReport lr = null;
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select * from milling where Date='" + txtDate.Text + "' and Shift='" + ddlShift.Text + "'"  , con);
            da.Fill(ds, "temp");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "MillingShiftReport.rdlc";


            SoftLensDataContext db = new SoftLensDataContext();

            ReportViewer1.LocalReport.ReportPath = "MillingShiftReport.rdlc";

            ReportParameter[] param = new ReportParameter[3];
            param[0] = new ReportParameter("name", txtSupervisorName.Text, false);
            param[1] = new ReportParameter("date", txtDate.Text, false);
            param[2] = new ReportParameter("shift", ddlShift.Text, false);
           
            this.ReportViewer1.LocalReport.SetParameters(param);
            this.ReportViewer1.LocalReport.Refresh();

            lr.DataSources.Add(new ReportDataSource("MillingShiftReport_Milling", ds.Tables[0]));
            int q = ds.Tables[0].Rows.Count;

        }
}
}
    
