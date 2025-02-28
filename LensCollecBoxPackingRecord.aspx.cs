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
using System.Web.Services;
using System.Data.SqlClient;

public partial class LensCollecBoxPackingRecord : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
     DataTable dt;
    [WebMethod]
    public static void Close()
    {
       
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnlRejQDet.Visible = false;
        }
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    protected void txtBPLno_TextChanged(object sender, EventArgs e)
    {
        clear();
        sclear();
        
        gvBoxInspection.DataSource = null;
        gvBoxInspection.DataBind();
        var vis = from a in db.LenscollectBoxPackRecords where a.BPLno==txtBPLno.Text select a;
        if (vis.Count() == 0)
        {
            var collec = from a in db.BoxPackgcollecLists where a.BplNo == txtBPLno.Text select a;
            if (collec.Count() != 0)
            {
                gvBoxInspection.Columns[0].Visible = false;
                txtModel.Text = collec.Single().Model.ToString();
                txtPower.Text = collec.Single().Power.ToString();
                var brnd = from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) select a.Brand;
                txtBrand.Text = brnd.Single().ToString();
                var qty = from a in db.BoxPackgcollecLists where a.BplNo == txtBPLno.Text select a.CollecQty;
                txtRecQty.Text = qty.Single().ToString();
                btnSave.Visible = true;
            }
            else
            {
                Messagebox("BPL No doesn't Exist");
                txtBPLno.Text = "";
            }
        }
        else
        {
            gvBoxInspection.Columns[0].Visible = true;
            txtModel.Text = vis.Single().Model.Value.ToString();
            txtPower.Text = vis.Single().Power.ToString();
            txtBrand.Text = vis.Single().Brand.ToString();
            txtAccQty.Text = vis.Single().QtyAccepted.ToString();
            txtRecQty.Text = vis.Single().QtyReceived.ToString();
            //txtRejQty.Text = vis.Single().QtyRejected.ToString();
            DateTime dte = vis.Single().Date.Value;
            txtDate.Text = dte.ToString("dd/MM/yyyy");

            txtInspecBy.Text = vis.Single().InspectedBy.ToString();
            txtSnoRejLens.Text = vis.Single().SnoRejLens.ToString();
            txtShrkPackBy.Text = vis.Single().shrkPacBy.ToString();
            txtBoxPrepBy.Text = vis.Single().Boxprepby.ToString();
            txtLabelprintedBuy.Text = vis.Single().LPrintedBy.ToString();
            txtPnOlabelby.Text = vis.Single().shrkPacBy.ToString();
            txtRmks.Text = vis.Single().Rmks.ToString();
             var Lenrej = from a in db.LensBoxPackingRejections where a.BplNo == Convert.ToInt32(txtBPLno.Text) select a;
             txtRejQty.Text = vis.Single().QtyRejected.ToString();
             
            DataSet ds = new DataSet();
             SqlCommand cmd = db.GetCommand(Lenrej.AsQueryable()) as SqlCommand;
             SqlDataAdapter adp = new SqlDataAdapter(cmd);
             adp.Fill(ds);
             DataTable dtPO = new DataTable();
             dtPO = ds.Tables[0];

             gvBoxInspection.DataSource = dtPO;
            gvBoxInspection.DataBind();
            ViewState["upgrd"] = dtPO;
            //changes made on 21/9/2010
            txtPackLno.Text = vis.Single().LnPckLotNo.ToString();
            txtLNpckQty.Text = vis.Single().LnPckQty.ToString();
            txtFpstrQty.Text = vis.Single().FpStrQty.ToString();
            if (vis.Single().FpDate.ToString() != "")
            {
                DateTime fpdte = vis.Single().FpDate.Value;
                txtFpDate.Text = fpdte.ToString("dd/MM/yyyy");
            }            
            txtfpMTSno.Text = vis.Single().FpMtsNo.ToString();
            if (vis.Single().ThbDate.ToString() != "")
            {
                DateTime thbDte = vis.Single().ThbDate.Value;
                txtthbDate.Text = thbDte.ToString("dd/MM/yyyy");
            }
            txtThmbMTSno.Text = vis.Single().ThbMtsNo.ToString();
            txtThbQty.Text = vis.Single().ThbQty.ToString();
            if (vis.Single().ToStrDate.ToString() != "")
            {
                DateTime tostrDate = vis.Single().ToStrDate.Value;
                txtTostoreDate.Text = tostrDate.ToString("dd/MM/yyyy");
            }
            txtTOstoreMTSno.Text = vis.Single().ToStrMtsNo.ToString();
            txtTOstoreQty.Text = vis.Single().ToStrQty.ToString();

            btnUpdate.Visible = true;
            btnSave.Visible = false;
            
        }
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var power = from a in db.BoxPackgcollecLists where a.BplNo == txtBPLno.Text && a.Model == ddlModel.Text select a.Power;
        //ddlPower.Items.Add("Select");
        //ddlPower.DataSource = power;
        //ddlPower.DataBind();
    }


    protected void txtBrand_TextChanged(object sender, EventArgs e)
    {
       
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (btnUpdate.Visible == true)
        {
            gvBoxInspection.DataSource = null;
            gvBoxInspection.DataBind();
        }
        if(txtInlotno.Text=="")
        {
            Messagebox("Please check RejLotNo");
            txtInlotno.Focus();
        }
        else if(txtInSno.Text=="")
        {
            Messagebox("Please check SNo");
            txtInSno.Focus();
        }
        else if(txtInmodel.Text=="")
        {
            Messagebox("Please enter Model No");
            txtInmodel.Focus();
        }
        else if(txtPDama.Text == "")
        {
            Messagebox("Please check all fields");
        } 
        else if(txtPSeal.Text == "")
        {
            Messagebox("Please check all fields");
        } 
          else if(txtstain.Text == "")
        {
            Messagebox("Please check all fields");
        }
         else if(txtstrain.Text == "")
        {
            Messagebox("Please check all fields");
        }  
          else if(txtPcdama.Text == "")
        {
            Messagebox("Please check all fields");
        }  
          else if( txtPcDots.Text == "")
        {
            Messagebox("Please check all fields");
        }    
          else if( txtPclabel.Text == "")
        {
            Messagebox("Please check all fields");
        }   
         else if(  txtPcseal.Text == "")
        {
            Messagebox("Please check all fields");
        }   
         else if(  txtppHair.Text == "")
        {
            Messagebox("Please check all fields");
        }   
          else if(txtppDust.Text == "")
        {
            Messagebox("Please check all fields");
        }    
          else if(txtppBurr.Text == "")
        {
            Messagebox("Please check all fields");
        }     
          else if(txtThread.Text == "")
        {
            Messagebox("Please check all fields");
        }    
          else if(txtPPLiqlev.Text == "")
        {
            Messagebox("Please check all fields");
        }    
          else if(txtPPOther.Text == "")
        {
            Messagebox("Please check all fields");

        }                    
        
        else
      {
        
        try
        {
            Rejverif();
            
        }
        catch
        {
            Messagebox("Rejection Qty Does not Match");
            txtPDama.Text = "0";
            txtPSeal.Text = "0";
            txtstain.Text = "0";
            txtstrain.Text = "0";
            txtPcdama.Text = "0";
            txtPcDots.Text = "0";
            txtPclabel.Text = "0";
            txtPcseal.Text = "0";
            txtppHair.Text = "0";
            txtppDust.Text = "0";
            txtppBurr.Text = "0";
            txtThread.Text = "0";
            txtPPLiqlev.Text = "0";
            txtPPOther.Text = "0";
        }
        }
        
      
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        LenscollectBoxPackRecord lens = new LenscollectBoxPackRecord();
        
        lens.BPLno = txtBPLno.Text;
        lens.Model = Convert.ToInt32(txtModel.Text);
        lens.Power = Convert.ToDecimal(txtPower.Text);
        lens.Brand = txtBrand.Text;
        lens.QtyReceived = Convert.ToInt32(txtRecQty.Text);
        lens.QtyAccepted = Convert.ToInt32(txtAccQty.Text);
        lens.QtyRejected = Convert.ToInt32(txtRejQty.Text);
        
        lens.Date = System.DateTime.Now;
         lens.InspectedBy = txtInspecBy.Text;
         lens.SnoRejLens = txtSnoRejLens.Text;
         lens.LPrintedBy = txtLabelprintedBuy.Text;
         lens.Boxprepby = txtBoxPrepBy.Text;
         lens.PnOuterLby = txtPnOlabelby.Text;
         lens.shrkPacBy = txtShrkPackBy.Text;
         lens.Rmks = txtRmks.Text;

         lens.LnPckLotNo = txtPackLno.Text;
         lens.LnPckQty = txtLNpckQty.Text;
         lens.FpStrQty =txtFpstrQty.Text;
         if (txtFpDate.Text != "")
        {
         lens.FpDate = Convert.ToDateTime(txtFpDate.Text,provider);
        }
         lens.FpMtsNo = txtfpMTSno.Text;
         if (txtthbDate.Text != "")
         {
             lens.ThbDate = Convert.ToDateTime(txtthbDate.Text, provider);
         }
         lens.ThbMtsNo = txtThmbMTSno.Text;
         lens.ThbQty = txtThbQty.Text;
         if (txtTostoreDate.Text != "")
         {
             lens.ToStrDate = Convert.ToDateTime(txtTostoreDate.Text, provider);
         }
         lens.ToStrMtsNo = txtTOstoreMTSno.Text;
         lens.ToStrQty = txtTOstoreQty.Text;

                       

           db.LenscollectBoxPackRecords.InsertOnSubmit(lens);
        //SoftLensDataContext chg = (SoftLensDataContext) Session["chg"];
       // chg.SubmitChanges();
        //db.SubmitChanges();
         //dt = ViewState["ADD"];
        dt = (DataTable)ViewState["ADD"];
         ViewState["ADD"] = dt;
        LensBoxPackingRejection lrej = new LensBoxPackingRejection();
        lrej.BplNo = Convert.ToInt32(txtBPLno.Text);
           lrej.RejecQty = Convert.ToInt32(txtRejQty.Text);
           lrej.LotNo = dt.Rows[0][0].ToString();
           lrej.SerialNo = dt.Rows[0][1].ToString();
           lrej.LensModel = dt.Rows[0][2].ToString();
           lrej.Pdama = dt.Rows[0][3].ToString();
           lrej.Pseal = dt.Rows[0][4].ToString();
           lrej.Pstain = dt.Rows[0][5].ToString();
           lrej.Pstrain = dt.Rows[0][6].ToString();
           lrej.PCdama = dt.Rows[0][7].ToString();
           lrej.PCdots = dt.Rows[0][8].ToString();
           lrej.PClabel = dt.Rows[0][9].ToString();
           lrej.PCseal = dt.Rows[0][10].ToString();
           lrej.PPhair = dt.Rows[0][11].ToString();
           lrej.PPdust = dt.Rows[0][12].ToString();
           lrej.PPburr = dt.Rows[0][13].ToString();
           lrej.PPthread = dt.Rows[0][14].ToString();
           lrej.PPliqLev = dt.Rows[0][15].ToString();
           lrej.PPoth = dt.Rows[0][16].ToString();
           db.LensBoxPackingRejections.InsertOnSubmit(lrej);
           db.SubmitChanges();
            Messagebox("Saved Successfully");
       
        
        btnSave.Visible = false;
        
        clear();
        txtBPLno.Text = "";
        sclear();
        gvBoxInspection.DataSource = null;
        gvBoxInspection.DataBind();

    }
    private void Rejverif()
    {
        
        //dt = (DataTable)ViewState["ADD"];
       int r4= Convert.ToInt32(txtPDama.Text);
       int r5= Convert.ToInt32(txtPSeal.Text);
       int r6= Convert.ToInt32( txtstain.Text);
       int r7= Convert.ToInt32( txtstrain.Text);
       int r8= Convert.ToInt32( txtPcdama.Text);
       int r9= Convert.ToInt32( txtPcDots.Text);
       int r10= Convert.ToInt32( txtPclabel.Text);
       int r11= Convert.ToInt32(txtPcseal.Text);
       int r12= Convert.ToInt32( txtppHair.Text);
       int r13= Convert.ToInt32(  txtppDust.Text);
       int r14= Convert.ToInt32( txtppBurr.Text);
       int r15= Convert.ToInt32( txtThread.Text);
       int r16= Convert.ToInt32(txtPPLiqlev.Text);
       int r17 = Convert.ToInt32(txtPPOther.Text);
       int rej =  r4 + r5 + r6 + r7 + r8 + r9 + r10 + r11 + r12 + r13 + r14 + r15 + r16 + r17;
       if (Convert.ToInt32(txtRejQty.Text) == rej)
       {
           btnAdd.Visible = true;
           LensBoxPackingRejection lrej = new LensBoxPackingRejection();
           lrej.BplNo = Convert.ToInt32(txtBPLno.Text);
           lrej.RejecQty = Convert.ToInt32(txtRejQty.Text);
           lrej.LotNo = txtInlotno.Text;
           lrej.SerialNo = txtInSno.Text;
           lrej.LensModel = txtInmodel.Text;
           lrej.Pdama = txtPDama.Text;
           lrej.Pseal = txtPSeal.Text;
           lrej.Pstain = txtstain.Text;
           lrej.Pstrain = txtstrain.Text;
           lrej.PCdama = txtPcdama.Text;
           lrej.PCdots = txtPcDots.Text;
           lrej.PClabel = txtPclabel.Text;
           lrej.PCseal = txtPcseal.Text;
           lrej.PPhair = txtppHair.Text;
           lrej.PPdust = txtppDust.Text;
           lrej.PPburr = txtppBurr.Text;
           lrej.PPthread = txtThread.Text;
           lrej.PPliqLev = txtPPLiqlev.Text;
           lrej.PPoth = txtPPOther.Text;
           db.LensBoxPackingRejections.InsertOnSubmit(lrej);
           //Session["chg"] = lens;

           
           DataTable dt = new DataTable();
           dt.Columns.Add("LotNo", typeof(int));
           dt.Columns.Add("SerialNo", typeof(int));
           dt.Columns.Add("LensModel", typeof(int));
           dt.Columns.Add("Pdama", typeof(int));
           dt.Columns.Add("Pseal", typeof(int));
           dt.Columns.Add("Pstrain", typeof(int));
           dt.Columns.Add("Pstain", typeof(int));
           dt.Columns.Add("PCdama", typeof(int));
           dt.Columns.Add("PCdots", typeof(int));
           dt.Columns.Add("PClabel", typeof(int));
           dt.Columns.Add("PCseal", typeof(int));
           dt.Columns.Add("PPhair", typeof(int));
           dt.Columns.Add("PPdust", typeof(int));
           dt.Columns.Add("PPburr", typeof(int));
           dt.Columns.Add("PPthread", typeof(int));
           dt.Columns.Add("PPliqLev", typeof(int));
           dt.Columns.Add("PPoth", typeof(int));
           DataRow row = dt.NewRow();
           row[0] = txtInlotno.Text;
           row[1] = txtInSno.Text;
           row[2] = txtInmodel.Text;
           row[3] = txtPDama.Text;
           row[4] = txtPSeal.Text;
           row[5] = txtstain.Text;
           row[6] = txtstrain.Text;
           row[7] = txtPcdama.Text;
           row[8] = txtPcDots.Text;
           row[9] = txtPclabel.Text;
           row[10] = txtPcseal.Text;
           row[11] = txtppHair.Text;
           row[12] = txtppDust.Text;
           row[13] = txtppBurr.Text;
           row[14] = txtThread.Text;
           row[15] = txtPPLiqlev.Text;
           row[16] = txtPPOther.Text;
           dt.Rows.Add(row);
           gvBoxInspection.DataSource = dt;
           gvBoxInspection.DataBind();
           ViewState["ADD"] = dt;
           //db.SubmitChanges();
           pnlRejQDet.Visible = false;
           if (btnUpdate.Visible == true)
           {
               btnSave.Visible = false;
               btnUpdate.Visible = true;
           }
           if (btnSave.Visible == true)
           {
               btnSave.Visible = true;
               btnUpdate.Visible = false;
           }
       }
       else
       {
           Messagebox("Rejection Qty Does not Match");
           txtPDama.Text = "0";
           txtPSeal.Text = "0";
           txtstain.Text = "0";
           txtstrain.Text = "0";
           txtPcdama.Text = "0";
           txtPcDots.Text = "0";
           txtPclabel.Text = "0";
           txtPcseal.Text = "0";
           txtppHair.Text = "0";
           txtppDust.Text = "0";
           txtppBurr.Text = "0";
           txtThread.Text = "0";
           txtPPLiqlev.Text = "0";
           txtPPOther.Text = "0";
           //txtPDama.Text = "";
           //txtPSeal.Text ="";
           //txtstain.Text = "";
           //txtstrain.Text = "";
           //txtPcdama.Text = "";
           //txtPcDots.Text = "";
           //txtPclabel.Text = "";
           //txtPcseal.Text = "";
           //txtppHair.Text = "";
           //txtppDust.Text = "";
           //txtppBurr.Text = "";
           //txtThread.Text = "";
           //txtPPLiqlev.Text = "";
           //txtPPOther.Text = "";
       }
    }
    private void clear()
    {
        txtInlotno.Text="";
        txtInSno.Text="";
        txtInmodel.Text="";
        txtPDama.Text="";
        txtPSeal.Text="";
        txtstain.Text="";
        txtstrain.Text="";
        txtPcdama.Text="";
        txtPcDots.Text="";
        txtPclabel.Text="";
        txtPcseal.Text="";
        txtppHair.Text="";
        txtppDust.Text="";
        txtppBurr.Text="";
        txtThread.Text="";
        txtPPLiqlev.Text="";
        txtPPOther.Text="";
        
       
        txtModel.Text = "";
        txtPower.Text = "";
        txtBrand.Text = "";
        txtAccQty.Text = "";
        txtRecQty.Text = "";
        txtDate.Text = "";
        txtRejQty.Text = "";
    }

    private void sclear()
    {
        txtInspecBy.Text="";
        txtSnoRejLens.Text="";
        txtLabelprintedBuy.Text="";
        txtBoxPrepBy.Text="";
        txtPnOlabelby.Text="";
        txtShrkPackBy.Text="";
        txtRmks.Text="";

        txtPackLno.Text="";
        txtLNpckQty.Text="";
        txtFpstrQty.Text="";
        txtFpDate.Text="";
        txtfpMTSno.Text="";
        txtthbDate.Text="";
        txtThmbMTSno.Text="";
        txtThbQty.Text="";
        txtTostoreDate.Text="";
        txtTOstoreMTSno.Text="";
        txtTOstoreQty.Text="";
    }


    protected void txtInspecBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtInspecBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtInspecBy.Text = up.ToUpper();
                txtSnoRejLens.Focus();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: ");
                txtInspecBy.Text = "";
                txtInspecBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtInspecBy.Text = "";
            txtInspecBy.Focus();
        }
    }

    protected void txtBoxPrepBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtBoxPrepBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtBoxPrepBy.Text = up.ToUpper();
                txtPnOlabelby.Focus();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: ");
                txtBoxPrepBy.Text = "";
                txtBoxPrepBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtBoxPrepBy.Text = "";
            txtBoxPrepBy.Focus();
        }
    }

    protected void txtLabelprintedBuy_TextChanged(object sender, EventArgs e)
    {
        string up = txtLabelprintedBuy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtLabelprintedBuy.Text = up.ToUpper();
                txtBoxPrepBy.Focus();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: ");
                txtLabelprintedBuy.Text = "";
                txtLabelprintedBuy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtLabelprintedBuy.Text = "";
            txtLabelprintedBuy.Focus();
        }
    }

    protected void txtPnOlabelby_TextChanged(object sender, EventArgs e)
    {
        string up = txtPnOlabelby.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtPnOlabelby.Text = up.ToUpper();
                txtShrkPackBy.Focus();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: ");
                txtPnOlabelby.Text = "";
                txtPnOlabelby.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtPnOlabelby.Text = "";
            txtPnOlabelby.Focus();
        }
    }

    protected void txtShrkPackBy_TextChanged(object sender, EventArgs e)
    {
        string up = txtShrkPackBy.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtShrkPackBy.Text = up.ToUpper();
                txtRmks.Focus();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: ");
                txtShrkPackBy.Text = "";
                txtShrkPackBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtShrkPackBy.Text = "";
            txtShrkPackBy.Focus();
        }
    }
    protected void txtAccQty_TextChanged(object sender, EventArgs e)
    {
       
        if (Convert.ToInt32(txtAccQty.Text) > Convert.ToInt32(txtRecQty.Text))
        {
            Messagebox("Value is Greater than Received Qty");
            txtAccQty.Text = "";
            txtAccQty.Focus();

        }
        else
        {           
            txtRejQty.Text = (Convert.ToInt32(txtRecQty.Text) - Convert.ToInt32(txtAccQty.Text)).ToString();
            if (Convert.ToInt32(txtRejQty.Text) >= 1)
            {
                pnlRejQDet.Visible = true;
                txtPDama.Text = "0";
                txtPSeal.Text = "0";
                txtstain.Text = "0";
                txtstrain.Text = "0";
                txtPcdama.Text = "0";
                txtPcDots.Text = "0";
                txtPclabel.Text = "0";
                txtPcseal.Text = "0";
                txtppHair.Text = "0";
                txtppDust.Text = "0";
                txtppBurr.Text = "0";
                txtThread.Text = "0";
                txtPPLiqlev.Text = "0";
                txtPPOther.Text = "0";
            }
            else
            { 
                pnlRejQDet.Visible = false;
            }
        }         
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        sclear();
        clear();
        txtBPLno.Text = "";
        btnSave.Visible = false;
        gvBoxInspection.DataSource = null;
        gvBoxInspection.DataBind();
    }
    protected void txtPDama_TextChanged(object sender, EventArgs e)
    {

    }

    protected void gvBoxInspection_SelectedIndexChanged(object sender, EventArgs e)
    {
        //dt = (DataTable)ViewState["ADD"];
        //ViewState["ADD"] = dt;

        pnlRejQDet.Visible = true;
        txtInlotno.Text = gvBoxInspection.SelectedRow.Cells[1].Text;
        txtInSno.Text = gvBoxInspection.SelectedRow.Cells[2].Text;
        txtInmodel.Text = gvBoxInspection.SelectedRow.Cells[3].Text;
        txtPDama.Text = gvBoxInspection.SelectedRow.Cells[4].Text;
        txtPSeal.Text = gvBoxInspection.SelectedRow.Cells[5].Text;
        txtstain.Text = gvBoxInspection.SelectedRow.Cells[6].Text;
        txtstrain.Text = gvBoxInspection.SelectedRow.Cells[7].Text;
        txtPcdama.Text = gvBoxInspection.SelectedRow.Cells[8].Text;
        txtPcDots.Text = gvBoxInspection.SelectedRow.Cells[9].Text;
        txtPclabel.Text = gvBoxInspection.SelectedRow.Cells[10].Text;
        txtPcseal.Text = gvBoxInspection.SelectedRow.Cells[11].Text;
        txtppHair.Text = gvBoxInspection.SelectedRow.Cells[12].Text;
        txtppDust.Text = gvBoxInspection.SelectedRow.Cells[13].Text;
        txtppBurr.Text = gvBoxInspection.SelectedRow.Cells[14].Text;
        txtThread.Text = gvBoxInspection.SelectedRow.Cells[15].Text;
        txtPPLiqlev.Text = gvBoxInspection.SelectedRow.Cells[16].Text;
        txtPPOther.Text = gvBoxInspection.SelectedRow.Cells[17].Text;     

    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        var lens = from a in db.LenscollectBoxPackRecords where a.BPLno == txtBPLno.Text select a;

        lens.Single().BPLno = txtBPLno.Text;
        lens.Single().Model = Convert.ToInt32(txtModel.Text);
        lens.Single().Power = Convert.ToDecimal(txtPower.Text);
        lens.Single().Brand = txtBrand.Text;
        lens.Single().QtyReceived = Convert.ToInt32(txtRecQty.Text);
        lens.Single().QtyAccepted = Convert.ToInt32(txtAccQty.Text);
        lens.Single().QtyRejected = Convert.ToInt32(txtRejQty.Text);

        lens.Single().Date = System.DateTime.Now;
        lens.Single().InspectedBy = txtInspecBy.Text;
        lens.Single().SnoRejLens = txtSnoRejLens.Text;
        lens.Single().LPrintedBy = txtLabelprintedBuy.Text;
        lens.Single().Boxprepby = txtBoxPrepBy.Text;
        lens.Single().PnOuterLby = txtPnOlabelby.Text;
        lens.Single().shrkPacBy = txtShrkPackBy.Text;
        lens.Single().Rmks = txtRmks.Text;

        lens.Single().LnPckLotNo = txtPackLno.Text;
        lens.Single().LnPckQty = txtLNpckQty.Text;
        lens.Single().FpStrQty = txtFpstrQty.Text;

        if (txtFpDate.Text != "")
        {
            lens.Single().FpDate = Convert.ToDateTime(txtFpDate.Text, provider);
        }
        lens.Single().FpMtsNo = txtfpMTSno.Text;
        if (txtthbDate.Text != "")
        {
            lens.Single().ThbDate = Convert.ToDateTime(txtthbDate.Text, provider);
        }
        lens.Single().ThbMtsNo = txtThmbMTSno.Text;
        lens.Single().ThbQty = txtThbQty.Text;
        if (txtTostoreDate.Text != "")
        {
            lens.Single().ToStrDate = Convert.ToDateTime(txtTostoreDate.Text, provider);
        }

        lens.Single().ToStrMtsNo = txtTOstoreMTSno.Text;
        lens.Single().ToStrQty = txtTOstoreQty.Text;
        //db.LenscollectBoxPackRecords.SubmitChanges();

        var lrej = from a in db.LensBoxPackingRejections where a.BplNo == Convert.ToInt32(txtBPLno.Text) select a;
        dt = (DataTable)ViewState["ADD"];
        ViewState["ADD"] = dt;
        //LensBoxPackingRejection lrej = new LensBoxPackingRejection();
        lrej.Single().BplNo = Convert.ToInt32(txtBPLno.Text);
        lrej.Single().RejecQty = Convert.ToInt32(txtRejQty.Text);
        if(dt != null)
        {
            lrej.Single().LotNo = dt.Rows[0][0].ToString();
            lrej.Single().SerialNo = dt.Rows[0][1].ToString();
            lrej.Single().LensModel = dt.Rows[0][2].ToString();
            lrej.Single().Pdama = dt.Rows[0][3].ToString();
            lrej.Single().Pseal = dt.Rows[0][4].ToString();
            lrej.Single().Pstain = dt.Rows[0][5].ToString();
            lrej.Single().Pstrain = dt.Rows[0][6].ToString();
            lrej.Single().PCdama = dt.Rows[0][7].ToString();
            lrej.Single().PCdots = dt.Rows[0][8].ToString();
            lrej.Single().PClabel = dt.Rows[0][9].ToString();
            lrej.Single().PCseal = dt.Rows[0][10].ToString();
            lrej.Single().PPhair = dt.Rows[0][11].ToString();
            lrej.Single().PPdust = dt.Rows[0][12].ToString();
            lrej.Single().PPburr = dt.Rows[0][13].ToString();
            lrej.Single().PPthread = dt.Rows[0][14].ToString();
            lrej.Single().PPliqLev = dt.Rows[0][15].ToString();
            lrej.Single().PPoth = dt.Rows[0][16].ToString();
        }
        db.SubmitChanges();
        btnUpdate.Visible = false;
        clear();
        txtBPLno.Text = "";
        sclear();
        gvBoxInspection.DataSource = null;
        gvBoxInspection.DataBind();

    }
}
