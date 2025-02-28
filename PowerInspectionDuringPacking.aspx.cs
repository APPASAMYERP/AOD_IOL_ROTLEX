using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PowerInspectionDuringPacking : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    private void view(string tno)
    {
        SoftLensDataContext SL = new SoftLensDataContext();
        var q = from f in SL.Inprocess_Power_Inspections
                where f.TumblingLotNo1 == tno
                select f;
        GridView1.DataSource = q;
        GridView1.DataBind();
   
        if (q.Count() > 0)
        {
            GridView1.DataSource = q;
            GridView1.DataBind();
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        else
        {
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
           
        }
    }
    private void clear()
    {
       
        ddlPower.Text = "Select";
        txtTmbLotNo1Smp11.Text = "";
        txtTmbLotNo1Smp21.Text = "";
        txtTmpLotNo1Smp31.Text = "";
        txtTmbLotNoSmp41.Text = "";
        txtTmbLotNoSMP51.Text = "";
        txtTmbLotNo1Rmks1.Text = "";
        txtTmbLotNo1InpBy1.Text = "";
        txtTmbLotNo1Dt1.Text = "";
        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    protected void txtTmbLotNo1_TextChanged(object sender, EventArgs e)
    {
        clear();
            string t = txtTmbLotNo1.Text;
            txtTmbLotNo1.Text = t.ToUpper();
        btnClear.Visible = true;
        txtTmbLotNo1Dt1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        SoftLensDataContext db = new SoftLensDataContext();
        
        ddlPower.Items.Clear();
        ddlPower.Items.Add("Select");
        var seg = from a in db.PowerSegregationChilds
                  where a.TumblingNo == txtTmbLotNo1.Text
                  select a;

        ddlPower.DataSource = seg;
        ddlPower.DataTextField = "Power";
        ddlPower.DataBind();

        
        

        view(txtTmbLotNo1.Text);

    }

    
   
  
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlPower.Text == "Select")
        {
            Messagebox("Please select Power");
            ddlPower.Focus();
        }
        else if (txtTmbLotNo1InpBy1.Text == "")
        {
            Messagebox("Please enter Inspected By");
            txtTmbLotNo1InpBy1.Focus();
        }
        else if (txtTmbLotNo1Smp11.Text == "")
        {
            Messagebox("Please enter Sample1");
            txtTmbLotNo1Smp11.Focus();
        }
        else if (txtTmbLotNo1Smp21.Text == "")
        {
            Messagebox("Please enter Sample2");
            txtTmbLotNo1Smp21.Focus();
        }
        else if (txtTmpLotNo1Smp31.Text == "")
        {
            Messagebox("Please enter Sample3");
            txtTmpLotNo1Smp31.Focus();
        }
        else if (txtTmbLotNoSmp41.Text == "")
        {
            Messagebox("Please enter Sample4");
            txtTmbLotNoSmp41.Focus();
        }
        else if (txtTmbLotNoSMP51.Text == "")
        {
            Messagebox("Please enter Sample5");
            txtTmbLotNoSMP51.Focus();
        }
        else
        {

            try
            {

                SoftLensDataContext SL = new SoftLensDataContext();

                Inprocess_Power_Inspection IP = new Inprocess_Power_Inspection();
                IP.TumblingLotNo1 = txtTmbLotNo1.Text;

                IP.Tumbling1Power1 = Convert.ToDecimal(ddlPower.Text);


                IP.Tumbling11Sample1 = Convert.ToDecimal(txtTmbLotNo1Smp11.Text);

                IP.Tumbling21Sample1 = Convert.ToDecimal(txtTmbLotNo1Smp21.Text);

                IP.Tumbling31Sample1 = Convert.ToDecimal(txtTmpLotNo1Smp31.Text);


                IP.Tumbling41Sample1 = Convert.ToDecimal(txtTmbLotNoSmp41.Text);


                IP.Tumbling51Sample1 = Convert.ToDecimal(txtTmbLotNoSMP51.Text);

                IP.Tumbling1Remarks1 = txtTmbLotNo1Rmks1.Text;

                IP.Tumbling1InspectedBy = txtTmbLotNo1InpBy1.Text;


                IP.Tumbling1Date1 = Convert.ToDateTime(txtTmbLotNo1Dt1.Text,provider);

                SL.Inprocess_Power_Inspections.InsertOnSubmit(IP);
                SL.SubmitChanges();

                Messagebox("Saved Successfully");
                btnClear.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                clear();
                var q = from f in SL.Inprocess_Power_Inspections
                        where f.TumblingLotNo1 == txtTmbLotNo1.Text
                        select f;
                GridView1.DataSource = q;
                GridView1.DataBind();
                txtTmbLotNo1.Text = "";
            }
            catch (Exception)
            {

            }
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlPower.Text == "Select")
        {
            Messagebox("Please select Power");
            ddlPower.Focus();
        }
        else if (txtTmbLotNo1InpBy1.Text == "")
        {
            Messagebox("Please enter Inspected By");
            txtTmbLotNo1InpBy1.Focus();
        }
        else if (txtTmbLotNo1Smp11.Text == "")
        {
            Messagebox("Please enter Sample1");
            txtTmbLotNo1Smp11.Focus();
        }
        else if (txtTmbLotNo1Smp21.Text == "")
        {
            Messagebox("Please enter Sample2");
            txtTmbLotNo1Smp21.Focus();
        }
        else if (txtTmpLotNo1Smp31.Text == "")
        {
            Messagebox("Please enter Sample3");
            txtTmpLotNo1Smp31.Focus();
        }
        else if (txtTmbLotNoSmp41.Text == "")
        {
            Messagebox("Please enter Sample4");
            txtTmbLotNoSmp41.Focus();
        }
        else if (txtTmbLotNoSMP51.Text == "")
        {
            Messagebox("Please enter Sample5");
            txtTmbLotNoSMP51.Focus();
        }
        else
        {
            try
            {

                SoftLensDataContext SL = new SoftLensDataContext();
                var q = from f in SL.Inprocess_Power_Inspections where f.TumblingLotNo1 == txtTmbLotNo1.Text && f.Id == Convert.ToInt32(Session["id"].ToString()) select f;
                if (q.Count() > 0)
                {
                    q.Single().Tumbling1Power1 = Convert.ToDecimal(ddlPower.Text);
                    q.Single().Tumbling11Sample1 = Convert.ToDecimal(txtTmbLotNo1Smp11.Text);
                    q.Single().Tumbling21Sample1 = Convert.ToDecimal(txtTmbLotNo1Smp21.Text);
                    q.Single().Tumbling31Sample1 = Convert.ToDecimal(txtTmpLotNo1Smp31.Text);
                    q.Single().Tumbling41Sample1 = Convert.ToDecimal(txtTmbLotNoSmp41.Text);
                    q.Single().Tumbling51Sample1 = Convert.ToDecimal(txtTmbLotNoSMP51.Text);
                    q.Single().Tumbling1Remarks1 = txtTmbLotNo1Rmks1.Text;
                    q.Single().Tumbling1InspectedBy = txtTmbLotNo1InpBy1.Text;
                    q.Single().Tumbling1Date1 = Convert.ToDateTime(txtTmbLotNo1Dt1.Text, provider);
                    SL.SubmitChanges();

                    Messagebox("Update SuccessFully");
                    btnClear.Visible = false;
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                    clear();

                    var q1 = from f in SL.Inprocess_Power_Inspections
                             where f.TumblingLotNo1 == txtTmbLotNo1.Text
                             select f;
                    GridView1.DataSource = q1;
                    GridView1.DataBind();
                    txtTmbLotNo1.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Label id = (Label)GridView1.SelectedRow.FindControl("Label1");
            Session["id"] = id.Text;
            txtTmbLotNo1.Text = GridView1.SelectedRow.Cells[2].Text;
            ddlPower.Text = GridView1.SelectedRow.Cells[3].Text;
            txtTmbLotNo1Smp11.Text = GridView1.SelectedRow.Cells[4].Text;
            txtTmbLotNo1Smp21.Text = GridView1.SelectedRow.Cells[5].Text;
            txtTmpLotNo1Smp31.Text = GridView1.SelectedRow.Cells[6].Text;
            txtTmbLotNoSmp41.Text = GridView1.SelectedRow.Cells[7].Text;
            txtTmbLotNoSMP51.Text = GridView1.SelectedRow.Cells[8].Text;
            txtTmbLotNo1Rmks1.Text = GridView1.SelectedRow.Cells[9].Text;
            txtTmbLotNo1InpBy1.Text = GridView1.SelectedRow.Cells[10].Text;
            txtTmbLotNo1Dt1.Text = GridView1.SelectedRow.Cells[11].Text;

            if (txtTmbLotNo1Rmks1.Text == "&nbsp;")
            {
                txtTmbLotNo1Rmks1.Text = "";
            }
            btnUpdate.Visible = true;
            btnClear.Visible = true;
            btnSave.Visible = false;

        }
        catch (Exception)
        {

        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtTmbLotNo1.Text = "";
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }
    protected void txtTmbLotNo1InpBy1_TextChanged(object sender, EventArgs e)
    {
        string up = txtTmbLotNo1InpBy1.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtTmbLotNo1InpBy1.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: M.BALAJI");
                txtTmbLotNo1InpBy1.Text = "";
                txtTmbLotNo1InpBy1.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtTmbLotNo1InpBy1.Text = "";
            txtTmbLotNo1InpBy1.Focus();
        }
    }
    protected void txtTmbLotNo1Rmks1_TextChanged(object sender, EventArgs e)
    {

        string up = txtTmbLotNo1Rmks1.Text;
        txtTmbLotNo1Rmks1.Text = up.ToUpper();  
    }
    protected void txtTmbLotNo1Smp11_TextChanged(object sender, EventArgs e)
    {
        string s1 = txtTmbLotNo1Smp11.Text;
        try
        {
            if (s1[3] == '.' || s1[2] == '.')
            {
            }
            else
            {
                Messagebox("Please Enter in this format ex: 05.50");
                txtTmbLotNo1Smp11.Text = "";
                txtTmbLotNo1Smp11.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtTmbLotNo1Smp11.Text = "";
            txtTmbLotNo1Smp11.Focus();
        }
    }
    protected void txtTmbLotNo1Smp21_TextChanged(object sender, EventArgs e)
    {
        string s2 = txtTmbLotNo1Smp21.Text;
        try
        {
            if (s2[3] == '.' || s2[2] == '.')
            {
            }
            else
            {
                Messagebox("Please Enter in this format ex: 05.50");
                txtTmbLotNo1Smp21.Text = "";
                txtTmbLotNo1Smp21.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtTmbLotNo1Smp21.Text = "";
            txtTmbLotNo1Smp21.Focus();
        }
    }
    protected void txtTmpLotNo1Smp31_TextChanged(object sender, EventArgs e)
    {
        string s3 = txtTmpLotNo1Smp31.Text;
        try
        {
            if (s3[3] == '.' || s3[2] == '.')
            {
            }
            else
            {
                Messagebox("Please Enter in this format ex: 05.50");
                txtTmpLotNo1Smp31.Text = "";
                txtTmpLotNo1Smp31.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtTmpLotNo1Smp31.Text = "";
            txtTmpLotNo1Smp31.Focus();
        }
    }
    protected void txtTmbLotNoSmp41_TextChanged(object sender, EventArgs e)
    {
        string s4 = txtTmbLotNoSmp41.Text;
        try
        {
            if (s4[3] == '.' || s4[2] == '.')
            {
            }
            else
            {
                Messagebox("Please Enter in this format ex: 05.50");
                txtTmbLotNoSmp41.Text = "";
                txtTmbLotNoSmp41.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtTmbLotNoSmp41.Text = "";
            txtTmbLotNoSmp41.Focus();
        }
    }
    protected void txtTmbLotNoSMP51_TextChanged(object sender, EventArgs e)
    {
        string s5 = txtTmbLotNoSMP51.Text;
        try
        {
            if (s5[3] == '.' || s5[2] == '.')
            {
            }
            else
            {
                Messagebox("Please Enter in this format ex: 05.50");
                txtTmbLotNoSMP51.Text = "";
                txtTmbLotNoSMP51.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter in this format ex: 05.50");
            txtTmbLotNoSMP51.Text = "";
            txtTmbLotNoSMP51.Focus();
        }
    }
}