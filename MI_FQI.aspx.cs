using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Web.UI.HtmlControls;
public partial class MI_FQI : System.Web.UI.Page
{

    #region Declaration
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    SoftLensDataContext db = new SoftLensDataContext();
    PouchDataContext pd = new PouchDataContext();
    string idno;
    #endregion



    #region Method

    private void Clear()
    {
        txtLotNo.Text = "";
        txtModel.Text = "";
        txtTotalQty.Text = "";
        drpPower.SelectedValue = "--Select--";
        txtRecievedQty.Text = "";
        txtProgressQty.Text = "";
        txtBalanceQty.Text = "";
        txtAcceptedQty.Text = "";
        txtRetumbQty.Text = "";
        txtRejectedQty.Text = "";
        txtTumblingRef.Text = "";
        txtDate.Text = "";
        txtDots.Text = "0";
        txtIslands.Text = "0";
        txtLB.Text = "0";
        txtSCR.Text = "0";
        txtCutting.Text = "0";
        txtOther.Text = "0";
        txttotrejqty.Text = "0";
        txtRemarks.Text = "0";
        txtRejMTSNo.Text = "0";
        txtApprovedBy.Text = "";
        //GrdPouch.Visible = false;
    }

    private void GridBind()
    {
        var query = from row in db.MIinFQIs where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        if (query != null)
        {
            btnClear.Visible = true;
            gvMIinFQI.DataSource = query;
            gvMIinFQI.DataBind();
        }
        else
        {
            btnSave.Visible = true;
            btnClear.Visible = true;
        }

    }
    private void ReportUpdate()
    {
        var Q = from row in db.Report_Tables where row.TumblingNo == txtTumblingRef.Text && row.Status == 3 && row.GlassyNo == txtLotNo.Text select row;
        if (Q.Count() > 0)
        {
            Report_Table rt = new Report_Table();
            Q.Single().WaitingPouchPacking = 0;
            Q.Single().Status = 4;
            db.SubmitChanges();
        }
        else
        {
            var Q1 = from row in db.Report_Tables where row.RetumblingNo == txtTumblingRef.Text && row.Status == 3 && row.GlassyNo == txtLotNo.Text select row;
            if (Q1.Count() > 0)
            {
                Report_Table rt = new Report_Table();
                Q1.Single().WaitingPouchPacking = 0;
                Q1.Single().Status = 4;
                db.SubmitChanges();
            }
        }
    }

    protected void txttotrejqty_TextChanged(object sender, EventArgs e)
    {
        txttotrejqty.Text = Convert.ToString(Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));

    }

    protected void txtDots_TextChanged(object sender, EventArgs e)
    {
        textval();
        txttotrejqty.Text = Convert.ToString(Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));

        //int rej =Convert.ToInt32(txtRejectedQty.Text);
        //int val = (Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //if (rej == val)
        //{
        //    txtRejectedQty.Text = val.ToString();
        //}
        //else
        //{
        //    Messagebox("Values Mismatched");
        //    txtDots.Text = "0";
        //    txtDots.Focus();
        //}
        txtIslands.Focus();
    }

    protected void txtLB_TextChanged(object sender, EventArgs e)
    {
        textval();
        txttotrejqty.Text = Convert.ToString(Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //int rej = Convert.ToInt32(txtRejectedQty.Text);
        //int val = (Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //if (rej == val)
        //{
        //    txtRejectedQty.Text = val.ToString();
        //}
        //else
        //{
        //    Messagebox("Values Mismatched");
        //    txtLB.Text = "0";
        //    txtLB.Focus();
        //}
        txtSCR.Focus();
    }

    protected void txtSCR_TextChanged(object sender, EventArgs e)
    {
        textval();
        txttotrejqty.Text = Convert.ToString(Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //int rej = Convert.ToInt32(txtRejectedQty.Text);
        //int val = (Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //if (rej == val)
        //{
        //    txtRejectedQty.Text = val.ToString();
        //}
        //else
        //{
        //    Messagebox("Values Mismatched");
        //    txtSCR.Text = "0";
        //    txtSCR.Focus();
        //}
        txtCutting.Focus();
    }

    protected void txtIslands_TextChanged(object sender, EventArgs e)
    {
        textval();
        txttotrejqty.Text = Convert.ToString(Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //int rej = Convert.ToInt32(txtRejectedQty.Text);
        //int val = (Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //if (rej == val)
        //{
        //    txtRejectedQty.Text = val.ToString();
        //}
        //else
        //{
        //    Messagebox("Values Mismatched");
        //    txtIslands.Text = "0";
        //    txtIslands.Focus();
        //}
        txtLB.Focus();
    }

    protected void txtCutting_TextChanged(object sender, EventArgs e)
    {
        textval();
        txttotrejqty.Text = Convert.ToString(Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        txtOther.Focus();
    }


    protected void txtOther_TextChanged(object sender, EventArgs e)
    {
        textval();
        txttotrejqty.Text = Convert.ToString(Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //int rej = Convert.ToInt32(txtRejectedQty.Text);
        //int val = (Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text));
        //if (rej == val)
        //{
        //    txtRejectedQty.Text = val.ToString();
        //}
        //else
        //{
        //    Messagebox("Values Mismatched");
        //    txtOther.Text = "0";
        //    txtOther.Focus();
        //}
        txtRemarks.Focus();
    }



    private void textval()
    {
        if (txtDots.Text == "")
        {
            txtDots.Text = "0";
        }
        if (txtIslands.Text == "")
        {
            txtIslands.Text = "0";
        }
        if (txtLB.Text == "")
        {
            txtLB.Text = "0";
        }
        if (txtSCR.Text == "")
        {
            txtSCR.Text = "0";
        }
        if (txtCutting.Text == "")
        {
            txtCutting.Text = "0";
        }
        if (txttotrejqty.Text == "")
        {
            txttotrejqty.Text = "0";
        }
    }

    #endregion





    #region Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var username = (Session["Username"] as HtmlInputControl).Value;

            if (username == null)
            {
                Response.Redirect("404Page.aspx");
            }
            drpbind();
            txtSearch.Visible = false;

        }
    }

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    protected void txtGlassyNo_TextChanged(object sender, EventArgs e)
    {
        btnClear.Visible = true;
        //txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        string G = txtLotNo.Text;
        txtLotNo.Text = G.ToUpper();


        btnSave.Visible = true;
        //txtModel.Text = query.Single().Model.ToString();
        //txtTotalQty.Text = query.Single().AcceptedQty.ToString();
        //txtPower.Text = query.Single().Power.ToString();
        //txtTumblingRef.Text = query.Single().TumblingNo.ToString();
        drpPower.Focus();
        var seg = from a in db.PowerSegregationChilds
                  where a.TumblingNo == txtLotNo.Text
                  select a;
        drpPower.Items.Clear();
        drpPower.Items.Add("--Select--");
        drpPower.DataSource = seg;
        drpPower.DataTextField = "Power";
        drpPower.DataValueField = "Power";
        drpPower.DataBind();
    }

    protected void txtRecievedQty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtRecievedQty.Text) > Convert.ToInt32(txtTotalQty.Text))
        {
            Messagebox("Value is Greater than Total Qty");
            txtRecievedQty.Focus();
            txtRecievedQty.Text = "";

        }
        else
        {
            txtProgressQty.Focus();
        }


    }

    protected void txtProgressQty_TextChanged(object sender, EventArgs e)
    {
        txtBalanceQty.Text = (Convert.ToInt32(txtRecievedQty.Text) - Convert.ToInt32(txtProgressQty.Text)).ToString();
        txtAcceptedQty.Focus();
    }


    protected void txtAcceptedQty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtAcceptedQty.Text) > Convert.ToInt32(txtProgressQty.Text))
        {
            Messagebox("value greater than ProgressQty");
            txtAcceptedQty.Text = "";
            txtAcceptedQty.Focus();
        }
        else if (Convert.ToInt32(txtAcceptedQty.Text) == Convert.ToInt32(txtProgressQty.Text))
        {
            int temp = 0;
            txtRetumbQty.Text = Convert.ToInt32(temp).ToString();
            txtRetumbQty.Enabled = false;
            txtRejectedQty.Text = Convert.ToInt32(temp).ToString();
        }
        else
        {

            txtRetumbQty.Focus();
        }
    }




    protected void txtRetumbQty_TextChanged(object sender, EventArgs e)
    {

        //if (Convert.ToInt32(txtRetumbQty.Text) > Convert.ToInt32(txtAcceptedQty.Text))
        //{
        //    Messagebox("Value is Greater than Accepted Qty");
        //    txtRetumbQty.Text = "";
        //    txtRetumbQty.Focus();
        //}
        //else
        //{

        if (txtRetumbQty.Text != "0")
        {

            int val = (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumbQty.Text));
            if (val > Convert.ToInt32(txtProgressQty.Text))
            {
                Messagebox("Value is Greater than ProgressQty");
                txtRetumbQty.Text = "";
                txtRetumbQty.Focus();
            }
            else
            {
                txtRejectedQty.Text = (Convert.ToInt32(txtProgressQty.Text) - (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumbQty.Text))).ToString();
            }
        }
        else
        {
            txtRejectedQty.Text = (Convert.ToInt32(txtProgressQty.Text) - (Convert.ToInt32(txtAcceptedQty.Text) + Convert.ToInt32(txtRetumbQty.Text))).ToString();

        }

        //}

    }


    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        if (txtProgressQty.Text == "")
        {
            Messagebox("Please Enter Progress Qty");
            txtProgressQty.Focus();
        }
        else if (txtRejectedQty.Text != txttotrejqty.Text)
        {
            Messagebox("Total Rejected Qty does not match");

        }
        else if (txtAcceptedQty.Text == "")
        {
            Messagebox("Please Enter Accepted Qty");
            txtAcceptedQty.Focus();
        }
        //else if (Convert.ToInt32(txtRejectedQty.Text) != Convert.ToInt32(Session["RelQty"].ToString()))
        //{
        //    Messagebox("Please check Rejection Details Value");
        //}
        else if (txtApprovedBy.Text == "")
        {
            Messagebox("Please Enter ApprovedBy");
            txtApprovedBy.Focus();
        }
        else
        {
            int count = 0;
            foreach (GridViewRow r in GrdPouchChild.Rows)
            {
                count++;
            }

            int cnt = Convert.ToInt32(txtRejectedQty.Text) + Convert.ToInt32(txtRetumbQty.Text);
            if (count == cnt)
            {
                MIinFQI mitable = new MIinFQI();
                mitable.GlassyNo = txtLotNo.Text;
                mitable.Model = txtModel.Text;
                mitable.TotalQty = Convert.ToInt32(txtTotalQty.Text);
                mitable.Power = Convert.ToDecimal(drpPower.SelectedValue);
                mitable.RecievedQty = Convert.ToInt32(txtRecievedQty.Text);
                mitable.ProgressQty = Convert.ToInt32(txtProgressQty.Text);
                mitable.BalanceQty = Convert.ToInt32(txtBalanceQty.Text);
                mitable.AcceptedQty = Convert.ToInt32(txtAcceptedQty.Text);
                mitable.RetumblingQty = Convert.ToInt32(txtRetumbQty.Text);
                mitable.RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
                mitable.TumblingRefNo = txtTumblingRef.Text;
                if (txtTumblingRef.Text == null)
                {
                    txtTumblingRef.Text = "No Value";
                }
                mitable.Date = Convert.ToDateTime(txtDate.Text);
                mitable.Dots = Convert.ToInt32(txtDots.Text);
                mitable.Islands = Convert.ToInt32(txtIslands.Text);
                mitable.LB = Convert.ToInt32(txtLB.Text);
                mitable.SCR = Convert.ToInt32(txtSCR.Text);
                mitable.Cutting = Convert.ToInt32(txtCutting.Text);
                mitable.Other = Convert.ToInt32(txtOther.Text);
                mitable.TotalRejQty = Convert.ToInt32(txttotrejqty.Text);
                mitable.Remarks = txtRemarks.Text;
                mitable.RejMTSNo = txtRejMTSNo.Text;
                mitable.ApprovedBy = txtApprovedBy.Text;
                int checktotrej = Convert.ToInt32(txtDots.Text) + Convert.ToInt32(txtIslands.Text) + Convert.ToInt32(txtLB.Text) + Convert.ToInt32(txtSCR.Text) + Convert.ToInt32(txtCutting.Text) + Convert.ToInt32(txtOther.Text);
                if (checktotrej == Convert.ToInt32(txttotrejqty.Text))
                {

                    db.MIinFQIs.InsertOnSubmit(mitable);
                    db.SubmitChanges();
                    ReportUpdate();
                    GridBind();
                }
                else
                {
                    Messagebox("Total Rejection Qty and Cumulative of Rejection qty should be same..Please enter correct Reason Qty ");
                    return;
                      
                }
                Clear();
                txtLotNo.Text = "";

                foreach (GridViewRow r2 in GrdPouchChild.Rows)
                {
                    Label lbllabel = (Label)r2.FindControl("Label6");
                    Label lbllotno = (Label)r2.FindControl("Label4");
                    // var quey = from x in pd.POUCH_LABELs where x.RefLot == lbllotno.Text && x.Label == Convert.ToInt32(lbllabel.Text) select x;
                    string con1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
                    SqlConnection con = new SqlConnection(con1);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "StoredProcedure2";
                    cmd.Parameters.Add(new SqlParameter("@Action", "Search"));
                    cmd.Parameters.Add(new SqlParameter("@RefLot", lbllotno.Text));
                    cmd.Parameters.Add(new SqlParameter("@searchtxt", lbllabel.Text));
                    cmd.Parameters.Add(new SqlParameter("@Power", "0"));

                    cmd.Connection = con;
                    try
                    {
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                string rotlexty = dr["rotlex_type"].ToString();
                                string reflot = dr["RefLot"].ToString();
                                int labe = Convert.ToInt32(dr["Label"]);
                                string type = dr["Type"].ToString();
                                string brandname = dr["Brand_Name"].ToString();
                                string modelname = dr["Model_Name"].ToString();
                                string refname = dr["Reference_Name"].ToString();
                                string Pow = dr["Power"].ToString();
                                string r_pow = dr["R_Power"].ToString();
                                int qty = Convert.ToInt32(dr["Qty"]);
                                DateTime dt = System.DateTime.Now;
                                MI_FQIReject mr = new MI_FQIReject();
                                mr.Brand_Name = brandname;
                                mr.Created_By = "APS";
                                mr.Created_Date = dt;
                                mr.Label = labe;
                                mr.Model_name = modelname;
                                mr.Modified_By = "APS";
                                mr.Modified_Date = dt;
                                mr.Power = Pow;
                                mr.Qty = qty;
                                mr.R_Power = r_pow;
                                mr.Reference_Name = refname;
                                mr.RefLot = reflot;
                                mr.rotlex_type = rotlexty;
                                mr.Type = type;
                                db.MI_FQIRejects.InsertOnSubmit(mr);
                                db.SubmitChanges();
                            }
                            else
                            {
                                string con2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
                                SqlConnection con3 = new SqlConnection(con2);
                                SqlCommand cmd1 = new SqlCommand();
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandText = "StoredProcedure2";
                                cmd1.Parameters.Add(new SqlParameter("@Action", "SearchNonPre"));
                                cmd1.Parameters.Add(new SqlParameter("@RefLot", lbllotno.Text));
                                cmd1.Parameters.Add(new SqlParameter("@searchtxt", lbllabel.Text));
                                cmd1.Parameters.Add(new SqlParameter("@Power", "0"));

                                cmd1.Connection = con3;
                                try
                                {
                                    con3.Open();
                                    using (SqlDataReader dr1 = cmd1.ExecuteReader())
                                    {
                                        dr1.Read();
                                        if (dr1.HasRows)
                                        {
                                            string rotlexty = dr1["rotlex_type"].ToString();
                                            string reflot = dr1["RefLot"].ToString();
                                            int labe = Convert.ToInt32(dr1["Label"]);
                                            string type = dr1["Type"].ToString();
                                            string brandname = dr1["Brand_Name"].ToString();
                                            string modelname = dr1["Model_Name"].ToString();
                                            string refname = dr1["Reference_Name"].ToString();
                                            string Pow = dr1["Power"].ToString();
                                            string r_pow = dr1["R_Power"].ToString();
                                            int qty = Convert.ToInt32(dr1["Qty"]);
                                            DateTime dt = System.DateTime.Now;
                                            MI_FQIReject mr = new MI_FQIReject();
                                            mr.Brand_Name = brandname;
                                            mr.Created_By = "APS";
                                            mr.Created_Date = dt;
                                            mr.Label = labe;
                                            mr.Model_name = modelname;
                                            mr.Modified_By = "APS";
                                            mr.Modified_Date = dt;
                                            mr.Power = Pow;
                                            mr.Qty = qty;
                                            mr.R_Power = r_pow;
                                            mr.Reference_Name = refname;
                                            mr.RefLot = reflot;
                                            mr.rotlex_type = rotlexty;
                                            mr.Type = type;
                                            db.MI_FQIRejects.InsertOnSubmit(mr);
                                            db.SubmitChanges();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                                finally
                                {
                                    con3.Close();
                                    con3.Dispose();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                        con.Dispose();
                    }
                }
                foreach (GridViewRow r1 in GrdPouchChild.Rows)
                {

                    Label lblabel = (Label)r1.FindControl("Label5");
                    //Label lblpow = (Label)r.FindControl("Label3");
                    //Label lblsat = (Label)r.FindControl("Label6");
                    string con1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
                    SqlConnection pmcon = new SqlConnection(con1);
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "StoredProcedure1";
                    cmd.Parameters.Add(new SqlParameter("@Action", "DeleteMI"));
                    cmd.Parameters.Add(new SqlParameter("@Labl", lblabel.Text));
                    cmd.Parameters.Add(new SqlParameter("@Sat", "0"));
                    cmd.Parameters.Add(new SqlParameter("@Lot", "0"));
                    cmd.Parameters.Add(new SqlParameter("@Pow", "0"));
                    cmd.Connection = pmcon;
                    pmcon.Open();
                    cmd.ExecuteNonQuery();
                    pmcon.Close();
                    string con2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
                    SqlConnection pmcon1 = new SqlConnection(con2);
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "StoredProcedure1";
                    cmd1.Parameters.Add(new SqlParameter("@Action", "DeleteMINonPre"));
                    cmd1.Parameters.Add(new SqlParameter("@Labl", lblabel.Text));
                    cmd1.Parameters.Add(new SqlParameter("@Sat", "0"));
                    cmd1.Parameters.Add(new SqlParameter("@Lot", "0"));
                    cmd1.Parameters.Add(new SqlParameter("@Pow", "0"));
                    cmd1.Connection = pmcon1;
                    pmcon1.Open();
                    cmd1.ExecuteNonQuery();
                    pmcon1.Close();

                }


                Messagebox("Records Saved");
                txtSearch.Visible = false;
                btnClear.Visible = false;
                btnSave.Visible = false;
                GrdPouchChild.Visible = false;
                GrdPouch.Visible = false;
            }
            else
            {
                Messagebox("Rejected Qty Doesn't Match With Gridview Checked Rows");
            }
        }
    }

    protected void btnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clear();
        txtLotNo.Text = "";
        txtSearch.Visible = false;
        gvMIinFQI.DataSource = null;
        gvMIinFQI.DataBind();
        GrdPouch.DataSource = null;
        GrdPouch.DataBind();
        btnClear.Visible = false;
        btnSave.Visible = false;
        btnUpdate.Visible = false;
    }

    protected void txtRejectedQty_TextChanged(object sender, EventArgs e)
    {
        if (txtRejectedQty.Text == "0")
        {
            txtRejMTSNo.Text = "nil";
        }
    }
    protected void txtRemarks_TextChanged(object sender, EventArgs e)
    {
        string up = txtRemarks.Text;
        txtRemarks.Text = up.ToUpper();
        txtRejMTSNo.Focus();
    }
    protected void txtRejMTSNo_TextChanged(object sender, EventArgs e)
    {
        string up = txtRejMTSNo.Text;
        txtRejMTSNo.Text = up.ToUpper();
        txtApprovedBy.Focus();
    }
    //protected void txtApprovedBy_TextChanged(object sender, EventArgs e)
    //{
    //    string up = txtApprovedBy.Text;
    //    if (up[1] == '.' && up[2] != '.' && (up[2] >= 65 && up[2] <= 122))
    //    {
    //        txtApprovedBy.Text = up.ToUpper();
    //    }
    //    else
    //    {
    //        Messagebox("Please Enter With INITIAL ex: M.BALAJI");
    //        txtApprovedBy.Text = "";
    //        txtApprovedBy.Focus();

    //    }
    //}



    #endregion




    #region ref


    //protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    //{
    //    var query = from row in db.MIinFQIs where row.Id == Convert.ToInt32(Session["Id"].ToString()) select row;
    //    query.Single().AcceptedQty = Convert.ToInt32(txtAccepted.Text);
    //    query.Single().ApprovedBy = txtApprovedBy.Text;
    //    query.Single().CompletedQty = Convert.ToInt32(txtCompletedQty.Text);
    //    query.Single().Date = Convert.ToDateTime(txtDate.Text, provider);
    //    query.Single().Dots = Convert.ToInt32(txtDots.Text);
    //    query.Single().HeatProb = Convert.ToInt32(txtHeatProb.Text);
    //    query.Single().Other = Convert.ToInt32(txtOther.Text);
    //    query.Single().Islands = Convert.ToInt32(txtIslands.Text);
    //    query.Single().LB = Convert.ToInt32(txtLB.Text);
    //    query.Single().Model = (txtModel.Text);
    //    query.Single().PIMP = Convert.ToInt32(txtPimp.Text);
    //    query.Single().Power = Convert.ToDecimal(ddlPower.Text);
    //    query.Single().BalanceQty = Convert.ToInt32(txtBalanceQty.Text);
    //    query.Single().ProgressQty = Convert.ToInt32(txtProgressQty.Text);
    //    query.Single().RecievedQty = Convert.ToInt32(txtRecievedQty.Text);
    //    query.Single().RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
    //    query.Single().RejMTSNo = txtRejMTSNo.Text;
    //    query.Single().Remarks = txtRemarks.Text;
    //    query.Single().SCR = Convert.ToInt32(txtSCR.Text);
    //    query.Single().TotalQty = Convert.ToInt32(txtTotalQty.Text);

    //    db.SubmitChanges();
    //    Clear();
    //    GridBind();

    //    txtTumblingNo.Text = "";
    //    Messagebox("Recdords Updated");
    //    btnClear.Visible = false;
    //    btnSave.Visible = false;
    //    btnUpdate.Visible = false;

    //}  



    #endregion


    protected void drpApprov_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnSave.Focus();
    }
    private void drpbind()
    {
       
    }

    protected void gvMIinFQI_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (gvMIinFQI.Rows.Count - 1 == gvMIinFQI.SelectedRow.RowIndex && Session["up"].Equals(1))
        {
            btnSave.Visible = false;
            btnClear.Visible = true;
            SoftLensDataContext db = new SoftLensDataContext();
            Label id = (Label)gvMIinFQI.SelectedRow.FindControl("Label1");
            Session["ID"] = id.Text;
            var query = from r in db.MIinFQIs where r.GlassyNo == id.Text select r;
            txtModel.Text = gvMIinFQI.SelectedRow.Cells[2].Text;
            drpPower.SelectedValue = query.Single().Power.ToString();
            txtTotalQty.Text = gvMIinFQI.SelectedRow.Cells[3].Text;
            txtRecievedQty.Text = gvMIinFQI.SelectedRow.Cells[4].Text;
            txtProgressQty.Text = gvMIinFQI.SelectedRow.Cells[5].Text;
            txtBalanceQty.Text = gvMIinFQI.SelectedRow.Cells[6].Text;
            txtAcceptedQty.Text = gvMIinFQI.SelectedRow.Cells[7].Text;
            txtRetumbQty.Text = gvMIinFQI.SelectedRow.Cells[8].Text;
            txtRejectedQty.Text = gvMIinFQI.SelectedRow.Cells[9].Text;
            txtTumblingRef.Text = gvMIinFQI.SelectedRow.Cells[10].Text;
            txtApprovedBy.Text = gvMIinFQI.SelectedRow.Cells[13].Text;
            txtRemarks.Text = gvMIinFQI.SelectedRow.Cells[12].Text;
            if (txtRemarks.Text == "&nbsp;")
            {
                txtRemarks.Text = "";
            }
            txtDate.Text = gvMIinFQI.SelectedRow.Cells[11].Text;
            txtDots.Text = query.Single().Dots.ToString();
            txtIslands.Text = query.Single().Islands.ToString();
            txtLB.Text = query.Single().LB.ToString();
            txtSCR.Text = query.Single().SCR.ToString();
            txtCutting.Text = query.Single().Cutting.ToString();
            txtOther.Text = query.Single().Other.ToString();
            txtRejMTSNo.Text = query.Single().RejMTSNo.ToString();
            btnUpdate.Visible = true;
            btnClear.Visible = true;
        }
        else
        {
            Messagebox("This Row cannot be Updated & Permission is denied");
            Clear();
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }
    }

    protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
    {
        SoftLensDataContext db = new SoftLensDataContext();

        //idno = Session["ID"].ToString();
        var qury = from r1 in db.BlisterSealingTables where r1.GlassyNo == txtLotNo.Text && r1.Power == Convert.ToDecimal(drpPower.SelectedValue) select r1;
        if (qury.Count() > 0)
        {
            qury.Single().TotalQty = Convert.ToInt32(txtAcceptedQty.Text);
        }
        var qury1 = from r2 in db.FirstRetumblingReports where r2.GlassyNo == txtLotNo.Text && r2.Power == Convert.ToDecimal(drpPower.SelectedValue) select r2;
        if (qury1.Count() > 0)
        {
            qury1.Single().TotalQty = Convert.ToInt32(txtAcceptedQty.Text);
        }
        var qury2 = from r3 in db.LabelDetailsPackings where r3.GlassyNo == txtLotNo.Text && r3.Power == Convert.ToDecimal(drpPower.SelectedValue) select r3;
        if (qury2.Count() > 0)
        {
            qury2.Single().TotalQty = Convert.ToInt32(txtAcceptedQty.Text);
        }

        var MI = from b in db.MIinFQIs where b.GlassyNo == txtLotNo.Text && b.Power == Convert.ToDecimal(drpPower.SelectedValue) select b;
        if (MI.Count() > 0)
        {
            MI.Single().GlassyNo = txtLotNo.Text;

            MI.Single().Model = txtModel.Text;
            MI.Single().TotalQty = Convert.ToInt32(txtTotalQty.Text);
            MI.Single().Power = Convert.ToDecimal(drpPower.SelectedValue);
            MI.Single().RecievedQty = Convert.ToInt32(txtRecievedQty.Text);
            MI.Single().ProgressQty = Convert.ToInt32(txtProgressQty.Text);
            MI.Single().BalanceQty = Convert.ToInt32(txtBalanceQty.Text);
            MI.Single().AcceptedQty = Convert.ToInt32(txtAcceptedQty.Text);
            MI.Single().RetumblingQty = Convert.ToInt32(txtRetumbQty.Text);
            MI.Single().RejectedQty = Convert.ToInt32(txtRejectedQty.Text);
            MI.Single().TumblingRefNo = txtTumblingRef.Text;
            if (txtTumblingRef.Text == null)
            {
                txtTumblingRef.Text = "No Value";
            }
            MI.Single().Date = Convert.ToDateTime(txtDate.Text);
            MI.Single().Dots = Convert.ToInt32(txtDots.Text);
            MI.Single().Islands = Convert.ToInt32(txtIslands.Text);
            MI.Single().LB = Convert.ToInt32(txtLB.Text);
            MI.Single().SCR = Convert.ToInt32(txtSCR.Text);
            MI.Single().Cutting = Convert.ToInt32(txtCutting.Text);
            MI.Single().Other = Convert.ToInt32(txtOther.Text);
            MI.Single().TotalRejQty = Convert.ToInt32(txttotrejqty.Text);
            MI.Single().Remarks = txtRemarks.Text;
            MI.Single().RejMTSNo = txtRejMTSNo.Text;
            MI.Single().ApprovedBy = txtApprovedBy.Text;

            foreach (GridViewRow r2 in GrdPouchChild.Rows)
            {
                Label lbllabel = (Label)r2.FindControl("Label6");
                Label lbllotno = (Label)r2.FindControl("Label4");
                string con1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(con1);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "StoredProcedure2";
                cmd.Parameters.Add(new SqlParameter("@Action", "Search"));
                cmd.Parameters.Add(new SqlParameter("@RefLot", lbllotno.Text));
                cmd.Parameters.Add(new SqlParameter("@searchtxt", lbllabel.Text));
                cmd.Parameters.Add(new SqlParameter("@Power", "0"));

                cmd.Connection = con;
                try
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            string rotlexty = dr["rotlex_type"].ToString();
                            string reflot = dr["RefLot"].ToString();
                            int labe = Convert.ToInt32(dr["Label"]);
                            string type = dr["Type"].ToString();
                            string brandname = dr["Brand_Name"].ToString();
                            string modelname = dr["Model_Name"].ToString();
                            string refname = dr["Reference_Name"].ToString();
                            string Pow = dr["Power"].ToString();
                            string r_pow = dr["R_Power"].ToString();
                            int qty = Convert.ToInt32(dr["Qty"]);
                            DateTime dt = System.DateTime.Now;
                            MI_FQIReject mr = new MI_FQIReject();
                            mr.Brand_Name = brandname;
                            mr.Created_By = "APS";
                            mr.Created_Date = dt;
                            mr.Label = labe;
                            mr.Model_name = modelname;
                            mr.Modified_By = "APS";
                            mr.Modified_Date = dt;
                            mr.Power = Pow;
                            mr.Qty = qty;
                            mr.R_Power = r_pow;
                            mr.Reference_Name = refname;
                            mr.RefLot = reflot;
                            mr.rotlex_type = rotlexty;
                            mr.Type = type;
                            db.MI_FQIRejects.InsertOnSubmit(mr);
                            db.SubmitChanges();
                        }
                        else
                        {
                            string con2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
                            SqlConnection con3 = new SqlConnection(con2);
                            SqlCommand cmd1 = new SqlCommand();
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.CommandText = "StoredProcedure2";
                            cmd1.Parameters.Add(new SqlParameter("@Action", "SearchNonPre"));
                            cmd1.Parameters.Add(new SqlParameter("@RefLot", lbllotno.Text));
                            cmd1.Parameters.Add(new SqlParameter("@searchtxt", lbllabel.Text));
                            cmd1.Parameters.Add(new SqlParameter("@Power", "0"));

                            cmd1.Connection = con3;
                            try
                            {
                                con3.Open();
                                using (SqlDataReader dr1 = cmd1.ExecuteReader())
                                {
                                    dr1.Read();
                                    if (dr1.HasRows)
                                    {
                                        string rotlexty = dr1["rotlex_type"].ToString();
                                        string reflot = dr1["RefLot"].ToString();
                                        int labe = Convert.ToInt32(dr1["Label"]);
                                        string type = dr1["Type"].ToString();
                                        string brandname = dr1["Brand_Name"].ToString();
                                        string modelname = dr1["Model_Name"].ToString();
                                        string refname = dr1["Reference_Name"].ToString();
                                        string Pow = dr1["Power"].ToString();
                                        string r_pow = dr1["R_Power"].ToString();
                                        int qty = Convert.ToInt32(dr1["Qty"]);
                                        DateTime dt = System.DateTime.Now;
                                        MI_FQIReject mr = new MI_FQIReject();
                                        mr.Brand_Name = brandname;
                                        mr.Created_By = "APS";
                                        mr.Created_Date = dt;
                                        mr.Label = labe;
                                        mr.Model_name = modelname;
                                        mr.Modified_By = "APS";
                                        mr.Modified_Date = dt;
                                        mr.Power = Pow;
                                        mr.Qty = qty;
                                        mr.R_Power = r_pow;
                                        mr.Reference_Name = refname;
                                        mr.RefLot = reflot;
                                        mr.rotlex_type = rotlexty;
                                        mr.Type = type;
                                        db.MI_FQIRejects.InsertOnSubmit(mr);
                                        db.SubmitChanges();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {
                                con3.Close();
                                con3.Dispose();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
            foreach (GridViewRow r1 in GrdPouchChild.Rows)
            {

                Label lblabel = (Label)r1.FindControl("Label5");
                //Label lblpow = (Label)r.FindControl("Label3");
                //Label lblsat = (Label)r.FindControl("Label6");
                string con1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
                SqlConnection pmcon = new SqlConnection(con1);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "StoredProcedure1";
                cmd.Parameters.Add(new SqlParameter("@Action", "DeleteMI"));
                cmd.Parameters.Add(new SqlParameter("@Labl", lblabel.Text));
                cmd.Parameters.Add(new SqlParameter("@Sat", "0"));
                cmd.Parameters.Add(new SqlParameter("@Lot", "0"));
                cmd.Parameters.Add(new SqlParameter("@Pow", "0"));
                cmd.Connection = pmcon;
                pmcon.Open();
                cmd.ExecuteNonQuery();
                pmcon.Close();
                string con2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
                SqlConnection pmcon1 = new SqlConnection(con2);
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "StoredProcedure1";
                cmd1.Parameters.Add(new SqlParameter("@Action", "DeleteMINonPre"));
                cmd1.Parameters.Add(new SqlParameter("@Labl", lblabel.Text));
                cmd1.Parameters.Add(new SqlParameter("@Sat", "0"));
                cmd1.Parameters.Add(new SqlParameter("@Lot", "0"));
                cmd1.Parameters.Add(new SqlParameter("@Pow", "0"));
                cmd1.Connection = pmcon1;
                pmcon1.Open();
                cmd1.ExecuteNonQuery();
                pmcon1.Close();

            }
            db.SubmitChanges();
            ReportUpdate();
            GridBind();
            Clear();
            txtLotNo.Text = "";
            Messagebox("Updated Successfully");
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
        }
    }
    protected void PouchGridBind()
    {
        var qury = from r in db.PowerSegregationChilds where r.TumblingNo == txtLotNo.Text && r.Power == Convert.ToDecimal(drpPower.SelectedValue) select r;
        string tumbno = qury.Single().TumblingNo;
        string powr = qury.Single().Power.ToString();
        //var qury1 = from r1 in pd.POUCH_LABELs where r1.RefLot == tumbno select r1;
        //GrdPouch.DataSource = qury1;
        //GrdPouch.DataBind();
        string con1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(con1);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "StoredProcedure2";
        cmd.Parameters.Add(new SqlParameter("@Action", "GrdBind"));
        cmd.Parameters.Add(new SqlParameter("@RefLot", tumbno));
        cmd.Parameters.Add(new SqlParameter("@searchtxt", "0"));
        cmd.Parameters.Add(new SqlParameter("@Power", powr));

        cmd.Connection = con;
        try
        {
            con.Open();
            GrdPouch.DataSource = cmd.ExecuteReader();
            if (GrdPouch.DataSource != null)
            {
                GrdPouch.DataBind();
                GrdPouch.Visible = true;
                foreach (GridViewRow r in GrdPouch.Rows)
                {
                    Label brnd = (Label)r.FindControl("Label2");
                    Label mode = (Label)r.FindControl("Label1");
                    Label pow = (Label)r.FindControl("Label3");
                    Label reflot = (Label)r.FindControl("Label4");
                    Label lotsrno = (Label)r.FindControl("Label5");
                    Label lbl = (Label)r.FindControl("Label6");
                    if (ViewState["dt1"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["dt1"];
                        int count = dt.Rows.Count;
                        DetailsAdd(brnd.Text, mode.Text, Convert.ToDecimal(pow.Text), reflot.Text, lotsrno.Text, Convert.ToInt32(lbl.Text), count);
                    }
                    else
                    {
                        DetailsAdd(brnd.Text, mode.Text, Convert.ToDecimal(pow.Text), reflot.Text, lotsrno.Text, Convert.ToInt32(lbl.Text), 1);
                    }
                }
            }
            else
            {
                string con2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
                SqlConnection con3 = new SqlConnection(con2);
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "StoredProcedure2";
                cmd1.Parameters.Add(new SqlParameter("@Action", "GrdBindNonPre"));
                cmd1.Parameters.Add(new SqlParameter("@RefLot", tumbno));
                cmd1.Parameters.Add(new SqlParameter("@searchtxt", "0"));
                cmd1.Parameters.Add(new SqlParameter("Power", powr));

                cmd1.Connection = con3;
                try
                {
                    con3.Open();
                    GrdPouch.DataSource = cmd1.ExecuteReader();
                    GrdPouch.DataBind();
                    GrdPouch.Visible = true;
                    foreach (GridViewRow r in GrdPouch.Rows)
                    {
                        Label brnd = (Label)r.FindControl("Label2");
                        Label mode = (Label)r.FindControl("Label1");
                        Label pow = (Label)r.FindControl("Label3");
                        Label reflot = (Label)r.FindControl("Label4");
                        Label lotsrno = (Label)r.FindControl("Label5");
                        Label lbl = (Label)r.FindControl("Label6");
                        if (ViewState["dt1"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["dt1"];
                            int count = dt.Rows.Count;
                            DetailsAdd(brnd.Text, mode.Text, Convert.ToDecimal(pow.Text), reflot.Text, lotsrno.Text, Convert.ToInt32(lbl.Text), count);
                        }
                        else
                        {
                            DetailsAdd(brnd.Text, mode.Text, Convert.ToDecimal(pow.Text), reflot.Text, lotsrno.Text, Convert.ToInt32(lbl.Text), 1);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con3.Close();
                    con3.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    //protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    //{
    //    string con1 = ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString;
    //    SqlConnection con = new SqlConnection(con1);
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandText = "StoredProcedure2";
    //    cmd.Parameters.Add(new SqlParameter("@Action", "Search"));
    //    cmd.Parameters.Add(new SqlParameter("@RefLot", "0"));
    //    cmd.Parameters.Add(new SqlParameter("@searchtxt", txtSearch.Text));

    //    cmd.Connection = con;
    //    try
    //    {
    //        con.Open();
    //        GrdPouch.DataSource = cmd.ExecuteReader();
    //        GrdPouch.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();
    //    }
    //}
    protected void GrdPouch_CheckChange(object sender, EventArgs e)
    {
        GrdPouchChild.Visible = true;
        CheckBox chkall = (sender as CheckBox);

        if (chkall.Checked == true)
        {
            GridViewRow row = (GridViewRow)chkall.NamingContainer;
            Label brnd = row.FindControl("Label1") as Label;
            Label model = row.FindControl("Label2") as Label;
            Label pow = row.FindControl("Label3") as Label;
            Label tumbno = row.FindControl("Label4") as Label;
            Label lot = row.FindControl("Label5") as Label;
            Label lbl = row.FindControl("Label6") as Label;
            CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
            chk.Checked = true;
            if (ViewState["dt"] != null)
            {
                DataTable dt = (DataTable)ViewState["dt"];
                int count = dt.Rows.Count;
                AddMaterial(brnd.Text, model.Text, Convert.ToDecimal(pow.Text), tumbno.Text, lot.Text, Convert.ToInt32(lbl.Text), count);
            }
            else
            {
                AddMaterial(brnd.Text, model.Text, Convert.ToDecimal(pow.Text), tumbno.Text, lot.Text, Convert.ToInt32(lbl.Text), 1);
            }

        }
        else if (chkall.Checked == false)
        {
            GridViewRow rows = (GridViewRow)chkall.NamingContainer;
            Label lotsrno = rows.FindControl("Label5") as Label;
            foreach (GridViewRow row in GrdPouch.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("Checkbox1");
                Label lott = row.FindControl("Label5") as Label;
                DataTable dt = (DataTable)ViewState["dt"];
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dt.Rows[i];
                    if ((dr["Lot_SrNo"]).ToString() == lotsrno.Text)
                    {
                        chk.Checked = false;
                        //'Delete Selected Row from TempTable
                        dr.Delete();
                    }
                }
                GrdPouchChild.DataSource = ViewState["dt"] as DataTable;
                GrdPouchChild.DataBind();
            }

        }
    }
    private void AddMaterial(string brand, string mod, decimal pow, string tumno, string LotSrno, int label, int count)
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Brand_Name", typeof(string));
        dt.Columns.Add("Model_Name", typeof(string));
        dt.Columns.Add("Power", typeof(decimal));
        dt.Columns.Add("RefLot", typeof(string));
        dt.Columns.Add("Lot_SrNo", typeof(string));
        dt.Columns.Add("Label", typeof(int));

        if (ViewState["dt"] != null)
        {
            for (int i = 0; i < count + 1; i++)
            {
                dt = (DataTable)ViewState["dt"];
                if (dt.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr[0] = dt.Rows[0][0].ToString();
                }
            }
            dr = dt.NewRow();
            dr[0] = count + 1;
            dr[1] = brand;
            dr[2] = mod;
            dr[3] = pow;
            dr[4] = tumno;
            dr[5] = LotSrno;
            dr[6] = label;

            dt.Rows.Add(dr);
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = 1;
            dr[1] = brand;
            dr[2] = mod;
            dr[3] = pow;
            dr[4] = tumno;
            dr[5] = LotSrno;
            dr[6] = label;

            dt.Rows.Add(dr);
        }
        if (ViewState["dt"] != null)
        {
            GrdPouchChild.DataSource = ViewState["dt"] as DataTable;
            GrdPouchChild.DataBind();
        }
        else
        {
            GrdPouchChild.DataSource = dt;
            GrdPouchChild.DataBind();
        }
        ViewState["dt"] = dt;
    }
    protected void GrdPouchChild_Delete(object sender, GridViewDeleteEventArgs e)
    {
        //' Get Selected Rowid from TempTable
        int id = Convert.ToInt32(GrdPouchChild.DataKeys[e.RowIndex].Value);
        DataTable dt = (DataTable)ViewState["dt"];
        for (int i = dt.Rows.Count - 1; i >= 0; i--)
        {
            DataRow dr = dt.Rows[i];
            if (Convert.ToInt32(dr["Id"]) == id)
                //'Delete Selected Row from TempTable
                dr.Delete();
        }
        //'Bind Temptable
        GrdPouchChild.DataSource = ViewState["dt"] as DataTable;
        GrdPouchChild.DataBind();

    }
    protected void DetailsAdd(string brand, string mod, decimal pow, string tumno, string LotSrno, int label, int count)
    {
        DataTable dt1 = new DataTable();
        DataRow dr1;
        dt1.Columns.Add("Id", typeof(int));
        dt1.Columns.Add("Brand_Name", typeof(string));
        dt1.Columns.Add("Model_Name", typeof(string));
        dt1.Columns.Add("Power", typeof(decimal));
        dt1.Columns.Add("RefLot", typeof(string));
        dt1.Columns.Add("Lot_SrNo", typeof(string));
        dt1.Columns.Add("Label", typeof(int));

        if (ViewState["dt1"] != null)
        {
            for (int i = 0; i < count + 1; i++)
            {
                dt1 = (DataTable)ViewState["dt1"];
                if (dt1.Rows.Count > 0)
                {
                    dr1 = dt1.NewRow();
                    dr1[0] = dt1.Rows[0][0].ToString();
                }
            }
            dr1 = dt1.NewRow();
            dr1[0] = count + 1;
            dr1[1] = brand;
            dr1[2] = mod;
            dr1[3] = pow;
            dr1[4] = tumno;
            dr1[5] = LotSrno;
            dr1[6] = label;

            dt1.Rows.Add(dr1);
        }
        else
        {
            dr1 = dt1.NewRow();
            dr1[0] = 1;
            dr1[1] = brand;
            dr1[2] = mod;
            dr1[3] = pow;
            dr1[4] = tumno;
            dr1[5] = LotSrno;
            dr1[6] = label;

            dt1.Rows.Add(dr1);
        }
        ViewState["dt1"] = dt1;
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        if (txtSearch.Text != "")
        {
            DataTable dat = new DataTable();
            dat = ViewState["dt1"] as DataTable;
            //dat.Select().Where(P => (P["Lot_SrNo"]) == txtSearch.Text);
            DataTable tmpp = new DataTable();
            tmpp = null;
            //DataRow[] dr;
            var x = from t in dat.AsEnumerable() where t["Label"].ToString() == txtSearch.Text select t;
            if (x.Any())
            {
                //foreach (var row in x)
                //{
                //    tmpp.ImportRow(row);
                //}
                tmpp = x.CopyToDataTable();
                ViewState["tmpp"] = tmpp;
            }
            else
            {
                Messagebox("No Data Found");
            }

            //'Bind Temptable
            GrdPouch.DataSource = ViewState["tmpp"] as DataTable;
            GrdPouch.DataBind();

        }
        else
        {
            PouchGridBind();
        }
    }
    protected void txtApprovedBy_TextChanged(object sender, EventArgs e)
    {
        string apprv = txtApprovedBy.Text;
        txtApprovedBy.Text = apprv.ToUpper();
        btnSave.Focus();
    }
    protected void drpPower_SelectedIndexChanged(object sender, EventArgs e)
    {
        var query1 = from row in db.MIinFQIs where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        //var query = from row in db.Pick_Packings where row.GlassyNo == txtLotNo.Text && row.Power == Convert.ToDecimal(drpPower.SelectedValue) select row;
        if (query1.Count() > 0)
        {
            gvMIinFQI.DataSource = query1;
            gvMIinFQI.DataBind();
            //gridpuch.Visible = false;
            //gridpuchchild.Visible = false; 
            PouchGridBind();
            txtModel.Text = query1.Single().Model;
            txtTotalQty.Text = query1.Single().TotalQty.ToString();
            txtRecievedQty.Text = query1.Single().RecievedQty.ToString();
            txtProgressQty.Text = query1.Single().ProgressQty.ToString();
            txtAcceptedQty.Text = query1.Single().AcceptedQty.ToString();
            txtRejectedQty.Text = query1.Single().RejectedQty.ToString();
            //txtRetumbQty.Text = query1.Single().RetumblingQty.ToString();
            txtTumblingRef.Text = query1.Single().TumblingRefNo.ToString();
            txtDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            txtDots.Text = query1.Single().Dots.ToString();
            txtIslands.Text = query1.Single().Islands.ToString();
            txtLB.Text = query1.Single().LB.ToString();
            txtSCR.Text = query1.Single().SCR.ToString();
            txtCutting.Text = query1.Single().Cutting.ToString();
            txtOther.Text = query1.Single().Other.ToString();
            txttotrejqty.Text = query1.Single().TotalRejQty.ToString();
            txtRemarks.Text = query1.Single().Remarks.ToString();
            txtRejMTSNo.Text = query1.Single().RejMTSNo.ToString();
            txtApprovedBy.Text = query1.Single().ApprovedBy.ToString();
            txtSearch.Visible = true;
            btnClear.Visible = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;

        }
        else
        {
            //var qury = from x in db.Pick_Packings where x.TumblingNo == txtLotNo.Text && x.Power == Convert.ToDecimal(drpPower.SelectedValue) select x;
            var qury = from x in db.NewBtchAllots where x.LotNo == txtLotNo.Text select x;
            var query = from r in db.PowerSegregationChilds where r.TumblingNo == txtLotNo.Text && r.Power == Convert.ToDecimal(drpPower.SelectedValue) select r;
            if (query.Count() > 0)
            {
                txtModel.Text = qury.Single().Model;
                txtTumblingRef.Text = qury.Single().LotNo;
                txtTotalQty.Text = query.Single().Qty.ToString();
                gridpuchchild.Visible = true;
                gridpuch.Visible = true;
                gvMIinFQI.DataSource = null;
                gvMIinFQI.DataBind();
                txtSearch.Visible = true;
                btnSave.Visible = true;
                PouchGridBind();
            }
            else
            {
                Messagebox("Choose a Valid Power");
            }
        }
    }
}
