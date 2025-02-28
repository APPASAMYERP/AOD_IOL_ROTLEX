using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Timers;
using AjaxControlToolkit;


public partial class Lens_for_Tumbling : System.Web.UI.Page
{
    #region Declaration
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    int temp1;
    #endregion

    #region Method

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void GridBind()
    {

        var q = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
        gvLensPrepare.DataSource = q;
        gvLensPrepare.DataBind();
        btnSave.Visible = true;
        btnClear.Visible = true;
    }

    private void Clear()
    {
        gvLensPrepare.DataSource = null;
        gvLensPrepare.DataBind();
        txttotalQty.Text = "";
        totalQty.Visible = false;
        txttotalQty.Visible = false;
        Startdatetime.Visible = false;
        Enddatetime.Visible = false;
        btnUpdate.Visible = false;
        txtSatrtDate.Text = "";
        txtEndDate.Text = "";
        txtStartTime.Text = "";
        txtEndTime.Text = "";
    }

    private bool ValidateSave()
    {
        bool _isvalid = true;
        if (txtSatrtDate.Text == "")
        {
            Messagebox("Please enter StartDate");
            txtSatrtDate.Focus();
            _isvalid = false;
        }
        else if (txtStartTime.Text == "")
        {
            Messagebox("Please enter StartTime");
            txtStartTime.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }

    private bool ValidateUpdate()
    {
        bool _isvalid = true;
        if (txtEndDate.Text == "")
        {
            Messagebox("Please enter Enddate");
            txtEndDate.Focus();
            _isvalid = false;
        }
        else if (txtEndTime.Text == "")
        {
            Messagebox("Please enter EndTime");
            txtEndTime.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }


    private void Report()
    {
        IQueryable<Report_Table> Q = from row in db.Report_Tables where row.TumblingNo == txttumblingNo.Text && row.Status == 0 select row;
        int c = Q.Count();
        Report_Table[] report = Q.ToArray();
        if (Q.Count() > 0)
        {
            for (int i = 0; i < c; i++)
            {
                Report_Table rt = new Report_Table();
                int qty = Convert.ToInt32(report[i].WaitingTumbling);
                report[i].WaitingTumbling = 0;
                report[i].RunningTumbling = qty;
                report[i].Status = 1;
                db.SubmitChanges();
            }
        }
        else
        {
            IQueryable<Report_Table> Qu = from row in db.Report_Tables where row.RetumblingNo == txttumblingNo.Text && row.Status == 0 select row;
            int c1 = Qu.Count();
            Report_Table[] report1 = Qu.ToArray();
            if (Qu.Count() > 0)
            {
                for (int i = 0; i < c1; i++)
                {
                    Report_Table rt = new Report_Table();
                    int qty = Convert.ToInt32(report1[i].WaitingTumbling);
                    report1[i].WaitingTumbling = 0;
                    report1[i].RunningTumbling = qty;
                    report1[i].Status = 1;
                    db.SubmitChanges();
                }
            }
        }

    }

    private void ReportUpdate()
    {
        IQueryable<Report_Table> Q1 = from row in db.Report_Tables where row.TumblingNo == txttumblingNo.Text && row.Status == 1 select row;
        int c1 = Q1.Count();
        Report_Table[] report1 = Q1.ToArray();
        if (Q1.Count() > 0)
        {
            for (int i = 0; i < c1; i++)
            {
                Report_Table rt = new Report_Table();
                int qty = Convert.ToInt32(report1[i].RunningTumbling);
                report1[i].RunningTumbling = 0;
                report1[i].WaitingPowerSegregation = qty;
                report1[i].Status = 2;
                db.SubmitChanges();
            }
        }
        else
        {
            IQueryable<Report_Table> Q2 = from row in db.Report_Tables where row.RetumblingNo == txttumblingNo.Text && row.Status == 1 select row;
            int c2 = Q2.Count();
            Report_Table[] report2 = Q2.ToArray();
            if (Q2.Count() > 0)
            {
                for (int i = 0; i < c2; i++)
                {
                    Report_Table rt = new Report_Table();
                    int qty = Convert.ToInt32(report2[i].RunningTumbling);
                    report2[i].RunningTumbling = 0;
                    report2[i].WaitingPowerSegregation = qty;
                    report2[i].Status = 2;
                    db.SubmitChanges();
                }
            }
        }
    }

    private void ReportBind()
    {
        //int tottemp = 0;  

        var Q1 = from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row;
        var Q = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
        if (Q1.Count() > 0)
        {
            //foreach (var q in Q)
            //{
            //     tottemp = tottemp + Convert.ToInt32(q);
            //}
            DataTable dt = (DataTable)ViewState["table"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Report_Table rt = new Report_Table();
                //var Query = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
                //var Qu = from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row;
                //if (Qu.Count() > 0)
                //{
                rt.Model = dt.Rows[i][2].ToString();
                rt.Power = Convert.ToDecimal(dt.Rows[i][3].ToString());
                rt.TumblingNo = dt.Rows[i][0].ToString();
                rt.PhobicId = dt.Rows[i][5].ToString();
                rt.WaitingTumbling = Convert.ToInt32(dt.Rows[i][4].ToString());
                rt.RunningTumbling = 0;
                rt.WaitingPowerSegregation = 0;
                rt.WaitingPouchPacking = 0;
                rt.Status = 0;
                db.Report_Tables.InsertOnSubmit(rt);
                db.SubmitChanges();

            }
        }
        else
        {
            var re = from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row;
            var q = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
            if (re.Count() > 0)
            {
                DataTable dt = (DataTable)ViewState["table"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Report_Table rt = new Report_Table();
                    rt.Model = dt.Rows[i][2].ToString();
                    rt.Power = Convert.ToDecimal(dt.Rows[i][3].ToString());
                    rt.RetumblingNo = dt.Rows[i][0].ToString();
                    rt.PhobicId = dt.Rows[i][5].ToString();
                    rt.WaitingTumbling = Convert.ToInt32(dt.Rows[i][4].ToString());
                    rt.RunningTumbling = 0;
                    rt.WaitingPowerSegregation = 0;
                    rt.WaitingPouchPacking = 0;
                    rt.Status = 0;
                    db.Report_Tables.InsertOnSubmit(rt);
                    db.SubmitChanges();
                }
            }
            else
            {
                var re1 = from row in db.RemattTumblingLens where row.RetumblingRef2 == txttumblingNo.Text select row;
                var q1 = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
                if (re1.Count() > 0)
                {
                    DataTable dt = (DataTable)ViewState["table"];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Report_Table rt = new Report_Table();
                        rt.Model = dt.Rows[i][2].ToString();
                        rt.Power = Convert.ToDecimal(dt.Rows[i][3].ToString());
                        rt.RetumblingNo = dt.Rows[i][0].ToString();
                        rt.PhobicId = dt.Rows[i][5].ToString();
                        rt.WaitingTumbling = Convert.ToInt32(dt.Rows[i][4].ToString());
                        rt.RunningTumbling = 0;
                        rt.WaitingPowerSegregation = 0;
                        rt.WaitingPouchPacking = 0;
                        rt.Status = 0;
                        db.Report_Tables.InsertOnSubmit(rt);
                        db.SubmitChanges();
                    }
                }
                else
                {
                    var re2 = from row in db.RemattTumblingLens where row.RetumblingRef3 == txttumblingNo.Text select row;
                    var q2 = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
                    if (re2.Count() > 0)
                    {
                        DataTable dt = (DataTable)ViewState["table"];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Report_Table rt = new Report_Table();
                            rt.Model = dt.Rows[i][2].ToString();
                            rt.Power = Convert.ToDecimal(dt.Rows[i][3].ToString());
                            rt.RetumblingNo = dt.Rows[i][0].ToString();
                            rt.PhobicId = dt.Rows[i][5].ToString();
                            rt.WaitingTumbling = Convert.ToInt32(dt.Rows[i][4].ToString());
                            rt.RunningTumbling = 0;
                            rt.WaitingPowerSegregation = 0;
                            rt.WaitingPouchPacking = 0;
                            rt.Status = 0;
                            db.Report_Tables.InsertOnSubmit(rt);
                            db.SubmitChanges();
                        }
                    }
                }
            }
        }




        //Report_Table rt=new Report_Table();
        //     var Qu1 = from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row;
        //     if (Qu1.Count() > 0)
        //     {
        //         rt.Model = Qu1.Single().Model1;
        //         rt.Power = Qu1.Single().Power1;
        //         rt.TumblingNo = Qu1.Single().TumblingLotNo;
        //         rt.RetumblingNo = Qu1.Single().RetumblingRef1;
        //         rt.PhobicId = Qu1.Single().PhobicId;
        //         rt.WaitingTumbling = tottemp;
        //         rt.RunningTumbling = 0;
        //         rt.WaitingPowerSegregation = 0;
        //         rt.WaitingPouchPacking = 0;
        //         rt.Status = 0;
        //         db.Report_Tables.InsertOnSubmit(rt);
        //         db.SubmitChanges();
        //     }

        //     else
        //     {
        //         var Qu2 = from row in db.RemattTumblingLens where row.RetumblingRef2 == txttumblingNo.Text select row;
        //         if (Qu2.Count() > 0)
        //         {
        //             rt.Model = Qu2.Single().Model1;
        //             rt.Power = Qu2.Single().Power1;
        //             rt.TumblingNo = Qu2.Single().TumblingLotNo;
        //             rt.RetumblingNo = Qu2.Single().RetumblingRef2;
        //             rt.PhobicId = Qu1.Single().PhobicId;
        //             rt.WaitingTumbling = tottemp;
        //             rt.RunningTumbling = 0;
        //             rt.WaitingPowerSegregation = 0;
        //             rt.WaitingPouchPacking = 0;
        //             rt.Status = 0;
        //             db.Report_Tables.InsertOnSubmit(rt);
        //             db.SubmitChanges();

        //         }
        //     }

        // }
    }


    #endregion

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtSatrtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            totalQty.Visible = false;
            txttotalQty.Visible = false;
            Startdatetime.Visible = false;
            Enddatetime.Visible = false;
        }

    }

    protected void txttumblingNo_TextChanged(object sender, EventArgs e)
    {
        string t = txttumblingNo.Text;
        txttumblingNo.Text = t.ToUpper();

        var q1 = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
        if (q1.Count() > 0)
        {
            gvLensPrepare.DataSource = q1;
            gvLensPrepare.DataBind();
            btnSave.Visible = false;
            btnClear.Visible = true;
            var q2 = from row in db.FinalLensPreparations where row.TumblingNo == txttumblingNo.Text select row;
            if (q2.Count() > 0)
            {
                txttotalQty.Text = (q2.Single().TotalQty).ToString();
                totalQty.Visible = true;
                txttotalQty.Visible = true;
                Startdatetime.Visible = true;
                DateTime Start = q2.Single().StartDate.Value;
                txtSatrtDate.Text = Start.ToString("dd/MM/yyyy");
                string StartTim = (q2.Single().StartTime).ToString();
                string[] StartTime = StartTim.Split(':');
                txtStartTime.Text = StartTime[0] + ":" + StartTime[1];
                ddlStartDay.Text = StartTime[2];
                var Q3 = from row in db.FinalLensPreparations where row.TumblingNo == txttumblingNo.Text select row;
                int StatusVal = Convert.ToInt32(Q3.Single().Status);
                if (StatusVal == 1)
                {
                    Enddatetime.Visible = true;
                    btnUpdate.Visible = true;
                }
                else
                {
                    var Q4 = from row in db.FinalLensPreparations where row.TumblingNo == txttumblingNo.Text select row;
                    if (Q4.Single().Status == 2)
                    {
                        Enddatetime.Visible = true;
                        DateTime End = Q4.Single().EndDate.Value;
                        txtEndDate.Text = End.ToString("dd/MM/yyyy");
                        string EndTim = (Q4.Single().EndTime).ToString();
                        string[] EndTime = EndTim.Split(':');
                        txtEndTime.Text = EndTime[0] + ":" + EndTime[1];
                        ddlEndday.Text = EndTime[2];
                        btnUpdate.Visible = false;
                    }

                }
            }
            else
            {
                Startdatetime.Visible = true;
                btnSave.Visible = true;
                btnClear.Visible = true;
            }
        }

        else
        {
            var query = from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row;
            if (query.Count() > 0)
            {
                btngenerate.Visible = true;
                DataTable dt = new DataTable();
                dt.Columns.Add("TumblingRefNo", typeof(string));
                dt.Columns.Add("LotNo", typeof(string));
                dt.Columns.Add("Model", typeof(string));
                dt.Columns.Add("Power", typeof(decimal));
                dt.Columns.Add("Qty", typeof(int));
                dt.Columns.Add("PhobicId", typeof(string));
                //dt.Columns.Add("Date", typeof(DateTime));
                ViewState["table"] = dt;

                foreach (var q in query)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = q.TumblingLotNo;
                    dr[1] = q.LensCutLot;
                    dr[2] = q.ModelNo;
                    dr[3] = q.Power;
                    dr[4] = q.TotalQuantity;
                    dr[5] = q.PhobicID;
                    //dr[6] = q.Date;
                    dt.Rows.Add(dr);
                }

                ViewState["table"] = dt;
                //gvLensPrepare.DataSource = dt;
                //gvLensPrepare.DataBind();
            }
            else
            {
                var Query = from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row;
                if (Query.Count() > 0)
                {
                    btngenerate.Visible = true;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("TumblingRefNo", typeof(string));
                    dt.Columns.Add("LotNo", typeof(string));
                    dt.Columns.Add("Model", typeof(string));
                    dt.Columns.Add("Power", typeof(decimal));
                    dt.Columns.Add("Qty", typeof(int));
                    dt.Columns.Add("PhobicId", typeof(string));
                    //dt.Columns.Add("Date", typeof(DateTime));
                    ViewState["table"] = dt;

                    foreach (var q in Query)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = q.RetumblingRef1;
                        dr[1] = q.Glassy1;
                        dr[2] = q.Model1;
                        dr[3] = q.Power1;
                        dr[4] = q.AcceptedQty1;
                        dr[5] = q.PhobicId;
                        //dr[6] = q.Date;
                        dt.Rows.Add(dr);
                    }
                    ViewState["table"] = dt;
                }

                else
                {
                    var Query2 = from row in db.RemattTumblingLens where row.RetumblingRef2 == txttumblingNo.Text select row;
                    if (Query2.Count() > 0)
                    {
                        btngenerate.Visible = true;
                        DataTable dt = new DataTable();
                        dt.Columns.Add("TumblingRefNo", typeof(string));
                        dt.Columns.Add("LotNo", typeof(string));
                        dt.Columns.Add("Model", typeof(string));
                        dt.Columns.Add("Power", typeof(decimal));
                        dt.Columns.Add("Qty", typeof(int));
                        dt.Columns.Add("PhobicId", typeof(string));
                        //dt.Columns.Add("Date", typeof(DateTime));
                        ViewState["table"] = dt;

                        foreach (var q in Query2)
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = q.RetumblingRef2;
                            dr[1] = q.Glassy2;
                            dr[2] = q.Model2;
                            dr[3] = q.Power2;
                            dr[4] = q.AcceptedQty2;
                            dr[5] = q.PhobicId;
                            //dr[6] = q.Date;
                            dt.Rows.Add(dr);
                        }
                        ViewState["table"] = dt;

                    }

                    else
                    {
                        Messagebox("Enter Correct TumblingLotNo");
                        txttumblingNo.Text = "";
                        txttumblingNo.Focus();
                    }


                }
            }
        }
    }

    protected void btngenerate_Click(object sender, ImageClickEventArgs e)
    {
        var query = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
        if (query.Count() > 0)
        {
            gvLensPrepare.DataSource = query;
            gvLensPrepare.DataBind();
            btnSave.Visible = true;
            btnClear.Visible = true;
            totalQty.Visible = true;
            txttotalQty.Visible = true;
            lblstartdate.Visible = true;
            txtStartTime.Visible = true;
        }
        else
        {

            DataTable dt = (DataTable)ViewState["table"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LensPreperation_Detail d = new LensPreperation_Detail();
                d.TumblingRefNo = dt.Rows[i][0].ToString();
                d.LotNo = dt.Rows[i][1].ToString();
                d.Model = dt.Rows[i][2].ToString();
                d.Power = Convert.ToDecimal(dt.Rows[i][3].ToString());
                d.Qty = Convert.ToInt32(dt.Rows[i][4].ToString());
                d.PhobicId = dt.Rows[i][5].ToString();
                //d.Date = Convert.ToDateTime(txtSatrtDate.Text);
                d.Date = Convert.ToDateTime(System.DateTime.Now);
                db.LensPreperation_Details.InsertOnSubmit(d);
                db.SubmitChanges();
                //ReportBind();
                GridBind();
                Startdatetime.Visible = true;
            }

            //Report_Table Rptbl = new Report_Table();
            //var Q1 = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row.Power;
            //var Q2 = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row.Qty;
            //var Q = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row;
            //Rptbl.TumblingNo = Q.First().TumblingRefNo;
            //Rptbl.Model = Q.First().Model;
            //Rptbl.Power = Q1.First();
            //Rptbl.PhobicId = Q.First().PhobicId.ToString();
            //foreach (var Qu in Q2)
            //{

            //    temp1 = temp1 + Convert.ToInt32(Qu);
            //}
            //Rptbl.WaitingTumbling = temp1;
            //Rptbl.Status = 0;
            //db.Report_Tables.InsertOnSubmit(Rptbl);
            //db.SubmitChanges();
        }
        totalQty.Visible = false;
        txttotalQty.Visible = false;
        ReportBind();
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        int temp = 0;
        string Model;
        var query = from row in db.FinalLensPreparations where row.TumblingNo == txttumblingNo.Text select row;
        if (query.Count() > 0)
        {
            Messagebox("Data Already Saved");
        }
        else
        {
            var query1 = from row in db.LensPreperation_Details where row.TumblingRefNo == txttumblingNo.Text select row.Qty;
            //var query2 = (from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row.ModelNo).First();
            //var query3 = (from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row.PhobicID).First();
            var query2 = (from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row.ModelNo);
            var query3 = (from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row.PhobicID);
            if (query2.Count() > 0)
            {
                foreach (var q in query1)
                {
                    temp = temp + Convert.ToInt32(q);
                }
                if (ValidateSave())
                {
                    FinalLensPreparation lp = new FinalLensPreparation();
                    lp.TumblingNo = txttumblingNo.Text;
                    lp.Model = query2.First();
                    lp.TotalQty = Convert.ToInt32(temp);
                    lp.PhobicId = query3.First();
                    lp.StartDate = Convert.ToDateTime(txtSatrtDate.Text, provider);
                    lp.StartTime = Convert.ToString(txtStartTime.Text + ":" + ddlStartDay.Text);
                    int StatusValue = 1;
                    lp.Status = StatusValue;
                    db.FinalLensPreparations.InsertOnSubmit(lp);
                    db.SubmitChanges();
                    Report();
                    Messagebox("Saved Successfully");
                    btnSave.Visible = false;
                    btnClear.Visible = false;
                    btngenerate.Visible = false;
                    Clear();
                    txttumblingNo.Text = "";
                }
            }

            else
            {
                //var query4 = (from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row.Model1).First();
                //var query5 = (from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row.PhobicId).First();
                var query4 = (from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row.Model1);
                var query5 = (from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row.PhobicId);
                if (query4.Count() > 0)
                {
                    foreach (var q6 in query1)
                    {
                        temp = temp + Convert.ToInt32(q6);
                    }
                    if (ValidateSave())
                    {
                        FinalLensPreparation lp = new FinalLensPreparation();
                        lp.TumblingNo = txttumblingNo.Text;
                        lp.Model = query4.First();
                        lp.TotalQty = Convert.ToInt32(temp);
                        lp.PhobicId = query5.First();
                        lp.StartDate = Convert.ToDateTime(txtSatrtDate.Text, provider);
                        lp.StartTime = Convert.ToString(txtStartTime.Text + ":" + ddlStartDay.Text);
                        int StatusValue = 1;
                        lp.Status = StatusValue;
                        db.FinalLensPreparations.InsertOnSubmit(lp);
                        db.SubmitChanges();
                        Report();
                        Messagebox("Saved Successfully");
                        btnSave.Visible = false;
                        btnClear.Visible = false;
                        btngenerate.Visible = false;
                        Clear();
                        txttumblingNo.Text = "";

                    }
                }
                else
                {
                    var query6 = (from row in db.RemattTumblingLens where row.RetumblingRef2 == txttumblingNo.Text select row.Model2);
                    var query7 = (from row in db.RemattTumblingLens where row.RetumblingRef2 == txttumblingNo.Text select row.PhobicId);
                    if (query6.Count() > 0)
                    {
                        foreach (var q6 in query1)
                        {
                            temp = temp + Convert.ToInt32(q6);
                        }
                        if (ValidateSave())
                        {
                            FinalLensPreparation lp = new FinalLensPreparation();
                            lp.TumblingNo = txttumblingNo.Text;
                            lp.Model = query6.First();
                            lp.TotalQty = Convert.ToInt32(temp);
                            lp.PhobicId = query7.First();
                            lp.StartDate = Convert.ToDateTime(txtSatrtDate.Text, provider);
                            lp.StartTime = Convert.ToString(txtStartTime.Text + ":" + ddlStartDay.Text);
                            int StatusValue = 1;
                            lp.Status = StatusValue;
                            db.FinalLensPreparations.InsertOnSubmit(lp);
                            db.SubmitChanges();
                            Report();
                            Messagebox("Saved Successfully");
                            btnSave.Visible = false;
                            btnClear.Visible = false;
                            btngenerate.Visible = false;
                            Clear();
                            txttumblingNo.Text = "";
                        }
                    }
                }

                //var query4 = (from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row.Model1).First();
                //var query5 = (from row in db.RemattTumblingLens where row.RetumblingRef1 == txttumblingNo.Text select row.PhobicId).First() ;
                //if (query4.Count() > 0)
                //{
                //    foreach (var q6 in query1)
                //    {
                //        temp = temp + Convert.ToInt32(q6);
                //    }
                //    if (ValidateSave())
                //    {
                //        FinalLensPreparation lp = new FinalLensPreparation();
                //        lp.TumblingNo = txttumblingNo.Text;
                //        lp.Model = query4.ToString();
                //        lp.TotalQty = Convert.ToInt32(temp);
                //        lp.PhobicId = query5.ToString();
                //        lp.StartDate = Convert.ToDateTime(txtSatrtDate.Text, provider);
                //        lp.StartTime = Convert.ToString(txtStartTime.Text + ":" + ddlStartDay.Text);
                //        int StatusValue = 1;
                //        lp.Status = StatusValue;
                //        db.FinalLensPreparations.InsertOnSubmit(lp);
                //        db.SubmitChanges();
                //        Report();
                //        Messagebox("Saved Successfully");
                //        btnSave.Visible = false;
                //        btnClear.Visible = false;
                //        btngenerate.Visible = false;
                //        Clear();
                //        txttumblingNo.Text = ""; 

                //    }

                //}

                //else
                //{
                //    var query2 = (from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row.ModelNo).First();
                //    var query3 = (from row in db.MattTumblingLens where row.TumblingLotNo == txttumblingNo.Text select row.PhobicID).First();

                //    foreach (var q in query1)
                //    {
                //        temp = temp + Convert.ToInt32(q);
                //    }
                //    if (ValidateSave())
                //    {
                //        FinalLensPreparation lp = new FinalLensPreparation();
                //        lp.TumblingNo = txttumblingNo.Text;
                //        lp.Model = query2.ToString();
                //        lp.TotalQty = Convert.ToInt32(temp);
                //        lp.PhobicId = query3.ToString();
                //        lp.StartDate = Convert.ToDateTime(txtSatrtDate.Text, provider);
                //        lp.StartTime = Convert.ToString(txtStartTime.Text + ":" + ddlStartDay.Text);
                //        int StatusValue = 1;
                //        lp.Status = StatusValue;
                //        db.FinalLensPreparations.InsertOnSubmit(lp);
                //        db.SubmitChanges();
                //        Report();
                //        Messagebox("Saved Successfully");
                //        btnSave.Visible = false;
                //        btnClear.Visible = false;
                //        btngenerate.Visible = false;
                //        Clear();
                //        txttumblingNo.Text = "";
                //    }            

                //}                     
            }
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        var Query = from row in db.FinalLensPreparations where row.TumblingNo == txttumblingNo.Text select row;
        if (Query.Count() > 0)
        {
            if (ValidateUpdate())
            {
                Query.Single().EndDate = Convert.ToDateTime(txtEndDate.Text, provider);
                Query.Single().EndTime = Convert.ToString(txtEndTime.Text + ":" + ddlEndday.Text);

                if (Query.Single().Status == 1)
                {
                    Query.Single().Status = 2;
                }
                db.SubmitChanges();
                ReportUpdate();
                Messagebox("Updated Successfully");
                btnUpdate.Visible = false;
                btnClear.Visible = false;
                Clear();
                txttumblingNo.Text = "";
            }
        }
        else
        {
            Messagebox("Need to Save Start Time for this Tumbling Number");
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        txttumblingNo.Text = "";
        Clear();
        btnSave.Visible = false;
        btnClear.Visible = false;
        btngenerate.Visible = false;
        Startdatetime.Visible = false;
    }


    #endregion
}
