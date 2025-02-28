using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class PickPacking : System.Web.UI.Page
{


    #region Declaration
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext Db = new SoftLensDataContext();
    #endregion



    #region Methods

    protected void clear()
    {

        txtLotNo.Text = "";
        txtModelNo.Text = "";
        txtTotalQuantity.Text = "";
        drpPower.SelectedValue = "--Select--";
        txtReceivedQty.Text = "";
        txtProgressingQty.Text = "";
        txtBalanceQty.Text = "";
        txtAcceptedQty.Text = "";
        txtRejectedQty.Text = "";
        txtTumblingRef.Text = "";
        txtRemarks.Text = "";
        txtpickpackby.Text = "";
        txtDate.Text = "";


    }

    private void GridBind()
    {
        btnSave.Visible = false;
        var query = from row in Db.Pick_Packings where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        btnClear.Visible = true;
        gvPickpacking.DataSource = query;
        gvPickpacking.DataBind();

    }


    #endregion



    #region events

    protected void Page_Load(object sender, EventArgs e)
    {
        var username = (Session["Username"] as HtmlInputControl).Value;

        if (username == null)
        {
            Response.Redirect("404Page.aspx");
        }
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        //txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }


    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        btnClear.Visible = true;
        txtDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

        string tn = txtLotNo.Text;
        txtLotNo.Text = tn.ToUpper();

        var query = from row in Db.LensWipings where row.GlassyNo == txtLotNo.Text select row;
        if (query.Count() > 0)
        {
            //txtModelNo.Text = query.Single().Model;
            //txtTotalQuantity.Text = query.Single().AcceptedQty.ToString();
            //txtPower.Text = query.Single().Power.ToString();
            //txtTumblingRef.Text = query.Single().TumblingNo.ToString();
            var seg = from a in Db.PowerSegregationChilds
                      where a.TumblingNo == txtLotNo.Text
                      select a;
            drpPower.Items.Clear();
            drpPower.Items.Add("--Select--");
            drpPower.DataSource = seg;
            drpPower.DataTextField = "Power";
            drpPower.DataValueField = "Power";
            drpPower.DataBind();

        }
        else
        {
            Messagebox("Enter Valid Lot No");
            txtLotNo.Text = "";
            txtLotNo.Focus();
            btnClear.Visible = false;
            btnSave.Visible = false;

        }
    }
    protected void txtProgressingQty_TextChanged(object sender, EventArgs e)
    {

        txtBalanceQty.Text = (Convert.ToInt32(txtReceivedQty.Text) - Convert.ToInt32(txtProgressingQty.Text)).ToString();
        txtAcceptedQty.Focus();

    }

    protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
    {
        txtRejectedQty.Text = (Convert.ToInt32(txtProgressingQty.Text) - Convert.ToInt32(txtAcceptedQty.Text)).ToString();
        txtRemarks.Focus();

    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string tn = txtRemarks.Text;
        txtRemarks.Text = tn.ToUpper();
        txtpickpackby.Focus();

    }

    protected void txtpickpackby_TextChanged(object sender, EventArgs e)
    {
        string tn = txtpickpackby.Text;
        txtpickpackby.Text = tn.ToUpper();

    }


    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try{
        if (txtReceivedQty.Text == "")
        {
            Messagebox("Please Enter Received Qty");
            txtReceivedQty.Focus();
        }
        else if (txtProgressingQty.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtProgressingQty.Focus();
        }
        else if (txtpickpackby.Text == "")
        {
            Messagebox("Please Enter pickpacking  doneby ");
            txtpickpackby.Focus();
        }
        else
        {
              var q = from x in Db.Pick_Packings where x.GlassyNo == txtLotNo.Text && x.Model == txtModelNo.Text && x.Power == Convert.ToDecimal(drpPower.SelectedValue) select x;
            if (q.Count() == 0)
            {
            Pick_Packing pp = new Pick_Packing();
            pp.GlassyNo = txtLotNo.Text;
            pp.Model = txtModelNo.Text;
            pp.TotalQuantity = Convert.ToInt32(txtTotalQuantity.Text);
            pp.Power = Convert.ToDecimal(drpPower.SelectedValue);
            pp.ReceivedQty = Convert.ToInt32(txtReceivedQty.Text);
            pp.ProgressingQty = Convert.ToInt32(txtProgressingQty.Text);
            pp.BalanceQty = Convert.ToInt32(txtBalanceQty.Text);
            pp.AcceptedQty = Convert.ToInt32(txtAcceptedQty.Text);
            pp.RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
            pp.TumblingNo = txtTumblingRef.Text;
            pp.Remarks = txtRemarks.Text;
            pp.PickpackingBy = txtpickpackby.Text;
            pp.Date = Convert.ToDateTime(txtDate.Text, provider);
            Db.Pick_Packings.InsertOnSubmit(pp);
            Db.SubmitChanges();
            Messagebox("Saved Succefully");
            clear();
            btnSave.Visible = false;
            btnClear.Visible = false;
            }
            else
            {
                Messagebox("Lot Number Already Exists..");
            }
        }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }

    }


    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        gvPickpacking.DataSource = null;
        gvPickpacking.DataBind();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    #endregion

    protected void drpPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        var query1 = from row in Db.Pick_Packings where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        

        if (query1.Count() > 0)
        {
            GridBind();

        }
        else
        {

            var query = from r in Db.LensWipings where r.TumblingNo == txtLotNo.Text && r.Power == Convert.ToDecimal(drpPower.SelectedValue) select r;
            var qury = from x in Db.PowerSegregationChilds where x.TumblingNo == txtLotNo.Text && x.Power == Convert.ToDecimal(drpPower.SelectedValue) select x;
            if (qury.Count() > 0)
            {
                txtTumblingRef.Text = query.Single().TumblingNo;
                txtTotalQuantity.Text = qury.Single().Qty.ToString();
                txtModelNo.Text = query.Single().Model;
            }
            else
            {
                Messagebox("Power Value Doesn't Exists");
            }
        }
    }
}
