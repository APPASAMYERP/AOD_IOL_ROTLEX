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

public partial class ProductReleaseNote : System.Web.UI.Page
{
    #region Declarations
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    #endregion


    #region Methods
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    private void clear()
    {
        txtAppBy.Text = "";
        txtAuthSig.Text = "";
        txtCdate.Text = "";
        txtDate.Text = "";
        txtMHSRno.Text = "";
        txtPRNno.Text = "";
        txtSterileBNo.Text = "";
        gvPRNno.DataSource = null;
        gvPRNno.DataBind();
    }

    private void EnableALL()
    {
        lblSterileBNO.Visible = true;
        lblCurrentDate.Visible = true;
        lblMHSRNo.Visible = true;
        lblDate.Visible = true;
        lblApprovedBy.Visible = true;
        lblAuthSign.Visible = true;
        txtAppBy.Visible = true;
        txtAuthSig.Visible = true;
        txtCdate.Visible = true;
        txtDate.Visible = true;
        txtMHSRno.Visible = true;
        txtSterileBNo.Visible = true;
        pnlPRN.Visible = true;
    }

    private void DisableALL()
    {
        lblSterileBNO.Visible = false;
        lblCurrentDate.Visible = false;
        lblMHSRNo.Visible = false;
        lblDate.Visible = false;
        lblApprovedBy.Visible = false;
        lblAuthSign.Visible = false;
        txtAppBy.Visible = false;
        txtAuthSig.Visible = false;
        txtCdate.Visible = false;
        txtDate.Visible = false;
        txtMHSRno.Visible = false;
        txtSterileBNo.Visible = false;
        pnlPRN.Visible = false;
    }

    private void Changeclear()
    {
        txtAppBy.Text = "";
        txtAuthSig.Text = "";
        txtCdate.Text = "";
        txtDate.Text = "";
        txtMHSRno.Text = "";

        txtSterileBNo.Text = "";
        gvPRNno.DataSource = null;
        gvPRNno.DataBind();
    }

    public void index()
    {
        var mhsr = from a in db.MHSRnews where a.ProductRelease == txtPRNno.Text select a;
        if (mhsr.Count() != 0)
        {
            EnableALL();
            txtSterileBNo.Text = mhsr.Single().BNoMHSR.ToString();
            txtMHSRno.Text = mhsr.Single().MHSR.ToString();
            txtDate.Text = mhsr.Single().Date.ToString();
            txtCdate.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");

            var mhs = from a in db.MHSRs where a.MHSRNo == txtMHSRno.Text select a;
            if (mhs.Count() != 0)
            {
                string l1 = mhs.Single().LotNo1.ToString();
                string l2 = mhs.Single().LotNo2.ToString();
                string l3 = mhs.Single().LotNo3.ToString();
                string l4 = mhs.Single().LotNo4.ToString();
                string l5 = mhs.Single().LotNo5.ToString();
                string l6 = mhs.Single().LotNo6.ToString();


                DataTable dt = new DataTable();
                dt.Columns.Add("Model", typeof(int));
                dt.Columns.Add("LotNo", typeof(int));
                dt.Columns.Add("Power", typeof(decimal));
                dt.Columns.Add("Qty", typeof(int));

                for (int i = 1; i <= 6; i++)
                {
                    DataRow row = dt.NewRow();
                    if (i == 1 && l1 != "")
                    {
                        var lab1id = from a in db.LabelDetailsPackings where a.LotNo == (l1) select a.Id;
                        foreach (var val in lab1id)
                        {
                            DataRow row1 = dt.NewRow();
                            int id1 = val;
                            var lab1 = from a in db.LabelDetailsPackings where a.LotNo == (l1) && a.Id == id1 select a;
                            row1[0] = lab1.Single().Model.ToString();
                            row1[1] = lab1.Single().LotNo.ToString();
                            row1[2] = lab1.Single().Power.ToString();
                            row1[3] = lab1.Single().Qty.ToString();
                            dt.Rows.Add(row1);
                        }
                    }

                    if (i == 2 && l2 != "")
                    {
                        var lab2id = from a in db.LabelDetailsPackings where a.LotNo == (l2) select a.Id;
                        foreach (var val in lab2id)
                        {
                            DataRow row2 = dt.NewRow();
                            int id2 = val;
                            var lab2 = from a in db.LabelDetailsPackings where a.LotNo == (l2) && a.Id == id2 select a;
                            row2[0] = lab2.Single().Model.ToString();
                            row2[1] = lab2.Single().LotNo.ToString();
                            row2[2] = lab2.Single().Power.ToString();
                            row2[3] = lab2.Single().Qty.ToString();
                            dt.Rows.Add(row2);
                        }
                    }
                    if (i == 3 && l3 != "")
                    {
                        var lab3id = from a in db.LabelDetailsPackings where a.LotNo == (l3) select a.Id;
                        foreach (var val in lab3id)
                        {
                            DataRow row3 = dt.NewRow();
                            int id3 = val;
                            var lab3 = from a in db.LabelDetailsPackings where a.LotNo == (l3) && a.Id == id3 select a;


                            row3[0] = lab3.Single().Model.ToString();
                            row3[1] = lab3.Single().LotNo.ToString();
                            row3[2] = lab3.Single().Power.ToString();
                            row3[3] = lab3.Single().Qty.ToString();
                            dt.Rows.Add(row3);
                        }
                    }
                    if (i == 4 && l4 != "")
                    {
                        var lab4id = from a in db.LabelDetailsPackings where a.LotNo == (l4) select a.Id;
                        foreach (var val in lab4id)
                        {
                            DataRow row4 = dt.NewRow();
                            int id4 = val;
                            var lab4 = from a in db.LabelDetailsPackings where a.LotNo == (l4) && a.Id == id4 select a;
                            row4[0] = lab4.Single().Model.ToString();
                            row4[1] = lab4.Single().LotNo.ToString();
                            row4[2] = lab4.Single().Power.ToString();
                            row4[3] = lab4.Single().Qty.ToString();
                            dt.Rows.Add(row4);
                        }
                    }
                    if (i == 5 && l5 != "") 
                    {
                        var lab5id = from a in db.LabelDetailsPackings where a.LotNo == (l5) select a.Id;
                        foreach (var val in lab5id)
                        {
                            DataRow row5 = dt.NewRow();
                            int id5 = val;
                            var lab5 = from a in db.LabelDetailsPackings where a.LotNo == (l5) && a.Id == id5 select a;
                            row5[0] = lab5.Single().Model.ToString();
                            row5[1] = lab5.Single().LotNo.ToString();
                            row5[2] = lab5.Single().Power.ToString();
                            row5[3] = lab5.Single().Qty.ToString();
                            dt.Rows.Add(row5);
                        }
                    }
                    if (i == 6 && l6 != "")
                    {
                        var lab6id = from a in db.LabelDetailsPackings where a.LotNo == (l6) select a.Id;
                        foreach (var val in lab6id)
                        {
                            DataRow row6 = dt.NewRow();
                            int id6 = val;
                            var lab6 = from a in db.LabelDetailsPackings where a.LotNo == (l6) && a.Id == id6 select a;
                            row6[0] = lab6.Single().Model.ToString();
                            row6[1] = lab6.Single().LotNo.ToString();
                            row6[2] = lab6.Single().Power.ToString();
                            row6[3] = lab6.Single().Qty.ToString();
                            dt.Rows.Add(row6);
                        }
                    }
                    //if (i == 2)
                    //{
                    //    var lab2 = from a in db.LabelDetailsPackings where a.LotNo == Convert.ToInt32(l2) select a;
                    //    row[0] = lab2.Single().Model.ToString();
                    //    row[1] = lab2.Single().LotNo.ToString();
                    //    row[2] = lab2.Single().Power.ToString();
                    //    row[3] = lab2.Single().Qty.ToString();
                    //}

                }
                gvPRNno.DataSource = dt;
                gvPRNno.DataBind();

            }
        }
    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        PRNnum pnr = new PRNnum();
        pnr.PRNno = txtPRNno.Text;
        pnr.Date =Convert.ToDateTime(txtCdate.Text,provider);
        pnr.ApprovedBy = txtAppBy.Text;
        pnr.AuthSign = txtAuthSig.Text;
        db.PRNnums.InsertOnSubmit(pnr);
        db.SubmitChanges();
        clear();
        btnSave.Visible = false;
        DisableALL();
        btnClear.Visible = false;
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        DisableALL();
        btnClear.Visible = false;
    }

   
    protected void txtAuthSig_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string up = txtAuthSig.Text;
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtAuthSig.Text = up.ToUpper();
                btnSave.Focus();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: ");
                txtAuthSig.Text = "";
                txtAuthSig.Focus();

            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtAuthSig.Text = "";
            txtAuthSig.Focus();
        }
    }

    protected void txtAppBy_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string up = txtAppBy.Text;
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtAppBy.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: ");
                txtAppBy.Text = "";
                txtAppBy.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: ");
            txtAppBy.Text = "";
            txtAppBy.Focus();

        }
    }

    protected void txtPRNno_TextChanged(object sender, EventArgs e)
    {
        Changeclear();
        gvPRNno.DataSource = null;
        gvPRNno.DataBind();
        var mhsr = from a in db.MHSRnews where a.ProductRelease == txtPRNno.Text select a;
        if (mhsr.Count() != 0)
        {
            EnableALL();
            txtAppBy.Focus();
            txtSterileBNo.Text = mhsr.Single().BNoMHSR.ToString();
            txtMHSRno.Text = mhsr.Single().MHSR.ToString();
            DateTime dat = mhsr.Single().Date.Value;
            txtDate.Text = dat.ToString("dd/MM/yyyy");
            txtCdate.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
            var mhs = from a in db.MHSRs where a.MHSRNo == txtMHSRno.Text select a;
            if (mhs.Count() != 0)
            {
                string l1 = mhs.Single().LotNo1.ToString();
                string l2 = mhs.Single().LotNo2.ToString();
                string l3 = mhs.Single().LotNo3.ToString();
                string l4 = mhs.Single().LotNo4.ToString();
                string l5 = mhs.Single().LotNo5.ToString();
                string l6 = mhs.Single().LotNo6.ToString();


                DataTable dt = new DataTable();
                dt.Columns.Add("Model", typeof(int));
                dt.Columns.Add("LotNo", typeof(int));
                dt.Columns.Add("Power", typeof(decimal));
                dt.Columns.Add("Qty", typeof(int));

                for (int i = 1; i <= 6; i++)
                {
                    DataRow row = dt.NewRow();
                    if (i == 1 && l1 !="")
                    {
                        var lab1id = from a in db.LabelDetailsPackings where a.LotNo == (l1) select a.Id;
                        foreach (var val in lab1id)
                        {
                            DataRow row1 = dt.NewRow();
                            int id1 = val;
                            var lab1 = from a in db.LabelDetailsPackings where a.LotNo == (l1) && a.Id == id1 select a;
                            row1[0] = lab1.Single().Model.ToString();
                            row1[1] = lab1.Single().LotNo.ToString();
                            row1[2] = lab1.Single().Power.ToString();
                            row1[3] = lab1.Single().Qty.ToString();
                            dt.Rows.Add(row1);
                        }
                    }

                    if (i == 2 && l2 != "")
                    {
                        var lab2id = from a in db.LabelDetailsPackings where a.LotNo == (l2) select a.Id;
                        foreach (var val in lab2id)
                        {
                            DataRow row2 = dt.NewRow();
                            int id2 = val;
                            var lab2 = from a in db.LabelDetailsPackings where a.LotNo == (l2) && a.Id == id2 select a;
                            row2[0] = lab2.Single().Model.ToString();
                            row2[1] = lab2.Single().LotNo.ToString();
                            row2[2] = lab2.Single().Power.ToString();
                            row2[3] = lab2.Single().Qty.ToString();
                            dt.Rows.Add(row2);
                        }
                    }
                    if (i == 3 && l3 !="")
                    {
                        var lab3id = from a in db.LabelDetailsPackings where a.LotNo == (l3) select a.Id;
                        foreach (var val in lab3id)
                        {
                            DataRow row3 = dt.NewRow();
                            int id3 = val;
                            var lab3 = from a in db.LabelDetailsPackings where a.LotNo == (l3) && a.Id == id3 select a;


                            row3[0] = lab3.Single().Model.ToString();
                            row3[1] = lab3.Single().LotNo.ToString();
                            row3[2] = lab3.Single().Power.ToString();
                            row3[3] = lab3.Single().Qty.ToString();
                            dt.Rows.Add(row3);
                        }
                    }
                    if (i == 4 && l4 !="")
                    {
                        var lab4id = from a in db.LabelDetailsPackings where a.LotNo == (l4) select a.Id;
                        foreach (var val in lab4id)
                        {
                            DataRow row4 = dt.NewRow();
                            int id4 = val;
                            var lab4 = from a in db.LabelDetailsPackings where a.LotNo == (l4) && a.Id == id4 select a;
                            row4[0] = lab4.Single().Model.ToString();
                            row4[1] = lab4.Single().LotNo.ToString();
                            row4[2] = lab4.Single().Power.ToString();
                            row4[3] = lab4.Single().Qty.ToString();
                            dt.Rows.Add(row4);
                        }
                    }
                    if (i == 5 && l5 != "")
                    {
                        var lab5id = from a in db.LabelDetailsPackings where a.LotNo == (l5) select a.Id;
                        foreach (var val in lab5id)
                        {
                            DataRow row5 = dt.NewRow();
                            int id5 = val;
                            var lab5 = from a in db.LabelDetailsPackings where a.LotNo == (l5) && a.Id == id5 select a;
                            row5[0] = lab5.Single().Model.ToString();
                            row5[1] = lab5.Single().LotNo.ToString();
                            row5[2] = lab5.Single().Power.ToString();
                            row5[3] = lab5.Single().Qty.ToString();
                            dt.Rows.Add(row5);
                        }
                    }
                    if (i == 6 && l6 != "")
                    {
                        var lab6id = from a in db.LabelDetailsPackings where a.LotNo == (l6) select a.Id;
                        foreach (var val in lab6id)
                        {
                            DataRow row6 = dt.NewRow();
                            int id6 = val;
                            var lab6 = from a in db.LabelDetailsPackings where a.LotNo == (l6) && a.Id == id6 select a;
                            row6[0] = lab6.Single().Model.ToString();
                            row6[1] = lab6.Single().LotNo.ToString();
                            row6[2] = lab6.Single().Power.ToString();
                            row6[3] = lab6.Single().Qty.ToString();
                            dt.Rows.Add(row6);
                        }
                    }
                    //if (i == 2)
                    //{
                    //    var lab2 = from a in db.LabelDetailsPackings where a.LotNo == Convert.ToInt32(l2) select a;
                    //    row[0] = lab2.Single().Model.ToString();
                    //    row[1] = lab2.Single().LotNo.ToString();
                    //    row[2] = lab2.Single().Power.ToString();
                    //    row[3] = lab2.Single().Qty.ToString();
                    //}

                }

                gvPRNno.DataSource = dt;
                gvPRNno.DataBind();
                btnSave.Visible = true;
            }
        }
        else
        {
            Messagebox("The PRN number doesnot exist");
            txtPRNno.Text = "";
            txtPRNno.Focus();
            DisableALL();
        }
        btnClear.Visible = true;
        var prn = from a in db.PRNnums where a.PRNno == txtPRNno.Text select a;
        if (prn.Count() != 0)
        {
            txtAppBy.Text = prn.Single().ApprovedBy.ToString();
            txtAuthSig.Text = prn.Single().AuthSign.ToString();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
       
    }

    protected void gvPRNno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPRNno.PageIndex = e.NewPageIndex;
        index();
    }    

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        var prn = from a in db.PRNnums where a.PRNno == txtPRNno.Text select a;
        prn.Single().ApprovedBy = txtAppBy.Text;
        prn.Single().AuthSign = txtAuthSig.Text;
        db.SubmitChanges();
        btnUpdate.Visible = false;
        clear();
    }
    #endregion


    #region old2remove
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        LabelDetailsPacking lp = new LabelDetailsPacking();
        //var prn = from a in db.LabelDetailsPackings where a.Date == txtDate.Text select a;
        //if (prn.Count() != 0)
        //{
        //    gvPRNno.DataSource = prn;
        //    gvPRNno.DataBind();
        //    btnSave.Visible = true;
        //}
        //else
        //{
        //    Messagebox("Moist Heat Stearilisation process is not done for the selected Date");
        //    btnSave.Visible = false;
        //    txtDate.Text = "";
        //}
    }

    protected void txtSterileBNo_TextChanged(object sender, EventArgs e)
    {
        //var mhs = from a in db.MHSRs where a.BatchNo == txtSterileBNo.Text select a.MHSRNo;
        //txtMHSRno.Text = mhs.Single().ToString();
        //txtCdate.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
    }
    #endregion
}
