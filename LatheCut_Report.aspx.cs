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


public partial class LatheCut_Report : System.Web.UI.Page
{

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }


    protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
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
            DateTime dt = Convert.ToDateTime(txtDate.Text, provider);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Lathecut where shift='" + ddlShift.Text + "' and cast(convert(varchar(8),date,112)as datetime)='" +dt.ToShortDateString() + "'", con);
            
            da.Fill(ds, "temp");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "LatheCutShiftReport.rdlc";


            SoftLensDataContext db = new SoftLensDataContext();
            int cut1 = 0;
            int cut2 = 0;
            try
            {
                var query = (from row in db.Lathecuts where row.Date == Convert.ToDateTime(txtDate.Text, provider) && row.Shift == ddlShift.Text && row.LatheType == "Ist Cut" select row.AcceptedQuantity).Sum();
                var query2 = (from row2 in db.Lathecuts where row2.Date == Convert.ToDateTime(txtDate.Text, provider) && row2.Shift == ddlShift.Text && row2.LatheType == "IInd Cut" select row2.AcceptedQuantity).Sum();
                cut1 = query.Value;
                cut2 = query2.Value;
            }
            catch
            {

            }
            ReportViewer1.LocalReport.ReportPath = "LatheCutShiftReport.rdlc";

            ReportParameter[] param = new ReportParameter[5];
            param[0] = new ReportParameter("name", txtSupervisorName.Text, false);
            param[1] = new ReportParameter("date", txtDate.Text, false);
            param[2] = new ReportParameter("shift", ddlShift.Text, false);
            param[3] = new ReportParameter("cut1", cut1.ToString(), false);
            param[4] = new ReportParameter("cut2", cut2.ToString(), false);
            this.ReportViewer1.LocalReport.SetParameters(param);
            this.ReportViewer1.LocalReport.Refresh();

            lr.DataSources.Add(new ReportDataSource("LatheCut_Lathecut", ds.Tables[0]));
            int q = ds.Tables[0].Rows.Count;

        }

    }


}