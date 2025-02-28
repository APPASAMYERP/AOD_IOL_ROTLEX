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

public partial class LotResult1stCut : System.Web.UI.Page
{


    #region Declarations
    public string idno;
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    #endregion Declarations

    #region Methods 
    protected void clear()
    {
        txtInspectedBy.Text = "";
        //txtDate.Text = "";
        
        txtBalanceQuantity.Text = "";
        txtReceivedQuantity.Text = "";
        txtFinishedQuantity.Text = "";
        txtRemarks.Text = "";
        txtRejectedQuantity.Text = "";
        txtAcceptedQuantity.Text = "";
        drpShift.SelectedValue = "Select";
        gvLotResult.DataSource = null;
        gvLotResult.DataBind();
        
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    protected void shift()
    {
        String time = DateTime.Now.Hour.ToString();
        //lblMessage2.Text = time;
        if (Convert.ToInt32(time) >= 6 && Convert.ToInt32(time) <= 13)
        {
            drpShift.SelectedIndex = 1;

        }
        if (Convert.ToInt32(time) >= 14 && Convert.ToInt32(time) <= 22)
        {
            drpShift.SelectedIndex = 2;

        }
        if (Convert.ToInt32(time) >= 22 && Convert.ToInt32(time) <= 5)
        {
            drpShift.SelectedIndex = 3;

        }
    } 
    
    private void lotnogridbind(string lotno)
    {
        if (txtLotNo.Text.Length > Convert.ToInt32(Session["LotNoMaxLength"]))
        {
            Messagebox("Enter " + Session["LotNoMaxLength"] + " digit No In correct Format ex:" + Session["CurrentYear"] + Session["CurrentMonth"] + Session["LotNoFormat"]);
            txtLotNo.Text = "";
            txtLotNo.Focus();
        }     

        SoftLensDataContext db = new SoftLensDataContext();
        LotResult lotres = new LotResult();
        btnUpdate.Visible = false;
        btnClear.Visible = true;
        clear();
        var query = from row in db.LotResults where row.LotNo == lotno select row;
        gvLotResult.DataSource = query;
        gvLotResult.DataBind();
        try
        {
            var query1 = from r in db.BatchAllots where r.LotNo == txtLotNo.Text select r; 
            var que = (from req in db.MillingCleanedLens  where req.LotNo == txtLotNo.Text select req.AcceptedQuantity).Sum();

            if (que== null)
            {
                txtLotNo.Focus();
                Messagebox("Before Process Might Not be Completed");
                txtLotNo.Text = "";
            }   
            else
            {
               txtReceivedQuantity.Text = Convert.ToInt32(query1.Single().AllotedQuantity).ToString();
                txtFinishedQuantity.Focus();
                //btnSave.Visible = false;
            }               
            
            try
            {
                var query3 = (from row3 in db.LotResults where row3.LotNo == txtLotNo.Text  select row3.FinishedQuantity).Sum();
                if (query3.Value < Convert.ToInt32(txtReceivedQuantity.Text))
                {
                    txtFinishedQuantity.Enabled = true;
                    btnSave.Visible = false;
                }
                else
                {
                    //txtFinishedQuantity.Enabled = false;
                    btnSave.Visible = false;
                }
                int val = Convert.ToInt32(txtReceivedQuantity.Text) - query3.Value;
               
                txtBalanceQuantity.Text = Convert.ToString(val);
            }

            catch
            {
            }
        }
        
        catch
        {
        }
        
     }

    private bool  Validation()
    {
        bool _isvalid = true;
        if (txtLotNo.Text == "")
        {
            Messagebox("Please Enter Lot No ");
            txtLotNo.Focus();
            _isvalid = false;
        }
        else if (txtFinishedQuantity.Text == "")
        {
            Messagebox("Please Enter Finished Qty ");
            txtFinishedQuantity.Focus();
            _isvalid = false;
        }
        else if (txtAcceptedQuantity.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtAcceptedQuantity.Focus();
            _isvalid = false;
        }
        else if (txtInspectedBy.Text == "")
        {
            Messagebox("Please Enter InSpectedBy");
            txtInspectedBy.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }

    private void Save()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        LotResult lotres = new LotResult();

        lotres.LotNo = txtLotNo.Text;
        lotres.ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
        lotres.FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
        lotres.AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
        lotres.BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);
        lotres.RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);
        lotres.Remarks = txtRemarks.Text;
        lotres.Shift = drpShift.Text;
        lotres.InspectedBy = Convert.ToString(txtInspectedBy.Text);
        lotres.Date = Convert.ToDateTime(txtDate.Text, provider);

        db.LotResults.InsertOnSubmit(lotres);
        db.SubmitChanges();
        Messagebox("Saved  Successfully");
    }

    private void Update()
    {

        SoftLensDataContext db = new SoftLensDataContext();
        //LotResult lotres = new LotResult();
        idno = Session["ID"].ToString();
        var lotres = from b in db.LotResults where b.IdNo == Convert.ToInt32(idno) select b;
        lotres.Single().LotNo = txtLotNo.Text;

        lotres.Single().FinishedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
        lotres.Single().AcceptedQuantity = Convert.ToInt32(txtAcceptedQuantity.Text);
        lotres.Single().BalanceQuantity = Convert.ToInt32(txtBalanceQuantity.Text);
        lotres.Single().ReceivedQuantity = Convert.ToInt32(txtFinishedQuantity.Text);
        lotres.Single().RejectedQuantity = Convert.ToInt32(txtRejectedQuantity.Text);

        lotres.Single().Remarks = txtRemarks.Text;
        lotres.Single().Shift = drpShift.Text;
        lotres.Single().InspectedBy = Convert.ToString(txtInspectedBy.Text);
        lotres.Single().Date = Convert.ToDateTime(txtDate.Text, provider);

        db.SubmitChanges();
        Messagebox("Updated Successfully");
    }

    private void GridBind()
    {
        SoftLensDataContext db = new SoftLensDataContext();
        var query = from row in db.LotResults where row.LotNo == txtLotNo.Text select row;
        gvLotResult.DataSource = query;
        gvLotResult.DataBind();
    }

    #endregion Methods

    #region Events
    protected void Page_Load(object sender, EventArgs e)
     {
         txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
         if (!IsPostBack)
         {
             shift();
         }
         if (Session["Location"].ToString() == "Chennai")
         {
             txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
             txtFinishedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
             txtAcceptedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);

             //txtLotNo_FilteredTextBoxExtender.FilterType = FilterTypes.Custom;
             //txtLotNo_FilteredTextBoxExtender.ValidChars = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
             
         }
         else if (Session["Location"].ToString() == "Pondicherry")
         {
             txtLotNo.MaxLength = Convert.ToInt32(Session["LotNoMaxLength"]);
             txtFinishedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
             txtAcceptedQuantity.MaxLength = Convert.ToInt32(Session["AllotededMaxLength"]);
         }
     }

    protected void  txtLotNo_TextChanged(object sender, EventArgs e)
{
         btnSave.Visible = true;
         btnClear.Visible = true;
         txtFinishedQuantity.Enabled = true;
         lotnogridbind(txtLotNo.Text);
}

    
    protected void txtAcceptedQuantity_TextChanged(object sender, EventArgs e)
    {
        if (txtFinishedQuantity.Text != "" && txtAcceptedQuantity.Text != "")
        {
            if (Convert.ToInt32(txtAcceptedQuantity.Text) > Convert.ToInt32(txtFinishedQuantity.Text))
            {
                Messagebox("Value is Greater than Finished Qty");
                txtAcceptedQuantity.Text = "";
                txtAcceptedQuantity.Focus();
            }
            else
            {
                txtRejectedQuantity.Text = (Convert.ToInt32(txtFinishedQuantity.Text) - Convert.ToInt32(txtAcceptedQuantity.Text)).ToString();
                txtRemarks.Focus();
            }
        }
        else
        {
            Messagebox("Please Enter the Finished Quantity");
            txtAcceptedQuantity.Text = "";
            txtFinishedQuantity.Focus();
        }
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    
    protected void gvDeblocking_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvLotResult.Rows.Count - 1 == gvLotResult.SelectedRow.RowIndex && Session["up"].Equals(1))
        {
        btnSave.Visible = false;
        btnClear.Visible = true;
            
        txtFinishedQuantity.Enabled = true;
        SoftLensDataContext db = new SoftLensDataContext();
        Label id = (Label)gvLotResult.SelectedRow.FindControl("Label1");
        Session["ID"] = id.Text;
        txtLotNo.Text = gvLotResult.SelectedRow.Cells[2].Text;
        txtReceivedQuantity.Text = gvLotResult.SelectedRow.Cells[3].Text;
        txtFinishedQuantity.Text = gvLotResult.SelectedRow.Cells[4].Text;
        txtAcceptedQuantity.Text = gvLotResult.SelectedRow.Cells[5].Text;
        txtRejectedQuantity.Text = gvLotResult.SelectedRow.Cells[6].Text;
        txtBalanceQuantity.Text = gvLotResult.SelectedRow.Cells[7].Text;
        txtRemarks.Text = gvLotResult.SelectedRow.Cells[8].Text;
        if (txtRemarks.Text == "&nbsp;")
        {
            txtRemarks.Text = "";
        }
        txtInspectedBy.Text = gvLotResult.SelectedRow.Cells[9].Text;
        drpShift.Text = gvLotResult.SelectedRow.Cells[10].Text;
        txtDate.Text = gvLotResult.SelectedRow.Cells[11].Text;
     
        btnUpdate.Visible = true;
       }
        else
        {
            Messagebox("This Row values cannot be Updated & Permission is denied");
            clear();
            btnUpdate.Visible = false;
        }
     
    }

    protected void txtFinishedQuantity_TextChanged1(object sender, EventArgs e)
    {
        txtAcceptedQuantity.Text = "";
        btnClear.Visible = true;
        shift();
        btnClear.Visible = true;
        SoftLensDataContext db = new SoftLensDataContext();
        if (txtFinishedQuantity.Text != "")
        {
            if (btnUpdate.Visible == true)
            {
                int val = (Convert.ToInt32(txtReceivedQuantity.Text) - Convert.ToInt32(txtFinishedQuantity.Text));
                if (val < 0)
                {
                    Messagebox("Value is Greater than Received Qty");
                    txtFinishedQuantity.Text = "";
                    txtFinishedQuantity.Focus();
                }
                else
                {
                    txtBalanceQuantity.Text = val.ToString();
                    txtAcceptedQuantity.Text = "";
                    txtAcceptedQuantity.Focus();
                }

            }
            else
            {
                var query3 = (from row3 in db.LotResults where row3.LotNo == txtLotNo.Text select row3.FinishedQuantity).Sum();

                int sumofFinishedQty = 0;
                if (query3 != null)
                {
                    sumofFinishedQty = query3.Value;
                }

                if (Convert.ToInt32(txtFinishedQuantity.Text) > Convert.ToInt32(txtReceivedQuantity.Text))
                {
                    Messagebox(" Finished Qty eXceeds Received Qty ");
                    txtFinishedQuantity.Text = "";
                    txtFinishedQuantity.Focus();
                }
                else
                {
                    int val = (Convert.ToInt32(txtReceivedQuantity.Text) - (sumofFinishedQty + Convert.ToInt32(txtFinishedQuantity.Text)));
                    if (val < 0)
                    {
                        txtFinishedQuantity.Text = "";
                        Messagebox("Value is Greater than Received Qty");
                        txtFinishedQuantity.Focus();
                    }
                    else
                    {
                        txtBalanceQuantity.Text = val.ToString();
                        txtAcceptedQuantity.Focus();
                    }
                }
            }
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        
        if(Validation())
        {
            Save();
            txtLotNo.Focus();
            btnClear.Visible = false;
            btnSave.Visible = false;
            clear();
            GridBind();
            txtLotNo.Text = "";
        }

    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            Update();
            txtLotNo.Focus();
            clear();
            GridBind();
            btnUpdate.Visible = false;
            btnClear.Visible = false;
            txtLotNo.Text = "";
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        btnClear.Visible = false;
    }

    protected void txtInspectedBy_TextChanged(object sender, EventArgs e)
    {

        string up = txtInspectedBy.Text;
        if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
        {
            txtInspectedBy.Text = up.ToUpper();
        }
        else
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtInspectedBy.Text = "";
            txtInspectedBy.Focus();

        }
    }

    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
        txtInspectedBy.Focus();
    }
    #endregion Events


}
