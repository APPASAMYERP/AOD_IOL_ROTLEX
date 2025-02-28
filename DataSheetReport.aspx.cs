using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;

public partial class DataSheetReport : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportViewer1.Visible = false;
            string lotno = "SELECT DISTINCT Lot_Prefix + Lot_No AS Lot_No FROM POUCH_LABEL WHERE (Status IS NOT NULL)";
            SqlCommand cmd = new SqlCommand(lotno, con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            drpLotNo.Items.Clear();
            drpLotNo.Items.Insert(0, new ListItem("--Select--", "0"));
            drpLotNo.DataTextField = "Lot_No";
            drpLotNo.DataValueField = "Lot_No";
            drpLotNo.DataSource = null;
            drpLotNo.DataSource = dr;
            DataBind();
            con1.Close();
        }
    }
    protected void txtGenerate_Click(object sender, ImageClickEventArgs e)
    {
        ReportViewer1.Visible = true;
        if (drpLotNo.SelectedValue == "--Select--")
        {
            Messagebox("Choose LotNo");

        }
        else
        {        
            LocalReport lr = null;
            DataSet ds = new DataSet();
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select Model_Name,Power,(Lot_Prefix+Lot_No) as Lot_No,Label from POUCH_LABEL where (Lot_Prefix+Lot_No) ='" + drpLotNo.SelectedValue + "'", con1);
            da.Fill(ds, "temp");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "DataSheetReport.rdlc";
            lr.DataSources.Add(new ReportDataSource("DataSet3_POUCH_LABEL", ds.Tables[0]));
        }
    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    protected void txtclear_Click(object sender, ImageClickEventArgs e)
    {
        ReportViewer1.Visible = false;
    }
}
