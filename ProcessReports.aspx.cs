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
using System.Data.SqlClient;

public partial class ProcessReports : System.Web.UI.Page
{
    SoftLensDataContext db = new SoftLensDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    } 
    
    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        btnGenerate.Visible = true;
        btnGenerate.Focus();

        lblBatchAllot.Visible = false;
        gvBatchAllot.DataSource = null;
        gvBatchAllot.DataBind();

        lblBlocking.Visible = false;
        gvBlock.DataSource = null;
        gvBlock.DataBind();

        lblLatheCut.Visible = false;
        gvLatheCut.DataSource = null;
        gvLatheCut.DataBind();

        //lblMicroscopicInspection.Visible = false;
        //gvMicroscopic.DataSource = null;
        //gvMicroscopic.DataBind();

        //lblLensMeasurement.Visible = false;
        //gvLensMeasurement.DataSource = null;
        //gvLensMeasurement.DataBind();

        //lblMicroscopicInspectionCollet.Visible = false;
        //gvMicroScopicWithCollet.DataSource = null;
        //gvMicroScopicWithCollet.DataBind();

        //lblDeBlocking.Visible = false;
        //gvDeBlock.DataSource = null;
        //gvDeBlock.DataBind();

        lblLotResult.Visible = false;
        gvLotResult.DataSource = null;
        gvLotResult.DataBind();
        // 2nd Cut//
        lblBlocking2.Visible = false;
        gvBlock2cut.DataSource = null;
        gvBlock2cut.DataBind();

        lblLatheCut2.Visible = false;
        gvLathe2ndCut.DataSource = null;
        gvLathe2ndCut.DataBind();

        //lblMicroscopicInspection2.Visible = false;
        //gvMicroscopic2ndCut.DataSource = null;
        //gvMicroscopic2ndCut.DataBind();

        lblMicroscopicHapThick.Visible = false;
        gvHaptic.DataSource = null;
        gvHaptic.DataBind();

        //lblPowerInspection.Visible = false;
        //gvPowerInspec.DataSource = null;
        //gvPowerInspec.DataBind();

        //lblMicroscopicInspectionCollet2ndCut.Visible = false;
        //gvMicroScopicWithCollet2ndCut.DataSource = null;
        //gvMicroScopicWithCollet2ndCut.DataBind();

        lblMilling.Visible = false;
        gvMilling.DataSource = null;
        gvMilling.DataBind();

        //lblMicroscopicInspectionMiling.Visible = false;
        //gvMicroscopicMilling.DataSource = null;
        //gvMicroscopicMilling.DataBind();

        lblDeBlocking2.Visible = false;
        gvDeBlock2.DataSource = null;
        gvDeBlock2.DataBind();

        //lblHydBefHyd.Visible = false;
        //gvHydBefTumb.DataSource = null;
        //gvHydBefTumb.DataBind();

        lblMICleanedLens.Visible = false;
        gvMICleanedLens.DataSource = null;
        gvMICleanedLens.DataBind();

    }
    
    protected void btnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Welcome.aspx");
    }
    protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
    {
        var qbatch1 = from row in db.BatchAllots where row.LotNo == txtLotNo.Text select row;
        if (qbatch1.Count() != 0)
        {
            lblBatchAllot.Visible = true;
            gvBatchAllot.DataSource = qbatch1;
            gvBatchAllot.DataBind();
        }
        else
        {
            Messagebox("Process Might not be Completed or Lot No doesnot Exist");
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }

        var qblock1 = from row in db.Blockings where row.LotNo == txtLotNo.Text && row.BlockingType == "Ist Cut" select row;
        if (qblock1.Count() != 0)
        {
            lblBlocking.Visible = true;
            gvBlock.DataSource = qblock1;
            gvBlock.DataBind();
        }

        var qlath1 = from row in db.Lathecuts where row.LotNo == txtLotNo.Text && row.LatheType == "Ist Cut" select row;
        if (qlath1.Count() != 0)
        {
            lblLatheCut.Visible = true;
            gvLatheCut.DataSource = qlath1;
            gvLatheCut.DataBind();
        }
        
        var qMilling = from row in db.Millings where row.LotNo == txtLotNo.Text select row;
        if (qMilling.Count() != 0)
        {
            lblMilling.Visible = true;
            gvMilling.DataSource = qMilling;
            gvMilling.DataBind();
        }

        var qblock2 = from row in db.Blockings where row.LotNo == txtLotNo.Text && row.BlockingType == "IInd Cut" select row;
        if (qblock2.Count() != 0)
        {
            lblBlocking2.Visible = true;
            gvBlock2cut.DataSource = qblock2;
            gvBlock2cut.DataBind();
        }

        var qlath2 = from row in db.Lathecuts where row.LotNo == txtLotNo.Text && row.LatheType == "IInd Cut" select row;
        if (qlath2.Count() != 0)
        {
            lblLatheCut2.Visible = true;
            gvLathe2ndCut.DataSource = qlath2;
            gvLathe2ndCut.DataBind();
        }
        
        var qDebloc2 = from row in db.DeBlockings where row.LotNo == txtLotNo.Text && row.BlockingType == "IInd Cut" select row;
        if (qDebloc2.Count() != 0)
        {
            lblDeBlocking2.Visible = true;
            gvDeBlock2.DataSource = qDebloc2;
            gvDeBlock2.DataBind();
        }

        var qHapThick = from f in db.HapticSamples where f.LotNo == txtLotNo.Text select f;
        if (qHapThick.Count() != 0)
        {
            lblMicroscopicHapThick.Visible = true;
            gvHaptic.DataSource = qHapThick;
            gvHaptic.DataBind();
        }

        var qMICleanLens = from a in db.MillingCleanedLens where a.LotNo == txtLotNo.Text select a;
        if (qMICleanLens.Count() != 0)
        {
            lblMICleanedLens.Visible = true;
            gvMICleanedLens.DataSource = qMICleanLens;
            gvMICleanedLens.DataBind();
        }

        //var qMicro1 = from f in db.MicroscopicInspections where f.LotNo == txtLotNo.Text && f.BlockingType == "Ist Cut" select f;
        //if (qMicro1.Count() != 0)
        //{
        //    lblMicroscopicInspection.Visible = true;
        //    gvMicroscopic.DataSource = qMicro1;
        //    gvMicroscopic.DataBind();
        //}

        var qResolution = from row in db.HapticPowerTables where row.LotNo == txtLotNo.Text select row;
        if (qResolution.Count() != 0)
        {
            lblResolution.Visible = true;
            gvResolution.DataSource = qResolution;
            gvResolution.DataBind();
        }

        //var qMicroCollet2 = from row in db.MicroScopicInspCollets where row.LotNo == txtLotNo.Text && row.BlockingType == "IInd Cut" select row;
        //if (qMicroCollet2.Count() != 0)
        //{
        //    lblMicroscopicInspectionCollet2ndCut.Visible = true;
        //    gvMicroScopicWithCollet2ndCut.DataSource = qMicroCollet2;
        //    gvMicroScopicWithCollet2ndCut.DataBind();
        //}

        var qlotRes = from row in db.LotResults where row.LotNo == txtLotNo.Text select row;
        if (qlotRes.Count() != 0)
        {
            lblLotResult.Visible = true;
            gvLotResult.DataSource = qlotRes;
            gvLotResult.DataBind();
        }

        //++=+=++  Second Cut +==+==+ //

        //var qLensMeas = from row in db.LensMeasurements where row.LotNo == txtLotNo.Text select row;
        //if (qLensMeas.Count() != 0)
        //{
        //    lblLensMeasurement.Visible = true;
        //    gvLensMeasurement.DataSource = qLensMeas;
        //    gvLensMeasurement.DataBind();
        //}

        //var qMicroCollet1 = from row in db.MicroScopicInspCollets where row.LotNo == txtLotNo.Text && row.BlockingType == "Ist Cut" select row;
        //if (qMicroCollet1.Count() != 0)
        //{
        //    lblMicroscopicInspectionCollet.Visible = true;
        //    gvMicroScopicWithCollet.DataSource = qMicroCollet1;
        //    gvMicroScopicWithCollet.DataBind();
        //}

        //var qDebloc1 = from row in db.DeBlockings where row.LotNo == txtLotNo.Text && row.BlockingType == "Ist Cut" select row;
        //if (qDebloc1.Count() != 0)
        //{
        //    lblDeBlocking.Visible = true;
        //    gvDeBlock.DataSource = qDebloc1;
        //    gvDeBlock.DataBind();
        //}

        //var qMicro2 = from f in db.MicroscopicInspections where f.LotNo == txtLotNo.Text && f.BlockingType == "IInd Cut" select f;
        //if (qMicro2.Count() != 0)
        //{
        //    lblMicroscopicInspection2.Visible = true;
        //    gvMicroscopic2ndCut.DataSource = qMicro2;
        //    gvMicroscopic2ndCut.DataBind();
        //}

        //var qPowerInspec = from f in db.Powerinspections where f.LotNo == txtLotNo.Text select f;
        //if (qPowerInspec.Count() != 0)
        //{
        //    lblPowerInspection.Visible = true;
        //    gvPowerInspec.DataSource = qPowerInspec;
        //    gvPowerInspec.DataBind();
        //}

        //var qMicro2Milling = from f in db.MicroscopicInspections where f.LotNo == txtLotNo.Text && f.BlockingType == "Milling" select f;
        //if (qMicro2Milling.Count() != 0)
        //{
        //    lblMicroscopicInspectionMiling.Visible = true;
        //    gvMicroscopicMilling.DataSource = qMicro2Milling;
        //    gvMicroscopicMilling.DataBind();
        //}

        //var qHydBefTum = from a in db.Hydrations where a.LotNo == txtLotNo.Text select a;
        //if (qHydBefTum.Count() != 0)
        //{
        //    lblHydBefHyd.Visible = true;
        //    gvHydBefTumb.DataSource = qHydBefTum;
        //    gvHydBefTumb.DataBind();
        //}

        btnGenerate.Visible = false;
    }
}
