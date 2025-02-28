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

public partial class PoweInspection_Bef_And_Aft__Hydration : System.Web.UI.Page
{

    #region Declarations
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext SL = new SoftLensDataContext();
    #endregion Declarations

    #region Methods
    private void Shift1()
    {
        String time = DateTime.Now.Hour.ToString();

        if (Convert.ToInt32(time) >= 6 && Convert.ToInt32(time) <= 13)
        {
            ddlSampleNo1Shift1.SelectedIndex = 1;

        }
        if (Convert.ToInt32(time) >= 14 && Convert.ToInt32(time) <= 22)
        {
            ddlSampleNo1Shift1.SelectedIndex = 2;

        }
        if (Convert.ToInt32(time) >= 22 && Convert.ToInt32(time) <= 5)
        {
            ddlSampleNo1Shift1.SelectedIndex = 3;

        }
    }

    private void clear()
    {

        txtSmpNo1BfHyd.Text = "";
        txtSmpNo2BfHyd.Text = "";
        txtSmpNo3BfHyd.Text = "";
        txtSmpNo1AftHyd.Text = "";
        txtSmpNo2AftHyd.Text = "";
        txtSmpNo3AftHyd.Text = "";
        txtSampleNo1Rmks.Text = "";

        txtSampleNo1InspBy.Text = "";

        ddlSampleNo1Shift1.SelectedIndex = 0;

        txtSampleNo1Date.Text = "";

        txtLotNo.Text = "";

        ckb1SampleNo1PwrSts1Gd1.Checked = true;
        chkb3SampleNo2PwrSts2Gd2.Checked = true;
        chkb5SampleNo3PwrSts3Gd3.Checked = true;
        chkb2SampleNo1PwrSts1Bad1.Checked = false;
        chkb4SampleNo2PwrSts2Bad2.Checked = false;
        chkb6SampleNo3PwrSts3Bad3.Checked = false;
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }


    private int PowerValidation(string text)
    {
        int f = 0;
        try
        {

            string val = text;

            if (text.StartsWith("."))
            {
                f = 1;
            }
            if (val[1] == '.')
            {
                if (val.Length == 2 || val.Length == 3 || val.Length == 4)
                {
                    for (int i = 2; i < 4; i++)
                    {
                        if (val[i] == '.')
                        {
                            f = 1;
                        }
                    }

                }
                else
                {
                    f = 1;
                }
            }
            else if (val[2] == '.')
            {
                if (val.Length == 3 || val.Length == 4 || val.Length == 5)
                {
                    for (int i = 3; i < 5; i++)
                    {
                        if (val[i] == '.')
                        {
                            f = 1;
                        }
                    }
                }
                else
                {
                    f = 1;
                }
            }
            else
            {
                if (val.Length >= 3)
                {
                    f = 1;
                }
            }

        }
        catch
        {
        }

        return f;


    }

    #endregion Methods

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Location"].ToString() == "Chennai")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
            txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
        }

    }

    protected void ckb1SampleNo1PwrSts1Gd1_CheckedChanged(object sender, EventArgs e)
    {
        ckb1SampleNo1PwrSts1Gd1.Checked = true;
        chkb2SampleNo1PwrSts1Bad1.Checked = false;
    }

    protected void chkb2SampleNo1PwrSts1Bad1_CheckedChanged(object sender, EventArgs e)
    {
        ckb1SampleNo1PwrSts1Gd1.Checked = false;
        chkb2SampleNo1PwrSts1Bad1.Checked = true;

    }

    protected void chkb3SampleNo2PwrSts2Gd2_CheckedChanged(object sender, EventArgs e)
    {
        chkb3SampleNo2PwrSts2Gd2.Checked = true;
        chkb4SampleNo2PwrSts2Bad2.Checked = false;
    }

    protected void chkb4SampleNo2PwrSts2Bad2_CheckedChanged(object sender, EventArgs e)
    {
        chkb3SampleNo2PwrSts2Gd2.Checked = false;
        chkb4SampleNo2PwrSts2Bad2.Checked = true;
    }

    protected void chkb5SampleNo3PwrSts3Gd3_CheckedChanged(object sender, EventArgs e)
    {
        chkb5SampleNo3PwrSts3Gd3.Checked = true;
        chkb6SampleNo3PwrSts3Bad3.Checked = false;
    }

    protected void chkb6SampleNo3PwrSts3Bad3_CheckedChanged(object sender, EventArgs e)
    {
        chkb5SampleNo3PwrSts3Gd3.Checked = false;
        chkb6SampleNo3PwrSts3Bad3.Checked = true;
    }

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        if (txtLotNo.Text.Length < Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }
        else
        {
            var valid = from a in SL.HapticSamples where a.LotNo == txtLotNo.Text select a;
            if (valid.Count() != 0)
            {
                // clear();
                Shift1();
                btnClear.Visible = true;
                btnSave.Visible = true;
                txtSmpNo1BfHyd.Focus();
                txtSampleNo1Date.Text = System.DateTime.Now.ToString("dd/MM/yyyy");


                var q1 = from f in SL.Powerinspections where f.LotNo == txtLotNo.Text select f;
                gvPowerInspec.DataSource = q1;
                gvPowerInspec.DataBind();
                try
                {

                    var q = from f in SL.Powerinspections where f.LotNo == txtLotNo.Text select f;
                    if (q.Count() > 0)
                    {
                        btnSave.Visible = false;

                    }
                }

                catch (Exception ex)
                {

                }

            }
            else
            {
                Messagebox("Please Enter a valid Lot No/ Check previous process");
                txtLotNo.Text = "";
                txtLotNo.Focus();
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
        else if (txtSmpNo1BfHyd.Text == "")
        {
            Messagebox("Please Enter the BeforeHyd Value in Sample1");
            txtSmpNo1BfHyd.Focus();
        }
        else if (txtSmpNo1AftHyd.Text == "")
        {
            Messagebox("Please Enter the AftHyd Value in Sample1");
            txtSmpNo1AftHyd.Focus();
        }
        else if (txtSmpNo2BfHyd.Text == "")
        {
            Messagebox("Please Enter the BeforeHyd Value in Sample2");
            txtSmpNo2BfHyd.Focus();
        }
        else if (txtSmpNo2AftHyd.Text == "")
        {
            Messagebox("Please Enter the AftHyd Value in Sample2");
            txtSmpNo2AftHyd.Focus();
        }
        else if (txtSmpNo3BfHyd.Text == "")
        {
            Messagebox("Please Enter the BeforeHyd Value in Sample3");
            txtSmpNo3BfHyd.Focus();
        }
        else if (txtSmpNo3AftHyd.Text == "")
        {
            Messagebox("Please Enter the AftHyd Value in Sample2");
            txtSmpNo3AftHyd.Focus();
        }
        else if (txtSampleNo1InspBy.Text == "")
        {
            Messagebox("Please Enter InspectedBy Name");
            txtSampleNo1InspBy.Focus();
        }
        else
        {
            try
            {
                SoftLensDataContext SL = new SoftLensDataContext();
                Powerinspection ps = new Powerinspection();
                ps.LotNo = txtLotNo.Text;
                ps.BlockingType = txtBlockingType.Text;
                ps.SampleNo1 = lblSmpNo1.Text;
                ps.SampleNo2 = lblSmpNo2.Text;
                ps.SampleNo3 = lblSmpNo3.Text;
                ps.BeforeHydSample1 = Convert.ToDecimal(txtSmpNo1BfHyd.Text);
                ps.BeforeHydSample2 = Convert.ToDecimal(txtSmpNo2BfHyd.Text);
                ps.BeforeHydSample3 = Convert.ToDecimal(txtSmpNo3BfHyd.Text);
                ps.AfterHydSample1 = Convert.ToDecimal(txtSmpNo1AftHyd.Text);
                ps.AfterHydSample2 = Convert.ToDecimal(txtSmpNo2AftHyd.Text);
                ps.AfterHydSample3 = Convert.ToDecimal(txtSmpNo3AftHyd.Text);
                ps.Sample1Remarks = txtSampleNo1Rmks.Text;

                ps.Sample1InspectedBy = txtSampleNo1InspBy.Text;

                ps.Sample1Shift = ddlSampleNo1Shift1.Text;

                ps.Sample1Date =  Convert.ToDateTime(txtSampleNo1Date.Text,provider);

                if (ckb1SampleNo1PwrSts1Gd1.Checked == true)
                {
                    ps.PowerStatus1 = "GOOD";
                }
                else
                {
                    ps.PowerStatus1 = "BAD";
                }
                if (chkb3SampleNo2PwrSts2Gd2.Checked == true)
                {
                    ps.PowerStatus2 = "GOOD";
                }
                else
                {
                    ps.PowerStatus2 = "BAD";
                }
                if (chkb5SampleNo3PwrSts3Gd3.Checked == true)
                {
                    ps.PowerStatus3 = "GOOD";
                }
                else
                {
                    ps.PowerStatus3 = "BAD";
                }

                SL.Powerinspections.InsertOnSubmit(ps);
                SL.SubmitChanges();

                Messagebox("Save SuccessFully");
                btnClear.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                
                var q1 = from f in SL.Powerinspections where f.LotNo == txtLotNo.Text select f;
                gvPowerInspec.DataSource = q1;
                gvPowerInspec.DataBind();
                clear();
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {

        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter Lot No ");
            txtLotNo.Focus();
        }
        else if (txtSmpNo1BfHyd.Text == "")
        {
            Messagebox("Please Enter the BeforeHyd Value in Sample1");
            txtSmpNo1BfHyd.Focus();
        }
        else if (txtSmpNo1AftHyd.Text == "")
        {
            Messagebox("Please Enter the AftHyd Value in Sample1");
            txtSmpNo1AftHyd.Focus();
        }
        else if (txtSmpNo2BfHyd.Text == "")
        {
            Messagebox("Please Enter the BeforeHyd Value in Sample2");
            txtSmpNo2BfHyd.Focus();
        }
        else if (txtSmpNo2AftHyd.Text == "")
        {
            Messagebox("Please Enter the AftHyd Value in Sample2");
            txtSmpNo2AftHyd.Focus();
        }
        else if (txtSmpNo3BfHyd.Text == "")
        {
            Messagebox("Please Enter the BeforeHyd Value in Sample3");
            txtSmpNo3BfHyd.Focus();
        }
        else if (txtSmpNo3AftHyd.Text == "")
        {
            Messagebox("Please Enter the AftHyd Value in Sample2");
            txtSmpNo3AftHyd.Focus();
        }
        else if (txtSampleNo1InspBy.Text == "")
        {
            Messagebox("Please Enter InspectedBy Name");
            txtSampleNo1InspBy.Focus();
        }
        else
        {
            try
            {
                SoftLensDataContext SL = new SoftLensDataContext();
                var q = from f in SL.Powerinspections where f.LotNo == txtLotNo.Text select f;
                if (q.Count() > 0)
                {
                    q.Single().BeforeHydSample1 = Convert.ToDecimal(txtSmpNo1BfHyd.Text);
                    q.Single().BeforeHydSample2 = Convert.ToDecimal(txtSmpNo2BfHyd.Text);
                    q.Single().BeforeHydSample3 = Convert.ToDecimal(txtSmpNo3BfHyd.Text);
                    q.Single().AfterHydSample1 = Convert.ToDecimal(txtSmpNo1AftHyd.Text);
                    q.Single().AfterHydSample2 = Convert.ToDecimal(txtSmpNo2AftHyd.Text);
                    q.Single().AfterHydSample3 = Convert.ToDecimal(txtSmpNo3AftHyd.Text);
                    q.Single().Sample1Remarks = txtSampleNo1Rmks.Text;

                    q.Single().Sample1InspectedBy = txtSampleNo1InspBy.Text;

                    q.Single().Sample1Shift = ddlSampleNo1Shift1.Text;

                    q.Single().Sample1Date = Convert.ToDateTime(txtSampleNo1Date.Text, provider);

                    if (ckb1SampleNo1PwrSts1Gd1.Checked == true)
                    {
                        q.Single().PowerStatus1 = "GOOD";
                    }
                    else
                    {
                        q.Single().PowerStatus1 = "BAD";
                    }
                    if (chkb3SampleNo2PwrSts2Gd2.Checked == true)
                    {
                        q.Single().PowerStatus2 = "GOOD";
                    }
                    else
                    {
                        q.Single().PowerStatus2 = "BAD";
                    }
                    if (chkb5SampleNo3PwrSts3Gd3.Checked == true)
                    {
                        q.Single().PowerStatus3 = "GOOD";
                    }
                    else
                    {
                        q.Single().PowerStatus3 = "BAD";
                    }

                    SL.SubmitChanges();

                    Messagebox("Update SuccessFully");
                    btnClear.Visible = false;
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                   
                    var q1 = from f in SL.Powerinspections where f.LotNo == txtLotNo.Text select f;
                    gvPowerInspec.DataSource = q1;
                    gvPowerInspec.DataBind();
                    clear();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    protected void txtSampleNo1Rmks_TextChanged(object sender, EventArgs e)
    {
        string up = txtSampleNo1Rmks.Text;
        txtSampleNo1Rmks.Text = up.ToUpper();
    }

    protected void txtSampleNo1InspBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtSampleNo1InspBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtSampleNo1InspBy.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: M.BALAJI");
                txtSampleNo1InspBy.Text = "";
                txtSampleNo1InspBy.Focus();

            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtSampleNo1InspBy.Text = "";
            txtSampleNo1InspBy.Focus();
        }
    }

    protected void gvPowerInspec_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Visible = false;
        btnClear.Visible = true;
        btnUpdate.Visible = true;
        SoftLensDataContext SL = new SoftLensDataContext();
        Powerinspection ps = new Powerinspection();
        txtLotNo.Text = gvPowerInspec.SelectedRow.Cells[1].Text;
        txtBlockingType.Text = gvPowerInspec.SelectedRow.Cells[2].Text;
        if (gvPowerInspec.SelectedRow.Cells[3].Text == "GOOD")
        {
            ckb1SampleNo1PwrSts1Gd1.Checked = true;
            chkb2SampleNo1PwrSts1Bad1.Checked = false;
        }
        else
        {
            ckb1SampleNo1PwrSts1Gd1.Checked = false;
            chkb2SampleNo1PwrSts1Bad1.Checked = true;
        }

        txtSmpNo1BfHyd.Text = gvPowerInspec.SelectedRow.Cells[4].Text;
        txtSmpNo1AftHyd.Text = gvPowerInspec.SelectedRow.Cells[5].Text;
        if (gvPowerInspec.SelectedRow.Cells[6].Text == "GOOD")
        {
            chkb3SampleNo2PwrSts2Gd2.Checked = true;
            chkb4SampleNo2PwrSts2Bad2.Checked = false;
        }
        else
        {
            chkb3SampleNo2PwrSts2Gd2.Checked = false;
            chkb4SampleNo2PwrSts2Bad2.Checked = true;
        }

        txtSmpNo2BfHyd.Text = gvPowerInspec.SelectedRow.Cells[7].Text;
        txtSmpNo2AftHyd.Text = gvPowerInspec.SelectedRow.Cells[8].Text;
        if (gvPowerInspec.SelectedRow.Cells[9].Text == "GOOD")
        {
            chkb5SampleNo3PwrSts3Gd3.Checked = true;
            chkb6SampleNo3PwrSts3Bad3.Checked = false;
        }
        else
        {
            chkb5SampleNo3PwrSts3Gd3.Checked = false;
            chkb6SampleNo3PwrSts3Bad3.Checked = true;
        }

        txtSmpNo3BfHyd.Text = gvPowerInspec.SelectedRow.Cells[10].Text;
        txtSmpNo3AftHyd.Text = gvPowerInspec.SelectedRow.Cells[11].Text;
        txtSampleNo1Rmks.Text = gvPowerInspec.SelectedRow.Cells[12].Text;
        txtSampleNo1InspBy.Text = gvPowerInspec.SelectedRow.Cells[13].Text;
        ddlSampleNo1Shift1.Text = gvPowerInspec.SelectedRow.Cells[14].Text;
        txtSampleNo1Date.Text = gvPowerInspec.SelectedRow.Cells[15].Text;
    }

    protected void txtSmpNo1BfHyd_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSmpNo1BfHyd.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtSmpNo1BfHyd.Text = "";
            txtSmpNo1BfHyd.Focus();
        }
        else
        {
            txtSmpNo1AftHyd.Focus();
        }
            
    }

    protected void txtSmpNo1AftHyd_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSmpNo1AftHyd.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtSmpNo1AftHyd.Text = "";
            txtSmpNo1AftHyd.Focus();
        }
        else
        {
            chkb3SampleNo2PwrSts2Gd2.Focus();
        }
    }

    protected void txtSmpNo2BfHyd_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSmpNo2BfHyd.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtSmpNo2BfHyd.Text = "";
            txtSmpNo2BfHyd.Focus();
        }
        else
        {
            txtSmpNo2AftHyd.Focus();
        }
    }

    protected void txtSmpNo2AftHyd_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSmpNo2AftHyd.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtSmpNo2AftHyd.Text = "";
            txtSmpNo2AftHyd.Focus();
        }
        else
        {
            chkb5SampleNo3PwrSts3Gd3.Focus();
        }
    }

    protected void txtSmpNo3BfHyd_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSmpNo3BfHyd.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtSmpNo3BfHyd.Text = "";
            txtSmpNo3BfHyd.Focus();
        }
        else
        {
            txtSmpNo3AftHyd.Focus();
        }
    }

    protected void txtSmpNo3AftHyd_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSmpNo3AftHyd.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtSmpNo3AftHyd.Text = "";
            txtSmpNo3AftHyd.Focus();
        }
        else
        {
            txtSampleNo1Rmks.Focus();
        }
    }

    #endregion Events

}
