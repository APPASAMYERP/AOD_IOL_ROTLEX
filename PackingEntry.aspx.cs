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

public partial class PackingEntry : System.Web.UI.Page
{
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ModelBind();
            PowerBind();
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    } 

    private void Clear()
    {
        ddlModel.Text = "Select";
        ddlSubModel.Text = "Select";
        txtBrand.Text = "";
        ddlPower.Text = "Select";
        txtAvailableQty.Text = "";
        txtRequiredQty.Text = "";
        txtBPLNO.Text = "";

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
    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSubModel.Items.Clear();
        ddlSubModel.Items.Add("Select");
        var q = from r in db.ModelMasters where r.Model==(ddlModel.Text) select r.SubModel;
        ddlSubModel.DataSource = q;
        ddlSubModel.DataBind();
    }
    protected void ddlSubModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        var q = from r in db.ModelMasters where r.SubModel == ddlSubModel.Text select r.BrandName;
        txtBrand.Text = q.Single().ToString();
        
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            var q = from r in db.InspectionDocDatas where r.Model == ddlModel.Text && r.SubModel == ddlSubModel.Text && r.Power == Convert.ToDecimal(ddlPower.Text) && r.RemainingQty > 0 orderby r.ManufactureDate ascending select r;
            gvPackingEntry.DataSource = q;
            gvPackingEntry.DataBind();

            if (q.Count() > 0)
            {
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
                txtAvailableQty.Visible = true;
                txtRequiredQty.Visible = true;
                txtBPLNO.Visible = true;
                txtDate.Visible = true;
                var q1 = (from r in db.InspectionDocDatas where r.Model == ddlModel.Text && r.SubModel == ddlSubModel.Text && r.Power == Convert.ToDecimal(ddlPower.Text) && r.RemainingQty > 0 orderby r.ManufactureDate ascending select r.RemainingQty).Sum();
                txtAvailableQty.Text = q1.Value.ToString();
                btnSave.Visible = true;
            }
            else
            {
                Messagebox("No Lens Available");
                Label2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                txtAvailableQty.Visible = false;
                txtRequiredQty.Visible = false;
                txtBPLNO.Visible = false;
                txtDate.Visible = false;
            }
        }
        catch
        {

        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if(txtRequiredQty.Text=="")
        {
            Messagebox("Please enter Required qty");
        }
        else if (txtBPLNO.Text == "")
        {
            Messagebox("Please enter BPLNO");
        }
        else
        {

        if (Convert.ToInt32(txtRequiredQty.Text) <= Convert.ToInt32(txtAvailableQty.Text))
        {
            Label s = gvPackingEntry.Rows[0].FindControl("Label1") as Label;
            int requiredqty;
            int remainingqty;
            requiredqty = Convert.ToInt32(txtRequiredQty.Text);
            for (int i = 0; i < gvPackingEntry.Rows.Count; i++)
            {
                Label id = gvPackingEntry.Rows[i].FindControl("Label1") as Label;
                remainingqty = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[8].Text) - Convert.ToInt32(requiredqty);
                if (remainingqty < 0)
                {

                    var q1 = from r in db.InspectionDocDatas where r.Id == Convert.ToInt32(id.Text) select r;
                    requiredqty = requiredqty - q1.Single().RemainingQty.Value;
                    int takenqty = q1.Single().RemainingQty.Value;
                    q1.Single().RemainingQty = 0;
                    db.SubmitChanges();

                    PackingEntryTable pe = new PackingEntryTable()
                    {
                        BPLNO = Convert.ToInt32(txtBPLNO.Text),
                        Brand = gvPackingEntry.Rows[i].Cells[8].Text,
                        Date = txtDate.Text,
                        LotNo = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[0].Text),
                        Model = Convert.ToInt32(ddlModel.Text),
                        Power = Convert.ToDecimal(ddlPower.Text),
                        Qty = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[7].Text),
                        RemainingQty = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[8].Text),
                        SerialFrom = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[5].Text),
                        SerialTo = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[6].Text),
                        SubModel = ddlSubModel.Text,
                        TakenQty = takenqty,
                        SterileBatchNo = gvPackingEntry.Rows[i].Cells[9].Text,
                        ManufactureDate = Convert.ToDateTime(gvPackingEntry.Rows[i].Cells[10].Text),
                        ExpiryDate = Convert.ToDateTime(gvPackingEntry.Rows[i].Cells[11].Text),


                    };
                    db.PackingEntryTables.InsertOnSubmit(pe);
                    db.SubmitChanges();
                }
                else
                {

                    var q1 = from r in db.InspectionDocDatas where r.Id == Convert.ToInt32(id.Text) select r;
                    q1.Single().RemainingQty = q1.Single().RemainingQty.Value - Convert.ToInt32(requiredqty);
                    db.SubmitChanges();

                    PackingEntryTable pe = new PackingEntryTable()
                    {
                        BPLNO = Convert.ToInt32(txtBPLNO.Text),
                        Brand = gvPackingEntry.Rows[i].Cells[8].Text,
                        Date = txtDate.Text,
                        LotNo = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[0].Text),
                        Model = Convert.ToInt32(ddlModel.Text),
                        Power = Convert.ToDecimal(ddlPower.Text),
                        Qty = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[7].Text),
                        RemainingQty = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[8].Text),
                        SerialFrom = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[5].Text),
                        SerialTo = Convert.ToInt32(gvPackingEntry.Rows[i].Cells[6].Text),
                        SubModel = ddlSubModel.Text,
                        TakenQty = requiredqty,
                        SterileBatchNo = gvPackingEntry.Rows[i].Cells[9].Text,
                        ManufactureDate = Convert.ToDateTime(gvPackingEntry.Rows[i].Cells[10].Text),
                        ExpiryDate = Convert.ToDateTime(gvPackingEntry.Rows[i].Cells[11].Text),


                    };
                    db.PackingEntryTables.InsertOnSubmit(pe);
                    db.SubmitChanges();
                    Clear();
                    btnSave.Visible = false;
                    Messagebox("Saved Successfully");
                    Label2.Visible = false;
                    Label3.Visible = false;
                    Label4.Visible = false;
                    Label5.Visible = false;
                    txtAvailableQty.Visible = false;
                    txtRequiredQty.Visible = false;
                    txtBPLNO.Visible = false;
                    txtDate.Visible = false;

                    break;
                }
            }
        }
    }
    }
}
