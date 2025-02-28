using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.Common;

public static class BrowserCompatibility
{
    #region IsUplevel Browser property
    private enum UpLevel { chrome, firefox, safari }

    public static bool IsUplevel
    {
        get
        {
            bool ret = false;
            string _browser;

            try
            {

                if (HttpContext.Current == null) return ret;
                _browser = HttpContext.Current.Request.UserAgent.ToLower();

                foreach (UpLevel br in Enum.GetValues(typeof(UpLevel)))
                { if (_browser.Contains(br.ToString())) { ret = true; break; } }

                return ret;
            }
            catch { return ret; }
        }
    }
    #endregion
}
public partial class _Default : System.Web.UI.Page
{
    #region Page Pre-Init: force uplevel browser setting
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (BrowserCompatibility.IsUplevel)
        {
            Page.ClientTarget = "uplevel";
        }
    }
    #endregion
}

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var username = (Session["Username"] as HtmlInputControl).Value;

        if (username == null)
        {
            Response.Redirect("404Page.aspx");
        }
        SoftLensDataContext db = new SoftLensDataContext();
        if (!IsPostBack)
        {
           try
            {
                int v = (int)Session["Rollback"];
                if (1 == v)
                {
                    DbTransaction trans;
                    trans = (DbTransaction)Session["trans"];
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                }
            }
            catch
            {
            }
        }

    }
  
    protected void Menu1_MenuItemClick1(object sender, MenuEventArgs e)
    {

        MenuItem item = Menu1.SelectedItem;

        try
        {

            if (item.Parent.Text == "First Cut")
            {
                Session["Cut Type"] = "Ist Cut";
            }
            else if (item.Parent.Text == "Second Cut")
            {
                Session["Cut Type"] = "IInd Cut";
            }

        }
        catch
        {
        }


        if (item.Value == "Blocking")
        {
            Response.Redirect("BlockingForm.aspx");

        }

        else if (item.Value == "Lath Cut")
        {
            Response.Redirect("LathCut.aspx");
        }


        else if (item.Value == "Microscopic Inspection")
        {
            Response.Redirect("MicroscopicInspec.aspx");
        }
        else if (item.Value == "Haptic Thick & Power Inspec")
        {
            Response.Redirect("HapticPower.aspx");
        }
        else if (item.Value == "Lens Measurement Inspection")
        {
            Response.Redirect("LensMeasurementInspection.aspx");
        }
        else if (item.Value == "Lot Inspection")
        {
            Response.Redirect("MIwithCollet.aspx");
        }
        else if (item.Value == "Deblocking")
        {
            Response.Redirect("Deblocking.aspx");
        }
        else if (item.Value == "Lot Result")
        {
            Response.Redirect("LotResult1stCut.aspx");
        }
        else if (item.Value == "Micro cleaned & haptic")
        {
            Response.Redirect("MicroscopeHapticThick.aspx");
        }
        else if (item.Value == "Power Inspec")
        {
            Response.Redirect("PoweInspectionInHydration.aspx");
        }
       
        else if (item.Value == "SIForMilling")
        {
            Session["Cut Type"] = "Milling";
            Response.Redirect("MicroscopicInspec.aspx");
        }
        else if (item.Value == "Sealing Cup")
        {
            Session["Cut Type"] = "Sealing Cup";
            Response.Redirect("SealingProcess.aspx");
        }
        else if (item.Value == "Sealing Pouch")
        {
            Session["Cut Type"] = "Sealing Pouch";
            Response.Redirect("SealingProcess.aspx");
        }
        else if (item.Value == "Master Form" && Session["up"].Equals(1))
        {
            Response.Redirect("PageMaster.aspx");
        }
        else if (item.Value == "Master Form" && Session["up"] != "1")
        {
            Response.Redirect("Welcome.aspx");
        }
        else if (item.Value == "Hydration Before Tumbling")
        {
            Session["Title"] = "Hydration Before Tumbling";
            Response.Redirect("StatisticalReport.aspx");
        }
        else if (item.Value == "Waiting For Tumbling")
        {
            Session["Title"] = "Waiting For Tumbling";
            Response.Redirect("StatisticalReport.aspx");
        }
        else if (item.Value == "RunningTumbling")
        {
            Session["Title"] = "Running Tumbling";
            Response.Redirect("StatisticalReport.aspx");
        }
        else if (item.Value == "Waiting For Power Segregation")
        {
            Session["Title"] = "Waiting For Power Segregation";
            Response.Redirect("StatisticalReport.aspx");
        }
        else if (item.Value == "Waiting For Pouch Packing")
        {
            Session["Title"] = "Waiting For Pouch Packing";
            Response.Redirect("StatisticalReport.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (var cn = new SoftLensDataContext())
        {

           var username = (Session["Username"] as HtmlInputControl).Value;
           
          //  string username = Session["UserName"].ToString();
            //string userName = HttpContext.Current.Session["UserName"].ToString();
            var userLogin = cn.Logins.FirstOrDefault(x => x.Login_Status == 1 && x.LoginName == username);

            if (userLogin != null)
            {
              //  userLogin.Login_Status = 0;  // Or your desired login status
              //  cn.SubmitChanges();  // This will work if cn is a valid DbContext instance
            }
        }

        Response.Redirect("~/Loginpage.aspx");
    }
}
