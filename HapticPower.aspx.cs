using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HapticPower : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        txtdate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
        txtBlockingType.Text = "IInd Cut";

        if (!IsPostBack)
        {
            Shift();
        }
        if (Session["Location"].ToString() == "Chennai")
        {
             txtlotno.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtlotno.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
        }
    }
    protected void txtlotno_TextChanged(object sender, EventArgs e)
    {
        Clear();
        btnClear.Visible = true;
        btnSave.Visible = true;
        btnUpdate.Visible = true;
        Shift();
        SoftLensDataContext SL = new SoftLensDataContext();
        var q = from x in SL.HapticPowerTables where x.LotNo == txtlotno.Text select x;
        grdview.DataSource = q;
        grdview.DataBind();
        if (txtlotno.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            MessageBox("Enter" + Session["LotNoMaxLength"] + "digit No In Correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtlotno.Text = "";
            txtlotno.Focus();
        }
        else
        {
            var q1 = from row in SL.DeBlockings where row.LotNo == txtlotno.Text && row.BlockingType == txtBlockingType.Text select row;
            if (q1.Count() == 0)
            {
                MessageBox("Enter Correct LotNo (or) Check Prev Process");
                txtlotno.Text = "";
                txtlotno.Focus();
            }
            var s = from row in SL.HapticPowerTables where row.LotNo == txtlotno.Text select row;
            if (s.Count() > 0)
            {
                btnClear.Visible = true;
                btnSave.Visible = false;
            }
        }
    }
    private void Shift()
    {
        String time = DateTime.Now.Hour.ToString();
        if (Convert.ToInt32(time) >= 6 && Convert.ToInt32(time) <= 13)
        {
            ddlSample1Shif.SelectedIndex = 1;
        }
        if (Convert.ToInt32(time) >= 14 && Convert.ToInt32(time) <= 22)
        {
            ddlSample1Shif.SelectedIndex = 2;
        }
        if (Convert.ToInt32(time) >= 23 && Convert.ToInt32(time) <= 5)
        {
            ddlSample1Shif.SelectedIndex = 3;
        }
    }
    private void MessageBox(string m)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "window", "alert('" + m + "');", true);
    }
    private void Clear()
    {
        txtlotno.Enabled = true;
        chkpoweracc1.Checked = true;
        chkpoweracc2.Checked = true;
        chkpoweracc3.Checked = true;
        ddlSample1Shif.SelectedValue = "Select";
        txtremark.Text = "";
        txtinsp.Text = "";
        txtpowervalue1.Text = "";
        txtpowervalue2.Text = "";
        txtpowervalue3.Text = "";
        txthaptic1.Text = "";
        txthaptic2.Text = "";
        txthaptic3.Text = "";
        grdview.DataSource = null;
        grdview.DataBind();
    }
    private bool Validation()
    {
        bool _isvalid = true;
        if (txtlotno.Text == "")
        {
            MessageBox("Enter LotNo!!!");
            txtlotno.Focus();
            _isvalid = false;
        }
        else if (txtpowervalue1.Text == "")
        {
            MessageBox("Enter PowerValue For Sample1");
            txtpowervalue1.Focus();
            _isvalid = false;
        }
        else if (txtpowervalue2.Text == "")
        {
            MessageBox("Enter PowerValue For Sample2");
            txtpowervalue2.Focus();
            _isvalid = false;
        }
        else if (txtpowervalue3.Text == "")
        {
            MessageBox("Enter PowerValue For Sample3");
            txtpowervalue3.Focus();
            _isvalid = false;
        }
        else if (txthaptic1.Text == "")
        {
            MessageBox("Enter Haptic For Sample1");
            txthaptic1.Focus();
            _isvalid = false;
        }
        else if (txthaptic2.Text == "")
        {
            MessageBox("Enter Haptic For Sample2");
            txthaptic2.Focus();
            _isvalid = false;
        }
        else if (txthaptic3.Text == "")
        {
            MessageBox("Enter Haptic For Sample3");
            txthaptic3.Focus();
            _isvalid = false;
        }
        else if (txtinsp.Text == "")
        {
            MessageBox("Enter Inspected By Field");
            txtinsp.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }
    private void Save()
    {
        SoftLensDataContext SL = new SoftLensDataContext();
        HapticPowerTable hp = new HapticPowerTable();
        hp.LotNo = txtlotno.Text;
        hp.BlockingType = txtBlockingType.Text;
        hp.PowerValue1 = Convert.ToDecimal(txtpowervalue1.Text);
        hp.PowerValue2 = Convert.ToDecimal(txtpowervalue2.Text);
        hp.PowerValue3 = Convert.ToDecimal(txtpowervalue3.Text);
        hp.Haptic1 = Convert.ToDecimal(txthaptic1.Text);
        hp.Haptic2 = Convert.ToDecimal(txthaptic2.Text);
        hp.Haptic3 = Convert.ToDecimal(txthaptic3.Text);
        hp.SampleNo1 = "SampleNo1";
        hp.SampleNo2 = "SampleNo2";
        hp.SampleNo3 = "SampleNo3";
        hp.Remarks = txtremark.Text;
        hp.InspectedBy = txtinsp.Text;
        hp.Shift = ddlSample1Shif.Text;
        hp.Date = Convert.ToDateTime(txtdate.Text);
        if (chkpoweracc1.Checked == true)
        {
            hp.PowerSample1 = "Accepted";
        }
        else
        {
            hp.PowerSample1 = "Rejected";
        }
        if (chkpoweracc2.Checked == true)
        {
            hp.PowerSample2 = "Accepted";
        }
        else
        {
            hp.PowerSample2 = "Rejected";
        }
        if (chkpoweracc3.Checked == true)
        {
            hp.PowerSample3 = "Accepted";
        }
        else
        {
            hp.PowerSample3 = "Rejected";
        }
        SL.HapticPowerTables.InsertOnSubmit(hp);
        SL.SubmitChanges();
        MessageBox("Saved Successfully");
    }
    private void GridBind()
    {
        SoftLensDataContext SL = new SoftLensDataContext();
        var query = from x in SL.HapticPowerTables where x.LotNo == txtlotno.Text select x;
        grdview.DataSource = query;
        grdview.DataBind();
    }
    private void Update()
    {
        SoftLensDataContext SL = new SoftLensDataContext();
        var q1 = from row in SL.HapticPowerTables where row.LotNo == txtlotno.Text select row;
        if (q1.Count() > 0)
        {
            q1.Single().PowerValue1 = Convert.ToDecimal(txtpowervalue1.Text);
            q1.Single().PowerValue2 = Convert.ToDecimal(txtpowervalue2.Text);
            q1.Single().PowerValue3 = Convert.ToDecimal(txtpowervalue3.Text);
            q1.Single().Haptic1 = Convert.ToDecimal(txthaptic1.Text);
            q1.Single().Haptic2 = Convert.ToDecimal(txthaptic2.Text);
            q1.Single().Haptic3 = Convert.ToDecimal(txthaptic3.Text);
            q1.Single().SampleNo1 = "SampleNo1";
            q1.Single().SampleNo1 = "SampleNo2";
            q1.Single().SampleNo1 = "SampleNo3";
            q1.Single().Remarks = txtremark.Text;
            q1.Single().InspectedBy = txtinsp.Text;
            q1.Single().Shift = ddlSample1Shif.Text;
            q1.Single().Date = Convert.ToDateTime(txtdate.Text);
            if (chkpoweracc1.Checked == true)
            {
                q1.Single().PowerSample1 = "Accepted";
            }
            else
            {
                q1.Single().PowerSample1 = "Rejected";
            }
            if (chkpoweracc2.Checked == true)
            {
                q1.Single().PowerSample2 = "Accepted";
            }
            else
            {
                q1.Single().PowerSample2 = "Rejected";
            }
            if (chkpoweracc3.Checked == true)
            {
                q1.Single().PowerSample3 = "Accepted";
            }
            else
            {
                q1.Single().PowerSample3 = "Rejected";
            }
            SL.SubmitChanges();
            MessageBox("Updated Successfully");
        }
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
            if (text.EndsWith("."))
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
                if (text.StartsWith("-"))
                {                    
                    if (val.Length >= 3)
                    {
                        f = 1;
                    }
                    f = 0;
                }
                else if (val.Length >= 3)
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
    private int HapticValidation(string text)
    {
        int f = 0;
        try
        {

            string val = text;

            if (text.StartsWith("."))
            {
                f = 1;
            }
            if (text.EndsWith("."))
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

    protected void chkpoweracc1_CheckedChanged(object sender, EventArgs e)
    {
        chkpoweracc1.Checked = true;
        chkpowerrej1.Checked = false;
    }
    protected void chkpoweracc2_CheckedChanged(object sender, EventArgs e)
    {
        chkpoweracc2.Checked = true;
        chkpowerrej2.Checked = false;
    }

    protected void chkpoweracc3_CheckedChanged(object sender, EventArgs e)
    {
        chkpoweracc3.Checked = true;
        chkpowerrej3.Checked = false;
    }

    protected void chkpowerrej1_CheckedChanged(object sender, EventArgs e)
    {
        chkpoweracc1.Checked = false;
        chkpowerrej1.Checked = true;
    }
    protected void Chkpowerrej2_CheckedChanged(object sender, EventArgs e)
    {
        chkpoweracc2.Checked = false;
        chkpowerrej2.Checked = true;
    }
    protected void chkpowerrej3_CheckedChanged(object sender, EventArgs e)
    {
        chkpoweracc3.Checked = false;
        chkpowerrej3.Checked = true;
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            try
            {
                Save();
                GridBind();
                Clear();
                txtlotno.Text = "";
                btnClear.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox("Check the Given Input");
            }
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            try
            {
                Update();
                GridBind();
                Clear();
                txtlotno.Text = "";
                btnUpdate.Visible = false;
                btnClear.Visible = false;
                btnSave.Visible = false;
            }
            catch (Exception ex)
            {
               
            }
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        btnSave.Visible = false;
        btnClear.Visible = false;
        btnUpdate.Visible = false;
        txtlotno.Text = "";
    }
    protected void txtremark_TextChanged(object sender, EventArgs e)
    {
        string re = txtremark.Text;
        txtremark.Text= re.ToUpper();
        txtinsp.Focus();
    }
    protected void txtinsp_TextChanged(object sender, EventArgs e)
    {
        string isp = txtinsp.Text;
        try
        {
            if (isp[1] == '.' && isp[2] != '.' && (isp[2] >= 65 && isp[2] <= 122))
            {
                txtinsp.Text = isp.ToUpper();
            }
            else
            {
                MessageBox("Please Enter With INITIAL ex: M.BALAJI");
                txtinsp.Text = "";
                txtinsp.Focus();
            }
        }
        catch (Exception ex)
        {
            MessageBox("Please Enter With INITIAL ex: M.BALAJI");
            txtinsp.Text = "";
            txtinsp.Focus();
        }
    }
    protected void grdview_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["up"].Equals(1))
        {
            btnSave.Visible = false;
            btnClear.Visible = true;
            SoftLensDataContext SL = new SoftLensDataContext();
            txtlotno.Text = grdview.SelectedRow.Cells[1].Text;
            txtBlockingType.Text = grdview.SelectedRow.Cells[2].Text;
            if (grdview.SelectedRow.Cells[3].Text == "Accepted")
            {
                chkpoweracc1.Checked = true;
            }
            else
            {
                chkpowerrej1.Checked = true;
                chkpoweracc1.Checked = false;
            }
            if (grdview.SelectedRow.Cells[4].Text == "Accepted")
            {
                chkpoweracc2.Checked = true;
            }
            else
            {
                chkpowerrej2.Checked = true;
                chkpoweracc2.Checked = false;
            }
            if (grdview.SelectedRow.Cells[5].Text == "Accepted")
            {
                chkpoweracc2.Checked = true;
            }
            else
            {
                chkpowerrej2.Checked = true;
                chkpoweracc2.Checked = false;
            }
            txtpowervalue1.Text = grdview.SelectedRow.Cells[6].Text;
            txtpowervalue2.Text = grdview.SelectedRow.Cells[7].Text;
            txtpowervalue3.Text = grdview.SelectedRow.Cells[8].Text;
            txthaptic1.Text = grdview.SelectedRow.Cells[9].Text;
            txthaptic1.Text = grdview.SelectedRow.Cells[10].Text;
            txthaptic1.Text = grdview.SelectedRow.Cells[11].Text;
            txtinsp.Text = grdview.SelectedRow.Cells[12].Text;
            ddlSample1Shif.Text = grdview.SelectedRow.Cells[13].Text;
            txtdate.Text = grdview.SelectedRow.Cells[14].Text;
            txtlotno.Enabled = false;
            btnClear.Visible = true;
            btnUpdate.Visible = true;
        }
        else
        {
            MessageBox("Permission is denied");
        }
    }
    protected void txtpowervalue2_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtpowervalue2.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txtpowervalue2.Text = "";
            txtpowervalue2.Focus();
        }
        else
        {
            txthaptic2.Focus();
        }
    }
    protected void txtpowervalue3_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtpowervalue3.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txtpowervalue3.Text = "";
            txtpowervalue3.Focus();
        }
        else
        {
            txthaptic3.Focus();
        }
    }
    protected void txtpowervalue1_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtpowervalue1.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txtpowervalue1.Text = "";
            txtpowervalue1.Focus();
        }
        else
        {
            txthaptic1.Focus();
        }
    }
    protected void txthaptic1_TextChanged(object sender, EventArgs e)
    {
        int val = HapticValidation(txthaptic1.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txthaptic1.Text = "";
            txthaptic1.Focus();
        }
        else
        {
            chkpoweracc2.Focus();
        }
    }
    protected void txthaptic2_TextChanged(object sender, EventArgs e)
    {
        int val = HapticValidation(txthaptic2.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txthaptic2.Text = "";
            txthaptic2.Focus();
        }
        else
        {
            chkpoweracc3.Focus();
        }
    }
    protected void txthaptic3_TextChanged(object sender, EventArgs e)
    {
        int val = HapticValidation(txthaptic3.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txthaptic3.Text = "";
            txthaptic3.Focus();
        }
        else
        {
            txtremark.Focus();
        }
    }
   
}
