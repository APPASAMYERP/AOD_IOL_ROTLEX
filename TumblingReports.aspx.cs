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

public partial class TumblingReports : System.Web.UI.Page
{
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "');", true);
    }

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        btnGenerate.Visible = true;
        btnGenerate.Focus();
        
        string t = txtTumblingLotNo.Text;
        //string ran = (range >= 48 && range <= 57);
        //if (t.Substring(1, 7) >= "47" && t.Substring(1, 7) <= "58")
        //{
            txtTumblingLotNo.Text = t.ToUpper();
        //}
        //else
        //{
        //    MessageBox("Invalid Format");
        //}
        
        lblLenspreptumb.Visible = false;
        gvLenPrepTumb.DataSource = null;
        gvLenPrepTumb.DataBind();

        lblHydAftTumb.Visible = false;
        gvHydAfrTumb.DataSource = null;
        gvHydAfrTumb.DataBind();

        lblSIforTumb.Visible = false;
        gvSiTumb.DataSource = null;
        gvSiTumb.DataBind();

        lblLensWiping.Visible = false;
        gvLensWiping.DataSource = null;
        gvLensWiping.DataBind();

        lblMIFqiLens.Visible = false;
        gvMi4lens.DataSource = null;
        gvMi4lens.DataBind();

        lblSealingCup.Visible = false;
        gvSealingCup.DataSource = null;
        gvSealingCup.DataBind();

        lblPowerInspec.Visible = false;
        gvPowerinspec.DataSource = null;
        gvPowerinspec.DataBind();

        lblSealingPouch.Visible = false;
        gvSealingPouch.DataSource = null;
        gvSealingPouch.DataBind();

        lbLabelDetail.Visible = false;
        gvlabeldetail.DataSource = null;
        gvlabeldetail.DataBind();

        lblPackingreport.Visible = false;
        gvPackingReport.DataSource = null;
        gvPackingReport.DataBind();

    }   


     protected void  btnGenerate_Click1(object sender, ImageClickEventArgs e)
    {
     btnGenerate.Visible = false;

    var qLensPreptum = from row in db.Tumblings where row.TumblingLotNo == txtTumblingLotNo.Text select row;
    if (qLensPreptum.Count() != 0)
    {
        lblLenspreptumb.Visible = true;
       
        gvLenPrepTumb.DataSource = qLensPreptum;

        gvLenPrepTumb.DataBind();

        var qLensPrepTumChild = (from row in db.TumblingChilds
                                 where row.TumblingNo == txtTumblingLotNo.Text
                                 select new
                                 {
                                     row.LotNo,
                                     row.Power,
                                     row.Quantity
                                 }).Distinct();
        gvLenPrepTumbChild.DataSource = qLensPrepTumChild;
        gvLenPrepTumbChild.DataBind();

        var qhydAftTumb = from a in db.HydrationAftTumblings where a.TumblingLotNo == txtTumblingLotNo.Text select a;
        if (qhydAftTumb.Count() != 0)
        {
            lblHydAftTumb.Visible = true;
            gvHydAfrTumb.DataSource = qhydAftTumb;
            gvHydAfrTumb.DataBind();

        }
        var qSiTumb = from a in db.SI_Tumblings where a.TumblingNo == txtTumblingLotNo.Text select a;
        if (qSiTumb.Count() != 0)
        {
            lblSIforTumb.Visible = true;
            gvSiTumb.DataSource = qSiTumb;
            gvSiTumb.DataBind();
        }
        //var qlensWiping = from row in db.LensWipings where row.TumblingLotNo == txtTumblingLotNo.Text select row;
        //if (qlensWiping.Count() != 0)
        //{
        //    lblLensWiping.Visible = true;
        //    gvLensWiping.DataSource = qlensWiping;
        //    gvLensWiping.DataBind();
        //}

        var qMi4Lens = from row3 in db.MIinFQIs where row3.GlassyNo == txtTumblingLotNo.Text select row3;
        if (qMi4Lens.Count() != 0)
        {
            lblMIFqiLens.Visible = true;
            gvMi4lens.DataSource = qMi4Lens;
            gvMi4lens.DataBind();
        }

        var qsealingCup = from row in db.SealingCupandPouches where row.TumblingLotNo == txtTumblingLotNo.Text && row.SealingProcess == "SEALING CUP" select row;
        if (qsealingCup.Count() != 0)
        {
            lblSealingCup.Visible = true;
            gvSealingCup.DataSource = qsealingCup;
            gvSealingCup.DataBind();
        }

        var qpowerInspec = from f in db.Inprocess_Power_Inspections where f.TumblingLotNo1 == txtTumblingLotNo.Text select f;
        if (qpowerInspec.Count() != 0)
        {
            lblPowerInspec.Visible = true;
            gvPowerinspec.DataSource = qpowerInspec;
            gvPowerinspec.DataBind();
        }

        var qsealingPouch = from row in db.SealingCupandPouches where row.TumblingLotNo == txtTumblingLotNo.Text && row.SealingProcess == "SEALING POUCH" select row;
        if (qsealingPouch.Count() != 0)
        {
            lblSealingPouch.Visible = true;
            gvSealingPouch.DataSource = qsealingPouch;
            gvSealingPouch.DataBind();
        }

        var qlabeldetails = from row in db.LabelDetailsPackings where row.GlassyNo == txtTumblingLotNo.Text select row;
        {
            lbLabelDetail.Visible = true;
            gvlabeldetail.DataSource = qlabeldetails;
            gvlabeldetail.DataBind();
        }

        var qPackingreport = from row in db.PackingReports where row.TumblingLotNo == txtTumblingLotNo.Text select row;
        if (qPackingreport.Count() != 0)
        {
            lblPackingreport.Visible = true;
            gvPackingReport.DataSource = qPackingreport;
            gvPackingReport.DataBind();
        }
    }
    else
    {
        lbLabelDetail.Visible = false;
        MessageBox("Process Might not be Completed or Tumbling No doesnot Exist");
        txtTumblingLotNo.Focus();

    }

}
     protected void btnHome_Click(object sender, ImageClickEventArgs e)
     {
         Response.Redirect("Welcome.aspx");
     }
}
