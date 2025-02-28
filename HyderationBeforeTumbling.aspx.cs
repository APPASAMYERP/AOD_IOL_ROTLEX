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

public partial class HyderationBeforeTumbling : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Location"].ToString() == "Chennai")
        {
            txtLotno.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtAccpQty.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
           
            //txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            //txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtLotno.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtAccpQty.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
        }
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
    private void StartQtyBind()
    {
        var query = (from row in db.DeBlockings where row.LotNo == txtLotno.Text && row.BlockingType == "IInd Cut" select row.AcceptedQuantity).Sum();
        if (query != null)
        {
            txtStartQty.Text = query.Value.ToString();
        }
        else
        {
            MessageBox("Enter a valid LotNo or No Accepted Qty in Deblocking");
        }
    }

    private void Clear()
    {
       
        txtStartTime.Text = "";
        drpStartTimeDay.Text = "AM";
        drpStopTimeDay.Text = "AM";
        drpShift.Text = "Select";
        txtStartQty.Text = "";
        txtSatrtDate.Text = "";
        txtStopDate.Text = "";
        txtStopTime.Text = "";

        txtRejectionReason.Text = "";
        txtRejectedQty.Text = "0";
        txtRejectedMTS.Text = "";
        txtHydratedBy.Text = "";
        txtDuration.Text = "0";
        txtAccpQty.Text = "0";
    }


    protected void txtAccpQty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAccpQty.Text) > Convert.ToInt32(txtStartQty.Text))
        {
            MessageBox("Accepted Qty is greater than strat Qty");
            txtAccpQty.Text = "";
        }
        else
        {
            try
            {
                txtRejectedQty.Text = Convert.ToString(Convert.ToInt32(txtStartQty.Text) - Convert.ToInt32(txtAccpQty.Text));
                if (txtRejectedQty.Text != "0")
                {
                    txtRejectionReason.Enabled = true;
                    txtRejectedMTS.Enabled = true;
                    txtHydratedBy.Focus();
                }
                else
                {
                    txtRejectionReason.Enabled = false ;
                    txtRejectedMTS.Enabled = false;
                    txtRejectionReason.Text = "";
                    txtRejectedMTS.Text = "";
                }
            }
            catch
            {
            }
        }
    }
    protected void txtLotno_TextChanged(object sender, EventArgs e)
    {
        if (txtLotno.Text.Length < Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            MessageBox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotno.Text = "";
            txtLotno.Focus();
        }
        else
        {
            btnClear.Visible = true;
            Clear();
            txtSatrtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Shift();
            var query = from row in db.Hydrations where row.LotNo == txtLotno.Text select row;
            if (query.Count() > 0)
            {

                txtLotno.Text = query.Single().LotNo.ToString();
                DateTime strDate = query.Single().StartDate.Value;
                txtSatrtDate.Text = strDate.ToString("dd/MM/yyyy");
                string time = query.Single().StartTime.ToString();
                string[] tim = time.Split(':');
                txtStartTime.Text = tim[0] + ":" + tim[1];
                drpStartTimeDay.Text = tim[2];
                txtStartQty.Text = query.Single().StartQty.ToString();
                
                    
                
                if (txtStopDate.Text == "")
                {
                    txtStopDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                try
                {
                    string time1 = query.Single().StopTime.ToString();
                    string[] tim1 = time1.Split(':');
                    txtStopTime.Text = tim1[0] + ":" + tim1[1];
                    drpStopTimeDay.Text = tim1[2];

                    DateTime stpDate = query.Single().StopDate.Value;
                    txtStopDate.Text = stpDate.ToString("dd/MM/yyyy");
                }
                catch
                {
                }
                txtAccpQty.Text = query.Single().Acceptedqty.ToString();
                txtRejectedQty.Text = query.Single().Rejectedqty.ToString();
                txtDuration.Text = query.Single().Duration.ToString();
                txtRejectionReason.Text = query.Single().RejectedReason.ToString();
                txtRejectedMTS.Text = query.Single().RejMTSNo.ToString();
                drpShift.Text = query.Single().Shift.ToString();
                txtHydratedBy.Text = query.Single().Hydratedby.ToString();

                txtAccpQty.Enabled = true;

                txtStopTime.Enabled = true;
                txtHydratedBy.Enabled = true;
                drpStopTimeDay.Enabled = true;
                txtStopDate.Enabled = true;
                txtRejectionReason.Enabled = true;
                txtRejectedMTS.Enabled = true;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                txtStopTime.Focus();
            }
            else
            {
                StartQtyBind();
                txtAccpQty.Enabled = false;
                txtRejectedQty.Enabled = false;
                txtRejectionReason.Enabled = false;
                txtRejectedMTS.Enabled = false;
                txtStopDate.Enabled = false;
                txtStopTime.Enabled = false;
                txtHydratedBy.Enabled = false;
                drpStopTimeDay.Enabled = false;
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                txtStartTime.Focus();

            }
        }
    }




  


    protected void txtStopTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string val = txtStopTime.Text;
            string[] val1 = val.Split(':');
            int hr = Convert.ToInt32(val1[0]);
            int min = Convert.ToInt32(val1[1]);
            if (hr > 12)
            {
                MessageBox("Enter a valid Time");
                txtStopTime.Text = "";
            }
            if (hr == 0)
            {
                MessageBox("Enter a valid Time");
                txtStopTime.Text = "";
            }
            if (min > 59)
            {
                MessageBox("Enter a valid Time");
                txtStopTime.Text = "";
            }
            DurationCal();
        }
        catch
        {
        }
    }

    private void DurationCal()
    {
        try
        {
            string times = DateTime.Now.ToString();
            string[] day = times.Split(' ');
            drpStopTimeDay.Text = day[2];


            var query = from row in db.Hydrations where row.LotNo == txtLotno.Text select row.StartTimeCal;
            DateTime StartTime = Convert.ToDateTime(query.Single().ToString());

            string time = txtStopTime.Text;
            string[] tim = time.Split(':');
            if (tim[0] == "12" && drpStopTimeDay.Text == "PM")
            {
                tim[0] = "12";

            }
            else if (tim[0] == "12" && drpStopTimeDay.Text == "AM")
            {
                tim[0] = "0";

            }
            else
            {
                if (drpStopTimeDay.Text == "PM")
                {
                    tim[0] = Convert.ToString(Convert.ToInt32(tim[0]) + 12);
                }

            }
            string sd =txtStopDate.Text;
            string[] sdat = sd.Split('/');

            DateTime StopTime = new DateTime(Convert.ToInt32(sdat[2]), Convert.ToInt32(sdat[1]), Convert.ToInt32(sdat[0]), Convert.ToInt32(tim[0]), Convert.ToInt32(tim[1]), 0);

            TimeSpan Timespan = StopTime.Subtract(StartTime);

            txtDuration.Text = Timespan.Days.ToString() + "Day:" + Timespan.Hours.ToString() + "Hour:" + Timespan.Minutes.ToString() + "Min";
            string minval = Timespan.Minutes.ToString();
            if (minval.StartsWith("-"))
            {
                txtDuration.Text = "";
                MessageBox("Please Check the given Date & Time");
            }
        }
        catch
        {
        }
    }
    private void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "');", true); 
    }
       
   

    protected void txtStartTime_TextChanged(object sender, EventArgs e)
    {
        if (txtStartTime.Text != "")
        {
            string val = txtStartTime.Text;
            string[] val1 = val.Split(':');
            int hr = Convert.ToInt32(val1[0]);
            int min = Convert.ToInt32(val1[1]);

            if (hr > 12)
            {
                MessageBox("Enter a valid Time");
                txtStartTime.Text = "";
            }

            if (hr == 0)
            {
                MessageBox("Enter a valid Time");
                txtStartTime.Text = "";
            }

            if (min > 59)
            {
                MessageBox("Enter a valid Time");
                txtStartTime.Text = "";
            }

            string tim = DateTime.Now.ToString();
            string[] day = tim.Split(' ');
            drpStartTimeDay.Text = day[2];
        }
    }

   
    protected void drpStopTimeDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        DurationCal();
    }
    protected void txtStopDate_TextChanged(object sender, EventArgs e)
    {
        var query = from row in db.Hydrations where row.LotNo == txtLotno.Text select row.StartTimeCal;
        DateTime StartTime = Convert.ToDateTime(query.Single().ToString());
    
        DurationCal();
        txtStopTime.Focus();
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtStartTime.Text == "")
        {
            MessageBox("Please Enter Start Time");
            txtStartTime.Focus();
        }
       
        else if (txtStartQty.Text == "")
        {
            MessageBox("Please Enter StartQty");
            txtStartQty.Focus();
        }
        else
        {

            SoftLensDataContext db = new SoftLensDataContext();
            if (txtAccpQty.Text == "")
            {
                txtAccpQty.Text = "0";
            }

            string time = txtStartTime.Text;
            string[] tim = time.Split(':');
            if (tim[0] == "12" && drpStartTimeDay.Text == "PM")
            {
                tim[0] = "12";

            }
            else if (tim[0] == "12" && drpStartTimeDay.Text == "AM")
            {
                tim[0] = "0";

            }
            else
            {
                if (drpStartTimeDay.Text == "PM")
                {
                    tim[0] = Convert.ToString(Convert.ToInt32(tim[0]) + 12);
                }

            }
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(tim[0]), Convert.ToInt32(tim[1]), 0);

            //if (txtStopTime.Text == "")
            //{
            //    txtStopTime.Text = "0:0";
            //}
            Hydration hydTable = new Hydration()
            {
                LotNo = txtLotno.Text,
                StartDate = Convert.ToDateTime(txtSatrtDate.Text,provider),
                StartTime = txtStartTime.Text + ":" + drpStartTimeDay.SelectedValue,
                //StopDate = txtStopDate.Text,
                StopTime = txtStopTime.Text + ":" + drpStopTimeDay.SelectedValue,
                StartQty = Convert.ToInt32(txtStartQty.Text),
                Rejectedqty = Convert.ToInt32(txtRejectedQty.Text),
                RejectedReason = txtRejectionReason.Text,
                RejMTSNo = txtRejectedMTS.Text,
                Shift = drpShift.SelectedValue,
         
                Hydratedby = txtHydratedBy.Text,
                Duration = txtDuration.Text,
                Acceptedqty = Convert.ToInt32(txtAccpQty.Text),
                StartTimeCal = dt

            };

            db.Hydrations.InsertOnSubmit(hydTable);
            db.SubmitChanges();

            var query = from r in db.BatchAllots where r.LotNo == txtLotno.Text select r;


            //ReportTable rt = new ReportTable()
            //{
            //    Model= (query.Single().ModelNo),
            //    Power = Convert.ToDecimal(query.Single().Power.ToString()),
            //    LotNo=txtLotno.Text,
            //    Hydration = Convert.ToInt32(txtStartQty.Text),
            //    RuningTumbling = 0,
            //    WaitingPowerSegregation =0,
            //    WaitingTumbling = 0,
            //    WiatingPouchPacking = 0,
            //    Type=1,
            //    Status=1
           
            //};
            //db.ReportTables.InsertOnSubmit(rt);
            //db.SubmitChanges();

            //Clear();
            //txtLotno.Text = "";
            //btnClear.Visible = false;
            //btnSave.Visible = false;
            //btnUpdate.Visible = false;
            //MessageBox("Records Saved");
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        SoftLensDataContext db = new SoftLensDataContext();

        if (txtStopTime.Text == "00:00")
        {
            MessageBox("Please Enter Stop Time");
            txtStopTime.Focus();
        }
        else if (txtAccpQty.Text == "0")
        {
            MessageBox("Please Enter Accepted Qty");
            txtAccpQty.Focus();
        }
        else if (txtDuration.Text=="")
        {
            MessageBox("Please Enter a valid Time");
            txtDuration.Focus();
        }
        else if (txtHydratedBy.Text == "")
        {
            MessageBox("Please Enter Hydrated By");
            txtHydratedBy.Focus();
        }
        else
        {

            var query = from row in db.Hydrations where row.LotNo == txtLotno.Text select row;
            if (query.Count() > 0)
            {
                query.Single().StartDate = Convert.ToDateTime(txtSatrtDate.Text,provider);
                query.Single().StartTime = txtStartTime.Text + ":" + drpStartTimeDay.SelectedValue;
                query.Single().StopDate = Convert.ToDateTime(txtStopDate.Text,provider);
                query.Single().StopTime = txtStopTime.Text + ":" + drpStartTimeDay.SelectedValue;
                query.Single().StartQty = Convert.ToInt32(txtStartQty.Text);
                query.Single().Rejectedqty = Convert.ToInt32(txtRejectedQty.Text);
                query.Single().RejectedReason = txtRejectionReason.Text;
                query.Single().RejMTSNo = txtRejectedMTS.Text;
                query.Single().Shift = drpShift.SelectedValue;
              
                query.Single().Hydratedby = txtHydratedBy.Text;
                query.Single().Duration = txtDuration.Text;
                query.Single().Acceptedqty = Convert.ToInt32(txtAccpQty.Text);
                db.SubmitChanges();

                var query1 = from r in db.BatchAllots where r.LotNo == txtLotno.Text select r;

                //ReportTable rt = new ReportTable()
                //{
                //    Model = (query1.Single().ModelNo),
                //    Power = Convert.ToDecimal(query1.Single().Power.ToString()),
                //    LotNo = txtLotno.Text,
                //    WaitingTumbling  = Convert.ToInt32(txtAccpQty.Text),
                //    Hydration = 0,
                //    RuningTumbling = 0,
                //    WaitingPowerSegregation = 0,
                //    WiatingPouchPacking = 0,
                //    Type = 2,
                //    Status = 2

                //};
                //db.ReportTables.InsertOnSubmit(rt);
                //db.SubmitChanges();

                //var query2 = from r in db.ReportTables where r.LotNo == txtLotno.Text && r.Type == 1 select r;
                //db.ReportTables.DeleteAllOnSubmit(query2);
                //db.SubmitChanges();

                btnClear.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                Clear();
                txtLotno.Text = "";
                MessageBox("Records Updated");
            }
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        txtLotno.Text = "";
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }
    protected void txtHydratedBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtHydratedBy.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtHydratedBy.Text = up.ToUpper();
        }
        else
        {
            MessageBox("Please Enter With INITIAL ex: M.BALAJI");
            txtHydratedBy.Text = "";
            txtHydratedBy.Focus();

        }

    }
    protected void txtRejectionReason_TextChanged(object sender, EventArgs e)
    {
        string up = txtRejectionReason.Text;
        txtRejectionReason.Text = up.ToUpper();  
    }
}
