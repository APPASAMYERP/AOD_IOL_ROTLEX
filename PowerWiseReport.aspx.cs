using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;


public partial class PowerWiseReport : System.Web.UI.Page
{
    PouchDataContext db = new PouchDataContext();
    string mod,brand = string.Empty;
    
    SoftLensDataContext db1 = new SoftLensDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
    SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDownList();
            ReportViewer1.Visible = false;
            
        }
    }
    private void MessageBox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "');", true);
    }
    private void BindDropDownList()
    {
        // Connection strings
        string connectionString1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
        string connectionString2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
        string connectionString3 = ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString;

       
        var data = new List<string>();

        data.AddRange(GetRefLotFromDatabase(connectionString1));
        data.AddRange(GetRefLotFromDatabase(connectionString2));
        data.AddRange(GetRefLotFromDatabase(connectionString3));

        // Remove duplicates and bind to DropDownList
        data = data.Distinct().ToList();

        drptumbNo.Items.Clear();
        drptumbNo.Items.Add("--Select--");
        drptumbNo.DataSource = data;
        drptumbNo.DataBind();
    }

    private IEnumerable<string> GetRefLotFromDatabase(string connectionString)
    {
        var refLots = new List<string>();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT DISTINCT RefLot FROM POUCH_LABEL WHERE RefLot IS NOT NULL";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        refLots.Add(reader["RefLot"].ToString());
                    }
                }
            }
        }

        return refLots;
    }
    public List<string> GetDistinctPowers(string refLot)
    {
        List<string> distinctPowers = new List<string>();

        // Define connection strings
        string[] connectionStrings = {
        ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString,
        ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString,
        ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString
    };

        // Define the query
        string query = "SELECT DISTINCT Power FROM POUCH_LABEL WHERE RefLot = @RefLot";

        // Loop through each connection string to query the database
        foreach (string connectionString in connectionStrings)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RefLot", refLot);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string power = reader["Power"].ToString();
                        if (!distinctPowers.Contains(power))
                        {
                            distinctPowers.Add(power);
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exception (log error, rethrow, etc.)
                    Console.WriteLine(ex.Message);
                }
            }
        }

        return distinctPowers;
    }

    protected void drptumbNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedRefLot = drptumbNo.SelectedValue;

        if (!string.IsNullOrEmpty(selectedRefLot))
        {
            List<string> powers = GetDistinctPowers(selectedRefLot);

            drpPower.Items.Clear();
            drpPower.Items.Add("--Select--");

            foreach (string power in powers)
            {
                drpPower.Items.Add(new ListItem(power, power));
            }
        }
    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "windows", "alert('" + msg + "')", true);
    }
    protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (drptumbNo.Text != "--Select--" && drpPower.Text != "--Select--")
            {
                var qurty = from x1 in db1.MIinFQIs where x1.GlassyNo == drptumbNo.SelectedValue && x1.Power == Convert.ToDecimal(drpPower.SelectedValue) select x1;
                if (qurty.Count() > 0)
                {
                    string accpt = qurty.Single().AcceptedQty.ToString();
                    string rej = qurty.Single().RejectedQty.ToString();

                    LocalReport lr = null;
                    DataSet ds = new DataSet();
                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    var query = from model in db1.NewBtchAllots where model.LotNo == drptumbNo.SelectedValue || model.Reflot == drptumbNo.SelectedValue select model;
                    mod = query.Single().Model;
                    brand = query.Single().Brand_Name;


                    if (mod == "AE-01" || mod == "AEM-01" || mod == "AE INFO")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select Lot_Prefix + Lot_No AS Lot_No,RefLot,Power,R_Power,Model_Name,Label from POUCH_LABEL where RefLot='" + drptumbNo.SelectedValue + "' and Power='" + drpPower.SelectedValue + "'", con3);
                        da.Fill(ds, "temp");
                    }
                    else if (brand == "HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS" && mod == "SPNT300")
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select Lot_Prefix + Lot_No AS Lot_No,RefLot,Power,R_Power,Model_Name,Label from POUCH_LABEL where RefLot='" + drptumbNo.SelectedValue + "' and Power='" + drpPower.SelectedValue + "'", con2);
                        da.Fill(ds, "temp");
                    }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter("Select Lot_Prefix + Lot_No AS Lot_No,RefLot,Power,R_Power,Model_Name,Label from POUCH_LABEL where RefLot='" + drptumbNo.SelectedValue + "' and Power='" + drpPower.SelectedValue + "'", con1);
                        da.Fill(ds, "temp");
                    }

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    lr = ReportViewer1.LocalReport;
                    lr.ReportPath = "PowerWiseReport.rdlc";
                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("accpt", accpt, false);
                    param[1] = new ReportParameter("rej", rej, false);
                    this.ReportViewer1.LocalReport.SetParameters(param);
                    this.ReportViewer1.LocalReport.Refresh();

                    // lr.DataSources.Add(new ReportDataSource("DataSet5", ds.Tables[0]));
                    lr.DataSources.Add(new ReportDataSource("DataSet3_POUCH_LABEL", ds.Tables[0]));

                    if (ds.Tables["temp"].Rows.Count == 0)
                    {
                        Messagebox("No data found for the given input..");
                        this.ReportViewer1.Visible = false;
                    }
                    else
                    {
                        this.ReportViewer1.Visible = true;
                    }
                }
                else
                {
                    MessageBox("Inspection Process Not Completed");
                }
            }

            else
            {
                MessageBox("Please select both tumbling number and Power Fields");
            }
        }
        catch (Exception ex)
        {
            MessageBox(ex.ToString());
        }
    }
    
}
