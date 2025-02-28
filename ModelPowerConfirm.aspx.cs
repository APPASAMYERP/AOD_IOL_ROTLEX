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

public partial class ModelPowerConfirm : System.Web.UI.Page
{

    #region declaration

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext SL = new SoftLensDataContext();

    #endregion



    #region method

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void clear()
    {
        txtLotNo.Text = "";
        txtTmbLotNo1.Text = "";
        txtModel.Text = "";
        drpPower.SelectedValue = "--Select--";
        //txtJarNo.Text = "";
        txtDate.Text = "";
        chk1.Checked = false;
        Chk2.Checked = false;
        Chk3.Checked = false;
        Chk4.Checked = false;
        Chk5.Checked = false;
        Chk6.Checked = false;
        Chk7.Checked = false;
        Chk8.Checked = false;
        Chk9.Checked = false;
        Chk10.Checked = false;
        ChkAccept.Checked = false;
        ChkReject.Checked = false;
        ChkAccep1.Checked = false;
        ChkRejec1.Checked = false;
        Textpow1.Text = "";
        Textpow2.Text = "";
        Textpow3.Text = "";
        Textpow4.Text = "";
        Textpow5.Text = "";
        Textpow6.Text = "";
        Textpow7.Text = "";
        Textpow8.Text = "";
        Textpow9.Text = "";
        Textpow10.Text = "";
        TextModInsBy.Text = "";
        TextPowInsBy.Text = "";


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
        //else if (txtJarNo.Text == "")
        //{
        //    Messagebox("Enter Jar No");
        //    txtJarNo.Focus();
        //    _isvalid = false;
        //}

        return _isvalid;

    }


    private void Meassagebox()
    {
        throw new NotImplementedException();
    }


    private void SaveMethod()
    {
        ModelPower mp = new ModelPower();
        mp.GRFLotno = txtLotNo.Text;
        mp.TumblingLotno = txtTmbLotNo1.Text;
        mp.ModelNo = txtModel.Text;
        mp.Power = Convert.ToDecimal(drpPower.SelectedValue);
        //mp.JarNo = txtJarNo.Text;
        if (chk1.Checked == true)
        {
            mp.Sample1Status = "Accepted";
        }
        if (Chk2.Checked == true)
        {
            mp.Sample2Status = "Accepted";
        }
        if (Chk3.Checked == true)
        {
            mp.Sample3Status = "Accepted";
        }
        if (Chk4.Checked == true)
        {
            mp.Sample4Status = "Accepted";
        }
        if (Chk5.Checked == true)
        {
            mp.Sample5Status = "Accepted";
        }
        if (Chk6.Checked == true)
        {
            mp.Sample6Status = "Accepted";
        }
        if (Chk7.Checked == true)
        {
            mp.Sample7Status = "Accepted";
        }
        if (Chk8.Checked == true)
        {
            mp.Sample8Status = "Accepted";
        }
        if (Chk9.Checked == true)
        {
            mp.Sample9Status = "Accepted";
        }
        if (Chk10.Checked == true)
        {
            mp.Sample10Status = "Accepted";
        }
        mp.Sample1Power = Convert.ToDecimal(Textpow1.Text);
        mp.Sample2Power = Convert.ToDecimal(Textpow2.Text);
        mp.Sample3Power = Convert.ToDecimal(Textpow3.Text);
        mp.Sample4Power = Convert.ToDecimal(Textpow4.Text);
        mp.Sample5Power = Convert.ToDecimal(Textpow5.Text);
        mp.Sample6Power = Convert.ToDecimal(Textpow6.Text);
        mp.Sample7Power = Convert.ToDecimal(Textpow7.Text);
        mp.Sample8Power = Convert.ToDecimal(Textpow8.Text);
        mp.Sample9Power = Convert.ToDecimal(Textpow9.Text);
        mp.Sample10Power = Convert.ToDecimal(Textpow10.Text);

        if (ChkAccept.Checked == true)
        {
            mp.ModelStatus = "Accepted";
        }
        if (ChkReject.Checked == true)
        {
            mp.ModelStatus = "Rejected";
        }
        if (ChkAccep1.Checked == true)
        {
            mp.PowerStatus = "Accepted";

        }
        if (ChkRejec1.Checked == true)
        {
            mp.PowerStatus = "Rejected";
        }

        mp.ModelIns = TextModInsBy.Text;
        mp.PowerIns = TextPowInsBy.Text;
        SL.ModelPowers.InsertOnSubmit(mp);
        SL.SubmitChanges();
        btnSave.Visible = false;
        Messagebox("Saved Successfully");

    }


    #endregion



    #region events

    protected void Page_Load(object sender, EventArgs e)
    {
        var username = (Session["Username"] as HtmlInputControl).Value;

        if (username == null)
        {
            Response.Redirect("404Page.aspx");
        }
        txtDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");


    }


    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (validation1())
        {
            SaveMethod();
            clear();
            btnClear.Visible = false;
            txtLotNo.Text = "";


        }

    }

    protected void txtGRFNO_TextChanged(object sender, EventArgs e)
    {
        string t = txtLotNo.Text;
        txtLotNo.Text = t.ToUpper();

        var qury = from x in SL.Pick_Packings where x.GlassyNo == txtLotNo.Text select x;
        var query = from row in SL.PowerSegregationChilds where row.TumblingNo == txtLotNo.Text select row;
        if (query.Count() > 0)
        {
            //txtTmbLotNo1.Text = query.Single().TumblingNo.ToString();
            var seg = from a in SL.PowerSegregationChilds
                      where a.TumblingNo == txtLotNo.Text
                      select a;
            drpPower.Items.Clear();
            drpPower.Items.Add("--Select--");
            drpPower.DataSource = seg;
            drpPower.DataTextField = "Power";
            drpPower.DataValueField = "Power";
            drpPower.DataBind();
            //txtModel.Text = qury.Single().Model;
            //txtPower.Text = query.Single().Power.ToString();
            btnSave.Visible = true;
            btnClear.Visible = true;
            //var query1 = from row in SL.RemattTumblingLens where row.RetumblingRef1 == txtTmbLotNo1.Text && row.Power1 == Convert.ToDecimal(txtPower.Text) select row;
            //var query3 = from row in SL.RemattTumblingLens where row.RetumblingRef2 == txtTmbLotNo1.Text && row.Power2 == Convert.ToDecimal(txtPower.Text) select row;
            //var query5 = from row in SL.RemattTumblingLens where row.RetumblingRef3 == txtTmbLotNo1.Text && row.Power3 == Convert.ToDecimal(txtPower.Text) select row;
            ////var query4 = from row in SL.MattTumblingLens where row.TumblingLotNo == txtTmbLotNo1.Text select row;
            //var query4 = from row in SL.FinalLensPreparations where row.TumblingNo == txtTmbLotNo1.Text select row;
            //if (query1.Count() > 0)
            //{
            //    txtModel.Text = query1.Single().Model1.ToString();
            //}
            //else if (query3.Count() > 0)
            //{
            //    txtModel.Text = query3.Single().Model2.ToString();
            //}
            //else if (query5.Count() > 0)
            //{
            //    txtModel.Text = query5.Single().Model3.ToString();
            //}
            //else
            //{
            //    txtModel.Text = query4.Single().Model.ToString();
            //}

            //var query2 = (from row in SL.SO_MattTumblings where row.TumblingNo == txtTmbLotNo1.Text select row).Take(1).SingleOrDefault();
            //txtJarNo.Text = query2.JarNo.ToString();

            //var query2 = (from row in SL.GlassyTumblingSOs where row.TumblingLotNo == txtTmbLotNo1.Text select row).Take(1).SingleOrDefault();
            //txtJarNo.Text = query2.JarNo.ToString();
        }

        else
        {
            Messagebox("Enter a valid Lot No");
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }

    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;

    }


    protected void chk1_CheckedChanged(object sender, EventArgs e)
    {
        chk1.Checked = true;
    }
    protected void Chk2_CheckedChanged(object sender, EventArgs e)
    {
        Chk2.Checked = true;
    }
    protected void Chk3_CheckedChanged(object sender, EventArgs e)
    {
        Chk3.Checked = true;
    }
    protected void Chk4_CheckedChanged(object sender, EventArgs e)
    {
        Chk4.Checked = true;
    }
    protected void Chk5_CheckedChanged(object sender, EventArgs e)
    {
        Chk5.Checked = true;
    }
    protected void Chk6_CheckedChanged(object sender, EventArgs e)
    {
        Chk6.Checked = true;
    }
    protected void Chk7_CheckedChanged(object sender, EventArgs e)
    {
        Chk7.Checked = true;
    }
    protected void Chk8_CheckedChanged(object sender, EventArgs e)
    {
        Chk8.Checked = true;
    }
    protected void Chk9_CheckedChanged(object sender, EventArgs e)
    {
        Chk9.Checked = true;
    }
    protected void Chk10_CheckedChanged(object sender, EventArgs e)
    {
        Chk10.Checked = true;
    }

    protected void ChkAccept_CheckedChanged(object sender, EventArgs e)
    {
        ChkAccept.Checked = true;
        ChkReject.Checked = false;
    }
    protected void ChkReject_CheckedChanged(object sender, EventArgs e)
    {
        ChkAccept.Checked = false;
        ChkReject.Checked = true;
    }
    protected void ChkAccep1_CheckedChanged(object sender, EventArgs e)
    {
        ChkAccep1.Checked = true;
        ChkRejec1.Checked = false;
    }
    protected void ChkRejec1_CheckedChanged(object sender, EventArgs e)
    {
        ChkAccep1.Checked = false;
        ChkRejec1.Checked = true;
    }
    protected void TextModInsBy_TextChanged(object sender, EventArgs e)
    {
        string up = TextModInsBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                TextModInsBy.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter INITIAL ex: M.BALAJI");
                TextModInsBy.Text = "";
                TextModInsBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter INITIAL ex: M.BALAJI");
            TextModInsBy.Text = "";
            TextModInsBy.Focus();
        }
    }

    #endregion
    
    protected void TextPowInsBy_TextChanged(object sender, EventArgs e)
    {
        string up1 = TextPowInsBy.Text;
        try
        {
            if (up1[1] == '.' && up1[2] != '.' && (up1[2] >= 65 && up1[2] <= 122))
            {
                TextPowInsBy.Text = up1.ToUpper();
            }
            else
            {
                Messagebox("Please Enter INITIAL ex: M.BALAJI");
                TextPowInsBy.Text = "";
                TextPowInsBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter INITIAL ex: M.BALAJI");
            TextModInsBy.Text = "";
            TextModInsBy.Focus();
        }

    }
    protected void drpPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        var q = from row in SL.ModelPowers where row.GRFLotno == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        if (q.Count() > 0)
        {
            txtTmbLotNo1.Text = q.Single().TumblingLotno.ToString();
            drpPower.SelectedValue = q.Single().Power.ToString();
            txtModel.Text = q.Single().ModelNo.ToString();
            //txtJarNo.Text = q.Single().JarNo.ToString();
            btnSave.Visible = false;
            btnClear.Visible = true;

        }
        else
        {
            var qury = from x in SL.Pick_Packings where x.TumblingNo == txtLotNo.Text && x.Power == Convert.ToDecimal(drpPower.SelectedValue) select x;
            if (qury.Count() > 0)
            {
                txtTmbLotNo1.Text = qury.Single().TumblingNo;
                txtModel.Text = qury.Single().Model;
            }
        }
    }
    protected void txtJarNo_TextChanged(object sender, EventArgs e)
    {
        //string jar = txtJarNo.Text;
        //txtJarNo.Text = jar.ToUpper();
        //btnSave.Focus();
    }
}
