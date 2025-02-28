using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;


public partial class RotlexUpload : System.Web.UI.Page
{
    SoftLensDataContext db = new SoftLensDataContext();
    PouchDataContext db2 = new PouchDataContext();
    TextBox tumbno, pow, qty, txtglass;
    //MoriaDataContext db3 = new MoriaDataContext();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
    SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString);
    int endsrno = 0;
    string losrno, btch, stryear, strmonth, strmanfmonth, strmanfyear, expyear, expmonth, prefix, lotno;
    decimal dia;
    int pass, fail, samp;
    string gscode1, Brand, mtfno, qual, MTFQual;
    string line = string.Empty;
    string[] lines = new string[6];
    double MTF;
    int totexp1;
    decimal optic;
    decimal length;
    string lotunit;
    decimal Aconst;
    string TypeGS;
    string refname;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string strconn = ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(strconn);
            string que1 = "Select distinct Brand_Name from LENS_MASTER";
            SqlCommand cmd = new SqlCommand(que1, connection);
            SqlDataReader bn;
            connection.Open();
            bn = cmd.ExecuteReader();
            DropDownList1.Items.Clear();
            DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList1.DataTextField = "Brand_Name";
            DropDownList1.DataValueField = "Brand_Name";
            DropDownList1.DataSource = null;
            DropDownList1.DataSource = bn;
            DataBind();
            connection.Close();
            string strconn1 = ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString;
            SqlConnection connection1 = new SqlConnection(strconn1);
            string que = "Select distinct RefLot from POUCH_LABEL";
            SqlCommand cmd1 = new SqlCommand(que, connection1);
            SqlDataReader bn1;
            connection1.Open();
            bn1 = cmd1.ExecuteReader();
            DropDownList4.Items.Clear();
            DropDownList4.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList4.DataTextField = "RefLot";
            DropDownList4.DataValueField = "RefLot";
            DropDownList4.DataSource = null;
            DropDownList4.DataSource = bn1;
            DropDownList4.DataBind();
            connection1.Close();
            string strconn2 = ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString;
            SqlConnection connection2 = new SqlConnection(strconn2);
            string que2 = "Select distinct RefLot from POUCH_LABEL";
            SqlCommand cmd2 = new SqlCommand(que2, connection2);
            SqlDataReader bn2;
            connection2.Open();
            bn2 = cmd2.ExecuteReader();
            DropDownList2.Items.Clear();
            DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList2.DataTextField = "RefLot";
            DropDownList2.DataValueField = "RefLot";
            DropDownList2.DataSource = null;
            DropDownList2.DataSource = bn2;
            DropDownList2.DataBind();
            connection2.Close();
            string strconn3 = ConfigurationManager.ConnectionStrings["APS_MORIAConnectionString"].ConnectionString;
            SqlConnection connection3 = new SqlConnection(strconn3);
            string que3 = "Select distinct RefLot from POUCH_LABEL";
            SqlCommand cmd3 = new SqlCommand(que3, connection3);
            SqlDataReader bn3;
            connection3.Open();
            bn3 = cmd3.ExecuteReader();
            DropDownList5.Items.Clear();
            DropDownList5.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList5.DataTextField = "RefLot";
            DropDownList5.DataValueField = "RefLot";
            DropDownList5.DataSource = null;
            DropDownList5.DataSource = bn3;
            DropDownList5.DataBind();
            connection3.Close();
            string strconn31 = ConfigurationManager.ConnectionStrings["APS_MORIAConnectionString"].ConnectionString;
            SqlConnection connection31 = new SqlConnection(strconn31);
            string que31 = "Select distinct RefLot from POUCH_LABEL";
            SqlCommand cmd31 = new SqlCommand(que31, connection31);
            SqlDataReader bn31;
            connection31.Open();
            bn31 = cmd31.ExecuteReader();
            DropDownList7.Items.Clear();
            DropDownList7.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList7.DataTextField = "RefLot";
            DropDownList7.DataValueField = "RefLot";
            DropDownList7.DataSource = null;
            DropDownList7.DataSource = bn31;
            DropDownList7.DataBind();
            connection31.Close();
            var qr = (from rw in db.PowerSegregationTables select new { rw.TumblingNo }).Distinct();
            DropDownList3.Items.Clear();
            DropDownList3.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList3.DataSource = qr;
            DropDownList3.DataValueField = "";
            DropDownList3.DataTextField = "TumblingNo";
            DropDownList3.DataBind();
            DropDownList6.Items.Clear();
            DropDownList6.Items.Insert(0, new ListItem("--Select--", "0"));
            DropDownList6.DataSource = qr;
            DropDownList6.DataValueField = "";
            DropDownList6.DataTextField = "TumblingNo";
            DropDownList6.DataBind();
            //Button2.Enabled = false;
            //Button6.Enabled = false;
            Drop.Visible = false;
            Del.Visible = false;
            btn.Visible = false;
            Update.Visible = false;
            Drop1.Visible = false;
            Del1.Visible = false;
            btn1.Visible = false;
            Update1.Visible = false;
            Exist.Visible = false;
            Exist1.Visible = false;
        }

    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    protected void Linkbutton1_Click(object sender, EventArgs e)
    {
        //FileUpload1.PostedFile.SaveAs(Server.MapPath(FileUpload1.FileName));
        //ViewState["file"] = FileUpload1.FileName;
        Update.Visible = false;
        Label7.Visible = false;
        Drop.Visible = false;
        btn.Visible = true;
        ImageButton4.Visible = false;
        Button1.Enabled = false;
        ImageButton1.Visible = true;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString);
        //con.Open();
        //con1.Open();
        StreamReader sr = new StreamReader(FileUpload1.FileContent);
        var linecount = 0;

        //string[] lines1 = new string[6];     
        while ((line = sr.ReadLine()) != null)
        {
            string chk = line.Trim(new char[] { '\t' });
            if (chk == "")
            {
            } //string[] tokens = line.Split(':');
            else
            {  //string last1 = tokens[tokens.Length - 1];
                if (linecount < 15)
                {
                    lines = line.Split(':');
                    string last = lines[lines.Length - 1];
                    string rpl = Regex.Replace(last, @"\s+|\t", "");
                    char[] arr = new char[] { ' ', '\t' };
                    last = rpl.Trim(arr);
                    string first = lines[0];
                    string rplace = Regex.Replace(first, @"\s+|\t", "");
                    char[] ar = new char[] { ' ', '\t' };
                    first = rplace.Trim(ar);

                    if (first == "LOT")
                    {
                        losrno = last;
                        var r = from row in db.PowerSegregationTables where row.TumblingNo == last select row;
                        if (r.Count() > 0)
                        {
                            //    SqlCommand cmd = new SqlCommand();
                            //    cmd.CommandText = "Delete From POUCH_LABEL where Batch='" + btch + "' and LotNo IS NULL";
                            //    cmd.Connection = con;
                            //    cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Insert into PowerSegregationTable (TumblingNo) values(@TumblingNo)";
                            cmd.Connection = con;
                            cmd.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = last;
                            //cmd.Parameters.Add("@Power", SqlDbType.VarChar, 50).Value = last;
                            //cmd.Parameters.Add("@Batch", SqlDbType.VarChar, 50).Value = last;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    if (first == "Batch")
                    {
                        btch = last;
                    }

                    else if (first == "Diameter")
                    {
                        //dia = Convert.ToDecimal(last);
                    }
                    else if (first == "Sampled")
                    {
                        samp = Convert.ToInt32(last);
                        var q = from row in db.PowerSegregationTables where row.RecievedQty == samp && row.TumblingNo == losrno select row;
                        if (q.Count() == 0)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Update PowerSegregationTable set RecievedQty=@RecievedQty,TotalQty=@TotalQty where TumblingNo='" + losrno + "'";
                            cmd.Connection = con;
                            cmd.Parameters.Add("@RecievedQty", SqlDbType.Int).Value = last;
                            cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = last;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else if (first == "Passed")
                    {
                        pass = Convert.ToInt32(last);
                        var q = from row in db.PowerSegregationTables where row.AcceptedQty == pass && row.TumblingNo == losrno select row;
                        if (q.Count() == 0)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Update PowerSegregationTable set AcceptedQty=@AcceptedQty where TumblingNo='" + losrno + "'";
                            cmd.Connection = con;
                            cmd.Parameters.Add("@AcceptedQty", SqlDbType.Int).Value = last;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else if (first == "Failed")
                    {
                        fail = Convert.ToInt32(last);
                        DateTime dt = System.DateTime.Now;
                        var q = from row in db.PowerSegregationTables where row.RejectedQty == fail && row.TumblingNo == losrno select row;
                        if (q.Count() == 0)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Update PowerSegregationTable set RejectedQty=@RejectedQty,Resolution=@Resolution,Date=@Date where TumblingNo='" + losrno + "'";
                            cmd.Connection = con;
                            cmd.Parameters.Add("@RejectedQty", SqlDbType.Int).Value = last;
                            cmd.Parameters.Add("@Resolution", SqlDbType.VarChar, 50).Value = "Good";
                            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dt;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else if (first == "MTFrejectedLimit")
                    {
                        MTF = Convert.ToDouble(last);
                    }

                    linecount++;
                    con.Close();
                }

                else if (linecount == 15)
                {
                    string replace = Regex.Replace(line, @"\t|\n", " ");
                    string wh = "\\s+";
                    lines = Regex.Split(replace, wh);
                    MTFQual = lines[6];
                    linecount++;
                }
                else if (linecount > 15)
                {
                    string replace = Regex.Replace(line, @"\t|\n", "");
                    //char[] white = new char[] { ' ', '\t' };              
                    //lines = replace.Split(white);
                    string wh = "\\s+";
                    lines = Regex.Split(replace, wh);
                    if (lines.Count() == 8)
                    {
                        mtfno = lines[6];
                        double mtnum = Convert.ToDouble(mtfno);

                        if (MTFQual == "MTF")
                        {
                            if (mtnum >= MTF)
                            {
                                datastore();
                                linecount++;
                            }
                            else
                            {
                                PowerRejectMtf();
                                linecount++;
                            }
                        }
                        else if (MTFQual == "Quality")
                        {
                            if (mtnum >= 6.00)
                            {
                                datastore();
                                linecount++;
                            }
                            else
                            {
                                PowerRejectMtf();
                                linecount++;
                            }
                        }

                    }
                    else
                    {
                        if (lines.Count() == 9)
                        {
                            PowerReject();
                        }
                        linecount++;
                    }
                }
            }
        }
        Messagebox("Data Saved!!!");
        btn.Visible = true;
        sr.Close();
        //File.WriteAllText("d:/file1.txt", string.Empty);
        //con.Close();
        //con1.Close();       
    }
    //protected void Linkbutton1_Click(object sender, EventArgs e)
    //{
    //    FileUpload1.PostedFile.SaveAs(Server.MapPath(FileUpload1.FileName));
    //    ViewState["file"] = FileUpload1.FileName;      
    //    Update.Visible = false;
    //    Label7.Visible = false;
    //    Drop.Visible = false;
    //    btn.Visible = true;
    //}

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button2.Enabled = true;
        Button6.Enabled = true;
    }
    protected void BindGrid()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + DropDownList2.SelectedValue + "' group by Power,Status", con1);
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con1.Close();
    }
    protected void Gridbind()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_MORIAConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + DropDownList5.SelectedValue + "' group by Power,Status", con1);
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con1.Close();
    }
    protected void Gridviewbind()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + DropDownList4.SelectedValue + "' group by Power", con1);
        GridView7.DataSource = cmd.ExecuteReader();
        GridView7.DataBind();
        con1.Close();
    }
    protected void Gridviewbind1()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_MORIAConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + DropDownList7.SelectedValue + "' group by Power", con1);
        GridView8.DataSource = cmd.ExecuteReader();
        GridView8.DataBind();
        con1.Close();
    }
    protected void grview1()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_MORIAConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + losrno + "' group by Power", con1);
        GridView6.DataSource = cmd.ExecuteReader();
        GridView6.DataBind();
        con1.Close();
    }
    protected void grview()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + losrno + "' group by Power", con1);
        GridView5.DataSource = cmd.ExecuteReader();
        GridView5.DataBind();
        con1.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in GridView1.Rows)
        {
            CheckBox ch = (CheckBox)r.FindControl("CheckBox1");
            if (ch.Checked == true)
            {
                Label lblref = (Label)r.FindControl("Label5");
                Label lblpow = (Label)r.FindControl("Label3");
                Label lblsat = (Label)r.FindControl("Label6");
                string con1 = ConfigurationManager.ConnectionStrings["APSConnectionString"].ConnectionString;
                SqlConnection pmcon = new SqlConnection(con1);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "StoredProcedure1";
                cmd.Parameters.Add(new SqlParameter("@Action", "SearchPouch"));
                cmd.Parameters.Add(new SqlParameter("@Lot", lblref.Text));
                cmd.Parameters.Add(new SqlParameter("@Pow", lblpow.Text));
                cmd.Parameters.Add(new SqlParameter("@Sat", lblsat.Text));
                cmd.Parameters.Add(new SqlParameter("@Labl", "0"));
                cmd.Connection = pmcon;
                pmcon.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Open();
                using (SqlBulkCopy bulkdata = new SqlBulkCopy(con))
                {
                    bulkdata.ColumnMappings.Add("Brand_Name", "Brand_Name");
                    bulkdata.ColumnMappings.Add("Model_Name", "Model_Name");
                    bulkdata.ColumnMappings.Add("Reference_Name", "Reference_Name");
                    bulkdata.ColumnMappings.Add("Power", "Power");
                    bulkdata.ColumnMappings.Add("Qty", "Qty");
                    bulkdata.ColumnMappings.Add("Created_By", "Created_By");
                    bulkdata.ColumnMappings.Add("Created_Date", "Created_Date");
                    bulkdata.ColumnMappings.Add("Modified_By", "Modified_By");
                    bulkdata.ColumnMappings.Add("Modified_Date", "Modified_Date");
                    bulkdata.ColumnMappings.Add("R_Power", "R_Power");
                    bulkdata.ColumnMappings.Add("Type", "Type");
                    bulkdata.ColumnMappings.Add("rotlex_type", "rotlex_type");
                    bulkdata.ColumnMappings.Add("RefLot", "RefLot");
                    bulkdata.ColumnMappings.Add("Label", "Label");
                    bulkdata.DestinationTableName = "Pouch_Delete";
                    bulkdata.WriteToServer(dr);
                }
                con.Close();
                pmcon.Close();                
                SqlConnection delcon = new SqlConnection(con1);
                SqlCommand cmds = new SqlCommand();
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.CommandText = "StoredProcedure1";
                cmds.Parameters.Add(new SqlParameter("@Lot", lblref.Text));
                cmds.Parameters.Add(new SqlParameter("@Pow", lblpow.Text));
                cmds.Parameters.Add(new SqlParameter("@Sat", lblsat.Text));
                cmds.Parameters.Add(new SqlParameter("@Labl", "0"));
                cmds.Parameters.Add(new SqlParameter("@Action", "DeletePower"));
                cmds.Connection = delcon;
                delcon.Open();
                cmds.ExecuteNonQuery();
                delcon.Close();
            }
        }
        Messagebox("Deleted!!!");
        BindGrid();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Del.Visible = true;
        btn.Visible = false;
        Drop.Visible = false;
        Button1.Visible = true;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Update.Visible = true;
        Del.Visible = false;
        btn.Visible = false;
        Drop.Visible = false;
        ImageButton2.Visible = true;
        Button1.Visible = true;
    }
    protected void BindGrid2()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select id, TumblingNo, Power ,Qty,GlassyRecordRef from PowerSegregationChild where TumblingNo='" + DropDownList3.SelectedValue + "'", con);
        GridView2.DataSource = cmd.ExecuteReader();
        GridView2.DataBind();
        con.Close();
    }
    protected void Gridbind2()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select id, TumblingNo, Power ,Qty,GlassyRecordRef from PowerSegregationChild where TumblingNo='" + DropDownList6.SelectedValue + "'", con);
        GridView4.DataSource = cmd.ExecuteReader();
        GridView4.DataBind();
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        BindGrid2();
    }
    protected void Gridview2_Edit(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        BindGrid2();
    }
    protected void Gridview2_Update(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
        int userid = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value.ToString());
        tumbno = (TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox1");
        pow = (TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox2");
        qty = (TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox3");
        TextBox txtglass = (TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox4");
        var glas = from g in db.PowerSegregationChilds where g.GlassyRecordRef == txtglass.Text select g;
        if (glas.Count() == 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update PowerSegregationChild set GlassyRecordRef='" + txtglass.Text + "' where id='" + userid + "'", con);
            cmd.ExecuteNonQuery();
            ReportBind();
            con.Close();
            GridView2.EditIndex = -1;
            BindGrid2();
            Messagebox("Glassy Number Updated!!!");
        }
        else
        {
            Messagebox("Glassy Number Already Exists!!!");
        }
    }
    protected void Gridview2_Cancel(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        BindGrid2();
    }
    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Drop.Visible = true;
        btn.Visible = true;
        DropDownList1.Items.Clear();
        DropDownList1.SelectedIndex = -1;
        Response.Redirect("frmPower.aspx");
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        Drop.Visible = true;
        btn.Visible = true;
        DropDownList1.Items.Clear();
        DropDownList1.SelectedIndex = -1;
        Response.Redirect("frmPower.aspx");
    }
    protected void btnaps_Click(object sender, EventArgs e)
    {
        Drop.Visible = true;
        Buttons.Visible = false;
    }
    protected void btnmoria_Click(object sender, EventArgs e)
    {
        Buttons.Visible = false;
        Drop1.Visible = true;
    }
    //protected void Button6_Click(object sender, EventArgs e)
    //{
    //    FileUpload2.PostedFile.SaveAs(Server.MapPath(FileUpload2.FileName));
    //    ViewState["file"] = FileUpload2.FileName;
    //    Update1.Visible = false;
    //    //Label8.Visible = false;
    //    Drop1.Visible = false;
    //    btn1.Visible = true;
    //}
    protected void Button7_Click(object sender, EventArgs e)
    {
        Del1.Visible = true;
        btn1.Visible = false;
        Drop1.Visible = false;
        Button12.Visible = true;
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Update1.Visible = true;
        Del1.Visible = false;
        btn1.Visible = false;
        Drop1.Visible = false;
        Button14.Visible = true;
        Button12.Visible = true;
    }
    //protected void Button9_Click(object sender, EventArgs e)
    //{
    protected void Button6_Click(object sender, EventArgs e)
    {
        //FileUpload2.PostedFile.SaveAs(Server.MapPath(FileUpload2.FileName));
        //ViewState["file"] = FileUpload2.FileName;
        Update1.Visible = false;
        Label8.Visible = false;
        Drop1.Visible = false;
        Button9.Visible = false;
        btn1.Visible = true;
        Button12.Enabled = false;
        Button10.Visible = true;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_MORIAConnectionString"].ConnectionString);
        //con.Open();
        //con1.Open();
        StreamReader sr = new StreamReader(FileUpload2.FileContent);
        var linecount = 0;
        //string line = string.Empty;
        //string[] lines = new string[6];
        //string[] lines1 = new string[6];     
        while ((line = sr.ReadLine()) != null)
        {
            string chk = line.Trim(new char[] { '\t' });
            if (chk == "")
            {
            }
            //string[] tokens = line.Split(':');
            //string last1 = tokens[tokens.Length - 1];
            else
            {
                if (linecount < 15)
                {
                    lines = line.Split(':');
                    string last = lines[lines.Length - 1];
                    string rpl = Regex.Replace(last, @"\s+|\t", "");
                    char[] arr = new char[] { ' ', '\t' };
                    last = rpl.Trim(arr);
                    string first = lines[0];
                    string rplace = Regex.Replace(last, @"\s+|\t", "");
                    char[] ar = new char[] { ' ', '\t' };
                    first = rplace.Trim(ar);

                    if (first == "LOT")
                    {
                        losrno = last;
                        var r = from row in db.PowerSegregationTables where row.TumblingNo == last select row;
                        if (r.Count() > 0)
                        {
                            //    SqlCommand cmd = new SqlCommand();
                            //    cmd.CommandText = "Delete From POUCH_LABEL where Batch='" + btch + "' and LotNo IS NULL";
                            //    cmd.Connection = con;
                            //    cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Insert into PowerSegregationTable (TumblingNo) values(@TumblingNo)";
                            cmd.Connection = con;
                            cmd.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = last;
                            //cmd.Parameters.Add("@Power", SqlDbType.VarChar, 50).Value = last;
                            //cmd.Parameters.Add("@Batch", SqlDbType.VarChar, 50).Value = last;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    if (first == "Batch")
                    {
                        btch = last;
                    }

                    else if (first == "Diameter")
                    {
                        //dia = Convert.ToDecimal(last);
                    }
                    else if (first == "Sampled")
                    {
                        samp = Convert.ToInt32(last);
                        var q = from row in db.PowerSegregationTables where row.RecievedQty == samp && row.TumblingNo == losrno select row;
                        if (q.Count() == 0)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Update PowerSegregationTable set RecievedQty=@RecievedQty,TotalQty=@TotalQty where TumblingNo='" + losrno + "'";
                            cmd.Connection = con;
                            cmd.Parameters.Add("@RecievedQty", SqlDbType.Int).Value = last;
                            cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = last;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else if (first == "Passed")
                    {
                        pass = Convert.ToInt32(last);
                        var q = from row in db.PowerSegregationTables where row.AcceptedQty == pass && row.TumblingNo == losrno select row;
                        if (q.Count() == 0)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Update PowerSegregationTable set AcceptedQty=@AcceptedQty where TumblingNo='" + losrno + "'";
                            cmd.Connection = con;
                            cmd.Parameters.Add("@AcceptedQty", SqlDbType.Int).Value = last;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else if (first == "Failed")
                    {
                        fail = Convert.ToInt32(last);
                        DateTime dt = System.DateTime.Now;
                        var q = from row in db.PowerSegregationTables where row.RejectedQty == fail && row.TumblingNo == losrno select row;
                        if (q.Count() == 0)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "Update PowerSegregationTable set RejectedQty=@RejectedQty,Resolution=@Resolution,Date=@Date where TumblingNo='" + losrno + "'";
                            cmd.Connection = con;
                            cmd.Parameters.Add("@RejectedQty", SqlDbType.Int).Value = last;
                            cmd.Parameters.Add("@Resolution", SqlDbType.VarChar, 50).Value = "Good";
                            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dt;
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    else if (first == "MTFrejectedLimit")
                    {
                        MTF = Convert.ToDouble(last);
                    }

                    linecount++;
                    con.Close();
                }

                else if (linecount == 15)
                {
                    string replace = Regex.Replace(line, @"\t|\n", " ");
                    string wh = "\\s+";
                    lines = Regex.Split(replace, wh);
                    MTFQual = lines[6];
                    linecount++;
                }
                else if (linecount > 15)
                {
                    string replace = Regex.Replace(line, @"\t|\n", "");
                    //char[] white = new char[] { ' ', '\t' };              
                    //lines = replace.Split(white);
                    string wh = "\\s+";
                    lines = Regex.Split(replace, wh);
                    if (lines.Count() == 8)
                    {
                        mtfno = lines[6];
                        double mtnum = Convert.ToDouble(mtfno);

                        if (MTFQual == "MTF")
                        {
                            if (mtnum >= MTF)
                            {
                                datastoremoria();
                                linecount++;
                            }
                            else
                            {
                                PowerRejectMtfMoria();
                                linecount++;
                            }
                        }
                        else if (MTFQual == "Quality")
                        {
                            if (mtnum >= 6.00)
                            {
                                datastoremoria();
                                linecount++;
                            }
                            else
                            {
                                PowerRejectMtfMoria();
                                linecount++;
                            }
                        }
                    }

                    else
                    {
                        if (lines.Count() == 9)
                        {
                            PowerRejectMoria();
                        }
                        linecount++;
                    }
                }
            }
        }
        Messagebox("Data Saved!!!");
        sr.Close();
        //File.WriteAllText("d:/file1.txt", string.Empty);
        //con.Close();
        //con1.Close();
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        Drop1.Visible = true;
        btn1.Visible = true;
        //DropDownList4.Items.Clear();
        //DropDownList4.SelectedIndex = -1;
        Response.Redirect("frmPower.aspx");
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        Gridbind();
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        Drop1.Visible = true;
        btn1.Visible = true;
        //DropDownList4.Items.Clear();
        //DropDownList4.SelectedIndex = -1;
        Response.Redirect("frmPower.aspx");
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow r in GridView3.Rows)
        {
            CheckBox ch = (CheckBox)r.FindControl("CheckBox1");
            if (ch.Checked == true)
            {
                Label lblref = (Label)r.FindControl("Label5");
                Label lblpow = (Label)r.FindControl("Label3");
                Label lblsat = (Label)r.FindControl("Label6");
                string con1 = ConfigurationManager.ConnectionStrings["APS_MORIAConnectionString"].ConnectionString;
                SqlConnection pmcon = new SqlConnection(con1);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "StoredProcedure1";
                cmd.Parameters.Add(new SqlParameter("@Lot", lblref.Text));
                cmd.Parameters.Add(new SqlParameter("@Pow", lblpow.Text));
                cmd.Parameters.Add(new SqlParameter("@Sat", lblsat.Text));
                cmd.Parameters.Add(new SqlParameter("@Action", "SearchPouch"));
                cmd.Parameters.Add(new SqlParameter("@Labl", "0"));
                pmcon.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                con.Open();
                using (SqlBulkCopy bulkdata = new SqlBulkCopy(con))
                {
                    bulkdata.ColumnMappings.Add("Brand_Name", "Brand_Name");
                    bulkdata.ColumnMappings.Add("Model_Name", "Model_Name");
                    bulkdata.ColumnMappings.Add("Reference_Name", "Reference_Name");
                    bulkdata.ColumnMappings.Add("Power", "Power");
                    bulkdata.ColumnMappings.Add("Qty", "Qty");
                    bulkdata.ColumnMappings.Add("Created_By", "Created_By");
                    bulkdata.ColumnMappings.Add("Created_Date", "Created_Date");
                    bulkdata.ColumnMappings.Add("Modified_By", "Modified_By");
                    bulkdata.ColumnMappings.Add("Modified_Date", "Modified_Date");
                    bulkdata.ColumnMappings.Add("R_Power", "R_Power");
                    bulkdata.ColumnMappings.Add("Type", "Type");
                    bulkdata.ColumnMappings.Add("rotlex_type", "rotlex_type");
                    bulkdata.ColumnMappings.Add("RefLot", "RefLot");
                    bulkdata.ColumnMappings.Add("Label", "Label");
                    bulkdata.DestinationTableName = "Pouch_Delete";
                    bulkdata.WriteToServer(dr);
                }
                con.Close();
                pmcon.Close();
                SqlConnection delcon = new SqlConnection(con1);
                SqlCommand cmds = new SqlCommand();
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.CommandText = "StoredProcedure1";
                cmds.Parameters.Add(new SqlParameter("@Lot", lblref.Text));
                cmds.Parameters.Add(new SqlParameter("@Pow", lblpow.Text));
                cmds.Parameters.Add(new SqlParameter("@Sat", lblsat.Text));
                cmds.Parameters.Add(new SqlParameter("@Labl", "0"));
                cmds.Parameters.Add(new SqlParameter("@Action", "DeletePower"));
                cmds.Connection = delcon;
                delcon.Open();
                cmds.ExecuteNonQuery();
                delcon.Close();
            }
        }
        Messagebox("Deleted!!!");
        Gridbind();
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        Gridbind2();
    }
    protected void Gridview4_Edit(object sender, GridViewEditEventArgs e)
    {
        GridView4.EditIndex = e.NewEditIndex;
        Gridbind2();
    }
    protected void Gridview4_Update(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
        int userid = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Value.ToString());
        tumbno = (TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox1");
        pow = (TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox2");
        qty = (TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox3");
        txtglass = (TextBox)GridView4.Rows[e.RowIndex].FindControl("TextBox4");
        var glas = from g in db.PowerSegregationChilds where g.GlassyRecordRef == txtglass.Text select g;
        if (glas.Count() == 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update PowerSegregationChild set GlassyRecordRef='" + txtglass.Text + "' where id='" + userid + "'", con);
            cmd.ExecuteNonQuery();
            ReportBind();
            con.Close();
            GridView4.EditIndex = -1;
            Gridbind2();
            Messagebox("Glassy Number Updated!!!");
        }
        else
        {
            Messagebox("Glassy Number Already Exists!!!");
        }
    }
    protected void Gridview4_Cancel(object sender, GridViewCancelEditEventArgs e)
    {
        GridView4.EditIndex = -1;
        Gridbind2();
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        Buttons.Visible = true;
        Update.Visible = false;
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        Buttons.Visible = true;
        Update1.Visible = false;
    }

    protected void Button9_Click1(object sender, EventArgs e)
    {
        Drop.Visible = true;
        //btn1.Visible = true;
        //DropDownList4.Items.Clear();
        //DropDownList4.SelectedIndex = -1;
        Response.Redirect("frmPower.aspx");
    }
    protected void ImageButton5_Click(object sender, EventArgs e)
    {
        Gridviewbind();
    }
    protected void Button11_Click1(object sender, EventArgs e)
    {
        Drop1.Visible = true;
        Response.Redirect("frmPower.aspx");
    }
    protected void ImageButton6_Click(object sender, EventArgs e)
    {
        Gridviewbind1();
    }

    protected void Button18_Click(object sender, EventArgs e)
    {
        Exist1.Visible = true;
        Drop1.Visible = false;
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        Exist.Visible = true;
        Drop.Visible = false;
    }
    protected void btnclo_Click(object sender, EventArgs e)
    {
        Response.Redirect("Welcome.aspx");
    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Welcome.aspx");
    }
    private void ReportBind()
    {
        var w = from row in db.Report_Tables where row.TumblingNo == tumbno.Text && row.Power == Convert.ToDecimal(pow.Text) select row;
        if (w.Count() > 0)
        {
            w.FirstOrDefault().GlassyNo = txtglass.Text;
            w.FirstOrDefault().WaitingPowerSegregation = 0;
            w.FirstOrDefault().WaitingPouchPacking = Convert.ToInt32(qty.Text);
            w.FirstOrDefault().Status = 3;
            db.SubmitChanges();
        }
        else
        {
            Report_Table rt = new Report_Table();
            //var query = from row in db.LensPreperation_Details where row.TumblingRefNo == txtTumblingNo.Text select row;
            var s = from row in db.Report_Tables where row.TumblingNo == tumbno.Text select row;
            if (s.Count() > 0)
            {

                rt.TumblingNo = s.FirstOrDefault().TumblingNo;
                rt.Model = s.FirstOrDefault().Model;
                rt.PhobicId = s.FirstOrDefault().PhobicId;
                rt.WaitingPowerSegregation = 0;
                rt.WaitingTumbling = 0;
                rt.RunningTumbling = 0;
                rt.GlassyNo = txtglass.Text;
                rt.WaitingPouchPacking = Convert.ToInt32(qty.Text);
                rt.Power = Convert.ToDecimal(pow.Text);
                rt.Status = 3;
                db.Report_Tables.InsertOnSubmit(rt);
                db.SubmitChanges();
            }
            else
            {
                var w1 = from row in db.Report_Tables where row.RetumblingNo == tumbno.Text && row.Power == Convert.ToDecimal(pow.Text) select row;
                if (w1.Count() > 0)
                {
                    w1.FirstOrDefault().GlassyNo = txtglass.Text;
                    w1.FirstOrDefault().WaitingPowerSegregation = 0;
                    w1.FirstOrDefault().WaitingPouchPacking = Convert.ToInt32(qty.Text);
                    w1.FirstOrDefault().Status = 3;
                    db.SubmitChanges();
                }
                else
                {
                    //Report_Table rt1 = new Report_Table();
                    var s1 = from row in db.Report_Tables where row.RetumblingNo == tumbno.Text select row;
                    if (s1.Count() > 0)
                    {
                        rt.RetumblingNo = s1.FirstOrDefault().RetumblingNo;
                        rt.Model = s1.FirstOrDefault().Model;
                        rt.PhobicId = s1.FirstOrDefault().PhobicId;
                        rt.WaitingPowerSegregation = 0;
                        rt.WaitingTumbling = 0;
                        rt.RunningTumbling = 0;
                        rt.GlassyNo = txtglass.Text;
                        rt.WaitingPouchPacking = Convert.ToInt32(qty.Text);
                        rt.Power = Convert.ToDecimal(pow.Text);
                        rt.Status = 3;
                        db.Report_Tables.InsertOnSubmit(rt);
                        db.SubmitChanges();
                    }
                }
            }
        }
    }
    protected void datastore()
    {
        con1.Open();
        string str = "Select count(*) from POUCH_LABEL where rotlex_type='" + btch + "' AND RefLot='" + losrno + "' AND Label='" + lines[2] + "' AND Type='PHOBIC'";
        SqlCommand com = new SqlCommand(str, con1);
        int counts = Convert.ToInt32(com.ExecuteScalar());
        con1.Close();
        //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
        var query = from model in db.BatchAllots where model.LotNo == losrno select model;
        string mod = query.Single().ModelNo;
        string bat = query.Single().BatchNo;
        if (counts == 0)
        {
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "Insert into MacDetail (LotNo,Batch,Diameter,Sampled,Accepted,Rejected,Operator,Date,Time,Power,Cylinder,Grp,Model,Label,LotSrNo,BatchNo,GScode,ManfYr,ExpYr,ManfMonth,ExpMonth,Brand) Values(@LotNo,@Batch,@Diameter,@Sampled,@Accepted,@Rejected,@Operator,@Date,@Time,@Power,@Cylinder,@Grp,@Model,@Label,@LotSrNo,@BatchNo,@GScode,@ManfYr,@ExpYr,@ManfMonth,@ExpMonth,@Brand)";
            cmd.CommandText = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,GS_Code,Power,Optic,Length,Lot_Unit," +
                            "A_Constant,Type_GS_Code,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_No,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization, " +
                            "Sample_Taken,Type_Sample,BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,R_Power,rotlex_type,Label,RefLot,Status)" +
                            "values(@Brand_Name,@Model_Name,@Reference_Name,@GS_Code,@Power,@Optic,@Length,@Lot_Unit," +
                            "@A_Constant,@Type_GS_Code,@Qty,@St_SrNo,@St_EnNo,@Lot_Prefix,@Lot_No,@Lot_SrNo,@Mfd_Month,@Mfd_Year,@Exp_Month,@Exp_Year,@Sterilization, " +
                            "@Sample_Taken,@Type_Sample,@BPL_Taken,@Box_Packing,@Dc_Packing,@Created_By,@Created_Date,@Modified_By,@Modified_Date,@Sterilization_Reject,@Qty_1,@Type,@Sterilization_After,@Box_Reject,@Print_Name,@R_Power,@rotlex_type,@Label,@RefLot,@Status)";
            cmd.Connection = con1;
            string s = lines[2];
            int count = 0;
            string lab = string.Empty;
            foreach (char c in s)
            {
                count++;
            }
            if (count == 1)
            {
                lab = "00" + lines[2];
            }
            else if (count == 2)
            {
                lab = "0" + lines[2];
            }
            else if (count == 3)
            {
                lab = lines[2];
            }
            //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;

            SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AI'", con1);
            SqlDataReader dar = recm.ExecuteReader();
            if (dar.Read())
            {
                gscode1 = dar["GS_Code"].ToString();
                totexp1 = Convert.ToInt32(dar["Tot_Exp"]);
                optic = Convert.ToDecimal(dar["Optic"]);
                length = Convert.ToDecimal(dar["Length"]);
                lotunit = dar["Lot_Unit"].ToString();
                Aconst = Convert.ToDecimal(dar["A_Constant"]);
                TypeGS = dar["Type_GS_Code"].ToString();
                refname = dar["Reference_Name"].ToString();
            }
            con1.Close();
            con1.Open();
            DateTime dt = System.DateTime.Now;
            string initialString = losrno;
            System.Text.RegularExpressions.Regex nonNumericCharacters = new System.Text.RegularExpressions.Regex(@"\D");
            string numericOnlyString = nonNumericCharacters.Replace(initialString, String.Empty);
            stryear = numericOnlyString.Substring(0, 2);
            strmonth = numericOnlyString.Substring(2, 2);
            int i = 0;
            foreach (char cr in losrno)
            {
                string tempc = cr.ToString();
                System.Text.RegularExpressions.Regex al = new System.Text.RegularExpressions.Regex("^[A-z]+$");
                if (al.IsMatch(tempc))
                {
                    i++;
                }
            }
            if (i == 1)
            {
                prefix = losrno.Substring(0, 5);
                int num = losrno.Length - prefix.Length;
                lotno = losrno.Substring(5, num);
            }
            else if (i == 2)
            {
                prefix = losrno.Substring(0, 6);
                int num = losrno.Length - prefix.Length;
                lotno = losrno.Substring(6, num);
            }
            else
            {
                prefix = losrno.Substring(0, 4);
                int num = losrno.Length - prefix.Length;
                lotno = losrno.Substring(4, num);
            }
            if (strmonth == "01")
            {
                strmanfmonth = strmonth;
                strmanfyear = Convert.ToString(Convert.ToInt32(stryear) + 2000);
                expmonth = Convert.ToString((Convert.ToInt32(strmonth) - 1) + 12);
                expyear = Convert.ToString(Convert.ToInt32(stryear) + 2000 + totexp1 - 1);
            }
            else
            {
                strmanfmonth = strmonth;
                strmanfyear = Convert.ToString(Convert.ToInt32(stryear) + 2000);
                expmonth = "0" + Convert.ToString(Convert.ToInt32(strmonth) - 1);
                expyear = Convert.ToString(Convert.ToInt32(stryear) + 2000 + totexp1);
            }

            cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
            cmd.Parameters.Add("@Model_Name", SqlDbType.NVarChar, 50).Value = mod;
            cmd.Parameters.Add("@Reference_Name", SqlDbType.NVarChar, 50).Value = refname;
            cmd.Parameters.Add("@GS_Code", SqlDbType.NVarChar, 50).Value = gscode1;
            cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[7];
            cmd.Parameters.Add("@Optic", SqlDbType.Money).Value = optic;
            cmd.Parameters.Add("@Length", SqlDbType.Money).Value = length;
            cmd.Parameters.Add("@Lot_Unit", SqlDbType.VarChar, 10).Value = lotunit;
            cmd.Parameters.Add("@A_Constant", SqlDbType.Money).Value = Aconst;
            cmd.Parameters.Add("@Type_GS_Code", SqlDbType.NVarChar, 50).Value = TypeGS;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@St_SrNo", SqlDbType.Int).Value = lab;
            cmd.Parameters.Add("@St_EnNo", SqlDbType.Int).Value = 001;
            cmd.Parameters.Add("@Lot_Prefix", SqlDbType.NVarChar, 50).Value = prefix;
            cmd.Parameters.Add("@Lot_No", SqlDbType.NVarChar, 50).Value = lotno;
            cmd.Parameters.Add("@Lot_SrNo", SqlDbType.NVarChar, 50).Value = losrno + " " + lab;
            cmd.Parameters.Add("@Mfd_Month", SqlDbType.Int).Value = strmanfmonth;
            cmd.Parameters.Add("@Mfd_Year", SqlDbType.Int).Value = strmanfyear;
            cmd.Parameters.Add("@Exp_Month", SqlDbType.Int).Value = expmonth;
            cmd.Parameters.Add("@Exp_Year", SqlDbType.Int).Value = expyear;
            cmd.Parameters.Add("@Sterilization", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Sample_Taken", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Type_Sample", SqlDbType.NVarChar, 50).Value = "NO";
            cmd.Parameters.Add("@BPL_Taken", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Box_Packing", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Dc_Packing", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Created_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Modified_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Modified_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Sterilization_Reject", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Qty_1", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "PHOBIC";
            cmd.Parameters.Add("@Sterilization_After", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Box_Reject", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Print_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
            cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
            //cmd.Parameters.Add("@Cylsize", SqlDbType.NVarChar, 50).Value = lines[14];
            cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
            cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = lines[2];
            cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = losrno;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = "Not Labelled";
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "Update POUCH_LABEL set St_EnNo=@St_EnNo,Qty=@Qty where RefLot='" + losrno + "'";
            cmd1.Connection = con1;
            cmd1.Parameters.Add("@St_EnNo", SqlDbType.VarChar, 50).Value = endsrno + 1;
            cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = endsrno + 1;
            cmd1.ExecuteNonQuery();
            grview();
            con1.Close();
            con.Open();
            SqlCommand sm = new SqlCommand();
            sm.CommandText = "Update PowerSegregationTable set InspectedBy=@InspectedBy where TumblingNo='" + losrno + "'";
            sm.Connection = con;
            sm.Parameters.Add("@InspectedBy", SqlDbType.VarChar, 50).Value = lines[1];
            sm.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("Select Qty from PowerSegregationChild where TumblingNo='" + losrno + "' and Power='" + lines[7] + "'", con);
            SqlDataReader dr = cm.ExecuteReader();
            int quantity = 0;
            if (dr.Read())
            {
                quantity = Convert.ToInt32(dr["Qty"]);
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand();
                //int quant = Convert.ToInt32(pr.First().Qty);
                cmd2.CommandText = "Update PowerSegregationChild set Qty=@Qty where TumblingNo='" + losrno + "' and Power='" + lines[7] + "'";
                cmd2.Connection = con;
                cmd2.Parameters.Add("@Qty", SqlDbType.Int).Value = quantity + 1;
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand();
                int quant1 = 0;
                cmd2.CommandText = "Insert into PowerSegregationChild (TumblingNo,Power,Qty,GlassyRecordRef) values(@TumblingNo,@Power,@Qty,@GlassyRecordRef)";
                cmd2.Connection = con;
                cmd2.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = losrno;
                cmd2.Parameters.Add("@Power", SqlDbType.Decimal).Value = lines[7];
                cmd2.Parameters.Add("@Qty", SqlDbType.Int).Value = quant1 + 1;
                cmd2.Parameters.Add("@GlassyRecordRef", SqlDbType.VarChar, 50).Value = "GR" + lines[2];
                cmd2.ExecuteNonQuery();


            }
            endsrno = Convert.ToInt32(lines[2]);
            con.Close();
            //}
        }
        else
        {
            Messagebox("Data Already Saved!!!");
            Drop.Visible = true;
            btn.Visible = false;
        }
    }
    protected void PowerRejectMtf()
    {
        con.Open();
        string str = "Select count(*) from PowerReject where rotlex_type='" + btch + "' AND RefLot='" + losrno + "' AND Label='" + lines[2] + "' AND Type='PHOBIC'";
        SqlCommand com = new SqlCommand(str, con);
        int counts = Convert.ToInt32(com.ExecuteScalar());
        con.Close();
        //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
        var query = from model in db.BatchAllots where model.LotNo == losrno select model;
        string mod = query.Single().ModelNo;
        string bat = query.Single().BatchNo;
        if (counts == 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "Insert into MacDetail (LotNo,Batch,Diameter,Sampled,Accepted,Rejected,Operator,Date,Time,Power,Cylinder,Grp,Model,Label,LotSrNo,BatchNo,GScode,ManfYr,ExpYr,ManfMonth,ExpMonth,Brand) Values(@LotNo,@Batch,@Diameter,@Sampled,@Accepted,@Rejected,@Operator,@Date,@Time,@Power,@Cylinder,@Grp,@Model,@Label,@LotSrNo,@BatchNo,@GScode,@ManfYr,@ExpYr,@ManfMonth,@ExpMonth,@Brand)";
            cmd.CommandText = "insert into PowerReject (Brand_Name,Model_Name,Reference_Name,Power," +
                             "Qty,Created_By,Created_Date,Modified_By,Modified_Date,Type,R_Power,rotlex_type,Label,RefLot)" +

                             "values(@Brand_Name,@Model_Name,@Reference_Name,@Power,@Qty," +
                             "@Created_By,@Created_Date,@Modified_By,@Modified_Date,@Type,@R_Power,@rotlex_type,@Label,@RefLot)";
            cmd.Connection = con;
            con.Close();
            //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;
            con1.Open();
            SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AI'", con1);
            SqlDataReader dar = recm.ExecuteReader();
            if (dar.Read())
            {
                gscode1 = dar["GS_Code"].ToString();
                totexp1 = Convert.ToInt32(dar["Tot_Exp"]);
                optic = Convert.ToDecimal(dar["Optic"]);
                length = Convert.ToDecimal(dar["Length"]);
                lotunit = dar["Lot_Unit"].ToString();
                Aconst = Convert.ToDecimal(dar["A_Constant"]);
                TypeGS = dar["Type_GS_Code"].ToString();
                refname = dar["Reference_Name"].ToString();
            }
            con1.Close();
            con.Open();
            DateTime dt = System.DateTime.Now;
            cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
            cmd.Parameters.Add("@Model_Name", SqlDbType.NVarChar, 50).Value = mod;
            cmd.Parameters.Add("@Reference_Name", SqlDbType.NVarChar, 50).Value = refname;
            cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[7];
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Created_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Modified_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Modified_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "PHOBIC";
            cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
            cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
            cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = lines[2];
            cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = losrno;
            //cmd.Parameters.Add("@CySize", SqlDbType.VarChar, 50).Value = lines[7];
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            int r = 0;
            cmd1.CommandText = "Update PowerReject set Qty=@Qty where RefLot='" + losrno + "'";
            cmd1.Connection = con;
            cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = r + 1;
            cmd1.ExecuteNonQuery();
            //grview();
            con.Close();
        }
        else
        {
            Messagebox("Data Already Saved!!!");
            Drop.Visible = true;
            btn.Visible = false;
        }
    }
    protected void PowerReject()
    {
        con.Open();
        string str = "Select count(*) from PowerReject where rotlex_type='" + btch + "' AND RefLot='" + losrno + "' AND Label='" + lines[2] + "' AND Type='PHOBIC'";
        SqlCommand com = new SqlCommand(str, con);
        int counts = Convert.ToInt32(com.ExecuteScalar());
        con.Close();
        //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
        var query = from model in db.BatchAllots where model.LotNo == losrno select model;
        string mod = query.Single().ModelNo;
        string bat = query.Single().BatchNo;
        if (counts == 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "Insert into MacDetail (LotNo,Batch,Diameter,Sampled,Accepted,Rejected,Operator,Date,Time,Power,Cylinder,Grp,Model,Label,LotSrNo,BatchNo,GScode,ManfYr,ExpYr,ManfMonth,ExpMonth,Brand) Values(@LotNo,@Batch,@Diameter,@Sampled,@Accepted,@Rejected,@Operator,@Date,@Time,@Power,@Cylinder,@Grp,@Model,@Label,@LotSrNo,@BatchNo,@GScode,@ManfYr,@ExpYr,@ManfMonth,@ExpMonth,@Brand)";
            cmd.CommandText = "insert into PowerReject (Brand_Name,Model_Name,Reference_Name,Power," +
                             "Qty,Created_By,Created_Date,Modified_By,Modified_Date,Type,R_Power,rotlex_type,Label,RefLot)" +

                             "values(@Brand_Name,@Model_Name,@Reference_Name,@Power,@Qty," +
                             "@Created_By,@Created_Date,@Modified_By,@Modified_Date,@Type,@R_Power,@rotlex_type,@Label,@RefLot)";
            cmd.Connection = con;
            con.Close();
            //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;
            con1.Open();
            SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[8] + "' AND Type_GS_Code='AI'", con1);
            SqlDataReader dar = recm.ExecuteReader();
            if (dar.Read())
            {
                gscode1 = dar["GS_Code"].ToString();
                totexp1 = Convert.ToInt32(dar["Tot_Exp"]);
                optic = Convert.ToDecimal(dar["Optic"]);
                length = Convert.ToDecimal(dar["Length"]);
                lotunit = dar["Lot_Unit"].ToString();
                Aconst = Convert.ToDecimal(dar["A_Constant"]);
                TypeGS = dar["Type_GS_Code"].ToString();
                refname = dar["Reference_Name"].ToString();
            }
            con1.Close();
            con.Open();
            DateTime dt = System.DateTime.Now;
            cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
            cmd.Parameters.Add("@Model_Name", SqlDbType.NVarChar, 50).Value = mod;
            cmd.Parameters.Add("@Reference_Name", SqlDbType.NVarChar, 50).Value = refname;
            cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[8];
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Created_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Modified_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Modified_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "PHOBIC";
            cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
            cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
            cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = lines[2];
            cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = losrno;
            //cmd.Parameters.Add("@CySize", SqlDbType.VarChar, 50).Value = lines[7];
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            int r = 0;
            cmd1.CommandText = "Update PowerReject set Qty=@Qty where RefLot='" + losrno + "'";
            cmd1.Connection = con;
            cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = r + 1;
            cmd1.ExecuteNonQuery();
            //grview();
            con.Close();
        }
        else
        {
            Messagebox("Data Already Saved!!!");
            Drop.Visible = true;
            btn.Visible = false;
        }
    }
    protected void datastoremoria()
    {
        con1.Open();
        string str = "Select count(*) from POUCH_LABEL where rotlex_type='" + btch + "' AND RefLot='" + losrno + "' AND Label='" + lines[2] + "' AND Type='PHOBIC'";
        SqlCommand com = new SqlCommand(str, con1);
        int counts = Convert.ToInt32(com.ExecuteScalar());
        con1.Close();
        //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
        var query = from model in db.BatchAllots where model.LotNo == losrno select model;
        string mod = query.Single().ModelNo;
        string bat = query.Single().BatchNo;
        if (counts == 0)
        {
            con1.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "Insert into MacDetail (LotNo,Batch,Diameter,Sampled,Accepted,Rejected,Operator,Date,Time,Power,Cylinder,Grp,Model,Label,LotSrNo,BatchNo,GScode,ManfYr,ExpYr,ManfMonth,ExpMonth,Brand) Values(@LotNo,@Batch,@Diameter,@Sampled,@Accepted,@Rejected,@Operator,@Date,@Time,@Power,@Cylinder,@Grp,@Model,@Label,@LotSrNo,@BatchNo,@GScode,@ManfYr,@ExpYr,@ManfMonth,@ExpMonth,@Brand)";
            cmd.CommandText = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,GS_Code,Power,Optic,Length,Lot_Unit," +
                            "A_Constant,Type_GS_Code,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_No,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization, " +
                            "Sample_Taken,Type_Sample,BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,rotlex_type,Label,RefLot,Status)" +
                            "values(@Brand_Name,@Model_Name,@Reference_Name,@GS_Code,@Power,@Optic,@Length,@Lot_Unit," +
                            "@A_Constant,@Type_GS_Code,@Qty,@St_SrNo,@St_EnNo,@Lot_Prefix,@Lot_No,@Lot_SrNo,@Mfd_Month,@Mfd_Year,@Exp_Month,@Exp_Year,@Sterilization, " +
                            "@Sample_Taken,@Type_Sample,@BPL_Taken,@Box_Packing,@Dc_Packing,@Created_By,@Created_Date,@Modified_By,@Modified_Date,@Sterilization_Reject,@Qty_1,@Type,@Sterilization_After,@Box_Reject,@Print_Name,@rotlex_type,@Label,@RefLot,@Status)";
            cmd.Connection = con1;
            string s = lines[2];
            int count = 0;
            string lab = string.Empty;
            foreach (char c in s)
            {
                count++;
            }
            if (count == 1)
            {
                lab = "00" + lines[2];
            }
            else if (count == 2)
            {
                lab = "0" + lines[2];
            }
            else if (count == 3)
            {
                lab = lines[2];
            }
            //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;
            SqlCommand recm1 = new SqlCommand("Select Brand_Name from LENS_MASTER where Replace(Model_Name,' ','')='" + mod + "' AND Power='" + lines[7] + "'", con1);
            SqlDataReader dar1 = recm1.ExecuteReader();
            if (dar1.Read())
            {
                Brand = dar1["Brand_Name"].ToString();
            }
            con1.Close();
            con1.Open();
            SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + Brand + "' AND Replace(Model_Name,' ','')='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='MORIA'", con1);
            SqlDataReader dar = recm.ExecuteReader();
            if (dar.Read())
            {
                gscode1 = dar["GS_Code"].ToString();
                totexp1 = Convert.ToInt32(dar["Tot_Exp"]);
                optic = Convert.ToDecimal(dar["Optic"]);
                length = Convert.ToDecimal(dar["Length"]);
                lotunit = dar["Lot_Unit"].ToString();
                Aconst = Convert.ToDecimal(dar["A_Constant"]);
                TypeGS = dar["Type_GS_Code"].ToString();
                refname = dar["Reference_Name"].ToString();
            }
            con1.Close();
            con1.Open();
            DateTime dt = System.DateTime.Now;
            string initialString = losrno;
            System.Text.RegularExpressions.Regex nonNumericCharacters = new System.Text.RegularExpressions.Regex(@"\D");
            string numericOnlyString = nonNumericCharacters.Replace(initialString, String.Empty);
            stryear = numericOnlyString.Substring(0, 2);
            strmonth = numericOnlyString.Substring(2, 2);
            int i = 0;
            foreach (char cr in losrno)
            {
                string tempc = cr.ToString();
                System.Text.RegularExpressions.Regex al = new System.Text.RegularExpressions.Regex("^[A-z]+$");
                if (al.IsMatch(tempc))
                {
                    i++;
                }
            }
            if (i == 1)
            {
                prefix = losrno.Substring(0, 5);
                int num = losrno.Length - prefix.Length;
                lotno = losrno.Substring(5, num);
            }
            else if (i == 2)
            {
                prefix = losrno.Substring(0, 6);
                int num = losrno.Length - prefix.Length;
                lotno = losrno.Substring(6, num);
            }
            else
            {
                prefix = losrno.Substring(0, 4);
                int num = losrno.Length - prefix.Length;
                lotno = losrno.Substring(4, num);
            }
            if (strmonth == "01")
            {
                strmanfmonth = strmonth;
                strmanfyear = Convert.ToString(Convert.ToInt32(stryear) + 2000);
                expmonth = Convert.ToString((Convert.ToInt32(strmonth) - 1) + 12);
                expyear = Convert.ToString(Convert.ToInt32(stryear) + 2000 + totexp1);
            }
            else
            {
                strmanfmonth = strmonth;
                strmanfyear = Convert.ToString(Convert.ToInt32(stryear) + 2000);
                expmonth = "0" + Convert.ToString(Convert.ToInt32(strmonth) - 1);
                expyear = Convert.ToString(Convert.ToInt32(stryear) + 2000 + totexp1);
            }

            cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = Brand;
            cmd.Parameters.Add("@Model_Name", SqlDbType.NVarChar, 50).Value = mod;
            cmd.Parameters.Add("@Reference_Name", SqlDbType.NVarChar, 50).Value = refname;
            cmd.Parameters.Add("@GS_Code", SqlDbType.NVarChar, 50).Value = gscode1;
            cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[7];
            cmd.Parameters.Add("@Optic", SqlDbType.Money).Value = optic;
            cmd.Parameters.Add("@Length", SqlDbType.Money).Value = length;
            cmd.Parameters.Add("@Lot_Unit", SqlDbType.VarChar, 10).Value = lotunit;
            cmd.Parameters.Add("@A_Constant", SqlDbType.Money).Value = Aconst;
            cmd.Parameters.Add("@Type_GS_Code", SqlDbType.NVarChar, 50).Value = TypeGS;
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@St_SrNo", SqlDbType.Int).Value = lab;
            cmd.Parameters.Add("@St_EnNo", SqlDbType.Int).Value = 001;
            cmd.Parameters.Add("@Lot_Prefix", SqlDbType.NVarChar, 50).Value = prefix;
            cmd.Parameters.Add("@Lot_No", SqlDbType.NVarChar, 50).Value = lotno;
            cmd.Parameters.Add("@Lot_SrNo", SqlDbType.NVarChar, 50).Value = losrno + " " + lab;
            cmd.Parameters.Add("@Mfd_Month", SqlDbType.Int).Value = strmanfmonth;
            cmd.Parameters.Add("@Mfd_Year", SqlDbType.Int).Value = strmanfyear;
            cmd.Parameters.Add("@Exp_Month", SqlDbType.Int).Value = expmonth;
            cmd.Parameters.Add("@Exp_Year", SqlDbType.Int).Value = expyear;
            cmd.Parameters.Add("@Sterilization", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Sample_Taken", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Type_Sample", SqlDbType.NVarChar, 50).Value = "NO";
            cmd.Parameters.Add("@BPL_Taken", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Box_Packing", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Dc_Packing", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Created_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Modified_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Modified_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Sterilization_Reject", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Qty_1", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "PHOBIC";
            cmd.Parameters.Add("@Sterilization_After", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Box_Reject", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@Print_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
            //cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[4];
            //cmd.Parameters.Add("@Cylsize", SqlDbType.NVarChar, 50).Value = lines[7];
            cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
            cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = lines[2];
            cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = losrno;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = "Not Labelled";
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "Update POUCH_LABEL set St_EnNo=@St_EnNo,Qty=@Qty where RefLot='" + losrno + "'";
            cmd1.Connection = con1;
            cmd1.Parameters.Add("@St_EnNo", SqlDbType.VarChar, 50).Value = lab;
            cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = lines[2];
            cmd1.ExecuteNonQuery();
            grview1();
            con1.Close();
            con.Open();
            SqlCommand sm = new SqlCommand();
            sm.CommandText = "Update PowerSegregationTable set InspectedBy=@InspectedBy where TumblingNo='" + losrno + "'";
            sm.Connection = con;
            sm.Parameters.Add("@InspectedBy", SqlDbType.VarChar, 50).Value = lines[1];
            sm.ExecuteNonQuery();
            con.Close();
            con.Open();
            SqlCommand cm = new SqlCommand("Select Qty from PowerSegregationChild where TumblingNo='" + losrno + "' and Power='" + lines[7] + "'", con);
            SqlDataReader dr = cm.ExecuteReader();
            int quantity = 0;
            if (dr.Read())
            {
                quantity = Convert.ToInt32(dr["Qty"]);
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand();
                //int quant = Convert.ToInt32(pr.First().Qty);
                cmd2.CommandText = "Update PowerSegregationChild set Qty=@Qty where TumblingNo='" + losrno + "' and Power='" + lines[7] + "'";
                cmd2.Connection = con;
                cmd2.Parameters.Add("@Qty", SqlDbType.Int).Value = quantity + 1;
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand();
                int quant1 = 0;
                cmd2.CommandText = "Insert into PowerSegregationChild (TumblingNo,Power,Qty,GlassyRecordRef) values(@TumblingNo,@Power,@Qty,@GlassyRecordRef)";
                cmd2.Connection = con;
                cmd2.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = losrno;
                cmd2.Parameters.Add("@Power", SqlDbType.Decimal).Value = lines[7];
                cmd2.Parameters.Add("@Qty", SqlDbType.Int).Value = quant1 + 1;
                cmd2.Parameters.Add("@GlassyRecordRef", SqlDbType.VarChar, 50).Value = "GR" + lines[2];
                cmd2.ExecuteNonQuery();

            }
            con.Close();
            //}
        }
        else
        {
            Messagebox("Data Already Saved!!!");
            Drop1.Visible = true;
            btn1.Visible = false;
        }
    }
    protected void PowerRejectMtfMoria()
    {
        con.Open();
        string str = "Select count(*) from PowerReject where rotlex_type='" + btch + "' AND RefLot='" + losrno + "' AND Label='" + lines[2] + "' AND Type='PHOBIC'";
        SqlCommand com = new SqlCommand(str, con);
        int counts = Convert.ToInt32(com.ExecuteScalar());
        con.Close();
        //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
        var query = from model in db.BatchAllots where model.LotNo == losrno select model;
        string mod = query.Single().ModelNo;
        string bat = query.Single().BatchNo;
        if (counts == 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "Insert into MacDetail (LotNo,Batch,Diameter,Sampled,Accepted,Rejected,Operator,Date,Time,Power,Cylinder,Grp,Model,Label,LotSrNo,BatchNo,GScode,ManfYr,ExpYr,ManfMonth,ExpMonth,Brand) Values(@LotNo,@Batch,@Diameter,@Sampled,@Accepted,@Rejected,@Operator,@Date,@Time,@Power,@Cylinder,@Grp,@Model,@Label,@LotSrNo,@BatchNo,@GScode,@ManfYr,@ExpYr,@ManfMonth,@ExpMonth,@Brand)";
            cmd.CommandText = "insert into PowerReject (Brand_Name,Model_Name,Reference_Name,Power," +
                             "Qty,Created_By,Created_Date,Modified_By,Modified_Date,Type,R_Power,rotlex_type,Label,RefLot)" +

                             "values(@Brand_Name,@Model_Name,@Reference_Name,@Power,@Qty," +
                             "@Created_By,@Created_Date,@Modified_By,@Modified_Date,@Type,@R_Power,@rotlex_type,@Label,@RefLot)";
            cmd.Connection = con;
            con.Close();
            //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;
            con1.Open();
            SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AI'", con1);
            SqlDataReader dar = recm.ExecuteReader();
            if (dar.Read())
            {
                gscode1 = dar["GS_Code"].ToString();
                totexp1 = Convert.ToInt32(dar["Tot_Exp"]);
                optic = Convert.ToDecimal(dar["Optic"]);
                length = Convert.ToDecimal(dar["Length"]);
                lotunit = dar["Lot_Unit"].ToString();
                Aconst = Convert.ToDecimal(dar["A_Constant"]);
                TypeGS = dar["Type_GS_Code"].ToString();
                refname = dar["Reference_Name"].ToString();
            }
            con1.Close();
            con.Open();
            DateTime dt = System.DateTime.Now;
            cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
            cmd.Parameters.Add("@Model_Name", SqlDbType.NVarChar, 50).Value = mod;
            cmd.Parameters.Add("@Reference_Name", SqlDbType.NVarChar, 50).Value = refname;
            cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[7];
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Created_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Modified_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Modified_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "PHOBIC";
            cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
            cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
            cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = lines[2];
            cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = losrno;
            //cmd.Parameters.Add("@CySize", SqlDbType.VarChar, 50).Value = lines[7];
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            int r = 0;
            cmd1.CommandText = "Update PowerReject set Qty=@Qty where RefLot='" + losrno + "'";
            cmd1.Connection = con;
            cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = r + 1;
            cmd1.ExecuteNonQuery();
            //grview();
            con.Close();
        }

        else
        {
            Messagebox("Data Already Saved!!!");
            Drop1.Visible = true;
            btn1.Visible = false;
        }
    }
    protected void PowerRejectMoria()
    {
        con.Open();
        string str = "Select count(*) from PowerReject where rotlex_type='" + btch + "' AND RefLot='" + losrno + "' AND Label='" + lines[2] + "' AND Type='PHOBIC'";
        SqlCommand com = new SqlCommand(str, con);
        int counts = Convert.ToInt32(com.ExecuteScalar());
        con.Close();
        //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
        var query = from model in db.BatchAllots where model.LotNo == losrno select model;
        string mod = query.Single().ModelNo;
        string bat = query.Single().BatchNo;
        if (counts == 0)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "Insert into MacDetail (LotNo,Batch,Diameter,Sampled,Accepted,Rejected,Operator,Date,Time,Power,Cylinder,Grp,Model,Label,LotSrNo,BatchNo,GScode,ManfYr,ExpYr,ManfMonth,ExpMonth,Brand) Values(@LotNo,@Batch,@Diameter,@Sampled,@Accepted,@Rejected,@Operator,@Date,@Time,@Power,@Cylinder,@Grp,@Model,@Label,@LotSrNo,@BatchNo,@GScode,@ManfYr,@ExpYr,@ManfMonth,@ExpMonth,@Brand)";
            cmd.CommandText = "insert into PowerReject (Brand_Name,Model_Name,Reference_Name,Power," +
                             "Qty,Created_By,Created_Date,Modified_By,Modified_Date,Type,R_Power,rotlex_type,Label,RefLot)" +

                             "values(@Brand_Name,@Model_Name,@Reference_Name,@Power,@Qty," +
                             "@Created_By,@Created_Date,@Modified_By,@Modified_Date,@Type,@R_Power,@rotlex_type,@Label,@RefLot)";
            cmd.Connection = con;
            con.Close();
            //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;
            con1.Open();
            SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[8] + "' AND Type_GS_Code='AI'", con1);
            SqlDataReader dar = recm.ExecuteReader();
            if (dar.Read())
            {
                gscode1 = dar["GS_Code"].ToString();
                totexp1 = Convert.ToInt32(dar["Tot_Exp"]);
                optic = Convert.ToDecimal(dar["Optic"]);
                length = Convert.ToDecimal(dar["Length"]);
                lotunit = dar["Lot_Unit"].ToString();
                Aconst = Convert.ToDecimal(dar["A_Constant"]);
                TypeGS = dar["Type_GS_Code"].ToString();
                refname = dar["Reference_Name"].ToString();
            }
            con1.Close();
            con.Open();
            DateTime dt = System.DateTime.Now;
            cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
            cmd.Parameters.Add("@Model_Name", SqlDbType.NVarChar, 50).Value = mod;
            cmd.Parameters.Add("@Reference_Name", SqlDbType.NVarChar, 50).Value = refname;
            cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[8];
            cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Created_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Modified_By", SqlDbType.VarChar, 50).Value = "APS";
            cmd.Parameters.Add("@Modified_Date", SqlDbType.DateTime).Value = dt;
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "PHOBIC";
            cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
            cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
            cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = lines[2];
            cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = losrno;
            //cmd.Parameters.Add("@CySize", SqlDbType.VarChar, 50).Value = lines[7];
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            int r = 0;
            cmd1.CommandText = "Update PowerReject set Qty=@Qty where RefLot='" + losrno + "'";
            cmd1.Connection = con;
            cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = r + 1;
            cmd1.ExecuteNonQuery();
            //grview();
            con.Close();
        }

        else
        {
            Messagebox("Data Already Saved!!!");
            Drop1.Visible = true;
            btn1.Visible = false;
        }
    }
}







