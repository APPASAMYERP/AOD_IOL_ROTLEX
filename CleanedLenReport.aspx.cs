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

public partial class CleanedLenReport : System.Web.UI.Page
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
    

    protected void txtGenerate_Click1(object sender, ImageClickEventArgs e)
    {
        
        if ((txtDate1.Text == "" ) || (txtDate2.Text == ""))
        {
            messagebox("Please Select Date");
        }
        else
        {
            LocalReport lr = null;
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            DateTime dt1 = Convert.ToDateTime(txtDate1.Text, provider);
            DateTime dt2 = Convert.ToDateTime(txtDate2.Text, provider);
            SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),DATE,105) as Date, SUM(InspectedQuantity) as InspectedQuantity, SUM(AcceptedQuantity) as AcceptedQuantity, SUM(RejectedQty) as RejectedQty,SUM(ESC) as ESC,SUM(SCR) as SCR,SUM(LB) as LB,SUM(CHIP) as CHIP,SUM(BURR) as BURR,SUM(Thick) as Thick,SUM(OTHERS) as OTHERS,SUM(OFFSET) as OFFSET,SUM(CUTTING) as CUTTING,SUM(TotalRejQty) as TotalRejQty from MillingCleanedLens where cast(convert(varchar(8),Date,112) as Datetime)  between '" + dt1.ToShortDateString() + "' and '" + dt2.ToShortDateString() + "' group by Date ", con);
            da.Fill(ds, "temp");
            //SqlDataAdapter da1 = new SqlDataAdapter("SELECT SUM(InspectedQuantity) as Recqty from MillingCleanedLens WHERE Date='" + txtDate.Text + "'", con);
            //da1.Fill(ds, "temp");
            rvCleanedLens.LocalReport.DataSources.Clear();
            rvCleanedLens.ProcessingMode = ProcessingMode.Local;
            lr = rvCleanedLens.LocalReport;
            lr.ReportPath = "CleanedReport.rdlc";
            lr.DataSources.Add(new ReportDataSource("DataSet1_MillingCleanedLens", ds.Tables[0]));
        }
    }
}
