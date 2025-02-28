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


public partial class FQIMiReort : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);   
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportViewer1.Visible = false;
            string lotno = "SELECT DISTINCT Reflot from POUCH_LABEL where Type='MOULDING'";
            SqlCommand cmd = new SqlCommand(lotno, con1);
            con1.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            drpLotNo.Items.Clear();
            drpLotNo.Items.Insert(0, new ListItem("--Select--", "0"));
            drpLotNo.DataTextField = "RefLot";
            drpLotNo.DataValueField = "RefLot";
            drpLotNo.DataSource = null;
            drpLotNo.DataSource = dr;
            DataBind();
            con1.Close();
        }
    }

    //protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
    //{

    //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);

    //    LocalReport lr = null;
    //    DataSet ds = new DataSet();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand();
    //    DateTime dt1 = Convert.ToDateTime(txtDate.Text, provider);
    //    DateTime dt2 = Convert.ToDateTime(txtDate1.Text, provider);
    //    SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),DATE,105) as Date,TumblingNo,Sum(RecievedQty) as RecievedQty,Sum(ProgressQty) as ProgressQty,Sum(AcceptedQty) as AcceptedQty,Sum(RejectedQty) as RejectedQty,Sum(CompletedQty) as CompletedQty,Sum(Dots) as Dots,Sum(Islands) as Islands,Sum(LB) as LB,Sum(SCR) as SCR,Sum(PIMP) as PIMP,Sum(HeatProb) as HeatProb,Sum(BalanceQty) as BalanceQty from MIinFQI where cast(convert(varchar(8),Date,112) as Datetime) between '" + dt1.ToShortDateString() + "' and '" + dt2.ToShortDateString() + "'group by Date,TumblingNo", con);
    //    da.Fill(ds, "temp");

    //    ReportViewer1.LocalReport.DataSources.Clear();
    //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //    lr = ReportViewer1.LocalReport;
    //    lr.ReportPath = "MIFQIReport.rdlc";
    //    lr.DataSources.Add(new ReportDataSource("FQIMicroScopicDataSet_MIinFQI", ds.Tables[0]));
    //}

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
            SqlDataAdapter da = new SqlDataAdapter("Select Max(Model_Name) as Model_Name,Max(Power) As Power,Count(Qty) As Qty,Max(RefLot) As RefLot,Max(Status) As Status from POUCH_LABEL where Reflot='" + drpLotNo.SelectedValue + "' group by Power", con1);
            da.Fill(ds, "temp");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "InspectionReport.rdlc";           
            lr.DataSources.Add(new ReportDataSource("DataSet3_POUCH_LABEL", ds.Tables[0]));
            this.ReportViewer1.Visible = true;
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
