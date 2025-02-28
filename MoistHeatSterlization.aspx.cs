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
using System.ComponentModel;
using System.Windows.Forms;

public partial class MoistHeatSterlization : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    DateTime StartTime;
    static int[] stcount;
    static int[] lalcount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 1; i <= 12; i++)
            {               
                chklbBiological.Items.Add(i.ToString());
                stcount = new int[6];
                lalcount = new int[6];
            }
        }

    }


    private void Shift()
    {
        String time = DateTime.Now.Hour.ToString();

        if (Convert.ToInt32(time) >= 6 && Convert.ToInt32(time) <= 13)
        {
            ddlShift.SelectedIndex = 1;

        }
        if (Convert.ToInt32(time) >= 14 && Convert.ToInt32(time) <= 22)
        {
            ddlShift.SelectedIndex = 2;

        }
        if (Convert.ToInt32(time) >= 22 && Convert.ToInt32(time) <= 5)
        {
            ddlShift.SelectedIndex = 3;

        }

    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void Clear()
    {
        txtDate.Text = "";
        txtBatchNo.Text = "";
        txtDateLoad.Text = "";
        txtLotNo1.Text = "";
        txtLotNo2.Text = "";
        txtLotNo3.Text = "";
        txtLotNo4.Text = "";
        txtLotNo5.Text = "";
        txtLotNo6.Text = "";
        txtQty1.Text = "";
        txtQty2.Text = "";
        txtQty3.Text = "";
        txtQty4.Text = "";
        txtQty5.Text = "";
        txtQty6.Text = "";
        txtQtyDummy.Text = "";
        chklbBiological.Items.Clear();
        for (int i = 1; i <= 12; i++)
        {
            chklbBiological.Items.Add(i.ToString());
        }
        ddlMode.Text = "Auto";
        txtExposureTime.Text = "";
        ddlRoomTemp.Text = "29°C";
        txtStartTime.Text = "";
        ddlDayStart.Text = "AM";
        txtStopTime.Text = "";
        ddlDayStop.Text = "AM";
        txtCycleTime.Text = "";
        ddlBeforeChemical.Text = "Pink";
        ddlAfterChemical.Text = "Brown";
        txtResultChemical.Text = "";
        txtCheckedByChemical.Text = "";
        ddlBeforeBio.Text = "Pink";
        ddlAfterBio.Text = "Brown";
        txtResultBio.Text = "";
        txtCheckedByBio.Text = "";


    }

    protected void txtMHSRNo_TextChanged(object sender, EventArgs e)
    {
        Clear();
        Shift();
        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDateLoad.Text = DateTime.Now.ToString("dd/MM/yyyy");

        txtQtyDummy.Text = "1200";

        btnSave.Visible = false;
        btnUpdate.Visible = false;

        try
        {
            var query = from r in db.MHSRs where r.MHSRNo == txtMHSRNo.Text select r;
            DateTime datedt = query.Single().Date.Value;
            txtDate.Text = datedt.ToString("dd/MM/yyyy");
            txtBatchNo.Text = query.Single().BatchNo;
            DateTime datedte = query.Single().DateLoad.Value;
            txtDateLoad.Text = datedte.ToString("dd/MM/yyyy");
            txtLotNo1.Text = query.Single().LotNo1.ToString();
            txtLotNo2.Text = query.Single().LotNo2.ToString();
            txtLotNo3.Text = query.Single().LotNo3.ToString();
            txtLotNo4.Text = query.Single().LotNo4.ToString();
            txtLotNo5.Text = query.Single().LotNo5.ToString();
            txtLotNo6.Text = query.Single().LotNo6.ToString();
            txtDummy.Text = query.Single().DummyLotNo.ToString();
            txtQty1.Text = query.Single().qty1.ToString();
            txtQty2.Text = query.Single().qty2.ToString();
            txtQty3.Text = query.Single().qty3.ToString();
            txtQty4.Text = query.Single().qty4.ToString();
            txtQty5.Text = query.Single().qty5.ToString();
            txtQty6.Text = query.Single().qty6.ToString();
            txtQtyDummy.Text = query.Single().qtyDummy.ToString();

            if (query.Single().BI1 == "T")
            {
                chklbBiological.Items[0].Selected = true;
            }
            else
            {
                chklbBiological.Items[0].Selected = false;
            }

            if (query.Single().BI2 == "T")
            {
                chklbBiological.Items[1].Selected = true;
            }
            else
            {
                chklbBiological.Items[1].Selected = false;
            }

            if (query.Single().BI3 == "T")
            {
                chklbBiological.Items[2].Selected = true;
            }
            else
            {
                chklbBiological.Items[2].Selected = false;
            }

            if (query.Single().BI4 == "T")
            {
                chklbBiological.Items[3].Selected = true;
            }
            else
            {
                chklbBiological.Items[3].Selected = false;
            }

            if (query.Single().BI5 == "T")
            {
                chklbBiological.Items[4].Selected = true;
            }
            else
            {
                chklbBiological.Items[4].Selected = false;
            }

            if (query.Single().BI6 == "T")
            {
                chklbBiological.Items[5].Selected = true;
            }
            else
            {
                chklbBiological.Items[5].Selected = false;
            }

            if (query.Single().BI7 == "T")
            {
                chklbBiological.Items[6].Selected = true;
            }
            else
            {
                chklbBiological.Items[6].Selected = false;
            }

            if (query.Single().BI8 == "T")
            {
                chklbBiological.Items[7].Selected = true;
            }
            else
            {
                chklbBiological.Items[7].Selected = false;
            }

            if (query.Single().BI9 == "T")
            {
                chklbBiological.Items[8].Selected = true;
            }
            else
            {
                chklbBiological.Items[8].Selected = false;
            }

            if (query.Single().BI10 == "T")
            {
                chklbBiological.Items[9].Selected = true;
            }
            else
            {
                chklbBiological.Items[9].Selected = false;
            }

            if (query.Single().BI11 == "T")
            {
                chklbBiological.Items[10].Selected = true;
            }
            else
            {
                chklbBiological.Items[10].Selected = false;
            }

            if (query.Single().BI12 == "T")
            {
                chklbBiological.Items[11].Selected = true;
            }
            else
            {
                chklbBiological.Items[11].Selected = false;
            }



            ddlMode.Text = query.Single().Mode;
            txtExposureTime.Text = query.Single().ExposureTime;
            ddlRoomTemp.Text = query.Single().RoomTemp;
            txtStartTime.Text = query.Single().StartTime;
            ddlDayStart.Text = query.Single().StartDay;
            txtStopTime.Text = query.Single().StopTime;
            ddlDayStop.Text = query.Single().StopDay;
            txtCycleTime.Text = query.Single().CycleTime;
            ddlBeforeChemical.Text = query.Single().BeforeChemical;
            ddlAfterChemical.Text = query.Single().AfterChemical;
            txtResultChemical.Text = query.Single().ResultChemical;
            txtCheckedByChemical.Text = query.Single().CheckedByChemical;
            ddlBeforeBio.Text = query.Single().BeforeBio;
            ddlAfterBio.Text = query.Single().AfterBio;
            txtResultBio.Text = query.Single().ResultBio;
            txtCheckedByBio.Text = query.Single().CheckedByBio;
            btnUpdate.Visible = true;
            btnClear.Visible = true;
        }
        catch
        {
            btnSave.Visible = true;
            btnClear.Visible = true;
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        txtMHSRNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtMHSRNo.Text == "")
        {
            Messagebox("Please Enter MHSRNO");
            txtMHSRNo.Focus();
        }
        else if (txtBatchNo.Text == "")
        {
            Messagebox("Please Enter BatchNo");
            txtMHSRNo.Focus();
        }
        else if (txtBatchNo.Text == "")
        {
            Messagebox("Please Enter BatchNo");
            txtMHSRNo.Focus();
        }
        else
        {
            string[] v = new string[12];
            for (int i = 0; i < 12; i++)
            {
                if (chklbBiological.Items[i].Selected == true)
                {
                    v[i] = "T";
                }
                else
                {
                    v[i] = "F";
                }
            }
            MHSR mhsrtable = new MHSR();

            mhsrtable.MHSRNo = txtMHSRNo.Text;
            mhsrtable.BatchNo = txtBatchNo.Text;
            mhsrtable.DateLoad = Convert.ToDateTime(txtDateLoad.Text, provider);
            mhsrtable.ResultBio = txtResultBio.Text;
            mhsrtable.AfterBio = ddlAfterBio.Text;
            mhsrtable.AfterChemical = ddlAfterChemical.Text;
            mhsrtable.BeforeBio = ddlBeforeBio.Text;
            mhsrtable.BeforeChemical = ddlBeforeChemical.Text;

            mhsrtable.CheckedByBio = txtCheckedByBio.Text;
            mhsrtable.CheckedByChemical = txtCheckedByChemical.Text;

            mhsrtable.CycleTime = txtCycleTime.Text;
            mhsrtable.Date = Convert.ToDateTime(txtDate.Text, provider);

            mhsrtable.DummyLotNo = txtDummy.Text;
            mhsrtable.ExposureTime = txtExposureTime.Text;
                 if(txtLotNo1.Text !="")
                 {
                     mhsrtable.LotNo1 = Convert.ToInt32(txtLotNo1.Text);    
                 }
                 if(txtLotNo2.Text!="")
                 {
                     mhsrtable.LotNo2 = Convert.ToInt32(txtLotNo2.Text);
                 }
                 if(txtLotNo3.Text!="")
                 {
                     mhsrtable.LotNo3 = Convert.ToInt32(txtLotNo3.Text);
                 }
                 if(txtLotNo4.Text!="")
                 {
                     mhsrtable.LotNo4 = Convert.ToInt32(txtLotNo4.Text);
                 }
                 if(txtLotNo5.Text!="")
                 {
                     mhsrtable.LotNo5 = Convert.ToInt32(txtLotNo5.Text);
                 }
                 if (txtLotNo6.Text!="")
                 {
                     mhsrtable.LotNo6 = Convert.ToInt32(txtLotNo6.Text);
                 }

                 mhsrtable.Mode = ddlMode.Text;


                 mhsrtable.qty1 = Convert.ToInt32(txtQty1.Text);
                 mhsrtable.qty2 = Convert.ToInt32(txtQty2.Text);
                 mhsrtable.qty3 = Convert.ToInt32(txtQty3.Text);
                 mhsrtable.qty4 = Convert.ToInt32(txtQty4.Text);
                 mhsrtable.qty5 = Convert.ToInt32(txtQty5.Text);
                 mhsrtable.qty6 = Convert.ToInt32(txtQty6.Text);
                 mhsrtable.qtyDummy = Convert.ToInt32(txtQtyDummy.Text);

                 mhsrtable.ResultChemical = txtResultChemical.Text;

                 mhsrtable.RoomTemp = ddlRoomTemp.Text;
                 mhsrtable.Shift = ddlShift.Text;
                 mhsrtable.StartDay = ddlDayStart.Text;
                 mhsrtable.StartTime = txtStartTime.Text;

                 mhsrtable.StopDay = ddlDayStop.Text;
                 mhsrtable.StopTime = txtStopTime.Text;

                 mhsrtable.BI1 = v[0];
                 mhsrtable.BI2 = v[1];
                 mhsrtable.BI3 = v[2];
                 mhsrtable.BI4 = v[3];
                 mhsrtable.BI5 = v[4];
                 mhsrtable.BI6 = v[5];
                 mhsrtable.BI7 = v[6];
                 mhsrtable.BI8 = v[7];
                 mhsrtable.BI9 = v[8];
                 mhsrtable.BI10 = v[9];
                 mhsrtable.BI11 = v[10];
                 mhsrtable.BI12 = v[11];
                 mhsrtable.SterilityTest = Session["Sterility"].ToString();
                 mhsrtable.LalTest = Session["LalTest"].ToString();
                
            db.MHSRs.InsertOnSubmit(mhsrtable);
            db.SubmitChanges();
            Messagebox("Saved Successfully");
            Clear();
            txtMHSRNo.Text = "";
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {

        string[] v = new string[12];
        for (int i = 0; i < 12; i++)
        {
            if (chklbBiological.Items[i].Selected == true)
            {
                v[i] = "T";
            }
            else
            {
                v[i] = "F";
            }
        }
        var query = from r in db.MHSRs where r.MHSRNo == txtMHSRNo.Text select r;
        query.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
        query.Single().BatchNo = txtBatchNo.Text;
        query.Single().DateLoad = Convert.ToDateTime(txtDateLoad.Text, provider);
        if (txtLotNo1.Text != "")
        {
            query.Single().LotNo1 = Convert.ToInt32(txtLotNo1.Text);
        }
        if (txtLotNo2.Text != "")
        {
            query.Single().LotNo2 = Convert.ToInt32(txtLotNo2.Text);
        }
        if (txtLotNo3.Text != "")
        {
            query.Single().LotNo3 = Convert.ToInt32(txtLotNo3.Text);
        }
        if (txtLotNo4.Text != "")
        {
            query.Single().LotNo4 = Convert.ToInt32(txtLotNo4.Text);
        }
        if (txtLotNo5.Text != "")
        {
            query.Single().LotNo5 = Convert.ToInt32(txtLotNo5.Text);
        }
        if (txtLotNo6.Text != "")
        {
            query.Single().LotNo6 = Convert.ToInt32(txtLotNo6.Text);
        }
        query.Single().DummyLotNo = txtDummy.Text;
        query.Single().qty1 = Convert.ToInt32(txtQty1.Text);
        query.Single().qty2 = Convert.ToInt32(txtQty2.Text);
        query.Single().qty3 = Convert.ToInt32(txtQty3.Text);
        query.Single().qty4 = Convert.ToInt32(txtQty4.Text);
        query.Single().qty5 = Convert.ToInt32(txtQty5.Text);
        query.Single().qty6 = Convert.ToInt32(txtQty6.Text);
        query.Single().qtyDummy = Convert.ToInt32(txtQtyDummy.Text);

        query.Single().BI1 = v[0];
        query.Single().BI2 = v[1];
        query.Single().BI3 = v[2];
        query.Single().BI4 = v[3];
        query.Single().BI5 = v[4];
        query.Single().BI6 = v[5];
        query.Single().BI7 = v[6];
        query.Single().BI8 = v[7];
        query.Single().BI9 = v[8];
        query.Single().BI10 = v[9];
        query.Single().BI11 = v[1];
        query.Single().BI12 = v[1];

        query.Single().Mode = ddlMode.Text;
        query.Single().ExposureTime = txtExposureTime.Text;
        query.Single().RoomTemp = ddlRoomTemp.Text;
        query.Single().StartTime = txtStartTime.Text;
        query.Single().StartDay = ddlDayStart.Text;
        query.Single().StopTime = txtStopTime.Text;
        query.Single().StopDay = ddlDayStop.Text;
        query.Single().CycleTime = txtCycleTime.Text;
        query.Single().BeforeChemical = ddlBeforeChemical.Text;
        query.Single().AfterChemical = ddlAfterChemical.Text;
        query.Single().ResultChemical = txtResultChemical.Text;
        query.Single().CheckedByChemical = txtCheckedByChemical.Text;
        query.Single().BeforeBio = ddlBeforeBio.Text;
        query.Single().AfterBio = ddlAfterBio.Text;
        query.Single().ResultBio = txtResultBio.Text;
        query.Single().CheckedByBio = txtCheckedByBio.Text;
        query.Single().SterilityTest = Session["Sterility"].ToString();
        query.Single().LalTest = Session["LalTest"].ToString();
        db.SubmitChanges();
        Messagebox("Updated Successfully");
        Clear();
        txtMHSRNo.Text = "";

    }

    protected void txtLotNo1_TextChanged(object sender, EventArgs e)
    {
        try 
        {
            var dup = from r in db.MHSRs where r.LotNo1 == Convert.ToInt32(txtLotNo1.Text) || r.LotNo2 == Convert.ToInt32(txtLotNo1.Text) || r.LotNo3 == Convert.ToInt32(txtLotNo1.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo1.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo1.Text) || r.LotNo5 == Convert.ToInt32(txtLotNo1.Text) || r.LotNo6 == Convert.ToInt32(txtLotNo1.Text) select r;
            if (dup.Count() != 0)
            {
                Messagebox("LotNo Already in Use");
                txtLotNo1.Text = "";
                txtQty1.Text = "0";
            }
            else if (txtLotNo2.Text != "" && Convert.ToInt32(txtLotNo1.Text) == Convert.ToInt32(txtLotNo2.Text))
            {
                Messagebox("LotNo Already in Use");
                    txtLotNo1.Text = "";
                    txtQty1.Text = "0";
            }
            else if (txtLotNo3.Text != "" && Convert.ToInt32(txtLotNo1.Text) == Convert.ToInt32(txtLotNo3.Text))
            {
                Messagebox("LotNo Already in Use");
                    txtLotNo1.Text = "";
                    txtQty1.Text = "0";
            }
            else if (txtLotNo4.Text != "" && Convert.ToInt32(txtLotNo1.Text) == Convert.ToInt32(txtLotNo4.Text))
            {
                Messagebox("LotNo Already in Use");
                    txtLotNo1.Text = "";
                    txtQty1.Text = "0";
            }
            else if (txtLotNo5.Text != "" && Convert.ToInt32(txtLotNo1.Text) == Convert.ToInt32(txtLotNo5.Text))
            {
                Messagebox("LotNo Already in Use");
                    txtLotNo1.Text = "0";
            }
            else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo1.Text) == Convert.ToInt32(txtLotNo6.Text))
            {
                Messagebox("LotNo Already in Use");
                    txtLotNo1.Text = "";
                    txtQty1.Text = "0";
            }
            else
            {
                var q = (from r in db.LabelDetailsPackings where r.LotNo == txtLotNo1.Text select r.Qty).Sum();
                txtQty1.Text = Convert.ToString(q.Value);
                if (txtQty1.Text == "")
                {
                    txtQty1.Text = "0";
                }
                if (txtQty2.Text == "")
                {
                    txtQty2.Text = "0";
                }
                if (txtQty3.Text == "")
                {
                    txtQty3.Text = "0";
                }
                if (txtQty4.Text == "")
                {
                    txtQty4.Text = "0";
                }
                if (txtQty5.Text == "")
                {
                    txtQty5.Text = "0";
                }
                if (txtQty6.Text == "")
                {
                    txtQty6.Text = "0";
                }
                txtQtyDummy.Text = Convert.ToString(1200 - (Convert.ToInt32(txtQty1.Text) + Convert.ToInt32(txtQty2.Text) + Convert.ToInt32(txtQty3.Text) + Convert.ToInt32(txtQty4.Text) + Convert.ToInt32(txtQty5.Text) + Convert.ToInt32(txtQty6.Text)));

                try
                {
                    var q1 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo1.Text) && r.TestType == "Sterile" select r;
                    stcount[0] = q1.Count();
                }
                catch
                {

                }
                try
                {
                    var q2 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo1.Text) && r.TestType == "Lal" select r;
                    lalcount[0] = q2.Count();
                }
                catch
                {
                }


                Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
                Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);
            }        
                
            
        }
        catch
        {
            stcount[0] = 0;
            lalcount[0] = 0;
            Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
            Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);
        }
    }
    protected void txtLotNo2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var dup = from r in db.MHSRs where r.LotNo1 == Convert.ToInt32(txtLotNo2.Text) || r.LotNo2 == Convert.ToInt32(txtLotNo2.Text) || r.LotNo3 == Convert.ToInt32(txtLotNo2.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo2.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo2.Text) || r.LotNo5 == Convert.ToInt32(txtLotNo2.Text) || r.LotNo6 == Convert.ToInt32(txtLotNo2.Text) select r;
             if (dup.Count() != 0)
             {
                 Messagebox("LotNo Already in Use");
                 txtLotNo2.Text = "";
                 txtQty2.Text = "0";
             }
             else if (txtLotNo1.Text!="" && Convert.ToInt32(txtLotNo2.Text) == Convert.ToInt32(txtLotNo1.Text)) 
            {   
                     Messagebox("LotNo Already in Use");
                     txtLotNo2.Text = "";
                     txtQty2.Text = "0"; 
            }
             else if (txtLotNo3.Text != "" && Convert.ToInt32(txtLotNo2.Text) == Convert.ToInt32(txtLotNo3.Text))
             {
                     Messagebox("LotNo Already in Use");
                     txtLotNo2.Text = "";
                     txtQty2.Text = "0";
             }
             else if (txtLotNo4.Text != "" && (Convert.ToInt32(txtLotNo2.Text) == Convert.ToInt32(txtLotNo4.Text)))
             {
                     Messagebox("LotNo Already in Use");
                     txtLotNo2.Text = "";
                     txtQty2.Text = "0";
             }
             else if (txtLotNo5.Text != "" && Convert.ToInt32(txtLotNo2.Text) == Convert.ToInt32(txtLotNo5.Text))
             {
                 Messagebox("LotNo Already in Use");
                     txtLotNo2.Text = "";
                     txtQty2.Text = "0";
             }
             else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo2.Text) != Convert.ToInt32(txtLotNo6.Text))
             {
                 Messagebox("LotNo Already in Use");
                     txtLotNo2.Text = "";
                     txtQty2.Text = "0";
             }
             else
             {
                 var q = (from r in db.LabelDetailsPackings where r.LotNo == txtLotNo2.Text select r.Qty).Sum();
                 txtQty2.Text = Convert.ToString(q.Value);
                 if (txtQty1.Text == "")
                 {
                     txtQty1.Text = "0";
                 }
                 if (txtQty2.Text == "")
                 {
                     txtQty2.Text = "0";
                 }
                 if (txtQty3.Text == "")
                 {
                     txtQty3.Text = "0";
                 }
                 if (txtQty4.Text == "")
                 {
                     txtQty4.Text = "0";
                 }
                 if (txtQty5.Text == "")
                 {
                     txtQty5.Text = "0";
                 }
                 if (txtQty6.Text == "")
                 {
                     txtQty6.Text = "0";
                 }
                 txtQtyDummy.Text = Convert.ToString(1200 - (Convert.ToInt32(txtQty1.Text) + Convert.ToInt32(txtQty2.Text) + Convert.ToInt32(txtQty3.Text) + Convert.ToInt32(txtQty4.Text) + Convert.ToInt32(txtQty5.Text) + Convert.ToInt32(txtQty6.Text)));

                 try
                 {
                     var q1 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo2.Text) && r.TestType == "Sterile" select r;
                     stcount[1] = q1.Count();
                 }
                 catch
                 {

                 }
                 try
                 {
                     var q2 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo2.Text) && r.TestType == "Lal" select r;
                     lalcount[1] = q2.Count();
                 }
                 catch
                 {
                 }


                 Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
                 Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);
             }            
            

        }
        catch
        {
            stcount[1] = 0;
            lalcount[1] = 0;
            Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
            Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);

        }
    }
    protected void txtLotNo3_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var dup = from r in db.MHSRs where r.LotNo1 == Convert.ToInt32(txtLotNo3.Text) || r.LotNo2 == Convert.ToInt32(txtLotNo3.Text) || r.LotNo3 == Convert.ToInt32(txtLotNo3.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo3.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo3.Text) || r.LotNo5 == Convert.ToInt32(txtLotNo3.Text) || r.LotNo6 == Convert.ToInt32(txtLotNo3.Text) select r;
            if (dup.Count() != 0)
            {
                Messagebox("LotNo Already in Use");
                txtLotNo3.Text = "";
                txtQty3.Text = "0";
            }
            else if (txtLotNo1.Text != "" && Convert.ToInt32(txtLotNo3.Text) == Convert.ToInt32(txtLotNo1.Text))
            {
                Messagebox("LotNo Already in Use");
                    txtLotNo3.Text = "";
                    txtQty3.Text = "0";
            }
            else if (txtLotNo2.Text !="" && Convert.ToInt32(txtLotNo3.Text) == Convert.ToInt32(txtLotNo2.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo3.Text = "";
                    txtQty3.Text = "0";
            }
            else if (txtLotNo4.Text != "" && Convert.ToInt32(txtLotNo3.Text) == Convert.ToInt32(txtLotNo4.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo3.Text = "";
                    txtQty3.Text = "0";
            }
            else if (txtLotNo5.Text != "" && Convert.ToInt32(txtLotNo3.Text) == Convert.ToInt32(txtLotNo5.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo3.Text = "";
                    txtQty3.Text = "0";
            }
            else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo3.Text) == Convert.ToInt32(txtLotNo6.Text))
            {          
                     Messagebox("LotNo Already in Use");
                     txtLotNo3.Text = "";
                     txtQty3.Text = "0";
            }
            else
             {
                 var q = (from r in db.LabelDetailsPackings where r.LotNo ==  txtLotNo3.Text select r.Qty).Sum();
                 txtQty3.Text = Convert.ToString(q.Value);
                 if (txtQty1.Text == "")
                 {
                     txtQty1.Text = "0";
                 }
                 if (txtQty2.Text == "")
                 {
                     txtQty2.Text = "0";
                 }
                 if (txtQty3.Text == "")
                 {
                     txtQty3.Text = "0";
                 }
                 if (txtQty4.Text == "")
                 {
                     txtQty4.Text = "0";
                 }
                 if (txtQty5.Text == "")
                 {
                     txtQty5.Text = "0";
                 }
                 if (txtQty6.Text == "")
                 {
                     txtQty6.Text = "0";
                 }
                 txtQtyDummy.Text = Convert.ToString(1200 - (Convert.ToInt32(txtQty1.Text) + Convert.ToInt32(txtQty2.Text) + Convert.ToInt32(txtQty3.Text) + Convert.ToInt32(txtQty4.Text) + Convert.ToInt32(txtQty5.Text) + Convert.ToInt32(txtQty6.Text)));

                 try
                 {
                     var q1 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo3.Text) && r.TestType == "Sterile" select r;
                     stcount[2] = q1.Count();
                 }
                 catch
                 {
                 }
                 try
                 {
                     var q2 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo3.Text) && r.TestType == "Lal" select r;
                     lalcount[2] = q2.Count();
                 }
                 catch
                 {
                 }


                 Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
                 Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);
             }
             

        }
        catch
        {
            stcount[2] = 0;
            lalcount[2] = 0;
            Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
            Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);
        }
    }
    protected void txtLotNo4_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var dup = from r in db.MHSRs where r.LotNo1 == Convert.ToInt32(txtLotNo4.Text) || r.LotNo2 == Convert.ToInt32(txtLotNo4.Text) || r.LotNo3 == Convert.ToInt32(txtLotNo4.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo4.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo4.Text) || r.LotNo5 == Convert.ToInt32(txtLotNo4.Text) || r.LotNo6 == Convert.ToInt32(txtLotNo4.Text) select r;
             if (dup.Count() != 0 )
             {
                 Messagebox("LotNo Already in Use");
                 txtLotNo4.Text = "";
                 txtQty4.Text = "0";
             }
             else if (txtLotNo1.Text != "" && Convert.ToInt32(txtLotNo4.Text) == Convert.ToInt32(txtLotNo1.Text))
             {
                     Messagebox("LotNo Already in Use");
                     txtLotNo4.Text = "";
                     txtQty4.Text = "0";
             }
             else if (txtLotNo2.Text != "" && Convert.ToInt32(txtLotNo4.Text) == Convert.ToInt32(txtLotNo2.Text))
             {
                     Messagebox("LotNo Already in Use");
                     txtLotNo4.Text = "";
                     txtQty4.Text = "0";
             }
             else if (txtLotNo3.Text != "" && Convert.ToInt32(txtLotNo4.Text) == Convert.ToInt32(txtLotNo3.Text))
             {
                     Messagebox("LotNo Already in Use");
                     txtLotNo4.Text = "";
                     txtQty4.Text = "0";
             }
             else if (txtLotNo5.Text != "" && Convert.ToInt32(txtLotNo4.Text) == Convert.ToInt32(txtLotNo5.Text))
             {
                     Messagebox("LotNo Already in Use");
                     txtLotNo4.Text = "";
                     txtQty4.Text = "0";
             }
             else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo4.Text) == Convert.ToInt32(txtLotNo6.Text))
             {
                     Messagebox("LotNo Already in Use");
                     txtLotNo4.Text = "";
                     txtQty4.Text = "0";
             }
             else
             {
                 var q = (from r in db.LabelDetailsPackings where r.LotNo == txtLotNo4.Text select r.Qty).Sum();
                 txtQty4.Text = Convert.ToString(q.Value);
                 if (txtQty1.Text == "")
                 {
                     txtQty1.Text = "0";
                 }
                 if (txtQty2.Text == "")
                 {
                     txtQty2.Text = "0";
                 }
                 if (txtQty3.Text == "")
                 {
                     txtQty3.Text = "0";
                 }
                 if (txtQty4.Text == "")
                 {
                     txtQty4.Text = "0";
                 }
                 if (txtQty5.Text == "")
                 {
                     txtQty5.Text = "0";
                 }
                 if (txtQty6.Text == "")
                 {
                     txtQty6.Text = "0";
                 }
                 txtQtyDummy.Text = Convert.ToString(1200 - (Convert.ToInt32(txtQty1.Text) + Convert.ToInt32(txtQty2.Text) + Convert.ToInt32(txtQty3.Text) + Convert.ToInt32(txtQty4.Text) + Convert.ToInt32(txtQty5.Text) + Convert.ToInt32(txtQty6.Text)));

                 try
                 {
                     var q1 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo4.Text) && r.TestType == "Sterile" select r;
                     stcount[3] = q1.Count();
                 }
                 catch
                 {
                 }
                 try
                 {
                     var q2 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo4.Text) && r.TestType == "Lal" select r;
                     lalcount[3] = q2.Count();
                 }
                 catch
                 {
                 }


                 Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
                 Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);
             }
        }
        catch
        {

            stcount[3] = 0;
            lalcount[3] = 0;
            Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
            Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);

        }
    }
    protected void txtLotNo5_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var dup = from r in db.MHSRs where r.LotNo1 == Convert.ToInt32(txtLotNo5.Text) || r.LotNo2 == Convert.ToInt32(txtLotNo5.Text) || r.LotNo3 == Convert.ToInt32(txtLotNo5.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo5.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo5.Text) || r.LotNo5 == Convert.ToInt32(txtLotNo5.Text) || r.LotNo6 == Convert.ToInt32(txtLotNo5.Text) select r;
            if (dup.Count() != 0 )
            {
                Messagebox("LotNo Already in Use");
                txtLotNo5.Text = "";
                txtQty5.Text = "0";
            }
            else if (txtLotNo1.Text != "" && Convert.ToInt32(txtLotNo5.Text) == Convert.ToInt32(txtLotNo1.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo5.Text = "";
                    txtQty5.Text = "0";
            }
            else if (txtLotNo2.Text != "" && Convert.ToInt32(txtLotNo5.Text) == Convert.ToInt32(txtLotNo2.Text))
            {
                Messagebox("LotNo Already in Use");
                    txtLotNo5.Text = "";
                    txtQty5.Text = "0";
            }
            else if (txtLotNo3.Text != "" && Convert.ToInt32(txtLotNo5.Text) == Convert.ToInt32(txtLotNo3.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo5.Text = "";
                    txtQty5.Text = "0";
            }
            else if (txtLotNo4.Text != "" && Convert.ToInt32(txtLotNo5.Text) == Convert.ToInt32(txtLotNo4.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo5.Text = "";
                    txtQty5.Text = "0";
            }
            else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo5.Text) == Convert.ToInt32(txtLotNo6.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo5.Text = "";
                    txtQty5.Text = "0";
            }
            else
            {
                var q = (from r in db.LabelDetailsPackings where r.LotNo == txtLotNo5.Text select r.Qty).Sum();
                txtQty5.Text = Convert.ToString(q.Value);
                if (txtQty1.Text == "")
                {
                    txtQty1.Text = "0";
                }
                if (txtQty2.Text == "")
                {
                    txtQty2.Text = "0";
                }
                if (txtQty3.Text == "")
                {
                    txtQty3.Text = "0";
                }
                if (txtQty4.Text == "")
                {
                    txtQty4.Text = "0";
                }
                if (txtQty5.Text == "")
                {
                    txtQty5.Text = "0";
                }
                if (txtQty6.Text == "")
                {
                    txtQty6.Text = "0";
                }
                txtQtyDummy.Text = Convert.ToString(1200 - (Convert.ToInt32(txtQty1.Text) + Convert.ToInt32(txtQty2.Text) + Convert.ToInt32(txtQty3.Text) + Convert.ToInt32(txtQty4.Text) + Convert.ToInt32(txtQty5.Text) + Convert.ToInt32(txtQty6.Text)));

                try
                {
                    var q1 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo5.Text) && r.TestType == "Sterile" select r;
                    stcount[4] = q1.Count();
                }
                catch
                {

                }
                try
                {
                    var q2 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo5.Text) && r.TestType == "Lal" select r;
                    lalcount[4] = q2.Count();
                }
                catch
                {
                }


                Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
                Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);
            }
        }
        catch
        {
            stcount[4] = 0;
            lalcount[4] = 0;
            Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
            Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);

        }
    }
    protected void txtLotNo6_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var dup = from r in db.MHSRs where r.LotNo1 == Convert.ToInt32(txtLotNo6.Text) || r.LotNo2 == Convert.ToInt32(txtLotNo6.Text) || r.LotNo3 == Convert.ToInt32(txtLotNo6.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo6.Text) || r.LotNo4 == Convert.ToInt32(txtLotNo6.Text) || r.LotNo5 == Convert.ToInt32(txtLotNo6.Text) || r.LotNo6 == Convert.ToInt32(txtLotNo6.Text) select r;
            if (dup.Count() != 0 )
            {
                Messagebox("LotNo Already in Use");
                txtLotNo6.Text = "";
                txtQty6.Text = "0";
            }
            else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo6.Text) == Convert.ToInt32(txtLotNo1.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo6.Text = "";
                    txtQty6.Text = "0";
            }
            else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo6.Text) == Convert.ToInt32(txtLotNo2.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo6.Text = "";
                    txtQty6.Text = "0";
            }
            else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo6.Text) == Convert.ToInt32(txtLotNo3.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo6.Text = "";
                    txtQty6.Text = "0";
            }
            else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo6.Text) == Convert.ToInt32(txtLotNo4.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo6.Text = "";
                    txtQty6.Text = "0";
            }
            else if (txtLotNo6.Text != "" && Convert.ToInt32(txtLotNo6.Text) == Convert.ToInt32(txtLotNo5.Text))
            {
                    Messagebox("LotNo Already in Use");
                    txtLotNo6.Text = "";
                    txtQty6.Text = "0";
            }
            else 
            {
                var q = (from r in db.LabelDetailsPackings where r.LotNo == txtLotNo6.Text select r.Qty).Sum();
                txtQty6.Text = Convert.ToString(q.Value);
                if (txtQty1.Text == "")
                {
                    txtQty1.Text = "0";
                }
                if (txtQty2.Text == "")
                {
                    txtQty2.Text = "0";
                }
                if (txtQty3.Text == "")
                {
                    txtQty3.Text = "0";
                }
                if (txtQty4.Text == "")
                {
                    txtQty4.Text = "0";
                }
                if (txtQty5.Text == "")
                {
                    txtQty5.Text = "0";
                }
                if (txtQty6.Text == "")
                {
                    txtQty6.Text = "0";
                }
                txtQtyDummy.Text = Convert.ToString(1200 - (Convert.ToInt32(txtQty1.Text) + Convert.ToInt32(txtQty2.Text) + Convert.ToInt32(txtQty3.Text) + Convert.ToInt32(txtQty4.Text) + Convert.ToInt32(txtQty5.Text) + Convert.ToInt32(txtQty6.Text)));

                try
                {
                    var q1 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo6.Text) && r.TestType == "Sterile" select r;
                    stcount[5] = q1.Count();
                }
                catch
                {

                }
                try
                {
                    var q2 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo6.Text) && r.TestType == "Lal" select r;
                    lalcount[5] = q2.Count();
                }
                catch
                {
                }


                Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
                Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);
            }
        }
        catch
        {
            stcount[5] = 0;
            lalcount[5] = 0;
            Session["Sterility"] = Convert.ToString(stcount[0] + stcount[1] + stcount[2] + stcount[3] + stcount[4] + stcount[5]);
            Session["LalTest"] = Convert.ToString(lalcount[0] + lalcount[1] + lalcount[2] + lalcount[3] + lalcount[4] + lalcount[5]);

        }

    }
    protected void txtStartTime_TextChanged(object sender, EventArgs e)
    {
        string val = txtStartTime.Text;
        string[] val1 = val.Split(':');
        int hr = Convert.ToInt32(val1[0]);
        int min = Convert.ToInt32(val1[1]);
        if (hr > 23)
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
        ttt();
        //string t = DateTime.Now.ToString();
        //string[] day = t.Split(' ');
        //ddlDayStart.Text = day[2];

        //string time = txtStartTime.Text;
        //string[] tim = time.Split(':');
        //if (tim[0] == "12" && ddlDayStart.Text == "PM")
        //{
        //    tim[0] = "12";

        //}
        //else if (tim[0] == "12" && ddlDayStart.Text == "AM")
        //{
        //    tim[0] = "0";

        //}
        //else
        //{
        //    if (ddlDayStart.Text == "PM")
        //    {
        //        tim[0] = Convert.ToString(Convert.ToInt32(tim[0]) + 12);
        //    }

        //}
        //string sd = txtDate.Text;
        //string[] sdat = sd.Split('/');

        //StartTime = new DateTime(Convert.ToInt32(sdat[2]), Convert.ToInt32(sdat[1]), Convert.ToInt32(sdat[0]), Convert.ToInt32(tim[0]), Convert.ToInt32(tim[1]), 0);
        //Session["sttim"] = StartTime;
        //DurationCal();
    }
    protected void txtStopTime_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string val = txtStopTime.Text;
            string[] val1 = val.Split(':');
            int hr = Convert.ToInt32(val1[0]);
            int min = Convert.ToInt32(val1[1]);
            if (hr > 23)
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
            string tim = DateTime.Now.ToString();
            string[] day = tim.Split(' ');
            ddlDayStop.Text = day[2];
            ttt();
        }
        catch
        {
        }
        //DurationCal();
    }

    private void ttt()
    {
        try
        {
            string strt = Convert.ToDateTime(txtStartTime.Text).ToString();
            string time1 = Convert.ToDateTime(strt).ToString("HH:mm");

            string strt1 = Convert.ToDateTime(txtStopTime.Text).ToString();
            string time2 = Convert.ToDateTime(strt1).ToString("HH:mm");

            DateTime endTime = Convert.ToDateTime(time2);
            DateTime strtTime = Convert.ToDateTime(time1);
            TimeSpan span = endTime.Subtract(strtTime);
            txtCycleTime.Text = span.ToString();
           
            if (txtCycleTime.Text.StartsWith("-"))
            {
                Messagebox(" Please Check given Time ");
                txtStartTime.Focus();
            }
        }
        catch
        {
        }
    }
    private void DurationCal()
    {
        try
        {

            DateTime StartTime = (DateTime)Session["sttim"];

            string time = txtStopTime.Text;
            string[] tim = time.Split(':');
            if (tim[0] == "12" && ddlDayStop.Text == "PM")
            {
                tim[0] = "12";

            }
            else if (tim[0] == "12" && ddlDayStop.Text == "AM")
            {
                tim[0] = "0";

            }
            else
            {
                if (ddlDayStop.Text == "PM")
                {
                    tim[0] = Convert.ToString(Convert.ToInt32(tim[0]) + 12);
                }

            }
            string sd = txtDate.Text;
            string[] sdat = sd.Split('/');

            DateTime StopTime = new DateTime(Convert.ToInt32(sdat[2]), Convert.ToInt32(sdat[1]), Convert.ToInt32(sdat[0]), Convert.ToInt32(tim[0]), Convert.ToInt32(tim[1]), 0);

            TimeSpan Timespan = StopTime.Subtract(StartTime);

            txtCycleTime.Text = Timespan.Hours.ToString() + ":" + Timespan.Minutes.ToString();
            string minval = Timespan.Minutes.ToString();
            if (minval.StartsWith("-"))
            {
                txtCycleTime.Text = "";
                Messagebox("Please Check the given Date & Time");
            }
        }
        catch
        {
        }
    }

    protected void ddlDayStart_SelectedIndexChanged(object sender, EventArgs e)
    {
        DurationCal();
    }
    protected void ddlDayStop_SelectedIndexChanged(object sender, EventArgs e)
    {
        DurationCal();
    }
    protected void txtCheckedByChemical_TextChanged(object sender, EventArgs e)
    {
        string up = txtCheckedByChemical.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtCheckedByChemical.Text = up.ToUpper();

        }
        else
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtCheckedByChemical.Text = "";
            txtCheckedByChemical.Focus();

        }
    }
    protected void txtCheckedByBio_TextChanged(object sender, EventArgs e )
    {
        string up = txtCheckedByBio.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtCheckedByBio.Text = up.ToUpper();
            
        }
        else
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtCheckedByBio.Text = "";
            txtCheckedByBio.Focus();

        }
    }


    protected void txtBatchNo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtDoorClosedTime_TextChanged(object sender, EventArgs e)
    {

    }
   
}
