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
using System.Data.Common;
using System.Web.Services;


public partial class DespatchEntry : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    static SoftLensDataContext db;
    static DbTransaction trans;

    [WebMethod]

    public static void Close()
    {

        DespatchEntry de = new DespatchEntry();
        de.call();
       
    }
    private void call()
    {
        try
        {
           
            int v = (int)Session["Rollback"];

            if (trans != null && v == 1)
                trans.Rollback();
        }
        catch
        {
            
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
          //  txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
           
            DataTable dt = new DataTable();
            dt.Columns.Add("Model", typeof(int));
            dt.Columns.Add("SubModel", typeof(string));
            dt.Columns.Add("Brand", typeof(string));
            dt.Columns.Add("Power", typeof(decimal));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("LotNo", typeof(int));
            dt.Columns.Add("RefID", typeof(int));
            dt.Columns.Add("Type", typeof(string));
            Session["table"] = dt;

            db = new SoftLensDataContext();
            db.Connection.Open();            
            trans = db.Connection.BeginTransaction();
            db.Transaction = trans;
            Session["trans"] = trans;
            ModelBind();
            PowerBind();
        }
    }

    private void Clear()
    {
        txtAddress.Text = "";
        txtBrand.Text = "";
        txtDCNo.Text = "";
        txtDcDate.Text = "";
        txtIndentNo.Text = "";
        txtModeofDespatch.Text = "";
        txtNoofPacking.Text = "";
        txtOrderRefNo.Text = "";
        txtRemarks.Text = "";
        txtRequiredQty.Text = "";
        txtStock.Text = "";
        txtToAddress.Text = "";
        txtTransDate.Text = "";
        ddlModel.Text = "Select";

      
        ddlSubModel.Items.Clear();
        ddlPower.Text = "Select";

        gvDespatch.DataSource = null;
        gvDespatch.DataBind();
        gvUpdate.DataSource = null;
        gvUpdate.DataBind();
        
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    } 

    private void ModelBind()
    {
        ddlModel.Items.Add("Select");
        var q = (from r in db.ModelMasters select r.Model).Distinct();
        ddlModel.DataSource = q;
        ddlModel.DataBind();
    }
    private void PowerBind()
    {
        ddlPower.Items.Add("Select");
        var q = from r in db.PowerMasters select r.Power;
        ddlPower.DataSource = q;
        ddlPower.DataBind();
    }


    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlModel.SelectedIndex == 0)
        {
            Messagebox("Please Select Model");
        }
        else if (ddlSubModel.SelectedIndex == 0)
        {
            Messagebox("Please Select SubModel");
        }
        else if (txtBrand.Text == "")
        {
            Messagebox("Please enter Brand");
        }
        else if (ddlPower.SelectedIndex == 0)
        {
            Messagebox("Please Select Power");
        }
        else if (txtStock.Text == "")
        {
            Messagebox("No Stock found");
        }
        else if (txtRequiredQty.Text == "")
        {
            Messagebox("Please enter Required Qty");
        }
        else
        {
            Session["Rollback"] = 1;
            LensDescriptionGridBind("Add");
            ddlModel.Text = "Select";
            ddlSubModel.Text = "Select";
            txtBrand.Text = "";
            ddlPower.Text = "Select";
            txtRequiredQty.Text = "";
            txtStock.Text = "";
            btnAdd.Visible = false;
            btnClear.Visible = true;
        }
    }

    private void LensDescriptionGridBind(string Type)
    {
      

        int requiredqty;
        int remainingqty;
        ArrayList id;
        ArrayList qty;
        ArrayList det;
        int Model;
        string SubModel,Brand,typ;
        decimal Power;

        if (Type == "Add")
        {
            requiredqty = Convert.ToInt32(txtRequiredQty.Text);
             id= (ArrayList)Session["id"];
             qty = (ArrayList)Session["qty"];
             Model=Convert.ToInt32(ddlModel.Text);
             SubModel=ddlSubModel.Text;
             Brand=txtBrand.Text;
             Power = Convert.ToDecimal(ddlPower.Text);
             typ = "Add";
        }
        else
        {
            requiredqty = Convert.ToInt32(Type);
             id = (ArrayList)Session["idUpdate"];
             qty = (ArrayList)Session["qtyUpdate"];
             det = (ArrayList)Session["detailsUpdate"];
             Model= Convert.ToInt32(det[0].ToString());
            SubModel=det[1].ToString();
            Brand=det[2].ToString();
            Power=Convert.ToDecimal(det[3].ToString());
            typ = "Update";
        }
        
        DataTable dt = (DataTable)Session["table"];

      
        for (int i = 0; i < id.Count; i++)
        {

            remainingqty = Convert.ToInt32(qty[i].ToString()) - requiredqty;
            if (remainingqty < 0)
            {

                var q1 = from r in db.PackingEntryTables where r.Id == Convert.ToInt32(id[i].ToString()) select r;
                requiredqty = requiredqty - q1.Single().TakenQty.Value;
                int Stocktakenqty = q1.Single().TakenQty.Value;
                int LotNo = q1.Single().LotNo.Value;
                q1.Single().TakenQty = 0;
                db.SubmitChanges();

                DataRow dr = dt.NewRow();
                dr[0] = Model;
                dr[1] = SubModel;
                dr[2] = Brand;
                dr[3] = Power;
                dr[4] = Stocktakenqty;
                dr[5] = q1.Single().LotNo.Value;
                dr[6] = q1.Single().Id;
                dr[7] = typ;
                dt.Rows.Add(dr);

            }
            else
            {

                var q1 = from r in db.PackingEntryTables where r.Id == Convert.ToInt32(id[i].ToString()) select r;
                q1.Single().TakenQty = q1.Single().TakenQty.Value - Convert.ToInt32(requiredqty);
                db.SubmitChanges();

                DataRow dr = dt.NewRow();
                dr[0] = Model;
                dr[1] = SubModel;
                dr[2] = Brand;
                dr[3] = Power;
                dr[4] = requiredqty;
                dr[5] = q1.Single().LotNo.Value;
                dr[6] = q1.Single().Id;
                dr[7] = typ;
                dt.Rows.Add(dr);

                break;
            }
        }
   
        //Session["db"] = db;
        Session["table"] = dt;
        
        gvDespatch.DataSource = dt;
        gvDespatch.DataBind();
       
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlModel.SelectedIndex > 0)
        {
            btnAdd.Visible = true;
        }
        else
        {
            btnAdd.Visible = false;
        }

        ddlSubModel.Items.Clear();
        ddlSubModel.Items.Add("Select");
        var q = from r in db.ModelMasters where r.Model == (ddlModel.Text) select r.SubModel;
        ddlSubModel.DataSource = q;
        ddlSubModel.DataBind();
    }
    protected void ddlSubModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        var q = from r in db.ModelMasters where r.SubModel == ddlSubModel.Text select r.BrandName;
        txtBrand.Text = q.Single().ToString();
    }

    protected void ddlPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        var q = from r in db.PackingEntryTables where r.Model == Convert.ToInt32(ddlModel.Text) && r.SubModel == ddlSubModel.Text && r.Power == Convert.ToDecimal(ddlPower.Text) && r.TakenQty > 0 orderby r.ManufactureDate ascending select r;
        ArrayList id = new ArrayList();
        ArrayList qty= new ArrayList();
        int Stock=0;
        foreach (var val in q)
        {
            id.Add(val.Id.ToString());
            qty.Add(val.TakenQty.ToString());
            Stock = Stock + val.TakenQty.Value;
        }
        txtStock.Text = Stock.ToString();
        Session["id"] = id;
        Session["qty"] = qty;
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (txtDCNo.Text == "")
        {
            Messagebox("Please Enter DC No");
        }
        else if (txtDcDate.Text == "")
        {
            Messagebox("Please Enter Date");
        }
        else if (txtToAddress.Text == "")
        {
            Messagebox("Please Enter To Name");
        }
        else if (txtAddress.Text == "")
        {
            Messagebox("Please Enter Address");
        }
        else if (txtOrderRefNo.Text == "")
        {
            Messagebox("Please Enter Order Reference No");
        }
        else if (txtIndentNo.Text == "")
        {
            Messagebox("Please Enter Indent No");
        }
        else if (txtNoofPacking.Text == "")
        {
            Messagebox("Please Enter No of Packing");
        }
        else
        {

            DespatchTable de = new DespatchTable()
            {
                Address = txtAddress.Text,
                DcDate =Convert.ToDateTime(txtDcDate.Text,provider),
                DCNo = txtDCNo.Text,

                IndentNo = txtIndentNo.Text,
                ModeOfDespatch = txtModeofDespatch.Text,
                NoOfPacking = Convert.ToInt32(txtNoofPacking.Text),
                OrderRef = txtOrderRefNo.Text,
                Remarks = txtRemarks.Text,
                ToName = txtToAddress.Text,
                TransactionDate = Convert.ToDateTime(txtTransDate.Text,provider)
            };
            db.DespatchTables.InsertOnSubmit(de);

            DataTable dt = (DataTable)Session["table"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DespatchChild dc = new DespatchChild()
                {
                    Model = Convert.ToInt32(dt.Rows[i][0].ToString()),
                    SubModel = dt.Rows[i][1].ToString(),
                    Brand = dt.Rows[i][2].ToString(),
                    Power = Convert.ToDecimal(dt.Rows[i][3].ToString()),
                    TakenQuantity = Convert.ToInt32(dt.Rows[i][4].ToString()),
                    LotNo = dt.Rows[i][5].ToString(),
                    RefID = Convert.ToInt32(dt.Rows[i][6].ToString()),
                    DCNo = txtDCNo.Text,
                    RequiredQty = Convert.ToInt32(txtRequiredQty.Text)
                };
                db.DespatchChilds.InsertOnSubmit(dc);

            }

            db.SubmitChanges();
            trans.Commit();
            db.Connection.Close();

            db = new SoftLensDataContext();
            db.Connection.Open();
            trans = db.Connection.BeginTransaction();
            db.Transaction = trans;
            Session["trans"] = trans;
            Session["Rollback"] = 0;
            Clear();
            btnClear.Visible = false;
            btnSave.Visible = false;
            dt.Clear();
            DataTable dt1 = (DataTable)Session["dt"];
            dt1.Clear();
        }
    }
    protected void txtDCNo_TextChanged(object sender, EventArgs e)
    {
        var q = (from r in db.DespatchChilds where r.DCNo == txtDCNo.Text select new { r.Model,r.Power,r.SubModel,r.Brand,r.RequiredQty}).Distinct();

        DataTable dt = new DataTable();
        dt.Columns.Add("Model", typeof(int));
        dt.Columns.Add("SubModel", typeof(string));
        dt.Columns.Add("Brand", typeof(string));
        dt.Columns.Add("Power", typeof(decimal));
        dt.Columns.Add("Quantity", typeof(int));
        foreach(var val in q)
        {
            DataRow dr = dt.NewRow();
            dr[0] = val.Model;
            dr[1] = val.SubModel;
            dr[2] = val.Brand;
            dr[3] = val.Power;
            dr[4] = val.RequiredQty;
            dt.Rows.Add(dr);
        }
        gvUpdate.DataSource = dt;
        gvUpdate.DataBind();
        Session["dt"] = dt;
        if (q.Count() > 0)
        {
            btnUpdate.Visible = true;
            btnClear.Visible = true;
        }
        else
        {
            btnSave.Visible = true;
            btnClear.Visible = true;
        }
        var q1 = from r in db.DespatchTables where r.DCNo == txtDCNo.Text select r;
        if (q1.Count() > 0)
        {
            txtDCNo.Text = q1.Single().DCNo.ToString();
            txtAddress.Text = q1.Single().Address.ToString();
            DateTime dat = q1.Single().DcDate.Value;
            txtDcDate.Text = dat.ToString("dd/MM/yyyy");
            txtIndentNo.Text = q1.Single().IndentNo.ToString();
            txtModeofDespatch.Text = q1.Single().DCNo.ToString();
            txtNoofPacking.Text = q1.Single().NoOfPacking.ToString();
            txtOrderRefNo.Text = q1.Single().OrderRef.ToString();
            txtRemarks.Text = q1.Single().Remarks.ToString();
            txtToAddress.Text = q1.Single().ToName.ToString();
            DateTime dte = q1.Single().TransactionDate.Value;
            txtTransDate.Text = dte.ToString("dd/MM/yyyy");
        }
    }

    protected void gvUpdate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvUpdate.EditIndex = e.NewEditIndex;
        DataTable dt = (DataTable)Session["dt"];
        gvUpdate.DataSource = dt;
        gvUpdate.DataBind();
    }

    protected void gvUpdate_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {      
        TextBox qty = gvUpdate.Rows[e.RowIndex].Cells[4].FindControl("Textbox5") as TextBox;
        Session["ReqQtyupdate"] = qty.Text;
        DataTable dt = (DataTable)Session["dt"];
     
        var q1 = (from r in db.PackingEntryTables where r.Model == Convert.ToInt32(dt.Rows[e.RowIndex][0].ToString()) && r.SubModel == dt.Rows[e.RowIndex][1].ToString() && r.Brand == dt.Rows[e.RowIndex][2].ToString() && r.Power == Convert.ToDecimal(dt.Rows[e.RowIndex][3].ToString()) select r.TakenQty).Sum();
        int chkqty=q1.Value + Convert.ToInt32(dt.Rows[e.RowIndex][4]);

        if (Convert.ToInt32(qty.Text) <= chkqty)
        {
            if (Convert.ToInt32(qty.Text) != Convert.ToInt32(dt.Rows[0][4].ToString()))
            {
                var q2 = from r in db.DespatchChilds where r.DCNo == txtDCNo.Text && r.Model == Convert.ToInt32(dt.Rows[e.RowIndex][0].ToString()) select new { r.TakenQuantity, r.RefID };
                foreach (var val in q2)
                {                   
                    var q3 = from r in db.PackingEntryTables where r.Id == val.RefID select r;
                    q3.Single().TakenQty = q3.Single().TakenQty + val.TakenQuantity;
                    db.SubmitChanges();
                }

                var q4 = from r in db.DespatchChilds where r.DCNo == txtDCNo.Text && r.Model == Convert.ToInt32(dt.Rows[e.RowIndex][0].ToString()) select r;
                db.DespatchChilds.DeleteAllOnSubmit(q4);
                db.SubmitChanges();

                var q5 = from r in db.PackingEntryTables where r.Model == Convert.ToInt32(dt.Rows[e.RowIndex][0].ToString()) && r.SubModel == dt.Rows[e.RowIndex][1].ToString() && r.Brand == dt.Rows[e.RowIndex][2].ToString() && r.Power==Convert.ToDecimal(dt.Rows[e.RowIndex][3].ToString()) && r.TakenQty > 0 orderby r.ManufactureDate ascending select r; ;
               
                ArrayList id = new ArrayList();
                ArrayList qtys = new ArrayList();
                int Stock = 0;
                foreach (var val in q5)
                {
                    id.Add(val.Id.ToString());
                    qtys.Add(val.TakenQty.ToString());
                    Stock = Stock + val.TakenQty.Value;
                }

                ArrayList det=new ArrayList();
                det.Add(dt.Rows[e.RowIndex][0].ToString());
                det.Add(dt.Rows[e.RowIndex][1].ToString());
                det.Add(dt.Rows[e.RowIndex][2].ToString());
                det.Add(dt.Rows[e.RowIndex][3].ToString());
                                               
                Session["idUpdate"] = id;
                Session["qtyUpdate"] = qtys;
                Session["detailsUpdate"]=det;
                LensDescriptionGridBind(qty.Text);
                dt.Rows[0][4] = Convert.ToInt32(qty.Text);
            }           
       
            gvUpdate.EditIndex = -1;
            Session["dt"] = dt;
            gvUpdate.DataSource = dt;
            gvUpdate.DataBind();
        }
        else
        {
            Messagebox("Available qty is only :" + chkqty);
            gvUpdate.EditIndex = -1;
            Session["dt"] = dt;
            gvUpdate.DataSource = dt;
            gvUpdate.DataBind();
        }
    }

    protected void gvUpdate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvUpdate.EditIndex = -1;
        DataTable dt = (DataTable)Session["dt"];
        gvUpdate.DataSource = dt;
        gvUpdate.DataBind();
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
         if (txtDCNo.Text == "")
        {
            Messagebox("Please Enter DC No");
        }
        else if (txtDcDate.Text == "")
        {
            Messagebox("Please Enter Date");
        }
        else if (txtToAddress.Text == "")
        {
            Messagebox("Please Enter To Name");
        }
        else if (txtAddress.Text == "")
        {
            Messagebox("Please Enter Address");
        }
        else if (txtOrderRefNo.Text == "")
        {
            Messagebox("Please Enter Order Reference No");
        }
        else if (txtIndentNo.Text == "")
        {
            Messagebox("Please Enter Indent No");
        }
         else if (txtNoofPacking.Text == "")
         {
             Messagebox("Please Enter No of Packing");
         }
         else
         {
             var q = from r in db.DespatchTables where r.DCNo == txtDCNo.Text select r;

             q.Single().Address = txtAddress.Text;
             q.Single().DcDate = Convert.ToDateTime(txtDcDate.Text,provider);
             q.Single().DCNo = txtDCNo.Text;

             q.Single().IndentNo = txtIndentNo.Text;
             q.Single().ModeOfDespatch = txtModeofDespatch.Text;
             q.Single().NoOfPacking = Convert.ToInt32(txtNoofPacking.Text);
             q.Single().OrderRef = txtOrderRefNo.Text;
             q.Single().Remarks = txtRemarks.Text;
             q.Single().ToName = txtToAddress.Text;
             q.Single().TransactionDate = Convert.ToDateTime(txtTransDate.Text,provider);

             db.SubmitChanges();

             DataTable dt = (DataTable)Session["table"];
             string reqqty;
             for (int i = 0; i < dt.Rows.Count; i++)
             {

                 if (dt.Rows[i][7].ToString() == "Add")
                 {
                     reqqty = txtRequiredQty.Text;
                 }
                 else
                 {
                     reqqty = Session["ReqQtyupdate"].ToString();
                 }

                 DespatchChild dc = new DespatchChild()
                 {

                     Model = Convert.ToInt32(dt.Rows[i][0].ToString()),
                     SubModel = dt.Rows[i][1].ToString(),
                     Brand = dt.Rows[i][2].ToString(),
                     Power = Convert.ToDecimal(dt.Rows[i][3].ToString()),
                     TakenQuantity = Convert.ToInt32(dt.Rows[i][4].ToString()),
                     LotNo = dt.Rows[i][5].ToString(),
                     RefID = Convert.ToInt32(dt.Rows[i][6].ToString()),
                     DCNo = txtDCNo.Text,
                     RequiredQty = Convert.ToInt32(reqqty)
                 };
                 db.DespatchChilds.InsertOnSubmit(dc);
             }

             db.SubmitChanges();
             trans.Commit();
             db.Connection.Close();
             db = new SoftLensDataContext();
             db.Connection.Open();
             trans = db.Connection.BeginTransaction();
             db.Transaction = trans;
             Session["trans"] = trans;
             Session["Rollback"] = 0;
             Clear();
             btnClear.Visible = false;
             btnUpdate.Visible = false;
             dt.Clear();
             DataTable dt1 = (DataTable)Session["dt"];
             dt1.Clear();
         }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {        
        Clear();
        try
        {
            DataTable dt = (DataTable)Session["table"];
            dt.Clear();
            DataTable dt1 = (DataTable)Session["dt"];
            dt1.Clear();
        }
        catch
        {
        }

        if (trans != null)
        {
            trans.Rollback();
            db.Connection.Close();

            db = new SoftLensDataContext();
            db.Connection.Open();
            trans = db.Connection.BeginTransaction();
            db.Transaction = trans;
            Session["trans"] = trans;
            //Session["table"] = null;
            //Session["dt"] = null;
            btnClear.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = false;
        }     
      
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DateTime comp = Convert.ToDateTime(txtSearchBox.Text, provider);
            var q = from r in db.DespatchTables where  r.DcDate == comp select r;
            gvSearch.DataSource = q;
            gvSearch.DataBind();
        }
        catch
        {
            var q = from r in db.DespatchTables where r.DCNo == txtSearchBox.Text  select r;
            gvSearch.DataSource = q;
            gvSearch.DataBind();
        }
        
    }

    protected void btnViewAll_Click(object sender, ImageClickEventArgs e)
    {
        var q = from r in db.DespatchTables select r;
        gvSearch.DataSource = q;
        gvSearch.DataBind();
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        txtSearchBox.Text = "";
    }
}
