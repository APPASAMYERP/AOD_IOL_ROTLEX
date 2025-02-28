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

public partial class PageMaster : System.Web.UI.Page
{
   
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        PowerGridBind();
        ModelGridBind();
        LatheGridBind();
        UserAdmin();
        MillingGridBind();
        //TabContainer1.ActiveTabIndex
    }
    private void PowerGridBind()
    {
        var query = from row in db.PowerMasters select row;
        GridView1.DataSource = query;
        GridView1.DataBind();
        
    }
    private void Clear()
    {
        txtPower.Text = "";
        txtRadius1.Text = "";
        txtRadius2.Text ="";
    }    
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
         if (txtPower.Text == "")
        {
            Messagebox("Please enter Power value");
        }
        else if (txtRadius1.Text == "")
        {
            Messagebox("Please enter Radius1 value");
        }
         else if (txtRadius2.Text == "")
         {
             Messagebox("Please enter Radius2 value");
         }
         else
         {
             PowerMaster pow = new PowerMaster()
             {
                 Power = Convert.ToDecimal(txtPower.Text),
                 Radius1 = Convert.ToDecimal(txtRadius1.Text),
                 Radius2 = Convert.ToDecimal(txtRadius2.Text),
             };
             db.PowerMasters.InsertOnSubmit(pow);
             db.SubmitChanges();
             Messagebox("Power Added");
             PowerGridBind();
             Clear();
             btnAdd.Visible = false;
         }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label id = GridView1.SelectedRow.FindControl("Label1") as Label;
        Session["id"] = id.Text;
        txtPower.Text = GridView1.SelectedRow.Cells[1].Text;
        txtRadius1.Text = GridView1.SelectedRow.Cells[2].Text;
        txtRadius2.Text = GridView1.SelectedRow.Cells[3].Text;
        btnUpdate.Visible = true;
        btnAdd.Visible = false;
       
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
         if (txtPower.Text == "")
        {
            Messagebox("Please enter Power value");
        }
        else if (txtRadius1.Text == "")
        {
            Messagebox("Please enter Radius1 value");
        }
         else if (txtRadius2.Text == "")
         {
             Messagebox("Please enter Radius2 value");
         }
         else
         {
             int id = Convert.ToInt32(Session["id"].ToString());

             var query = from row in db.PowerMasters where row.Id == id select row;

             query.Single().Power = Convert.ToDecimal(txtPower.Text);
             query.Single().Radius1 = Convert.ToDecimal(txtRadius1.Text);
             query.Single().Radius2 = Convert.ToDecimal(txtRadius2.Text);
             db.SubmitChanges();
             Messagebox("Power Value Updated");
             PowerGridBind();
             Clear();
             btnUpdate.Visible = false;
         }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        var query = from row in db.PowerMasters select row;
        GridView1.DataSource = query;
        GridView1.DataBind();

    }
    protected void txtPower_TextChanged(object sender, EventArgs e)
    {
        btnAdd.Visible = true;
        btnUpdate.Visible = false; 
    }


    //------------------------------------------Model Master--------------------------------------

    private void ClearModel()
    {
        txtModel.Text = "";
        txtSubModel.Text="";
        txtBrandName.Text = "";

            
    }
    private void ModelGridBind()
    {
        var query = from row in db.ModelMasters select row;
        gvModel.DataSource = query;
        gvModel.DataBind();

    }
    protected void btnAddModel_Click(object sender, ImageClickEventArgs e)
    {
        if (txtModel.Text == "")
        {
            Messagebox("Please enter Model value");
        }
        else if (txtSubModel.Text == "")
        {
            Messagebox("Please enter SubModel value");
        }
        else if (txtBrandName.Text == "")
        {
            Messagebox("Please enter BrandName value");
        }
        else
        {
            ModelMaster mod = new ModelMaster()
            {
                Model = (txtModel.Text),
                BrandName = txtBrandName.Text,
                SubModel = txtSubModel.Text
            };
            db.ModelMasters.InsertOnSubmit(mod);
            db.SubmitChanges();
            Messagebox("Model Added");
            ModelGridBind();
            ClearModel();
            btnAddModel.Visible = false;
        }
    }
    protected void gvModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label id = gvModel.SelectedRow.FindControl("Label2") as Label;
        Session["idModel"] = id.Text;
        txtModel.Text = gvModel.SelectedRow.Cells[1].Text;
        txtSubModel.Text = gvModel.SelectedRow.Cells[2].Text;
        txtBrandName.Text = gvModel.SelectedRow.Cells[3].Text;
        btnUpdateModel.Visible = true;
        btnAddModel.Visible = false;
    }
    protected void btnUpdateModel_Click(object sender, ImageClickEventArgs e)
    {
        if (txtModel.Text == "")
        {
            Messagebox("Please enter Model value");
        }
        else if (txtSubModel.Text == "")
        {
            Messagebox("Please enter SubModel value");
        }
        else if (txtBrandName.Text == "")
        {
            Messagebox("Please enter BrandName value");
        }
        else
        {
             int id = Convert.ToInt32(Session["idModel"].ToString());

             var query = from row in db.ModelMasters where row.Id == id select row;

             query.Single().Model = (txtModel.Text);
             query.Single().SubModel = txtSubModel.Text;
             query.Single().BrandName = txtBrandName.Text;
             db.SubmitChanges();
             Messagebox("Model Value Updated");
             ModelGridBind();
             ClearModel();
             btnUpdateModel.Visible = false;
         }
    }
    protected void txtModel_TextChanged(object sender, EventArgs e)
    {
        btnAddModel.Visible = true;
        btnUpdateModel.Visible = false; 
    }

    //--------------------------------Lathe Master----------------------------------------------

    private void ClearLathe()
    {
        txtLatheNo.Text = "";
        txtToolId.Text = "";
        
    }
    private void LatheGridBind()
    {
        var query = from row in db.LatheMasters select row;
        gvLathe.DataSource = query;
        gvLathe.DataBind();

    }

    protected void btnAddLatheNo_Click(object sender, ImageClickEventArgs e)
    {
        if (txtLatheNo.Text == "")
        {
            Messagebox("Please enter LatheNo value");
        }
        else if (txtToolId.Text == "")
        {
            Messagebox("Please enter ToolId value");
        }
       
        else
        {
            LatheMaster mod = new LatheMaster()
            {
                LatheNo = txtLatheNo.Text,
                ToolId = txtToolId.Text
             
            };
            db.LatheMasters.InsertOnSubmit(mod);
            db.SubmitChanges();
            Messagebox("LatheNo Added");
            LatheGridBind();
            ClearLathe();
            btnAddLatheNo.Visible = false;
        }
    }
    protected void btnUpdateLatheNo_Click(object sender, ImageClickEventArgs e)
    {
        if (txtLatheNo.Text == "")
        {
            Messagebox("Please enter LatheNo value");
        }
        else if (txtToolId.Text == "")
        {
            Messagebox("Please enter ToolId value");
        }

        else
        {
            int id = Convert.ToInt32(Session["idLathe"].ToString());

            var query = from row in db.LatheMasters where row.Id == id select row;

            query.Single().LatheNo = txtLatheNo.Text;
            query.Single().ToolId = txtToolId.Text;
         
            db.SubmitChanges();
            Messagebox("LatheNo Updated");
            LatheGridBind();
            ClearLathe();
            btnUpdateLatheNo.Visible = false;
        }

    }
    protected void gvLathe_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label id = gvLathe.SelectedRow.FindControl("Label3") as Label;
        Session["idLathe"] = id.Text;
        txtLatheNo.Text = gvLathe.SelectedRow.Cells[1].Text;
        txtToolId.Text = gvLathe.SelectedRow.Cells[2].Text;
        btnUpdateLatheNo.Visible = true;
        btnAddLatheNo.Visible = false;
    }
    protected void txtLatheNo_TextChanged(object sender, EventArgs e)
    {
        btnAddLatheNo.Visible = true;
        btnUpdateLatheNo.Visible = false; 
    }


    //--------------------------------Milling Master----------------------------------------------

    private void ClearMilling()
    {
        txtMillingno.Text = "";
    }
    private void MillingGridBind()
    {
        var millno = from row in db.MillingLatheNoMasters select row;
        dgvMilling.DataSource = millno;
        dgvMilling.DataBind();
       
    }

    protected void btnMillingAdd_Click(object sender, ImageClickEventArgs e)
    {
        if (txtMillingno.Text == "")
        {
            Messagebox("Please enter Milling LatheNo value");
        }
        else
        {
            MillingLatheNoMaster mod = new MillingLatheNoMaster()
            {
                MillingLatheNo = txtMillingno.Text
            };
            db.MillingLatheNoMasters.InsertOnSubmit(mod);
            db.SubmitChanges();
            Messagebox("Milling LatheNo Added");
            MillingGridBind();
            ClearMilling();
        }
    }
    protected void btnMillingupdate_Click(object sender, ImageClickEventArgs e)
    {
        if (txtMillingno.Text == "")
        {
            Messagebox("Please enter Milling LatheNo value");
        }
        else
        {
            int id = Convert.ToInt32(Session["idMillig"].ToString());

            var query = from row in db.MillingLatheNoMasters where row.Id == id select row;

            query.Single().MillingLatheNo = txtMillingno.Text;

            db.SubmitChanges();
            Messagebox("Milling LatheNo Updated");
            MillingGridBind();
            ClearMilling();
            btnMillingupdate.Visible = false;
            btnMillingAdd.Visible = true;
        }

    }

    protected void dgvMilling_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label Millid = dgvMilling.SelectedRow.FindControl("Label3") as Label;
        Session["idMillig"] = Millid.Text;
        txtMillingno.Text = dgvMilling.SelectedRow.Cells[1].Text;
        btnMillingupdate.Visible = true;
        btnMillingAdd.Visible = false;
    }
    protected void btnMillingClear_Click(object sender, ImageClickEventArgs e)
    {
        ClearMilling();
        btnMillingAdd.Visible = true;
        btnMillingupdate.Visible = false;
    }
    //================= User admin ==================================//

   
    protected void gvUserAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSuccess.Visible = false;
        btnAddusrAdm.Visible = false;
        var usr = from a in db.Logins select a;
        //Label id = gvUserAdmin.SelectedRow.FindControl("Label1") as Label;
        //Session["Usr"] = id.Text;
        txtUsername.Text = gvUserAdmin.SelectedRow.Cells[1].Text;
        txtPassword.Text = gvUserAdmin.SelectedRow.Cells[2].Text;
        txtUsername.Enabled = false;
        btnChange.Visible = true;
        btnClearChange.Visible = true;
      
    }
   
    private void UserAdmin()
    {
        var que = from a in db.Logins select a;
        gvUserAdmin.DataSource = que;
        gvUserAdmin.DataBind();
    }
    protected void txtUsername_TextChanged(object sender, EventArgs e)
    {
        lblSuccess.Visible = false;
        var name = from a in db.Logins where a.LoginName == txtUsername.Text select a.LoginName;
       
        try
        {
            if (txtUsername.Text == name.Single())
            {
                txtUsername.Text = "";
                Messagebox("UserName Already Exists");
                txtUsername.Focus();
                btnAddusrAdm.Visible = false;
            }
            else
            {
                txtUsername.Visible = true;
                btnAddusrAdm.Visible = true;
            }
        }
        catch
        {
            lblSuccess.Visible = true;
            lblSuccess.Text = "UserName Available";
            txtPassword.Focus();
            btnAddusrAdm.Visible = true;
           
        }
    }
  

    private void ClearUsrAcc()
    {
        txtUsername.Text = "";
        txtPassword.Text = "";
    }


    protected void btnClearChange_Click(object sender, ImageClickEventArgs e)
    {
        txtUsername.Text = "";
        txtPassword.Text = "";
        txtUsername.Enabled = true;
        btnChange.Visible = false;
        btnClearChange.Visible = false;
    }

    
protected void  btnChange_Click(object sender, ImageClickEventArgs e)
{
    var update = from a in db.Logins where a.LoginName == txtUsername.Text select a;

    update.Single().Password = txtPassword.Text;
    db.SubmitChanges();
    UserAdmin();

    btnChange.Visible = false;
    ClearUsrAcc();
    txtUsername.Enabled = true;
    btnClearChange.Visible = false;
}

    

protected void btnAddusrAdm_Click(object sender, ImageClickEventArgs e)
{
    Login log = new Login();
    lblSuccess.Visible = false;
    log.LoginName = txtUsername.Text;
    log.Password = txtPassword.Text;
    db.Logins.InsertOnSubmit(log);
    db.SubmitChanges();
    ClearUsrAcc();
    UserAdmin();
    btnAddusrAdm.Visible = false;
}

protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
{
    txtUsername.Text = "";
    txtPassword.Text = "";
    txtLatheNo.Text = "";
    txtToolId.Text = "";
    txtModel.Text = "";
    txtSubModel.Text = "";
    txtBrandName.Text = "";
    txtPower.Text = "";
    txtRadius1.Text = "";
    txtRadius2.Text = "";
    txtMillingno.Text = "";
}

 }
