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
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;

public partial class HydrationRunning : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        lblTitle.Text = Session["Title"].ToString();
        LocalReport lr = null;
        DataSet ds = new DataSet();
        con.Open();
       
        if (Session["Title"].ToString() == "Hydration Before Tumbling")
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select Model,Power,sum(Hydration) as Hydration from ReportTable where type=1 and Status=1  group by Model,Power", con);
            da.Fill(ds, "temp");
            
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "HydrationRunningReport.rdlc";

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("Title", lblTitle.Text, false);
            
            this.ReportViewer1.LocalReport.SetParameters(param);
            this.ReportViewer1.LocalReport.Refresh();

            lr.DataSources.Add(new ReportDataSource("PPStatisticalReport_ReportTable", ds.Tables[0]));

        }
        else if (Session["Title"].ToString() == "Waiting For Tumbling")
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select Model,Power,sum(WaitingTumbling) as WaitingTumbling from ReportTable where type=2 and Status=2  group by Model,Power", con);
            da.Fill(ds, "temp");

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "HydrationCompleted.rdlc";

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("Title", lblTitle.Text, false);

            this.ReportViewer1.LocalReport.SetParameters(param);
            this.ReportViewer1.LocalReport.Refresh();

            lr.DataSources.Add(new ReportDataSource("PPStatisticalReport_ReportTable", ds.Tables[0]));

        }
        else if (Session["Title"].ToString() == "Running Tumbling")
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select Model,Power,sum(RuningTumbling) as RuningTumbling from ReportTable where type=3 and Status=1  group by Model,Power", con);
            da.Fill(ds, "temp");

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "RunningTumbling.rdlc";

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("Title", lblTitle.Text, false);

            this.ReportViewer1.LocalReport.SetParameters(param);
            this.ReportViewer1.LocalReport.Refresh();

            lr.DataSources.Add(new ReportDataSource("PPStatisticalReport_ReportTable", ds.Tables[0]));

        }
        else if (Session["Title"].ToString() == "Waiting For Power Segregation")
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select Model,Power,sum(WaitingPowerSegregation) as WaitingPowerSegregation from ReportTable where type=4 and Status=2  group by Model,Power", con);
            da.Fill(ds, "temp");

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "TumblingCompleted.rdlc";

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("Title", lblTitle.Text, false);

            this.ReportViewer1.LocalReport.SetParameters(param);
            this.ReportViewer1.LocalReport.Refresh();

            lr.DataSources.Add(new ReportDataSource("PPStatisticalReport_ReportTable", ds.Tables[0]));

        }
        else if (Session["Title"].ToString() == "Waiting For Pouch Packing")
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("Select Model,Power,sum(WiatingPouchPacking) as WiatingPouchPacking from ReportTable where type=5 and Status=2  group by Model,Power", con);
            da.Fill(ds, "temp");

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            lr = ReportViewer1.LocalReport;
            lr.ReportPath = "PowerSegregationCompleted.rdlc";

            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("Title", lblTitle.Text, false);

            this.ReportViewer1.LocalReport.SetParameters(param);
            this.ReportViewer1.LocalReport.Refresh();

            lr.DataSources.Add(new ReportDataSource("PPStatisticalReport_ReportTable", ds.Tables[0]));

        }



      
    }
}
