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

public partial class BoxPackingCollectionList : System.Web.UI.Page
{

#region declarations
    SoftLensDataContext db = new SoftLensDataContext();
#endregion

    #region Methods

    public void clear()
    {

        txtModel.Text = "";
        txtPower.Text = "";
        //txtEDate.Text = "";
        //txtSDate.Text = "";
        //txtDays.Text = "";
        txttotal.Text = "";
        txtcollected.Text = "";
        txtBalance.Text = "";
        txtCollecBy.Text = "";
        gvBoxpacking.DataSource = null;
        gvBoxpacking.DataBind();
    }
    protected void index()
    {
        Session["cts"] = 0;
        var ln = (from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(txtModel.Text) && a.Power == Convert.ToDecimal(txtPower.Text) select a.LotNo).Distinct();

        var Sno = from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(txtModel.Text) && a.Power == Convert.ToDecimal(txtPower.Text) select a.SerialFrom;

        string start = Sno.Min().ToString();
        var Eno = from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(txtModel.Text) && a.Power == Convert.ToDecimal(txtPower.Text) select a.SerialTo;
        string end = Eno.Min().ToString();

        int ss = Convert.ToInt32(start);
        int en = Convert.ToInt32(end);

        DataTable dt = new DataTable();
        dt.Columns.Add("LotNo", typeof(int));
        dt.Columns.Add("SerialNo", typeof(int));
        dt.Columns.Add("type", typeof(string));
        int ctT = 0, ctS = 0;
        for (int i = ss; i <= en; i++)
        {
            DataRow row = dt.NewRow();
            row[2] = "Collected Qty";
            row[0] = ln.Single().Value;
            row[1] = i;

            foreach (var val in ln)
            {
                var selected = from a in db.QcSerialNos where a.LotNo == val select a.SerialNo == i.ToString();
                string c1 = selected.Count().ToString();
                foreach (var value in selected)
                {
                    if (value == true)
                    {
                        row[2] = "T";
                    }
                }
            }
            foreach (var value in ln)
            {
                var serial = from a in db.InspectionsDocs where a.LotNo == value select a.SerialNo == i;
                string c2 = serial.Count().ToString();

                foreach (var val in serial)
                {
                    if (val == true)
                    {
                        row[2] = "s";
                        ctS = ctS + 1;
                        Session["ctS"] = ctS;
                    }
                }
            }
            dt.Rows.Add(row);

        }
        txtBalance.Text = Session["cts"].ToString();
        var bp = (from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) select a.Qty).Distinct();
        txttotal.Text = bp.Single().ToString();
        txtcollected.Text = (Convert.ToInt32(txttotal.Text) - Convert.ToInt32(txtBalance.Text)).ToString();
        var qty = (from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(txtModel.Text) && a.Power == Convert.ToDecimal(txtPower.Text) select a.Qty).Sum();
        txttotal.Text = qty.ToString();

        gvBoxpacking.DataSource = dt;
        gvBoxpacking.DataBind();

    }
    protected void Savedindex()
    {
        Session["cts"] = 0;
        var ln = (from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(txtModel.Text) && a.Power == Convert.ToDecimal(txtPower.Text) select a.LotNo).Distinct();

        var Sno = from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(txtModel.Text) && a.Power == Convert.ToDecimal(txtPower.Text) select a.SerialFrom;

        string start = Sno.Min().ToString();
        var Eno = from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(txtModel.Text) && a.Power == Convert.ToDecimal(txtPower.Text) select a.SerialTo;
        string end = Eno.Min().ToString();

        int ss = Convert.ToInt32(start);
        int en = Convert.ToInt32(end);

        DataTable dt = new DataTable();
        dt.Columns.Add("LotNo", typeof(int));
        dt.Columns.Add("SerialNo", typeof(int));
        dt.Columns.Add("type", typeof(string));
        int ctT = 0, ctS = 0;
        for (int i = ss; i <= en; i++)
        {
            DataRow row = dt.NewRow();
            row[2] = "Collected Qty";
            row[0] = ln.Single().Value;
            row[1] = i;

            foreach (var val in ln)
            {
                var selected = from a in db.QcSerialNos where a.LotNo == val select a.SerialNo == i.ToString();
                string c1 = selected.Count().ToString();
                foreach (var value in selected)
                {
                    if (value == true)
                    {
                        row[2] = "T";
                    }
                }
            }
            foreach (var value in ln)
            {
                var serial = from a in db.InspectionsDocs where a.LotNo == value select a.SerialNo == i;
                string c2 = serial.Count().ToString();

                foreach (var val in serial)
                {
                    if (val == true)
                    {
                        row[2] = "s";
                        ctS = ctS + 1;
                        Session["ctS"] = ctS;
                    }
                }
            }
            dt.Rows.Add(row);
        }
        gvBoxpacking.DataSource = dt;
        gvBoxpacking.DataBind();
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
      

    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

   

    protected void txtBPLno_TextChanged(object sender, EventArgs e)
    {
        try
        {
            btnSave.Visible = false;
            
            var chk = from a in db.BoxPackgcollecLists where a.BplNo == txtBPLno.Text select a;
            if (chk.Count() == 0)
            {
                var mod = (from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) select a.Model).Distinct();
                if (mod.Count() > 0)
                {
                    txtModel.Text = mod.Single().ToString();
                    var pow = (from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) select a.Power).Distinct();
                    txtPower.Text = pow.Single().ToString();

                    index();
                    btnSave.Visible = true;
                }
                else
                {
                    Messagebox("BplNo doesn't exist");
                    txtBPLno.Text = "";
                }

            }
            else
            {
                txtModel.Text = chk.Single().Model.ToString();
                txtPower.Text = chk.Single().Power.ToString();
                Savedindex();
                txttotal.Text = chk.Single().Total.ToString();
                txtcollected.Text = chk.Single().CollecQty.ToString();
                txtBalance.Text = chk.Single().BalQty.ToString();
                txtCollecBy.Text = chk.Single().CollecBy.ToString();                
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
        }
        catch
        {

        }
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var pow = from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model==Convert.ToInt32(ddlModel.Text) select a.Power;
        //ddlPower.Items.Add("Select");
        //ddlPower.DataSource = pow;
        //ddlPower.DataBind();
    }

    protected void ddlPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var Sno = from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(ddlModel.Text) && a.Power ==Convert.ToDecimal(ddlPower.Text) select a.SerialFrom;
        //string start = Sno.Min().ToString();
        //var Eno = from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(ddlModel.Text) && a.Power == Convert.ToDecimal(ddlPower.Text) select a.SerialTo;
        //string end = Eno.Min().ToString();
        ////var gv = from a in db.PackingEntryDatas where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == ddlModel.Text select a;
        //int ss = Convert.ToInt32(start);
        //int en = Convert.ToInt32(end);
        //var lot = (from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(ddlModel.Text) && a.Power == Convert.ToDecimal(ddlPower.Text) select a.LotNo).Distinct();
        //string lotcounnt = lot.Count().ToString();
        //// string  ln= lot.Single().ToString();
        //DataTable dt = new DataTable();
        //dt.Columns.Add("LotNo", typeof(int));
        //dt.Columns.Add("SerialNo", typeof(int));
        //dt.Columns.Add("type", typeof(string));

        //foreach (var lotval in lot)
        //{
            
        //        for (int i = ss; i <= en; i++)
        //        {
        //            DataRow row = dt.NewRow();                   
        //            row[2] = "Def";
        //            row[0] = lotval.ToString();
        //            row[1] = i;
        //            var selected = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(lotval) select a.SerialNo == i.ToString();
        //            string c1 = selected.Count().ToString();
        //            foreach (var value in selected)
        //            {
        //                if (value == true)
        //                {
        //                    row[2] = "T";
        //                }

        //            }
        //            var serial = from a in db.InspectionsDocs where a.LotNo == Convert.ToInt32(lotval) select a.SerialNo == i;
        //            string c2 = serial.Count().ToString();
        //            foreach (var val in serial)
        //            {
        //                if (val == true)
        //                {
        //                    row[2] = "s";
        //                }

        //            }
        //            dt.Rows.Add(row);
        //            txtBalance.Text = (Convert.ToInt32(c1) + Convert.ToInt32(c2)).ToString();
        //        }              
                      
        //}
        ////var ct = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(ln) select a.SerialNo;
        ////string ct1 = ct.Count().ToString();
        ////var ctt = from a in db.InspectionsDocs where a.LotNo == Convert.ToInt32(ln) select a.SerialNo;
        ////string ctt1 = ct1.Count().ToString();
        ////txtBalance.Text = (Convert.ToInt32(ct1) + Convert.ToInt32(ctt1)).ToString();

        //var qty = (from a in db.PackingEntryTables where a.BPLNO == Convert.ToInt32(txtBPLno.Text) && a.Model == Convert.ToInt32(ddlModel.Text) && a.Power == Convert.ToDecimal(ddlPower.Text) select a.Qty).Sum();
        //txttotal.Text = qty.ToString();
        //txtcollected.Text = (Convert.ToInt32(txttotal.Text) - Convert.ToInt32(txtBalance.Text)).ToString();
        //txtSDate.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");

        //gvBoxpacking.DataSource = dt;
        //gvBoxpacking.DataBind();
    }


    protected void gvBoxpacking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBoxpacking.PageIndex = e.NewPageIndex;
        index();
        

    }
   

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        BoxPackgcollecList box = new BoxPackgcollecList();

        box.BplNo = txtBPLno.Text;
        box.Model = txtModel.Text;
        box.Power = txtPower.Text;
        //box.AsDate = txtSDate.Text;
        //box.AeDate = txtEDate.Text;
        box.Total = Convert.ToInt32(txttotal.Text);
        box.CollecQty = Convert.ToInt32(txtcollected.Text);
        box.BalQty = Convert.ToInt32(txtBalance.Text);
        box.CollecBy = txtCollecBy.Text;
       // box.Nod = Convert.ToInt32(txtDays.Text);
        db.BoxPackgcollecLists.InsertOnSubmit(box);
        db.SubmitChanges();
        btnSave.Visible = false;
        clear();
        txtBPLno.Text = "";
    }

  

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtBPLno.Text = "";
        btnUpdate.Visible = false;
        btnSave.Visible = false;
    }
    


    protected void txtCollecBy_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string up = txtCollecBy.Text;
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtCollecBy.Text = up.ToUpper();
                btnSave.Focus();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: ");
                txtCollecBy.Text = "";
                txtCollecBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtCollecBy.Text = "";
            txtCollecBy.Focus();
        }

    }


    protected void btnPrint_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("BoxPackingCollectionList.aspx");
    }

    
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        var up = from a in db.BoxPackgcollecLists where a.BplNo == txtBPLno.Text select a;
        up.Single().CollecBy = txtCollecBy.Text;
        db.SubmitChanges();
        btnUpdate.Visible = false;
        txtBPLno.Text = "";
        clear();
    }
    #endregion

    #region unused
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {


        var ser = (from a in db.InspectionsDocs where a.LotNo == Convert.ToInt32(txtBPLno.Text) select a.LotNo).Distinct();
        //string l = ser.Single().LotNo.ToString();
        // gvBoxpacking.DataSource = ser;
        //gvBoxpacking.DataBind();
        // var serial = from a in db.InspectionsDocs where a.LotNo == Convert.ToInt32(txtBPLno.Text) select a.SerialNo ;
        // string  s= serial.Count().ToString();
        // var selected = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(txtBPLno.Text) select a;
        DataTable dt = new DataTable();
        dt.Columns.Add("LotNo", typeof(int));
        dt.Columns.Add("SerialNo", typeof(int));
        dt.Columns.Add("type", typeof(string));

        //foreach (var val in serial)
        //{
        //    DataRow row = dt.NewRow();
        //    row[0] = val.LotNo;
        //    row[1] = val.SerialNo;
        //    row[2] = "B";
        //    dt.Rows.Add(row);         


        //}
        //foreach (var value in selected)
        //{
        //    DataRow row1 = dt.NewRow();
        //    row1[0] = value.LotNo;
        //    row1[1] = value.SerialNo;
        //    row1[2] = "T";
        //    dt.Rows.Add(row1);
        //}      


        var bp = from a in db.InspectionDocDatas where a.LotNo == txtBPLno.Text select a;
        string s = bp.Single().SerialFrom.ToString();
        int ss = Convert.ToInt32(s);
        string end = bp.Single().SerialTo.ToString();
        int en = Convert.ToInt32(end);
        int ctT = 0, ctS = 0;
        for (int i = ss; i <= en; i++)
        {
            DataRow row = dt.NewRow();
            row[2] = "Collected Qty";
            row[0] = txtBPLno.Text;
            row[1] = i;
            var selected = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(txtBPLno.Text) select a.SerialNo == i.ToString();
            string c1 = selected.Count().ToString();
            foreach (var value in selected)
            {

                if (value == true)
                {
                    row[2] = "T";
                    ctT = ctT + 1;
                    Session["ctT"] = ctT;
                }

            }
            var serial = from a in db.InspectionsDocs where a.LotNo == Convert.ToInt32(txtBPLno.Text) select a.SerialNo == i;
            string c2 = serial.Count().ToString();
            foreach (var val in serial)
            {
                if (val == true)
                {
                    row[2] = "s";
                    ctS = ctS + 1;
                    Session["ctS"] = ctS;
                }

            }
            dt.Rows.Add(row);
        }
        txtBalance.Text = Session["cts"].ToString();

        txttotal.Text = bp.Single().Qty.ToString();
        txtcollected.Text = (Convert.ToInt32(txttotal.Text) - Convert.ToInt32(txtBalance.Text)).ToString();
        //txtSDate.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");

        //DateTime startTime = txtSDate.Text;

        //DateTime endTime = txtEDate.Text;

        //TimeSpan span = endTime.Subtract(startTime);
        //s = Convert.ToDateTime(txtDate.Text);
        //txtDays.Text = "12/10/2014";
        //e = Convert.ToDateTime(txtDays.Text);
        //TimeSpan span = (e).Subtract(s);
        //txtCollecBy.Text = span.Days.ToString();
        gvBoxpacking.DataSource = dt;
        gvBoxpacking.DataBind();
    }

    protected void txtEDate_TextChanged(object sender, EventArgs e)
    {
        //txtSDate.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");

        //DateTime startTime = Convert.ToDateTime(txtSDate.Text);

        //DateTime endTime = Convert.ToDateTime(txtEDate.Text);


        //System.TimeSpan span = endTime.Subtract(startTime);
        //txtDays.Text = span.Days.ToString();


        //DateTime nowDate = Convert.ToDateTime(txtEDate.Text);

        ////use timespan to get the number of days

        //System.TimeSpan span = nowDate - Convert.ToDateTime(txtSDate.Text);

        //int days = (int)span.Days;

        //txtDays.Text = days.ToString();       
    }
    #endregion

}