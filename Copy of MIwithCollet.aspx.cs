using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class MIwithCollet : System.Web.UI.Page
{

    #region Declarations
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    #endregion Declarations

    #region Methods
    private bool Validation()
    {
        bool _isvalid = true;
        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter Lot No ");
            txtLotNo.Focus();
            _isvalid = false;
        }
        else if (txtFinishedQuantity.Text == "")
        {
            Messagebox("Please Enter Finished Qty ");
            txtFinishedQuantity.Focus();
            _isvalid = false;
        }
        else if (txtAcceptedQuantity.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtAcceptedQuantity.Focus();
            _isvalid = false;
        }

        else if (txtBlockedBy.Text == "")
        {
            Messagebox("Please Enter Blocked By ");
            txtBlockedBy.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }


    private void Shift()
    {
        String time = DateTime.Now.Hour.ToString();

        if (Convert.ToInt32(time) >= 6 && Convert.ToInt32(time) <= 13)
        {
            drpShift.SelectedIndex = 1;
        }
        if (Convert.ToInt32(time) >= 14 && Convert.ToInt32(time) <= 22)
        {
            drpShift.SelectedIndex = 2;
        }
        if (Convert.ToInt32(time) >= 22 && Convert.ToInt32(time) <= 5)
        {
            drpShift.SelectedIndex = 3;
        }
    }

    protected void Clear()
    {
        txtBlockedBy.Text = "";
        txtDate.Text = "";

        txtBalanceQuantity.Text = "";
        txtReceivedQuantity.Text = "";
        txtFinishedQuantity.Text = "";
        txtRemarks.Text = "";
        txtRejectedQuantity.Text = "";
        txtAcceptedQuantity.Text = "";

        drpShift.SelectedValue = "Select";
        txtRejectedMtsNo.Text = "";
        gvBlocking.DataSource = null;
        gvBlocking.DataBind();
        txtLotNo.Enabled = true;
    }

    protected void Gclear()
    {
        txtBlockedBy.Text = "";
        txtDate.Text = "";

        txtBalanceQuantity.Text = "";
        txtReceivedQuantity.Text = "";
        txtFinishedQuantity.Text = "";
        txtRemarks.Text = "";
        txtRejectedQuantity.Text = "";
        txtAcceptedQuantity.Text = "";

        drpShift.SelectedValue = "Select";
        txtRejectedMtsNo.Text = "";
        txtLotNo.Enabled = true;
    }

    private void Save()
    {
        db = new SoftLensDataContext();
        MicroScopicInspCollet bloc = new MicroScopicInspCollet();
        {
            bloc.LotNo = txtLotNo.Text;
            bloc.BlockingType = txtCutType.Text;
            bloc.ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
            bloc.FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
            bloc.AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
            bloc.BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);
            bloc.RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);
            bloc.RejMts = txtRejectedMtsNo.Text;
            bloc.Remarks = txtRemarks.Text;
            bloc.Shift = drpShift.Text;
            bloc.InspectedBy = Convert.ToString(txtBlockedBy.Text);
            bloc.Date = Convert.ToDateTime(txtDate.Text, provider);
        }
        db.MicroScopicInspCollets.InsertOnSubmit(bloc);
        db.SubmitChanges();
        Messagebox("Saved successfully");
    }

    private void GridBind()
    {
        db = new SoftLensDataContext();
        var query = from row in db.MicroScopicInspCollets where row.LotNo == txtLotNo.Text && row.BlockingType == txtCutType.Text select row;
        gvBlocking.DataSource = query;
        gvBlocking.DataBind();    
    }

    private void Update()
    {
        SoftLensDataContext db = new SoftLensDataContext();

        string idno = Session["ID"].ToString();
        var bloc = from b in db.MicroScopicInspCollets where b.Id == Convert.ToInt32(idno) select b;
        bloc.Single().LotNo = txtLotNo.Text;
        bloc.Single().BlockingType = txtCutType.Text;
        bloc.Single().FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
        bloc.Single().AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
        bloc.Single().BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);

        bloc.Single().ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
        bloc.Single().RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);

        bloc.Single().RejMts = txtRejectedMtsNo.Text;
        bloc.Single().Remarks = txtRemarks.Text;
        bloc.Single().Shift = drpShift.Text;
        bloc.Single().InspectedBy = Convert.ToString(txtBlockedBy.Text);
        bloc.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
        db.SubmitChanges();
        btnUpdate.Visible = false;
        txtLotNo.Enabled = true;
        Clear();
        Messagebox("Updated successfully");
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void lotnogridbind(string lotno)
    {
        SoftLensDataContext db = new SoftLensDataContext();
        Blocking bloc = new Blocking();

        var query = from row in db.MicroScopicInspCollets where row.LotNo == lotno && row.BlockingType == txtCutType.Text select row;
        gvBlocking.DataSource = query;
        gvBlocking.DataBind();

        if (txtLotNo.Text.Length < Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }

        try
        {
            int receivedQty = 0;
            if (txtCutType.Text == "Ist Cut")
            {
                var query2 = (from row2 in db.Lathecuts where row2.LotNo == lotno && row2.LatheType == txtCutType.Text select row2.AcceptedQuantity).Sum();

                if (query2 == null)
                {
                    Messagebox("Before Process Might Not be Completed");
                    txtLotNo.Focus();
                    txtLotNo.Text = "";
                }
                else
                {
                    receivedQty = query2.Value;
                    txtReceivedQuantity.Text = receivedQty.ToString();
                }
            }
            else
            {
                var query4 = (from row4 in db.Lathecuts where row4.LotNo == lotno && row4.LatheType == txtCutType.Text select row4.AcceptedQuantity).Sum();
                if (query4 == null)
                {
                    Messagebox("Before Process Might Not be Completed");
                    txtLotNo.Focus();
                    txtLotNo.Text = "";
                }
                else
                {
                    receivedQty = query4.Value;
                    txtReceivedQuantity.Text = receivedQty.ToString();
                }

            }
            var query3 = (from row3 in db.MicroScopicInspCollets where row3.LotNo == txtLotNo.Text && row3.BlockingType == txtCutType.Text select row3.FinishedQuantity).Sum();
            if (query3 == null)
            {
                txtBalanceQuantity.Text = "0";
            }
            if (query3.Value < Convert.ToInt32(txtReceivedQuantity.Text))
            {
                txtFinishedQuantity.Enabled = true;
                btnSave.Visible = true;
            }
            else
            {


                btnSave.Visible = false;

            }
            int val = Convert.ToInt32(txtReceivedQuantity.Text) - query3.Value;

            txtBalanceQuantity.Text = Convert.ToString(val);
        }
        catch
        {
        }
    }
    #endregion Methods

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        gvBlocking.Enabled = true;
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");


        if (!IsPostBack)
        {
            Shift();
            txtCutType.Text = Session["Cut Type"].ToString();

            if (txtCutType.Text == "Ist Cut")
            {
                Label2.Text = "Ist Cut Microscopic Inspection With Collet";
            }
            else
            {
                Label2.Text = "IInd Cut Microscopic Inspection With Collet";
            }

        }

        if (Session["Location"].ToString() == "Chennai")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtFinishedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            txtAcceptedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtFinishedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            txtAcceptedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
        }
    }

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        Clear();
        btnSave.Visible = true;
        btnClear.Visible = true;
        lotnogridbind(txtLotNo.Text);
    }
   
    protected void gvBlocking_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvBlocking.Rows.Count - 1 == gvBlocking.SelectedRow.RowIndex)
        {
            btnSave.Visible = false;
            btnClear.Visible = true;
            SoftLensDataContext db = new SoftLensDataContext();

            Label id = (Label)gvBlocking.SelectedRow.FindControl("Label1");
            Session["ID"] = id.Text;


            txtLotNo.Text = gvBlocking.SelectedRow.Cells[2].Text;

            txtReceivedQuantity.Text = gvBlocking.SelectedRow.Cells[4].Text;
            txtFinishedQuantity.Text = gvBlocking.SelectedRow.Cells[5].Text;
            txtAcceptedQuantity.Text = gvBlocking.SelectedRow.Cells[6].Text;
            txtRejectedQuantity.Text = gvBlocking.SelectedRow.Cells[7].Text;
            txtBalanceQuantity.Text = gvBlocking.SelectedRow.Cells[8].Text;
            txtRejectedMtsNo.Text = gvBlocking.SelectedRow.Cells[9].Text;
            if (txtRejectedMtsNo.Text == "&nbsp;")
            {
                txtRejectedMtsNo.Text = "";
            }
            txtRemarks.Text = gvBlocking.SelectedRow.Cells[10].Text;
            if (txtRemarks.Text == "&nbsp;")
            {
                txtRemarks.Text = "";
            }
            txtBlockedBy.Text = gvBlocking.SelectedRow.Cells[11].Text;
            drpShift.Text = gvBlocking.SelectedRow.Cells[12].Text;
            txtDate.Text = gvBlocking.SelectedRow.Cells[13].Text;
            txtLotNo.Enabled = false;
            btnUpdate.Visible = true;
        }
        else
        {
            Messagebox("This Row values cannot be Updated & Permission is denied");
            Gclear();
            btnUpdate.Visible = false;
        }
    }

    protected void txtFinishedQuantity_TextChanged(object sender, EventArgs e)
    {
        Shift();
        txtAcceptedQuantity.Text = "";

        SoftLensDataContext db = new SoftLensDataContext();

        if (txtFinishedQuantity.Text != "")
        {
            var query = (from row in db.MicroScopicInspCollets where row.LotNo == txtLotNo.Text && row.BlockingType == txtCutType.Text select row.FinishedQuantity).Sum();

            int sumofFinishedQty = 0;

            if (query != null)
            {
                sumofFinishedQty = query.Value;
            }

            if (btnUpdate.Visible == true)
            {
                sumofFinishedQty = sumofFinishedQty - Convert.ToInt32(gvBlocking.SelectedRow.Cells[5].Text);
                int val = (Convert.ToInt32(txtReceivedQuantity.Text) - (sumofFinishedQty + Convert.ToInt32(txtFinishedQuantity.Text)));
                if (val < 0)
                {
                    Messagebox("Finished Qty is Greater than Received Qty");
                    txtFinishedQuantity.Text = "";
                    txtFinishedQuantity.Focus();
                }
                else
                {
                    txtAcceptedQuantity.Focus();
                    txtAcceptedQuantity.Text = "";
                    txtBalanceQuantity.Text = val.ToString();
                }

            }
            else
            {

                var query3 = (from row3 in db.MicroScopicInspCollets where row3.LotNo == txtLotNo.Text && row3.BlockingType == txtCutType.Text select row3.FinishedQuantity).Sum();

                sumofFinishedQty = 0;
                if (query3 != null)
                {
                    sumofFinishedQty = query3.Value;
                }

                if (Convert.ToInt32(txtFinishedQuantity.Text) > Convert.ToInt32(txtReceivedQuantity.Text))
                {

                    Messagebox("Value is Greater than Received Qty");
                    txtFinishedQuantity.Text = "";
                    txtFinishedQuantity.Focus();

                }
                else
                {

                    btnSave.Enabled = true;
                    int val = (Convert.ToInt32(txtReceivedQuantity.Text) - (sumofFinishedQty + Convert.ToInt32(txtFinishedQuantity.Text)));

                    if (val < 0)
                    {
                        txtFinishedQuantity.Text = "";
                        Messagebox("Value is Greater than Received Qty");
                        txtFinishedQuantity.Focus();

                    }
                    else
                    {
                        txtBalanceQuantity.Text = val.ToString();
                        txtAcceptedQuantity.Focus();
                    }
                }
            }
            //txtAcceptedQuantity.Text = "";
            //txtAcceptedQuantity.Focus();
        }
    }

    protected void txtAcceptedQuantity_TextChanged(object sender, EventArgs e)
    {
        // btnClear.Visible = true;
        if (txtFinishedQuantity.Text != "" && txtAcceptedQuantity.Text != "")
        {
            if (Convert.ToInt32(txtAcceptedQuantity.Text) > Convert.ToInt32(txtFinishedQuantity.Text))
            {
                Messagebox("Value is Greater than Finished Qty");
                txtAcceptedQuantity.Text = "";
                txtAcceptedQuantity.Focus();

            }
            else
            {
                txtRemarks.Focus();
                txtRejectedQuantity.Text = (Convert.ToInt32(txtFinishedQuantity.Text) - Convert.ToInt32(txtAcceptedQuantity.Text)).ToString();
                if (Convert.ToInt32(txtRejectedQuantity.Text) > 0)
                {
                    txtRejectedMtsNo.Enabled = true;
                    txtRejectedMtsNo.Focus();
                }

            }
        }
        else
        {
            Messagebox("Please Enter the Finished Quantity");
            txtAcceptedQuantity.Text = "";
            txtFinishedQuantity.Focus();
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if(Validation())
        {

            Save();
            GridBind();
            btnSave.Visible = false;
            btnClear.Visible = false;
            Clear();
            txtLotNo.Text = "";
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            Update();
            GridBind();
            txtLotNo.Text = "";
            btnSave.Enabled = true;
            btnClear.Visible = false;
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
        Clear();
        txtLotNo.Text = "";
    }

    protected void txtBlockedBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtBlockedBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtBlockedBy.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: M.BALAJI");
                txtBlockedBy.Text = "";
                txtBlockedBy.Focus();

            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtBlockedBy.Text = "";
            txtBlockedBy.Focus();
        }
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
        txtBlockedBy.Focus();

    }

    #endregion Events
}