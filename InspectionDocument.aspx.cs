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

public partial class InspectionDocument : System.Web.UI.Page
{
    SoftLensDataContext db = new SoftLensDataContext();
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }


    private void Clear()
    {
        txtLotNo.Text = "";
        btnChart.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        btnClear.Visible = false;
        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            // var query = from r in db.LabelDetailsPackings where r.LotNo == Convert.ToInt32(txtLotNo.Text) select r;
            var q = from r in db.LabelDetailsPackings where r.LotNo == txtLotNo.Text select r;
            if (q.Count() > 0)
            {
                GridView1.DataSource = q;
                GridView1.DataBind();
                
            }
            else
            {
                txtLotNo.Text = "";
                Messagebox("LotNo Not Avaialble");
            }

            var q1 = from r in db.InspectionDocDatas where r.LotNo == txtLotNo.Text select r;
            if (q1.Count() > 0)
            {
                btnUpdate.Visible = true;
                btnChart.Visible = true;
                btnClear.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnChart.Visible = true;
                btnClear.Visible = true;

            }
        }
        catch
        {
            
        }
    }

    protected void btnChart_Click(object sender, ImageClickEventArgs e)
    {
        var query = from r in db.QcSerialNos where r.LotNo == Convert.ToInt32(txtLotNo.Text) select r;
        ArrayList serialno = new ArrayList();
        ArrayList Type = new ArrayList();
        foreach (var val in query)
        {
            serialno.Add(val.SerialNo.ToString());
            Type.Add(val.TestType.ToString());
        }
        CheckBoxList1.Items.Clear();
        for (int i = 1; i <= 200; i++)
        {
            int f = 0;
            for (int j = 0; j < serialno.Count; j++)
            {
                if (Convert.ToInt32(serialno[j]) == i)
                {
                    if (Type[j].ToString() == "Sterile")
                    {
                        CheckBoxList1.Items.Add("ST");
                    }
                    else
                    {
                        CheckBoxList1.Items.Add("LAL");
                    }
                                       
                    CheckBoxList1.Items[i - 1].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "Green");
                    CheckBoxList1.Items[i - 1].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontSize, "13");
                    CheckBoxList1.Items[i - 1].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontWeight, "Bold");
                    CheckBoxList1.Items[i - 1].Selected = true;
                    f = 1;
                    break;
                    
                }
             
            }
            if(f!=1)
            {
                CheckBoxList1.Items.Add(i.ToString());
                CheckBoxList1.Items[i - 1].Selected = true;
            }
        }

        try
        {
            var q = from r in db.InspectionsDocs where r.LotNo == Convert.ToInt32(txtLotNo.Text) select r.SerialNo;
            ArrayList items = new ArrayList();
            foreach (var val in q)
            {
                items.Add(val.Value);
            }


            for (int k = 0; k<items.Count; k++)
            {
                CheckBoxList1.Items[Convert.ToInt32( items[k].ToString())-1].Selected = false;
                CheckBoxList1.Items[Convert.ToInt32(items[k].ToString()) - 1].Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, "RED");
                CheckBoxList1.Items[Convert.ToInt32(items[k].ToString()) - 1].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontSize, "13");
                CheckBoxList1.Items[Convert.ToInt32(items[k].ToString()) - 1].Attributes.CssStyle.Add(HtmlTextWriterStyle.FontWeight, "Bold");
            }
        }
        catch
        {
        }

        this.Panel1_ModalPopupExtender.Show();
    }

    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
      
        this.Panel1_ModalPopupExtender.Hide();
      
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        var q = from r in db.LabelDetailsPackings where r.LotNo == txtLotNo.Text select r;
        foreach (var val in q)
        {

            int itemct = 0;
            for (int i = val.StartNo.Value; i <= val.EndNo; i++)
            {
                if (CheckBoxList1.Items[i - 1].Text == "ST" || CheckBoxList1.Items[i - 1].Text == "LAL" || CheckBoxList1.Items[i - 1].Selected == false)
                {
                    itemct++;
                }
            }

            string t = DateTime.Now.ToString("dd/MM/yyyy");

            InspectionDocData insdata = new InspectionDocData()
            {
                Brand = val.BrandName,
                Date = Convert.ToDateTime(t,provider),
                ExpiryDate = Convert.ToDateTime(val.ExpiryDate, provider),
                LotNo = val.LotNo,
                ManufactureDate = Convert.ToDateTime(val.Date, provider),
                Model = val.Model,
                Power = val.Power,
                Qty = val.Qty,
                RemainingQty = val.Qty - itemct,
                SerialFrom = val.StartNo,
                SerialTo = val.EndNo,
                //SterileBatchno = txtSterileBNo.Text,
                SubModel = val.SubModel
            };
            db.InspectionDocDatas.InsertOnSubmit(insdata);
            db.SubmitChanges();
        }
        

        try
        {
            ArrayList item = new ArrayList();
            item = (ArrayList)Session["item"];

            for (int i = 0; i < item.Count; i++)
            {
                 
                InspectionsDoc insptable = new InspectionsDoc()
                {

                    Date =DateTime.Now,
                    LotNo = Convert.ToInt32(txtLotNo.Text),
                    SerialNo = Convert.ToInt32(item[i].ToString())
                };
                db.InspectionsDocs.InsertOnSubmit(insptable);
                db.SubmitChanges();
            }
            Messagebox("Saves successfully");
            btnSave.Visible = false;
            Clear();
        }
        catch
        {
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ArrayList item = new ArrayList();
            item = (ArrayList)Session["item"];

            var q = from r in db.InspectionsDocs where r.LotNo == Convert.ToInt32(txtLotNo.Text) select r;
            db.InspectionsDocs.DeleteAllOnSubmit(q);
            db.SubmitChanges();

            for (int i = 0; i < item.Count; i++)
            {

                InspectionsDoc insptable = new InspectionsDoc()
                {


                    LotNo = Convert.ToInt32(txtLotNo.Text),
                    SerialNo = Convert.ToInt32(item[i].ToString())
                };
                db.InspectionsDocs.InsertOnSubmit(insptable);
                db.SubmitChanges();
            }
            Messagebox("Saves successfully");
            btnUpdate.Visible = false;
            Clear();
        }
        catch
        {
        }

    }
    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        this.Panel1_ModalPopupExtender.Hide();
        ArrayList items = new ArrayList();
        for (int i = 1; i <= 200; i++)
        {
            if (CheckBoxList1.Items[i - 1].Selected == false)
            {
                items.Add(i);
            }
        }
        Session["item"] = items;
    }
}
