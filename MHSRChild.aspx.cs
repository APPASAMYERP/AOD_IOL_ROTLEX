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

public partial class MHSRChild : System.Web.UI.Page
{
    
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            txtDate.Text=DateTime.Now.ToString("dd/MM/yyyy");
        }
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

    private void Clear()
    {
        txtDateMHSR.Text = "";
        txtBatchNoMHSR.Text = "";
        txtParticulars.Text = "";
        txtDoorClosedTime.Text = "";
        txtSteamOpenedTime.Text = "";
        txtVentClosedTime.Text = "";
        txtPressAttainedTime.Text = "";
        TxtPress.Text = "";
        txtTemp.Text = "";
        txtMaintainedUpto.Text = "";
        txtVentOpenedTime.Text = "";
        txtDoorOpenedTime.Text = "";
        txtOperator.Text = "";
        txtChemist.Text = "";
        txtSterilityTest.Text = "";
        txtLalTest.Text = "";
        txtOtherTest.Text = "";
        ddlResult.Text = "Accepted";
        txtRecordRef.Text = "";
        txtCheckedBySterility.Text = "";
        ddlResultCycle.Text = "Accepted";
        txtQQualityControl.Text = "";
        txtProductRelease.Text = "";
    }

    protected void txtMHSRNo_TextChanged(object sender, EventArgs e)
    {
        Clear();
        Shift();
        txtDateMHSR.Text = DateTime.Now.ToString("dd/MM/yyyy");
        try
        {
            var query = from r in db.MHSRnews where r.MHSR == txtMHSRNo.Text select r;
            if (query.Count() > 0)
            {
                txtMHSRNo.Text = query.Single().MHSR;
                txtDate.Text = query.Single().Date.Value.ToString("dd/MM/yyyy");
                ddlShift.Text = query.Single().Shift;
                txtDateMHSR.Text = query.Single().DateMHSR.Value.ToString("dd/MM/yyyy");
                txtBatchNoMHSR.Text = query.Single().BNoMHSR;
                txtParticulars.Text = query.Single().Particulars;
                txtDoorClosedTime.Text = query.Single().DoorClosedTime;
                txtSteamOpenedTime.Text = query.Single().SteamOpenedTime;
                txtVentClosedTime.Text = query.Single().VentClosedTime;
                txtPressAttainedTime.Text = query.Single().PressAttainedTime;
                TxtPress.Text = query.Single().Press;
                txtTemp.Text = query.Single().Temp;
                txtMaintainedUpto.Text = query.Single().MaintainedUpto;
                txtVentOpenedTime.Text = query.Single().VentOpenedTime;
                txtDoorOpenedTime.Text = query.Single().DoorOpenedTime;
                txtOperator.Text = query.Single().Operator;
                txtChemist.Text = query.Single().Chemist;
                txtSterilityTest.Text = query.Single().SterilityTest;
                txtLalTest.Text = query.Single().LalTest;
                txtOtherTest.Text = query.Single().OtherTest;
                ddlResult.Text = query.Single().ResultSterility;
                txtRecordRef.Text = query.Single().RecordRef;
                txtCheckedBySterility.Text = query.Single().CheckedBySterility;
                ddlResultCycle.Text = query.Single().ResultCycle;
                txtQQualityControl.Text = query.Single().QuqlityControlCycle;
                txtProductRelease.Text = query.Single().ProductRelease;
                btnUpdate.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                var query1 = from r in db.MHSRs where r.MHSRNo == txtMHSRNo.Text select r;
                if(query1.Count()>0)
                {
                    txtBatchNoMHSR.Text=query1.Single().BatchNo.ToString();


                    ArrayList Lotno = new ArrayList();
                    Lotno.Add(query1.Single().LotNo1.ToString());
                    Lotno.Add(query1.Single().LotNo2.ToString());
                    Lotno.Add(query1.Single().LotNo3.ToString());
                    Lotno.Add(query1.Single().LotNo4.ToString());
                    Lotno.Add(query1.Single().LotNo5.ToString());
                    Lotno.Add(query1.Single().LotNo6.ToString());
                    int stcount = 0;
                    int lalcount = 0;

                    for (int i = 0; i < 6; i++)
                    {
                        try
                        {
                            var q1 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(Lotno[i].ToString()) && r.TestType == "Sterile" select r;
                            stcount = stcount + q1.Count();
                        }
                        catch
                        {

                        }
                        try
                        {
                            var q2 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(Lotno[i].ToString()) && r.TestType == "Lal" select r;
                            lalcount = lalcount + q2.Count();
                        }
                        catch
                        {
                        }
                    }
                    txtSterilityTest.Text = stcount.ToString();
                    txtLalTest.Text = lalcount.ToString();
         

                    btnSave.Visible = true;
                    btnClear.Visible = true;
                }
                else
                {
                    Messagebox("MHSR NO does not Exit");
                    txtMHSRNo.Text="";
                    txtMHSRNo.Focus();
                }
            }
        }
        catch
        {
            var query1 = from r in db.MHSRs where r.MHSRNo == txtMHSRNo.Text select r;
            if (query1.Count() > 0)
            {
                txtBatchNoMHSR.Text = query1.Single().BatchNo.ToString();
                

                ArrayList Lotno = new ArrayList();
                Lotno.Add(query1.Single().LotNo1.ToString());
                Lotno.Add(query1.Single().LotNo2.ToString());
                Lotno.Add(query1.Single().LotNo3.ToString());
                Lotno.Add(query1.Single().LotNo4.ToString());
                Lotno.Add(query1.Single().LotNo5.ToString());
                Lotno.Add(query1.Single().LotNo6.ToString());
                int stcount = 0;
               int lalcount = 0;

                for (int i = 0; i < 6; i++)
                {
                    try
                    {
                        var q1 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(Lotno[i].ToString()) && r.TestType == "Sterile" select r;
                        stcount = stcount+q1.Count();
                    }
                    catch
                    {

                    }
                    try
                    {
                        var q2 = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(Lotno[i].ToString()) && r.TestType == "Lal" select r;
                        lalcount = lalcount+q2.Count();
                    }
                    catch
                    {
                    }
                }
                txtSterilityTest.Text = stcount.ToString();
                txtLalTest.Text = lalcount.ToString();
            }
            else
            {
                Messagebox("MHSR NO does not Exit");
                txtMHSRNo.Text = "";
                txtMHSRNo.Focus();
            }
            btnSave.Visible = true;
            btnClear.Visible = true;
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        MHSRnew mhsrtable = new MHSRnew()
            {
                MHSR =txtMHSRNo.Text,
                Date=Convert.ToDateTime(txtDate.Text,provider), 
                Shift = ddlShift.Text,
                BNoMHSR = txtBatchNoMHSR.Text,
                CheckedBySterility = txtCheckedBySterility.Text,
                Chemist = txtChemist.Text,
                DateMHSR = Convert.ToDateTime(txtDateMHSR.Text, provider),
                DoorClosedTime = txtDoorClosedTime.Text,
                DoorOpenedTime = txtDoorOpenedTime.Text,
                LalTest = txtLalTest.Text,
                MaintainedUpto = txtMaintainedUpto.Text,
                Operator = txtOperator.Text,
                OtherTest = txtOtherTest.Text,
                Particulars = txtParticulars.Text,
                Press = TxtPress.Text,
                PressAttainedTime = txtPressAttainedTime.Text,
                ProductRelease = txtProductRelease.Text,
                QuqlityControlCycle = txtQQualityControl.Text,
                RecordRef = txtRecordRef.Text,
                ResultCycle = ddlResultCycle.Text,
                ResultSterility = ddlResult.Text,
                SteamOpenedTime = txtSteamOpenedTime.Text,
                SterilityTest = txtSterilityTest.Text,
                Temp = txtTemp.Text,
                VentClosedTime = txtVentClosedTime.Text,
                VentOpenedTime = txtVentOpenedTime.Text,
            };
        db.MHSRnews.InsertOnSubmit(mhsrtable);
        db.SubmitChanges();
        Messagebox("Saved Successfully");
        Clear();
        txtMHSRNo.Text = "";
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (txtProductRelease.Text == "")
        {
            Messagebox("Please Enter Product release No");
        }
        else
        {
            var query = from r in db.MHSRs where r.MHSRNo == txtMHSRNo.Text select r;
            query.Single().Date=Convert.ToDateTime(txtDate.Text,provider);
            query.Single().Shift = ddlShift.Text;
            query.Single().DateMHSR = Convert.ToDateTime(txtDateMHSR.Text, provider);
            query.Single().BNoMHSR = txtBatchNoMHSR.Text;
            query.Single().Particulars = txtParticulars.Text;
            query.Single().DoorClosedTime = txtDoorClosedTime.Text;
            query.Single().SteamOpenedTime = txtSteamOpenedTime.Text;
            query.Single().VentClosedTime = txtVentClosedTime.Text;
            query.Single().PressAttainedTime = txtPressAttainedTime.Text;
            query.Single().Press = TxtPress.Text;
            query.Single().Temp = txtTemp.Text;
            query.Single().MaintainedUpto = txtMaintainedUpto.Text;
            query.Single().VentOpenedTime = txtVentOpenedTime.Text;
            query.Single().DoorOpenedTime = txtDoorOpenedTime.Text;
            query.Single().Operator = txtOperator.Text;
            query.Single().Chemist = txtChemist.Text;
            query.Single().SterilityTest = txtSterilityTest.Text;
            query.Single().LalTest = txtLalTest.Text;
            query.Single().OtherTest = txtOtherTest.Text;
            query.Single().ResultSterility = ddlResult.Text;
            query.Single().RecordRef = txtRecordRef.Text;
            query.Single().CheckedBySterility = txtCheckedBySterility.Text;
            query.Single().ResultCycle = ddlResultCycle.Text;
            query.Single().QuqlityControlCycle = txtQQualityControl.Text;
            query.Single().ProductRelease = txtProductRelease.Text;
            db.SubmitChanges();
            Messagebox("Updated Successfully");
            Clear();
            txtMHSRNo.Text = "";
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        btnUpdate.Visible = false;
        btnClear.Visible = false;
        btnClear.Visible = false;
    }

    protected void txtCheckedBySterility_TextChanged(object sender, EventArgs e)
    {
        string up = txtCheckedBySterility.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtCheckedBySterility.Text = up.ToUpper();

        }
        else
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtCheckedBySterility.Text = "";
            txtCheckedBySterility.Focus();
        }
    }

    }

