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
using AjaxControlToolkit;

public partial class ReportTrail : System.Web.UI.Page
{
    #region Declarations
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext SL = new SoftLensDataContext();
    int temp;
    #endregion

    #region Methods

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void clear()
    {
        txtLotNo.Text = "";
        txtTumblingNo.Text = "";
        txtModelNo.Text = "";
        drpPower.SelectedValue = "--Select--";
        txtTotalQty.Text = "";
        txtDate.Text = "";
        txtAcceptedQty.Text = "";
        txtRetumblingQty.Text = "0";
        txtRejectedQty.Text = "";
        txtRemarks.Text = "";
        txtApprovedBy.Text = "";

    }

    protected void txtJarNo_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string re = txtRemarks.Text;
        txtRemarks.Text = re.ToUpper();

    }

    protected void txtApprovedBy_TextChanged(object sender, EventArgs e)
    {
        string a = txtApprovedBy.Text;
        txtApprovedBy.Text = a.ToUpper();

    }

    protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
    {

        if (Convert.ToInt32(txtAcceptedQty.Text) > Convert.ToInt32(txtTotalQty.Text))
        {
            Messagebox("Value is Greater than Total Qty");
            txtAcceptedQty.Text = "";
            txtAcceptedQty.Focus();
        }
        else
        {

        }

    }

    protected void txtRetumblingQty_TextChanged1(object sender, EventArgs e)
    {

        if (Convert.ToInt32(txtRetumblingQty.Text) > Convert.ToInt32(txtAcceptedQty.Text))
        {
            Messagebox("Value is Greater than Accepted Qty");
            txtRetumblingQty.Text = "";
            txtRetumblingQty.Focus();
        }
        else
        {
            if (txtRetumblingQty.Text != "0")
            {
                txtRejectedQty.Text = (Convert.ToInt32(txtTotalQty.Text) - (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumblingQty.Text))).ToString();
            }
            else
            {
                txtRejectedQty.Text = (Convert.ToInt32(txtTotalQty.Text) - (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumblingQty.Text))).ToString();

            }

        }

    }

    private void GridBind()
    {
        var q = from a in SL.FirstRetumblingReports where a.GlassyNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPower.SelectedValue) select a;
        gvPackingReports.DataSource = q;
        gvPackingReports.DataBind();

    }

    private bool validation1()
    {
        bool _isvalid = true;
        if (txtLotNo.Text == "")
        {
            Messagebox("Please enter Glassy Tumbling Ref No");
            txtLotNo.Focus();
            _isvalid = false;
        }
       
        else if (txtAcceptedQty.Text == "")
        {
            Messagebox("Please enter Accepted Qty");
            txtAcceptedQty.Focus();
            _isvalid = false;
        }
        else if (txtRetumblingQty.Text == "")
        {
            Messagebox("Please enter Retumbling Qty");
            txtRetumblingQty.Focus();
            _isvalid = false;
        }
        else if (txtRejectedQty.Text == "")
        {
            Messagebox("Please Enter the Rejected Qty");
            txtRejectedQty.Focus();
            _isvalid = false;
        }
        else if (txtApprovedBy.Text == "")
        {
            Messagebox("Please enter the Approved By");
            txtApprovedBy.Focus();
            _isvalid = false;
        }

        return _isvalid;

    }
  protected void txtGlassyNo_TextChanged(object sender, EventArgs e)
    {
        string t = txtLotNo.Text;
        txtLotNo.Text = t.ToUpper();


        var seg = from a in SL.PowerSegregationChilds
                  where a.TumblingNo == txtLotNo.Text
                  select a;
        drpPower.Items.Clear();
        drpPower.Items.Add("--Select--");
        drpPower.DataSource = seg;
        drpPower.DataTextField = "Power";
        drpPower.DataValueField = "Power";
        drpPower.DataBind();
    }
  private void SaveMethod()
    {
        FirstRetumblingReport fr = new FirstRetumblingReport();
        fr.GlassyNo = txtLotNo.Text;
        fr.TumblingNo = txtTumblingNo.Text;
        fr.Model = txtModelNo.Text;
        fr.Power = Convert.ToDecimal(drpPower.SelectedValue);
        fr.TotalQty = Convert.ToInt32(txtTotalQty.Text);
        fr.Date = Convert.ToDateTime(txtDate.Text);
    
        fr.AcceptedQty = Convert.ToInt32(txtAcceptedQty.Text);
        fr.RetumblingQty = Convert.ToInt32(txtRetumblingQty.Text);
        fr.RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
        
        fr.Remarks = txtRemarks.Text;
        fr.ApprovedBy = txtApprovedBy.Text;

        SL.FirstRetumblingReports.InsertOnSubmit(fr);
        SL.SubmitChanges();
        btnSave.Visible = false;
        Messagebox("Saved Successfully");
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

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        SaveMethod();
        GridBind();
        clear();
        btnClear.Visible = false;
        txtLotNo.Text = "";
    }

    protected void btnClear_Click1(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
        gvPackingReports.DataSource = null;
        gvPackingReports.DataBind();
    }

    protected void txtRetumblingQty_TextChanged(object sender, EventArgs e)
    {

        txtRejectedQty.Text = (Convert.ToInt32(txtTotalQty.Text) - (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumblingQty.Text))).ToString();
        temp = Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumblingQty.Text) + Convert.ToInt32(txtRejectedQty.Text);
        if (txtTotalQty.Text != temp.ToString())
        {
            Messagebox("Value exceeds Total Quantity");
        }



    }

    #endregion

    protected void drpPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        var query3 = from row in SL.FirstRetumblingReports where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        if (query3.Count() > 0)
        {
            gvPackingReports.DataSource = query3;
            gvPackingReports.DataBind();
            btnSave.Visible = false;
            btnClear.Visible = true;
        }
        else
        {
            var query = from row in SL.MIinFQIs where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
            if (query.Count() > 0)
            {
                txtTumblingNo.Text = query.Single().TumblingRefNo;
                txtModelNo.Text = query.Single().Model;
                drpPower.SelectedValue = query.Single().Power.ToString();
                txtTotalQty.Text = query.Single().TotalQty.ToString();
                txtDate.Text = query.Single().Date.Value.ToShortDateString();
                txtAcceptedQty.Text = query.Single().AcceptedQty.ToString();
                txtRetumblingQty.Text = query.Single().RetumblingQty.ToString();
                txtRejectedQty.Text = query.Single().RejectedQty.ToString();
                txtRemarks.Text = query.Single().Remarks;
                txtApprovedBy.Text = query.Single().ApprovedBy;
            }
            gvPackingReports.DataSource = null;
            gvPackingReports.DataBind();
            btnSave.Visible = true;
            btnClear.Visible = true;
        }
        
    }
}
