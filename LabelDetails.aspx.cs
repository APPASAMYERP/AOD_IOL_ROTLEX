using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LabelDetails : System.Web.UI.Page
{

    #region Declaration
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    #endregion


    #region Methods

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void clear()
    {
        txtEndNo.Text = "";
        txtLotNos.Text = "";
        txtModel.Text = "";
        txtQty.Text = "";
        txtRemarks.Text = "";
        txtStartNo.Text = "";
        txtTotalQty.Text = "";
        txtPackedBy.Text = "";
        drpPower.SelectedValue = "--Select--";
        txtBrandName.Text = "";
        txtLotNo.Text = "";
        txtTotalQty.Text = "";
        txtTumblingRef.Text = "";
        ddlSubModel.SelectedValue = "0";
    }

    #endregion


    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

    }

    protected void LabelDetailsBind()
    {
        btnSave.Visible = false;
        var query = from row in db.LabelDetailsPackings where row.GlassyNo == txtLotNos.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        btnClear.Visible = true;
        gvLabelDetails.DataSource = query;
        gvLabelDetails.DataBind();
    }

    protected void txtGlassyNo_TextChanged(object sender, EventArgs e)
    {
        string t = txtLotNos.Text;
        txtLotNos.Text = t.ToUpper();

        var seg = from a in db.PowerSegregationChilds
                  where a.TumblingNo == txtLotNos.Text
                  select a;
        drpPower.Items.Clear();
        drpPower.Items.Add("--Select--");
        drpPower.DataSource = seg;
        drpPower.DataTextField = "Power";
        drpPower.DataValueField = "Power";
        drpPower.DataBind();
        drpPower.Focus();
    }

    protected void gvLabelDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["up"].Equals(1) && gvLabelDetails.Rows.Count - 1 == gvLabelDetails.SelectedIndex)
        {

            txtDate.Text = gvLabelDetails.SelectedRow.Cells[12].Text;
            txtEndNo.Text = gvLabelDetails.SelectedRow.Cells[9].Text;
            txtLotNo.Text = gvLabelDetails.SelectedRow.Cells[7].Text;
            txtModel.Text = gvLabelDetails.SelectedRow.Cells[2].Text;
            txtQty.Text = gvLabelDetails.SelectedRow.Cells[10].Text;
            txtRemarks.Text = gvLabelDetails.SelectedRow.Cells[11].Text;
            txtStartNo.Text = gvLabelDetails.SelectedRow.Cells[8].Text;
            txtTotalQty.Text = gvLabelDetails.SelectedRow.Cells[5].Text;
            //txtTumblingLotNo.Text = gvLabelDetails.SelectedRow.Cells[1].Text;
            txtPackedBy.Text = gvLabelDetails.SelectedRow.Cells[13].Text;
            //ddlPower.Text = gvLabelDetails.SelectedRow.Cells[6].Text;
            ddlSubModel.Text = gvLabelDetails.SelectedRow.Cells[3].Text;
            txtBrandName.Text = gvLabelDetails.SelectedRow.Cells[4].Text;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnClear.Visible = true;
            Label id = gvLabelDetails.SelectedRow.FindControl("Label1") as Label;
            Session["id"] = id.Text;
        }
    }

    protected void txtEndNo_TextChanged(object sender, EventArgs e)
    {
        #region CurrentUse

        if (Convert.ToInt32(txtEndNo.Text) > Convert.ToInt32(txtTotalQty.Text))
        {
            Messagebox("EndNo Value Exceeds,Check it");
            txtEndNo.Focus();
            txtEndNo.Text = "";


        }
        else
        {
            int s = Convert.ToInt32(txtStartNo.Text);
            if (s == 1)
            {
                txtQty.Text = txtEndNo.Text.ToString();
            }

        }
        #endregion




        #region Philic Code
        //var query = (from row in db.LabelDetailsPackings where row.TumblingRefNo == txtTumblingRef.Text select row.Qty).Sum();

        //if (query != null)
        //{
        //    if (query.Value + Convert.ToInt32(txtQty.Text) > Convert.ToInt32(txtTotalQty.Text))
        //    {
        //        Messagebox("Enter qty is greater than received qty");
        //        txtEndNo.Text = "";
        //        txtQty.Text = "";
        //        txtEndNo.Focus();
        //    }
        //}

        #endregion

        #region Deleted

        //int val = Convert.ToInt32(txtEndNo.Text) - Convert.ToInt32(txtStartNo.Text) + 1;
        //if (val < 0)
        //{
        //    Messagebox("Enter a valid No");
        //    txtEndNo.Text = "";
        //    txtEndNo.Focus();

        //}
        //else
        //{
        //    txtQty.Text = val.ToString();
        //    txtRemarks.Focus();
        //}

        //if (Convert.ToInt32(txtEndNo.Text) > 200 || Convert.ToInt32(txtEndNo.Text) > Convert.ToInt32(txtTotalQty.Text))
        //{
        //    Messagebox("Enter a valid No");
        //    txtEndNo.Text = "";
        //    txtEndNo.Focus();
        //}

        //var query = (from row in db.LabelDetailsPackings where row.GlassyNo == txtGlassyNo.Text select row.Qty).Sum();

        //if (query != null)
        //{
        //    if (query.Value + Convert.ToInt32(txtQty.Text) > Convert.ToInt32(txtTotalQty.Text))
        //    {
        //        Messagebox("Enter qty is greater than received qty");
        //        txtEndNo.Text = "";
        //        txtQty.Text = "";
        //        txtEndNo.Focus();
        //    }
        //}
        #endregion

    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        //string d = txtDate.Text;
        //string[] dat = d.Split('/');

        //int dt = Convert.ToInt32(dat[0]);

        //int m = Convert.ToInt32(dat[1]) - 1;
        //int y;
        //if (m == 1)
        //{
        //    m = 12;
        //    y = Convert.ToInt32(dat[2]) + 2;
        //}
        //else
        //{
        //    y = Convert.ToInt32(dat[2]) + 3;
        //}


        //string exp = dt.ToString() + "/" + m.ToString() + "/" + y.ToString();

        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter LotNo");
        }
        else if (txtStartNo.Text == "")
        {
            Messagebox("Please Enter Start NO");
        }
        else if (txtEndNo.Text == "")
        {
            Messagebox("Please Enter End No");
        }
        else if (txtPackedBy.Text == "")
        {
            Messagebox("Please Enter Packed By");
        }

        else
        {
            //var Q = (from row in db.LabelDetailsPackings where row.LotNo == txtLotNo.Text select row.Qty).Sum();
            //int temp1= Convert.ToInt32(Q.ToString());
            //int temp2=Convert.ToInt32(txtQty.Text);
            //int Quantity = temp1 + temp2;
            //if (Quantity > 100)
            //{
            //    Messagebox("Assign Another Lotno for Label_Packing");
            //}
            //else
            //{
            LabelDetailsPacking labTable = new LabelDetailsPacking();
            labTable.GlassyNo = txtLotNos.Text;
            labTable.Model = txtModel.Text;
            labTable.TotalQty = Convert.ToInt32(txtTotalQty.Text);
            labTable.TumblingRefNo = txtTumblingRef.Text;
            labTable.SubModel = ddlSubModel.SelectedValue;
            labTable.BrandName = txtBrandName.Text;
            labTable.Power = Convert.ToDecimal(drpPower.SelectedValue);
            labTable.LotNo = txtLotNo.Text;
            labTable.StartNo = Convert.ToInt32(txtStartNo.Text);
            labTable.EndNo = Convert.ToInt32(txtEndNo.Text);
            labTable.Qty = Convert.ToInt32(txtQty.Text);
            labTable.Remarks = txtRemarks.Text;
            labTable.Date = Convert.ToDateTime(txtDate.Text, provider);
            labTable.PackedBy = txtPackedBy.Text;
            db.LabelDetailsPackings.InsertOnSubmit(labTable);
            db.SubmitChanges();
            Messagebox("Records Saved");

            LabelDetailsBind();
            clear();
            btnUpdate.Visible = false;
            btnClear.Visible = false;
            btnSave.Visible = false;


            //}

        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        string d = txtDate.Text;
        string[] dat = d.Split('/');

        int dt = Convert.ToInt32(dat[0]);

        int m = Convert.ToInt32(dat[1]) - 1;
        int y;
        if (m == 1)
        {
            m = 12;
            y = Convert.ToInt32(dat[2]) + 2;
        }
        else
        {
            y = Convert.ToInt32(dat[2]) + 3;
        }

        string exp = dt.ToString() + "/" + m.ToString() + "/" + y.ToString();

        var query = from row in db.LabelDetailsPackings where row.GlassyNo == txtLotNos.Text && row.Id == Convert.ToInt32(Session["id"].ToString()) select row;
        query.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
        query.Single().EndNo = Convert.ToInt32(txtEndNo.Text);
        query.Single().LotNo = txtLotNo.Text;
        query.Single().Model = txtModel.Text;
        query.Single().PackedBy = txtPackedBy.Text;
        //query.Single().Power = Convert.ToDecimal(ddlPower.Text);
        query.Single().Qty = Convert.ToInt32(txtQty.Text);
        query.Single().Remarks = txtRemarks.Text;
        query.Single().StartNo = Convert.ToInt32(txtStartNo.Text);
        query.Single().TotalQty = Convert.ToInt32(txtTotalQty.Text);
        //query.Single().TumblingLotNo = txtTumblingLotNo.Text;
        query.Single().SubModel = ddlSubModel.Text;
        query.Single().BrandName = txtBrandName.Text;
        query.Single().ExpiryDate = exp;
        db.SubmitChanges();
        Messagebox("Records Updated");
        clear();
        //LabelDetailsGridBind(txtTumblingLotNo.Text);

        //txtTumblingLotNo.Text = "";
        btnUpdate.Visible = false;
        btnClear.Visible = false;
        btnSave.Visible = false;
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
    }


    protected void txtPackedBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtPackedBy.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtPackedBy.Text = up.ToUpper();
        }
        else
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtPackedBy.Text = "";
            txtPackedBy.Focus();

        }
    }

    protected void ddlSubModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubModel.SelectedIndex == 0)
        {
            Messagebox("Please choose SubModel");
            ddlSubModel.Focus();
        }
        else
        {
            var query = from row in db.ModelMasters where row.SubModel == ddlSubModel.Text select row.BrandName;
            txtBrandName.Text = query.Single().ToString();
            txtLotNo.Focus();
        }
    }

    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        if (txtLotNos.Text != "")
        {
            if (Convert.ToInt32(txtQty.Text) > Convert.ToInt32(txtTotalQty.Text))
            {
                Messagebox("Value is Greater than Total Qty");
                txtStartNo.Text = "";
                txtEndNo.Text = "";
                txtQty.Text = "";

            }
        }
        //if (txtGlassyNo.Text != "")
        //{
        //    var query = (from row in db.LabelDetailsPackings where row.GlassyNo == (txtGlassyNo.Text) select row.Qty).Sum();
        //    if (query == null) { query = (0); }
        //    if (Convert.ToInt32(txtQty.Text) > Convert.ToInt32(txtTotalQty.Text) || (query.Value + Convert.ToInt32(txtQty.Text)) > Convert.ToInt32(txtTotalQty.Text) || ((Convert.ToInt32(txtStartNo.Text) + Convert.ToInt32(txtQty.Text)) - 1) > 200)
        //    {
        //        Messagebox("Qty is greater than Total Qty");
        //        txtQty.Text = "";
        //        txtQty.Focus();
        //        txtEndNo.Text = "";
        //        txtEndNo.Focus();
        //    }
        //    else
        //    {
        //        txtEndNo.Text = (Convert.ToInt32(txtStartNo.Text) + Convert.ToInt32(txtQty.Text) - 1).ToString();
        //    }
        //}

    }

    //protected void txtLotNo_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtLotNo.Text != "")
    //    {
    //        var query = (from row in db.LabelDetailsPackings where row.LotNo == txtLotNo.Text select row.EndNo).Max();
    //        if (query != null)
    //        {
    //            if (query.Value == 200)
    //            {
    //                txtLotNo.Text = "";
    //                txtLotNo.Focus();
    //                Messagebox("LotNo Limit exceeds");
    //            }
    //            else
    //            {
    //                txtStartNo.Text = Convert.ToString(Convert.ToInt32(query.Value) + 1);
    //            }
    //        }
    //        else
    //        {
    //            txtStartNo.Text = "1";
    //        }

    //        var query1 = (from row in db.LabelDetailsPackings where row.GlassyNo == txtGlassyNo.Text select row.Qty).Sum();
    //        if (query1 != null && txtTotalQty.Text != "")
    //        {
    //            if (query1.Value >= Convert.ToInt32(txtTotalQty.Text))
    //            {
    //                Messagebox("No qty Available for this Tumbling No");
    //                clear();
    //            }
    //        }
    //    }
    //}

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        string t = txtLotNo.Text;
        txtLotNo.Text = t.ToUpper();
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNos.Text = "";
        gvLabelDetails.DataSource = null;
        gvLabelDetails.DataBind();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    //protected void txtGlassyNo_TextChanged(object sender, EventArgs e)
    //{
    //    string t = txtGlassyNo.Text;
    //    txtGlassyNo.Text = t.ToUpper();

    //    var Query = from row in db.MIinFQIs where row.GlassyNo == txtGlassyNo.Text select row;
    //    txtModel.Text = Query.Single().Model.ToString();
    //}


    #endregion

    protected void drpPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        var q1 = from row in db.LabelDetailsPackings where row.GlassyNo == txtLotNos.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        if (q1.Count() > 0)
        {
            gvLabelDetails.DataSource = q1;
            gvLabelDetails.DataBind();
            btnClear.Visible = true;
        }
        else
        {
            var query = from row in db.MIinFQIs where row.GlassyNo == txtLotNos.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
            txtModel.Text = query.Single().Model;
            txtTotalQty.Text = query.Single().AcceptedQty.ToString();
            txtTumblingRef.Text = query.Single().TumblingRefNo;
            drpPower.SelectedValue = query.Single().Power.ToString();

            var query1 = from row in db.ModelMasters select row.SubModel;
            ddlSubModel.DataSource = query1;
            ddlSubModel.DataBind();

            gvLabelDetails.DataSource = null;
            gvLabelDetails.DataBind();

            btnSave.Visible = true;
            btnClear.Visible = true;
            ddlSubModel.Focus();
        }
    }
}