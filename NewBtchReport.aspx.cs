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

public partial class NewBtchReport : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);

            LocalReport lr = null;
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            DateTime dt1 = Convert.ToDateTime(txtDate.Text);
            DateTime dt2 = Convert.ToDateTime(txtDate1.Text);
            string formattedDate1 = dt1.ToString("yyyy-MM-dd");
            string formattedDate2 = dt2.ToString("yyyy-MM-dd");
            //SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),Date,105) as Date,SUM(RecievedQty) as RecievedQty ,SUM(AcceptedQty) as AcceptedQty,SUM(RejectedQty) as RejectedQty,Power1,Power2,Power3,Power4,Power5,Power6,Power7,Power8,SUM(Qty1) as Qty1,SUM(Qty2) as Qty2,SUm(Qty3) as Qty3,SUM(Qty4) as Qty4,SUM(Qty5) as Qty5,SUm(Qty6) as Qty6,SUM(Qty7) as Qty7,SUM(Qty8) as Qty8 from PowerSegregationTable where cast(convert(varchar(8),Date,112) as datetime)  between '" + dt1.ToShortDateString() + "' and '" + dt2.ToShortDateString() + "' group by Date,Power1,Power2,Power3,Power4,Power5,Power6,Power7,Power8", con);
            SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),Date,105) as Date,LotNo,Model,SolutionId,Shift,Quantity from NewBtchAllot where cast(convert(varchar(8),Date,112) as datetime)  between '" + formattedDate1 + "' and '" + formattedDate2 + "' ", con);
            da.Fill(ds, "temp");
            if (ds.Tables["temp"].Rows.Count == 0)
            {


                Messagebox("No data found for the given input..");
              
            }
            else
            {
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                lr = ReportViewer1.LocalReport;
                lr.ReportPath = "NewbtchallotReport.rdlc";
                lr.DataSources.Add(new ReportDataSource("DataSet2_NewBtchAllot", ds.Tables[0]));
            }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {


        DateTime parsedDate;

        // Try to parse the date input from the text box
        if (DateTime.TryParse(txtDate.Text, out parsedDate))
        {
            // If successful, format the date to "yyyy-MM-dd"
            txtDate.Text = parsedDate.ToString("yyyy-MM-dd");
        }
        else
        {
            
            txtDate.Text = ""; 
            Messagebox("Do not Enter..Only select the date");
        }
    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "windows", "alert('" + msg + "')", true);
    }
    protected void txtDate1_TextChanged(object sender, EventArgs e)
    {
        DateTime parsedDate;

        // Try to parse the date input from the text box
        if (DateTime.TryParse(txtDate.Text, out parsedDate))
        {
            // If successful, format the date to "yyyy-MM-dd"
            txtDate.Text = parsedDate.ToString("yyyy-MM-dd");
        }
        else
        {
          
            txtDate.Text = "";
            Messagebox("Do not Enter..Only select the date");
        }
    }
}
