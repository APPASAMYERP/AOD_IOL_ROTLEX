using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
public partial class BlisterSealing : System.Web.UI.Page
{

    #region Declaration
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext Db = new SoftLensDataContext();
    #endregion

    #region Methods

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void Clear()
    {
        txtLotNo.Text = "";
        drpPower.SelectedValue = "--Select--";
        txtModelNo.Text = "";
        txtTotalQuantity.Text = "";
        txtReceivedQuantity.Text = "";
        txtProgQty.Text = "";
        txtBalanceQty.Text = "";
        txtAccpQty.Text = "";
        txtRejQty.Text = "";
        txtWipDnby0.Text = "";
        txtWipDnby.Text = "";
        txtDate.Text = "";

    }

    private void GridBind()
    {
        btnSave.Visible = false;
        var query = from row in Db.BlisterSealingTables where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        btnClear.Visible = true;
        gvSealingPro.DataSource = query;
        gvSealingPro.DataBind();

    }
    
    #endregion

    #region Events

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

    protected void txtGlassyNo_TextChanged(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        btnClear.Visible = true;
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        string tn = txtLotNo.Text;
        txtLotNo.Text = tn.ToUpper();

        
        var query = from row in Db.MIinFQIs where row.GlassyNo == txtLotNo.Text select row;
        
        if (query.Count() > 0)
        {
            
            drpPower.Focus();
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

    protected void txtReceivedQuantity_TextChanged(object sender, EventArgs e)
    {
        txtProgQty.Focus();
    }

    protected void txtProgQty_TextChanged(object sender, EventArgs e)
    {
        txtBalanceQty.Text = (Convert.ToInt32(txtReceivedQuantity.Text) - Convert.ToInt32(txtProgQty.Text)).ToString();
        txtAccpQty.Focus();
    }


    protected void txtAccpQty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAccpQty.Text) > Convert.ToInt32(txtTotalQuantity.Text))
        {
            Messagebox("Value is Greater than Total Qty");
            txtAccpQty.Text = "";
            txtAccpQty.Focus();
        }

        txtRejQty.Text = (Convert.ToInt32(txtProgQty.Text) - Convert.ToInt32(txtAccpQty.Text)).ToString();
        txtWipDnby0.Focus();
    }

    protected void txtWipDnby0_TextChanged(object sender, EventArgs e)
    {
        string s = txtWipDnby0.Text;
        txtWipDnby0.Text = s.ToUpper();
        txtWipDnby.Focus();
    }

    protected void txtWipDnby_TextChanged(object sender, EventArgs e)
    {
        string s1 = txtWipDnby.Text;
        txtWipDnby.Text = s1.ToUpper();

    }


    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
         try{
        if (txtReceivedQuantity.Text == "")
        {
            Messagebox("Please Enter Received Qty");
            txtReceivedQuantity.Focus();
        }
        else if (txtProgQty.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtProgQty.Focus();
        }
        else if (txtWipDnby.Text == "")
        {
            Messagebox("Please Enter Magnifier doneby ");
            txtWipDnby.Focus();
        }
        else if (txtWipDnby0.Text == "")
        {
            Messagebox("Please Enter Sealind doneby ");
            txtWipDnby.Focus();
        }

        else
        {
            var q = from x in Db.BlisterSealingTables where x.GlassyNo == txtLotNo.Text && x.Model == txtModelNo.Text && x.Power == Convert.ToDecimal(drpPower.SelectedValue) select x;
            if (q.Count() == 0)
            {
            BlisterSealingTable Bs = new BlisterSealingTable();
            Bs.GlassyNo = txtLotNo.Text;
            Bs.Model = txtModelNo.Text;
            Bs.Power = Convert.ToDecimal(drpPower.SelectedValue);
            Bs.TotalQty = Convert.ToInt32(txtTotalQuantity.Text);
            Bs.ReceivedQty = Convert.ToInt32(txtReceivedQuantity.Text);
            Bs.ProgressQty = Convert.ToInt32(txtProgQty.Text);
            Bs.BalanceQty = Convert.ToInt32(txtBalanceQty.Text);
            Bs.AcceptedQty = Convert.ToInt32(txtAccpQty.Text);
            Bs.RejectedQty = Convert.ToInt32(txtRejQty.Text);
            Bs.SealdoneBy = txtWipDnby0.Text;
            Bs.MagnidoneBy = txtWipDnby.Text;
            Bs.Date = Convert.ToDateTime(txtDate.Text, provider);
            Db.BlisterSealingTables.InsertOnSubmit(Bs);
            Db.SubmitChanges();
            Messagebox("Record Saved");
            GridBind();
            Clear();
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
        Clear();
        txtLotNo.Text = "";

        gvSealingPro.DataSource = null;
        gvSealingPro.DataBind();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;

    }

    #endregion

    protected void drpPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        var query1 = from row in Db.BlisterSealingTables where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        if (query1.Count() > 0)
        {
            GridBind();
        }
        else
        {
            var qury = from x in Db.MIinFQIs where x.GlassyNo == txtLotNo.Text && x.Power == Convert.ToDecimal(drpPower.SelectedValue) select x;
            var query = from r in Db.MIinFQIs where r.GlassyNo == txtLotNo.Text && r.Power == Convert.ToDecimal(drpPower.SelectedValue) select r;
            if (query.Count() > 0)
            {
                txtTotalQuantity.Text = query.Single().AcceptedQty.ToString();
                txtModelNo.Text = qury.Single().Model;
                gvSealingPro.DataSource = null;
                gvSealingPro.DataBind();
            }
            else
            {
                Messagebox("Choose valid Power");
            }
        }
    }
}
