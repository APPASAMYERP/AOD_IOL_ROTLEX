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

public partial class MillingProcess : System.Web.UI.Page
{
    #region Declarations
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    public string idno;
    SoftLensDataContext db = new SoftLensDataContext();
    #endregion Declarations

    #region Methods
    private void MillingNo()
    {
        drpMillingLathNo.Items.Add("Select");
        var query = from row in db.MillingLatheNoMasters select row.MillingLatheNo;
        drpMillingLathNo.DataSource = query;
        drpMillingLathNo.DataBind();
        drpMillingLathNo.SelectedIndex = -1;
        
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }




    private void lotnogridbind(string lotno)
    {
        SoftLensDataContext db = new SoftLensDataContext();
        LotResult lotres = new LotResult();
        btnUpdate.Visible = false;
        btnClear.Visible = true;
        //var q = from r in db.BatchAllots where r.LotNo == txtLotNo.Text select r;
        //txtradius.Text = q.Single().Radius.ToString();
        var query = from row in db.Millings where row.LotNo == lotno select row;
        gvMilling.DataSource = query;
        gvMilling.DataBind();
        if (txtLotNo.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }

        try
        {
            var query2 = (from row2 in db.Lathecuts  where row2.LotNo == lotno && row2.LatheType  == "Ist Cut" select row2.AcceptedQuantity).Sum();
            int receivedQty = 0;
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


            try
            {
                var query3 = (from row3 in db.Millings where row3.LotNo == txtLotNo.Text select row3.FinishedQuantity).Sum();

                int val = Convert.ToInt32(txtReceivedQuantity.Text) - query3.Value;
                if (val == 0)
                {
                    btnSave.Visible = false;
                }
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

    protected void clear()
    {
        txtOperatorName.Text = "";
        txtReceivedQuantity.Text = "";
        txtRejectedQuantity.Text = "";
        txtRemarks.Text = "";
        txtBalanceQuantity.Text = "";
        txtFinishedQuantity.Text = "";
        //txtDate.Text = "";        
        drpMillingLathNo.SelectedIndex = -1;
        drpShift.Text = "Select";
        txtAcceptedQuantity.Text = "";
        gvMilling.DataSource = null;
        gvMilling.DataBind();
        txtLotNo.Enabled = true;
        txtStartTime.Text = "00:00 AM";
        txtStopTime.Text = "00:00 AM";
        txtDuration.Text = "";
    }


    protected void shift()
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
    #endregion Methods

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        if (!IsPostBack)
        {
            shift();
            MillingNo();
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
        btnSave.Visible = true;
        //btnClear.Visible = true;
        lotnogridbind(txtLotNo.Text);
        txtFinishedQuantity.Focus();
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }

    protected void gvMilling_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Visible = false;
        btnClear.Visible = true;
        //btnClear.Visible = true;
        if (gvMilling.Rows.Count - 1 == gvMilling.SelectedRow.RowIndex && Session["up"].Equals(1))
        {

            txtFinishedQuantity.Enabled = true;
            SoftLensDataContext db = new SoftLensDataContext();
            Label id = (Label)gvMilling.SelectedRow.FindControl("Label1");
            Session["ID"] = id.Text;
            txtLotNo.Text = gvMilling.SelectedRow.Cells[2].Text;
            txtReceivedQuantity.Text = gvMilling.SelectedRow.Cells[3].Text;
            txtFinishedQuantity.Text = gvMilling.SelectedRow.Cells[4].Text;
            txtAcceptedQuantity.Text = gvMilling.SelectedRow.Cells[5].Text;
            txtBalanceQuantity.Text = gvMilling.SelectedRow.Cells[6].Text;
            txtRejectedQuantity.Text = gvMilling.SelectedRow.Cells[7].Text;
            drpMillingLathNo.Text = gvMilling.SelectedRow.Cells[8].Text;
            txtStartTime.Text = gvMilling.SelectedRow.Cells[9].Text;
            txtStopTime.Text = gvMilling.SelectedRow.Cells[10].Text;
            txtDuration.Text = gvMilling.SelectedRow.Cells[11].Text;
            txtRemarks.Text = gvMilling.SelectedRow.Cells[12].Text;
            if (txtRemarks.Text == "&nbsp;")
            {
                txtRemarks.Text = "";
            }
            txtOperatorName.Text = gvMilling.SelectedRow.Cells[13].Text;
            drpShift.Text = gvMilling.SelectedRow.Cells[14].Text;
            txtDate.Text = gvMilling.SelectedRow.Cells[15].Text;
            txtLotNo.Enabled = false;
            btnUpdate.Visible = true;
        }
        else
        {
            Messagebox("This Row values cannot be Updated & Permission is denied");
            clear();
            btnUpdate.Visible = false;
        }
    }

    protected void txtFinishedQuantity_TextChanged(object sender, EventArgs e)
    {
        btnClear.Visible = true;
        txtAcceptedQuantity.Text = "";
        shift();
        btnClear.Visible = true;
        SoftLensDataContext db = new SoftLensDataContext();

        DeBlocking debloc = new DeBlocking();
      
        var query = (from row in db.Millings  where row.LotNo == txtLotNo.Text   select row.FinishedQuantity).Sum();

        int sumofFinishedQty = 0;
        if (query != null)
        {
            sumofFinishedQty = query.Value;
        }
        if (txtFinishedQuantity.Text != "")
        {
            if (btnUpdate.Visible == true)
            {
                sumofFinishedQty = sumofFinishedQty - Convert.ToInt32(gvMilling.SelectedRow.Cells[4].Text);
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

                var query3 = (from row3 in db.Millings where row3.LotNo == txtLotNo.Text select row3.FinishedQuantity).Sum();

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
        }
    }

    protected void txtAcceptedQuantity_TextChanged(object sender, EventArgs e)
    {
        if (txtFinishedQuantity.Text != "" && txtAcceptedQuantity.Text != "")
        {
            if (Convert.ToInt32(txtAcceptedQuantity.Text) > Convert.ToInt32(txtFinishedQuantity.Text))
            {
                Messagebox("Accepted Qty is greater than  Finished Qty");
                txtAcceptedQuantity.Text = "";
                txtAcceptedQuantity.Focus();
            }
            else
            {
                drpMillingLathNo.Focus();
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
        else if (drpMillingLathNo.Text == "Select")
        {
            Messagebox("please Choose the Milling LathNo");
            drpMillingLathNo.Focus();
        }
        else if (txtDuration.Text.StartsWith("-") || txtStartTime.Text == "00:00 AM" || txtStopTime.Text == "00:00 AM")
        {
            Messagebox("please Check The Given Time");
            txtStartTime.Focus();
        }
        else if (txtOperatorName.Text == "")
        {
            Messagebox("Please Enter Operator Name");
            txtOperatorName.Focus();
        }
        else if (txtDate.Text == "")
        {
            Messagebox("Please Enter Date");
            txtDate.Focus();
        }
        else
        {
            SoftLensDataContext db = new SoftLensDataContext();
            Milling mill = new Milling()
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
                MillingLatheNo = drpMillingLathNo.Text,

            };
            db.Millings.InsertOnSubmit(mill);
            db.SubmitChanges();
            Messagebox("Saved Successfully");
            btnClear.Visible = false;

            btnSave.Visible = false;
            clear();
            var query = from row in db.Millings where row.LotNo == txtLotNo.Text select row;
            gvMilling.DataSource = query;
            gvMilling.DataBind();

            txtLotNo.Text = "";

        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
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
        else if (drpMillingLathNo.Text == "Select")
        {
            Messagebox("please Choose the Milling LathNo");
            drpMillingLathNo.Focus();
        }
        else if (txtDuration.Text.StartsWith("-") || txtStartTime.Text == "" || txtStopTime.Text == "")
        {
            Messagebox("please Check The Given Time");
            txtStartTime.Focus();
        }
        else if (txtOperatorName.Text == "")
        {
            Messagebox("Please Enter Operator Name");
            txtOperatorName.Focus();
        }
        else
        {
            SoftLensDataContext db = new SoftLensDataContext();
            //Milling mill = new Milling();

            //LotResult lotres = new LotResult();
            idno = Session["ID"].ToString();
            var mill = from b in db.Millings where b.IdNo == Convert.ToInt32(idno) select b;
            mill.Single().LotNo = txtLotNo.Text;
            mill.Single().FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
            mill.Single().AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
            mill.Single().BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);
            mill.Single().ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
            mill.Single().RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);
            mill.Single().StartTime = Convert.ToDateTime(txtStartTime.Text).ToString("HH:mm tt");
            mill.Single().EndTime = Convert.ToDateTime(txtStopTime.Text).ToString("HH:mm tt");
            mill.Single().Duration = Convert.ToDateTime(txtDuration.Text).ToString("HH:mm");
            mill.Single().Remarks = txtRemarks.Text;
            mill.Single().Shift = drpShift.Text;
            mill.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
            mill.Single().OperatorName = txtOperatorName.Text;
            mill.Single().MillingLatheNo = Convert.ToString(drpMillingLathNo.Text);

            db.SubmitChanges();
            txtLotNo.Enabled = true;
            clear();
            var query = from row in db.Millings where row.LotNo == txtLotNo.Text select row;
            gvMilling.DataSource = query;
            gvMilling.DataBind();
            //btnClear.Visible = false;
            Messagebox("Updated Successfully");
            btnUpdate.Visible = false;
            txtLotNo.Text = "";
        }

    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        txtLotNo.Text = "";
        btnClear.Visible = false;
    }

    protected void txtStopTime_TextChanged1(object sender, EventArgs e)
    {
        try
        {
            string strt = Convert.ToDateTime(txtStartTime.Text).ToString();
            string time = Convert.ToDateTime(strt).ToString("HH:mm");

            string strt1 = Convert.ToDateTime(txtStopTime.Text).ToString();
            string time1 = Convert.ToDateTime(strt1).ToString("HH:mm");
            DateTime endTime = Convert.ToDateTime(time1);
            //DateTime end = Convert.ToDateTime(time1).Date.ToShortDateString();      

            DateTime startTime = Convert.ToDateTime(time);
            //DateTime start = Convert.ToDateTime(time).Date.ToShortDateString();

            //TimeSpan sp = end.Subtract(start);

            TimeSpan span = endTime.Subtract(startTime);

            txtDuration.Text = span.ToString();
            txtRemarks.Focus();
            //if (txtDuration.Text.StartsWith("-") || span.Hours > 12)
            //{
            //    Messagebox("Please Enter Valid Time");
            //    txtStopTime.Text = "00:00 AM";
            //    txtDuration.Text = "00:00:00";
            //}
        }
        catch
        {
            //Messagebox("Please Enter in the Correct format ex: 06:00 AM");
            //txtStartTime.Text = "00:00 AM";
            //txtStopTime.Text = "00:00 AM";
        }
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
        txtOperatorName.Focus();
    }

    protected void txtOperatorName_TextChanged(object sender, EventArgs e)
    {
        string up = txtOperatorName.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtOperatorName.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter the Name With INITIAL ex: M.BALAJI");
                txtOperatorName.Text = "";
                txtOperatorName.Focus();

            }
        }
        catch
        {
            Messagebox("Please Enter the Name With INITIAL ex: M.BALAJI");
            txtOperatorName.Text = "";
            txtOperatorName.Focus();

        }
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
            //        if (txtDuration.Text.StartsWith("-") || span.Hours > 12)
            //        {
            //            Messagebox(" Please Check given Time ");
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
            Messagebox(" Please Enter correct format ex: 06:56 AM");
        }

    }

    #endregion Events

}
