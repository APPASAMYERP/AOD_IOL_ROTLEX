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

public partial class rptDatewisetumbling : System.Web.UI.Page
{


    #region Declaration
    SoftLensDataContext db = new SoftLensDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);
    #endregion


    #region Method

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }



    #endregion




    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        btnGenerate.Visible = true;
        btnGenerate.Focus();
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

            string s = "SELECT dbo.Tumbling.StartDate AS Date, dbo.TumblingChild.ModelNo, dbo.TumblingChild.Power, SUM(dbo.TumblingChild.Quantity) AS Qty FROM dbo.Tumbling INNER JOIN dbo.TumblingChild ON dbo.Tumbling.TumblingLotNo = dbo.TumblingChild.TumblingNo WHERE (dbo.Tumbling.StartDate BETWEEN '" + txtDate.Text + "' AND '" + txtDate1.Text + "') GROUP BY dbo.TumblingChild.ModelNo, dbo.TumblingChild.Power, dbo.Tumbling.StartDate";

            SqlDataAdapter Adp = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            Adp.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                lblLenspreptumb.Visible = true;
            }
            else
            {
                Messagebox("Process Might not be Completed on This Date");
                txtDate.Focus();

            }
            gvLenPrepTumb.DataSource = ds;
            gvLenPrepTumb.DataBind();


            string s1 = " SELECT     Date, Model, Power, SUM(AcceptedQty) AS AccQty, SUM(RejectedQty) AS RejQty, SUM(Dots) AS DOTS, SUM(Islands) AS ISLANDS, SUM(LB) AS LB, SUM(SCR) AS SCR,SUM(PIMP) AS PIMP, SUM(HeatProb) AS HeatProb, SUM(Other) AS Other FROM MIinFQI WHERE (Date BETWEEN '" + txtDate.Text + "' AND '" + txtDate1.Text + "')GROUP BY Date, Model, Power, AcceptedQty, RejectedQty, Dots, Islands, LB, SCR, PIMP, HeatProb, Other ORDER BY Date ";

            SqlDataAdapter Adp1 = new SqlDataAdapter(s1, con);
            DataSet ds1 = new DataSet();
            Adp1.Fill(ds1);

            if (ds1.Tables[0].Rows.Count != 0)
            {
                lblMIFqiLens.Visible = true;
            }
            else
            {
                Messagebox("Process Might not be Completed on This Date");
                txtDate.Focus();

            }
            gvMi4lens.DataSource = ds1;
            gvMi4lens.DataBind();

        }

    }


    #endregion
    
   

    
   
   
}
