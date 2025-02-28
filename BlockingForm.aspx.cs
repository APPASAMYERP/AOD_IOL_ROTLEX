
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

public partial class BlockingForm : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    public string idno;

    protected void Page_Load(object sender, EventArgs e)
    {

        gvBlocking.Enabled = true;
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");       
        gvBlockingbind();
        if (!IsPostBack)
        {
            txtBlockingType.Text = Session["Cut Type"].ToString();
            if (txtBlockingType.Text == "Ist Cut")
            {
                Label2.Text = "Ist Cut BLOCKING";
            }
            else
            {
                Label2.Text = "IInd Cut BLOCKING";
            }
            shift();

        }
        if (Session["Location"].ToString() == "Chennai")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtFinishedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            txtAcceptedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            //txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            //txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtFinishedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
            txtAcceptedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
        }
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    private void gvBlockingbind()
    {

    }
    protected void clear()
    {
        txtBlockedBy.Text = "";
        //txtDate.Text = "";

        txtBalanceQuantity.Text = "";
        txtReceivedQuantity.Text = "";
        txtFinishedQuantity.Text = "";
        txtRemarks.Text = "";
        txtRejectedQuantity.Text = "";
        txtAcceptedQuantity.Text = "";
        drpShift.SelectedValue = "Select";
        drpWaxTemperature.SelectedValue = "Select";
        txtLotNo.Enabled = true;
        gvBlocking.DataSource = null;
        gvBlocking.DataBind();
    }
    protected void gclear()
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
        drpWaxTemperature.SelectedValue = "Select";
        txtLotNo.Enabled = true;
    }


    protected void txtAcceptedQuantity_TextChanged(object sender, EventArgs e)
    {
        btnClear.Visible = true;
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
                drpWaxTemperature.Focus();
                txtRejectedQuantity.Text = (Convert.ToInt32(txtFinishedQuantity.Text) - Convert.ToInt32(txtAcceptedQuantity.Text)).ToString();
            }

        }
        else
        {
            Messagebox("Please Enter the Finished Quantity");
            txtAcceptedQuantity.Text = "";
            txtFinishedQuantity.Focus();
        }
    }

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {

        clear();
        btnSave.Visible = true;
        btnClear.Visible = true;
        lotnogridbind(txtLotNo.Text);
        txtFinishedQuantity.Enabled = true;
    }

    private void lotnogridbind(string  lotno)
    {
        SoftLensDataContext db = new SoftLensDataContext();
        Blocking bloc = new Blocking();
        var r = from row in db.BatchAllots where row.LotNo == txtLotNo.Text select row;
        txtradius.Text = r.Single().Radius.ToString();

        var query = from row in db.Blockings where row.LotNo == lotno && row.BlockingType == txtBlockingType.Text select row;
        btnClear.Visible = true;
        gvBlocking.DataSource = query;
        gvBlocking.DataBind();
        if (txtLotNo.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }
        else
        {
            int receivedQty = 0;

            if (txtBlockingType.Text == "Ist Cut")
            {
                var query2 = from row2 in db.BatchAllots where row2.LotNo == lotno select row2.AllotedQuantity;
                if (query2.Count() > 0)
                {
                    receivedQty = query2.Single().Value;
                    txtFinishedQuantity.Focus();
                }
                else
                {
                    Messagebox("LotNo Does not Exit");
                    txtLotNo.Focus();
                    txtLotNo.Text = "";
                }

            }
            else
            {
                var query3 = (from row3 in db.Millings  where row3.LotNo == lotno select row3.AcceptedQuantity).Sum();
                if (query3 == null)
                {
                    txtLotNo.Text = "";
                    txtLotNo.Focus();
                    Messagebox("Before Process Might Not be Completed");
                }
                else
                {
                    receivedQty = query3.Value;
                    txtFinishedQuantity.Focus();

                }

            } 
            
            txtReceivedQuantity.Text = receivedQty.ToString();

            var bal = (from row3 in db.Blockings where row3.LotNo == txtLotNo.Text && row3.BlockingType == txtBlockingType.Text select row3.FinishedQuantity).Sum();
            if (bal != null)
            {
                if (bal.Value < Convert.ToInt32(txtReceivedQuantity.Text))
                {
                    txtFinishedQuantity.Enabled = true;
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                    btnClear.Visible = true;
                }

                int val = Convert.ToInt32(txtReceivedQuantity.Text) - bal.Value;

                txtBalanceQuantity.Text = Convert.ToString(val);
            }
            txtFinishedQuantity.Focus();
        }


    }

    protected void gvBlocking_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (gvBlocking.Rows.Count - 1 == gvBlocking.SelectedRow.RowIndex && Session["up"].Equals(1))
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
            txtRejectedQuantity.Text = gvBlocking.SelectedRow.Cells[8].Text;
            txtBalanceQuantity.Text = gvBlocking.SelectedRow.Cells[7].Text;
            drpWaxTemperature.Text = gvBlocking.SelectedRow.Cells[9].Text;
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
            gclear();
            btnUpdate.Visible = false;
        }
    }
    private void shift()
    {
        String time = DateTime.Now.Hour.ToString();
        //lblMessage2.Text = time;
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
    protected void txtClear_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        clear();
        txtLotNo.Text = "";
        btnSave.Visible = false;
        btnClear.Visible = false;
    }

    protected void txtFinishedQuantity_TextChanged(object sender, EventArgs e)
    {
        shift();
        txtAcceptedQuantity.Text = "";
        btnClear.Visible = true;
        SoftLensDataContext db = new SoftLensDataContext();
        if (txtFinishedQuantity.Text != "")
        {
            var query = (from row in db.Blockings where row.LotNo == txtLotNo.Text && row.BlockingType == txtBlockingType.Text select row.FinishedQuantity).Sum();

            int sumofFinishedQty = 0;
            if (query != null)
            {
                sumofFinishedQty = query.Value;
            }

            if (btnUpdate.Visible == true)
            {
                sumofFinishedQty = sumofFinishedQty - Convert.ToInt32(gvBlocking.SelectedRow.Cells[7].Text);
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
                    txtBalanceQuantity.Text = val.ToString();
                    txtAcceptedQuantity.Text = "";
                }

            }
            else
            {

                var query3 = (from row3 in db.Blockings where row3.LotNo == txtLotNo.Text && row3.BlockingType == txtBlockingType.Text select row3.FinishedQuantity).Sum();

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
                        txtAcceptedQuantity.Focus();
                        txtBalanceQuantity.Text = val.ToString();

                    }
                }
            }
        }
    }



    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter Lot No ");
            txtLotNo.Focus();
        }
        else if (txtFinishedQuantity.Text == "")
        {
            Messagebox("Please Enter Finished Qty ");
            txtFinishedQuantity.Focus();
        }
        else if (txtAcceptedQuantity.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtAcceptedQuantity.Focus();
        }
        else if (drpWaxTemperature.Text == "Select")
        {
            Messagebox("Please Choose Wax Temperature");
            drpWaxTemperature.Focus();
        }
        else if (txtBlockedBy.Text == "")
        {
            Messagebox("Please Enter Blocked By ");
            txtBlockedBy.Focus();
        }
        else if (txtDate.Text == "")
        {
            Messagebox("Please Enter Date");
            txtDate.Focus();
        }
        else
        {
            SoftLensDataContext db = new SoftLensDataContext();
            Blocking bloc = new Blocking();
            {
                bloc.LotNo = txtLotNo.Text;
                bloc.BlockingType = txtBlockingType.Text;
                bloc.ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
                bloc.FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
                bloc.AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
                bloc.BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);
                bloc.RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);
                bloc.Waxtemp = Convert.ToInt32(drpWaxTemperature.Text);
                bloc.Remarks = txtRemarks.Text;
                bloc.Shift = drpShift.Text;
                bloc.Blockedby = Convert.ToString(txtBlockedBy.Text);
                bloc.Date = Convert.ToDateTime(txtDate.Text, provider);
            }
            db.Blockings.InsertOnSubmit(bloc);
            db.SubmitChanges();
            Messagebox("Saved Succesfully");
            txtLotNo.Focus();
            btnSave.Visible = false;
            btnClear.Visible = false;
            clear();

            var query = from row in db.Blockings where row.LotNo == txtLotNo.Text && row.BlockingType == txtBlockingType.Text select row;
            gvBlocking.DataSource = query;
            gvBlocking.DataBind();
            txtLotNo.Text = "";
        }
    }

    protected void btnUpdate_Click1(object sender, ImageClickEventArgs e)
    {
        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter Lot No ");
            txtLotNo.Focus();
        }
        else if (txtFinishedQuantity.Text == "")
        {
            Messagebox("Please Enter Finished Qty ");
            txtFinishedQuantity.Focus();
        }
        else if (txtAcceptedQuantity.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtAcceptedQuantity.Focus();
        }
        else if (drpWaxTemperature.Text == "Select")
        {
            Messagebox("Please Choose Wax Temperature");
            drpWaxTemperature.Focus();
        }
        else if (txtBlockedBy.Text == "")
        {
            Messagebox("Please Enter Blocked By ");
            txtBlockedBy.Focus();
        }
        else
        {
            SoftLensDataContext db = new SoftLensDataContext();

            idno = Session["ID"].ToString();
            var bloc = from b in db.Blockings where b.IdNo == Convert.ToInt32(idno) select b;
            bloc.Single().LotNo = txtLotNo.Text;
            bloc.Single().BlockingType = txtBlockingType.Text;
            bloc.Single().FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
            bloc.Single().AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
            bloc.Single().BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);

            bloc.Single().ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
            bloc.Single().RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);

            bloc.Single().Waxtemp = Convert.ToInt32(drpWaxTemperature.Text);
            bloc.Single().Remarks = txtRemarks.Text;
            bloc.Single().Shift = drpShift.Text;
            bloc.Single().Blockedby = Convert.ToString(txtBlockedBy.Text);
            bloc.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
            db.SubmitChanges();
            Messagebox("Updated Successfulluy");
            btnUpdate.Visible = false;
            txtLotNo.Enabled = true;
            clear();

            var query = from row in db.Blockings where row.LotNo == txtLotNo.Text && row.BlockingType == txtBlockingType.Text select row;
            gvBlocking.DataSource = query;
            gvBlocking.DataBind();
            txtLotNo.Focus();
            btnSave.Enabled = true;
            btnClear.Visible = false;
            txtLotNo.Text = "";
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        btnUpdate.Visible = false;
        clear();
        txtLotNo.Text = "";
        btnSave.Visible = false;
        btnClear.Visible = false;
    }
    protected void txtBlockedBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtBlockedBy.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtBlockedBy.Text = up.ToUpper();
            drpShift.Focus();
        }
        else
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
    
}

