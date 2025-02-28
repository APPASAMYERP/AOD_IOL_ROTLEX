using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HydrationAfterTumbling : System.Web.UI.Page
{
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    private void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "');", true);
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
            drpShift.SelectedIndex =3;

        }

    }

    private void Clear()
    {
       
        txtStartTime.Text = "";
        drpStartTimeDay.Text = "AM";
        drpStopTimeDay.Text = "AM";
        drpShift.Text = "Select";
        txtStartQty.Text = "";
        txtStopDate.Text = "";
        txtStopTime.Text = "";
             
        txtRejectionReason.Text = "";
        txtRejectedQty.Text = "";
        txtRejectedMTS.Text = "";
        txtHydratedBy.Text = "";
        txtDuration.Text = "";
        txtAccpQty.Text = "";
    }


   
    protected void txtTumblingNo_TextChanged(object sender, EventArgs e)
    {
        Clear();
        btnClear.Visible = true;
        txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        if (txtTumblingNo.Text.Length < 8)
        {
            MessageBox("Enter the LOTNO with  8 digit No ex: 10100001");
            txtTumblingNo.Text = "";
            txtTumblingNo.Focus();
        }
        else
        { 
                    string lot = txtTumblingNo.Text;
                    txtTumblingNo.Text = lot.ToUpper();
            string yr = System.DateTime.Now.ToString("yy");
            string mon = System.DateTime.Now.ToString("MM");
            if (lot[0] == 't' || lot[0] == 'T' && lot.Substring(1, 2) == yr && lot.Substring(3, 2) == mon)
            {
            }
            else
            {
                MessageBox("Enter In correct Format ex: T1007001 ");
            }
            Shift();
            var query = from row in db.HydrationAftTumblings where row.TumblingLotNo == txtTumblingNo.Text select row;
            if (query.Count() > 0)
            {

                txtStartDate.Text = query.Single().StartDate.ToString();
                string time = query.Single().StartTime.ToString();
                string[] tim = time.Split(':');
                txtStartTime.Text = tim[0] + ":" + tim[1];
                drpStartTimeDay.Text = tim[2];
                txtStartQty.Text = query.Single().StartQty.ToString();
                try
                {
                    txtStopDate.Text = query.Single().StopDate.ToString();

                    string time1 = query.Single().StopTime.ToString();
                    string[] tim1 = time1.Split(':');
                    txtStopTime.Text = tim1[0] + ":" + tim1[1];
                    drpStopTimeDay.Text = tim1[2];
                    txtDuration.Text = query.Single().Duration.ToString();
                    txtRejectionReason.Text = query.Single().RejectedReason.ToString();
                    txtRejectedMTS.Text = query.Single().RejMTSNo.ToString();
                    txtHydratedBy.Text = query.Single().Hydratedby.ToString();
                }
                catch
                {
                }
                if (txtStopDate.Text == "")
                {
                    txtStopDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                txtAccpQty.Text = query.Single().Acceptedqty.ToString();
                txtRejectedQty.Text = query.Single().Rejectedqty.ToString();

                drpShift.Text = query.Single().Shift.ToString();


                txtAccpQty.Enabled = true;

                txtStopTime.Enabled = true;
                txtHydratedBy.Enabled = true;
                drpStopTimeDay.Enabled = true;
                txtRejectionReason.Enabled = true;
                txtRejectedMTS.Enabled = true;
                txtStopDate.Enabled = true;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {

                var q = from row in db.Tumblings where row.TumblingLotNo == txtTumblingNo.Text select row.TotalQuantity;

                if (q.Count() > 0)
                {
                    txtStartQty.Text = q.Single().Value.ToString();
                }
                else
                {
                    MessageBox("Enter a valid Tumbling No ex: T1007001");
                    txtTumblingNo.Text = "";
                    txtTumblingNo.Focus();
                }

                txtAccpQty.Enabled = false;
                txtRejectedQty.Enabled = false;
                txtRejectionReason.Enabled = false;
                txtRejectedMTS.Enabled = false;
                txtStopTime.Enabled = false;
                txtStopDate.Enabled = false;
                txtHydratedBy.Enabled = false;
                drpStopTimeDay.Enabled = false;
                btnSave.Visible = true;
                btnUpdate.Visible = false;

            }
        }
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
                if (txtRejectedQty.Text != "")
                {
                    txtRejectionReason.Enabled = true;
                    txtRejectedMTS.Enabled = true;
                }
                else
                {
                    txtRejectionReason.Enabled = false;
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
   
    protected void txtStopTime_TextChanged(object sender, EventArgs e)
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
        string tim = DateTime.Now.ToString();
        string[] day = tim.Split(' ');
        drpStopTimeDay.Text = day[2];
        DurationCal();
    }
    protected void drpStopTimeDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        var query = from row in db.HydrationAftTumblings where row.TumblingLotNo == txtTumblingNo.Text select row.StartTimeCal;
        DateTime StartTime = Convert.ToDateTime(query.Single().ToString());
        DurationCal();

 }

    private void DurationCal()
    {
        try
        {
            string times = DateTime.Now.ToString();
            string[] day = times.Split(' ');
            drpStopTimeDay.Text = day[2];


            var query = from row in db.HydrationAftTumblings where row.TumblingLotNo == txtTumblingNo.Text select row.StartTimeCal;
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
            string sd = txtStopDate.Text;
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
  
    protected void txtStopDate_TextChanged(object sender, EventArgs e)
    {
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

        else
        {

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


            HydrationAftTumbling hydTable = new HydrationAftTumbling()
            {

                Shift = drpShift.Text,
                StartDate = txtStartDate.Text,
                StartTime = txtStartTime.Text + ":" + drpStartTimeDay.SelectedValue,
                StartQty = Convert.ToInt32(txtStartQty.Text),
                StartTimeCal = dt.ToString(),
                TumblingLotNo = txtTumblingNo.Text
            };
            db.HydrationAftTumblings.InsertOnSubmit(hydTable);
            db.SubmitChanges();
            Clear();
            txtTumblingNo.Text = "";
            MessageBox("Records Saved");
            btnSave.Visible = false;
            btnClear.Visible = false;
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (txtStopTime.Text == "")
        {
            MessageBox("Please Enter Stop Time");
            txtStopTime.Focus();
        }
        else if (txtAccpQty.Text == "")
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

            var query = from row in db.HydrationAftTumblings where row.TumblingLotNo == txtTumblingNo.Text select row;
            if (query.Count() > 0)
            {
                query.Single().StartDate = txtStopDate.Text;
                query.Single().StartTime = txtStartTime.Text + ":" + drpStartTimeDay.SelectedValue;
                query.Single().StopDate = txtStopDate.Text;
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
                btnUpdate.Visible = false;
                btnClear.Visible = false;
                Clear();
                txtTumblingNo.Text = "";
                MessageBox("Records Updated");
            }
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        txtTumblingNo.Text = "";
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }
    protected void txtRejectionReason_TextChanged(object sender, EventArgs e)
    {
        string up = txtRejectionReason.Text;
        txtRejectionReason.Text = up.ToUpper();   
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
}