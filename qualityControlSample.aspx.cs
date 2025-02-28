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

public partial class qualityControlSample : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        if (!IsPostBack)
        {
            for (int i = 1; i <= 200; i++)
            {
                CheckBoxList1.Items.Add(i.ToString());
            }

        }
    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }





    private void iclear()
    {
        txtModel.Text = "";
        ddlPower.Items.Clear();
        ddlSerialNo.Items.Clear();
        txtQuantity.Text = "";
        //txtType.Text = "";
        btnSerialNo_ConfirmButtonExtender.Enabled = false;
    }

    private void clear()
    {
        txtModel.Text = "";
        txtLotNo.Text = "";
        ddlPower.Items.Clear();
        ddlSerialNo.Items.Clear();
        txtQuantity.Text = "";
        //txtType.Text = "";
        txtDate.Text = "";
        txtBatchNo.Text = "";
        btnClear.Visible = false;
        btnSerialNo_ConfirmButtonExtender.Enabled = false;
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {

        if (CheckBoxList1.SelectedItem.Selected == true)
        {
            ddlSerialNo.Items.Clear();
            for (int i = 1; i <= 200; i++)
            {
                if (CheckBoxList1.Items[i - 1].Selected == true && CheckBoxList1.Items[i - 1].Enabled == true)
                {

                    string qw = i.ToString();
                    ddlSerialNo.Items.Add(qw);
                    CheckBoxList1.Items[i - 1].Enabled = true;
                }
            }
            int rt = ddlSerialNo.Items.Count;
            //var existTestType = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == txtLotNo.Text && a.Type == ddlTestType.Text select a.Quantity;
            //int exct = Convert.ToInt32(txtQuantity.Text);
            //int count = exct + rt;
            //txtQuantity.Text = count.ToString();
            txtQuantity.Text = rt.ToString();

        }
        else
        {
            Messagebox("Please choose a SerialNo  or click on Close");
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        QualityControl qc = new QualityControl();
        if (txtBatchNo.Text == "")
        {
            Messagebox("Please Enter the Batch No");
            txtBatchNo.Focus();
        }
        else if (ddlLabeldtlLotNo.Text == "Select")
        {
            Messagebox("Please Choose the LotNo");
            ddlLabeldtlLotNo.Focus();
        }
        //else if (txtLotNo.Text == "")
        //{
        //    Messagebox("Please Enter the LotNo");
        //    txtLotNo.Focus();
        //}
        //else if (txtType.Text == "")
        //{
        //    Messagebox("Please Enter the Type");
        //    txtType.Focus();
        //}
        else if (ddlPower.Text == "Select")
        {
            Messagebox("Please Choose the Power");
            ddlPower.Focus();
        }
        else
        {
            qc.Date = Convert.ToDateTime(txtDate.Text, provider);
            qc.BatchNo = txtBatchNo.Text;
            qc.LotNo = ddlLabeldtlLotNo.Text;
            qc.Type = ddlTestType.Text;
            qc.Model = txtModel.Text;
            qc.Power = Convert.ToDecimal(ddlPower.Text);

            qc.Quantity = Convert.ToInt32(txtQuantity.Text);
            int s = Convert.ToInt32(txtQuantity.Text);
            qc.Type = ddlTestType.Text;

            db.QualityControls.InsertOnSubmit(qc);
            db.SubmitChanges();



            for (int i = 1; i <= s; i++)
            {
                var q = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == ddlLabeldtlLotNo.Text select a.LotNo;
                QcSerialNo sno = new QcSerialNo();
                sno.TestType = ddlTestType.Text;
                sno.LotNo = Convert.ToInt32(ddlLabeldtlLotNo.Text);
                sno.SerialNo = ddlSerialNo.Items[i - 1].Value.ToString();
                db.QcSerialNos.InsertOnSubmit(sno);
                db.SubmitChanges();

            }
            CheckBoxList1.ClearSelection();
            clear();
            ddlSerialNo.Items.Clear();
            btnSave.Visible = false;
            btnClear.Visible = false;
            ddlTestType.Text = "Select";
            btnSerialNo.Visible = false;
        }
    }

    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        this.mpePopup.Hide();
        CheckBoxList1.ClearSelection();
        CheckBoxList1.Enabled = true;
        for (int i = 1; i <= 200; i++)
        {
            CheckBoxList1.Items[i - 1].Selected = false;
            CheckBoxList1.Items[i - 1].Enabled = true;
            CheckBoxList1.Items[i - 1].Text = i.ToString();
        }
        

   
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        QualityControl qc = new QualityControl();
        if (txtBatchNo.Text == "")
        {
            Messagebox("Please Enter the Batch No");
            txtBatchNo.Focus();
        }
        else if (ddlLabeldtlLotNo.Text == "Select")
        {
            Messagebox("Please Choose the LotNo");
            ddlLabeldtlLotNo.Focus();
        }
        //else if (txtLotNo.Text == "")
        //{
        //    Messagebox("Please Enter the LotNo");
        //    txtLotNo.Focus();
        //}
        else if (ddlSerialNo.Text == "")
        {
            Messagebox("Please Add the SerialNo");
            ddlSerialNo.Focus();
        }
        else
        {
            var up = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == ddlLabeldtlLotNo.Text && a.Type == ddlTestType.Text select a;
            up.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
            up.Single().BatchNo = txtBatchNo.Text;
            up.Single().LotNo = ddlLabeldtlLotNo.Text;

            up.Single().Model = txtModel.Text;
            up.Single().Power = Convert.ToDecimal(ddlPower.Text);
            var existTestType = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == ddlLabeldtlLotNo.Text && a.Type == ddlTestType.Text select a.Quantity;
            int ctt = existTestType.Single().Value;
            up.Single().Quantity = Convert.ToInt32(txtQuantity.Text) + ctt;
            int s = Convert.ToInt32(txtQuantity.Text);
            up.Single().Type = ddlTestType.Text;
            db.SubmitChanges();

            var q = (from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == ddlLabeldtlLotNo.Text select a.LotNo).Distinct();

            //var d = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(q.Single()) select a;
            //db.QcSerialNos.DeleteAllOnSubmit(d);
            //db.SubmitChanges();

            var d = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(q.Single()) select a.SerialNo;


            for (int i = 1; i <= s; i++)
            {

                var q1 = (from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == ddlLabeldtlLotNo.Text select a.LotNo).First();
                QcSerialNo sno = new QcSerialNo();

                // string ss = ddlSerialNo.Items[i - 1].Value.ToString();

                sno.LotNo = Convert.ToInt32(q1);
                sno.SerialNo = ddlSerialNo.Items[i - 1].Value.ToString();
                sno.TestType = ddlTestType.Text;
                db.QcSerialNos.InsertOnSubmit(sno);



            }
            db.SubmitChanges();




            btnUpdate.Visible = false;
            btnClear.Visible = false;
            btnSerialNo_ConfirmButtonExtender.Enabled = false;
            clear();
            CheckBoxList1.ClearSelection();
            ddlSerialNo.Items.Clear();
            ddlLabeldtlLotNo.Items.Clear();
            btnSerialNo.Visible = false;
            ddlTestType.Text = "Select";
        }
    }

    protected void btnSerialNo_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 1; i <= 200; i++)
        {
            CheckBoxList1.Items[i - 1].Selected = false;
            CheckBoxList1.Items[i - 1].Enabled = true;
            CheckBoxList1.Items[i - 1].Text = i.ToString();
        }
        if (ddlPower.Text == "Select")
        {
            Messagebox("Please Choose Power");
            ddlPower.Focus();
        }
        else
        {

            var lal = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(ddlLabeldtlLotNo.Text) && a.TestType == "Lal" select a.SerialNo;

            foreach (var val in lal)
            {
                int v = Convert.ToInt32(val) - 1;
                CheckBoxList1.Items[v].Selected = true;

                CheckBoxList1.Items[v].Enabled = false;
                //if (Session["up"].Equals(1))
                //{
                //    CheckBoxList1.Items[v].Enabled = true;
                //}

                CheckBoxList1.Items[v].Text = "lal";                
            }
            var seriallist = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(ddlLabeldtlLotNo.Text) && a.TestType == "Sterile" select a.SerialNo;
            foreach (var val in seriallist)
            {
                int v = Convert.ToInt32(val) - 1;
                CheckBoxList1.Items[v].Selected = true;

                CheckBoxList1.Items[v].Enabled = false;
                //if (Session["up"].Equals(1))
                //{
                //    CheckBoxList1.Items[v].Enabled = true;
                //}

                CheckBoxList1.Items[v].Text = "Sterile";
            }



            this.mpePopup.Show();
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnSerialNo.Visible = false;
    }

    #region lotnoindexchange
    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
    //    if (ddlTestType.Text == "Select")
    //    {
    //        Messagebox("Please Choose Test Type");
    //        ddlTestType.Focus();
    //    }
    //    else
    //    {
    //        ddlSerialNo.Items.Clear();

    //        btnUpdate.Visible = false;
    //        btnSave.Visible = false;
    //        var query = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == txtLotNo.Text && a.Type == ddlTestType.Text select a;
    //        if (query.Count() != 0)
    //        {
    //            btnUpdate.Visible = true;
    //            btnSerialNo_ConfirmButtonExtender.Enabled = true;

    //            string t = query.Single().LotNo.ToString();
    //            DateTime dnt = query.Single().Date.Value;
    //            txtDate.Text = dnt.ToString("dd/MM/yyyy");

    //            txtModel.Text = query.Single().Model.ToString();

    //            txtQuantity.Text = query.Single().Quantity.ToString();

    //            txtLotNo.Text = query.Single().LotNo.ToString();
    //            var query11 = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == txtLotNo.Text select a.Power;

    //            ddlPower.DataSource = query11;
    //            ddlPower.DataBind();

    //            var query1 = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(t) && a.TestType == ddlTestType.Text select a.SerialNo;

    //            ddlSerialNo.DataSource = query1;
    //            ddlSerialNo.DataBind();

    //            btnClear.Visible = true;
    //        }
    //        else
    //        {
    //            CheckBoxList1.Enabled = true;

    //            //CheckBoxList1.EnableViewState = true;
    //            btnSave.Visible = true;
    //            btnClear.Visible = true;
    //            iclear();
    //            LabelDetailsPacking lab = new LabelDetailsPacking();
    //            var q = (from a in db.LabelDetailsPackings where a.LotNo == Convert.ToInt32(txtLotNo.Text) select a.Model).Distinct();
    //            if (q.Count() != 0)
    //            {
    //                try
    //                {
    //                    txtModel.Text = q.Single().ToString();
    //                    var q1 = from a in db.LabelDetailsPackings where a.LotNo == Convert.ToInt32(txtLotNo.Text) select a.Power;
    //                    if (q1.Count() != null)
    //                    {
    //                        btnSave.Visible = true;
    //                        ddlPower.Items.Add("Select");
    //                        ddlPower.DataSource = q1;
    //                        ddlPower.DataBind();
    //                    }
    //                }
    //                catch
    //                {
    //                    Messagebox("Please Enter the Correct LotNo");
    //                    txtLotNo.Focus();
    //                }
    //            }
    //            else
    //            {
    //                Messagebox("Incorrect BatchNo and LotNo");
    //                txtLotNo.Text = "";
    //                txtBatchNo.Text = "";
    //                txtBatchNo.Focus();

    //            }
    //        }
    //    }
    }
    #endregion

    protected void ddlTestType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        txtModel.Text = "";
        txtLotNo.Text = "";
        ddlPower.Items.Clear();
        ddlSerialNo.Items.Clear();
        txtQuantity.Text = "";

        ddlLabeldtlLotNo.Items[0].Text= "Select";
        ddlLabeldtlLotNo.SelectedValue = "Select";
        ddlLabeldtlLotNo.Focus();

        //txtDate.Text = "";
        //txtBatchNo.Text = "";
        // btnAdd.Visible = false;
        btnUpdate.Visible = false;
        btnClear.Visible = false;
        btnSerialNo_ConfirmButtonExtender.Enabled = false;

    }

    #region Labeldtllotnoindexchange
    protected void ddlLabeldtlLotNo_SelectedIndexChanged(object sender, EventArgs e)
    {          
        if(ddlTestType.Text=="Select")
        {
            Messagebox("Please Choose a Test Type");
            ddlTestType.Focus();
        }
        else
        {
            btnSerialNo.Visible = true;
            ddlPower.Focus();
            ddlSerialNo.Items.Clear();
            ddlPower.Items.Clear();
            btnUpdate.Visible = false;
            btnSave.Visible = false;
            var query = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == ddlLabeldtlLotNo.Text && a.Type == ddlTestType.Text select a;
            if (query.Count() != 0)
            {
                btnUpdate.Visible = true;
                btnSerialNo_ConfirmButtonExtender.Enabled = true;

                string t = query.Single().LotNo.ToString();
                DateTime dnt = query.Single().Date.Value;
                txtDate.Text = dnt.ToString("dd/MM/yyyy");

                txtModel.Text = query.Single().Model.ToString();               


                txtQuantity.Text = query.Single().Quantity.ToString();

                
                //var query11 = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text && a.LotNo == ddlLabeldtlLotNo.Text select a.Power;
                //ddlPower.DataSource = query11;
                //ddlPower.DataBind();
                var q1 = from a in db.LabelDetailsPackings where a.LotNo == ddlLabeldtlLotNo.Text select a.Power;
                if (q1.Count() != null)
                {              
                    ddlPower.Items.Add("Select");
                    ddlPower.DataSource = q1;
                    ddlPower.DataBind();
                }
               

                var query1 = from a in db.QcSerialNos where a.LotNo == Convert.ToInt32(t) && a.TestType == ddlTestType.Text select a.SerialNo;

                ddlSerialNo.DataSource = query1;
                ddlSerialNo.DataBind();

                btnClear.Visible = true;
            }
            else
            {
                CheckBoxList1.Enabled = true;

                //CheckBoxList1.EnableViewState = true;
                btnSave.Visible = true;
                btnClear.Visible = true;
                iclear();
                LabelDetailsPacking lab = new LabelDetailsPacking();
                var q = (from a in db.LabelDetailsPackings where a.LotNo ==ddlLabeldtlLotNo.Text select a.Model).Distinct();
                if (q.Count() != 0)
                {
                    try
                    {
                        // new correction made for Multiple Model dropdown 25-09-2010 //

                        ddlModelNumber.Items.Clear();
                        var qModelNum = from a in db.LabelDetailsPackings where a.LotNo == ddlLabeldtlLotNo.Text select a.Model;
                        ddlModelNumber.Items.Add("Select");
                        ddlModelNumber.DataSource = qModelNum;
                        ddlModelNumber.DataBind();

                        // new correction made for Multiple Model dropdown 25-09-2010 //

                        txtModel.Text = q.Single().ToString();
                        var q1 = from a in db.LabelDetailsPackings where a.LotNo == ddlLabeldtlLotNo.Text select a.Power;
                        if (q1.Count() != null)
                        {
                            btnSave.Visible = true;
                            ddlPower.Items.Add("Select");
                            ddlPower.DataSource = q1;
                            ddlPower.DataBind();
                        }
                    }
                    catch
                    {
                        Messagebox("Please Enter the Correct LotNo");
                        txtLotNo.Focus();
                    }
                }
                else
                {
                    Messagebox("Incorrect BatchNo and LotNo");
                    txtLotNo.Text = "";
                    txtBatchNo.Text = "";
                    txtBatchNo.Focus();

                }
            }
        }

    }
    #endregion

    #region MHSRBatchNo
    protected void txtBatchNo_TextChanged(object sender, EventArgs e)
    {
        ddlLabeldtlLotNo.Items.Clear();
        ddlTestType.Focus();
        var query = from a in db.QualityControls where a.BatchNo == txtBatchNo.Text select a;
        if (query.Count() != 0)
        {
            var q1 = from a in db.MHSRs where a.BatchNo == txtBatchNo.Text select a;
            if (q1.Count() != 0)
            {
                ddlLabeldtlLotNo.Items.Add("Select");
                if (q1.Single().LotNo1.ToString() != "")
                {
                    ddlLabeldtlLotNo.Items.Add((q1.Single().LotNo1.Value).ToString());
                }
                if (q1.Single().LotNo2.ToString() != "")
                {
                    ddlLabeldtlLotNo.Items.Add((q1.Single().LotNo2.Value).ToString());
                }
                if (q1.Single().LotNo3.ToString() != "")
                {
                    ddlLabeldtlLotNo.Items.Add((q1.Single().LotNo3.Value).ToString());
                }
                if (q1.Single().LotNo4.ToString() != "")
                {
                    ddlLabeldtlLotNo.Items.Add((q1.Single().LotNo4.Value).ToString());
                }
                if (q1.Single().LotNo5.ToString() != "")
                {
                    ddlLabeldtlLotNo.Items.Add((q1.Single().LotNo5.Value).ToString());
                }
                if (q1.Single().LotNo6.ToString() != "")
                {
                    ddlLabeldtlLotNo.Items.Add((q1.Single().LotNo6.Value).ToString());
                }
            }
        }
            else
            {
                var q2 = from a in db.MHSRs where a.BatchNo == txtBatchNo.Text select a;
                if (q2.Count() != 0)
                {
                    ddlLabeldtlLotNo.Items.Add("Select");
                    if (q2.Single().LotNo1.ToString() != "")
                    {
                        ddlLabeldtlLotNo.Items.Add((q2.Single().LotNo1.Value).ToString());
                    }
                    if (q2.Single().LotNo2.ToString() != "")
                    {
                        ddlLabeldtlLotNo.Items.Add((q2.Single().LotNo2.Value).ToString());
                    }
                    if (q2.Single().LotNo3.ToString() != "")
                    {
                        ddlLabeldtlLotNo.Items.Add((q2.Single().LotNo3.Value).ToString());
                    }
                    if (q2.Single().LotNo4.ToString() != "")
                    {
                        ddlLabeldtlLotNo.Items.Add((q2.Single().LotNo4.Value).ToString());
                    }
                    if (q2.Single().LotNo5.ToString() != "")
                    {
                        ddlLabeldtlLotNo.Items.Add((q2.Single().LotNo5.Value).ToString());
                    }
                    if (q2.Single().LotNo6.ToString() != "")
                    {
                        ddlLabeldtlLotNo.Items.Add((q2.Single().LotNo6.Value).ToString());
                    }
                }
                else
                {
                    Messagebox("Please Enter the Correct Batch Number");
                    txtBatchNo.Focus();
                    txtBatchNo.Text = "";
                }

            }
        }
       
    #endregion
    }
