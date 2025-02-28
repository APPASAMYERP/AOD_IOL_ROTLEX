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

public partial class GlassyTumblingSI : System.Web.UI.Page
{

    #region Declarations

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext SL = new SoftLensDataContext();

    #endregion Declarations

    #region Methods

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void clear()
    {

        txtLotNo.Text = "";
        txtGFF.Text = "";
        txtMoNo.Text = "";
        //txtphob.Text = "";
        txtGTPower.Text = "";
        txtGTJarNo.Text = "";
        txtGTStartTime.Text = "";
        txtGTStopTime.Text = "";
        txtGTDuration.Text = "";
        txtRemarks1.Text = "";
        txtGTDate.Text = "";
        txtInspectedBy1.Text = "";
        ChkbAccepted1.Checked = true;
        chkbAccepted2.Checked = true;
        chkbAccepted3.Checked = true;
        chkbRejected1.Checked = false;
        chkbRejected2.Checked = false;
        chkbRejected3.Checked = false;
    }

    private void GridBind()
    {
        var q = from f in SL.GlassyTumblingSOs where f.GRFLotNo == txtLotNo.Text select f;
        GridView1.DataSource = q;
        GridView1.DataBind();
    }

    private bool validation1()
    {
        bool _isvalid = true;

        if (txtLotNo.Text == "")
        {
            Messagebox("Please enter Glassy Tumbling Ref No");
            txtLotNo.Focus();
            _isvalid = false;
        }
        else if (txtGTJarNo.Text == "")
        {
            Messagebox("Please enter Jar No");
            txtGTJarNo.Focus();
            _isvalid = false;
        }
        else if (txtGTStartTime.Text == "")
        {
            Messagebox("Please enter Start Time");
            txtGTStartTime.Focus();
            _isvalid = false;
        }
        else if (txtGTStopTime.Text == "")
        {
            Messagebox("Please enter Stop Time");
            txtGTStopTime.Focus();
            _isvalid = false;
        }
        else if (txtGTDuration.Text.StartsWith("-"))
        {
            Messagebox("Please check the Duration");
            txtGTDuration.Focus();
            _isvalid = false;
        }
        else if (txtRemarks1.Text == "")
        {
            Messagebox("Please Enter the Remarks");
            txtRemarks1.Focus();
            _isvalid = false;
        }
        else if (txtInspectedBy1.Text == "")
        {
            Messagebox("Please enter Inspected By");
            txtInspectedBy1.Focus();
            _isvalid = false;
        }
        //else if (txtphob.Text == "")
        //{
        //    Messagebox("Please Enter the Phob Id");
        //    txtphob.Focus();
        //    _isvalid = false;
        //}
        return _isvalid;
    }

    private void SaveMethod()
    {

        GlassyTumblingSO GT = new GlassyTumblingSO();

        GT.GRFLotNo = txtLotNo.Text;
        GT.TumblingLotNo = txtGFF.Text;
        GT.ModelNo = txtMoNo.Text;
        GT.Power = Convert.ToDecimal(txtGTPower.Text);
        GT.JarNo = txtGTJarNo.Text;
        GT.SampleDate = Convert.ToDateTime(txtGTDate.Text, provider);
        GT.StartTime = Convert.ToDateTime(txtGTStartTime.Text).ToString("HH:mm tt");
        GT.EndTime = Convert.ToDateTime(txtGTStopTime.Text).ToString("HH:mm tt");
        GT.Duration = Convert.ToDateTime(txtGTDuration.Text).ToString("HH:mm");



        if (ChkbAccepted1.Checked == true)
        {
            GT.Sample1Status = "Accepted";
        }
        else
        {
            GT.Sample1Status = "Rejected";
        }

        if (chkbAccepted2.Checked == true)
        {
            GT.Sample2Status = "Accepted";
        }
        else
        {
            GT.Sample2Status = "Rejected";
        }

        if (chkbAccepted3.Checked == true)
        {
            GT.Sample3Status = "Accepted";
        }
        else
        {
            GT.Sample3Status = "Rejected";
        }
        GT.SampleRemarks = txtRemarks1.Text;
        GT.SampleInspectedBy = txtInspectedBy1.Text;
        //GT.phob_id = txtphob.Text;       
        SL.GlassyTumblingSOs.InsertOnSubmit(GT);
        SL.SubmitChanges();
        btnSave.Visible = false;
        Messagebox("Saved Successfully");
    }

    #endregion Methods

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        //txtGTDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }

    protected void ChkbAccepted1_CheckedChanged(object sender, EventArgs e)
    {
        ChkbAccepted1.Checked = true;
        chkbRejected1.Checked = false;
    }

    protected void chkbRejected1_CheckedChanged(object sender, EventArgs e)
    {
        ChkbAccepted1.Checked = false;
        chkbRejected1.Checked = true;
    }

    protected void chkbAccepted2_CheckedChanged(object sender, EventArgs e)
    {
        chkbAccepted2.Checked = true;
        chkbRejected2.Checked = false;
    }

    protected void chkbRejected2_CheckedChanged(object sender, EventArgs e)
    {
        chkbAccepted2.Checked = false;
        chkbRejected2.Checked = true;

    }

    protected void chkbAccepted3_CheckedChanged(object sender, EventArgs e)
    {
        chkbAccepted3.Checked = true;
        chkbRejected3.Checked = false;
    }

    protected void chkbRejected3_CheckedChanged(object sender, EventArgs e)
    {
        chkbAccepted3.Checked = false;
        chkbRejected3.Checked = true;
    }

    //protected void txtLotNo_TextChanged(object sender, EventArgs e)
    //{
    //    if (txtLotNo.Text.Length < Convert.ToInt32(Session["LotNoMaxLength"]))
    //    {
    //        Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
    //        txtLotNo.Text = "";
    //        txtLotNo.Focus();
    //    }

    //    try
    //    {
    //        clear();
    //        txtDate1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

    //        SoftLensDataContext SL = new SoftLensDataContext();
    //        txtRemarks1.Focus();


    //        if (Label1.Text == " MicroScopic Inspection With Collect")
    //        {
    //            var val = from f in SL.Lathecuts where f.LotNo == txtLotNo.Text && f.LatheType == txtCutType.Text select f;
    //            if (val.Count() == 0)
    //            {
    //                Messagebox("Please Enter the Correct Lot No ");
    //                txtLotNo.Focus();
    //                txtLotNo.Text = "";
    //            }
    //            else
    //            {
    //                btnSave.Visible = true;
    //                btnClear.Visible = true;
    //            }


    //        }
    //        if (Label1.Text == "Sample Inspection For Milling")
    //        {
    //            var val = from f in SL.Millings where f.LotNo == txtLotNo.Text select f;
    //            if (val.Count() == 0)
    //            {
    //                Messagebox("Please Enter the Correct Lot No ");
    //                txtLotNo.Focus();
    //                txtLotNo.Text = "";
    //            }
    //            else
    //            {
    //                btnSave.Visible = true;
    //                btnClear.Visible = true;
    //            }

    //        }

    //        var q = from f in SL.MicroscopicInspections where f.LotNo == txtLotNo.Text && f.BlockingType == txtCutType.Text select f;
    //        if (q.Count() == 0)
    //        {
    //            btnSave.Visible = true;
    //            btnUpdate.Visible = false;
    //            btnClear.Visible = true;
    //        }
    //        else
    //        {
    //            btnSave.Visible = false;
    //            btnUpdate.Visible = false;
    //            btnClear.Visible = true;
    //        }
    //        GridView1.DataSource = q;
    //        GridView1.DataBind();
    //    }
    //    catch (Exception)
    //    {

    //    }


    //}

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (validation1())
        {
            SaveMethod();
            clear();
            GridBind();
            btnClear.Visible = false;
            txtLotNo.Text = "";
        }
    }

    //protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (txtLotNo.Text == "")
    //    {
    //        Messagebox("Please Enter Lot No ");
    //        txtLotNo.Focus();
    //    }
    //    else if (txtInspectedBy1.Text == "")
    //    {
    //        Messagebox("Please Enter InspectedBy");
    //        txtInspectedBy1.Focus();
    //    }
    //    else
    //    {
    //        try
    //        {
    //            //Update();
    //            GridBind();

    //            txtLotNo.Text = "";
    //            clear();
    //            btnSave.Visible = false;
    //            btnUpdate.Visible = false;
    //            btnClear.Visible = false;
    //            txtLotNo.Enabled = true;
    //        }
    //        catch (Exception ex)
    //        {

    //        }
    //    }
    //}

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false; ;
        btnSave.Visible = false;
        btnClear.Visible = false;
        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    protected void txtInspectedBy1_TextChanged(object sender, EventArgs e)
    {
        string up = txtInspectedBy1.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtInspectedBy1.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter INITIAL ex: M.BALAJI");
                txtInspectedBy1.Text = "";
                txtInspectedBy1.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter INITIAL ex: M.BALAJI");
            txtInspectedBy1.Text = "";
            txtInspectedBy1.Focus();
        }
    }

    protected void txtRemarks1_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks1.Text;
        txtRemarks1.Text = up.ToUpper();
        txtInspectedBy1.Focus();
    }

    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Session["up"].Equals(1))
    //    {
    //        btnSave.Visible = false;
    //        btnClear.Visible = true;
    //        btnUpdate.Visible = true;
    //        SoftLensDataContext db = new SoftLensDataContext();

    //        txtLotNo.Text = GridView1.SelectedRow.Cells[1].Text;
    //        if (GridView1.SelectedRow.Cells[4].Text == "Accepted")
    //        {
    //            ChkbAccepted1.Checked = true;

    //        }
    //        else
    //        {
    //            ChkbAccepted1.Checked = false;
    //            chkbRejected1.Checked = true;
    //        }



    //        if (GridView1.SelectedRow.Cells[5].Text == "Accepted")
    //        {
    //            chkbAccepted2.Checked = true;
    //        }
    //        else
    //        {
    //            chkbAccepted2.Checked = false;
    //            chkbRejected2.Checked = true;
    //        }

    //        if (GridView1.SelectedRow.Cells[6].Text == "Accepted")
    //        {
    //            chkbAccepted3.Checked = true;
    //        }
    //        else
    //        {
    //            chkbAccepted3.Checked = false;
    //            chkbRejected3.Checked = true;
    //        }
    //        txtRemarks1.Text = GridView1.SelectedRow.Cells[7].Text;
    //        if (txtRemarks1.Text == "&nbsp;")
    //        {
    //            txtRemarks1.Text = "";
    //        }
    //        txtInspectedBy1.Text = GridView1.SelectedRow.Cells[8].Text;
    //        if (Label1.Text == "Sample Inspection For Milling")
    //        {
    //            txtRejMtsNo.Text = GridView1.SelectedRow.Cells[9].Text;
    //            if (txtRejMtsNo.Text == "&nbsp;")
    //            {
    //                txtRejMtsNo.Text = "";
    //            }
    //        }
    //        txtGTDate.Text = GridView1.SelectedRow.Cells[10].Text;
    //    }
    //    else
    //    {
    //        Messagebox("Permission is denied");
    //    }
    //}

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        string t = txtLotNo.Text;
        txtLotNo.Text = t.ToUpper();
        var query3 = from row in SL.GlassyTumblingSOs where row.GRFLotNo == txtLotNo.Text select row;
        if (query3.Count() > 0)
        {
            GridView1.DataSource = query3;
            GridView1.DataBind();
            btnSave.Visible = false;
            btnClear.Visible = true;
        }
        else
        {
            var query1 = from row in SL.PowerSegregationChilds where row.GlassyRecordRef == txtLotNo.Text select row;
            var q1 = from row in SL.PowerSegregationChilds where row.GlassyRecordRef == txtLotNo.Text select row;
            if (query1.Count() > 0)
            {
                txtGFF.Text = query1.Single().TumblingNo.ToString();
                txtGTPower.Text = query1.Single().Power.ToString();
                btnSave.Visible = true;
                btnClear.Visible = true;
                var query2 = from row in SL.RemattTumblingLens where row.RetumblingRef1 == txtGFF.Text && row.Power1 == Convert.ToDecimal(txtGTPower.Text) select row;
                var query5 = from row in SL.RemattTumblingLens where row.RetumblingRef2 == txtGFF.Text && row.Power2 == Convert.ToDecimal(txtGTPower.Text) select row;
                var query7 = from row in SL.RemattTumblingLens where row.RetumblingRef3 == txtGFF.Text && row.Power3 == Convert.ToDecimal(txtGTPower.Text) select row;
                //var query6 = from row in SL.MattTumblingLens where row.TumblingLotNo == txtGFF.Text select row;
                var query6 = from row in SL.FinalLensPreparations where row.TumblingNo == txtGFF.Text select row;
                if (query2.Count() > 0)
                {
                    txtMoNo.Text = query2.Single().Model1.ToString();
                    //txtphob.Text = query2.Single().TumblingLotNo.ToString();
                }
                else if (query5.Count() > 0)
                {
                    txtMoNo.Text = query5.Single().Model2.ToString();
                    //txtphob.Text = query5.Single().TumblingLotNo.ToString();
                }
                else if (query7.Count() > 0)
                {
                    txtMoNo.Text = query7.Single().Model3.ToString();
                    //txtphob.Text = query7.Single().TumblingLotNo.ToString();
                }
                else
                {
                    txtMoNo.Text = query6.Single().Model.ToString();
                    //txtphob.Text = query6.Single().TumblingNo.ToString();
                }
                //var query4 = (from row in SL.SO_MattTumblings where row.TumblingNo == txtGFF.Text select row).Take(1).SingleOrDefault();
                //txtGTJarNo.Text = query4.JarNo.ToString();                

            }
            //else if (q1.Count() > 0)
            //{
            //    txtGFF.Text = q1.Single().TumblingNo.ToString();
            //    txtGTPower.Text = q1.Single().Power.ToString();
            //    btnSave.Visible = true;
            //    btnClear.Visible = true;
            //    var q2 = from row in SL.RemattTumblingLens where row.RetumblingRef2 == txtGFF.Text select row;
            //    txtMoNo.Text = q2.Single().Model2.ToString();
            //    txtphob.Text = q2.Single().TumblingLotNo.ToString();
            //    var q3 = (from row in SL.SO_MattTumblings where row.TumblingNo == txtGFF.Text select row).Take(1).SingleOrDefault();
            //    txtGTJarNo.Text = q3.JarNo.ToString();                

            //}
            else
            {
                Messagebox("Enter a valid Glassy Record Ref No");
                txtLotNo.Text = "";
                txtLotNo.Focus();
            }
        }
    }


    protected void txtGTStartTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string strt = Convert.ToDateTime(txtGTStartTime.Text).ToString();
            txtGTStopTime.Focus();
            //if (btnUpdate.Visible == true)
            //{
            //    try
            //    {
            //        string strtu = Convert.ToDateTime(txtGTStartTime.Text).ToString();
            //        string time1 = Convert.ToDateTime(strtu).ToString("HH:mm");

            //        string strt1 = Convert.ToDateTime(txtGTStopTime.Text).ToString();
            //        string time2 = Convert.ToDateTime(strt1).ToString("HH:mm");

            //        DateTime endTime = Convert.ToDateTime(time2);
            //        DateTime startTime = Convert.ToDateTime(time1);
            //        TimeSpan span = endTime.Subtract(startTime);
            //        txtGTDuration.Text = span.ToString();
            //        if (txtGTDuration.Text.StartsWith("-") && txtGTStopTime.Text != "00:00 AM" || span.Hours > 12)
            //        {
            //            Messagebox("Please Check given Time");
            //            txtGTStartTime.Text = "00:00 AM";
            //            txtGTStartTime.Focus();
            //            txtGTDuration.Text = "00:00:00";
            //        }
            //    }
            //    catch
            //    {

            //        Messagebox("Please Enter correct format ex: 01:56");
            //        txtGTStartTime.Text = "00:00 AM";
            //        txtGTStartTime.Focus();

            //    }
            //}
        }
        catch
        {
            //Messagebox("Please in correct format ex: 06:56 AM");
        }
    }

    protected void txtGTStopTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string strt = Convert.ToDateTime(txtGTStartTime.Text).ToString();
            string time1 = Convert.ToDateTime(strt).ToString("HH:mm");

            string strt1 = Convert.ToDateTime(txtGTStopTime.Text).ToString();
            string time2 = Convert.ToDateTime(strt1).ToString("HH:mm");

            DateTime endTime = Convert.ToDateTime(time2);
            DateTime startTime = Convert.ToDateTime(time1);
            TimeSpan span = endTime.Subtract(startTime);
            txtGTDuration.Text = span.ToString();
            txtRemarks1.Focus();
            if (txtGTDuration.Text.StartsWith("-") || span.Hours > 12)
            {
                Messagebox("Please Check given Time");
                txtGTStartTime.Focus();
                txtGTStopTime.Text = "00:00 AM";
                txtGTDuration.Text = "00:00:00";
            }
        }
        catch
        {
            //Messagebox("Please Enter correct format ex: 01:56");
            //txtGTStartTime.Text = "00:00 AM";
            //txtGTStartTime.Focus();
            //txtGTStopTime.Text = "00:00 PM";
            //txtGTStopTime.Focus();
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        GlassyTumblingSO GT = new GlassyTumblingSO();
        var query = (from a in SL.GlassyTumblingSOs where a.GRFLotNo == txtLotNo.Text select a).FirstOrDefault();
        txtLotNo.Enabled = false;
        txtGFF.Text = GridView1.SelectedRow.Cells[2].Text;
        txtMoNo.Text = GridView1.SelectedRow.Cells[4].Text;
        txtGTPower.Text = GridView1.SelectedRow.Cells[5].Text;
        txtGTJarNo.Text = GridView1.SelectedRow.Cells[6].Text;
        txtGTDate.Text = GridView1.SelectedRow.Cells[7].Text;
        if (GridView1.SelectedRow.Cells[8].Text == "Accepted")
        {
            ChkbAccepted1.Checked = true;
            if (ChkbAccepted1.Enabled == true)
            {
                ChkbAccepted1.Enabled = false;
                chkbRejected1.Enabled = false;
            }

        }
        else
        {
            ChkbAccepted1.Checked = false;


            chkbRejected1.Checked = true;

            if (chkbRejected1.Enabled == true)
            {
                chkbRejected1.Enabled = false;
            }
        }
        if (GridView1.SelectedRow.Cells[9].Text == "Accepted")
        {
            chkbAccepted2.Checked = true;
            if (chkbAccepted2.Checked == true)
            {
                chkbAccepted2.Enabled = false;
            }
        }
        else
        {
            chkbAccepted2.Checked = false;
            if (chkbAccepted2.Checked == false)
            {
                chkbAccepted2.Enabled = false;
            }
            chkbRejected2.Checked = true;
            if (chkbRejected2.Checked == true)
            {
                chkbRejected2.Enabled = false;
            }
        }
        if (GridView1.SelectedRow.Cells[10].Text == "Accepted")
        {
            chkbAccepted3.Checked = true;
            if (chkbAccepted3.Checked == true)
            {
                chkbAccepted3.Enabled = false;
                chkbRejected3.Enabled = false;
            }
        }
        else
        {
            chkbAccepted3.Checked = false;
            chkbAccepted3.Checked = false;
            if (chkbAccepted3.Checked == false)
            {
                chkbAccepted3.Enabled = false;
            }

            chkbRejected3.Checked = true;
            if (chkbRejected3.Enabled == true)
            {
                chkbRejected3.Enabled = false;
            }
        }

        txtGTStartTime.Text = query.StartTime;
        txtGTStartTime.Enabled = false;
        txtGTStopTime.Text = query.EndTime;
        txtGTStopTime.Enabled = false;
        txtGTDuration.Text = query.Duration;

        txtRemarks1.Text = GridView1.SelectedRow.Cells[11].Text;
        txtRemarks1.Enabled = false;
        txtInspectedBy1.Text = GridView1.SelectedRow.Cells[12].Text;
        txtInspectedBy1.Enabled = false;
        //txtphob.Text=GridView1.SelectedRow.Cells[3].Text;  

        btnUpdate.Visible = true;

    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        txtLotNo.Enabled = true;
        txtGFF.Enabled = true;
        txtMoNo.Enabled = true;
        txtGTPower.Enabled = true;
        txtGTJarNo.Enabled = true;
        txtGTDate.Enabled = true;
        ChkbAccepted1.Enabled = true;
        chkbRejected1.Enabled = true;
        chkbAccepted2.Enabled = true;
        chkbRejected2.Enabled = true;
        chkbAccepted3.Enabled = true;
        chkbRejected3.Enabled = true;
        txtGTStartTime.Enabled = true;
        txtGTStopTime.Enabled = true;
        txtRemarks1.Enabled = true;
        txtInspectedBy1.Enabled = true;
        //txtphob.Enabled = true;

    }
    #endregion Events



}