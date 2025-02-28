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

public partial class MI_FQIRejectionReport : System.Web.UI.Page
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
     private bool IsValidLotNumber(string lotNumber)
    {
     
        return !string.IsNullOrWhiteSpace(lotNumber) && lotNumber.All(c => Char.IsLetterOrDigit(c));
    }
    protected void txtGenerate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (!IsValidLotNumber(drpLotNo.Text))
            {
                Messagebox("Please enter a valid Lot number.");
                return;
            }
            if (drpLotNo.SelectedValue == "--Select--")
            {
            Messagebox("Choose LotNo");
            }
            else
            {
            string lot = "SELECT DISTINCT Reflot from POUCH_LABEL where (Lot_Prefix+Lot_No)='" + drpLotNo.SelectedValue + "'";
            SqlCommand cmd1 = new SqlCommand(lot, con1);
            con1.Open();
            string reflott = cmd1.ExecuteScalar().ToString();
            con1.Close();
            ReportViewer1.Visible = true;
            LocalReport lr = null;
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select Model_Name,Power,Label,R_Power from MI_FQIReject where Reflot='" + reflott + "'", con);
            da.Fill(ds, "temp");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "MI_FQIRejectionReport.rdlc";
            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("LotNo", drpLotNo.SelectedValue);          
            this.ReportViewer1.LocalReport.SetParameters(param);
            this.ReportViewer1.LocalReport.Refresh();
            lr.DataSources.Add(new ReportDataSource("DataSet4_MI_FQIReject", ds.Tables[0]));
            if (ds.Tables["temp"].Rows.Count == 0)
            {
                Messagebox("No data found for the given input..");
            }
            else
            {
                this.ReportViewer1.Visible = true;
            }
           
          }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
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
