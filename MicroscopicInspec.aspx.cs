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

public partial class MicroscopicInspec : System.Web.UI.Page
{
    #region Declarations

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext SL = new SoftLensDataContext();

    #endregion Declarations

    #region Methods

    private void clear()
    {
        txtRemarks1.Text = "";
        txtInspectedBy1.Text = "";
        txtRejMtsNo.Text = "";
        ddlShift1.Text = "Select";
        txtDate1.Text = "";
        ChkbAccepted1.Checked = true;
        chkbAccepted2.Checked = true;
        chkbAccepted3.Checked = true;
        chkbRejected1.Checked = false;
        chkbRejected2.Checked = false;
        chkbRejected3.Checked = false;

    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void Shift()
    {
        String time = DateTime.Now.Hour.ToString();

        if (Convert.ToInt32(time) >= 6 && Convert.ToInt32(time) <= 13)
        {
            ddlShift1.SelectedIndex = 1;

        }
        if (Convert.ToInt32(time) >= 14 && Convert.ToInt32(time) <= 22)
        {
            ddlShift1.SelectedIndex = 2;

        }
        if (Convert.ToInt32(time) >= 22 && Convert.ToInt32(time) <= 5)
        {
            ddlShift1.SelectedIndex = 3;

        }
    }


    private void Save()
    {
        SL = new SoftLensDataContext();
        MicroscopicInspection MI = new MicroscopicInspection();

        MI.LotNo = txtLotNo.Text;

        MI.Sample1Remarks = txtRemarks1.Text;
        MI.Sample1InspectedBy = txtInspectedBy1.Text;

        MI.Sample1Shift = ddlShift1.Text;
        MI.Sample1Date = Convert.ToDateTime(txtDate1.Text, provider);
        MI.BlockingType = txtCutType.Text;
        if (Label1.Text == "Sample Inspection For Milling")
        {
            MI.RejMTSNo = txtRejMtsNo.Text;
        }
        else
        {
            MI.RejMTSNo = "0";
        }
        if (ChkbAccepted1.Checked == true)
        {
            MI.Sample1Status = "Accepted";
        }
        else
        {
            MI.Sample1Status = "Rejected";
        }

        if (chkbAccepted2.Checked == true)
        {
            MI.Sample2Status = "Accepted";
        }
        else
        {
            MI.Sample2Status = "Rejected";
        }

        if (chkbAccepted3.Checked == true)
        {
            MI.Sample3Status = "Accepted";
        }
        else
        {
            MI.Sample3Status = "Rejected";
        }


        SL.MicroscopicInspections.InsertOnSubmit(MI);
        SL.SubmitChanges();
        Messagebox("Saved Successfully");
    }

    private void Update()
    {
        SL = new SoftLensDataContext();
        var q = from f in SL.MicroscopicInspections where f.LotNo == txtLotNo.Text && f.BlockingType == txtCutType.Text select f;
        if (q.Count() > 0)
        {
            q.Single().Sample1Remarks = txtRemarks1.Text;
            q.Single().Sample1InspectedBy = txtInspectedBy1.Text;
            q.Single().Sample1Shift = ddlShift1.Text;
            q.Single().Sample1Date = Convert.ToDateTime(txtDate1.Text, provider);
            if (Label1.Text == "Sample Inspection For Milling")
            {
                q.Single().RejMTSNo = txtRejMtsNo.Text;
            }
            if (ChkbAccepted1.Checked == true)
            {
                q.Single().Sample1Status = "Accepted";
            }
            else
            {
                q.Single().Sample1Status = "Rejected";
            }

            if (chkbAccepted2.Checked == true)
            {
                q.Single().Sample2Status = "Accepted";
            }
            else
            {
                q.Single().Sample2Status = "Rejected";
            }

            if (chkbAccepted3.Checked == true)
            {
                q.Single().Sample3Status = "Accepted";
            }
            else
            {
                q.Single().Sample3Status = "Rejected";
            }



            SL.SubmitChanges();
            Messagebox("Updated Successfully");
        }
    }

    private void GridBind()
    {
        SL = new SoftLensDataContext();
        var q = from f in SL.MicroscopicInspections where f.LotNo == txtLotNo.Text && f.BlockingType == txtCutType.Text select f;
        GridView1.DataSource = q;
        GridView1.DataBind();
    }

    #endregion Methods

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Shift();
            string type = Session["Cut Type"].ToString();
            txtCutType.Text = Session["Cut Type"].ToString();
            if (type == "Milling")
            {
                Label1.Text = "Sample Inspection For Milling";
                Label3.Visible = true;
                txtRejMtsNo.Visible = true;
                GridView1.Columns[9].Visible = true;
            }
            else
            {
                Label1.Text = " MicroScopic Inspection With Collect";
                Label3.Visible = false;
                txtRejMtsNo.Visible = false;
            }
        }
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

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        if (txtLotNo.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }

        try
        {
            clear();
            Shift();
            txtDate1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            SoftLensDataContext SL = new SoftLensDataContext();
            txtRemarks1.Focus();


            if (Label1.Text == " MicroScopic Inspection With Collect")
            {
                var val = from f in SL.Lathecuts where f.LotNo == txtLotNo.Text && f.LatheType == txtCutType.Text select f;
                if (val.Count() == 0)
                {
                    Messagebox("Please Enter the Correct Lot No ");
                    txtLotNo.Focus();
                    txtLotNo.Text = "";
                }
                else
                {
                    btnSave.Visible = true;
                    btnClear.Visible = true;
                }


            }
            if (Label1.Text == "Sample Inspection For Milling")
            {
                var val = from f in SL.Millings where f.LotNo == txtLotNo.Text select f;
                if (val.Count() == 0)
                {
                    Messagebox("Please Enter the Correct Lot No ");
                    txtLotNo.Focus();
                    txtLotNo.Text = "";
                }
                else
                {
                    btnSave.Visible = true;
                    btnClear.Visible = true;
                }

            }

            var q = from f in SL.MicroscopicInspections where f.LotNo == txtLotNo.Text && f.BlockingType == txtCutType.Text select f;
            if (q.Count() == 0)
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnClear.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnClear.Visible = true;
            }
            GridView1.DataSource = q;
            GridView1.DataBind();
        }
        catch (Exception)
        {

        }


    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter Lot No ");
            txtLotNo.Focus();
        }
        else if (txtInspectedBy1.Text == "")
        {
            Messagebox("Please Enter InspectedBy");
            txtInspectedBy1.Focus();
        }
        else
        {
            try
            {
                Save();
                GridBind();
                txtLotNo.Text = "";
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnClear.Visible = false;
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
        else if (txtInspectedBy1.Text == "")
        {
            Messagebox("Please Enter InspectedBy");
            txtInspectedBy1.Focus();
        }
        else
        {
            try
            {
                Update();
                GridBind();

                txtLotNo.Text = "";
                clear();
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnClear.Visible = false;
                txtLotNo.Enabled = true;
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false; ;
        btnSave.Visible = false;
        btnClear.Visible = false;
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["up"].Equals(1))
        {
            btnSave.Visible = false;
            btnClear.Visible = true;
            btnUpdate.Visible = true;
            SoftLensDataContext db = new SoftLensDataContext();

            txtLotNo.Text = GridView1.SelectedRow.Cells[1].Text;
            txtCutType.Text = GridView1.SelectedRow.Cells[2].Text;
            ddlShift1.Text = GridView1.SelectedRow.Cells[3].Text;
            if (GridView1.SelectedRow.Cells[4].Text == "Accepted")
            {
                ChkbAccepted1.Checked = true;

            }
            else
            {
                ChkbAccepted1.Checked = false;
                chkbRejected1.Checked = true;
            }



            if (GridView1.SelectedRow.Cells[5].Text == "Accepted")
            {
                chkbAccepted2.Checked = true;
            }
            else
            {
                chkbAccepted2.Checked = false;
                chkbRejected2.Checked = true;
            }

            if (GridView1.SelectedRow.Cells[6].Text == "Accepted")
            {
                chkbAccepted3.Checked = true;
            }
            else
            {
                chkbAccepted3.Checked = false;
                chkbRejected3.Checked = true;
            }
            txtRemarks1.Text = GridView1.SelectedRow.Cells[7].Text;
            if (txtRemarks1.Text == "&nbsp;")
            {
                txtRemarks1.Text = "";
            }
            txtInspectedBy1.Text = GridView1.SelectedRow.Cells[8].Text;
            if (Label1.Text == "Sample Inspection For Milling")
            {
                txtRejMtsNo.Text = GridView1.SelectedRow.Cells[9].Text;
                if (txtRejMtsNo.Text == "&nbsp;")
                {
                    txtRejMtsNo.Text = "";
                }
            }
            txtDate1.Text = GridView1.SelectedRow.Cells[10].Text;
        }
        else
        {
            Messagebox("Permission is denied");
        }
    }

    #endregion Events

    protected void ddlShift1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void txtCutType_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtDate1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtRejMtsNo_TextChanged(object sender, EventArgs e)
    {

    }

}