using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using AjaxControlToolkit;

public partial class MIforCleanedLens : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Text = DateTime.Now.ToString("dd/MM/yyy");
        
        if (!IsPostBack)
        {
            Shift();
        }

        if (Session["Location"].ToString() == "Chennai")
        {
            txtLotNO.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtAcceptedQty.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            //txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            //txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtLotNO.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtAcceptedQty.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
        }
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

    private void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"Windows","alert('"+msg+"');",true);
    }

    private void clear()
    { 
       
        txtInspectedQty.Text = "";
        txtAcceptedQty.Text = "";
        txtRejectedQty.Text = "";
        //txtRejectedMtsNo.Text = "";
        txtInspectedBy.Text = "";
        txtApprovedBy.Text = "";
        ddlShift.Text = "Select";
        txtDate.Text = DateTime.Now.ToString("dd/MM/yyy");
        txtESC.Text = "0";
        txtTotal.Text = "0";
        txtChip.Text = "0";
        txtBurr.Text = "0";
        txtLB.Text = "0";
        txtSCR.Text = "0";
        txtThick.Text = "0";
        txtothers.Text = "0";
        txtOffset.Text = "0";
        txtCutting.Text = "0";
        //txtTumblingNo.Text = "";
    }


   
  
    protected void txtLotNO_TextChanged(object sender, EventArgs e)
    {
        clear();
        Shift();
        if (txtLotNO.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            MessageBox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNO.Text = "";
            txtLotNO.Focus();
        }
        else
        {
        //txtRejectedMtsNo.Enabled = false;
        var query = from rows in db.MillingCleanedLens where rows.LotNo == txtLotNO.Text select rows;
        if (query.Count() > 0)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
            txtInspectedQty.Text = query.Single().InspectedQuantity.ToString();
            txtAcceptedQty.Text = query.Single().AcceptedQuantity.ToString();
            txtRejectedQty.Text = query.Single().RejectedQty.ToString();
            //if (Convert.ToInt32(txtRejectedQty.Text) != 0)
            //{
            //    txtRejectedMtsNo.Enabled = true;
            //}
            //txtRejectedMtsNo.Text = query.Single().RejectionMTSNo.ToString();
            txtInspectedBy.Text = query.Single().Inspectedby.ToString();
            txtApprovedBy.Text = query.Single().Approvedby.ToString();
            ddlShift.Text = query.Single().Shift.ToString();
            txtDate.Text = query.Single().Date.ToString();
            txtESC.Text = query.Single().ESC.ToString();
            txtTotal.Text = query.Single().TotalRejQty.ToString();
            txtChip.Text = query.Single().CHIP.ToString();
            txtBurr.Text = query.Single().BURR.ToString();
            txtLB.Text = query.Single().LB.ToString();
            txtSCR.Text = query.Single().SCR.ToString();
            txtThick.Text = query.Single().THICK.ToString();
            txtothers.Text = query.Single().OTHERS.ToString();
            txtOffset.Text = query.Single().OFFSET.ToString();
            txtCutting.Text = query.Single().CUTTING.ToString();
            //txtTumblingNo.Text = query.Single().TumblingNo.ToString();
        }
        else
        {
            var query1 = (from row in db.DeBlockings  where row.LotNo == txtLotNO.Text select row.AcceptedQuantity).Sum();
            if (query1 == null)
            {
                MessageBox("No Value found in Previous Process Check LotNo ");
                txtLotNO.Text = "";
                txtLotNO.Focus();
            }
            else
            {

                txtInspectedQty.Text = query1.Value.ToString();
                btnSave.Visible = true;
                btnClear.Visible = true;
                btnUpdate.Visible = false;
                txtAcceptedQty.Focus();
            }
        }
    }
    }
    protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
    {
        txtESC.Text = "0";
        txtTotal.Text = "0";
        txtChip.Text = "0";
        txtBurr.Text = "0";
        txtLB.Text = "0";
        txtSCR.Text = "0";
        txtThick.Text = "0";
        txtothers.Text = "0";
        txtOffset.Text = "0";
        txtCutting.Text = "0";
        if (Convert.ToInt32(txtAcceptedQty.Text) > Convert.ToInt32(txtInspectedQty.Text))
        {
            MessageBox("Accepted Qty is greater than Inspected qty");
            txtAcceptedQty.Text = "";
            txtAcceptedQty.Focus();
        }
        else
        {
        txtRejectedQty.Text = Convert.ToString(Convert.ToInt32(txtInspectedQty.Text ) - Convert.ToInt32(txtAcceptedQty.Text));
        txtInspectedBy.Focus();
        //if (txtRejectedQty.Text != "0")
        //{
        //    txtRejectedMtsNo.Enabled = true;
        //    txtRejectedMtsNo.Focus();
        //}

        }
    }
    protected void txtTotal_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
    }


    protected void txtSCR_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        txtLB.Focus();
    }
    protected void txtESC_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        txtSCR.Focus();
    }
    protected void txtLB_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        txtChip.Focus();
    }
    protected void txtChip_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        txtBurr.Focus();
    }
    protected void txtBurr_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        txtThick.Focus();
    }

    protected void txtThick_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        btnSave.Focus();
        btnUpdate.Focus();
    }
    protected void txtothers_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        btnSave.Focus();
        btnUpdate.Focus();
    }
    protected void txtOffset_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        btnSave.Focus();
        btnUpdate.Focus();
    }
    protected void txtCutting_TextChanged(object sender, EventArgs e)
    {
        txtTotal.Text = Convert.ToString(Convert.ToInt32(txtESC.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtChip.Text) + Convert.ToInt32(txtBurr.Text) + Convert.ToInt32(txtThick.Text) + Convert.ToInt32(txtothers.Text) + Convert.ToInt32(txtOffset.Text) + Convert.ToInt32(txtCutting.Text));
        btnSave.Focus();
        btnUpdate.Focus();
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        try{
        if (txtRejectedQty.Text != txtTotal.Text)
        {
            MessageBox("Total Rejected Qty Does Not Match");
            
        }
        else if (txtInspectedBy.Text == "")
        {
            MessageBox("Please Enter Inspected By");
            txtInspectedBy.Focus();
        }
        else if (txtApprovedBy.Text == "")
        {
            MessageBox("Please Enter Approved By");
            txtApprovedBy.Focus();
        }
      
        else
        {
            MillingCleanedLen milTable = new MillingCleanedLen()
            {
                LotNo = txtLotNO.Text,
                InspectedQuantity = Convert.ToInt32(txtInspectedQty.Text),
                AcceptedQuantity = Convert.ToInt32(txtAcceptedQty.Text),
                RejectedQty = Convert.ToInt32(txtRejectedQty.Text),
                //RejectionMTSNo = txtRejectedMtsNo.Text,
                Inspectedby = txtInspectedBy.Text,
                Approvedby = txtApprovedBy.Text,
                Shift = ddlShift.SelectedValue,
                Date = Convert.ToDateTime(txtDate.Text,provider),
                ESC = Convert.ToInt32(txtESC.Text),
                TotalRejQty = Convert.ToInt32(txtTotal.Text),
                CHIP = Convert.ToInt32(txtChip.Text),
                BURR = Convert.ToInt32(txtBurr.Text),
                LB = Convert.ToInt32(txtLB.Text),
                SCR = Convert.ToInt32(txtSCR.Text),
                THICK = Convert.ToInt32(txtThick.Text),
                OTHERS = Convert .ToInt32(txtothers.Text),
                OFFSET=Convert.ToInt32(txtOffset.Text),
                CUTTING=Convert.ToInt32(txtCutting.Text),
                //TumblingNo = txtTumblingNo.Text
            };
            db.MillingCleanedLens.InsertOnSubmit(milTable);
            db.SubmitChanges();
            MessageBox("Records Saved");
            clear();
            txtLotNO.Text = "";
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
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
   
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (txtRejectedQty.Text != txtTotal.Text)
        {
            MessageBox("Total Rejected Qty Does Not Match");
            
        }
        else if (txtInspectedBy.Text == "")
        {
            MessageBox("Please Enter Inspected By");
            txtInspectedBy.Focus();
        }
        else if (txtApprovedBy.Text == "")
        {
            MessageBox("Please Enter Approved By");
            txtApprovedBy.Focus();
        }
        //else if (txtTumblingNo.Text == "")
        //{
        //    MessageBox("Please Enter TumblingNo");
        //    txtTumblingNo.Focus();
        //}
        //else if (txtRejectedQty.Text != "0" && txtRejectedMtsNo.Text=="")
        //{
        //    MessageBox("Please Enter the RejMTS No");
        //    txtRejectedMtsNo.Focus();
        //}
        else if (txtRejectedQty.Text == txtTotal.Text)
        {
            var obj = db.MillingCleanedLens.Single(r => r.LotNo == txtLotNO.Text);

            obj.InspectedQuantity = Convert.ToInt32(txtInspectedQty.Text);
            obj.AcceptedQuantity = Convert.ToInt32(txtAcceptedQty.Text);
            obj.RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
            
            //obj.RejectionMTSNo = txtRejectedMtsNo.Text;
            obj.Inspectedby = txtInspectedBy.Text;
            obj.Approvedby = txtApprovedBy.Text;
            obj.Shift = ddlShift.SelectedValue;
            obj.Date = Convert.ToDateTime(txtDate.Text, provider);
            obj.ESC = Convert.ToInt32(txtESC.Text);
            obj.TotalRejQty = Convert.ToInt32(txtTotal.Text);
            obj.CHIP = Convert.ToInt32(txtChip.Text);
            obj.BURR = Convert.ToInt32(txtBurr.Text);
            obj.LB = Convert.ToInt32(txtLB.Text);
            obj.SCR = Convert.ToInt32(txtSCR.Text);
            obj.THICK = Convert.ToInt32(txtThick.Text);
            obj.OTHERS = Convert.ToInt32(txtothers.Text);
            obj.OFFSET = Convert.ToInt32(txtOffset.Text);
            obj.CUTTING = Convert.ToInt32(txtCutting.Text);
            //obj.TumblingNo = txtTumblingNo.Text;
            db.SubmitChanges();
            MessageBox("Records Updateds");
            clear();
            txtLotNO.Text = "";
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
        }
        else
        {
            MessageBox("Total Rejected Qty Does Not Match");
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNO.Text = "";
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
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
                MessageBox("Please Enter With INITIAL ex: M.BALAJI");
                txtInspectedBy.Text = "";
                txtInspectedBy.Focus();
            }
        }
        catch
        {
            MessageBox("Please Enter InspectedBy With INITIAL ex: M.BALAJI");
            txtInspectedBy.Text = "";
            txtInspectedBy.Focus();
        }
        txtApprovedBy.Focus();
    }
    protected void txtApprovedBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtApprovedBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtApprovedBy.Text = up.ToUpper();
            }
            else
            {
                MessageBox("Please Enter ApprovedBy With INITIAL ex: M.BALAJI");
                txtApprovedBy.Text = "";
                txtApprovedBy.Focus();

            }
        }
        catch
        {
            MessageBox("Please Enter ApprovedBy With INITIAL ex: M.BALAJI");
            txtApprovedBy.Text = "";
            txtApprovedBy.Focus();
        }
    }

    //protected void txtTumblingNo_TextChanged(object sender, EventArgs e)
    //{
    //    SoftLensDataContext db = new SoftLensDataContext();
    //    if (txtTumblingNo.Text.Length < 8)
    //    {
    //        MessageBox("Enter  the 8 digit No ex: T1007001 ");
    //        txtTumblingNo.Text = "";
    //        txtTumblingNo.Focus();
    //    }
    //    else
    //    {
    //        string lot = txtTumblingNo.Text;
    //        string yr = System.DateTime.Now.ToString("yy");
    //        string mon = System.DateTime.Now.ToString("MM");
    //        if ((lot[0] == 't' || lot[0] == 'T') && (lot.Substring(1, 2) == yr && lot.Substring(6, 2) == mon))
    //        {
                
    //        }
    //        else if ((lot[0] >= 48 && lot[5] <= 57) && (lot[6] >= 48 && lot[6] <= 57) && (lot[7] >= 48 && lot[7] <= 57))
    //        {
    //            txtTumblingNo.Text = lot.ToUpper();
    //        }
    //        else
    //        {
    //            MessageBox("Enter In correct Format ex: T1007001 ");
    //            txtTumblingNo.Text = "";
    //            txtTumblingNo.Focus();
    //        }
           
    //        var query = from row in db.MillingCleanedLens where row.TumblingNo == txtTumblingNo.Text select row.LotNo;
    //        if (query.Count() >= 8)
    //        {
    //            btnSave.Enabled = false;
    //            MessageBox("TumblingNO Exceeds the Limit");
    //        }
    //        else
    //        {
    //            btnSave.Enabled = true;
    //        }
    //    }
    //}
   
}
