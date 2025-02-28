using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

using System.Configuration;
using System.Text.RegularExpressions;

public partial class BtchforMould : System.Web.UI.Page
{
    #region Declaration
    SoftLensDataContext SL = new SoftLensDataContext();
    IOL_ERPDataContext ml = new IOL_ERPDataContext();
    PouchDataContext db2 = new PouchDataContext();
    string strconn = ConfigurationManager.ConnectionStrings["MOULDING_ERPConnectionString"].ConnectionString;
    string strconn1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
    string strconn2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
    string strconn3 = ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString;

    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    #endregion Declaration

    #region Event

    protected void Page_Load(object sender, EventArgs e)
    {
        var username = (Session["Username"] as HtmlInputControl).Value;

        if (username == null)
        {
            Response.Redirect("404Page.aspx");
        }
        if (!IsPostBack)
        {
           
            txtdate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
           // Bind_Reflot();
            Bind_Brand_Name();

        }
    }
//    protected void Bind_Reflot()
//    {

//        string connectionStringMouldingERP = ConfigurationManager.ConnectionStrings["MOULDING_ERPConnectionString"].ConnectionString;
//        string connectionStringMoulding = ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString;

//        string optimizedQuery = @"
//        SELECT Reflot
//        FROM Moulding_Rejection
//        WHERE (Process_code = 'PHO PI 011-2') 
//          AND (flag = 2) 
//          AND (NOT EXISTS (
//            SELECT 1 
//            FROM MOULDING.dbo.NewBtchAllot
//            WHERE ISNULL(Reflot, '') COLLATE SQL_Latin1_General_CP1_CI_AS = Moulding_Rejection.Reflot
//               OR ISNULL(LotNo, '') COLLATE SQL_Latin1_General_CP1_CI_AS = Moulding_Rejection.Reflot)) ORDER BY Reflot";

//        DataTable filteredReflots = new DataTable();

//        try
//        {
//            using (SqlConnection connection = new SqlConnection(connectionStringMouldingERP))
//            {
//                connection.Open();

//                using (SqlCommand command = new SqlCommand(optimizedQuery, connection))
//                {
//                    SqlDataAdapter adapter = new SqlDataAdapter(command);
//                    adapter.Fill(filteredReflots);
//                }
//            }

//            // Bind the DataTable to the dropdown list
//            txtlotno.DataSource = filteredReflots;
//            txtlotno.DataTextField = "Reflot";
//            txtlotno.DataValueField = "Reflot";
//            txtlotno.DataBind();

//            // Optionally add a default item
//            txtlotno.Items.Insert(0, new ListItem("--Select Reflot--", ""));
//        }
//        catch (Exception ex)
//        {
//            // Handle exceptions here
//            Console.WriteLine("Error: " + ex.Message);
//        }

//    }
   
    protected void txtlotno_TextChanged(object sender, EventArgs e)
    {
        gridview1.DataSource = null;
        gridview1.DataBind();
        string lot = txtlotno.Text;
        txtlotno.Text = lot.ToUpper();
        GridBind();
        drpshift.Focus();
    }
    protected void Bind_Brand_Name()
    {

        List<string> brandNames = new List<string>();
        // Fetch data from first data source
        string strconn1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
        using (SqlConnection connection1 = new SqlConnection(strconn1))
        {
            string query1 = "Select distinct Brand_Name from LENS_MASTER";
            SqlCommand cmd1 = new SqlCommand(query1, connection1);
            connection1.Open();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string brandName = reader1["Brand_Name"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader1.Close();
        }

        // Fetch data from second data source
        string strconn2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
        using (SqlConnection connection2 = new SqlConnection(strconn2))
        {
            string query2 = "Select distinct Brand_Name from LENS_MASTER";
            SqlCommand cmd2 = new SqlCommand(query2, connection2);
            connection2.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string brandName = reader2["Brand_Name"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader2.Close();
        }

        // Fetch data from third data source
        string strconn3 = ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString;
        using (SqlConnection connection3 = new SqlConnection(strconn3))
        {
            string query3 = "Select distinct Brand_Name from LENS_MASTER";
            SqlCommand cmd3 = new SqlCommand(query3, connection3);
            connection3.Open();
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string brandName = reader3["Brand_Name"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader3.Close();
        }

        // Bind combined list to DropDownList
        drop_brand.Items.Clear();
        drop_brand.Items.Insert(0, new ListItem("--Select--", "0"));
        foreach (string brandName in brandNames)
        {
            drop_brand.Items.Add(new ListItem(brandName, brandName));
        }

    }

    protected void Bind_Model_Name()
    {

        List<string> modelNames = new List<string>();
        // Fetch data from first data source
        string strconn1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
        using (SqlConnection connection1 = new SqlConnection(strconn1))
        {
            string query1 = "Select distinct Model_Name from LENS_MASTER where Brand_Name='" + drop_brand.Text + "'";
            SqlCommand cmd1 = new SqlCommand(query1, connection1);
            connection1.Open();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string brandName = reader1["Model_Name"].ToString();
                if (!modelNames.Contains(brandName))
                {
                    modelNames.Add(brandName);
                }
            }
            reader1.Close();
        }

        // Fetch data from second data source
        string strconn2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
        using (SqlConnection connection2 = new SqlConnection(strconn2))
        {
            string query2 = "Select distinct Model_Name from LENS_MASTER where Brand_Name='" + drop_brand.Text + "'";
            SqlCommand cmd2 = new SqlCommand(query2, connection2);
            connection2.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string modName = reader2["Model_Name"].ToString();
                if (!modelNames.Contains(modName))
                {
                    modelNames.Add(modName);
                }
            }
            reader2.Close();
        }

        // Fetch data from third data source
        string strconn3 = ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString;
        using (SqlConnection connection3 = new SqlConnection(strconn3))
        {
            string query3 = "Select distinct Model_Name from LENS_MASTER  where Brand_Name='" + drop_brand.Text + "'";
            SqlCommand cmd3 = new SqlCommand(query3, connection3);
            connection3.Open();
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string modName = reader3["Model_Name"].ToString();
                if (!modelNames.Contains(modName))
                {
                    modelNames.Add(modName);
                }
            }
            reader3.Close();
        }

        // Bind combined list to DropDownList
        drpmodel.Items.Clear();
        drpmodel.Items.Insert(0, new ListItem("--Select--", "0"));
        foreach (string modName in modelNames)
        {
            drpmodel.Items.Add(new ListItem(modName, modName));
        }

    }


    protected void drpshift_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtslnid.Focus();
    }
    protected void txtslnid_TextChanged(object sender, EventArgs e)
    {
        string sln = txtslnid.Text;
        txtslnid.Text = sln.ToUpper();
        drpmodel.Focus();
    }
    protected void drpmodel_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        txtvolume.Focus();
    }
    protected void txtvolume_TextChanged(object sender, EventArgs e)
    {
        txtQty.Focus();
    }
    protected void txtQty_TextChanged(object sender, EventArgs e)
    {
        txtapprvby.Focus();
    }
    protected void txtapprvby_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string up = txtapprvby.Text;

            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtapprvby.Text = up.ToUpper();
                btnSave.Focus();
            }
            else
            {
                Messagebox("Please Enter INITIAL ex: M.BALAJI");
                txtapprvby.Text = "";
                txtapprvby.Focus();
            }

        }
        catch
        {
            Messagebox("Please Enter INITIAL ex: M.BALAJI");
            txtapprvby.Text = "";
            txtapprvby.Focus();
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            try
            {
                SaveMethod();
            }
            catch (Exception ex)
            {
                Messagebox(ex.ToString());
            }
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (Validation())
        {
            try
            {
                Update();
            }
            catch (Exception ex)
            {
                Messagebox(ex.ToString());
            }
        }
    }
    protected void gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["up"].Equals(1))
        {
            txtlotno.Text = gridview1.SelectedRow.Cells[1].Text;
            drpmodel.Text = gridview1.SelectedRow.Cells[2].Text;
            txtslnid.Text = gridview1.SelectedRow.Cells[3].Text;
            drpshift.Text = gridview1.SelectedRow.Cells[4].Text;
            txtvolume.Text = gridview1.SelectedRow.Cells[5].Text;
            txtQty.Text = gridview1.SelectedRow.Cells[6].Text;
            txtdate.Text = gridview1.SelectedRow.Cells[7].Text;
            txtapprvby.Text = gridview1.SelectedRow.Cells[8].Text;
            btnUpdate.Visible = true;
            btnClear.Visible = true;
        }
        else
        {
            Messagebox("Permission is Denied to perform this process");
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
    }

    #endregion Event

    #region Methods

    protected void GridBind()
    {
        var qury = from r in SL.NewBtchAllots where r.LotNo == txtlotno.Text select r;
        if (qury.Count() > 0)
        {
            gridview1.DataSource = qury;
            gridview1.DataBind();
            btnSave.Visible = false;
            btnClear.Visible = true;
        }
        else
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnClear.Visible = true;
        }
    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    private bool Validation()
    {
        bool _isvalid = true;
        if (txtlotno.Text == "" && txtlotno.Text == "--Select--")
        {
            Messagebox("Please Enter LotNo");
            txtlotno.Focus();
            _isvalid = false;
        }
        else if (txtdate.Text == "")
        {
            Messagebox("Please Enter Date");
            txtdate.Focus();
            _isvalid = false;
        }
        else if (drpshift.SelectedValue == "--Select--")
        {
            Messagebox("Choose Shift Value");
            drpshift.Focus();
            _isvalid = false;
        }
        else if (txtslnid.Text == "")
        {
            Messagebox("Please Enter SolutionId");
            txtslnid.Focus();
            _isvalid = false;
        }
        else if (drpmodel.SelectedValue == "--Select--")
        {
            Messagebox("Choose Model Value");
            drpmodel.Focus();
            _isvalid = false;
        }
        else if (txtvolume.Text == "")
        {
            Messagebox("Please Enter Volume");
            txtvolume.Focus();
            _isvalid = false;
        }
        else if (txtQty.Text == "")
        {
            Messagebox("Please Enter Quantity");
            txtQty.Focus();
            _isvalid = false;
        }
        else if (txtapprvby.Text == "")
        {
            Messagebox("Please Enter ApprovedBy");
            txtapprvby.Focus();
            _isvalid = false;
        }
        return _isvalid;
    }

    protected void SaveMethod()
    {
           var q = from x in SL.NewBtchAllots where x.LotNo == txtlotno.Text  || x.Reflot == txtlotno.Text    select x;
           if (q.Count() == 0)
           {
            NewBtchAllot nba = new NewBtchAllot();
            nba.LotNo = txtlotno.Text;
            nba.Brand_Name = drop_brand.Text;
            nba.Model = drpmodel.SelectedValue;
            nba.Quantity = Convert.ToInt32(txtQty.Text);
            nba.Shift = drpshift.SelectedValue;
            nba.SolutionId = txtslnid.Text;
            nba.Volume = Convert.ToInt32(txtvolume.Text);
            nba.Date = Convert.ToDateTime(txtdate.Text, provider);
            nba.ApprovedBy = txtapprvby.Text;
            SL.NewBtchAllots.InsertOnSubmit(nba);
            SL.SubmitChanges();
            Messagebox("Saved Successfully");
            GridBind();
           }
           else
           {
               Messagebox("Lot Number Already Exists...");
           }
       
  }
    protected void Clear()
    {
       // txtlotno.Items.Clear();
        txtlotno.Text = "";
        txtdate.Text = "";
       
        drpshift.Items.Clear();
        txtslnid.Text = "";
        
        drpmodel.Items.Clear();
        drop_brand.Items.Clear();
        txtvolume.Text = "";
        txtQty.Text = "";
        txtapprvby.Text = "";
        gridview1.DataSource = null;
        gridview1.DataBind();
        btnSave.Visible = false;
        Response.Redirect("BtchforMould.aspx");
    }
    protected void Update()
    {
        var query = from x in SL.NewBtchAllots where x.LotNo == txtlotno.Text select x;
        if (query.Count() > 0)
        {
            query.Single().LotNo = txtlotno.Text;
            query.Single().Brand_Name = drop_brand.Text;
            query.Single().Model = drpmodel.SelectedValue;
            query.Single().Quantity = Convert.ToInt32(txtQty.Text);
            query.Single().Shift = drpshift.SelectedValue;
            query.Single().SolutionId = txtslnid.Text;
            query.Single().Volume = Convert.ToInt32(txtvolume.Text);
            query.Single().Date = Convert.ToDateTime(txtdate.Text, provider);
            query.Single().ApprovedBy = txtapprvby.Text;
            SL.SubmitChanges();
            GridBind();
            Clear();
            Messagebox("Updated Successfully");
        }
    }

    #endregion Methods
    protected void drop_brand_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_Model_Name();
    }
    protected void txtlotno_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridview1.DataSource = null;
        gridview1.DataBind();
        string lot = txtlotno.Text;
        txtlotno.Text = lot.ToUpper();
        GridBind();
        drpshift.Focus();
    }
}