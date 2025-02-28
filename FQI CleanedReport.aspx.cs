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


public partial class FQI_CleanedReport : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
    SoftLensDataContext db = new SoftLensDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        ReportViewer1.Visible = false;
        if (!IsPostBack)
        {
            ReportViewer1.Visible = false;
            //txtDate1.Attributes.Add("readonly", "readonly");
            //txtDate2.Attributes.Add("readonly", "readonly");
            //var query = (from row in db.ModelMasters select row.Model).Distinct();
            //ddlmodel.DataSource = query;
            //ddlmodel.DataBind();
            lot();
        }
    }

    private void lot()
    {
        string lotno = "SELECT DISTINCT RefLot FROM POUCH_LABEL WHERE (Status IS NOT NULL)";
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
    protected void txtGenerate_Click(object sender, ImageClickEventArgs e)
    {
        if (drpLotNo.SelectedValue == "0")
        {
            Messagebox("Choose LotNo");

        }
        else
        {
        ReportViewer1.Visible = true;
        string lot = "SELECT  Reflot from POUCH_LABEL where RefLot='" + drpLotNo.SelectedValue + "'";
        SqlCommand cmd1 = new SqlCommand(lot, con1);
        

        con1.Open();
        string reflott = cmd1.ExecuteScalar().ToString();
        con1.Close();
        ReportViewer1.Visible = true;
       
            LocalReport lr = null;
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            //DateTime dt1 = Convert.ToDateTime(txtDate1.Text);
            //DateTime dt2 = Convert.ToDateTime(txtDate2.Text);
            SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),Date,103) as Date, GlassyNo as GlassyNo,Model as Model,Power as Power,RecievedQty as RecievedQty,BalanceQty as BalanceQty,AcceptedQty as AcceptedQty,RetumblingQty as RetumblingQty,RejectedQty as RejectedQty,TumblingRefNo as TumblingRefNo from MIinFQI where TumblingRefNo='"+drpLotNo.SelectedValue+"'  ", con);
            da.Fill(ds, "temp");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "FQI Report.rdlc";
            lr.DataSources.Add(new ReportDataSource("PHOBICDataSet_MIinFQI", ds.Tables[0]));
            if (ds.Tables["temp"].Rows.Count == 0)
            {


                Messagebox("No data found for the given input..");
                ReportViewer1.Visible = false;

            }
            else
            {
                ReportViewer1.Visible = true;
            }
            //LocalReport lr = null;
            //DataSet ds = new DataSet();
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter("Select Model_Name,Power,Label,R_Power from MI_FQIReject where RefLot ='" + reflott + "'", con);
            //da.Fill(ds, "temp");
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //lr = ReportViewer1.LocalReport;
            //lr.ReportPath = "FQI Report.rdlc";
            //ReportParameter[] param = new ReportParameter[1];
            //param[0] = new ReportParameter("LotNo", drpLotNo.SelectedValue);

            //this.ReportViewer1.LocalReport.SetParameters(param);
            //this.ReportViewer1.LocalReport.Refresh();

            //lr.DataSources.Add(new ReportDataSource("PHOBICDataSet_MIinFQI", ds.Tables[0]));

            //this.ReportViewer1.Visible = true;

            //if (txtDate1.Text != "" && txtDate2.Text != "" && ddlmodel.SelectedValue != "Select Model" && ddlpower.SelectedValue != "Select Power")
            //{
            //    ModelPower();
            //}
            //else if (txtDate1.Text != "" && txtDate2.Text != "" && ddlmodel.SelectedValue != "Select Model" && ddlpower.SelectedValue == "Select Power")
            //{
            //    ReportViewer1.Visible = false;
            //    Messagebox("Please Select Power Value");
            //}
            //else if (txtDate1.Text != "" && txtDate2.Text != "" && ddlmodel.SelectedValue == "Select Model" && ddlpower.SelectedValue != "Select Power")
            //{
            //    ReportViewer1.Visible = false;
            //    Messagebox("Please Select Model Value");
            //}
            //else if (txtDate1.Text == "" && txtDate2.Text != "" && ddlmodel.SelectedValue != "Select Model" && ddlpower.SelectedValue != "Select Power")
            //{
            //    ReportViewer1.Visible = false;
            //    Messagebox("Please Fill Start Date");
            //}
            //else if (txtDate1.Text != "" && txtDate2.Text == "" && ddlmodel.SelectedValue != "Select Model" && ddlpower.SelectedValue != "Select Power")
            //{
            //    ReportViewer1.Visible = false;
            //    Messagebox("Please Fill End Date"); 
            //}
            //else if (txtDate1.Text == "" && txtDate2.Text == "" && ddlmodel.SelectedValue == "Select Model" && ddlpower.SelectedValue == "Select Power")
            //{
            //    ReportViewer1.Visible = false;
            //    Messagebox("Please Fill Any Of The Above Categories");
            //}
            //else if (txtDate1.Text == "" && txtDate2.Text == "" && ddlmodel.SelectedValue != "Select Model" && ddlpower.SelectedValue != "Select Power")
            //{
            //    onlyModelPower();
            //}
            //else if (txtDate1.Text != "" && txtDate2.Text != "" && ddlmodel.SelectedValue == "Select Model" && ddlpower.SelectedValue == "Select Power")
            //{
            //    startenddate();
            //}
            //else if (txtDate1.Text == "" && txtDate2.Text != "" && ddlmodel.SelectedValue == "Select Model" && ddlpower.SelectedValue == "Select Power")
            //{
            //    ReportViewer1.Visible = false;
            //    Messagebox("Please Fill Start Date");
            //}
            //else if (txtDate1.Text != "" && txtDate2.Text == "" && ddlmodel.SelectedValue == "Select Model" && ddlpower.SelectedValue == "Select Power")
            //{
            //    ReportViewer1.Visible = false;
            //    Messagebox("Please Fill End Date");
            //}
            //else if (txtDate1.Text == "" && txtDate2.Text == "" && ddlmodel.SelectedValue != "Select Model" && ddlpower.SelectedValue == "Select Power")
            //{
            //    onlymodel();
            //}
        }

    }
    //protected void startenddate()
    //{
    //    LocalReport lr = null;
    //    DataSet ds = new DataSet();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand();
    //    DateTime dt1 = Convert.ToDateTime(txtDate1.Text);
    //    DateTime dt2 = Convert.ToDateTime(txtDate2.Text);
    //    SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),Date,103) as Date, GlassyNo as GlassyNo,Model as Model,Power as Power,RecievedQty as RecievedQty,BalanceQty as BalanceQty,AcceptedQty as AcceptedQty,RetumblingQty as RetumblingQty,RejectedQty as RejectedQty,TumblingRefNo as TumblingRefNo from MIinFQI where Date between '" + dt1.ToShortDateString() + "' and '" + dt2.ToShortDateString() + "' order by CONVERT(DateTime,Date,103)", con);
    //    da.Fill(ds, "temp");
    //    ReportViewer1.LocalReport.DataSources.Clear();
    //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //    lr = ReportViewer1.LocalReport;
    //    lr.ReportPath = "FQI Report.rdlc";
    //    lr.DataSources.Add(new ReportDataSource("PHOBICDataSet_MIinFQI", ds.Tables[0]));
    //}
    //protected void ModelPower()
    //{
    //    LocalReport lr = null;
    //    DataSet ds = new DataSet();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand();
    //    DateTime dt1 = Convert.ToDateTime(txtDate1.Text);
    //    DateTime dt2 = Convert.ToDateTime(txtDate2.Text);
    //    SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),Date,103) as Date, GlassyNo as GlassyNo,Model as Model,Power as Power,RecievedQty as RecievedQty,BalanceQty as BalanceQty,AcceptedQty as AcceptedQty,RetumblingQty as RetumblingQty,RejectedQty as RejectedQty,TumblingRefNo as TumblingRefNo from MIinFQI where Date between '" + dt1.ToShortDateString() + "' and '" + dt2.ToShortDateString() + "' and Model='" + ddlmodel.SelectedValue + "' and Power='" + ddlpower.SelectedValue + "' order by CONVERT(DateTime,Date,103)", con);
    //    da.Fill(ds, "temp");
    //    ReportViewer1.LocalReport.DataSources.Clear();
    //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //    lr = ReportViewer1.LocalReport;
    //    lr.ReportPath = "FQI Report.rdlc";
    //    lr.DataSources.Add(new ReportDataSource("PHOBICDataSet_MIinFQI", ds.Tables[0]));
    //}
    //protected void onlyModelPower()
    //{
    //    LocalReport lr = null;
    //    DataSet ds = new DataSet();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand();
    //    //DateTime dt1 = Convert.ToDateTime(txtDate1.Text);
    //    //DateTime dt2 = Convert.ToDateTime(txtDate2.Text);
    //    SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),Date,103) as Date, GlassyNo as GlassyNo,Model as Model,Power as Power,RecievedQty as RecievedQty,BalanceQty as BalanceQty,AcceptedQty as AcceptedQty,RetumblingQty as RetumblingQty,RejectedQty as RejectedQty,TumblingRefNo as TumblingRefNo from MIinFQI where Model='" + ddlmodel.SelectedValue + "' and Power='" + ddlpower.SelectedValue + "' order by CONVERT(DateTime,Date,103)", con);
    //    da.Fill(ds, "temp");
    //    ReportViewer1.LocalReport.DataSources.Clear();
    //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //    lr = ReportViewer1.LocalReport;
    //    lr.ReportPath = "FQI Report.rdlc";
    //    lr.DataSources.Add(new ReportDataSource("PHOBICDataSet_MIinFQI", ds.Tables[0]));
    //}
    //protected void onlymodel()
    //{
    //    LocalReport lr = null;
    //    DataSet ds = new DataSet();
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand();
    //    //DateTime dt1 = Convert.ToDateTime(txtDate1.Text);
    //    //DateTime dt2 = Convert.ToDateTime(txtDate2.Text);
    //    SqlDataAdapter da = new SqlDataAdapter("Select CONVERT(VARCHAR(10),Date,103) as Date, GlassyNo as GlassyNo,Model as Model,Power as Power,RecievedQty as RecievedQty,BalanceQty as BalanceQty,AcceptedQty as AcceptedQty,RetumblingQty as RetumblingQty,RejectedQty as RejectedQty,TumblingRefNo as TumblingRefNo from MIinFQI where Model='" + ddlmodel.SelectedValue + "' order by CONVERT(DateTime,Date,103)", con);
    //    da.Fill(ds, "temp");
    //    ReportViewer1.LocalReport.DataSources.Clear();
    //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
    //    lr = ReportViewer1.LocalReport;
    //    lr.ReportPath = "FQI Report.rdlc";
    //    lr.DataSources.Add(new ReportDataSource("PHOBICDataSet_MIinFQI", ds.Tables[0]));
    //}   
  
    protected void txtclear_Click(object sender, ImageClickEventArgs e)
    {
        //var firstitem = ddlpower.Items[0];
        //txtDate1.Text = "";
        //txtDate2.Text = "";       
        //ddlmodel.SelectedValue = "Select Model";
        //ddlpower.Items.Clear();
        //ddlpower.Items.Add(firstitem);
        //ddlpower.Items.Clear();
        //ddlpower.Items.Add("Select Power",0);
        //ddlpower.SelectedValue = ddlpower.Items[0].ToString();
        //drpLotNo.SelectedValue="--Select--";
        lot();
        ReportViewer1.Visible = false;
    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    //protected void txtmodel_TextChanged(object sender, EventArgs e)
    //{
    //    var Q = (from x in db.MIinFQIs where x.Model == txtmodel.Text select x.Power).Distinct();
    //    ddlpower.DataSource = Q;
    //    ddlpower.DataBind();
    //}
    //protected void ddlmodel_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    var Q = (from x in db.MIinFQIs where x.Model == ddlmodel.SelectedValue select x.Power).Distinct();
    //    ddlpower.DataSource = Q;
    //    ddlpower.DataBind();
    //}
}
