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
using System.Timers;
using AjaxControlToolkit;


public partial class LathCut : System.Web.UI.Page
{

    #region Declarations

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    public string idno;
    SoftLensDataContext db = new SoftLensDataContext();

    #endregion Declarations

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        gvLathCut.Enabled = true;
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        if (!IsPostBack)
        {
            shift();
            txtBlockingType.Text = Session["Cut Type"].ToString();

            if (txtBlockingType.Text == "Ist Cut")
            {
                Label2.Text = "Ist Cut LATH CUT";
            }
            else
            {
                Label2.Text = "IInd Cut LATH CUT";
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

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        clear();
        btnSave.Visible = true;
        lotnogridbind(txtLotNo.Text);
        btnUpdate.Visible = false;
        txtFinishedQuantity.Enabled = true;

        ddlLathNo.Items.Clear();
        ddlLathNo.Items.Add("Select");
        var q = from r in db.LatheMasters select r.LatheNo;
        ddlLathNo.DataSource = q;
        ddlLathNo.DataBind();       
    }

    protected void txtAcceptedQuantity_TextChanged(object sender, EventArgs e)
    {
        btnClear.Visible = true;
        if (txtFinishedQuantity.Text != "" && txtAcceptedQuantity.Text != "")
        {
            if (Convert.ToInt32(txtAcceptedQuantity.Text) > Convert.ToInt32(txtFinishedQuantity.Text))
            {
                Messagebox("Limit exceeds Finished Quantity");
                txtAcceptedQuantity.Text = "";
                txtAcceptedQuantity.Focus();
            }
            else
            {
                ddlLathNo.Focus();
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

    protected void gvLathCut_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvLathCut.Rows.Count - 1 == gvLathCut.SelectedRow.RowIndex && Session["up"].Equals(1))
        {
            btnSave.Visible = false;
            btnClear.Visible = true;

            txtFinishedQuantity.Enabled = true;
            SoftLensDataContext db = new SoftLensDataContext();
            Label id = (Label)gvLathCut.SelectedRow.FindControl("Label1");
            Session["ID"] = id.Text;
            txtLotNo.Text = gvLathCut.SelectedRow.Cells[2].Text;

            txtReceivedQuantity.Text = gvLathCut.SelectedRow.Cells[4].Text;
            txtFinishedQuantity.Text = gvLathCut.SelectedRow.Cells[5].Text;
            txtAcceptedQuantity.Text = gvLathCut.SelectedRow.Cells[6].Text;
            txtRejectedQuantity.Text = gvLathCut.SelectedRow.Cells[7].Text;
            txtBalanceQuantity.Text = gvLathCut.SelectedRow.Cells[8].Text;
            ddlLathNo.Text = gvLathCut.SelectedRow.Cells[9].Text;
            drpToolId.Items.Clear();
            drpToolId.Items.Add("Select");
            var q = from r in db.LatheMasters where r.LatheNo == ddlLathNo.Text select r.ToolId;
            drpToolId.DataSource = q;
            drpToolId.DataBind();

            drpToolId.Text = gvLathCut.SelectedRow.Cells[10].Text;
            txtStartTime.Text = gvLathCut.SelectedRow.Cells[11].Text;
            txtStopTime.Text = gvLathCut.SelectedRow.Cells[12].Text;
            txtDuration.Text = gvLathCut.SelectedRow.Cells[13].Text;
            txtRemarks.Text = gvLathCut.SelectedRow.Cells[14].Text;
            if (txtRemarks.Text == "&nbsp;")
            {
                txtRemarks.Text = "";
            }
            txtOperatorName.Text = gvLathCut.SelectedRow.Cells[15].Text;
            drpShift.Text = gvLathCut.SelectedRow.Cells[16].Text;
            txtDate.Text = gvLathCut.SelectedRow.Cells[17].Text;
            txtLotNo.Enabled = false;
            btnUpdate.Visible = true;
            btnClear.Visible = true;
        }
        else
        {
            Messagebox("This Row cannot be Updated & Permission is denied");
            gclear();
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }
    }

    protected void txtFinishedQuantity_TextChanged(object sender, EventArgs e)
    {
        txtAcceptedQuantity.Text = "";
        btnClear.Visible = true;
        shift();
        btnClear.Visible = true;
        SoftLensDataContext db = new SoftLensDataContext();
        if (txtFinishedQuantity.Text != "")
        {
            Lathecut lath = new Lathecut();
            var query3 = (from row3 in db.Lathecuts where row3.LotNo == txtLotNo.Text && row3.LatheType == txtBlockingType.Text select row3.FinishedQuantity).Sum();

            int sumofFinishedQty = 0;
            if (query3 != null)
            {
                sumofFinishedQty = query3.Value;
            }

            if (Convert.ToInt32(txtFinishedQuantity.Text) > Convert.ToInt32(txtReceivedQuantity.Text))
            {
                Messagebox("Finished Qty is Greater than Received Qty");
                txtFinishedQuantity.Text = "";
                txtFinishedQuantity.Focus();
            }
            else
            {
                if (btnUpdate.Visible == true)
                {
                    sumofFinishedQty = sumofFinishedQty - Convert.ToInt32(gvLathCut.SelectedRow.Cells[5].Text);
                    int val = (Convert.ToInt32(txtReceivedQuantity.Text) - (sumofFinishedQty + Convert.ToInt32(txtFinishedQuantity.Text)));
                    if (val < 0)
                    {
                        Messagebox("Finished Qty is Greater than Received Qty");
                        txtFinishedQuantity.Text = "";
                        txtFinishedQuantity.Focus();
                    }
                    else
                    {
                        txtBalanceQuantity.Text = val.ToString();
                        txtAcceptedQuantity.Focus();
                        txtAcceptedQuantity.Text = "";
                    }

                }
                else
                {
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
                    }
                }
            }
        }
    }

    protected void txtStopTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string strt = Convert.ToDateTime(txtStartTime.Text).ToString();
            string time1 = Convert.ToDateTime(strt).ToString("HH:mm");

            string strt1 = Convert.ToDateTime(txtStopTime.Text).ToString();
            string time2 = Convert.ToDateTime(strt1).ToString("HH:mm");

            DateTime endTime = Convert.ToDateTime(time2);
            DateTime startTime = Convert.ToDateTime(time1);
            TimeSpan span = endTime.Subtract(startTime);
            txtDuration.Text = span.ToString();
            txtOperatorName.Focus();
            if (txtDuration.Text.StartsWith("-") || span.Hours > 12)
            {
                Messagebox(" Please Check given Time ");
                txtStartTime.Focus();
                txtStopTime.Text = "00:00 AM";
                txtDuration.Text = "00:00:00";
            }
        }
        catch
        {
            //Messagebox(" Please Enter correct format ex: 01:56 ");
            //txtStartTime.Text = "00:00 AM";
            //txtStartTime.Focus();
            //txtStopTime.Text = "00:00 PM";
            //txtStopTime.Focus();
        }


    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            SaveMethod();
            clear();
            GridBind();
            btnClear.Visible = false;
            txtLotNo.Text = "";
        }
    }

    protected void btnUpdate_Click1(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            UpdateMethod();
            clear();
            GridBind();
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            txtLotNo.Enabled = true;
            txtLotNo.Text = "";
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        clear();
        txtLotNo.Text = "";
        txtLotNo.Enabled = true;
    }

    protected void txtOperatorName_TextChanged(object sender, EventArgs e)
    {

        string up = txtOperatorName.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtOperatorName.Text = up.ToUpper();
            txtRemarks.Focus();
        }
        else
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtOperatorName.Text = "";
            txtOperatorName.Focus();

        }
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
    }

    protected void txtStartTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string strt = Convert.ToDateTime(txtStartTime.Text).ToString();
            txtStopTime.Focus();
            //if (btnUpdate.Visible == true)
            //{
            //    try
            //    {
            //        string strtu = Convert.ToDateTime(txtStartTime.Text).ToString();
            //        string time1 = Convert.ToDateTime(strtu).ToString("HH:mm");

            //        string strt1 = Convert.ToDateTime(txtStopTime.Text).ToString();
            //        string time2 = Convert.ToDateTime(strt1).ToString("HH:mm");

            //        DateTime endTime = Convert.ToDateTime(time2);
            //        DateTime startTime = Convert.ToDateTime(time1);
            //        TimeSpan span = endTime.Subtract(startTime);
            //        txtDuration.Text = span.ToString();
            //        if (txtDuration.Text.StartsWith("-") && txtStopTime.Text != "00:00 AM" || span.Hours > 12)
            //        {
            //            Messagebox(" Please Check given Time ");
            //            txtStartTime.Text = "00:00 AM";
            //            txtStartTime.Focus();
            //            txtDuration.Text = "00:00:00";
            //        }
            //    }
            //    catch
            //    {
            //        Messagebox(" Please Enter correct format ex: 01:56 ");
            //        txtStartTime.Text = "00:00 AM";
            //        txtStartTime.Focus();
            //    }
            //}
        }
        catch
        {
            Messagebox(" Please in correct format ex: 06:56 AM");
        }


    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]

    public static AjaxControlToolkit.CascadingDropDownNameValue[] GetDropDownContents(string knownCategoryValues, string category)
    {
        return default(AjaxControlToolkit.CascadingDropDownNameValue[]);
    }

    protected void drpLathNO_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpToolId.Items.Clear();
        drpToolId.Items.Add("Select");
        var q = from r in db.LatheMasters where r.LatheNo == ddlLathNo.Text select r.ToolId;
        drpToolId.DataSource = q;
        drpToolId.DataBind();
        txtStartTime.Focus();
    }

    #endregion Events

    #region Methods

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void lotnogridbind(string lotno)
    {
        SoftLensDataContext db = new SoftLensDataContext();

        btnClear.Visible = true;
        var que = from r in db.BatchAllots where r.LotNo == txtLotNo.Text select r;
        txtradius.Text = que.Single().Radius.ToString();

        var query = from row in db.Lathecuts where row.LotNo == lotno && row.LatheType == txtBlockingType.Text select row;
        btnClear.Visible = true;
        gvLathCut.DataSource = query;
        gvLathCut.DataBind();
        if (txtLotNo.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
             Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }


        try
        {
            int ReceivedQty = 0;
            if (txtBlockingType.Text == "Ist Cut")
            {
                var query2 = (from row2 in db.Blockings where row2.LotNo == lotno && row2.BlockingType == txtBlockingType.Text select row2.AcceptedQuantity).Sum();

                if (query2 != null)
                {
                    ReceivedQty = query2.Value;
                    txtReceivedQuantity.Text = ReceivedQty.ToString();
                    txtFinishedQuantity.Focus();
                }
                else
                {
                    Messagebox("Before Process Might Not be Completed");
                    txtLotNo.Text = "";
                    txtLotNo.Focus();
                }



            }
            else
            {
                var query4 = (from row4 in db.Blockings where row4.LotNo == lotno && row4.BlockingType == txtBlockingType.Text select row4.AcceptedQuantity).Sum();
                if (query4 == null)
                {
                    Messagebox("Before Process Might Not be Completed");
                    txtLotNo.Text = "";
                    txtLotNo.Focus();
                }
                else
                {
                    ReceivedQty = query4.Value;
                    txtReceivedQuantity.Text = ReceivedQty.ToString();
                    txtFinishedQuantity.Focus();
                }


            }

            try
            {
                var query3 = (from row3 in db.Lathecuts where row3.LotNo == txtLotNo.Text && row3.LatheType == txtBlockingType.Text select row3.FinishedQuantity).Sum();
                if (query3.Value < Convert.ToInt32(txtReceivedQuantity.Text))
                {
                    txtFinishedQuantity.Enabled = true;
                }
                else
                {
                    txtFinishedQuantity.Enabled = false;
                    btnSave.Visible = false;
                    btnClear.Visible = true;
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

        if (txtFinishedQuantity.Text == "")
        {
            Messagebox("Please enter Finished Qty");
            txtFinishedQuantity.Focus();
            _isvalid = false;
        }
        else if (txtAcceptedQuantity.Text == "")
        {
            Messagebox("Please enter Accepted Qty");
            txtAcceptedQuantity.Focus();
            _isvalid = false;
        }
        else if (ddlLathNo.Text == "Select")
        {
            Messagebox("Please choose LathNo");
            ddlLathNo.Focus();
            _isvalid = false;
        }
        else if (drpToolId.Text == "")
        {
            Messagebox("Please choose ToolId");
            drpToolId.Focus();
            _isvalid = false;
        }
        else if (txtStartTime.Text == "")
        {
            Messagebox("Please Enter the Start Time");
            txtStartTime.Focus();
            _isvalid = false;
        }
        else if (txtStopTime.Text == "")
        {
            Messagebox("Please Enter the Stop Time");
            txtStopTime.Focus();
            _isvalid = false;
        }
        else if (txtDuration.Text.StartsWith("-"))
        {
            Messagebox("Please check the correct Time");
            txtStartTime.Focus();
            _isvalid = false;
        }
        else if (txtOperatorName.Text == "")
        {
            Messagebox("Please enter Operator Name");
            txtOperatorName.Focus();
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
        txtOperatorName.Text = "";
        txtFinishedQuantity.Text = "";
        txtRejectedQuantity.Text = "";
        txtReceivedQuantity.Text = "";
        txtRemarks.Text = "";
        txtBalanceQuantity.Text = "";

        //txtDate.Text = "";
        ddlLathNo.Text = "Select";
        drpToolId.Items.Clear();
        drpShift.Text = "Select";

        txtStartTime.Text = "";
        txtStopTime.Text = "";
        txtDuration.Text = "";
        txtAcceptedQuantity.Text = "";
        btnClear.Visible = false;
        gvLathCut.DataSource = null;
        gvLathCut.DataBind();
    }

    protected void gclear()
    {
        txtOperatorName.Text = "";
        txtFinishedQuantity.Text = "";
        txtRejectedQuantity.Text = "";
        txtReceivedQuantity.Text = "";
        txtRemarks.Text = "";
        txtBalanceQuantity.Text = "";

        txtDate.Text = "";
        ddlLathNo.Text = "Select";
        drpShift.Text = "Select";
        drpToolId.Items.Clear();
        txtStartTime.Text = "";
        txtStopTime.Text = "";
        txtDuration.Text = "";
        txtAcceptedQuantity.Text = "";
    }

    private void SaveMethod()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        Lathecut lath = new Lathecut()
        {
            LotNo = txtLotNo.Text,
            FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text),
            AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text),
            BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text),
            ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text),
            RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text),
            StartTime = Convert.ToDateTime(txtStartTime.Text).ToString("HH:mm tt"),
            EndTime = Convert.ToDateTime(txtStopTime.Text).ToString("HH:mm tt"),
            Duration = Convert.ToDateTime(txtDuration.Text).ToString("HH:mm"),
            Remarks = txtRemarks.Text,
            Shift = drpShift.Text,
            Date = Convert.ToDateTime(txtDate.Text, provider),
            OperatorName = txtOperatorName.Text,
            LatheType = txtBlockingType.Text,
            LatheNo = Convert.ToString(ddlLathNo.Text),
            ToolId = drpToolId.Text,
        };
        db.Lathecuts.InsertOnSubmit(lath);
        db.SubmitChanges();
        btnSave.Visible = false;

        Messagebox("Saved Successfully");
    }

    private void UpdateMethod()
    {
        SoftLensDataContext db = new SoftLensDataContext();

        idno = Session["ID"].ToString();
        var lath = from b in db.Lathecuts where b.IdNo == Convert.ToInt32(idno) select b;


        lath.Single().LotNo = txtLotNo.Text;
        lath.Single().FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
        lath.Single().AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
        lath.Single().BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);
        lath.Single().ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
        lath.Single().RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);
        lath.Single().StartTime = Convert.ToDateTime(txtStartTime.Text).ToString("HH:mm tt");
        lath.Single().EndTime = Convert.ToDateTime(txtStopTime.Text).ToString("HH:mm tt");
        lath.Single().Duration = Convert.ToDateTime(txtDuration.Text).ToString("HH:mm");
        lath.Single().Remarks = txtRemarks.Text;
        lath.Single().Shift = drpShift.Text;
        lath.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
        lath.Single().OperatorName = txtOperatorName.Text;
        lath.Single().LatheType = txtBlockingType.Text;
        lath.Single().LatheNo = Convert.ToString(ddlLathNo.Text);
        lath.Single().ToolId = drpToolId.Text;

        db.SubmitChanges();

        Messagebox("Updated Successfully");
    }

    private void GridBind()
    {
        var query = from row in db.Lathecuts where row.LotNo == txtLotNo.Text && row.LatheType == txtBlockingType.Text select row;
        gvLathCut.DataSource = query;
        gvLathCut.DataBind();
    }

    #endregion Methods
}
