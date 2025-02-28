using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using AjaxControlToolkit;


public partial class LensMatTumblig : System.Web.UI.Page
{

    #region Declaration
    string lotno;

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    #endregion


    #region Methods





    #endregion


    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {


        //txtSatrtDate.Text = DateTime.Now.ToString("dd/MM/yyy");

        if (!IsPostBack)
        {
            //Shift();
        }

        if (Session["Location"].ToString() == "Chennai")
        {
            txtLotno.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtAcceptedQty.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            //txtLotno.FilterType = FilterTypes.Custom;
            //txtLotno.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtLotno.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtAcceptedQty.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
        }
    }

    #endregion



    private void clear()
    {
        txtLotno.Text = "";
        txtTumblingRefno.Text = "";
        txtPreparedBy.Text = "";
        txtPower.Text = "";
        txtPhobicId.Text = "";
        txtModel.Text = "";
        txtAcceptedQty.Text = "";
        //txtSatrtDate.Text = DateTime.Now.ToString("dd/MM/yyy");
        txtSatrtDate.Text = "";
        btnClear.Visible = true;
        //RadioButtonList1.SelectedValue = "";        

    }
    private void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "');", true);
    }
    private void lotnogridbind(string lotno)
    {
        SoftLensDataContext db = new SoftLensDataContext();
        MattTumblingLen mat = new MattTumblingLen();
        btnUpdate.Visible = false;
        btnClear.Visible = true;
        clear();
        var query = from row in db.MattTumblingLens where row.LensCutLot == lotno select row;
        gvLotResult.DataSource = query;
        gvLotResult.DataBind();
    }
    private void GridBind()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        var query = from row in db.MattTumblingLens where row.LensCutLot == txtLotno.Text select row;
        gvLotResult.DataSource = query;
        gvLotResult.DataBind();
    }
    protected void txtLotno_TextChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Matt")
        {
            if (txtLotno.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
            {
                MessageBox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex: PHY" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
                txtLotno.Text = "";
                txtLotno.Focus();
            }
            else
            {
                var query2 = from rows in db.MattTumblingLens where rows.LensCutLot == txtLotno.Text select rows;
                if (query2.Count() > 0)
                {
                    lotnogridbind(txtLotno.Text);
                    clear();
                }
                else
                {
                    var query = from rows in db.BatchAllots where rows.LotNo == txtLotno.Text select rows;
                    if (query.Count() > 0)
                    {
                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                        btnClear.Visible = true;
                        txtModel.Text = query.Single().ModelNo.ToString();
                        txtPower.Text = query.Single().Power.ToString();
                        txtPhobicId.Text = query.Single().BatchNo.ToString();
                    }
                    else
                    {

                        MessageBox("No Value found in Previous Process Check LotNo ");
                        txtLotno.Text = "";
                        txtLotno.Focus();
                    }
                    var query1 = (from rows in db.LotResults where rows.LotNo == txtLotno.Text select rows.AcceptedQuantity).Sum();

                    if (query1 == null)
                    {
                        MessageBox("No Value found in Previous Process Check LotNo ");
                        txtLotno.Text = "";
                        txtLotno.Focus();
                    }
                    else
                    {

                        txtAcceptedQty.Text = query1.Value.ToString();
                        btnSave.Visible = true;
                        btnClear.Visible = true;
                        btnUpdate.Visible = false;
                        txtAcceptedQty.Focus();
                    }
                }
            }
        }
        else if (RadioButtonList1.SelectedValue == "Ist Rematt")
        {

            if (txtLotno.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
            {
                MessageBox("Enter the Glassy Ref No in Correct Format");
                txtLotno.Text = "";
                txtLotno.Focus();
            }
            else
            {



                //var query2 = from row in db.FirstRetumblingReports where row.GlassyNo== txtLotno.Text select row;
                var q1 = from row in db.MIinFQIs where row.GlassyNo == txtLotno.Text select row;
                var query3 = from row in db.RemattTumblingLens where row.Glassy1 == txtLotno.Text select row;
                if (q1.Count() > 0)
                {
                    if (query3.Count() == 0)
                    {

                        btnSave.Visible = true;
                        btnUpdate.Visible = false;
                        btnClear.Visible = true;
                        txtAcceptedQty.Text = q1.Single().RetumblingQty.ToString();               
                        txtModel.Text = q1.Single().Model.ToString();
                        txtPower.Text = q1.Single().Power.ToString();
                        txtPhobicId.Text = q1.Single().TumblingRefNo.ToString();
                    }
                    else
                    {
                        btnSave.Visible = false;
                        btnClear.Visible = true;
                        txtTumblingRefno.Enabled = false;
                        txtSatrtDate.Text = query3.Single().Date1.Value.ToShortDateString();
                        txtAcceptedQty.Text = query3.Single().AcceptedQty1.ToString();
                        txtModel.Text = query3.Single().Model1.ToString();
                        txtPower.Text = query3.Single().Power1.ToString();
                        txtPhobicId.Text = query3.Single().TumblingLotNo.ToString();
                        txtTumblingRefno.Text = query3.Single().RetumblingRef1.ToString();
                        txtPreparedBy.Text = query3.Single().PreparedBy1.ToString();
                    }
                }
                else if (query3.Count() > 0)
                {
                    txtSatrtDate.Text = query3.Single().Date1.Value.ToShortDateString();
                    txtAcceptedQty.Text = query3.Single().AcceptedQty1.ToString();
                    txtPhobicId.Text = query3.Single().TumblingLotNo.ToString();
                    txtModel.Text = query3.Single().Model1.ToString();
                    txtTumblingRefno.Text = query3.Single().RetumblingRef1.ToString();
                    txtPower.Text = query3.Single().Power1.ToString();
                    txtPreparedBy.Text = query3.Single().PreparedBy1.ToString();
                    btnClear.Visible = true;

                }
                else
                {
                    MessageBox("No Value found in Previous Process Check GlassyRef No ");
                    txtLotno.Text = "";
                    txtLotno.Focus();

                }

            }


        }
        else if (RadioButtonList1.SelectedValue == "IInd Rematt")
        {
            if (txtLotno.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
            {
                MessageBox("Enter the Retumbling Glassy Ref No in Correct Format");
                txtLotno.Text = "";
                txtLotno.Focus();
            }
            else
            {
                var query2 = from row in db.MIinFQIs where row.GlassyNo == txtLotno.Text select row;
                var query4 = from row in db.RemattTumblingLens where row.Glassy2 == txtLotno.Text select row;
                if (query2.Count() > 0)
                {
                    if (query4.Count() == 0)
                    {
                        btnSave.Visible = true;
                        btnUpdate.Visible = false;
                        btnClear.Visible = true;
                        txtTumblingRefno.Enabled = true;
                        txtAcceptedQty.Text = query2.Single().RetumblingQty.ToString();
                        txtModel.Text = query2.Single().Model.ToString();
                        txtPower.Text = query2.Single().Power.ToString();
                        txtPhobicId.Text = query2.Single().TumblingRefNo.ToString();
                    }
                    else
                    {
                        btnSave.Visible = false;
                        btnClear.Visible = true;
                        txtTumblingRefno.Enabled = false;
                        txtAcceptedQty.Text = query4.Single().AcceptedQty2.ToString();
                        txtModel.Text = query4.Single().Model2.ToString();
                        txtPower.Text = query4.Single().Power2.ToString();
                        txtPhobicId.Text = query4.Single().TumblingLotNo.ToString();
                        txtTumblingRefno.Text = query4.Single().RetumblingRef2.ToString();
                        txtPreparedBy.Text = query4.Single().PreparedBy2.ToString();

                    }
                }
                else if (query4.Count() > 0)
                {
                    txtSatrtDate.Text = query4.Single().Date2.Value.ToShortDateString();
                    txtAcceptedQty.Text = query4.Single().AcceptedQty2.ToString();
                    txtPhobicId.Text = query4.Single().TumblingLotNo.ToString();
                    txtModel.Text = query4.Single().Model2.ToString();
                    txtTumblingRefno.Text = query4.Single().RetumblingRef2.ToString();
                    txtPower.Text = query4.Single().Power2.ToString();
                    txtPreparedBy.Text = query4.Single().PreparedBy2.ToString();
                    btnClear.Visible = true;
                }

                else
                {
                    MessageBox("No Value found in Previous Process Check GlassyRef No ");
                    txtLotno.Text = "";
                    txtLotno.Focus();
                }
            }
        }
        else if (RadioButtonList1.SelectedValue == "IIIrd Rematt")
        {
            if (txtLotno.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
            {
                MessageBox("Enter the RGlassy Ref No in Correct Format");
                txtLotno.Text = "";
                txtLotno.Focus();
            }
            else
            {
                var query2 = from row in db.MIinFQIs where row.GlassyNo == txtLotno.Text select row;
                var query5 = from row in db.RemattTumblingLens where row.Glassy3 == txtLotno.Text select row;
                if (query2.Count() > 0)
                {
                    if (query5.Count() == 0)
                    {
                        btnSave.Visible = true;
                        btnUpdate.Visible = false;
                        btnClear.Visible = true;
                        txtTumblingRefno.Enabled = true;
                        txtAcceptedQty.Text = query2.Single().RetumblingQty.ToString();
                        txtModel.Text = query2.Single().Model.ToString();
                        txtPower.Text = query2.Single().Power.ToString();
                        txtPhobicId.Text = query2.Single().TumblingRefNo.ToString();
                    }
                    else
                    {
                        btnSave.Visible = false;
                        btnClear.Visible = true;
                        txtTumblingRefno.Enabled = false;
                        txtAcceptedQty.Text = query5.Single().AcceptedQty3.ToString();
                        txtModel.Text = query5.Single().Model3.ToString();
                        txtPower.Text = query5.Single().Power3.ToString();
                        txtPhobicId.Text = query5.Single().TumblingLotNo.ToString();
                        txtTumblingRefno.Text = query5.Single().RetumblingRef3.ToString();
                        txtPreparedBy.Text = query5.Single().PreparedBy3.ToString();
                    }
                }
                else if (query5.Count() > 0)
                {
                    txtSatrtDate.Text = query5.Single().Date3.Value.ToShortDateString();
                    txtAcceptedQty.Text = query5.Single().AcceptedQty3.ToString();
                    txtPhobicId.Text = query5.Single().TumblingLotNo.ToString();
                    txtModel.Text = query5.Single().Model3.ToString();
                    txtTumblingRefno.Text = query5.Single().RetumblingRef3.ToString();
                    txtPower.Text = query5.Single().Power3.ToString();
                    txtPreparedBy.Text = query5.Single().PreparedBy3.ToString();
                    btnClear.Visible = true;
                }

                else
                {
                    MessageBox("No Value found in Previous Process Check GlassyRef No ");
                    txtLotno.Text = "";
                    txtLotno.Focus();
                }

            }

        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtTumblingRefno.Text = "";
        txtLotno.Text = "";
        gvLotResult.DataSource = null;
        gvLotResult.DataBind();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    private void Submitchangescompled()
    {
        clear();
        var qgv = from f in db.MattTumblingLens where f.LensCutLot == txtLotno.Text select f;
        if (qgv.Count() > 0)
        {
            gvLotResult.DataSource = qgv;
            gvLotResult.DataBind();

            btnSave.Visible = false;
            btnClear.Visible = true;
        }
        txtLotno.Text = "";
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnClear.Visible = false;
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Matt")
        {
            if (txtTumblingRefno.Text == "")
            {
                Messagebox("Please enter the Tumbling Ref No");
                txtTumblingRefno.Focus();
            }
            else if (txtPreparedBy.Text == "")
            {
                Messagebox("Please enter Prepared by");
                txtPreparedBy.Focus();
            }
            else
            {

                MattTumblingLen mat = new MattTumblingLen();
                mat.LensCutLot = txtLotno.Text;
                mat.TotalQuantity = Convert.ToInt16(txtAcceptedQty.Text);
                mat.Power = Convert.ToDecimal(txtPower.Text);
                mat.Tumbledby = txtPreparedBy.Text;
                mat.ModelNo = txtModel.Text;
                mat.TumblingLotNo = txtTumblingRefno.Text;
                mat.PhobicID = txtPhobicId.Text;
                mat.Date = Convert.ToDateTime(txtSatrtDate.Text, provider);
                db.MattTumblingLens.InsertOnSubmit(mat);
                db.SubmitChanges();
                Messagebox("Record Saved");
                GridBind();

                //Report_Table Rptbl = new Report_Table();
                //Rptbl.TumblingNo = txtTumblingRefno.Text;
                //Rptbl.Model = txtModel.Text;
                //Rptbl.Power = Convert.ToDecimal(txtPower.Text);
                //Rptbl.PhobicId = txtPhobicId.Text;
                //Rptbl.WaitingTumbling = Convert.ToInt32(txtAcceptedQty.Text);
                //Rptbl.Status = 0;
                //db.Report_Tables.InsertOnSubmit(Rptbl);
                //db.SubmitChanges();                
                //clear();
                Submitchangescompled();


                btnClear.Visible = true;
            }
        }
        else if (RadioButtonList1.SelectedValue == "Ist Rematt")
        {

            if (txtTumblingRefno.Text == "")
            {
                Messagebox("Please enter the Tumbling Ref No");
                txtTumblingRefno.Focus();
            }
            else if (txtPreparedBy.Text == "")
            {
                Messagebox("Please enter Prepared by");
                txtPreparedBy.Focus();
            }
            else
            {

                RemattTumblingLen Rt = new RemattTumblingLen();
                MIinFQI mi = new MIinFQI();

                Rt.Glassy1 = txtLotno.Text;
                Rt.Date1 = Convert.ToDateTime(txtSatrtDate.Text, provider);
                Rt.AcceptedQty1 = Convert.ToInt16(txtAcceptedQty.Text).ToString();
                Rt.Model1 = txtModel.Text;
                Rt.Power1 = Convert.ToDecimal(txtPower.Text);
                Rt.TumblingLotNo = txtPhobicId.Text;
                Rt.RetumblingRef1 = txtTumblingRefno.Text;
                Rt.PreparedBy1 = txtPreparedBy.Text;
                string temp = txtPhobicId.Text;
                var Q1 = (from row in db.MattTumblingLens where row.TumblingLotNo == temp select row.PhobicID).FirstOrDefault();
                Rt.PhobicId = Q1.ToString();
                string temp1 = txtAcceptedQty.Text;
                var q2 = (from row in db.MIinFQIs where row.GlassyNo == txtLotno.Text select row.RetumblingQty).FirstOrDefault();
                mi.RetumblingQty = q2 - Convert.ToInt32(temp1);
                db.RemattTumblingLens.InsertOnSubmit(Rt);
                db.SubmitChanges();

                //Report_Table rt = new Report_Table();
                //rt.RetumblingNo = txtTumblingRefno.Text;
                //rt.Model = txtModel.Text;
                //rt.Power = Convert.ToDecimal(txtPower.Text);
                //var Q = (from row in db.MattTumblingLens where row.TumblingLotNo == temp select row.PhobicID).FirstOrDefault();
                //rt.PhobicId = Q.ToString();
                //rt.TumblingNo=txtPhobicId.Text;
                //rt.WaitingTumbling = Convert.ToInt32(txtAcceptedQty.Text);
                //rt.Status = 0;
                //db.Report_Tables.InsertOnSubmit(rt);
                //db.SubmitChanges();

                Messagebox("Record Saved");
                clear();
                btnSave.Visible = false;
                btnClear.Visible = false;

            }
        }
        else if (RadioButtonList1.SelectedValue == "IInd Rematt")
        {

            if (txtTumblingRefno.Text == "")
            {
                Messagebox("Please enter the Tumbling Ref No");
                txtTumblingRefno.Focus();
            }
            else if (txtPreparedBy.Text == "")
            {
                Messagebox("Please enter Prepared by");
                txtPreparedBy.Focus();
            }
            else
            {
                RemattTumblingLen Rt = new RemattTumblingLen();
                Rt.Glassy2 = txtLotno.Text;
                Rt.Date2 = Convert.ToDateTime(txtSatrtDate.Text, provider);
                Rt.AcceptedQty2 = Convert.ToInt16(txtAcceptedQty.Text).ToString();
                Rt.Model2 = txtModel.Text;
                Rt.Power2 = Convert.ToDecimal(txtPower.Text);
                Rt.TumblingLotNo = txtPhobicId.Text;
                //Rt.RetumblingRef1= txtPhobicId.Text;
                Rt.RetumblingRef2 = txtTumblingRefno.Text;
                Rt.PreparedBy2 = txtPreparedBy.Text;
                string temp = txtPhobicId.Text;
                var Q1 = (from row in db.RemattTumblingLens where row.RetumblingRef1 == temp select row.PhobicId).FirstOrDefault();
                Rt.PhobicId = Q1.ToString();
                Rt.PhobicId = txtPhobicId.Text;
                db.RemattTumblingLens.InsertOnSubmit(Rt);
                db.SubmitChanges();

                //Report_Table rtb = new Report_Table();
                //rtb.RetumblingNo = txtTumblingRefno.Text;
                //rtb.Model = txtModel.Text;
                //rtb.Power = Convert.ToDecimal(txtPower.Text);
                //var Q = (from row in db.RemattTumblingLens where row.RetumblingRef1 == temp select row.PhobicId).FirstOrDefault();
                //rtb.PhobicId = Q.ToString();
                //rtb.TumblingNo = txtPhobicId.Text;
                //rtb.WaitingTumbling = Convert.ToInt32(txtAcceptedQty.Text);
                //rtb.Status = 0;
                //db.Report_Tables.InsertOnSubmit(rtb);
                //db.SubmitChanges();
                Messagebox("Record Saved");
                clear();
                btnClear.Visible = false;
                btnSave.Visible = false;
            }
        }
        else if (RadioButtonList1.SelectedValue == "IIIrd Rematt")
        {

            if (txtTumblingRefno.Text == "")
            {
                Messagebox("Please enter the Tumbling Ref No");
                txtTumblingRefno.Focus();
            }
            else if (txtPreparedBy.Text == "")
            {
                Messagebox("Please enter Prepared by");
                txtPreparedBy.Focus();
            }
            else
            {
                RemattTumblingLen Rt = new RemattTumblingLen();
                Rt.Glassy3 = txtLotno.Text;
                Rt.Date3 = Convert.ToDateTime(txtSatrtDate.Text, provider);
                Rt.AcceptedQty3 = Convert.ToInt16(txtAcceptedQty.Text).ToString();
                Rt.Model3 = txtModel.Text;
                Rt.Power3 = Convert.ToDecimal(txtPower.Text);
                Rt.TumblingLotNo = txtPhobicId.Text;
                //Rt.RetumblingRef2= txtPhobicId.Text;
                Rt.RetumblingRef3 = txtTumblingRefno.Text;
                Rt.PreparedBy3 = txtPreparedBy.Text;
                Rt.PhobicId = txtPhobicId.Text;
                db.RemattTumblingLens.InsertOnSubmit(Rt);
                db.SubmitChanges();
                Messagebox("Record Saved");
                clear();
                btnClear.Visible = true;
            }
        }

        //else
        //{
        //    RemattTumblingLen Rt = new RemattTumblingLen();
        //    Rt.Glassy3 = txtLotno.Text;
        //    Rt.Date3 = Convert.ToDateTime(txtSatrtDate.Text,provider);
        //    Rt.AcceptedQty3 = Convert.ToInt16(txtAcceptedQty.Text).ToString();
        //    Rt.Model3 = txtModel.Text;
        //    Rt.Power3 = Convert.ToDecimal(txtPower.Text);
        //    Rt.TumblingLotNo = txtPhobicId.Text;
        //    Rt.RetumblingRef3 = txtTumblingRefno.Text;
        //    Rt.PreparedBy3 = txtPreparedBy.Text;
        //    db.RemattTumblingLens.InsertOnSubmit(Rt);
        //    db.SubmitChanges();
        //    Messagebox("Record Saved");
        //}

    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    protected void txtTumblingRefno_TextChanged(object sender, EventArgs e)
    {
        SoftLensDataContext db = new SoftLensDataContext();
        if (txtTumblingRefno.Text.Length < 8)
        {
            MessageBox("Enter  the 11 digit No ex: PHYT0010000 ");
            txtTumblingRefno.Text = "";
            txtTumblingRefno.Focus();
        }
        else
        {
            string lot = txtTumblingRefno.Text;
            string yr = System.DateTime.Now.ToString("yy");
            string mon = System.DateTime.Now.ToString("MM");
            if ((lot[3] == 't' || lot[3] == 'T') && (lot.Substring(4, 2) == yr && lot.Substring(3, 2) == mon))
            {

            }
            else if ((lot[5] >= 48 && lot[5] <= 57) && (lot[6] >= 48 && lot[6] <= 57) && (lot[7] >= 48 && lot[7] <= 57))
            {
                txtTumblingRefno.Text = lot.ToUpper();
            }
            else
            {
                MessageBox("Enter In correct Format ex: PHYT0010000 ");
                txtTumblingRefno.Text = "";
                txtTumblingRefno.Focus();
            }

            //var query = from row in db.MattTumblingLens where row.TumblingLotNo == txtTumblingRefno.Text select row.TumblingLotNo;
            //if (query.Count() <=3)
            //{
            //    btnSave.Enabled = true;
            //}
            //else
            //{
            //    btnSave.Enabled = false;
            //    MessageBox("Tumbling No Exceeds the Limit");
            //}
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        var obj = db.MillingCleanedLens.Single(r => r.LotNo == txtLotno.Text);
        MattTumblingLen mat = new MattTumblingLen();
        mat.LensCutLot = txtLotno.Text;
        mat.TotalQuantity = Convert.ToInt16(txtAcceptedQty.Text);
        mat.Power = Convert.ToDecimal(txtPower.Text);
        mat.Tumbledby = txtPreparedBy.Text;
        mat.ModelNo = txtModel.Text;
        mat.TumblingLotNo = txtTumblingRefno.Text;
        mat.PhobicID = txtPhobicId.Text;
        mat.Date = Convert.ToDateTime(txtSatrtDate.Text);
        db.SubmitChanges();
        MessageBox("Records Updated");
        clear();
        txtLotno.Text = "";
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    protected void gvDeblocking_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void txtPreparedBy_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string up = txtPreparedBy.Text;

            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtPreparedBy.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter INITIAL ex: M.BALAJI");
                txtPreparedBy.Text = "";
                txtPreparedBy.Focus();
            }

        }
        catch
        {
            Messagebox("Please Enter INITIAL ex: M.BALAJI");
            txtPreparedBy.Text = "";
            txtPreparedBy.Focus();
        }
    }





    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Matt")
        {
            Label1.Text = "Lot No";
            Label5.Text = "PhobicID";
            Label8.Text = "Tumbling Ref No";
        }
        else if (RadioButtonList1.SelectedValue == "Ist Rematt")
        {
            Label1.Text = "Glassy RefNo";
            Label5.Text = "Tumbling LotNo";
            Label8.Text = "Retumb RefNo1";

        }
        else if (RadioButtonList1.SelectedValue == "IInd Rematt")
        {
            Label1.Text = "Glassy RefNo";
            Label5.Text = "Retumb LotNo1";
            Label8.Text = "Retumb RefNo2";
        }
        else if (RadioButtonList1.SelectedValue == "IIIrd Rematt")
        {
            Label1.Text = "Glassy RefNo";
            Label5.Text = "Retumb LotNo2";
            Label8.Text = "Retumb RefNo3";
        }
    }
}

