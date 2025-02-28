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

public partial class Deblocking : System.Web.UI.Page
{

    #region Declarations
    SoftLensDataContext db = new SoftLensDataContext();
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    public string idno;
    #endregion Declarations

    #region Methods

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    protected void shift()
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

    protected void clear()
    {
        txtDeblockedBy.Text = "";
        //txtDate.Text = "";

        txtBalanceQuantity.Text = "";
        txtFinishedQuantity.Text = "";
        txtReceivedQuantity.Text = "";
        txtRemarks.Text = "";
        txtRejectedQuantity.Text = "";
        txtAcceptedQuantity.Text = "";

        drpShift.SelectedValue = "Select";
        drpWaxTemperature.SelectedValue = "Select";
        gvDeblocking.DataSource = null;
        gvDeblocking.DataBind();
    }

    private void lotnogridbind(string lotno)
    {
        SoftLensDataContext db = new SoftLensDataContext();
        DeBlocking debloc = new DeBlocking();
        btnUpdate.Visible = false;
        btnClear.Visible = true;
        var r = from q in db.BatchAllots where q.LotNo == txtLotNo.Text select q;
        txtradius.Text = r.Single().Radius.ToString();
        if (txtLotNo.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
            btnSave.Visible = false;
        }
        var query = from row in db.DeBlockings where row.LotNo == lotno && row.BlockingType == txtCutType.Text select row;
        gvDeblocking.DataSource = query;
        gvDeblocking.DataBind();

        try
        {
            int receivedQty = 0;
            if (txtCutType.Text == "Ist Cut")
            {
                var query2 = (from row2 in db.MicroScopicInspCollets where row2.LotNo == lotno && row2.BlockingType == txtCutType.Text select row2.AcceptedQuantity).Sum();

                if (query2 == null)
                {
                    Messagebox("Before Process Might Not be Completed");
                    txtLotNo.Focus();
                    txtLotNo.Text = "";
                    btnSave.Visible = false;
                }
                else
                {
                    receivedQty = query2.Value;
                    txtReceivedQuantity.Text = receivedQty.ToString();
                }


            }
            else
            {
                var query4 = (from row4 in db.Lathecuts  where row4.LotNo == lotno &&  row4.LatheType==txtCutType.Text  select row4.AcceptedQuantity).Sum();

                if (query4 == null)
                {
                    Messagebox("Before Process Might Not be Completed");
                    txtLotNo.Focus();
                    txtLotNo.Text = "";
                    btnSave.Visible = false;

                }
                else
                {
                    receivedQty = query4.Value;
                    txtReceivedQuantity.Text = receivedQty.ToString();
                }

            }

            try
            {
                var query3 = (from row3 in db.DeBlockings where row3.LotNo == txtLotNo.Text && row3.BlockingType == txtCutType.Text select row3.FinishedQuantity).Sum();
                if (query3.Value < Convert.ToInt32(txtReceivedQuantity.Text))
                {
                    txtFinishedQuantity.Enabled = true;
                }
                else
                {
                    btnSave.Visible = false;
                    //txtFinishedQuantity.Enabled = false;
                }
                int val = Convert.ToInt32(txtReceivedQuantity.Text) - query3.Value;
                 
                txtBalanceQuantity.Text = Convert.ToString(val);
            }

            catch
            {
            }
        }
        catch
        {

        }

    }

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
        else if (drpWaxTemperature.Text == "Select")
        {
            Messagebox("Please Choose Wax Temperature");
            drpWaxTemperature.Focus();
            _isvalid = false;
        }
        else if (txtDeblockedBy.Text == "")
        {
            Messagebox("Please Enter DeBlocked By ");
            txtDeblockedBy.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }

    private void Save()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        DeBlocking debloc = new DeBlocking();
        debloc.LotNo = txtLotNo.Text;
        debloc.BlockingType = txtCutType.Text;
        debloc.ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
        debloc.FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
        debloc.AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
        debloc.BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);
        debloc.RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);
        debloc.WaxTemp = Convert.ToInt32(drpWaxTemperature.Text);
        debloc.Remarks = txtRemarks.Text;
        debloc.Shift = drpShift.Text;
        debloc.Deblockedby = Convert.ToString(txtDeblockedBy.Text);
        debloc.Date = Convert.ToDateTime(txtDate.Text, provider);

        db.DeBlockings.InsertOnSubmit(debloc);
        db.SubmitChanges();
        Messagebox("Saved  Successfully");
    }

    private void Update()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        // DeBlocking debloc = new DeBlocking();
        idno = Session["ID"].ToString();
        var debloc = from b in db.DeBlockings where b.IdNo == Convert.ToInt32(idno) select b;
        debloc.Single().LotNo = txtLotNo.Text;
        debloc.Single().BlockingType = txtCutType.Text;
        debloc.Single().FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
        debloc.Single().AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
        debloc.Single().BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);
        debloc.Single().ReceivedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
        debloc.Single().RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);
        debloc.Single().WaxTemp = Convert.ToInt32(drpWaxTemperature.Text);
        debloc.Single().Remarks = txtRemarks.Text;
        debloc.Single().Shift = drpShift.Text;
        debloc.Single().Deblockedby = Convert.ToString(txtDeblockedBy.Text);
        debloc.Single().Date = Convert.ToDateTime(txtDate.Text, provider);

        db.SubmitChanges();
        Messagebox("Updated Successfully");
    }

    private void GridBind()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        var query = from row in db.DeBlockings where row.LotNo == txtLotNo.Text && row.BlockingType == txtCutType.Text select row;
        gvDeblocking.DataSource = query;
        gvDeblocking.DataBind();
    }

    #endregion Methods

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        if (!IsPostBack)
        {
            shift();
            txtCutType.Text = Session["Cut Type"].ToString();

            if (txtCutType.Text == "Ist Cut")
            {
                Label2.Text = "Ist Cut DEBLOCKING";
            }
            else
            {
                Label2.Text = "IInd Cut DEBLOCKING";
            }

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

    protected void txtAcceptedQuantity_TextChanged(object sender, EventArgs e)
    {
        if (txtFinishedQuantity.Text != "" && txtAcceptedQuantity.Text != "")
        {
            if (Convert.ToInt32(txtAcceptedQuantity.Text) > Convert.ToInt32(txtFinishedQuantity.Text))
            {
                Messagebox("Value is Greater than Finished Qty ");
                txtAcceptedQuantity.Text = "";
                txtAcceptedQuantity.Focus();
            }
            else
            {
                txtRejectedQuantity.Text = (Convert.ToInt32(txtFinishedQuantity.Text) - Convert.ToInt32(txtAcceptedQuantity.Text)).ToString();
                drpWaxTemperature.Focus();
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
        txtFinishedQuantity.Enabled = true;
        lotnogridbind(txtLotNo.Text);
        txtFinishedQuantity.Focus();
       
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
    }

    protected void gvDeblocking_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvDeblocking.Rows.Count - 1 == gvDeblocking.SelectedRow.RowIndex && Session["up"].Equals(1))
        {
            btnSave.Visible = false;
            btnClear.Visible = true;


            txtFinishedQuantity.Enabled = true;
            SoftLensDataContext db = new SoftLensDataContext();
            Label id = (Label)gvDeblocking.SelectedRow.FindControl("Label1");
            Session["ID"] = id.Text;
            txtLotNo.Text = gvDeblocking.SelectedRow.Cells[2].Text;

            txtReceivedQuantity.Text = gvDeblocking.SelectedRow.Cells[4].Text;
            txtFinishedQuantity.Text = gvDeblocking.SelectedRow.Cells[5].Text;
            txtAcceptedQuantity.Text = gvDeblocking.SelectedRow.Cells[6].Text;
            txtRejectedQuantity.Text = gvDeblocking.SelectedRow.Cells[7].Text;
            txtBalanceQuantity.Text = gvDeblocking.SelectedRow.Cells[8].Text;
            drpWaxTemperature.Text = gvDeblocking.SelectedRow.Cells[9].Text;

            txtRemarks.Text = gvDeblocking.SelectedRow.Cells[10].Text;
            if (txtRemarks.Text == "&nbsp;")
            {
                txtRemarks.Text = "";
            }
            txtDeblockedBy.Text = gvDeblocking.SelectedRow.Cells[11].Text;
            drpShift.Text = gvDeblocking.SelectedRow.Cells[12].Text;
            txtDate.Text = gvDeblocking.SelectedRow.Cells[13].Text;

            btnUpdate.Visible = true;
        }
        else
        {
            Messagebox("This Row values cannot be Updated & the Permission is denied");
            clear();
            btnUpdate.Visible = false;
        }
    }

    protected void txtFinishedQuantity_TextChanged2(object sender, EventArgs e)
    {
        // btnClear.Visible = true;
        txtAcceptedQuantity.Text = "";
        shift();
        //btnClear.Visible = true;
        SoftLensDataContext db = new SoftLensDataContext();
        if (txtFinishedQuantity.Text != "")
        {
            if (btnUpdate.Visible == true)
            {
                int val = (Convert.ToInt32(txtReceivedQuantity.Text) - Convert.ToInt32(txtFinishedQuantity.Text));
                if (val < 0)
                {
                    Messagebox("Value is Greater than Received Qty");
                    txtFinishedQuantity.Text = "";
                    txtFinishedQuantity.Focus();
                }
                else
                {
                    txtBalanceQuantity.Text = val.ToString();
                    txtAcceptedQuantity.Text = "";
                    txtAcceptedQuantity.Focus();
                }
            }
            else
            {
                var query3 = (from row3 in db.DeBlockings where row3.LotNo == txtLotNo.Text && row3.BlockingType == txtCutType.Text select row3.FinishedQuantity).Sum();
                int sumofFinishedQty = 0;
                if (query3 != null)
                {
                    sumofFinishedQty = query3.Value;
                }

                if (Convert.ToInt32(txtFinishedQuantity.Text) > Convert.ToInt32(txtReceivedQuantity.Text))
                {
                    Messagebox(" Finished Qty eXceeds Received Qty ");
                    txtFinishedQuantity.Text = "";
                    txtFinishedQuantity.Focus();
                    //btnSave.Enabled = false;
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
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            Save();
            btnSave.Visible = false;
            btnClear.Visible = false;
            btnUpdate.Visible = false;
            txtLotNo.Focus();
            clear();
            GridBind();
            txtLotNo.Text = "";
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            Update();
            clear();
            GridBind();
            btnSave.Enabled = true;
            btnUpdate.Visible = false;
            btnClear.Visible = false;
            txtLotNo.Text = "";
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
        txtDeblockedBy.Focus();
    }

    protected void txtDeblockedBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtDeblockedBy.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtDeblockedBy.Text = up.ToUpper();
        }
        else
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtDeblockedBy.Text = "";
            txtDeblockedBy.Focus();

        }
    }
    #endregion Events
}
