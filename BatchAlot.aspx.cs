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
using System.Text.RegularExpressions;

public partial class BatchAlot : System.Web.UI.Page
{
    #region Declarations
    SoftLensDataContext SL = new SoftLensDataContext();
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    private string _lot;
    private string _yr;
    private string _month;
    #endregion Declarations

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {

        Shift();
        _lot = txtLotNo.Text.Trim();
        _yr = System.DateTime.Now.ToString("yy");
        _month = System.DateTime.Now.ToString("MM");
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        if (Session["Location"].ToString() == "Chennai")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtAllotedQty.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            txtWaxId.MaxLength = Convert.ToInt32(Session["WaxNoMaxLength"]);
            //txtWaxId_FilteredTextBoxExtender.FilterType = FilterTypes.Numbers;
            //txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            //txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtAllotedQty.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            txtWaxId.MaxLength = Convert.ToInt32(Session["WaxNoMaxLength"]);
            //txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            //txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //txtWaxId_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            //txtWaxId_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
    }

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        gvBatchAllot.DataSource = null;
        gvBatchAllot.DataBind();

        if (txtLotNo.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            Messagebox("Enter " + Convert.ToInt32(Session["LotNoMaxLength"]) + " digit No In correct Format ex: PH" + _yr + _month + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }
        else
        {
            try
            {
                Clear();
                Shift();
                btnClear.Visible = true;
                btnSave.Visible = true;
                Modelmasters();
               /* Validation to check if the LotNo starts with Year & Month Order*/

                //if (lot.Substring(0, 2) == _yr && lot.Substring(2, 2) == _month)
                //{
                //}
                //else
                //{
                //    Messagebox("Enter In correct Format ex:10070001 ");
                //    txtLotNo.Text = "";
                //    txtLotNo.Focus();
                //}

                PowerMaster();
                //txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                

                GridVisibility();
            }
            catch (Exception ex)
            {

            }
        }
        txtDate.Focus();
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            try
            {
                SaveMethod();
            }
            catch (Exception)
            {
                Clear();
            }
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            try
            {
                UpdateMethod();
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void btnClear_Click1(object sender, ImageClickEventArgs e)
    {

        Clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
        gvBatchAllot.DataSource = null;
        gvBatchAllot.DataBind();
    }

    protected void txtAllotedQty_TextChanged(object sender, EventArgs e)
    {
        if (txtAllotedQty.Text.Trim() != "")
        {
            if (Convert.ToInt32(txtAllotedQty.Text) > Convert.ToInt64(Session["AllotededQty"]) ||
                Convert.ToInt32(txtAllotedQty.Text) <= 0)
            {
                Messagebox("Enter within the range " + Session["AllotededQty"] + "");
                txtAllotedQty.Text = "";
                txtAllotedQty.Focus();
            }
            else
            {
                ddlPower.Focus();
            }
        }
    }

    //protected void txtWaxId_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string wax = txtWaxId.Text.Trim();
    //        if (wax != "" && Session["Location"].ToString() == "Pondicherry")
    //        {
    //            WaxIdValidationForPondicherry(wax);
    //        }
    //    }
    //    catch
    //    {
    //        txtWaxId.Text = "";
    //        txtWaxId.Focus();
    //    }
    //}

    protected void txtApprovedBy_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string up = txtApprovedBy.Text;

            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtApprovedBy.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter INITIAL ex: M.BALAJI");
                txtApprovedBy.Text = "";
                txtApprovedBy.Focus();

            }
            
        }
        catch
        {
            Messagebox("Please Enter INITIAL ex: M.BALAJI");
            txtApprovedBy.Text = "";
            txtApprovedBy.Focus();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            var query = from row in SL.PowerMasters where row.Power == Convert.ToDecimal(ddlPower.Text) select row;
            txtRadius.Text = query.Single().Radius1.ToString();
            txtWaxId.Text = query.Single().Radius2.ToString();
            txtApprovedBy.Focus();
            //txtWaxId.Focus();

        }
        catch
        {
            Messagebox("Power value does not Exits - Enter in the format 11.50 0r 12.00");
            ddlPower.Text = "";
            ddlPower.Focus();
        }
    }

    protected void txtBatchNo_TextChanged(object sender, EventArgs e)
    {
        string bat = txtBatchNo.Text;
        txtBatchNo.Text = bat.ToUpper();

    }
    
    protected void gvBatchAllot_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["up"].Equals(1))
        {
            txtDate.Text = gvBatchAllot.SelectedRow.Cells[1].Text;
            txtLotNo.Text = gvBatchAllot.SelectedRow.Cells[2].Text;
            ddlModelNo.Text = gvBatchAllot.SelectedRow.Cells[3].Text;
            ddlPower.Text = gvBatchAllot.SelectedRow.Cells[4].Text;
            txtRadius.Text = gvBatchAllot.SelectedRow.Cells[5].Text;
            txtBatchNo.Text = gvBatchAllot.SelectedRow.Cells[6].Text;
            txtWaxId.Text = gvBatchAllot.SelectedRow.Cells[7].Text;
            txtAllotedQty.Text = gvBatchAllot.SelectedRow.Cells[8].Text;
            ddlShift.Text = gvBatchAllot.SelectedRow.Cells[9].Text;
            txtApprovedBy.Text = gvBatchAllot.SelectedRow.Cells[10].Text;
            btnUpdate.Visible = true;
        }
        else
        {
            Messagebox("Permission is Denied to perform this process");
        }
    }
    #endregion Events

    #region Methods
    private void Clear()
    {

        //txtDate.Text = "";
        ddlModelNo.Text = "Select";
        ddlShift.Text = "Select";
        txtAllotedQty.Text = "";
        txtWaxId.Text = "";
        txtRadius.Text = "";
        ddlPower.Text = "Select";
        txtBatchNo.Text = "";
        txtRadius.Text = "";
        txtApprovedBy.Text = "";
    }

    private void Shift()
    {
        String time = DateTime.Now.Hour.ToString();

        if (Convert.ToInt32(time) >= 6 && Convert.ToInt32(time) <= 13)
        {
            ddlShift.SelectedIndex = 1;

        }
        if (Convert.ToInt32(time) >= 14 && Convert.ToInt32(time) <= 22)
        {
            ddlShift.SelectedIndex = 2;

        }
        if (Convert.ToInt32(time) >= 22 && Convert.ToInt32(time) <= 5)
        {
            ddlShift.SelectedIndex = 3;

        }
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private bool Validation()
    {
        bool _isvalid = true;
        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter Lot No");
            txtLotNo.Focus();
            _isvalid = false;
        }
        else if (txtBatchNo.Text == "")
        {
            Messagebox("Please Enter Batch No");
            txtBatchNo.Focus();
            _isvalid = false;
        }
        else if (ddlModelNo.Text == "Select")
        {
            Messagebox("Please Choose Model No");
            ddlModelNo.Focus();
            _isvalid = false;
        }
        else if (txtAllotedQty.Text == "" || txtAllotedQty.Text == "0")
        {
            Messagebox("Please Enter Alloted Qty");
            txtAllotedQty.Focus();
            _isvalid = false;
        }
        else if (ddlPower.Text == "")
        {
            Messagebox("Please Choose Power");
            ddlPower.Focus();
            _isvalid = false;
        }
        else if (txtWaxId.Text == "")
        {
            Messagebox("Please Enter WaxID");
            txtWaxId.Focus();
            _isvalid = false;
        }
        else if (txtApprovedBy.Text == "")
        {
            Messagebox("Please Enter ApprovedBy");
            txtApprovedBy.Focus();
            _isvalid = false;
        }
        else if (txtDate.Text == "")
        {
            Messagebox("Please Enter Date");
            txtDate.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }

    private void Submitchangescompled()
    {
        Clear();
        var qgv = from f in SL.BatchAllots where f.LotNo == txtLotNo.Text select f;
        if (qgv.Count() > 0)
        {
            gvBatchAllot.DataSource = qgv;
            gvBatchAllot.DataBind();

            btnSave.Visible = false;
            btnClear.Visible = true;
        }
        txtLotNo.Text = "";
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnClear.Visible = true;
    }

    private void GridVisibility()
    {
        var qgv = from f in SL.BatchAllots where f.LotNo == txtLotNo.Text select f;
        if (qgv.Count() > 0)
        {
            if (Session["up"].Equals(1))
            {
                gvBatchAllot.Columns[0].Visible = true;
            }
            gvBatchAllot.DataSource = qgv;
            gvBatchAllot.DataBind();

            btnSave.Visible = false;
            btnClear.Visible = true;
        }
        else
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
    }

    private void Modelmasters()
    {
        ddlModelNo.Items.Clear();
        ddlModelNo.Items.Add("Select");
        var qu = (from r in SL.ModelMasters select r.Model).Distinct();
        ddlModelNo.DataSource = qu;
        ddlModelNo.DataBind();
    }

    private void PowerMaster()
    {
        ddlPower.Items.Clear();
        ddlPower.Items.Add("Select");
        var pwr = from a in SL.PowerMasters select a.Power;
        ddlPower.DataSource = pwr;
        ddlPower.DataBind();
    }


    private void WaxIdValidationForPondicherry(string wax)
    {
        if (wax.Length < 6)
        {
            Messagebox("Enter in format ex: 622A10(or) 622B10 (or) 622C10 ");
            txtWaxId.Text = "";
            txtWaxId.Focus();
        }
        else
        {
            if (wax[0] == '6' && wax[1] == '2' && wax[2] == '2' && wax[3] >= 65 && wax[3] <= 122 && (wax[4] >= 48 && wax[4] <= 57) && (wax[5] >= 48 && wax[5] <= 57))
            {
                txtWaxId.Text = wax.ToUpper();
                txtApprovedBy.Focus();
            }
            else
            {
                Messagebox("Enter in format ex: 622A10 (or) 622B10 (or) ex: 622C10");
                txtWaxId.Text = "";
                txtWaxId.Focus();
            }

/* Validation for the Last two Characters that must Match with the Current Year */

            //string yr = System.DateTime.Now.ToString("yy");
            //if (wax.Substring(4, 2) == yr)
            //{
            //    txtApprovedBy.Focus();
            //}
            //else
            //{
            //    Messagebox("Enter in format ex: 622A10 (or) 622B10 ");
            //    txtWaxId.Text = "";
            //    txtWaxId.Focus();
            //}
        }
    }

    private void SaveMethod()
    {
        //bool FoundMatch = false;
        //if(ddlModelNo.Text.Contains("HPNT200Y"))
        //{
        //    FoundMatch = Regex.IsMatch(txtLotNo.Text, "^[pP][hH][yY][0-9]{8}$");
        //      if (FoundMatch == true)
        //      {
                  BatchAllot ab = new BatchAllot();
                  ab.LotNo = txtLotNo.Text;
                  ab.Date = Convert.ToDateTime(txtDate.Text, provider);
                  ab.ModelNo = ddlModelNo.Text;
                  ab.AllotedQuantity = Convert.ToInt32(txtAllotedQty.Text);
                  ab.WaxId = txtWaxId.Text;
                  ab.BatchNo = txtBatchNo.Text;
                  ab.Power = Convert.ToDecimal(ddlPower.Text);
                  ab.Radius = Convert.ToDecimal(txtRadius.Text);
                  ab.Shift = ddlShift.Text;
                  ab.ApprovedBy = txtApprovedBy.Text;
                  SL.BatchAllots.InsertOnSubmit(ab);
                  SL.SubmitChanges();
                  Messagebox("Saved Successfully");
                  Submitchangescompled();
              //}
       //       else
       //       {
       //           Messagebox("Warning! Model No & Lotno Format does not Match");
       //       }
       //}
       // else if (ddlModelNo.Text.Contains("HPNT200"))
       // {
       //     FoundMatch = Regex.IsMatch(txtLotNo.Text, "^[pP][hH][0-9]{8}$");
       //     if (FoundMatch == true)
       //     {
       //         BatchAllot ab = new BatchAllot();
       //         ab.LotNo = txtLotNo.Text;
       //         ab.Date = Convert.ToDateTime(txtDate.Text, provider);
       //         ab.ModelNo = ddlModelNo.Text;
       //         ab.AllotedQuantity = Convert.ToInt32(txtAllotedQty.Text);
       //         ab.WaxId = txtWaxId.Text;
       //         ab.BatchNo = txtBatchNo.Text;
       //         ab.Power = Convert.ToDecimal(ddlPower.Text);
       //         ab.Radius = Convert.ToDecimal(txtRadius.Text);
       //         ab.Shift = ddlShift.Text;
       //         ab.ApprovedBy = txtApprovedBy.Text;
       //         SL.BatchAllots.InsertOnSubmit(ab);
       //         SL.SubmitChanges();
       //         Messagebox("Saved Successfully");
       //         Submitchangescompled();
       //     }
       //     else
       //     {
       //         Messagebox("Warning! Model No & Lotno Format does not Match");
       //     }
       // }
        
    }

    private void UpdateMethod()
    {
        var q = from f in SL.BatchAllots where f.LotNo == txtLotNo.Text select f;
        if (q.Count() > 0)
        {
            q.Single().LotNo = txtLotNo.Text;
            q.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
            q.Single().ModelNo = ddlModelNo.Text;
            q.Single().AllotedQuantity = Convert.ToInt16(txtAllotedQty.Text);
            q.Single().Shift = ddlShift.Text;
            q.Single().WaxId = Convert.ToString(txtWaxId.Text);
            q.Single().BatchNo = Convert.ToString(txtBatchNo.Text);
            q.Single().Power = Convert.ToDecimal(ddlPower.Text);
            q.Single().Radius = Convert.ToDecimal(txtRadius.Text);
            q.Single().ApprovedBy = txtApprovedBy.Text;
            SL.SubmitChanges();

            Messagebox("Updated  Successfully");
            Submitchangescompled();
        }
        txtLotNo.Enabled = true;
    }
    #endregion Methods


    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

    }
}