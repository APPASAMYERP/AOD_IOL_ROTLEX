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
public partial class LensMeasurementInspection : System.Web.UI.Page
{

    #region Declarations
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    #endregion Declarations

    #region Methods
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    protected void Clear()
    {

        txtDate.Text = "";

        drpShift.SelectedValue = "Select";

        txtInspectedby.Text = "";

        txtDiameter1.Text = "";
        txtDiameter2.Text = "";
        txtDiameter3.Text = "";
        txtThkness1.Text = "";
        txtThkness2.Text = "";
        txtThkness3.Text = "";
        ChkAcccepted1.Checked = true;
        ChkAccepted2.Checked = true;
        ChkAccepted3.Checked = true;
        chkRejected3.Checked = false;
        chkRejected2.Checked = false;
        chkRejected1.Checked = false;
        txtRemarks.Text = "";

    }

    protected void Shift()
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

    private void Save()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        LensMeasurement lensmeas = new LensMeasurement();
        {
            lensmeas.LotNo = txtLotNo.Text;

            lensmeas.SampleNo1LensDiameter = Convert.ToDecimal(txtDiameter1.Text);
            lensmeas.SampleNo2LensDiameter2 = Convert.ToDecimal(txtDiameter2.Text);
            lensmeas.SampleNo3LensDiameter3 = Convert.ToDecimal(txtDiameter3.Text);
            lensmeas.SampleNo1LensThickness = Convert.ToDecimal(txtThkness1.Text);
            lensmeas.SampleNo2LensThickness2 = Convert.ToDecimal(txtThkness2.Text);
            lensmeas.SampleNo3LensThickness3 = Convert.ToDecimal(txtThkness3.Text);
            lensmeas.Remarks1 = txtRemarks.Text;
            lensmeas.BlockingType = "Ist Cut";
            lensmeas.StatusShift = drpShift.Text;
            lensmeas.Inspectedby1 = txtInspectedby.Text;


            lensmeas.SampleNo1Date = Convert.ToDateTime(txtDate.Text, provider);

            if (ChkAcccepted1.Checked == true)
            {
                lensmeas.SampleNo1Status = "Accepted ";

            }
            else
            {
                lensmeas.SampleNo1Status = "Rejected";

            }
            if (ChkAccepted2.Checked == true)
            {
                lensmeas.SampleNo2Status = "Accepted ";

            }
            else
            {
                lensmeas.SampleNo2Status = "Rejected";


            }
            if (ChkAcccepted1.Checked == true)
            {
                lensmeas.SampleNo3Status = "Accepted ";

            }
            else
            {
                lensmeas.SampleNo3Status = "Rejected";


            }

        }
        db.LensMeasurements.InsertOnSubmit(lensmeas);
        db.SubmitChanges();
    }

    private void Update()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        LensMeasurement lensmeas = new LensMeasurement();
        lensmeas = db.LensMeasurements.Single(r => r.LotNo == txtLotNo.Text);

        lensmeas.LotNo = txtLotNo.Text;

        lensmeas.SampleNo1LensDiameter = Convert.ToDecimal(txtDiameter1.Text);
        lensmeas.SampleNo2LensDiameter2 = Convert.ToDecimal(txtDiameter2.Text);
        lensmeas.SampleNo3LensDiameter3 = Convert.ToDecimal(txtDiameter3.Text);
        lensmeas.SampleNo1LensThickness = Convert.ToDecimal(txtThkness1.Text);
        lensmeas.SampleNo2LensThickness2 = Convert.ToDecimal(txtThkness2.Text);
        lensmeas.SampleNo3LensThickness3 = Convert.ToDecimal(txtThkness3.Text);
        lensmeas.Remarks1 = txtRemarks.Text;

        lensmeas.Inspectedby1 = txtInspectedby.Text;

        lensmeas.StatusShift = drpShift.Text;

        lensmeas.SampleNo1Date = Convert.ToDateTime(txtDate.Text, provider);


        if (ChkAcccepted1.Checked == true)
        {
            lensmeas.SampleNo1Status = "Accepted";

        }
        else
        {
            lensmeas.SampleNo1Status = "Rejected";


        }
        if (ChkAccepted2.Checked == true)
        {
            lensmeas.SampleNo2Status = "Accepted";

        }
        else
        {
            lensmeas.SampleNo2Status = "Rejected";


        }
        if (ChkAccepted3.Checked == true)
        {
            lensmeas.SampleNo3Status = "Accepted";

        }
        else
        {
            lensmeas.SampleNo3Status = "Rejected";


        }
        db.SubmitChanges();

        Messagebox("Updated Successfully");
    }

    private void GridBind()
    {
        var query = from row in db.LensMeasurements where row.LotNo == txtLotNo.Text select row;
        gvLensMeas.DataSource = query;
        gvLensMeas.DataBind();
    }

    private bool Validation()
    {
        bool _isvalid = true;
        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter Lot No ");
            txtLotNo.Focus();
            _isvalid = false;
        }
        else if (txtDiameter1.Text == "")
        {
            Messagebox("Please Enter Diameter1 Value ");
            txtDiameter1.Focus();
            _isvalid = false;
        }
        else if (txtThkness1.Text == "")
        {
            Messagebox("Please Enter Thickness1 Value ");
            txtThkness1.Focus();
            _isvalid = false;
        }
        else if (txtDiameter2.Text == "")
        {
            Messagebox("Please Enter Diameter2 Value ");
            txtDiameter2.Focus();
            _isvalid = false;
        }
        else if (txtThkness2.Text == "")
        {
            Messagebox("Please Enter Thickness2 Value ");
            txtThkness2.Focus();
            _isvalid = false;
        }
        else if (txtDiameter3.Text == "")
        {
            Messagebox("Please Enter Diameter3 Value ");
            txtDiameter3.Focus();
            _isvalid = false;
        }

        else if (txtThkness3.Text == "")
        {
            Messagebox("Please Enter Thickness3 Value ");
            txtThkness3.Focus();
            _isvalid = false;
        }
        else if (txtInspectedby.Text == "")
        {
            Messagebox("Please Enter InSpectedBy");
            txtInspectedby.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }
    #endregion Methods

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Shift();
            txtBlockingType.Text = Session["Cut Type"].ToString();
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

    protected void chkRejected1_CheckedChanged(object sender, EventArgs e)
    {
        ChkAcccepted1.Checked = false;

        chkRejected1.Checked = true;
        txtDiameter1.Focus();
    }

    protected void ChkAcccepted1_CheckedChanged(object sender, EventArgs e)
    {
        ChkAcccepted1.Checked = true;

        chkRejected1.Checked = false;
        txtDiameter1.Focus();
    }

    protected void ChkAccepted2_CheckedChanged(object sender, EventArgs e)
    {
        ChkAccepted2.Checked = true;

        chkRejected2.Checked = false;
        txtDiameter2.Focus();
    }

    protected void chkRejected2_CheckedChanged(object sender, EventArgs e)
    {
        ChkAccepted2.Checked = false;

        chkRejected2.Checked = true;
        txtDiameter2.Focus();

    }

    protected void ChkAccepted3_CheckedChanged(object sender, EventArgs e)
    {
        ChkAccepted3.Checked = true;

        chkRejected3.Checked = false;
        txtDiameter3.Focus();

    }

    protected void chkRejected3_CheckedChanged(object sender, EventArgs e)
    {
        ChkAccepted3.Checked = false;

        chkRejected3.Checked = true;
        txtDiameter3.Focus();

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
            var val = from A in db.MicroscopicInspections where A.LotNo == txtLotNo.Text select A;
            if (val.Count() == 0)
            {
                Messagebox("Please Enter the Correct Lot No ");
                txtLotNo.Focus();
                txtLotNo.Text = "";
            }
            else
            {
                Clear();
                Shift();
                btnClear.Visible = true;
                ChkAcccepted1.Checked = true;
                ChkAccepted2.Checked = true;
                ChkAccepted3.Checked = true;
                txtDate.Text = txtDate.Text;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                txtDiameter1.Focus();
                txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");



                //var query = from A in db.LensMeasurements where A.LotNo == Convert.ToInt32(txtLotNo.Text) select A;
                //if (query.Count() == 0)
                //{
                //    Messagebox("Please Enter Lot No ");
                //    txtLotNo.Focus();
                //}

                var query1 = from row in db.LensMeasurements where row.LotNo == txtLotNo.Text select row;
                if (query1.Count() >= 1)
                {
                    btnSave.Visible = false;
                }
                gvLensMeas.DataSource = query1;
                gvLensMeas.DataBind();


            }
        }

    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            Save();
            GridBind();
            btnUpdate.Visible = false;
            btnSave.Visible = false;
            btnClear.Visible = false;
            Messagebox("Saved Successfully");
            Clear();
            txtLotNo.Text = "";
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            Update();
            GridBind();
            btnUpdate.Visible = false;
            btnSave.Visible = false;
            btnClear.Visible = false;
            Clear();
            txtLotNo.Text = "";
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
    }

    protected void txtInspectedby_TextChanged(object sender, EventArgs e)
    {
        string up = txtInspectedby.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtInspectedby.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter INITIAL ex: M.BALAJI");
                txtInspectedby.Text = "";
                txtInspectedby.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter INITIAL ex: M.BALAJI");
            txtInspectedby.Text = "";
            txtInspectedby.Focus();
        }
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
        txtInspectedby.Focus();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["up"].Equals(1))
        {
            btnSave.Visible = false;
            btnClear.Visible = true;

            SoftLensDataContext db = new SoftLensDataContext();

            txtLotNo.Text = gvLensMeas.SelectedRow.Cells[1].Text;
            txtDate.Text = gvLensMeas.SelectedRow.Cells[2].Text;

            if (gvLensMeas.SelectedRow.Cells[2].Text == "Accepted")
            {
                ChkAcccepted1.Checked = true;

            }
            else
            {
                ChkAcccepted1.Checked = false;
                chkRejected1.Checked = true;
            }
            txtDiameter1.Text = gvLensMeas.SelectedRow.Cells[4].Text;
            txtThkness1.Text = gvLensMeas.SelectedRow.Cells[5].Text;
            if (gvLensMeas.SelectedRow.Cells[6].Text == "Accepted")
            {
                ChkAccepted2.Checked = true;
            }
            else
            {
                ChkAccepted2.Checked = false;
                chkRejected2.Checked = true;
            }
            txtDiameter2.Text = gvLensMeas.SelectedRow.Cells[7].Text;
            txtThkness2.Text = gvLensMeas.SelectedRow.Cells[8].Text;
            if (gvLensMeas.SelectedRow.Cells[9].Text == "Accepted")
            {
                ChkAccepted3.Checked = true;
            }
            else
            {
                ChkAccepted3.Checked = false;
                chkRejected3.Checked = true;
            }
            txtDiameter3.Text = gvLensMeas.SelectedRow.Cells[10].Text;
            txtThkness3.Text = gvLensMeas.SelectedRow.Cells[11].Text;

            //txtRemarks.Text = gvLensMeas.SelectedRow.Cells[12].Text;
            //if (txtRemarks.Text == "&nbsp;")
            //{
            //    txtRemarks.Text = "";
            //}
            txtInspectedby.Text = gvLensMeas.SelectedRow.Cells[12].Text;
            drpShift.Text = gvLensMeas.SelectedRow.Cells[13].Text;

            btnUpdate.Visible = true;
            btnClear.Visible = true;
        }
        else
        {
            Messagebox("Permission is Denied");
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

    protected void txtDiameter1_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtDiameter1.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtDiameter1.Text = "";
            txtDiameter1.Focus();
        }
        else
        {
            txtThkness1.Focus();
        }

    }

    protected void txtDiameter2_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtDiameter2.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtDiameter2.Text = "";
            txtDiameter2.Focus();
        }
        else
        {
            txtThkness2.Focus();
        }
    }

    protected void txtDiameter3_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtDiameter3.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtDiameter3.Text = "";
            txtDiameter3.Focus();
        }
        else
        {
            txtThkness3.Focus();
        }
    }

    protected void txtThkness1_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtThkness1.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtThkness1.Text = "";
            txtThkness1.Focus();
        }
        else
        {
            ChkAccepted2.Focus();
        }
    }

    protected void txtThkness2_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtThkness2.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtThkness2.Text = "";
            txtThkness2.Focus();
        }
        else
        {
            ChkAccepted3.Focus();
        }
    }

    protected void txtThkness3_TextChanged(object sender, EventArgs e)
    {
        int val = PowerValidation(txtThkness3.Text);
        if (val == 1)
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtThkness3.Text = "";
            txtThkness3.Focus();
        }
        else
        {
            txtRemarks.Focus();
        }
    }

    #endregion Events

}
