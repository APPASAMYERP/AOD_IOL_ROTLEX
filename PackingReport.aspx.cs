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

public partial class PackingReport : System.Web.UI.Page
{

    #region Declarations

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext SL = new SoftLensDataContext();
    int temp;

    #endregion

    

    #region Methods

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void clear()
    {
        txtGlassyNo.Text = "";
        txtTumblingNo.Text = "";
        txtModelNo.Text = "";
        txtPower.Text = "";
        txtTotalQty.Text="";
        txtDate.Text = "";
        txtJarNo.Text = "";
        txtAcceptedQty.Text = "";
        txtRetumblingQty.Text ="0";
        txtRejectedQty.Text = "";
        ddlShift.SelectedValue = "Select";
        txtRemarks.Text = "";
        txtApprovedBy.Text = "";
        
    }

    protected void txtJarNo_TextChanged(object sender, EventArgs e)
    {
        string j = txtJarNo.Text;
        txtJarNo.Text = j.ToUpper();
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string re = txtRemarks.Text;
        txtRemarks.Text = re.ToUpper();
        
    }


    protected void txtApprovedBy_TextChanged(object sender, EventArgs e)
    {
        string a = txtApprovedBy.Text;
        txtApprovedBy.Text = a.ToUpper();

    }

    protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
    {
       
            if (Convert.ToInt32(txtAcceptedQty.Text) > Convert.ToInt32(txtTotalQty.Text))
            {
                Messagebox("Value is Greater than Total Qty");
                txtAcceptedQty.Text = "";
                txtAcceptedQty.Focus();
            }
            else 
            {
                
            }
        
    }

    protected void txtRetumblingQty_TextChanged1(object sender, EventArgs e)
    {

        if(Convert.ToInt32(txtRetumblingQty.Text) > Convert.ToInt32(txtAcceptedQty.Text))
        {
            Messagebox("Value is Greater than Accepted Qty");
            txtRetumblingQty.Text = "";
            txtRetumblingQty.Focus();
        }
        else
        {
            if (txtRetumblingQty.Text != "0")
            {
                txtRejectedQty.Text = (Convert.ToInt32(txtTotalQty.Text) - (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumblingQty.Text))).ToString();
            }
            else
            {
                txtRejectedQty.Text = (Convert.ToInt32(txtTotalQty.Text) - (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumblingQty.Text))).ToString();
         
            }

            

        }

    }

    private  void GridBind()
    {
        var q= from a in SL.FirstRetumblingReports where a.GlassyNo==txtGlassyNo.Text select a;
        gvPackingReports.DataSource = q;
        gvPackingReports.DataBind();

    }

    private bool validation1()
    {
        bool _isvalid = true;

        if (txtGlassyNo.Text== "")
        {
            Messagebox("Please enter Glassy Tumbling Ref No");
            txtGlassyNo.Focus();
            _isvalid = false;
        }
        else if (txtJarNo.Text == "")
        {
            Messagebox("Please enter JarNo");
            txtJarNo.Focus();
            _isvalid = false;
        }
        else if (txtAcceptedQty.Text == "")
        {
            Messagebox("Please enter Accepted Qty");
            txtAcceptedQty.Focus();
            _isvalid = false;
        }
        else if (txtRetumblingQty.Text=="")
        {
            Messagebox("Please enter Retumbling Qty");
            txtRetumblingQty.Focus();
            _isvalid = false;
        }
        else if (txtRejectedQty.Text == "")
        {
            Messagebox("Please Enter the Rejected Qty");
            txtRejectedQty.Focus();
            _isvalid = false;
        }
        else if (txtApprovedBy.Text== "")
        {
            Messagebox("Please enter the Approved By");
            txtApprovedBy.Focus();
            _isvalid = false;
        }
       
        return _isvalid;
 
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

    protected void txtGlassyNo_TextChanged(object sender, EventArgs e)
    {
        string t = txtGlassyNo.Text;
        txtGlassyNo.Text = t.ToUpper();
        gvPackingReports.DataSource = null;
        gvPackingReports.DataBind();
        var query3 = from row in SL.FirstRetumblingReports where row.GlassyNo == txtGlassyNo.Text select row;
        if (query3.Count() > 0)
        {
            gvPackingReports.DataSource = query3;
            gvPackingReports.DataBind();
            btnSave.Visible = false;
            btnClear.Visible = true;
        }
        else
        {
            var query1 = from row in SL.PowerSegregationChilds where row.GlassyRecordRef == txtGlassyNo.Text select row;
            if (query1.Count() > 0)
            {
                txtTumblingNo.Text = query1.Single().TumblingNo.ToString();
                txtPower.Text = query1.Single().Power.ToString();
                txtTotalQty.Text = query1.Single().Qty.ToString();
                var query2 = from row in SL.RemattTumblingLens where row.RetumblingRef1 == txtTumblingNo.Text select row;
                var query4 = from row in SL.RemattTumblingLens where row.RetumblingRef2 == txtTumblingNo.Text select row;
                if (query2.Count() > 0)
                {
                    txtModelNo.Text = query2.Single().Model1.ToString();
                }
                else if (query4.Count() > 0)
                {
                    txtModelNo.Text = query4.Single().Model2.ToString();
                }

                Shift();
                btnSave.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                Messagebox("Enter a valid Glassy Record Ref No");
                txtGlassyNo.Text = "";
                txtGlassyNo.Focus();
            }
        }
    }


    private void SaveMethod()
    {
       
        FirstRetumblingReport fr = new FirstRetumblingReport();
        fr.GlassyNo = txtGlassyNo.Text;
        fr.TumblingNo = txtTumblingNo.Text;
        fr.Model = txtModelNo.Text;
        fr.Power = Convert.ToDecimal(txtPower.Text);
        fr.TotalQty = Convert.ToInt32(txtTotalQty.Text);
        fr.Date=Convert.ToDateTime(txtDate.Text, provider);
        fr.JarNo = txtJarNo.Text;
        fr.AcceptedQty = Convert.ToInt32(txtAcceptedQty.Text);
        fr.RetumblingQty = Convert.ToInt32(txtRetumblingQty.Text);
        fr.RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
        fr.Shift = ddlShift.SelectedValue;
        fr.Remarks = txtRemarks.Text;
        fr.ApprovedBy = txtApprovedBy.Text;

        SL.FirstRetumblingReports.InsertOnSubmit(fr);
        SL.SubmitChanges();
        btnSave.Visible = false;
        Messagebox("Saved Successfully");     

    }



    #endregion


    

    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    //    if (Page.IsPostBack)
    //    {
    //        WebControl wcICausedPostBack = (WebControl)GetControlThatCausedPostBack(sender as Page);
    //        int indx = wcICausedPostBack.TabIndex;
    //        var ctrl = from control in wcICausedPostBack.Parent.Controls.OfType<WebControl>()
    //                   where control.TabIndex > indx
    //                   select control;
    //        ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus();
    //    }
    //}
    //protected Control GetControlThatCausedPostBack(Page page)
    //{
    //    Control control = null;
    //    string ctrlname = page.Request.Params.Get("__EVENTTARGET");
    //    if (ctrlname != null && ctrlname != string.Empty)
    //    {
    //        control = page.FindControl(ctrlname);
    //    }
    //    else
    //    {
    //        foreach (string ctl in page.Request.Form)
    //        {
    //            Control c = page.FindControl(ctl);
    //            if (c is System.Web.UI.WebControls.Button || c is System.Web.UI.WebControls.ImageButton)
    //            {
    //                control = c;
    //                break;
    //            }
    //        }
    //    }
    //    return control; 

    }




    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
      
            SaveMethod();
            
            GridBind();
            clear();
            btnClear.Visible = false;
            txtGlassyNo.Text = "";
            
        
        
    }

    protected void btnClear_Click1(object sender, ImageClickEventArgs e)
    {
        clear();
        txtGlassyNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
        gvPackingReports.DataSource = null;
        gvPackingReports.DataBind();

    }
      
    #endregion



    protected void txtRetumblingQty_TextChanged(object sender, EventArgs e)
    {
       
            txtRejectedQty.Text = (Convert.ToInt32(txtTotalQty.Text) - (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumblingQty.Text))).ToString();
            temp = Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumblingQty.Text) + Convert.ToInt32(txtRejectedQty.Text);
            if (txtTotalQty.Text != temp.ToString())
            {
                Messagebox("Value exceeds Total Quantity");
            }
       
        

    }


}
