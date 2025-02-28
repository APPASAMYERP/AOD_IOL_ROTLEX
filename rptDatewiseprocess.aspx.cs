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

public partial class rptDatewiseprocess : System.Web.UI.Page
{
    SoftLensDataContext db = new SoftLensDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        btnGenerate.Visible = true;
        btnGenerate.Focus();

        lblBatchAllot.Visible = false;
        gvBatchAllot.DataSource = null;
        gvBatchAllot.DataBind();

    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
       
        btnGenerate.Focus();

        lblBatchAllot.Visible = false;
        gvBatchAllot.DataSource = null;
        gvBatchAllot.DataBind();

      }

    protected void btnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Welcome.aspx");
    }
    protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
    {

        if (txtDate.Text == "" && txtDate1.Text == "")
        {
           
            Messagebox("Please Select From and End Date");
            txtDate.Focus();

        }
       
        else
        {

        string s = "Select Date,ModelNo,Power, SUM (AllotedQuantity)As AllotedQuantity from BatchAllot where Date between '" + txtDate.Text + "' and '" + txtDate1.Text + "' Group by ModelNo,Power, Date Order by Date";
        
        SqlDataAdapter Adp = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        Adp.Fill(ds);

        if (ds.Tables[0].Rows.Count != 0)
        {
            lblBatchAllot.Visible = true;
        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }
        gvBatchAllot.DataSource = ds;
        gvBatchAllot.DataBind();


        string s1 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.Blocking.AcceptedQuantity) AS Qty, dbo.Blocking.Date FROM dbo.BatchAllot INNER JOIN dbo.Blocking ON dbo.BatchAllot.Date = dbo.Blocking.Date AND dbo.BatchAllot.LotNo = dbo.Blocking.LotNo WHERE dbo.Blocking.Date Between '" + txtDate.Text + "' And '"+txtDate1.Text+"' And dbo.Blocking.BlockingType ='Ist Cut' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.Blocking.Date Order By dbo.Blocking.Date";
        SqlDataAdapter Adp1 = new SqlDataAdapter(s1, con);
        DataSet ds1 = new DataSet();
        Adp1.Fill(ds1);

        if (ds1.Tables[0].Rows.Count != 0)
        {
            lblBlocking.Visible = true;
        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }
      
        gvBlock.DataSource = ds1;
        gvBlock.DataBind();



        string s2 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.Lathecut.AcceptedQuantity) AS Qty, dbo.Lathecut.Date FROM dbo.BatchAllot INNER JOIN dbo.Lathecut ON dbo.BatchAllot.Date = dbo.Lathecut.Date AND dbo.BatchAllot.LotNo = dbo.Lathecut.LotNo WHERE dbo.Lathecut.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' And dbo.Lathecut.LatheType='Ist Cut' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.Lathecut.Date Order By dbo.Lathecut.Date";

        SqlDataAdapter Adp2 = new SqlDataAdapter(s2, con);
        DataSet ds2 = new DataSet();
        Adp2.Fill(ds2);

        if (ds2.Tables[0].Rows.Count != 0)
        {
            lblLatheCut.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvLatheCut.DataSource = ds2;
        gvLatheCut.DataBind();


        string s3 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.MicroScopicInspCollet.AcceptedQuantity) AS Qty, dbo.MicroScopicInspCollet.Date FROM dbo.BatchAllot INNER JOIN dbo.MicroScopicInspCollet ON dbo.BatchAllot.Date = dbo.MicroScopicInspCollet.Date AND dbo.BatchAllot.LotNo = dbo.MicroScopicInspCollet.LotNo WHERE dbo.MicroScopicInspCollet.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' And dbo.MicroScopicInspCollet.BlockingType='Ist Cut' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.MicroScopicInspCollet.Date Order By dbo.MicroScopicInspCollet.Date ";

        SqlDataAdapter Adp3 = new SqlDataAdapter(s3, con);
        DataSet ds3 = new DataSet();
        Adp3.Fill(ds3);

        if (ds3.Tables[0].Rows.Count != 0)
        {
            lblMicroscopicInspectionCollet.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvMicroScopicWithCollet.DataSource = ds3;
        gvMicroScopicWithCollet.DataBind();


        string s4 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.DeBlocking.AcceptedQuantity) AS Qty, dbo.DeBlocking.Date FROM dbo.BatchAllot INNER JOIN dbo.DeBlocking ON dbo.BatchAllot.Date = dbo.DeBlocking.Date AND dbo.BatchAllot.LotNo = dbo.DeBlocking.LotNo WHERE dbo.DeBlocking.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' And dbo.DeBlocking.BlockingType='Ist Cut' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.DeBlocking.Date Order By dbo.DeBlocking.Date";

        SqlDataAdapter Adp4 = new SqlDataAdapter(s4, con);
        DataSet ds4 = new DataSet();
        Adp4.Fill(ds4);

        if (ds4.Tables[0].Rows.Count != 0)
        {
            lblDeBlocking.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvDeBlock.DataSource = ds4;
        gvDeBlock.DataBind();


        string s5 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.LotResult.AcceptedQuantity) AS AcceptedQty, SUM(dbo.LotResult.RejectedQuantity) AS RejectedQty, dbo.LotResult.Date FROM dbo.BatchAllot INNER JOIN dbo.LotResult ON dbo.BatchAllot.Date = dbo.LotResult.Date AND dbo.BatchAllot.LotNo = dbo.LotResult.LotNo WHERE dbo.LotResult.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.LotResult.Date Order By dbo.LotResult.Date";

        SqlDataAdapter Adp5 = new SqlDataAdapter(s5, con);
        DataSet ds5 = new DataSet();
        Adp5.Fill(ds5);

        if (ds5.Tables[0].Rows.Count != 0)
        {
            lblLotResult.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvLotResult.DataSource = ds5;
        gvLotResult.DataBind();

        string s6 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.Blocking.AcceptedQuantity) AS Qty, dbo.Blocking.Date FROM dbo.BatchAllot INNER JOIN dbo.Blocking ON dbo.BatchAllot.Date = dbo.Blocking.Date AND dbo.BatchAllot.LotNo = dbo.Blocking.LotNo WHERE dbo.Blocking.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' And dbo.Blocking.BlockingType ='IInd Cut' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.Blocking.Date Order By dbo.Blocking.Date";
        SqlDataAdapter Adp6 = new SqlDataAdapter(s6, con);
        DataSet ds6 = new DataSet();
        Adp6.Fill(ds6);

        if (ds6.Tables[0].Rows.Count != 0)
        {
            lblBlocking2.Visible = true;
        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvBlock2cut.DataSource = ds6;
        gvBlock2cut.DataBind();

        string s7 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.Lathecut.AcceptedQuantity) AS Qty, dbo.Lathecut.Date FROM dbo.BatchAllot INNER JOIN dbo.Lathecut ON dbo.BatchAllot.Date = dbo.Lathecut.Date AND dbo.BatchAllot.LotNo = dbo.Lathecut.LotNo WHERE dbo.Lathecut.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' And dbo.Lathecut.LatheType='IInd Cut' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.Lathecut.Date Order By dbo.Lathecut.Date";

        SqlDataAdapter Adp7 = new SqlDataAdapter(s7, con);
        DataSet ds7 = new DataSet();
        Adp7.Fill(ds7);

        if (ds7.Tables[0].Rows.Count != 0)
        {
            lblLatheCut2.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvLathe2ndCut.DataSource = ds7;
        gvLathe2ndCut.DataBind();

        string s8 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.MicroScopicInspCollet.AcceptedQuantity) AS AcceptedQty, SUM(dbo.MicroScopicInspCollet.RejectedQuantity) AS RejectedQty, dbo.MicroScopicInspCollet.Date FROM dbo.BatchAllot INNER JOIN dbo.MicroScopicInspCollet ON dbo.BatchAllot.Date = dbo.MicroScopicInspCollet.Date AND dbo.BatchAllot.LotNo = dbo.MicroScopicInspCollet.LotNo WHERE dbo.MicroScopicInspCollet.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' And dbo.MicroScopicInspCollet.BlockingType='IInd Cut' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.MicroScopicInspCollet.Date Order By dbo.MicroScopicInspCollet.Date";

        SqlDataAdapter Adp8 = new SqlDataAdapter(s8, con);
        DataSet ds8 = new DataSet();
        Adp8.Fill(ds8);

        if (ds8.Tables[0].Rows.Count != 0)
        {
            lblMicroscopicInspectionCollet2ndCut.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvMicroScopicWithCollet2ndCut.DataSource = ds8;
        gvMicroScopicWithCollet2ndCut.DataBind();

        string s9 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.Milling.AcceptedQuantity) AS AcceptedQty, SUM(dbo.Milling.RejectedQuantity) AS RejectedQty, dbo.Milling.Date FROM dbo.BatchAllot INNER JOIN dbo.Milling ON dbo.BatchAllot.Date = dbo.Milling.Date AND dbo.BatchAllot.LotNo = dbo.Milling.LotNo WHERE dbo.Milling.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.Milling.Date Order By dbo.Milling.Date";

        SqlDataAdapter Adp9 = new SqlDataAdapter(s9, con);
        DataSet ds9 = new DataSet();
        Adp9.Fill(ds9);

        if (ds9.Tables[0].Rows.Count != 0)
        {
            lblMilling.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvMilling.DataSource = ds9;
        gvMilling.DataBind();



        string s10 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.DeBlocking.AcceptedQuantity) AS AcceptedQty, SUM(dbo.DeBlocking.RejectedQuantity) AS RejectedQty, dbo.DeBlocking.Date FROM dbo.BatchAllot INNER JOIN dbo.DeBlocking ON dbo.BatchAllot.Date = dbo.DeBlocking.Date AND dbo.BatchAllot.LotNo = dbo.DeBlocking.LotNo WHERE dbo.DeBlocking.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' And dbo.DeBlocking.BlockingType='IInd Cut' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.DeBlocking.Date Order By dbo.DeBlocking.Date";

        SqlDataAdapter Adp10 = new SqlDataAdapter(s10, con);
        DataSet ds10 = new DataSet();
        Adp10.Fill(ds10);

        if (ds10.Tables[0].Rows.Count != 0)
        {
            lblDeBlocking2.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvDeBlock2.DataSource = ds10;
        gvDeBlock2.DataBind();


        string s11 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.Hydration.Acceptedqty) AS AcceptedQty, SUM(dbo.Hydration.Rejectedqty) AS RejectedQty, dbo.Hydration.StartDate As Date FROM dbo.BatchAllot INNER JOIN dbo.Hydration ON dbo.BatchAllot.Date = dbo.Hydration.StartDate AND dbo.BatchAllot.LotNo = dbo.Hydration.LotNo WHERE dbo.Hydration.StartDate Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date, dbo.Hydration.StartDate Order By dbo.Hydration.StartDate";

        SqlDataAdapter Adp11 = new SqlDataAdapter(s11, con);
        DataSet ds11 = new DataSet();
        Adp11.Fill(ds11);

        if (ds11.Tables[0].Rows.Count != 0)
        {
            lblHydBefHyd.Visible = true;

        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }
        
        gvHydBefTumb.DataSource = ds11;
        gvHydBefTumb.DataBind();

        string s12 = "SELECT dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, SUM(dbo.MillingCleanedLens.InspectedQuantity) AS InspecQty, SUM(dbo.MillingCleanedLens.AcceptedQuantity) AS AccQty,SUM(dbo.MillingCleanedLens.RejectedQty) AS RejQty,SUM(dbo.MillingCleanedLens.ESC) AS ESC,SUM(dbo.MillingCleanedLens.SCR) AS SCR,SUM(dbo.MillingCleanedLens.LB) AS LB,SUM(dbo.MillingCleanedLens.CHIP) AS CHIP,SUM(dbo.MillingCleanedLens.BURR) AS BURR,SUM(dbo.MillingCleanedLens.Thick) AS Thick,SUM(dbo.MillingCleanedLens.TotalRejQty) AS TotalRejQty,  dbo.BatchAllot.Date FROM dbo.BatchAllot INNER JOIN dbo.MillingCleanedLens ON  dbo.BatchAllot.LotNo = dbo.MillingCleanedLens.LotNo WHERE dbo.MillingCleanedLens.Date Between '" + txtDate.Text + "' And '" + txtDate1.Text + "' GROUP BY dbo.BatchAllot.ModelNo, dbo.BatchAllot.Power, dbo.BatchAllot.Date Order By dbo.BatchAllot.Date";

        SqlDataAdapter Adp12 = new SqlDataAdapter(s12, con);
        DataSet ds12 = new DataSet();
        Adp12.Fill(ds12);

        if (ds12.Tables[0].Rows.Count != 0)
        {
            lblMICleanedLens.Visible = true;
            
        }
        else
        {
            Messagebox("Process Might not be Completed on This Date");
            txtDate.Focus();

        }

        gvMICleanedLens.DataSource = ds12;
        gvMICleanedLens.DataBind();


    }
   
    
    }





}
