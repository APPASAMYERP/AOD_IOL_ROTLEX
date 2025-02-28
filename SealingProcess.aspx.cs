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

public partial class SealingProcess : System.Web.UI.Page
{
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbProcessName.Text = Session["Cut Type"].ToString();

            if (lbProcessName.Text == "Sealing Cup")
            {
                lbProcessName.Text = "BLISTER SEALING";
            }
            else
            {
                lbProcessName.Text = "SEALING POUCH";
            }

        }
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        drpPwr.Focus();
        btnSave.Visible = true;
        btnClear.Visible = true;
        string tn = txtLotNo.Text;
        txtLotNo.Text = tn.ToUpper();
        txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        SoftLensDataContext db = new SoftLensDataContext();
        var query = from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.SealingProcess == lbProcessName.Text select row;
        gvSealingPro.DataSource = query;
        gvSealingPro.DataBind();
        try
        {
            Label l15 = (Label)gvSealingPro.Rows[gvSealingPro.Rows.Count - 1].FindControl("Label15");
            txtPrevDate.Text = l15.Text;
        }
        catch
        {
        }
        SealingCupandPouch sealing = new SealingCupandPouch();
        Tumbling tumble = new Tumbling();
        try
        {
            var tm = from a in db.Tumblings
                     where a.TumblingLotNo == txtLotNo.Text
                     select new
                     {
                         a.ModelNo,
                     };
            txtModelNo.Text = tm.Single().ModelNo.ToString();
            drpPwr.Items.Clear();
            drpPwr.Items.Add("Select");

            var seg = from a in db.PowerSegregationChilds
                      where a.TumblingNo == txtLotNo.Text
                      select a;

            drpPwr.DataSource = seg;
            drpPwr.DataTextField = "Power";
            drpPwr.DataBind();

        }
        catch
        {
        }
        //if (lbProcessName.Text == "SEALING CUP")
        //{
        //    //var query1 = (from t in db.MIinFQIs where t.TumblingNo == txtLotNo.Text select t.CompletedQty).Max();
        //    //try
        //    //{
        //    //    txtTotalQuantity.Text = query1.ToString();
        //    //}
        //    //catch
        //    //{
        //    //    Messagebox("TumblingNo Doesn't Exist");
        //    //    txtLotNo.Text = "";
        //    //    txtLotNo.Focus();

        //    }
        //}
        //if (lbProcessName.Text == "SEALING POUCH")
        //{
        //    var query2 = (from t in db.SealingCupandPouches where t.TumblingLotNo == txtLotNo.Text && t.SealingProcess == "SEALING CUP" select t.TotCompletedQuantity).Max();
        //    try
        //    {
        //        txtTotalQuantity.Text = query2.ToString();
        //    }
        //    catch
        //    {
        //        Messagebox("TumblingNo Doesn't Exist");
        //        txtLotNo.Text = "";
        //        txtLotNo.Focus();
        //    }
        //}

        var tot = (from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.SealingProcess == lbProcessName.Text select a.AcceptedQuantity).Sum();
        if (tot == null)
        {
            txtTCompQty.Text = "0";
        }
        else
        {
            txtTCompQty.Text = tot.ToString();
        }


    }

    protected void drpPwr_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAccpQty.Text = "";
        txtProgQty.Text = "";
        txtProgQty.Focus();
        SoftLensDataContext db = new SoftLensDataContext();
        MIinFQI micro = new MIinFQI();
        try
        {

            if (lbProcessName.Text == "SEALING CUP")
            {
                var que1 = (from t in db.MIinFQIs
                            where t.GlassyNo == txtLotNo.Text && t.Power == Convert.ToDecimal(drpPwr.Text)
                            select t.AcceptedQty).Sum();
                if (que1 != null)
                {
                    txtReceivedQuantity.Text = que1.ToString();
                    txtProgQty.Focus();
                    var q = (from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPwr.Text) && row.SealingProcess == "SEALING CUP" select row.ProgQuantity).Sum();
                    var query1 = from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPwr.Text) && row.SealingProcess == "SEALING CUP" select row.ReceivedQuantity;
                    if (q != null)
                    {
                        txtBalanceQty.Text = (que1.Value - q.Value).ToString();
                        var query = from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.SealingProcess == lbProcessName.Text && row.Power == Convert.ToDecimal(drpPwr.Text) select row;
                        gvSealingPro.DataSource = query;
                        gvSealingPro.DataBind();
                    }
                    else
                    {
                        txtBalanceQty.Text = que1.ToString();
                    }
                }
                else
                {
                    Messagebox("No Quantity Avail for this Power");
                    txtReceivedQuantity.Text = "";
                    drpPwr.Focus();
                }
            }
            if (lbProcessName.Text == "SEALING POUCH")
            {
                var que1 = (from t in db.SealingCupandPouches
                            where t.TumblingLotNo == txtLotNo.Text && t.Power == Convert.ToDecimal(drpPwr.Text) && t.SealingProcess == "SEALING CUP"
                            select t.AcceptedQuantity).Sum();
                if (que1 != null)
                {
                    txtReceivedQuantity.Text = que1.ToString();
                    txtProgQty.Focus();
                    var q = (from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPwr.Text) && row.SealingProcess == "SEALING POUCH" select row.ProgQuantity).Sum();
                    var query1 = (from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPwr.Text) && row.SealingProcess == "SEALING CUP" select row.AcceptedQuantity).Sum();
                    if (q != null)
                    {
                        txtBalanceQty.Text = (query1.Value - q.Value).ToString();
                        var query = from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.SealingProcess == lbProcessName.Text && row.Power == Convert.ToDecimal(drpPwr.Text) select row;
                        gvSealingPro.DataSource = query;
                        gvSealingPro.DataBind();
                    }
                    else
                    {
                        txtBalanceQty.Text = que1.ToString();
                    }
                }
                else
                {
                    Messagebox("No Quantity Avail for this Power");
                    txtReceivedQuantity.Text = "";
                    drpPwr.Focus();
                }
            }
        }
        catch
        {
        }

    }
    protected void txtProgQty_TextChanged(object sender, EventArgs e)
    {
        txtAccpQty.Text = "";
        SoftLensDataContext db = new SoftLensDataContext();
        if (txtProgQty.Text != "")
        {
            var prog = (from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text) && a.SealingProcess == lbProcessName.Text select a.ProgQuantity).Sum();

            int sumofProgressQty = 0;
            if (prog != null)
            {
                sumofProgressQty = prog.Value;
            }

            if (btnUpdate.Visible == true)
            {
                Label pq = gvSealingPro.SelectedRow.FindControl("Label10") as Label;

                sumofProgressQty = sumofProgressQty - Convert.ToInt32(pq.Text);

                txtAccpQty.Focus();
                //  txtBalanceQuantity.Text = val.ToString();
                txtAccpQty.Text = "";

                Label l17 = (Label)gvSealingPro.SelectedRow.FindControl("Label17");

                if (gvSealingPro.Rows.Count - 1 == gvSealingPro.SelectedRow.RowIndex)
                {
                    txtBalanceQty.Text = ((Convert.ToInt32(pq.Text) + Convert.ToInt32(l17.Text)) - Convert.ToInt32(txtProgQty.Text)).ToString();
                }
                //else
                //{
                //    if (Convert.ToInt32(txtProgQty.Text) <= Convert.ToInt32(pq.Text))
                //    {
                //        txtBalanceQty.Text = (Convert.ToInt32(pq.Text) - Convert.ToInt32(txtProgQty.Text)).ToString();
                //    }
                //    else
                //    {
                //        Messagebox("Progress Qty exceeds the Lmt");
                //        txtProgQty.Text = "";
                //        txtProgQty.Focus();
                //    }
                //}
                if ((Convert.ToInt32(txtReceivedQuantity.Text) - (sumofProgressQty + Convert.ToInt32(txtProgQty.Text))) < 0)
                {
                    Messagebox("Progress Qty is Greater than Received Qty");
                    txtProgQty.Text = "";
                    txtProgQty.Focus();
                }
            }
            else
            {

                var query3 = (from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text) && a.SealingProcess == lbProcessName.Text select a.ProgQuantity).Sum();

                sumofProgressQty = 0;
                if (query3 != null)
                {
                    sumofProgressQty = query3.Value;
                }

                if (Convert.ToInt32(txtProgQty.Text) > Convert.ToInt32(txtReceivedQuantity.Text))
                {

                    Messagebox("Value is Greater than Received Qty");
                    txtProgQty.Text = "";
                    txtProgQty.Focus();

                }
                else
                {

                    btnSave.Enabled = true;
                    var bal = (from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text) && a.SealingProcess == lbProcessName.Text select a.ProgQuantity).Sum();
                    // var bal1 = (from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text) && a.SealingProcess == lbProcessName.Text select a.BalanceQty)();
                    if (Convert.ToInt32(txtReceivedQuantity.Text) != bal)
                        if (bal == null)
                        {
                            txtBalanceQty.Text = (Convert.ToInt32(txtReceivedQuantity.Text) - Convert.ToInt32(txtProgQty.Text)).ToString();
                        }
                        else
                        {
                            txtBalanceQty.Text = ((Convert.ToInt32(txtReceivedQuantity.Text) - bal) - Convert.ToInt32(txtProgQty.Text)).ToString();
                        }
                    else
                    {
                        Messagebox("Progress Qty is Greater than Balance Qty");
                        //txtProgQty.Text = "";
                        txtProgQty.Focus();
                    }

                    int val = (Convert.ToInt32(txtReceivedQuantity.Text) - (sumofProgressQty + Convert.ToInt32(txtProgQty.Text)));
                    if (val < 0)
                    {
                        txtProgQty.Text = "";
                        Messagebox("Value is Greater than Received Qty");
                        txtProgQty.Focus();

                    }
                    else
                    {
                        txtAccpQty.Focus();
                        txtAccpQty.Text = "";
                        // txtBalanceQuantity.Text = val.ToString();
                    }
                }
            }
        }
    }

    protected void clear()
    {
        txtAccpQty.Text = "";
        txtTCompQty.Text = "";
        txtDate.Text = "";
        txtModelNo.Text = "";
        txtPrevDate.Text = "";
        txtReceivedQuantity.Text = "";
        txtBalanceQty.Text = "0";
        txtProgQty.Text = "";
        txtRejQty.Text = "";
        txtWipDnby0.Text = "";
        txtWipDnby.Text = "";
        txtTotalQuantity.Text = "";
        drpPwr.Text = "Select";
        gvSealingPro.DataSource = null;
        gvSealingPro.DataBind();
    }

    protected void txtAccpQty_TextChanged(object sender, EventArgs e)
    {
        SoftLensDataContext db = new SoftLensDataContext();
        if (txtAccpQty.Text != "" && txtProgQty.Text != "")
        {
            txtRejQty.Text = (Convert.ToInt32(txtProgQty.Text) - Convert.ToInt32(txtAccpQty.Text)).ToString();
            if (btnSave.Visible == true)
            {
                var comp = (from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.SealingProcess == lbProcessName.Text select a.AcceptedQuantity).Sum();
                if (comp != null)
                {
                    txtTCompQty.Text = (Convert.ToInt32(txtAccpQty.Text) + comp).ToString();
                }
                else
                {
                    txtTCompQty.Text = Convert.ToInt32(txtAccpQty.Text).ToString();
                }
                txtWipDnby0.Focus();
            }
            if (btnUpdate.Visible == true)
            {
                string idno = Session["ID"].ToString();
                var comp1 = from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.Id == Convert.ToInt32(idno) && a.SealingProcess == lbProcessName.Text select a.AcceptedQuantity;
                var comp2 = from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.Id == Convert.ToInt32(idno) && a.SealingProcess == lbProcessName.Text select a.TotCompletedQuantity;
                //string acp = (comp1.ToString() - comp2);
                if (comp1.Single().Value > comp2.Single().Value)
                {
                    txtTCompQty.Text = ((comp1.Single().Value - comp2.Single().Value) + Convert.ToInt32(txtAccpQty.Text)).ToString();
                }
                else
                {
                    txtTCompQty.Text = ((comp2.Single().Value - comp1.Single().Value) + Convert.ToInt32(txtAccpQty.Text)).ToString();
                }

            }

            if (Convert.ToInt32(txtAccpQty.Text) > Convert.ToInt32(txtProgQty.Text) || Convert.ToInt32(txtAccpQty.Text) > Convert.ToInt32(txtReceivedQuantity.Text))
            {
                Messagebox("Limit eXceeds Progress Qty");
                txtAccpQty.Text = "";
                txtAccpQty.Focus();
            }

        }
        else
        {
            Messagebox("Please Enter the Projected Quantity");
            txtAccpQty.Text = "";
            txtProgQty.Focus();
        }

    }
    protected void gvSealingPro_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPwr.Text != "Select")
        {
            if (gvSealingPro.Rows.Count - 1 == gvSealingPro.SelectedRow.RowIndex && Session["up"].Equals(1))
            {
                btnClear.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                SoftLensDataContext db = new SoftLensDataContext();
                Label l8 = (Label)gvSealingPro.SelectedRow.FindControl("Label8");
                drpPwr.Text = l8.Text;

                Label l16 = (Label)gvSealingPro.SelectedRow.FindControl("Label16");
                Session["ID"] = l16.Text;
                Label l2 = (Label)gvSealingPro.SelectedRow.FindControl("Label2");
                // Session["ID"] = l2.Text;

                Label l3 = (Label)gvSealingPro.SelectedRow.FindControl("Label3");
                //Session["ID"] = l3.Text;
                txtLotNo.Text = l3.Text;
                Label l4 = (Label)gvSealingPro.SelectedRow.FindControl("Label4");
                // Session["ID"] = l4.Text;
                txtModelNo.Text = l4.Text;
                Label l5 = (Label)gvSealingPro.SelectedRow.FindControl("Label5");
                txtTotalQuantity.Text = l5.Text;
                Label l6 = (Label)gvSealingPro.SelectedRow.FindControl("Label6");
                txtTCompQty.Text = l6.Text;
                Label l7 = (Label)gvSealingPro.SelectedRow.FindControl("Label7");
                txtPrevDate.Text = l7.Text;
                //Label l8 = (Label)gvSealingPro.SelectedRow.FindControl("Label8");
                //drpPwr.Text = l8.Text;
                Label l9 = (Label)gvSealingPro.SelectedRow.FindControl("Label9");
                txtReceivedQuantity.Text = l9.Text;
                Label l10 = (Label)gvSealingPro.SelectedRow.FindControl("Label10");
                txtProgQty.Text = l10.Text;
                Label l11 = (Label)gvSealingPro.SelectedRow.FindControl("Label11");
                txtAccpQty.Text = l11.Text;
                Label l12 = (Label)gvSealingPro.SelectedRow.FindControl("Label12");
                txtRejQty.Text = l12.Text;
                Label l13 = (Label)gvSealingPro.SelectedRow.FindControl("Label13");
                txtWipDnby0.Text = l13.Text;
                Label l14 = (Label)gvSealingPro.SelectedRow.FindControl("Label14");
                txtWipDnby.Text = l14.Text;
                Label l15 = (Label)gvSealingPro.SelectedRow.FindControl("Label15");
                txtDate.Text = l15.Text;
                Label l17 = (Label)gvSealingPro.SelectedRow.FindControl("Label17");
                txtBalanceQty.Text = l17.Text;

            }
            else
            {
                Messagebox("This Row values cannot be Updated & Permission is Denied");
                clear();
                btnUpdate.Visible = false;
            }
        }
        else
        {
            Messagebox("Please Choose a Power to Update a process");
            drpPwr.Focus();
        }

    }


    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        if (txtProgQty.Text == "")
        {
            Messagebox("Please Enter Prog Qty");
            txtProgQty.Focus();
        }
        else if (txtAccpQty.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtAccpQty.Focus();
        }
        else if (txtWipDnby.Text == "")
        {
            Messagebox("Please Enter WipingDoneby 1 Name");
            txtWipDnby.Focus();
        }


        else
        {
            SoftLensDataContext db = new SoftLensDataContext();
            SealingCupandPouch sealing = new SealingCupandPouch();
            {
                sealing.TumblingLotNo = txtLotNo.Text;
                sealing.ModelNo = txtModelNo.Text;
                sealing.TotalQuantity = Convert.ToInt32(txtTotalQuantity.Text);
                sealing.TotCompletedQuantity = Convert.ToInt32(txtTCompQty.Text);
                sealing.Power = Convert.ToDecimal(drpPwr.Text);
                sealing.ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
                sealing.BalanceQty = Convert.ToInt32(txtBalanceQty.Text);
                sealing.ProgQuantity = Convert.ToInt32(txtProgQty.Text);
                sealing.RejectedQuantity = Convert.ToInt32(txtRejQty.Text);
                sealing.AcceptedQuantity = Convert.ToInt32(txtAccpQty.Text);
                sealing.SealingDoneBy1 = txtWipDnby0.Text;
                if (txtWipDnby0.Text == "&nbsp;")
                {
                    txtWipDnby0.Text = "";
                }
                sealing.SealingDoneBy2 = txtWipDnby.Text;
                if (txtPrevDate.Text != "")
                {
                    sealing.PrevDate = Convert.ToDateTime(txtDate.Text, provider);
                }
                sealing.Date = Convert.ToDateTime(txtDate.Text, provider);
                sealing.SealingProcess = lbProcessName.Text;
            }
            db.SealingCupandPouches.InsertOnSubmit(sealing);
            db.SubmitChanges();
            Messagebox("Saved Successfully");
            clear();
            var query = from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.SealingProcess == lbProcessName.Text select row;
            gvSealingPro.DataSource = query;
            gvSealingPro.DataBind();

            txtLotNo.Text = "";
            btnSave.Visible = false;
        }
    }
    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        if (txtProgQty.Text == "")
        {
            Messagebox("Please Enter Prog Qty");
            txtProgQty.Focus();
        }
        else if (txtAccpQty.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtAccpQty.Focus();
        }
        else if (txtWipDnby.Text == "")
        {
            Messagebox("Please Enter WipingDoneby 1 Name");
            txtWipDnby.Focus();
        }


        else
        {
            SoftLensDataContext db = new SoftLensDataContext();
            LensWiping lens = new LensWiping();
            string idno = Session["ID"].ToString();
            var q = from a in db.SealingCupandPouches where a.TumblingLotNo == txtLotNo.Text && a.Id == Convert.ToInt32(idno) select a;
            if (q.Count() > 0)
            {
                q.Single().TumblingLotNo = txtLotNo.Text;
                q.Single().ModelNo = (txtModelNo.Text);
                q.Single().TotalQuantity = q.Single().TotalQuantity;
                q.Single().PrevDate = Convert.ToDateTime(txtDate.Text, provider);
                q.Single().Power = q.Single().Power;
                q.Single().TotCompletedQuantity = Convert.ToInt32(txtTCompQty.Text);
                q.Single().BalanceQty = Convert.ToInt32(txtBalanceQty.Text);
                q.Single().ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
                q.Single().RejectedQuantity = Convert.ToInt32(txtRejQty.Text);
                q.Single().AcceptedQuantity = Convert.ToInt32(txtAccpQty.Text);
                q.Single().ProgQuantity = Convert.ToInt32(txtProgQty.Text);
                q.Single().SealingDoneBy1 = txtWipDnby0.Text;
                q.Single().SealingDoneBy2 = txtWipDnby.Text;
                q.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
            }
            db.SubmitChanges();
            Messagebox("Updated Successfully");
            clear();
            var query = from row in db.SealingCupandPouches where row.TumblingLotNo == txtLotNo.Text && row.SealingProcess == lbProcessName.Text select row;
            gvSealingPro.DataSource = query;
            gvSealingPro.DataBind();

            txtLotNo.Text = "";
            btnClear.Visible = false;
            btnUpdate.Visible = false;
        }
    }
    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        btnUpdate.Visible = false;
        btnSave.Visible = false;
        txtLotNo.Text = "";
    }
    protected void txtWipDnby0_TextChanged(object sender, EventArgs e)
    {
        string up = txtWipDnby0.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtWipDnby0.Text = up.ToUpper();
                txtWipDnby.Focus();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: M.BALAJI");
                txtWipDnby0.Text = "";
                txtWipDnby0.Focus();

            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtWipDnby.Text = "";
            txtWipDnby.Focus();
        }
    }
    protected void txtWipDnby_TextChanged(object sender, EventArgs e)
    {
        string up = txtWipDnby.Text;
        try
        {
            if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
            {
                txtWipDnby.Text = up.ToUpper();
            }
            else
            {
                Messagebox("Please Enter With INITIAL ex: M.BALAJI");
                txtWipDnby.Text = "";
                txtWipDnby.Focus();
            }
        }
        catch
        {
            Messagebox("Please Enter With INITIAL ex: M.BALAJI");
            txtWipDnby.Text = "";
            txtWipDnby.Focus();
        }

    }
}
