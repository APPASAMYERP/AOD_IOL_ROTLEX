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

public partial class LensWipingDoc : System.Web.UI.Page
{

    #region Declaration
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext Db = new SoftLensDataContext();
    #endregion


    #region Methods

    protected void clear()
    {

        txtLotNo.Text = "";
        txtModelNo.Text = "";
        txtTotalQuantity.Text = "";
        drpPower.SelectedValue = "--Select--";
        txtDate.Text = "";
        txtReceivedQty.Text = "";
        txtProgressingQty.Text = "";
        txtBalanceQty.Text = "";
        txtAcceptedQty.Text = "";
        txtRejectedQty.Text = "";
        txtTumblingRef.Text = "";
        txtRemarks.Text = "";
        txtWipDnby.Text = "";


    }

    private void GridBind()
    {
        btnSave.Visible = false;
        var query = from row in Db.LensWipings where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        btnClear.Visible = true;
        gvLenswiping.DataSource = query;
        gvLenswiping.DataBind();

    }


    #endregion


    #region events

    protected void Page_Load(object sender, EventArgs e)
    {
        var username = (Session["Username"] as HtmlInputControl).Value;

        if (username == null)
        {
            Response.Redirect("404Page.aspx");
        }
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        //txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }


    protected void txtLotNo_TextChanged(object sender, EventArgs e)
    {
        btnSave.Visible = true;
        btnClear.Visible = true;
        txtDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

        string tn = txtLotNo.Text;
        txtLotNo.Text = tn.ToUpper();

        //var query = from row in Db.PowerSegregationChilds where row.GlassyRecordRef == txtLotNo.Text select row;
        
       
            var qury = from x in Db.NewBtchAllots where x.LotNo == txtLotNo.Text select x;
            if (qury.Count() > 0)
            {
                txtModelNo.Text = qury.Single().Model;
                var seg = from a in Db.PowerSegregationChilds
                          where a.TumblingNo == txtLotNo.Text
                          select a;
                drpPower.Items.Clear();
                drpPower.Items.Add("--Select--");
                drpPower.DataSource = seg;
                drpPower.DataTextField = "Power";
                drpPower.DataValueField = "Power";
                drpPower.DataBind();
            }
           
            //if (query.Count() > 0)
            //{
            //    txtTotalQuantity.Text = query.Single().Qty.ToString();
            //    txtPower.Text = query.Single().Power.ToString();
            //    txtTumblingRef.Text = query.Single().TumblingNo.ToString();

            //var q1 = from row in Db.MattTumblingLens where row.TumblingLotNo == txtTumblingRef.Text select row;
            //var q1 = from row in Db.FinalLensPreparations where row.TumblingNo == txtTumblingRef.Text select row;
            //var q2 = from row in Db.RemattTumblingLens where row.RetumblingRef1 == txtTumblingRef.Text select row;
            //var q3 = from row in Db.RemattTumblingLens where row.RetumblingRef2 == txtTumblingRef.Text select row;
            //var q4 = from row in Db.RemattTumblingLens where row.RetumblingRef3 == txtTumblingRef.Text select row;

            //if (q1.Count() > 0)
            //{
            //    txtModelNo.Text = q1.Single().Model.ToString();
            //}

            //else if (q2.Count() > 0)
            //{
            //    txtModelNo.Text = q2.Single().Model1.ToString();
            //}
            //else if (q3.Count() > 0)
            //{
            //    txtModelNo.Text = q3.Single().Model2.ToString();
            //}
            //else
            //{
            //    txtModelNo.Text = q4.Single().Model3.ToString();
            //}

            //}
            //else
            //{
            //    Messagebox("Enter Valid Glassy No");
            //    txtLotNo.Text = "";
            //    txtLotNo.Focus();
            //    btnClear.Visible = false;
            //    btnSave.Visible = false;
            //}
        
    }


    protected void txtProgressingQty_TextChanged(object sender, EventArgs e)
    {
        txtBalanceQty.Text = (Convert.ToInt32(txtReceivedQty.Text) - Convert.ToInt32(txtProgressingQty.Text)).ToString();
        txtAcceptedQty.Focus();
    }


    protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
    {
        txtRejectedQty.Text = (Convert.ToInt32(txtProgressingQty.Text) - Convert.ToInt32(txtAcceptedQty.Text)).ToString();
        txtRemarks.Focus();
    }


    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string tn = txtRemarks.Text;
        txtRemarks.Text = tn.ToUpper();
        txtWipDnby.Focus();

    }


    protected void txtWipDnby_TextChanged(object sender, EventArgs e)
    {
        string tn = txtWipDnby.Text;
        txtWipDnby.Text = tn.ToUpper();
    }


    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    { try{
        if (txtReceivedQty.Text == "")
        {
            Messagebox("Please Enter Received Qty");
            txtReceivedQty.Focus();
        }
        else if (txtProgressingQty.Text == "")
        {
            Messagebox("Please Enter Accepted Qty ");
            txtProgressingQty.Focus();
        }
        else if (txtWipDnby.Text == "")
        {
            Messagebox("Please Enter WipingDone by ");
            txtWipDnby.Focus();
        }
        else
        {
            var q = from x in Db.LensWipings where x.GlassyNo == txtLotNo.Text && x.Model == txtModelNo.Text && x.Power == Convert.ToDecimal(drpPower.SelectedValue) select x;
            if (q.Count() == 0)
            {
                LensWiping lens = new LensWiping();
                lens.GlassyNo = txtLotNo.Text;
                lens.Model = txtModelNo.Text;
                lens.TotalQuantity = Convert.ToInt32(txtTotalQuantity.Text);
                lens.Power = Convert.ToDecimal(drpPower.SelectedValue);
                lens.ReceivedQty = Convert.ToInt32(txtReceivedQty.Text);
                lens.ProgressingQty = Convert.ToInt32(txtProgressingQty.Text);
                lens.BalanceQty = Convert.ToInt32(txtBalanceQty.Text);
                lens.AcceptedQty = Convert.ToInt32(txtAcceptedQty.Text);
                lens.RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
                lens.TumblingNo = txtTumblingRef.Text;
                lens.Remarks = txtRemarks.Text;
                lens.WipingBy = txtWipDnby.Text;
                lens.Date = Convert.ToDateTime(txtDate.Text, provider);
                Db.LensWipings.InsertOnSubmit(lens);
                Db.SubmitChanges();
                Messagebox("Saved Succefully");
                clear();
                btnSave.Visible = false;
                btnClear.Visible = false;

            }
            else
            {
                Messagebox("Lot Number Already Exists..");
            }
        }
        }
            catch (Exception ex)
            {
                Messagebox(ex.ToString());
            }

    }


    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        clear();
        txtLotNo.Text = "";
        gvLenswiping.DataSource = null;
        gvLenswiping.DataBind();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }


    #endregion


    #region ref


    //  protected void txtAccpQty_TextChanged(object sender, EventArgs e)
    //  { 
    //      SoftLensDataContext db = new SoftLensDataContext();

    //      if (txtAccpQty.Text != "" && txtProgQty.Text != "")
    //      {

    //          if (Convert.ToInt32(txtAccpQty.Text) > Convert.ToInt32(txtProgQty.Text))
    //          {
    //              Messagebox("Accepted Qty is Greater than ProcessQty");
    //              txtAccpQty.Text = "";
    //              txtAccpQty.Focus();
    //          }
    //          else
    //          {

    //              txtRejQty.Text = Convert.ToString((Convert.ToInt32(txtProgQty.Text) - Convert.ToInt32(txtAccpQty.Text)));
    //              if (btnSave.Visible == true)
    //              {
    //                  int compval = 0;
    //                  var query = (from row in db.LensWipings where row.TumblingLotNo == txtLotNo.Text select row.CompQuantity).Max();
    //                  if (query == null)
    //                  {
    //                      compval = 0;
    //                  }
    //                  else
    //                  {
    //                      compval = query.Value;
    //                  }
    //                  txtTCompQty.Text = Convert.ToString(compval + Convert.ToInt32(txtAccpQty.Text));
    //                  txtWipDnby.Focus();
    //              }
    //              else
    //              {
    //                  string accpqty = Session["accpQty"].ToString();
    //                  string complqty = Session["complQty"].ToString();
    //                  if (Convert.ToInt32(txtAccpQty.Text) > Convert.ToInt32(accpqty))
    //                  {
    //                      int val = Convert.ToInt32(txtAccpQty.Text) - Convert.ToInt32(accpqty);
    //                      txtTCompQty.Text = Convert.ToString(Convert.ToInt32(complqty) + val);
    //                  }
    //                  else
    //                  {
    //                      int val = Convert.ToInt32(accpqty) - Convert.ToInt32(txtAccpQty.Text);
    //                      txtTCompQty.Text = Convert.ToString(Convert.ToInt32(complqty) - val);
    //                  }
    //                  txtWipDnby.Focus();
    //              }
    //          }
    //      }
    //      else
    //      {
    //          Messagebox("Please Enter the Projected Quantity");
    //          txtAccpQty.Text = "";
    //          txtProgQty.Focus();
    //      }
    //  }


    //  protected void clear()
    //  {

    //      txtAccpQty.Text = "";
    //      txtTCompQty.Text = "";
    //      txtDate.Text = "";
    //      txtModelNo.Text = "";
    //      txtPrevDate.Text = "";
    //      txtReceivedQuantity.Text = "";
    //      txtProgQty.Text = "";
    //      txtBalanceQty.Text = "0";
    //      txtRejQty.Text = "";
    //      txtRmks.Text="";
    //      txtRwk.Text = "";
    //      txtWipDnby.Text="";
    //      txtTotalQuantity.Text = "";
    //      //drpPwr.Text = "Select";              ****************
    //      gvLenswiping.DataSource = null;
    //      gvLenswiping.DataBind();
    //  }

    //  protected void gclear()
    //  {

    //      txtAccpQty.Text = "";
    //      txtTCompQty.Text = "";
    //      txtDate.Text = "";
    //      txtModelNo.Text = "";
    //      txtPrevDate.Text = "";
    //      txtReceivedQuantity.Text = "";
    //      txtProgQty.Text = "";
    //      txtBalanceQty.Text = "0";
    //      txtRejQty.Text = "";
    //      txtRmks.Text = "";
    //      txtRwk.Text = "";
    //      txtWipDnby.Text = "";
    //      txtTotalQuantity.Text = "";

    //      gvLenswiping.DataSource = null;
    //      gvLenswiping.DataBind();
    //  }

    //  protected void txtLotNo_TextChanged(object sender, EventArgs e)
    //  {
    //      btnSave.Visible = true;
    //      btnClear.Visible = true;
    //     // drpPwr.Items.Clear();
    //          string tn = txtLotNo.Text;
    //          txtLotNo.Text = tn.ToUpper();
    //      txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    //      SoftLensDataContext db = new SoftLensDataContext();
    //      var query = from row in db.LensWipings where row.TumblingLotNo == txtLotNo.Text select row;
    //      gvLenswiping.DataSource = query;
    //      gvLenswiping.DataBind();
    //      try
    //      {
    //          Label l6 = (Label)gvLenswiping.Rows[gvLenswiping.Rows.Count - 1].FindControl("Label15");
    //          txtPrevDate.Text = l6.Text;
    //      }
    //      catch
    //      {
    //      }

    //      LensWiping lens = new LensWiping();
    //       Tumbling tumble = new Tumbling();
    //       var tm = from a in db.Tumblings
    //                where a.TumblingLotNo == txtLotNo.Text
    //                select new
    //                    {
    //                        a.ModelNo,
    //                    };
    //       if (tm.Count() == 0)
    //       {
    //           Messagebox("Enter Valid Tumbling No");
    //           txtLotNo.Text = "";
    //           txtLotNo.Focus();
    //       }
    //       else
    //       {
    //           txtModelNo.Text = tm.Single().ModelNo.ToString();
    //           drpPwr.Items.Clear();

    //       }
    //       var seg = from a in db.PowerSegregationChilds
    //                 where a.TumblingNo == txtLotNo.Text                   
    //                 select a;
    //       drpPwr.Items.Add("Select");
    //      drpPwr.DataSource= seg;
    //      drpPwr.DataTextField ="Power";
    //      drpPwr.DataBind();


    //       var query1 = from t in db.PowerSegregationTables where t.TumblingNo == txtLotNo.Text  select t;
    //       try
    //       {
    //           txtTotalQuantity.Text = query1.Single().TotalQty.ToString();
    //           drpPwr.Focus();
    //       }
    //       catch
    //       {
    //           Messagebox("TumblingNo doesn't Exist");
    //           txtLotNo.Focus();
    //           txtLotNo.Text = "";
    //       }
    //           var tot = (from a in db.LensWipings where a.TumblingLotNo == txtLotNo.Text  select a.AcceptedQuantity).Sum();
    //           if (tot == null)
    //           {
    //               txtTCompQty.Text = "0";
    //           }
    //           else
    //           {
    //               txtTCompQty.Text =  tot.ToString();
    //           }       

    //}                 

    //  protected void txtCompQty_TextChanged(object sender, EventArgs e)
    //  {

    //  }

    //  protected void drpPwr_SelectedIndexChanged1(object sender, EventArgs e)
    //  {
    //      txtAccpQty.Text = "";
    //      txtProgQty.Text = "";
    //      if (drpPwr.SelectedIndex != 0)
    //      {
    //          SoftLensDataContext db = new SoftLensDataContext();
    //          LensWiping lens = new LensWiping();
    //          Tumbling tumble = new Tumbling();

    //          var que1 = from t in db.PowerSegregationChilds
    //                     where t.TumblingNo == txtLotNo.Text && t.Power == Convert.ToDecimal(drpPwr.Text)
    //                     select t.Qty;
    //          txtReceivedQuantity.Text = que1.Single().ToString();

    //          try
    //          {
    //              var query = (from row in db.LensWipings where row.TumblingLotNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPwr.Text) select row.ProgressQuantity).Sum();
    //              var query1 = from row in db.LensWipings where row.TumblingLotNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPwr.Text) select row.ReceivedQuantity;
    //              if (query != null)
    //              {
    //                  txtBalanceQty.Text = (query1.Max() - query.Value).ToString();
    //                  var qy = from row in db.LensWipings where row.TumblingLotNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPwr.Text) select row;
    //                  gvLenswiping.DataSource = qy;
    //                  gvLenswiping.DataBind();
    //              }
    //              else
    //              {
    //                  txtBalanceQty.Text = txtReceivedQuantity.Text;

    //              }
    //              txtProgQty.Focus();
    //          }
    //          catch
    //          {
    //          }
    //      }

    //  }
    protected void gvLenswiping_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (drpPwr.Text != "Select" )
        //{
        //    if (gvLenswiping.Rows.Count - 1 == gvLenswiping.SelectedRow.RowIndex && Session["up"].Equals(1))
        //    {
        //    btnClear.Visible = true;
        //    btnUpdate.Visible = true;
        //    btnSave.Visible = false;
        //    SoftLensDataContext db = new SoftLensDataContext();
        //    LensWiping lens = new LensWiping();
        //    Label l1 = (Label)gvLenswiping.SelectedRow.FindControl("Label1");
        //    Session["ID"] = l1.Text;
        //    Label l2 = (Label)gvLenswiping.SelectedRow.FindControl("Label2");
        //    Label l3 = (Label)gvLenswiping.SelectedRow.FindControl("Label3");
        //    Label l4 = (Label)gvLenswiping.SelectedRow.FindControl("Label4");
        //    Label l5 = (Label)gvLenswiping.SelectedRow.FindControl("Label5");
        //    Label l6 = (Label)gvLenswiping.SelectedRow.FindControl("Label6");
        //    Session["previousDate"] = l6.Text;
        //    Label l7 = (Label)gvLenswiping.SelectedRow.FindControl("Label7");
        //    Label l8 = (Label)gvLenswiping.SelectedRow.FindControl("Label8");
        //    Label l9 = (Label)gvLenswiping.SelectedRow.FindControl("Label9");
        //    Label l10 = (Label)gvLenswiping.SelectedRow.FindControl("Label10");
        //    Label l11 = (Label)gvLenswiping.SelectedRow.FindControl("Label11");
        //    Label l12 = (Label)gvLenswiping.SelectedRow.FindControl("Label12");
        //    Label l13 = (Label)gvLenswiping.SelectedRow.FindControl("Label13");
        //    Label l14 = (Label)gvLenswiping.SelectedRow.FindControl("Label14");
        //    Label l15 = (Label)gvLenswiping.SelectedRow.FindControl("Label15");
        //    Label l16 = (Label)gvLenswiping.SelectedRow.FindControl("Label16");


        //    Session["accpQty"] = l10.Text;
        //    Session["complQty"] = l5.Text;
        //    txtLotNo.Text = l2.Text;
        //    txtModelNo.Text = l3.Text;
        //    txtTotalQuantity.Text = l4.Text;
        //    txtTCompQty.Text = l5.Text;
        //    txtProgQty.Text = l7.Text;
        //    drpPwr.Text = l8.Text;
        //    txtReceivedQuantity.Text = l9.Text;
        //    txtAccpQty.Text = l10.Text;
        //    txtRejQty.Text = l11.Text;
        //    txtRmks.Text = l12.Text;
        //    txtRwk.Text = l13.Text;
        //    txtWipDnby.Text = l14.Text;
        //    txtDate.Text = l15.Text;
        //    txtBalanceQty.Text = l16.Text;
        //    //if (txtRmks.Text == " ")
        //    //{
        //    //    txtRmks.Text = "";
        //    //}
        //    }
        //    else
        //    {
        //        Messagebox("This Row values cannot be Updated & Permission is denied");
        //         clear();
        //         btnUpdate.Visible = false;
        //    }
        //}
        //else
        //{
        //    Messagebox("Please Choose a Power to Update a process");
        //    drpPwr.Focus();
        //}

    }
    //  protected void txtProgQty_TextChanged(object sender, EventArgs e)
    //  {
    //      txtAccpQty.Text = "";
    //      SoftLensDataContext db = new SoftLensDataContext();
    //      if (txtProgQty.Text != "")
    //      {
    //          var prog = (from a in db.LensWipings where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text) select a.ProgressQuantity).Sum();

    //          int sumofProgressQty = 0;
    //          if (prog != null)
    //          {
    //              sumofProgressQty = prog.Value;
    //          }

    //          if (btnUpdate.Visible == true)
    //          {
    //              Label pq = gvLenswiping.SelectedRow.FindControl("Label7") as Label;

    //              txtAccpQty.Focus();
    //              //  txtBalanceQuantity.Text = val.ToString();
    //              txtAccpQty.Text = "";

    //              Label l16 = (Label)gvLenswiping.SelectedRow.FindControl("Label16");
    //              if (gvLenswiping.Rows.Count - 1 == gvLenswiping.SelectedRow.RowIndex)
    //              {
    //                  txtBalanceQty.Text = ((Convert.ToInt32(pq.Text) + Convert.ToInt32(l16.Text)) - Convert.ToInt32(txtProgQty.Text)).ToString();
    //              }
    //              else
    //              {
    //                  sumofProgressQty = sumofProgressQty - Convert.ToInt32(pq.Text);
    //                  if (Convert.ToInt32(txtProgQty.Text) <= Convert.ToInt32(pq.Text))
    //                  {
    //                      txtBalanceQty.Text = (Convert.ToInt32(pq.Text) - Convert.ToInt32(txtProgQty.Text)).ToString();
    //                  }



    //                  else if ((Convert.ToInt32(txtReceivedQuantity.Text) - (sumofProgressQty + Convert.ToInt32(txtProgQty.Text))) < 0)
    //                  {
    //                      Messagebox("Progress Qty exceeds the Lmt");
    //                      txtProgQty.Text = "";
    //                      txtProgQty.Focus();
    //                  }
    //              }

    //          }
    //          else
    //          {

    //              var query3 = (from a in db.LensWipings where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text) select a.ProgressQuantity).Sum();

    //              sumofProgressQty = 0;
    //              if (query3 != null)
    //              {
    //                  sumofProgressQty = query3.Value;
    //              }

    //              if (Convert.ToInt32(txtProgQty.Text) > Convert.ToInt32(txtReceivedQuantity.Text))
    //              {
    //                  Messagebox("Value is Greater than Received Qty");
    //                  txtProgQty.Text = "";
    //                  txtProgQty.Focus();

    //              }
    //              else
    //              {
    //                  btnSave.Enabled = true;
    //                  var bal = (from a in db.LensWipings where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text) select a.ProgressQuantity).Sum();
    //                  //var bal1 = (from a in db.LensWipings where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text)  select a.BalanceQuantity).Sum();
    //                  if (Convert.ToInt32(txtReceivedQuantity.Text) != bal)
    //                      if (bal == null)
    //                      {
    //                          txtBalanceQty.Text = (Convert.ToInt32(txtReceivedQuantity.Text) - Convert.ToInt32(txtProgQty.Text)).ToString();
    //                      }
    //                      else
    //                      {
    //                          txtBalanceQty.Text = ((Convert.ToInt32(txtReceivedQuantity.Text) - bal) - Convert.ToInt32(txtProgQty.Text)).ToString();

    //                      }
    //                  else
    //                  {
    //                      Messagebox("Progress Qty is Greater than Balance Qty");
    //                      //txtProgQty.Text = "";
    //                      txtProgQty.Focus();
    //                  }

    //                  int val = (Convert.ToInt32(txtReceivedQuantity.Text) - (sumofProgressQty + Convert.ToInt32(txtProgQty.Text)));
    //                  if (val < 0)
    //                  {
    //                      txtProgQty.Text = "";
    //                      Messagebox("Value is Greater than Received Qty");
    //                      txtProgQty.Focus();

    //                  }
    //                  else
    //                  {
    //                      txtAccpQty.Focus();
    //                      txtAccpQty.Text = "";
    //                      // txtBalanceQuantity.Text = val.ToString();
    //                  }
    //              }
    //          }
    //      }
    //  }
    //  protected void txtRwk_TextChanged(object sender, EventArgs e)
    //  {
    //      if (Convert.ToInt32(txtRwk.Text) > Convert.ToInt32(txtRejQty.Text))
    //      {
    //          Messagebox("lmt exceeds rej Qty");
    //         // btnSave.Visible = false;
    //          txtRejQty.Text = "";            
    //      }
    //  }
    //  protected void txtReceivedQuantity_TextChanged(object sender, EventArgs e)
    //  {

    //  }

    //  protected void btnSave_Click(object sender, ImageClickEventArgs e)
    //  {
    //      if (txtProgQty.Text == "")
    //      {
    //          Messagebox("Please Enter Prog Qty");
    //          txtProgQty.Focus();
    //      }
    //      else if (txtAccpQty.Text == "")
    //      {
    //          Messagebox("Please Enter Accepted Qty ");
    //          txtAccpQty.Focus();
    //      }
    //      else if (txtWipDnby.Text == "")
    //      {
    //          Messagebox("Please Enter WipingDone by ");
    //          txtWipDnby.Focus();
    //      }
    //      else
    //      {
    //          SoftLensDataContext db = new SoftLensDataContext();
    //          if (txtRwk.Text == "")
    //          {
    //              txtRwk.Text = "0";
    //          }
    //          LensWiping lens = new LensWiping();
    //          {
    //              lens.TumblingLotNo = txtLotNo.Text;
    //              lens.Model = txtModelNo.Text;
    //              lens.TotalQuantity = Convert.ToInt32(txtTotalQuantity.Text);
    //              lens.CompQuantity = Convert.ToInt32(txtTCompQty.Text);
    //              lens.Power = Convert.ToDecimal(drpPwr.Text);
    //              lens.ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
    //              lens.BalanceQuantity = Convert.ToInt32(txtBalanceQty.Text);
    //              lens.ProgressQuantity = Convert.ToInt32(txtProgQty.Text);
    //              lens.RejectedQuantity = Convert.ToInt32(txtRejQty.Text);
    //              lens.AcceptedQuantity = Convert.ToInt32(txtAccpQty.Text);
    //              lens.Remarks = txtRmks.Text;
    //              lens.Rework = Convert.ToInt16(txtRwk.Text);
    //              lens.WipingDoneby = txtWipDnby.Text;
    //              if (txtPrevDate.Text != "")
    //              {
    //                  lens.PrevDate = Convert.ToDateTime(txtDate.Text, provider);
    //              }
    //              else
    //              {
    //                 // lens.PrevDate = Convert.ToDateTime(txtPrevDate.Text);
    //              }
    //              lens.Date = Convert.ToDateTime(txtDate.Text,provider);
    //          }
    //          db.LensWipings.InsertOnSubmit(lens);
    //          db.SubmitChanges();

    //          //decimal power;
    //          //int totQty;
    //          //int ProdLotNo;
    //          //int ModelNO;
    //          //var query = from rows in db.MillingCleanedLens where rows.TumblingNo == txtLotNo.Text select rows.LotNo;
    //          //if (query.Count() > 0)
    //          //{

    //          //    int i = 1, qtyy = 0;
    //          //    foreach (var value in query)
    //          //    {


    //          //        var query4 = from r in db.ReportTables where r.LotNo == value.Value.ToString()  && r.Type == 5 select r;

    //          //        db.ReportTables.DeleteAllOnSubmit(query4);
    //          //        db.SubmitChanges();
    //          //        i++;

    //          //    }



    //          //}
    //          var query = from r in db.ReportTables where r.LotNo== txtLotNo.Text && r.Type==5 && r.Power==Convert.ToDecimal(drpPwr.SelectedValue) select r;
    //          if (Convert.ToInt32(txtBalanceQty.Text) == 0)
    //          {
    //              db.ReportTables.DeleteAllOnSubmit(query);
    //          }
    //          else
    //          {
    //              query.Single().WiatingPouchPacking = Convert.ToInt32(txtBalanceQty.Text);
    //          }
    //          db.SubmitChanges();

    //          Messagebox("Saved Successfully");
    //          clear();
    //          var query7 = from row in db.LensWipings where row.TumblingLotNo == txtLotNo.Text select row;
    //          gvLenswiping.DataSource = query7;
    //          gvLenswiping.DataBind();
    //          txtLotNo.Text = "";
    //          btnClear.Visible = false;
    //          btnSave.Visible = false;
    //      }
    //  }
    //  protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    //  {
    //      if (txtProgQty.Text == "")
    //      {
    //          Messagebox("Please Enter Prog Qty");
    //          txtProgQty.Focus();
    //      }
    //      else if (txtAccpQty.Text == "")
    //      {
    //          Messagebox("Please Enter Accepted Qty ");
    //          txtAccpQty.Focus();
    //      }
    //      else if (txtWipDnby.Text == "")
    //      {
    //          Messagebox("Please Enter WipingDone by ");
    //          txtWipDnby.Focus();
    //      }
    //      else
    //      {
    //          SoftLensDataContext db = new SoftLensDataContext();
    //          LensWiping lens = new LensWiping();
    //          string idno = Session["ID"].ToString();
    //          var q = from a in db.LensWipings where a.TumblingLotNo == txtLotNo.Text && a.Power == Convert.ToDecimal(drpPwr.Text) && a.IdNo == Convert.ToInt32(idno) select a;
    //          if (q.Count() > 0)
    //          {
    //              q.Single().TumblingLotNo = txtLotNo.Text;
    //              q.Single().Model = txtModelNo.Text;
    //              q.Single().TotalQuantity = q.Single().TotalQuantity;
    //              q.Single().PrevDate = Convert.ToDateTime(txtPrevDate.Text, provider);
    //              q.Single().Power = q.Single().Power;
    //              q.Single().Rework = Convert.ToInt32(txtRwk.Text);
    //              q.Single().Remarks = txtRmks.Text;
    //              q.Single().ReceivedQuantity = Convert.ToInt32(txtReceivedQuantity.Text);
    //              q.Single().BalanceQuantity = Convert.ToInt32(txtBalanceQty.Text);
    //              q.Single().RejectedQuantity = Convert.ToInt32(txtRejQty.Text);
    //              q.Single().AcceptedQuantity = Convert.ToInt32(txtAccpQty.Text);
    //              q.Single().ProgressQuantity = Convert.ToInt32(txtProgQty.Text);
    //              q.Single().WipingDoneby = txtWipDnby.Text;
    //              q.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
    //          }
    //          db.SubmitChanges();

    //          var query1 = from r in db.ReportTables where r.LotNo ==Convert.ToString(txtLotNo.Text) && r.Type == 5 && r.Power == Convert.ToDecimal(drpPwr.SelectedValue) select r;
    //          if (Convert.ToInt32(txtBalanceQty.Text) == 0)
    //          {
    //              db.ReportTables.DeleteAllOnSubmit(query1);
    //          }
    //          else
    //          {
    //              query1.Single().WiatingPouchPacking = Convert.ToInt32(txtBalanceQty.Text);
    //          }
    //          db.SubmitChanges();

    //          Messagebox("Updated Successfully");
    //          gclear();
    //          var query = from row in db.LensWipings where row.TumblingLotNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPwr.Text) select row;
    //          gvLenswiping.DataSource = query;
    //          gvLenswiping.DataBind();
    //          txtLotNo.Text = "";

    //          btnUpdate.Visible = false;
    //      }
    //  }

    //  protected void btnClear_Click(object sender, ImageClickEventArgs e)
    //  {
    //      clear();
    //      txtLotNo.Text = "";
    //      btnClear.Visible = false;
    //      btnUpdate.Visible = false;
    //      btnSave.Visible = false;
    //  }
    //  protected void txtWipDnby_TextChanged(object sender, EventArgs e)
    //  {
    //      string up = txtWipDnby.Text;
    //      if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
    //      {
    //          txtWipDnby.Text = up.ToUpper();
    //      }
    //      else
    //      {
    //          Messagebox("Please Enter With INITIAL ex: M.BALAJI");
    //          txtWipDnby.Text = "";
    //          txtWipDnby.Focus();

    //      }
    //  }
    //  protected void txtRmks_TextChanged(object sender, EventArgs e)
    //  {
    //      string up = txtRmks.Text;
    //      txtRmks.Text = up.ToUpper();
    //      txtWipDnby.Focus();
    //  }

    #endregion


    protected void drpPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        var query2 = from row in Db.LensWipings where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;

        if (query2.Count() > 0)
        {
            GridBind();
        }
        else
        {
            var qury = from x in Db.PowerSegregationChilds where x.TumblingNo == txtLotNo.Text && x.Power == Convert.ToDecimal(drpPower.SelectedValue) select x;
            if (qury.Count() > 0)
            {
                txtTotalQuantity.Text = qury.Single().Qty.ToString();
                txtTumblingRef.Text = txtLotNo.Text;
            }
            else
            {
                Messagebox("Power Value doesn't Exists");
            }
        }
    }
}
