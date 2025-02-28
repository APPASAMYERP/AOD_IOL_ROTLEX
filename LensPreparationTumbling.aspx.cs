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
using System.Collections.Generic;
using AjaxControlToolkit;
public partial class LensPreparationTumbling : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    private void clear()
    {
        txtDuration.Text = "0";
        txtJarNo.Text = "";
        txtLocation.Text = "";
        txtModelNo.Text = "";
        txtQty.Text = "0";
        txtRemarks.Text = "";
        txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtStartTime.Text = "";
        txtStopDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtStopTime.Text = "";
        txtTumbledBy.Text = "";
       
        ddlStartDay.Text = "AM";
        ddlStopDay.Text = "AM";
        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    protected void txtTumblingNo_TextChanged(object sender, EventArgs e)
    {
        clear();
        btnClear.Visible = true;
        txtStartDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        if (txtTumblingNo.Text.Length < 11)
        {
            Messagebox("Enter the LOTNO with  11 digit No ex: PHYT1312001");
            txtTumblingNo.Text = "";
            txtTumblingNo.Focus();
        }
        else
        {
            string t = txtTumblingNo.Text;
            txtTumblingNo.Text = t.ToUpper();
            var q = from row in db.Tumblings where row.TumblingLotNo == txtTumblingNo.Text select row;
            
            if (q.Count() > 0)
            {
                txtDuration.Text = q.Single().Duration;
                txtJarNo.Text = q.Single().JarNo;
                txtLocation.Text = q.Single().Location;
                txtModelNo.Text = q.Single().ModelNo.ToString();
                txtQty.Text = q.Single().TotalQuantity.ToString();
                txtRemarks.Text = q.Single().Remarks;
                DateTime startd = q.Single().StartDate.Value;
                                                 
                txtStartDate.Text = startd.ToString("dd/MM/yyyy");
                
                string starttim = q.Single().StartTime;
                string[] starttime = starttim.Split(':');
                txtStartTime.Text = starttime[0] + ":" + starttime[1];
                ddlStartDay.Text = starttime[2];
                try
                {
                    string stoptim = q.Single().StopTime;
                    string[] stoptime = stoptim.Split(':');
                    txtStopTime.Text = stoptime[0] + ":" + stoptime[1];
                    ddlStopDay.Text = stoptime[2];

                    DateTime stopd = q.Single().StopDate.Value;
                    txtStopDate.Text = stopd.ToString("dd/MM/yyyy");
                }
                catch
                {

                }
                
                if (txtStopDate.Text == "")
                {
                    txtStopDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }

                txtTumbledBy.Text = q.Single().Tumbledby;

                txtTumbledBy.Enabled = true;
                txtRemarks.Enabled = true;
            }
            else
            {
                txtTumbledBy.Enabled = false;
                txtRemarks.Enabled = false;
            }
            DataTable datatable = new DataTable();

            datatable.Columns.Add("SI.No", typeof(int));
            datatable.Columns.Add("Power", typeof(decimal));
            datatable.Columns.Add("LotNo", typeof(int));
            datatable.Columns.Add("qty", typeof(int));

            ArrayList power = new ArrayList();
            ArrayList totQty = new ArrayList();
            ArrayList ProdLotNo = new ArrayList();

            var query = from rows in db.MillingCleanedLens where rows.TumblingNo == txtTumblingNo.Text select rows.LotNo;
            if (query.Count() > 0)
            {

            }
            else
            {
                Messagebox("Enter a valid Tumbling No ex:T1010001 ");
                txtTumblingNo.Text = "";
                txtTumblingNo.Focus();
            }

            int i = 1, qty = 0;
            foreach (var val in query)
            {
                DataRow dataRow = datatable.NewRow();
                dataRow[0] = i;
                var query1 = from rows1 in db.BatchAllots where rows1.LotNo == val select rows1.Power;
                dataRow[1] = query1.Single().Value;
                power.Add(query1.Single().Value);
                dataRow[2] = query1.Single().Value;
                ProdLotNo.Add(query1.Single().Value);
                var query2 = from rows2 in db.MillingCleanedLens where rows2.LotNo == val select rows2.AcceptedQuantity;
                dataRow[3] = query2.Single().Value;
                totQty.Add(query2.Single().Value);
                datatable.Rows.Add(dataRow);
                i++;
                qty = qty + query2.Single().Value;
                var query3 = from rows3 in db.BatchAllots where rows3.LotNo == val select rows3.ModelNo;
                txtModelNo.Text = query3.Single().ToString();
            }
            txtQty.Text = Convert.ToString(qty);

            Session["Power"] = power;
            Session["totQty"] = totQty;
            Session["ProdLotNo"] = ProdLotNo;

            GridView1.DataSource = datatable;

            GridView1.DataBind();
            
            if (txtJarNo.Text == "")
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                txtStopDate.Enabled = true;
                txtStopTime.Enabled = true;
                ddlStopDay.Enabled = true;

            }
            txtJarNo.Focus();
        }
    }

    
    protected void txtStopTime_TextChanged(object sender, EventArgs e)
        {
            if (txtStopTime.Text == "__:__")
            {
                string val = txtStopTime.Text;
                string[] val1 = val.Split(':');
                int hr = Convert.ToInt32(val1[0]);
                int min = Convert.ToInt32(val1[1]);
                if (hr > 12)
                {
                    Messagebox("Enter a valid Time");
                    txtStopTime.Text = "";
                }
                if (hr == 0)
                {
                    Messagebox("Enter a valid Time");
                    txtStopTime.Text = "";
                }
                if (min > 59)
                {
                    Messagebox("Enter a valid Time");
                    txtStopTime.Text = "";
                }

                DurationCal();
                txtRemarks.Focus();
            }
    }

    private void DurationCal()
    {
        try
        {
            string times = DateTime.Now.ToString();
            string[] day = times.Split(' ');
            ddlStopDay.Text = day[2];

            var query = from row in db.Tumblings where row.TumblingLotNo == txtTumblingNo.Text select row.StartTimeCal;
            DateTime StartTime = Convert.ToDateTime(query.Single().ToString());

            string time = txtStopTime.Text;
            string[] tim = time.Split(':');
            if (tim[0] == "12" && ddlStopDay.Text == "PM")
            {
                tim[0] = "12";

            }
            else if (tim[0] == "12" && ddlStopDay.Text == "AM")
            {
                tim[0] = "0";

            }
            else
            {
                if (ddlStopDay.Text == "PM")
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
                Messagebox("Please Check the given Date & Time");
            }
        }
        catch
        {
        }
    }
   
    protected void txtStartTime_TextChanged(object sender, EventArgs e)
    {
        if (txtStartTime.Text != "__:__")
        {
            string val = txtStartTime.Text;
            string[] val1 = val.Split(':');
            int hr = Convert.ToInt32(val1[0]);
            int min = Convert.ToInt32(val1[1]);
            if (hr > 12)
            {
                Messagebox("Enter a valid Time");
                txtStartTime.Text = "";
            }
            if (hr == 0)
            {
                Messagebox("Enter a valid Time");
                txtStartTime.Text = "";
            }
            if (min > 59)
            {
                Messagebox("Enter a valid Time");
                txtStartTime.Text = "";
            }

            string tim = DateTime.Now.ToString();
            string[] day = tim.Split(' ');
            ddlStartDay.Text = day[2];
        }
    }
   
    protected void ddlStopDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        DurationCal();
        txtRemarks.Focus();
    }
    protected void txtStopDate_TextChanged(object sender, EventArgs e)
    {
        DurationCal();
        txtStopTime.Focus();
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        if (txtLocation.Text == "")
        {
            Messagebox("Please Enter Location");
        }
        else if (txtJarNo.Text == "")
        {
            Messagebox("Please Enter JarNo");
        }
        else if (txtStartTime.Text == "")
        {
            Messagebox("Please Enter Start Time");
        }
        else
        {
            string time = txtStartTime.Text;
            string[] tim = time.Split(':');
            if (tim[0] == "12" && ddlStartDay.Text == "PM")
            {
                tim[0] = "12";

            }
            else if (tim[0] == "12" && ddlStartDay.Text == "AM")
            {
                tim[0] = "0";

            }
            else
            {
                if (ddlStartDay.Text == "PM")
                {
                    tim[0] = Convert.ToString(Convert.ToInt32(tim[0]) + 12);
                }

            }
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(tim[0]), Convert.ToInt32(tim[1]), 0);


            ArrayList power = (ArrayList)Session["Power"];
            ArrayList totQty = (ArrayList)Session["totQty"];
            ArrayList ProdLotNo = (ArrayList)Session["ProdLotNo"];

            if (power.Count < 8)
            {
                for (int i = power.Count; i < 8; i++)
                {
                    power.Add("0");

                }
            }
            if (totQty.Count < 8)
            {
                for (int i = totQty.Count; i < 8; i++)
                {
                    totQty.Add("0");

                }
            }
            if (ProdLotNo.Count < 8)
            {
                for (int i = ProdLotNo.Count; i < 8; i++)
                {
                    ProdLotNo.Add("0");

                }
            }
            
            Tumbling tumTable = new Tumbling()
            {
                Duration = txtDuration.Text,
                JarNo = txtJarNo.Text,
                Location = txtLocation.Text,
                ModelNo = txtModelNo.Text,
                //Power1 = Convert.ToDecimal(power[0].ToString()),
                //ProductLotNo1 = Convert.ToInt32(ProdLotNo[0].ToString()),
                //Qty1 = Convert.ToInt32(totQty[0].ToString()),
                Remarks = txtRemarks.Text,
                StartDate = Convert.ToDateTime(txtStartDate.Text,provider),
                StartTime = txtStartTime.Text + ":" + ddlStartDay.Text,
                StartTimeCal = dt.ToString(),
                //StopDate = txtStopDate.Text,
                //StopTime = txtStopTime.Text + ":" + ddlStopDay.Text,
                TotalQuantity = Convert.ToInt32(txtQty.Text),
                Tumbledby = txtTumbledBy.Text,
                TumblingLotNo = txtTumblingNo.Text,
               
            };
            db.Tumblings.InsertOnSubmit(tumTable);
            db.SubmitChanges();

            for (int i = 0; i < ProdLotNo.Count; i++)
            {
                TumblingChild tumchldTable = new TumblingChild()
                {
                    TumblingNo = txtTumblingNo.Text,
                    ModelNo = txtModelNo.Text,
                    LotNo = Convert.ToInt32(ProdLotNo[i].ToString()),
                    Power = Convert.ToDecimal(power[i].ToString()),
                    Quantity = Convert.ToInt32(totQty[i].ToString()),
                    Flag = 1
                };
                db.TumblingChilds.InsertOnSubmit(tumchldTable);
                db.SubmitChanges();
                               
                //ReportTable rt = new ReportTable()
                //{
                //    Model = (txtModelNo.Text),
                //    Power = Convert.ToDecimal(power[i].ToString()),
                //    LotNo =ProdLotNo[i].ToString(),
                //    RuningTumbling = Convert.ToInt32(totQty[i].ToString()),
                //    Hydration = 0,
                //    WaitingPowerSegregation = 0,
                //    WaitingTumbling = 0,
                //    WiatingPouchPacking = 0,
                //    Type = 3,
                //    Status = 1

                //};
                //db.ReportTables.InsertOnSubmit(rt);
                //db.SubmitChanges();
              
                //var query2 = from r in db.ReportTables where r.LotNo == ProdLotNo[i].ToString() && r.Type == 2 select r;
                //db.ReportTables.DeleteAllOnSubmit(query2);
                //db.SubmitChanges();
            }
            Messagebox("Records  saved");
            clear();
            txtTumblingNo.Text = "";
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (txtStopTime.Text == "")
        {
            Messagebox("Please Enter Stop Time");
        }
        else if (txtTumbledBy.Text == "")
        {
            Messagebox("Please Enter Tumbled By");
        }
        else if (txtDuration.Text == "")
        {
            Messagebox("Please Give Proper Date & Time");
        }
        else
        {
            var query = from row in db.Tumblings where row.TumblingLotNo == txtTumblingNo.Text select row;
            query.Single().Duration = txtDuration.Text;
            query.Single().JarNo = txtJarNo.Text;
            query.Single().Location = txtLocation.Text;
            query.Single().ModelNo = txtModelNo.Text;
            query.Single().Remarks = txtRemarks.Text;
            query.Single().StartDate = Convert.ToDateTime(txtStartDate.Text, provider);
            query.Single().StartTime = txtStartTime.Text + ":" + ddlStartDay.Text;
            query.Single().StopDate = Convert.ToDateTime(txtStopDate.Text, provider);
            query.Single().StopTime = txtStopTime.Text + ":" + ddlStopDay.Text;
            query.Single().Tumbledby = txtTumbledBy.Text;
            db.SubmitChanges();
            
            var query1 = (from row in db.TumblingChilds where row.TumblingNo == txtTumblingNo.Text select row).Distinct();
            foreach (var val in query1)
            {
                val.Flag = 2;
            }
            db.SubmitChanges();

            ArrayList power = (ArrayList)Session["Power"];
            ArrayList totQty = (ArrayList)Session["totQty"];
            ArrayList ProdLotNo = (ArrayList)Session["ProdLotNo"];

            //for (int i = 0; i < ProdLotNo.Count; i++)
            //{
            //    var que = from r in db.ReportTables where r.LotNo == ProdLotNo[i].ToString() && r.Type == 4 select r;
            //    if(que.Count() >0)
            //    {
            //        db.ReportTables.DeleteAllOnSubmit(que);
            //    }
            //    ReportTable rt = new ReportTable()
            //    {
            //        Model = txtModelNo.Text,
            //        Power = Convert.ToDecimal(power[i].ToString()),
            //        LotNo =ProdLotNo[i].ToString(),
            //        WaitingPowerSegregation = Convert.ToInt32(totQty[i].ToString()),
            //        Hydration = 0,
            //        RuningTumbling = 0,
            //        WaitingTumbling = 0,
            //        WiatingPouchPacking = 0,
            //        Type = 4,
            //        Status = 2

            //    };
            //    db.ReportTables.InsertOnSubmit(rt);
            //    db.SubmitChanges();

            //    var query2 = from r in db.ReportTables where r.LotNo == ProdLotNo[i].ToString() && r.Type ==3 select r;
            //    db.ReportTables.DeleteAllOnSubmit(query2);
            //    db.SubmitChanges();

            //}

            Messagebox("Recordrs Updated");
            clear();
            txtTumblingNo.Text = "";
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;

        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtTumblingNo.Text = "";
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }
    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();   
    }
    protected void txtTumbledBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtTumbledBy.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtTumbledBy.Text = up.ToUpper();
        }
        else
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtTumbledBy.Text = "";
            txtTumbledBy.Focus();

        }
    }
    protected void txtJarNo_TextChanged(object sender, EventArgs e)
    {
        string jar = txtJarNo.Text;
        if (jar.Length == 5)
        {
            try
            {

                //if ((jar[0] == 'f' || jar[0] == 'F') && (jar[1] == 'J' || jar[1] == 'j') )
                if ((jar[0] >= 65 && jar[0] <= 122) && (jar[1] >= 65 && jar[1] <= 122))
                {
                    txtJarNo.Text = jar.ToUpper();
                    txtLocation.Focus();
                }
                else
                {
                    Messagebox("Please Enter in format ex: fj134 ");
                    txtJarNo.Text = "";
                    txtJarNo.Focus();
                }
                if((jar[2]>=48 && jar[2]<=57)&&(jar[3]>=48 && jar[3]<=57) && (jar[4]>=48 && jar[4]<=57))
                {
                    txtJarNo.Text = jar.ToUpper();
                    txtLocation.Focus();
                }
                else
                {
                    Messagebox("Please Enter in format ex: fj134 ");
                    txtJarNo.Text = "";
                    txtJarNo.Focus();
                }
            }
            catch
            {
                Messagebox("ex: fj134 ");
                txtJarNo.Text = "";
                txtJarNo.Focus();
            }
        }
        else
        {
            Messagebox("Please Enter in format ex: fj134 ");
            txtJarNo.Text = "";
            txtJarNo.Focus();
        }
    }
    protected void txtLocation_TextChanged(object sender, EventArgs e)
    {
        string loc = txtLocation.Text;
        if (loc.Length == 3)
        {
            if (loc[0] >= 65 && loc[0] <= 122)
            {
                txtLocation.Text = loc.ToUpper();
                txtStartDate.Focus();
            }
            else
            {
                Messagebox("Please Enter in format ex: B12");
                txtLocation.Text = "";
                txtLocation.Focus();
            }
            if ((loc[1] >= 48 && loc[1] <= 57) && (loc[2] >= 48 && loc[2] <= 57) )
            {
                txtLocation.Text = loc.ToUpper();
                txtStartDate.Focus();
            }
            else
            {
                Messagebox("Please Enter in format ex: B12 ");
                txtLocation.Text = "";
                txtLocation.Focus();
            }
        }
        else
        {
            Messagebox("Please Enter in format ex: B12");
            txtLocation.Text = "";
            txtLocation.Focus();
        }
    }
}
