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

public partial class MicroscopeHapticThick : System.Web.UI.Page
{

    #region Declarations
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    #endregion Declarations


    #region Methods
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
        if (Convert.ToInt32(time) >= 22 && Convert.ToInt32(time) <= 5)
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
        txtLotNo.Enabled = true;
        txtSample1HaptiThick1.Text = "";
        txtSample2HaptiThick2.Text = "";
        txtSample3HaptiThick3.Text = "";
        txtSample1Remarks.Text = "";

        txtSample1InspBy.Text = "";

        ddlSample1Shif.SelectedValue = "Select";

        //txtDate.Text = "";


        chkb1SampleNo1MiStatusAccp1.Checked = true;
        chkb3SampleNo2MiStatusAccp2.Checked = true;
        chkb5SampleNo3MiStatusAccp3.Checked = true;
        chkb2SampleNo1MiStatusRej1.Checked = false;
        chkb4SampleNo2MiStatusRej2.Checked = false;
        chkb6SampleNo3MiStatusRej3.Checked = false;
        chkb7SampleNo1PfStsAccp1.Checked = true;
        chkb9SampleNo2PfStsAccp2.Checked = true;
        chkb11SampleNo3PfStsAccp3.Checked = true;
        chkb8SampleNo1PfStsRej1.Checked = false;
        chkb10SampleNo2PfStsRej2.Checked = false;
        chkb12SampleNo3PfStsRej3.Checked = false;

        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    private bool Validation()
    {
        bool _isvalid = true;
        if (txtLotNo.Text == "")
        {
            MessageBox("Please Enter Lot No ");
            txtLotNo.Focus();
            _isvalid = false;
        }
        else if (txtSample1HaptiThick1.Text == "")
        {
            MessageBox("Please Enter HapticThickness1 Value ");
            txtSample1HaptiThick1.Focus();
            _isvalid = false;
        }
        else if (txtSample2HaptiThick2.Text == "")
        {
            MessageBox("Please Enter HapticThickness2 Value ");
            txtSample2HaptiThick2.Focus();
            _isvalid = false;
        }
        else if (txtSample3HaptiThick3.Text == "")
        {
            MessageBox("Please Enter HapticThickness3 Value ");
            txtSample3HaptiThick3.Focus();
            _isvalid = false;
        }
        else if (txtSample1InspBy.Text == "")
        {
            MessageBox("Please Enter Inspectedby Name ");
            txtSample1InspBy.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }

    private void Save()
    {
        SoftLensDataContext SL = new SoftLensDataContext();
        HapticSample HS = new HapticSample();
        HS.LotNo = txtLotNo.Text;
        HS.SampleNo1 = lblSampleNo1.Text;
        HS.SampleNo2 = lblSampleNo2.Text;
        HS.SampleNo3 = lblSampleNo3.Text;
        HS.BlockingType = "IInd Cut";
        HS.Sample1Haptic = Convert.ToDecimal(txtSample1HaptiThick1.Text);
        HS.Sample2Haptic = Convert.ToDecimal(txtSample2HaptiThick2.Text);
        HS.Sample3Haptic = Convert.ToDecimal(txtSample3HaptiThick3.Text);

        HS.Sample1Remarks = txtSample1Remarks.Text;

        HS.Sample1InspectedBy = txtSample1InspBy.Text;

        HS.Sample1Shift = ddlSample1Shif.Text;

        HS.Sample1Date = Convert.ToDateTime(txtDate.Text, provider);

        if (chkb1SampleNo1MiStatusAccp1.Checked == true)
        {
            HS.Sample1MiStatus = "accepted";

        }
        else
        {
            HS.Sample1MiStatus = "rejected";

        }
        if (chkb3SampleNo2MiStatusAccp2.Checked == true)
        {
            HS.Sample2MiStatus = "accepted";
        }
        else
        {
            HS.Sample2MiStatus = "rejected";
        }

        if (chkb5SampleNo3MiStatusAccp3.Checked == true)
        {
            HS.Sample3MiStatus = "accepted";
        }
        else
        {
            HS.Sample3MiStatus = "rejected";
        }
        if (chkb7SampleNo1PfStsAccp1.Checked == true)
        {
            HS.Sample1ProfileStatus = "accepted";

        }
        else
        {
            HS.Sample1ProfileStatus = "rejected";

        }

        if (chkb9SampleNo2PfStsAccp2.Checked == true)
        {
            HS.Sample2ProfileStatus = "accepted";
        }
        else
        {
            HS.Sample2ProfileStatus = "rejected";
        }

        if (chkb11SampleNo3PfStsAccp3.Checked == true)
        {
            HS.Sample3ProfileStatus = "accepted";
        }
        else
        {
            HS.Sample3ProfileStatus = "rejected";
        }

        SL.HapticSamples.InsertOnSubmit(HS);
        SL.SubmitChanges();

        MessageBox("Saved Successfully");
    }


    private void GridBind()
    {
        SoftLensDataContext SL = new SoftLensDataContext();
        var q = from f in SL.HapticSamples where f.LotNo == txtLotNo.Text select f;
        GridView1.DataSource = q;
        GridView1.DataBind();
    }

    private void Update()
    {
        SoftLensDataContext SL = new SoftLensDataContext();
        var q = from f in SL.HapticSamples where f.LotNo == txtLotNo.Text select f;
        if (q.Count() > 0)
        {
            q.Single().Sample1Haptic = Convert.ToDecimal(txtSample1HaptiThick1.Text);
            q.Single().Sample2Haptic = Convert.ToDecimal(txtSample2HaptiThick2.Text);
            q.Single().Sample3Haptic = Convert.ToDecimal(txtSample3HaptiThick3.Text);

            q.Single().Sample1Remarks = txtSample1Remarks.Text;

            q.Single().Sample1InspectedBy = txtSample1InspBy.Text;

            q.Single().Sample1Shift = ddlSample1Shif.Text;

            q.Single().Sample1Date = Convert.ToDateTime(txtDate.Text, provider);
            if (chkb1SampleNo1MiStatusAccp1.Checked == true)
            {
                q.Single().Sample1MiStatus = "accepted";

            }
            else
            {
                q.Single().Sample1MiStatus = "rejected";

            }
            if (chkb3SampleNo2MiStatusAccp2.Checked == true)
            {
                q.Single().Sample2MiStatus = "accepted";
            }
            else
            {
                q.Single().Sample2MiStatus = "rejected";
            }

            if (chkb5SampleNo3MiStatusAccp3.Checked == true)
            {
                q.Single().Sample3MiStatus = "accepted";
            }
            else
            {
                q.Single().Sample3MiStatus = "rejected";
            }
            if (chkb7SampleNo1PfStsAccp1.Checked == true)
            {
                q.Single().Sample1ProfileStatus = "accepted";

            }
            else
            {
                q.Single().Sample1ProfileStatus = "rejected";

            }

            if (chkb9SampleNo2PfStsAccp2.Checked == true)
            {
                q.Single().Sample2ProfileStatus = "accepted";
            }
            else
            {
                q.Single().Sample2ProfileStatus = "rejected";
            }

            if (chkb11SampleNo3PfStsAccp3.Checked == true)
            {
                q.Single().Sample3ProfileStatus = "accepted";
            }
            else
            {
                q.Single().Sample3ProfileStatus = "rejected";
            }

            SL.SubmitChanges();

            MessageBox("Update Successfully");
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
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtCutType.Text = "IInd Cut";
        
        if (!IsPostBack)
        {
            //txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            Shift();
            
        }

        if (Session["Location"].ToString() == "Chennai")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);

            //txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
            //txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        }
        else if (Session["Location"].ToString() == "Pondicherry")
        {
            txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
        }


    }

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        Clear();
        //txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        btnClear.Visible = true;
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        Shift();
        SoftLensDataContext SL = new SoftLensDataContext();
        var g = from f in SL.HapticSamples where f.LotNo == txtLotNo.Text select f;
        GridView1.DataSource = g;
        GridView1.DataBind();
        if (txtLotNo.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            MessageBox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }
        else
        {

            var q1 = from f in SL.DeBlockings  where f.LotNo == txtLotNo.Text && f.BlockingType == txtCutType.Text select f;
            if (q1.Count() == 0)
            {
                MessageBox("PlZ Enter the Correct LotNo (or) Check Prev Process");
                txtLotNo.Text = "";
                txtLotNo.Focus();
            }
            var q = from f in SL.HapticSamples where f.LotNo == txtLotNo.Text select f;
            if (q.Count() > 0)
            {
                btnClear.Visible = true;
                btnSave.Visible = false;
                // btnUpdate.Visible = true;
            }

        }
    }

    protected void chkb1SampleNo1MiStatusAccp1_CheckedChanged(object sender, EventArgs e)
    {
        chkb1SampleNo1MiStatusAccp1.Checked = true;
        chkb2SampleNo1MiStatusRej1.Checked = false;
    }

    protected void chkb2SampleNo1MiStatusRej1_CheckedChanged(object sender, EventArgs e)
    {
        chkb1SampleNo1MiStatusAccp1.Checked = false;
        chkb2SampleNo1MiStatusRej1.Checked = true;

    }

    protected void chkb3SampleNo2MiStatusAccp2_CheckedChanged(object sender, EventArgs e)
    {
        chkb3SampleNo2MiStatusAccp2.Checked = true;
        chkb4SampleNo2MiStatusRej2.Checked = false;
    }

    protected void chkb4SampleNo2MiStatusRej2_CheckedChanged(object sender, EventArgs e)
    {
        chkb3SampleNo2MiStatusAccp2.Checked = false;
        chkb4SampleNo2MiStatusRej2.Checked = true;
    }

    protected void chkb5SampleNo3MiStatusAccp3_CheckedChanged(object sender, EventArgs e)
    {
        chkb5SampleNo3MiStatusAccp3.Checked = true;
        chkb6SampleNo3MiStatusRej3.Checked = false;
    }

    protected void chkb6SampleNo3MiStatusRej3_CheckedChanged(object sender, EventArgs e)
    {
        chkb5SampleNo3MiStatusAccp3.Checked = false;
        chkb6SampleNo3MiStatusRej3.Checked = true;
    }

    protected void chkb7SampleNo1PfStsAccp1_CheckedChanged(object sender, EventArgs e)
    {
        chkb7SampleNo1PfStsAccp1.Checked = true;
        chkb8SampleNo1PfStsRej1.Checked = false;
    }

    protected void chkb8SampleNo1PfStsRej1_CheckedChanged(object sender, EventArgs e)
    {
        chkb7SampleNo1PfStsAccp1.Checked = false;
        chkb8SampleNo1PfStsRej1.Checked = true;
    }

    protected void chkb9SampleNo2PfStsAccp2_CheckedChanged(object sender, EventArgs e)
    {
        chkb9SampleNo2PfStsAccp2.Checked = true;
        chkb10SampleNo2PfStsRej2.Checked = false;
    }

    protected void chkb10SampleNo2PfStsRej2_CheckedChanged(object sender, EventArgs e)
    {
        chkb9SampleNo2PfStsAccp2.Checked = false;
        chkb10SampleNo2PfStsRej2.Checked = true;

    }

    protected void chkb11SampleNo3PfStsAccp3_CheckedChanged(object sender, EventArgs e)
    {
        chkb11SampleNo3PfStsAccp3.Checked = true;
        chkb12SampleNo3PfStsRej3.Checked = false;
    }

    protected void chkb12SampleNo3PfStsRej3_CheckedChanged(object sender, EventArgs e)
    {
        chkb11SampleNo3PfStsAccp3.Checked = false;
        chkb12SampleNo3PfStsRej3.Checked = true;
    }

    protected void txtSample1Dat_TextChanged(object sender, EventArgs e)
    {

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
                txtLotNo.Text = "";
                btnClear.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox("Check the given input");
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
                btnClear.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                Clear();
                txtLotNo.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        txtLotNo.Text = "";
    }

    protected void txtSample1Remarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtSample1Remarks.Text;
        txtSample1Remarks.Text = up.ToUpper();
        txtSample1InspBy.Focus();

    }

    protected void txtSample1InspBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtSample1InspBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtSample1InspBy.Text = up.ToUpper();
            }
            else
            {
                MessageBox("Please Enter With INITIAL ex: M.BALAJI");
                txtSample1InspBy.Text = "";
                txtSample1InspBy.Focus();

            }
        }
        catch
        {
            MessageBox("Please Enter With INITIAL ex: M.BALAJI");
            txtSample1InspBy.Text = "";
            txtSample1InspBy.Focus();

        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["up"].Equals(1))
        {
            btnSave.Visible = false;
            btnClear.Visible = true;

            SoftLensDataContext db = new SoftLensDataContext();

            txtLotNo.Text = GridView1.SelectedRow.Cells[1].Text;
            txtCutType.Text = GridView1.SelectedRow.Cells[2].Text;
            if (GridView1.SelectedRow.Cells[3].Text == "accepted")
            {
                chkb1SampleNo1MiStatusAccp1.Checked = true;
            }
            else
            {
                chkb2SampleNo1MiStatusRej1.Checked = true;
                chkb1SampleNo1MiStatusAccp1.Checked = false;
            }
            if (GridView1.SelectedRow.Cells[4].Text == "accepted")
            {
                chkb7SampleNo1PfStsAccp1.Checked = true;
            }
            else
            {
                chkb8SampleNo1PfStsRej1.Checked = true;
                chkb7SampleNo1PfStsAccp1.Checked = false;
            }

            txtSample1HaptiThick1.Text = GridView1.SelectedRow.Cells[5].Text;

            if (GridView1.SelectedRow.Cells[6].Text == "accepted")
            {
                chkb3SampleNo2MiStatusAccp2.Checked = true;
            }
            else
            {
                chkb4SampleNo2MiStatusRej2.Checked = true;
                chkb3SampleNo2MiStatusAccp2.Checked = false;
            }
            if (GridView1.SelectedRow.Cells[7].Text == "accepted")
            {
                chkb9SampleNo2PfStsAccp2.Checked = true;
            }
            else
            {
                chkb10SampleNo2PfStsRej2.Checked = true;
                chkb9SampleNo2PfStsAccp2.Checked = false;
            }
            txtSample2HaptiThick2.Text = GridView1.SelectedRow.Cells[8].Text;
            if (GridView1.SelectedRow.Cells[9].Text == "accepted")
            {
                chkb5SampleNo3MiStatusAccp3.Checked = true;
            }
            else
            {
                chkb6SampleNo3MiStatusRej3.Checked = true;
                chkb5SampleNo3MiStatusAccp3.Checked = false;
            }
            if (GridView1.SelectedRow.Cells[10].Text == "accepted")
            {
                chkb11SampleNo3PfStsAccp3.Checked = true;
            }
            else
            {
                chkb12SampleNo3PfStsRej3.Checked = true;
                chkb11SampleNo3PfStsAccp3.Checked = false;
            }

            txtSample3HaptiThick3.Text = GridView1.SelectedRow.Cells[11].Text;
            txtSample1Remarks.Text = GridView1.SelectedRow.Cells[12].Text;
            if (txtSample1Remarks.Text == "&nbsp;")
            {
                txtSample1Remarks.Text = "";
            }
            txtSample1InspBy.Text = GridView1.SelectedRow.Cells[13].Text;
            ddlSample1Shif.Text = GridView1.SelectedRow.Cells[14].Text;
            txtDate.Text = GridView1.SelectedRow.Cells[15].Text;
            txtLotNo.Enabled = false;
            btnUpdate.Visible = true;
            btnClear.Visible = true;
        }
        else
        {
            MessageBox("Permission is denied");
        }
    }

    protected void txtSample1HaptiThick1_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSample1HaptiThick1.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txtSample1HaptiThick1.Text = "";
            txtSample1HaptiThick1.Focus();
        }
        else
        {
            chkb3SampleNo2MiStatusAccp2.Focus();
        }
    }

    protected void txtSample2HaptiThick2_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSample2HaptiThick2.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txtSample2HaptiThick2.Text = "";
            txtSample2HaptiThick2.Focus();
        }
        else
        {
            chkb5SampleNo3MiStatusAccp3.Focus();
        }

    }

    protected void txtSample3HaptiThick3_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtSample3HaptiThick3.Text);
        if (val == 1)
        {
            MessageBox("Please Enter in this format ex: 05.50");
            txtSample3HaptiThick3.Text = "";
            txtSample3HaptiThick3.Focus();
        }
        else
        {
            txtSample1Remarks.Focus();
        }
    }
    #endregion Events


}
