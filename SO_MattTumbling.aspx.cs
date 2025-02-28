using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class SI_DuringTumbling_ : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    private void Clear()
    {
        txtModelNo.Text = "";
        txtJarNo.Text = "";
        txtDuration.Text = "";
        txtDateIsnpection.Text = "";
        txtTime.Text = "";
        ddlDay.Text = "AM";
        txtPower.Text = "";
        chkcontinueremarks.Checked = true;
        chkAccepted.Checked = true;
        chkStopRemarks.Checked = false;
        chkRejected.Checked = false;
        txtInspectedBy.Text = "";
        gvTumblingInspection.DataSource = null;
        gvTumblingInspection.DataBind();
    }


    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }





    #region chkbox Change Event
    protected void chkAccepted_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAccepted.Checked == true)
        {
            chkRejected.Checked = false;
        }
        else
        {
            chkRejected.Checked = true;
            chkcontinueremarks.Focus();
        }

    }
    protected void chkRejected_CheckedChanged(object sender, EventArgs e)
    {
        if (chkRejected.Checked == true)
        {
            chkAccepted.Checked = false;
        }
        else
        {
            chkAccepted.Checked = true;
            chkcontinueremarks.Focus();
        }

    }





    protected void chkcontinue_CheckedChanged(object sender, EventArgs e)
    {
        if (chkcontinueremarks.Checked == true)
        {
            chkStopRemarks.Checked = false;
        }
        else
        {
            chkStopRemarks.Checked = true;
            txtInspectedBy.Focus();
        }
    }
    protected void chkStop_CheckedChanged(object sender, EventArgs e)
    {
        if (chkStopRemarks.Checked == true)
        {
            chkcontinueremarks.Checked = false;
        }
        else
        {
            chkcontinueremarks.Checked = true;
            txtInspectedBy.Focus();
        }
    }
    #endregion

    private void gvTumblingInspectionBind()
    {
        var q = from r in db.SO_MattTumblings where r.TumblingNo == txtTumblingNo.Text select r;
        if (q.Count() > 0)
        {
            gvTumblingInspection.DataSource = q;
            gvTumblingInspection.DataBind();
        }
    }


    protected void txtTumblingNo_TextChanged(object sender, EventArgs e)
    {

        gvTumblingInspectionBind();
        string t = txtTumblingNo.Text;
        txtTumblingNo.Text = t.ToUpper();

        //var query1 = from row in db.MattTumblingLens where row.TumblingLotNo == txtTumblingNo.Text select row;
        var query1 = from row in db.FinalLensPreparations where row.TumblingNo == txtTumblingNo.Text select row;

        if (query1.Count() == 0)
        {
            var query2 = from row in db.RemattTumblingLens where row.RetumblingRef1 == txtTumblingNo.Text select row;
            if (query2.Count() > 0)
            {
                txtModelNo.Text = query2.Single().Model1.ToString();
                //txtPower.Text = query2.Single().Power1.ToString();
                btnSave.Visible = true;
                btnClear.Visible = true;

                try
                {
                    string rem = gvTumblingInspection.Rows[gvTumblingInspection.Rows.Count - 1].Cells[11].Text;
                    if (rem == "Stop")
                    {
                        btnSave.Visible = false;
                    }
                }
                catch
                {
                }
            }

            var query3 = from row in db.RemattTumblingLens where row.RetumblingRef2 == txtTumblingNo.Text select row;
            if (query3.Count() > 0)
            {

                txtModelNo.Text = query3.Single().Model2.ToString();
                //txtPower.Text = query3.Single().Power2.ToString();
                btnSave.Visible = true;
                btnClear.Visible = true;

                try
                {
                    string rem = gvTumblingInspection.Rows[gvTumblingInspection.Rows.Count - 1].Cells[11].Text;
                    if (rem == "Stop")
                    {
                        btnSave.Visible = false;
                    }
                }
                catch
                {
                }
            }
            else
            {
                var query4 = from row in db.RemattTumblingLens where row.RetumblingRef3 == txtTumblingNo.Text select row;
                if (query4.Count() > 0)
                {

                    txtModelNo.Text = query4.Single().Model3.ToString();
                    //txtPower.Text = query4.Single().Power3.ToString();
                    btnSave.Visible = true;
                    btnClear.Visible = true;

                    try
                    {
                        string rem = gvTumblingInspection.Rows[gvTumblingInspection.Rows.Count - 1].Cells[11].Text;
                        if (rem == "Stop")
                        {
                            btnSave.Visible = false;
                        }
                    }
                    catch
                    {
                    }

                }
            }
        }

        if (query1.Count() > 0)
        {
            //txtModelNo.Text = query1.Single().ModelNo.ToString();
            txtModelNo.Text = query1.Single().Model.ToString();
            //txtPower.Text = query1.Single().Power.ToString();
            btnSave.Visible = true;
            btnClear.Visible = true;

            try
            {
                string rem = gvTumblingInspection.Rows[gvTumblingInspection.Rows.Count - 1].Cells[11].Text;
                if (rem == "Stop")
                {
                    btnSave.Visible = false;
                }
            }
            catch
            {
            }
        }

        //else 
        //{

        //    Messagebox("Enter a valid Tumbling No ex:PHYT1312001");
        //    txtTumblingNo.Text = "";
        //    txtTumblingNo.Focus();
        //}

        try
        {
            if (gvTumblingInspection.Rows[gvTumblingInspection.Rows.Count - 1].Cells[7].Text == "Stop")
            {
                btnSave.Visible = false;
            }
        }
        catch
        {
        }
    }

    protected void gvTumblingInspection_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Visible = false;
        btnClear.Visible = true;
        string s, remarks;
        txtJarNo.Text = gvTumblingInspection.SelectedRow.Cells[3].Text;
        ddlSampleNo.Text = gvTumblingInspection.SelectedRow.Cells[4].Text;
        txtDateIsnpection.Text = gvTumblingInspection.SelectedRow.Cells[5].Text;
        txtTime.Text = gvTumblingInspection.SelectedRow.Cells[6].Text;
        ddlDay.Text = gvTumblingInspection.SelectedRow.Cells[7].Text;
        txtPower.Text = gvTumblingInspection.SelectedRow.Cells[8].Text;
        txtDuration.Text = gvTumblingInspection.SelectedRow.Cells[9].Text;
        s = gvTumblingInspection.SelectedRow.Cells[10].Text;
        remarks = gvTumblingInspection.SelectedRow.Cells[11].Text;
        txtInspectedBy.Text = gvTumblingInspection.SelectedRow.Cells[12].Text;
        Label id = (Label)gvTumblingInspection.SelectedRow.FindControl("Label1");
        Session["id"] = id.Text;

        if (s == "Accepted")
        {
            chkAccepted.Checked = true;
            chkRejected.Checked = false;
        }
        else
        {
            chkAccepted.Checked = false;
            chkRejected.Checked = true;
        }

        if (remarks == "Continue")
        {
            chkcontinueremarks.Checked = true;
            chkStopRemarks.Checked = false;
        }
        else
        {
            chkcontinueremarks.Checked = false;
            chkStopRemarks.Checked = true;
        }

        btnUpdate.Visible = true;
    }




    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtJarNo.Text == "")
        {
            Messagebox("Please Enter Jar No");
        }
        if (txtDuration.Text == "")
        {
            Messagebox("Please Enter Duration");
        }

        if (txtPower.Text == "")
        {
            Messagebox("Please Enter Power");
        }
        else if (txtInspectedBy.Text == "")
        {
            Messagebox("Please Enter Inspected By");
        }
        else
        {
            string remarks, status;

            if (chkcontinueremarks.Checked == true)
            {
                remarks = "Continue";
            }
            else
            {
                remarks = "Stop";
            }

            if (chkAccepted.Checked == true)
            {
                status = "Accepted";
            }
            else
            {
                status = "Rejected";
            }



            SO_MattTumbling tumblingTable = new SO_MattTumbling()
            {
                TumblingNo = txtTumblingNo.Text,
                ModelNo = txtModelNo.Text,
                JarNo = txtJarNo.Text,
                Duration = txtDuration.Text,
                SampleNo = ddlSampleNo.Text,
                Date = Convert.ToDateTime(txtDateIsnpection.Text, provider),
                Time = txtTime.Text,
                Day = ddlDay.Text,
                Power = Convert.ToDecimal(txtPower.Text),
                Status = status,
                Remarks = remarks,
                InspectedBy = txtInspectedBy.Text
            };
            db.SO_MattTumblings.InsertOnSubmit(tumblingTable);
            db.SubmitChanges();
            Clear();
            gvTumblingInspectionBind();
            txtTumblingNo.Text = "";
            Messagebox("Records Saved");
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        string remarks, status;

        if (chkcontinueremarks.Checked == true)
        {
            remarks = "Continue";
        }
        else
        {
            remarks = "Stop";
        }

        if (chkAccepted.Checked == true)
        {
            status = "Accepted";
        }
        else
        {
            status = "Rejected";
        }

        var obj = db.SO_MattTumblings.Single(r => r.TumblingNo == txtTumblingNo.Text && r.Id == Convert.ToInt32(Session["id"].ToString()));

        obj.Power = Convert.ToDecimal(txtPower.Text);
        obj.InspectedBy = txtInspectedBy.Text;
        obj.Date = Convert.ToDateTime(txtDateIsnpection.Text, provider);
        obj.Time = txtTime.Text;
        obj.Day = ddlDay.Text;
        obj.Remarks = remarks;
        obj.Status = status;

        db.SubmitChanges();
        Clear();
        gvTumblingInspectionBind();

        txtTumblingNo.Text = "";
        Messagebox("Records Updated");

        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {

        Clear();
        txtTumblingNo.Text = "";
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
                Messagebox("Please Enter With INITIAL ex: M.BALAJI");
                txtInspectedBy.Text = "";
                txtInspectedBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtInspectedBy.Text = "";
            txtInspectedBy.Focus();
        }
    }
    protected void txtPower_TextChanged(object sender, EventArgs e)
    {
        var query = from row in db.SO_MattTumblings where row.TumblingNo == txtTumblingNo.Text && row.Power == Convert.ToDecimal(txtPower.Text) select row;
        //if (query.)
        //{
        //    Messagebox("Please verify the Power");
        //}
        //else
        //{
        int ct = query.Count();
        ddlSampleNo.SelectedIndex = ct;
        chkAccepted.Focus();
        //}
    }
    protected void txtTime_TextChanged(object sender, EventArgs e)
    {
        string val = txtTime.Text;
        string[] val1 = val.Split(':');
        int hr = Convert.ToInt32(val1[0]);
        int min = Convert.ToInt32(val1[1]);
        if (hr > 12)
        {
            Messagebox("Enter a valid Time");
            txtTime.Text = "";
        }

        if (min > 59)
        {
            Messagebox("Enter a valid Time");
            txtTime.Text = "";
        }

        string tim = DateTime.Now.ToString();
        string[] day = tim.Split(' ');
        ddlDay.Text = day[1];
        txtPower.Focus();
    }
    protected void ddlSampleNo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Matt")
        {
            Label2.Text = "TumblingNo";
        }
        else
        {
            Label2.Text = "RetumblingNo";
        }
    }
}