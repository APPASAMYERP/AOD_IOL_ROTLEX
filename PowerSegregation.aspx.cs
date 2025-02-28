using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;


public partial class PowerSegregation : System.Web.UI.Page
{

    #region Declaration

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);
    int flag = 0;
    int Flag1;
    int Retum = 1;

    #endregion



    #region Method



    #endregion



    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        var username = (Session["Username"] as HtmlInputControl).Value;

        if (username == null)
        {
            Response.Redirect("404Page.aspx");
        }
        if (!IsPostBack)
        {
            
         txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //DataTableBind();
        }
    }

    #endregion

    private void clear()
    {
        txtAcceptedQty.Text = "";
        //txtTotalQty.Text = "";
        txtInspectedBy.Text = "";
        //txtObservedPower.Text = "";
        //txtQty.Text = "";
        //txtGrfNo.Text = "";
        txtRecievedQty.Text = "";
        txtRejectedQty.Text = "";
        txtTumblingrefno.Text = "";
        txtRemarks.Text = "";
        txtDate.Text = "";
        //lbTotalQuantity.Visible = false;
        //txtTotalQty.Visible = false;
        chkGoodReason.Checked = true;
        chkBadReason.Checked = false;
        ViewState["table"] = null;
        //gvPowerSegregation.DataSource = null;
        //gvPowerSegregation.DataBind();
        btnUpdate.Visible = false;
        btnClear.Visible = false;
        btnSave.Visible = false;
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    //private void DataTableBind()
    //{
    //    DataTable dataTable = new DataTable();
    //    dataTable.Columns.Add("ObservedPower", typeof(decimal));
    //    dataTable.Columns.Add("Qty", typeof(int));
    //    dataTable.Columns.Add("GlassyRef", typeof(string));
    //    ViewState["table"] = dataTable;
    //}

    //private void ReportUpdate()
    //{
    //    var Q = from row in db.Report_Tables where row.TumblingNo == txtTumblingNo.Text && row.Status == 2 select row;
    //    if (Q.Count() > 0)
    //    {
    //        Report_Table rt = new Report_Table();
    //        int qty = Convert.ToInt32(Q.Single().WaitingPowerSegregation);
    //        Q.Single().WaitingPowerSegregation = 0;
    //        Q.Single().WaitingPouchPacking = qty;
    //        Q.Single().Status = 3;
    //        db.SubmitChanges();
    //    }
    //    else
    //    {
    //        var Qu = from row in db.Report_Tables where row.RetumblingNo == txtTumblingNo.Text && row.Status == 2 select row;
    //        if (Qu.Count() > 0)
    //        {
    //            Report_Table rt = new Report_Table();
    //            int qty = Convert.ToInt32(Qu.Single().WaitingPowerSegregation);
    //            Qu.Single().WaitingPowerSegregation = 0;
    //            Qu.Single().WaitingPouchPacking = qty;
    //            Qu.Single().Status = 3;
    //            db.SubmitChanges();
    //        }

    //    }

    //}  
    private void ReportBind()
    {
        //var w = from row in db.Report_Tables where row.TumblingNo == txtTumblingNo.Text && row.Power == Convert.ToDecimal(txtObservedPower.Text) select row;
        //if (w.Count() > 0)
        //{
        //    w.FirstOrDefault().GlassyNo = txtGrfNo.Text;
        //    w.FirstOrDefault().WaitingPowerSegregation = 0;
        //    w.FirstOrDefault().WaitingPouchPacking = Convert.ToInt32(txtQty.Text);
        //    w.FirstOrDefault().Status = 3;
        //    db.SubmitChanges();
        //}
        //else
        //{
        //    Report_Table rt = new Report_Table();
        //var query = from row in db.LensPreperation_Details where row.TumblingRefNo == txtTumblingNo.Text select row;
        //    var s = from row in db.Report_Tables where row.TumblingNo == txtTumblingNo.Text select row;
        //    if (s.Count() > 0)
        //    {

        //        rt.TumblingNo = s.FirstOrDefault().TumblingNo;
        //        rt.Model = s.FirstOrDefault().Model;
        //        rt.PhobicId = s.FirstOrDefault().PhobicId;
        //        rt.WaitingPowerSegregation = 0;
        //        rt.WaitingTumbling = 0;
        //        rt.RunningTumbling = 0;
        //        rt.GlassyNo = txtGrfNo.Text;
        //        rt.WaitingPouchPacking = Convert.ToInt32(txtQty.Text);
        //        rt.Power = Convert.ToDecimal(txtObservedPower.Text);
        //        rt.Status = 3;
        //        db.Report_Tables.InsertOnSubmit(rt);
        //        db.SubmitChanges();
        //    }
        //    else
        //    {
        //        var w1 = from row in db.Report_Tables where row.RetumblingNo == txtTumblingNo.Text && row.Power == Convert.ToDecimal(txtObservedPower.Text) select row;
        //        if (w1.Count() > 0)
        //        {
        //            w1.FirstOrDefault().GlassyNo = txtGrfNo.Text;
        //            w1.FirstOrDefault().WaitingPowerSegregation = 0;
        //            w1.FirstOrDefault().WaitingPouchPacking = Convert.ToInt32(txtQty.Text);
        //            w1.FirstOrDefault().Status = 3;
        //            db.SubmitChanges();
        //        }
        //        else
        //        {
        //            //Report_Table rt1 = new Report_Table();
        //            var s1 = from row in db.Report_Tables where row.RetumblingNo == txtTumblingNo.Text select row;
        //            if (s1.Count() > 0)
        //            {
        //                rt.RetumblingNo = s1.FirstOrDefault().RetumblingNo;
        //                rt.Model = s1.FirstOrDefault().Model;
        //                rt.PhobicId = s1.FirstOrDefault().PhobicId;
        //                rt.WaitingPowerSegregation = 0;
        //                rt.WaitingTumbling = 0;
        //                rt.RunningTumbling = 0;
        //                rt.GlassyNo = txtGrfNo.Text;
        //                rt.WaitingPouchPacking = Convert.ToInt32(txtQty.Text);
        //                rt.Power = Convert.ToDecimal(txtObservedPower.Text);
        //                rt.Status = 3;
        //                db.Report_Tables.InsertOnSubmit(rt);
        //                db.SubmitChanges();
        //            }
        //        }
        //    }
        //}
    }

    //private void TotalQtyCal()
    //{
    //    int ct = gvPowerSegregation.Rows.Count;
    //    DataTable dt = (DataTable)ViewState["table"];
    //    int qty = 0;
    //    for (int i = 0; i < ct; i++)
    //    {
    //        //Label v = gvPowerSegregation.Rows[i].Cells[1].FindControl("Label2") as Label;
    //        string v = dt.Rows[i][1].ToString();
    //        qty = qty + Convert.ToInt32(v);
    //    }
    //    txtTotalQty.Text = qty.ToString();
    //}

    //protected void gvPowerSegregation_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{

    //    TextBox Power = gvPowerSegregation.Rows[e.RowIndex].Cells[0].FindControl("Textbox1") as TextBox;
    //    TextBox qty = gvPowerSegregation.Rows[e.RowIndex].Cells[1].FindControl("Textbox2") as TextBox;
    //    TextBox GlassyRecordRef = gvPowerSegregation.Rows[e.RowIndex].Cells[2].FindControl("Textbox3") as TextBox;


    //    DataTable dt = (DataTable)ViewState["table"];

    //    int fl = 0;
    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        if (i != Convert.ToInt32(Session["rowdelindex"].ToString()))
    //        {
    //            if (Convert.ToDecimal(dt.Rows[i][0].ToString()) == Convert.ToDecimal(Power.Text))
    //            {
    //                dt.Rows[i][1] = Convert.ToInt32(qty.Text) + Convert.ToDecimal(dt.Rows[i][1].ToString());
    //                dt.Rows[i][2] = GlassyRecordRef.Text.ToString();
    //                gvPowerSegregation.EditIndex = -1;
    //                gvPowerSegregation.DataSource = dt;
    //                gvPowerSegregation.DataBind();
    //                ViewState["table"] = dt;

    //                dt.Rows[Convert.ToInt32(Session["rowdelindex"].ToString())].Delete();
    //                gvPowerSegregation.DataSource = dt;
    //                gvPowerSegregation.DataBind();
    //                ViewState["table"] = dt;

    //                TotalQtyCal();
    //                fl = 1;
    //            }
    //        }
    //    }
    //    if (fl == 0)
    //    {
    //        dt = (DataTable)ViewState["table"];
    //        DataRow[] rows = dt.Select();
    //        rows[e.RowIndex][0] = Power.Text;
    //        rows[e.RowIndex][1] = qty.Text;
    //        rows[e.RowIndex][2] = GlassyRecordRef.Text;
    //        gvPowerSegregation.EditIndex = -1;
    //        gvPowerSegregation.DataSource = dt;
    //        gvPowerSegregation.DataBind();
    //        ViewState["table"] = dt;
    //        TotalQtyCal();
    //    }
    //}

    //protected void gvPowerSegregation_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvPowerSegregation.EditIndex = e.NewEditIndex;
    //    Session["rowdelindex"] = e.NewEditIndex;
    //    DataTable dt = (DataTable)ViewState["table"];
    //    gvPowerSegregation.DataSource = dt;
    //    gvPowerSegregation.DataBind();
    //}


    protected void txtTumblingNo_TextChanged(object sender, EventArgs e)
    {
        clear();
        string t = txtTumblingNo.Text;
        txtTumblingNo.Text = t.ToUpper();
        btnClear.Visible = true;
        var query = from row in db.Lensometer_PowerChecks where row.TumblingNo == txtTumblingNo.Text select row;
        if (query.Count() > 0)
        {
            txtAcceptedQty.Text = query.Single().AcceptedQty.ToString();
            DateTime tdate = query.Single().Date.Value;
            txtDate.Text = tdate.ToString("yyyy-MM-dd");
            txtInspectedBy.Text = query.Single().InspectedBy.ToString();
            txtRecievedQty.Text = query.Single().RecievedQty.ToString();
            txtRejectedQty.Text = query.Single().RejectedQty.ToString();
            txtRemarks.Text = query.Single().Remarks.ToString();
            //txtTotalQty.Text = query.Single().TotalQty.ToString();
            string res = query.Single().Resolution.ToString();

            if (res == "Good")
            {
                chkGoodReason.Checked = true;
                chkBadReason.Checked = false;
            }
            else
            {
                chkGoodReason.Checked = false;
                chkBadReason.Checked = true;
            }
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            //txtTotalQty.Visible = true;
            //lbTotalQuantity.Visible = true;

            //DataTable dt = new DataTable();
            //dt.Columns.Add("ObservedPower", typeof(decimal));
            //dt.Columns.Add("Qty", typeof(int));
            //dt.Columns.Add("GlassyRef", typeof(string));
            //ViewState["table"] = dt;

            //var qu = from row in db.PowerSegregationChilds where row.TumblingNo == txtTumblingNo.Text select row;

            //foreach (var val in qu)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr[0] = val.Power;
            //    dr[1] = val.Qty;
            //    dr[2] = val.GlassyRecordRef;
            //    dt.Rows.Add(dr);
            //}
            //ViewState["table"] = dt;
            //gvPowerSegregation.DataSource = dt;
            //gvPowerSegregation.DataBind();
        }
        else
        {
            var qury = from x in db.NewBtchAllots where x.LotNo == txtTumblingNo.Text select x;
            if (qury.Count() > 0)
            {
                txtRecievedQty.Text = qury.Single().Quantity.ToString();
                txtTumblingrefno.Text = qury.Single().LotNo;
                btnSave.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                Messagebox("Previous Process Might Not Be Completed");
            }
        }
        //var query2 = from row in db.PowerSegregationTables where row.RetumblingNo1 == txtTumblingNo.Text select row;
        //var query3 = from row in db.PowerSegregationTables where row.RetumblingNo2 == txtTumblingNo.Text select row;
        //var query4 = from row in db.PowerSegregationTables where row.RetumblingNo3 == txtTumblingNo.Text select row;

        ////var q = (from r in db.MattTumblingLens where r.TumblingLotNo == txtTumblingNo.Text select r);
        //var q = (from r in db.FinalLensPreparations where r.TumblingNo == txtTumblingNo.Text && r.Status == 2 select r);
        //var q1 = (from r in db.RemattTumblingLens where r.RetumblingRef1 == txtTumblingNo.Text select r);
        //var q2 = (from r in db.RemattTumblingLens where r.RetumblingRef2 == txtTumblingNo.Text select r);
        //var q3 = (from r in db.RemattTumblingLens where r.RetumblingRef3 == txtTumblingNo.Text select r);
        //if (q.Count() > 0)
        //{
        //    if (q1.Count() > 0)
        //    {
        //        try
        //        {
        //            txtRecievedQty.Text = q.Single().TotalQty.ToString();
        //            btnSave.Visible = true;
        //            txtAcceptedQty.Text = "";
        //            txtInspectedBy.Text = "";
        //            //txtObservedPower.Text = "";
        //            //txtQty.Text = "";
        //            txtRejectedQty.Text = "";
        //            txtTumblingrefno.Text = q.Single().TumblingNo.ToString();
        //            txtRemarks.Text = "";
        //            btnUpdate.Visible = false;
        //            //btnSave.Enabled = true;
        //            chkGoodReason.Checked = true;
        //            chkBadReason.Checked = false;
        //            //try
        //            //{
        //            //    DataTableBind();
        //            //    DataTable dt = (DataTable)ViewState["table"];
        //            //    dt.Clear();
        //            //    gvPowerSegregation.DataSource = dt;
        //            //    gvPowerSegregation.DataBind();
        //            //}
        //            //catch
        //            //{
        //            //}

        //        }
        //        catch
        //        {
        //            Messagebox("Enter a valid Lot No");
        //            txtTumblingNo.Text = "";
        //            txtTumblingNo.Focus();
        //        }

        //    }

        //    else if (q2.Count() > 0)
        //    {
        //        try
        //        {
        //            txtRecievedQty.Text = q2.Single().AcceptedQty2.ToString();
        //            btnSave.Visible = true;
        //            txtAcceptedQty.Text = "";
        //            txtInspectedBy.Text = "";
        //            //txtObservedPower.Text = "";
        //            //txtQty.Text = "";
        //            txtRejectedQty.Text = "";
        //            txtTumblingrefno.Text = q2.Single().TumblingLotNo.ToString();
        //            txtRemarks.Text = "";
        //            btnUpdate.Visible = false;
        //            //btnSave.Enabled = false;
        //            chkGoodReason.Checked = true;
        //            chkBadReason.Checked = false;
        //            //try
        //            //{
        //            //    DataTableBind();
        //            //    DataTable dt = (DataTable)ViewState["table"];
        //            //    dt.Clear();
        //            //    gvPowerSegregation.DataSource = dt;
        //            //    gvPowerSegregation.DataBind();
        //            //}
        //            //catch { }

        //        }
        //        catch
        //        {
        //            Messagebox("Enter a valid Tumbling No");
        //            txtTumblingNo.Text = "";
        //            txtTumblingNo.Focus();

        //        }

        //    }
        //    else if (q3.Count() > 0)
        //    {
        //        try
        //        {
        //            txtRecievedQty.Text = q3.Single().AcceptedQty3.ToString();
        //            btnSave.Visible = true;
        //            txtAcceptedQty.Text = "";
        //            txtInspectedBy.Text = "";
        //            //txtObservedPower.Text = "";
        //            //txtQty.Text = "";
        //            txtRejectedQty.Text = "";
        //            txtTumblingrefno.Text = q3.Single().TumblingLotNo.ToString();
        //            txtRemarks.Text = "";
        //            btnUpdate.Visible = false;
        //            //btnSave.Enabled = false;
        //            chkGoodReason.Checked = true;
        //            chkBadReason.Checked = false;
        //            //try
        //            //{
        //            //    DataTableBind();
        //            //    DataTable dt = (DataTable)ViewState["table"];
        //            //    dt.Clear();
        //            //    gvPowerSegregation.DataSource = dt;
        //            //    gvPowerSegregation.DataBind();

        //            //}
        //            //catch { }

        //        }
        //        catch
        //        {
        //            Messagebox("Enter a valid Tumbling No");
        //            txtTumblingNo.Text = "";
        //            txtTumblingNo.Focus();

        //        }
        //    }
        //    else
        //    {

        //    }
        //}
        //else
        //{
        //    Messagebox("Before Process Might not be Completed");
        //}


    
        //else if (query2.Count() > 0)
        //{
        //    txtAcceptedQty.Text = query2.Single().AcceptedQty1.ToString();
        //    DateTime tdate = query2.Single().Date1.Value;
        //    txtDate.Text = tdate.ToString("dd/MM/yyyy");
        //    txtInspectedBy.Text = query2.Single().InspectedBy1.ToString();
        //    txtRecievedQty.Text = query2.Single().ReceivedQty1.ToString();
        //    txtRejectedQty.Text = query2.Single().RejectedQty1.ToString();
        //    txtRemarks.Text = query2.Single().Remarks1.ToString();
        //    //txtTotalQty.Text = query2.Single().TotalQty1.ToString();
        //    string res = query2.Single().Resolution1.ToString();

        //    if (res == "Good")
        //    {
        //        chkGoodReason.Checked = true;
        //        chkBadReason.Checked = false;
        //    }
        //    else
        //    {
        //        chkGoodReason.Checked = false;
        //        chkBadReason.Checked = true;
        //    }
        //    btnSave.Visible = false;
        //    btnUpdate.Visible = false;
        //    //txtTotalQty.Visible = true;
        //    //lbTotalQuantity.Visible = true;

        //    //DataTable dt = new DataTable();
        //    //dt.Columns.Add("ObservedPower", typeof(decimal));
        //    //dt.Columns.Add("Qty", typeof(int));
        //    //dt.Columns.Add("GlassyRef", typeof(string));
        //    //ViewState["table"] = dt;

        //    //var qu1 = from row in db.PowerSegregationChilds where row.TumblingNo == txtTumblingNo.Text select row;

        //    //foreach (var val in qu1)
        //    //{
        //    //    DataRow dr = dt.NewRow();
        //    //    dr[0] = val.Power;
        //    //    dr[1] = val.Qty;
        //    //    dr[2] = val.GlassyRecordRef;
        //    //    dt.Rows.Add(dr);
        //    //}
        //    //ViewState["table"] = dt;
        //    //gvPowerSegregation.DataSource = dt;
        //    //gvPowerSegregation.DataBind();
        //}
        //else if (query3.Count() > 0)
        //{
        //    txtAcceptedQty.Text = query3.Single().AcceptedQty2.ToString();
        //    DateTime tdate = query3.Single().Date2.Value;
        //    txtDate.Text = tdate.ToString("dd/MM/yyyy");
        //    txtInspectedBy.Text = query3.Single().InspectedBy2.ToString();
        //    txtRecievedQty.Text = query3.Single().ReceivedQty2.ToString();
        //    txtRejectedQty.Text = query3.Single().RejectedQty2.ToString();
        //    txtRemarks.Text = query3.Single().Remarks2.ToString();
        //    //txtTotalQty.Text = query3.Single().TotalQty2.ToString();
        //    string res = query3.Single().Resolution2.ToString();

        //    if (res == "Good")
        //    {
        //        chkGoodReason.Checked = true;
        //        chkBadReason.Checked = false;
        //    }
        //    else
        //    {
        //        chkGoodReason.Checked = false;
        //        chkBadReason.Checked = true;
        //    }
        //    btnSave.Visible = false;
        //    btnUpdate.Visible = false;
        //    //txtTotalQty.Visible = true;
        //    //lbTotalQuantity.Visible = true;

        //    //DataTable dt = new DataTable();
        //    //dt.Columns.Add("ObservedPower", typeof(decimal));
        //    //dt.Columns.Add("Qty", typeof(int));
        //    //dt.Columns.Add("GlassyRef", typeof(string));
        //    //ViewState["table"] = dt;

        //    //var qu2 = from row in db.PowerSegregationChilds where row.TumblingNo == txtTumblingNo.Text select row;

        //    //foreach (var val in qu2)
        //    //{
        //    //    DataRow dr = dt.NewRow();
        //    //    dr[0] = val.Power;
        //    //    dr[1] = val.Qty;
        //    //    dr[2] = val.GlassyRecordRef;
        //    //    dt.Rows.Add(dr);
        //    //}
        //    //ViewState["table"] = dt;
        //    //gvPowerSegregation.DataSource = dt;
        //    //gvPowerSegregation.DataBind();
        //}
        //else if (query4.Count() > 0)
        //{
        //    txtAcceptedQty.Text = query4.Single().AcceptedQty3.ToString();
        //    DateTime tdate = query4.Single().Date1.Value;
        //    txtDate.Text = tdate.ToString("dd/MM/yyyy");
        //    txtInspectedBy.Text = query4.Single().InspectedBy3.ToString();
        //    txtRecievedQty.Text = query4.Single().ReceivedQty3.ToString();
        //    txtRejectedQty.Text = query4.Single().RejectedQty3.ToString();
        //    txtRemarks.Text = query4.Single().Remarks3.ToString();
        //    //txtTotalQty.Text = query4.Single().TotalQty3.ToString();
        //    string res = query4.Single().Resolution3.ToString();

        //    if (res == "Good")
        //    {
        //        chkGoodReason.Checked = true;
        //        chkBadReason.Checked = false;
        //    }
        //    else
        //    {
        //        chkGoodReason.Checked = false;
        //        chkBadReason.Checked = true;
        //    }
        //    btnSave.Visible = false;
        //    btnUpdate.Visible = false;
        //    //txtTotalQty.Visible = true;
        //    //lbTotalQuantity.Visible = true;

        //    //DataTable dt = new DataTable();
        //    //dt.Columns.Add("ObservedPower", typeof(decimal));
        //    //dt.Columns.Add("Qty", typeof(int));
        //    //dt.Columns.Add("GlassyRef", typeof(string));
        //    //ViewState["table"] = dt;

        //    //var qu3 = from row in db.PowerSegregationChilds where row.TumblingNo == txtTumblingNo.Text select row;

        //    //foreach (var val in qu3)
        //    //{
        //    //    DataRow dr = dt.NewRow();
        //    //    dr[0] = val.Power;
        //    //    dr[1] = val.Qty;
        //    //    dr[2] = val.GlassyRecordRef;
        //    //    dt.Rows.Add(dr);
        //    //}
        //    //ViewState["table"] = dt;
        //    //gvPowerSegregation.DataSource = dt;
        //    //gvPowerSegregation.DataBind();
        //}
        //else
        //{
        //    if (q.Count() > 0)
        //    {
        //        try
        //        {

        //            txtRecievedQty.Text = q.Single().TotalQty.ToString();
        //            btnSave.Visible = true;
        //            txtAcceptedQty.Text = "";
        //            txtInspectedBy.Text = "";
        //            //txtObservedPower.Text = "";
        //            //txtQty.Text = "";
        //            txtRejectedQty.Text = "";
        //            //txtTumblingrefno.Text = "";
        //            txtRemarks.Text = "";
        //            btnUpdate.Visible = false;
        //            //btnSave.Enabled = false;
        //            chkGoodReason.Checked = true;
        //            chkBadReason.Checked = false;

        //            //try
        //            //{
        //            //    DataTableBind();
        //            //    DataTable dt = (DataTable)ViewState["table"];
        //            //    dt.Clear();
        //            //    gvPowerSegregation.DataSource = dt;
        //            //    gvPowerSegregation.DataBind();
        //            //}
        //            //catch
        //            //{
        //            //}

        //        }
        //        catch
        //        {
        //            Messagebox("Enter a valid Tumbling No");
        //            txtTumblingNo.Text = "";
        //            txtTumblingNo.Focus();
        //        }
        //    }

            //else if (query2.Count() == 0)
            //{
            //    txtRecievedQty.Text = query2.Single().AcceptedQty.ToString();
            //    btnSave.Visible = true;
            //    txtAcceptedQty.Text = "";
            //    txtInspectedBy.Text = "";
            //    txtObservedPower.Text = "";
            //    txtQty.Text = "";
            //    txtRejectedQty.Text = "";
            //    txtRejMtsNo.Text = "";
            //    txtRemarks.Text = "";
            //    btnUpdate.Visible = false;
            //    btnSave.Enabled = false;
            //    chkGoodReason.Checked = true;
            //    chkBadReason.Checked = false;

            //    try
            //    {
            //        DataTableBind();
            //        DataTable dt = (DataTable)ViewState["table"];
            //        dt.Clear();
            //        gvPowerSegregation.DataSource = dt;
            //        gvPowerSegregation.DataBind();
            //    }
            //    catch
            //    {
            //    }


            //}

       // }
    }


    protected void chkGoodReason_CheckedChanged(object sender, EventArgs e)
    {
        if (chkGoodReason.Checked)
        {
            chkBadReason.Checked = false;
        }
    }
    protected void chkBadReason_CheckedChanged(object sender, EventArgs e)
    {
        if (chkBadReason.Checked)
        {
            chkGoodReason.Checked = false;
        }
    }
    protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAcceptedQty.Text) > Convert.ToInt32(txtRecievedQty.Text))
        {
            Messagebox("Accepted Qty is Greater than Recieved Qty");
            txtAcceptedQty.Text = "";
            txtAcceptedQty.Focus();
            txtRejectedQty.Text = "";
        }
        else
        {
            txtRejectedQty.Text = Convert.ToString(Convert.ToInt32(txtRecievedQty.Text) - Convert.ToInt32(txtAcceptedQty.Text));
        }
    }

    //protected void gvPowerSegregation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvPowerSegregation.EditIndex = -1;
    //    DataTable dt = (DataTable)ViewState["table"];
    //    gvPowerSegregation.DataSource = dt;
    //    gvPowerSegregation.DataBind();
    //}


    protected void btnSave_Click1(object sender, ImageClickEventArgs e)
    {
        try
        {
        if (txtTumblingNo.Text == "")
        {
            Messagebox("Please enter TumblingNo");
            txtTumblingNo.Focus();
        }
        else if (txtAcceptedQty.Text == "")
        {
            Messagebox("Please enter Accepted Qty");
            txtAcceptedQty.Focus();
        }
        else if (txtInspectedBy.Text == "")
        {
            Messagebox("Please enter InspectedBy");
            txtInspectedBy.Focus();
        }
        
        else
        {
            DataTable dt = (DataTable)ViewState["table"];


            string res = "";
            if (chkGoodReason.Checked)
            {
                res = "Good";
            }
            else
            {
                res = "Bad";
            }

            
            var Q = (from row in db.Lensometer_PowerChecks where row.TumblingNo == txtTumblingrefno.Text select row);
            var Q1 = (from row in db.Lensometer_PowerChecks where row.RetumblingNo1 == txtTumblingrefno.Text select row);

            if (Q.Count() > 0)
            {
                int Flag = Convert.ToInt32(Q.Single().Flag.ToString());
                if (Flag == 0)
                {
                    Lensometer_PowerCheck powtable = new Lensometer_PowerCheck();
                    powtable.AcceptedQty1 = Convert.ToInt32(txtAcceptedQty.Text);
                    powtable.Date1 = Convert.ToDateTime(txtDate.Text, provider);
                    powtable.InspectedBy1 = txtInspectedBy.Text;
                    powtable.ReceivedQty1 = Convert.ToInt32(txtRecievedQty.Text);
                    powtable.RejectedQty1 = Convert.ToInt32(txtRejectedQty.Text);
                    powtable.Remarks1 = txtRemarks.Text;
                    powtable.Resolution1 = res;
                    powtable.RetumblingNo1 = txtTumblingNo.Text;
                    powtable.TotalQty1 = Convert.ToInt32(txtAcceptedQty.Text);
                    powtable.Flag = flag + 1;
                    db.Lensometer_PowerChecks.InsertOnSubmit(powtable);
                    db.SubmitChanges();
                    GridBind();
                }
            }
            else if (Q1.Count() > 0)
            {
                int Flag1 = Convert.ToInt32(Q1.Single().Flag.ToString());
                if (Flag1 == 1)
                {
                    Lensometer_PowerCheck powtable = new Lensometer_PowerCheck();
                    powtable.AcceptedQty2 = Convert.ToInt32(txtAcceptedQty.Text);
                    powtable.Date2 = Convert.ToDateTime(txtDate.Text, provider);
                    powtable.InspectedBy2 = txtInspectedBy.Text;
                    powtable.ReceivedQty2 = Convert.ToInt32(txtRecievedQty.Text);
                    powtable.RejectedQty2 = Convert.ToInt32(txtRejectedQty.Text);
                    powtable.Remarks2 = txtRemarks.Text;
                    powtable.Resolution2 = res;
                    powtable.RetumblingNo2 = txtTumblingNo.Text;
                    powtable.TotalQty2 = Convert.ToInt32(txtAcceptedQty.Text);
                    powtable.Flag = Flag1 + 1;
                    db.Lensometer_PowerChecks.InsertOnSubmit(powtable);
                    db.SubmitChanges();
                    GridBind();
                }
            }
            else if (Q.Count() == 0)
            {
                Lensometer_PowerCheck powtable = new Lensometer_PowerCheck();
                powtable.AcceptedQty = Convert.ToInt32(txtAcceptedQty.Text);
                powtable.Date = Convert.ToDateTime(txtDate.Text, provider);
                powtable.InspectedBy = txtInspectedBy.Text;
                powtable.RecievedQty = Convert.ToInt32(txtRecievedQty.Text);
                powtable.RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
                powtable.Remarks = txtRemarks.Text;
                powtable.Resolution = res;
                powtable.TumblingNo = txtTumblingNo.Text;
                powtable.TotalQty = Convert.ToInt32(txtAcceptedQty.Text);
                powtable.Flag = flag;
                db.Lensometer_PowerChecks.InsertOnSubmit(powtable);
                db.SubmitChanges();
                GridBind();
            }
            
            #region method1

       
            #endregion

           
            btnSave.Enabled = false;
            
            Messagebox("Record Saved");
            clear();
            txtTumblingNo.Text = "";
        }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
    }



    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        string res = "";
        if (chkGoodReason.Checked)
        {
            res = "Good";
        }
        else
        {
            res = "Bad";
        }
        DataTable dt = (DataTable)ViewState["table"];


        //SqlCommand cmd = new SqlCommand();
        //  SqlDataAdapter da = new SqlDataAdapter("Select * from milling where Date='" + txtDate.Text + "' and Shift='" + ddlShift.Text + "'"  , con);

        //if (Convert.ToInt32(txtTotalQty.Text) > Convert.ToInt32(txtAcceptedQty.Text))
        //{
        //    Messagebox("Total Qty Not Matching With Accepted qty");
        //}
        //else
        //{
        var query = from row in db.Lensometer_PowerChecks where row.TumblingNo == txtTumblingNo.Text select row;

        query.Single().AcceptedQty = Convert.ToInt32(txtAcceptedQty.Text);
        query.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
        query.Single().InspectedBy = txtInspectedBy.Text;
        query.Single().RecievedQty = Convert.ToInt32(txtRecievedQty.Text);
        query.Single().RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
        //query.Single().TumblingRef1 = txtRejMtsNo.Text;
        query.Single().Remarks = txtRemarks.Text;
        query.Single().Resolution = res;
        query.Single().TumblingNo = txtTumblingNo.Text;


        query.Single().TotalQty = Convert.ToInt32(txtAcceptedQty.Text);
        db.SubmitChanges();

        //Child Update
        //var query2 = from row in db.PowerSegregationChilds where row.TumblingNo == txtTumblingNo.Text select row;
        //db.PowerSegregationChilds.DeleteAllOnSubmit(query2);
        //db.SubmitChanges();

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    PowerSegregationChild powchild = new PowerSegregationChild()
        //    {
        //        TumblingNo = txtTumblingNo.Text,
        //        Power = Convert.ToDecimal(dt.Rows[i][0].ToString()),
        //        Qty = Convert.ToInt32(dt.Rows[i][1].ToString()),
        //        GlassyRecordRef = dt.Rows[i][2].ToString()
        //    };
        //    db.PowerSegregationChilds.InsertOnSubmit(powchild);
        //    db.SubmitChanges();
        //}

        ////Production plan report
        //var query7 = from r in db.ReportTables where r.LotNo == txtTumblingNo.Text && r.Type == 5 select r;
        //db.ReportTables.DeleteAllOnSubmit(query7);
        //db.SubmitChanges();
        //var q = from row in db.Tumblings where row.TumblingLotNo == txtTumblingNo.Text select row;

        //for (int j = 0; j < dt.Rows.Count; j++)
        //{
        //    ReportTable rt = new ReportTable()
        //    {
        //        Model = q.Single().ModelNo,
        //        Power = Convert.ToDecimal(dt.Rows[j][0].ToString()),
        //        LotNo = txtTumblingNo.Text,
        //        WiatingPouchPacking = Convert.ToInt32(dt.Rows[j][1].ToString()),
        //        Hydration = 0,
        //        RuningTumbling = 0,
        //        WaitingPowerSegregation = 0,
        //        WaitingTumbling = 0,
        //        Type = 5,
        //        Status = 2

        //    };
        //    db.ReportTables.InsertOnSubmit(rt);
        //    db.SubmitChanges();
        //}


        btnUpdate.Enabled = true;
        //dt.Clear();
        //gvPowerSegregation.DataSource = dt;
        //gvPowerSegregation.DataBind();
        Messagebox("Record Updated");
        clear();
        txtTumblingNo.Text = "";
        //}
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtTumblingNo.Text = "";
        btnClear.Visible = false;
        btnSave.Visible = false;
        //btnUpdate.Visible = false;
    }
    //protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    //{
    //    var query3 = from row in db.PowerSegregationChilds where row.GlassyRecordRef == txtGrfNo.Text select row;
    //    if (query3.Count() > 0)
    //    {
    //        Messagebox("Glassy Tumbling Ref No Already Exists");
    //    }
    //    else
    //    {
    //        try
    //        {
    //            DataTable dt = (DataTable)ViewState["table"];
    //            int qtyval = 0; ;
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                int qty = Convert.ToInt32(dt.Rows[i][1].ToString());
    //                qtyval = qtyval + qty;
    //            }
    //            if (Convert.ToInt32(txtQty.Text) + qtyval > Convert.ToInt32(txtAcceptedQty.Text))
    //            {
    //                Messagebox("Qty does not match");
    //            }
    //            else
    //            {
    //                int fl = 0;
    //                for (int i = 0; i < dt.Rows.Count; i++)
    //                {

    //                    if (Convert.ToDecimal(dt.Rows[i][0].ToString()) == Convert.ToDecimal(txtObservedPower.Text))
    //                    {
    //                        dt.Rows[i][1] = Convert.ToInt32(txtQty.Text) + Convert.ToDecimal(dt.Rows[i][1].ToString());
    //                        dt.Rows[i][2] = txtGrfNo.Text.ToString();
    //                        gvPowerSegregation.DataSource = dt;
    //                        gvPowerSegregation.DataBind();
    //                        ViewState["table"] = dt;
    //                        txtObservedPower.Text = "";
    //                        txtQty.Text = "";
    //                        txtGrfNo.Text = "";
    //                        btnSave.Enabled = true;
    //                        btnUpdate.Enabled = true;
    //                        TotalQtyCal();
    //                        txtTotalQty.Visible = true;
    //                        lbTotalQuantity.Visible = true;
    //                        fl = 1;
    //                    }
    //                }
    //                if (fl == 0)
    //                {

    //                    DataRow dr = dt.NewRow();
    //                    dr[0] = Convert.ToDecimal(txtObservedPower.Text);
    //                    dr[1] = Convert.ToInt32(txtQty.Text);
    //                    dr[2] = txtGrfNo.Text;
    //                    dt.Rows.Add(dr);
    //                    ReportBind();
    //                    gvPowerSegregation.DataSource = dt;
    //                    gvPowerSegregation.DataBind();
    //                    ViewState["table"] = dt;
    //                    txtObservedPower.Text = "";
    //                    txtQty.Text = "";
    //                    txtGrfNo.Text = "";
    //                    btnSave.Enabled = true;
    //                    btnUpdate.Enabled = true;
    //                    TotalQtyCal();
    //                    txtTotalQty.Visible = true;
    //                    lbTotalQuantity.Visible = true;
    //                }
    //                if (dt.Rows.Count == 0)
    //                {
    //                    DataRow dr = dt.NewRow();

    //                    dr[0] = Convert.ToDecimal(txtObservedPower.Text);
    //                    dr[1] = Convert.ToInt32(txtQty.Text);
    //                    dr[2] = txtGrfNo.Text;
    //                    dt.Rows.Add(dr);
    //                    gvPowerSegregation.DataSource = dt;
    //                    gvPowerSegregation.DataBind();
    //                    ViewState["table"] = dt;
    //                    txtObservedPower.Text = "";
    //                    txtQty.Text = "";
    //                    txtGrfNo.Text = "";
    //                    btnSave.Enabled = true;
    //                    btnUpdate.Enabled = true;
    //                    TotalQtyCal();
    //                    txtTotalQty.Visible = true;
    //                    lbTotalQuantity.Visible = true;
    //                }
    //            }
    //        }
    //        catch
    //        {
    //        }
    //    }
    //}
    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
        txtInspectedBy.Focus();
    }
    protected void txtInspectedBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtInspectedBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtInspectedBy.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: M.BALAJI");
                txtInspectedBy.Text = "";
                txtInspectedBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtInspectedBy.Text = "";
            txtInspectedBy.Focus();
        }
    }
    protected void GridBind()
    {
        var qury = from x in db.Lensometer_PowerChecks where x.TumblingNo == txtTumblingNo.Text select x;
        Gridview1.DataSource = qury;
        Gridview1.DataBind();
    }
}