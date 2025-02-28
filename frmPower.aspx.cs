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
using System.Web.UI.HtmlControls;

public partial class frmPower : System.Web.UI.Page
{
    int ReflotSer_dup;
    int bothReflotSer_dup;
    SoftLensDataContext db = new SoftLensDataContext();
    PouchDataContext db2 = new PouchDataContext();
    TextBox tumbno, pow, qty, txtglass;
    //MoriaDataContext db3 = new MoriaDataContext();
     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
     SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
    //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
    SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
    SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString);
    int endsrno = 0;
    string losrno, btch, stryear, strmonth, strmanfmonth, strmanfyear, expyear, expmonth, prefix, lotno, las;
    decimal dia;
    int pass, fail, samp;
    string gscode1, Brand, mtfno, qual, MTFQual, tumbLot,cylinder;
    string line = string.Empty;
    string[] lines = new string[6];
    string s, s1;
    string mod = string.Empty;
    string brand = string.Empty;
    double MTF;
    int totexp1;
    decimal optic;
    decimal length;
    string lotunit;
    decimal Aconst;
    string TypeGS;
    string refname;
    string sql_query;
    protected void Page_Load(object sender, EventArgs e)
    {
        var username = (Session["Username"] as HtmlInputControl).Value;

        if (username == null)
        {
            Response.Redirect("404Page.aspx");
        }
        if (!IsPostBack)
        {
            try
            {

              //  var getlot = db2.POUCH_LABELs

              //.Select(x => x.RefLot)
              //.Distinct()
              //.ToList();
              //  //var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;

                //string strconn0 = ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString;
                //SqlConnection connection0 = new SqlConnection(strconn0);
                //string que0 = "Select distinct LotNo FROM  NewBtchAllot";
                //SqlCommand cmd0 = new SqlCommand(que0, connection0);
                //SqlDataReader bn0;
                //connection0.Open();

                //bn0 = cmd0.ExecuteReader();
                //Droplotno1.Items.Clear();
                //Droplotno1.Items.Add("--Select--");
                ////droptyp.Items.Insert(0, new ListItem("--Select--"));
                //Droplotno1.DataTextField = "LotNo";
                //Droplotno1.DataValueField = "LotNo";
                ////DropDownList1.DataSource = null;
                //Droplotno1.DataSource = bn0;
                //Droplotno1.DataBind();
                //connection0.Close();


                string strconnbt = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
                SqlConnection connectionbt= new SqlConnection(strconnbt);
                string quebt= "Select distinct Type from Lot_Type";
                SqlCommand cmdbt = new SqlCommand(quebt, connectionbt);
                SqlDataReader bnbt;
                connectionbt.Open();

                bnbt = cmdbt.ExecuteReader();
                droptyp.Items.Clear();
                droptyp.Items.Add("--Select--");
                //droptyp.Items.Insert(0, new ListItem("--Select--"));
                droptyp.DataTextField = "Type";
                droptyp.DataValueField = "Type";
                //DropDownList1.DataSource = null;
                droptyp.DataSource = bnbt;
                droptyp.DataBind();
                connectionbt.Close();



               


                string strconn1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
                SqlConnection connection1 = new SqlConnection(strconn1);
                string que = "Select distinct RefLot from POUCH_LABEL ";
                SqlCommand cmd1 = new SqlCommand(que, connection1);
                SqlDataReader bn1;
                connection1.Open();
                bn1 = cmd1.ExecuteReader();
                DropDownList4.Items.Clear();
                //DropDownList4.Items.Insert(0, new ListItem("--Select--", "0"));
                DropDownList4.DataTextField = "RefLot";
                DropDownList4.DataValueField = "RefLot";
                //DropDownList4.DataSource = null;
                DropDownList4.DataSource = bn1;
                DropDownList4.DataBind();
                connection1.Close();


                string strconn2 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
                SqlConnection connection2 = new SqlConnection(strconn2);
                string que2 = "Select distinct RefLot from POUCH_LABEL where Type='Water-CE'";
                SqlCommand cmd2 = new SqlCommand(que2, connection2);
                SqlDataReader bn2;
                connection2.Open();
                bn2 = cmd2.ExecuteReader();
                DropDownList2.Items.Clear();
                //DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
                DropDownList2.DataTextField = "RefLot";
                DropDownList2.DataValueField = "RefLot";
                //DropDownList2.DataSource = null;
                DropDownList2.DataSource = bn2;
                DropDownList2.DataBind();
                connection2.Close();

              
                string strcn = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
                SqlConnection conn1 = new SqlConnection(strcn);
                string qerty = "Select distinct RefLot from POUCH_LABEL where Type='Water-CE'";
                SqlCommand cmmd = new SqlCommand(qerty, conn1);
                SqlDataReader drr;
                conn1.Open();
                drr = cmmd.ExecuteReader();
                DropDownList3.Items.Clear();
                //DropDownList3.Items.Insert(0, new ListItem("--Select--", "0"));
                DropDownList3.DataTextField = "RefLot";
                DropDownList3.DataValueField = "RefLot";
                //DropDownList3.DataSource = null;
                DropDownList3.DataSource = drr;
                DropDownList3.DataBind();
                conn1.Close();


                Win_btn.Enabled = false;
                Button2.Enabled = false;
                Button6.Enabled = false;
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
            catch (Exception ex)
            {
                Messagebox(ex.ToString());
            }
        }

    }
    

    protected void Linkbutton1_Click(object sender, EventArgs e)
    {
        if (Label14.Text == "NORMAL")
        {
            if (droptyp.SelectedValue == "--Select--")
            {
                Messagebox("Choose the Type");

            }
            try
            {
                var pouch_insertValues = string.Empty;
                Update.Visible = false;
                Label7.Visible = false;
                Drop.Visible = false;
                btn.Visible = true;
                ImageButton4.Visible = false;
                Button1.Enabled = false;
                ImageButton1.Visible = true;


                string fname = FileUpload1.FileName;
                string[] fnam1 = fname.Split('.');
                tumbLot = fnam1[0].ToString();


                var query = from model in db.NewBtchAllots where model.LotNo == tumbLot  select model;
                mod = query.Single().Model;
                brand = query.Single().Brand_Name;


                if (DropDownList1.Text == brand)
                {
                    StreamReader sr = new StreamReader(FileUpload1.FileContent);
                    var linecount = 0;


                    while ((line = sr.ReadLine()) != null)
                    {
                        string chk = line.Trim(new char[] { '\t' });
                        if (chk == "")
                        {
                        }
                        else
                        {
                            if (linecount < 13)
                            {
                                lines = line.Split(':');
                                string last = lines[lines.Length - 1];
                                string rpl = Regex.Replace(last, @"\s+|\t*", "");
                                char[] arr = new char[] { ' ', '\t', '/', '"', '*' };
                                last = rpl.Trim(arr);
                                string[] last1 = last.Split(',');
                                string las = last1[0];
                                string first = lines[0];
                                string rplace = Regex.Replace(first, @"\s+|\t*", "");
                                char[] ar = new char[] { ' ', '\t', '/', '"', '*' };
                                first = rplace.Trim(ar);

                                if (first == "LOT")
                                {
                                    losrno = las;
                                    var r = from row in db.PowerSegregationTables where row.TumblingNo == tumbLot select row;
                                    if (r.Count() > 0)
                                    {

                                    }
                                    else
                                    {
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand();
                                        cmd.CommandText = "Insert into PowerSegregationTable (TumblingNo) values(@TumblingNo)";
                                        cmd.Connection = con;
                                        cmd.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = tumbLot;

                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                                if (first == "Batch")
                                {
                                    btch = las;
                                }

                                else if (first == "Diameter")
                                {

                                }
                                else if (first == "Sampled")
                                {
                                    samp = Convert.ToInt32(las);
                                    var q = from row in db.PowerSegregationTables where row.RecievedQty == samp && row.TumblingNo == tumbLot select row;
                                    if (q.Count() == 0)
                                    {
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand();
                                        cmd.CommandText = "Update PowerSegregationTable set RecievedQty=@RecievedQty,TotalQty=@TotalQty where TumblingNo='" + tumbLot + "'";
                                        cmd.Connection = con;
                                        cmd.Parameters.Add("@RecievedQty", SqlDbType.Int).Value = las;
                                        cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = las;
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                                else if (first == "Passed")
                                {
                                    pass = Convert.ToInt32(las);
                                    var q = from row in db.PowerSegregationTables where row.AcceptedQty == pass && row.TumblingNo == tumbLot select row;
                                    if (q.Count() == 0)
                                    {
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand();
                                        cmd.CommandText = "Update PowerSegregationTable set AcceptedQty=@AcceptedQty where TumblingNo='" + tumbLot + "'";
                                        cmd.Connection = con;
                                        cmd.Parameters.Add("@AcceptedQty", SqlDbType.Int).Value = las;
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                                else if (first == "Failed")
                                {
                                    fail = Convert.ToInt32(las);

                                    DateTime dt = DateTime.Now;

                                    var q = from row in db.PowerSegregationTables where row.RejectedQty == fail && row.TumblingNo == tumbLot select row;
                                    if (q.Count() == 0)
                                    {
                                        con.Open();
                                        SqlCommand cmd = new SqlCommand();
                                        cmd.CommandText = "Update PowerSegregationTable set RejectedQty=@RejectedQty,Resolution=@Resolution,Date=@Date,Remarks=@Remarks where TumblingNo='" + tumbLot + "'";
                                        cmd.Connection = con;
                                        cmd.Parameters.Add("@RejectedQty", SqlDbType.Int).Value = las;
                                        cmd.Parameters.Add("@Resolution", SqlDbType.VarChar, 50).Value = "Good";
                                        cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dt;
                                        cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = "NIL";
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                                else if (first == "MTFrejectedLimit")
                                {
                                    MTF = Convert.ToDouble(las);
                                }

                                linecount++;
                                con.Close();
                            }

                            else if (linecount == 13)
                            {
                                linecount++;
                            }

                            else if (linecount > 13)
                            {
                                if (DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT300" || DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT200" || DropDownList1.Text == "SUPERPHOB" && mod == "AE-01" || DropDownList1.Text == "SUPRAPHOB INFOCUS" && mod == "SP INFO" || DropDownList1.Text == "SUPRAPHOB TORIC" || DropDownList1.Text == "SUPRAPHOB REGEN")
                                {
                                    string replace = Regex.Replace(line, @"\t|\n", " ");

                                    string wh = "\\s+";
                                    lines = Regex.Split(replace, wh);
                                    if (lines.Count() == 8)
                                    {

                                        if (DropDownList1.Text == "SUPRAPHOB INFOCUS" && mod == "SP INFO" || DropDownList1.Text == "SUPRAPHOB TORIC" || DropDownList1.Text == "SUPRAPHOB REGEN")
                                        {
                                            mtfno = lines[4];
                                        }
                                        else
                                        {
                                            mtfno = lines[6];
                                        }
                                        double mtnum = Convert.ToDouble(mtfno);


                                        if (mtnum >= 0.43)
                                        {

                                            datastore_Normal();
                                            linecount++;

                                            //var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
                                            mod = query.Single().Model;

                                            if (query.Count() > 0)
                                            {


                                                pouch_insertValues = pouch_insertValues + datastore_Normal();
                                            }
                                            linecount++;
                                        }
                                        else
                                        {
                                            PowerRejectMtf();
                                            linecount++;
                                        }


                                    }
                                    else
                                    {

                                        if (lines.Count() == 9)
                                        {
                                            // PowerReject();
                                        }
                                        linecount++;
                                    }

                                }
                                else if (DropDownList1.Text == "HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS" && mod == "SPNT300")
                                {

                                    string replace = Regex.Replace(line, @"\t|\n", " ");

                                    string wh = "\\s+";
                                    lines = Regex.Split(replace, wh);
                                    if (lines.Count() == 8 && lines[0] != "*Operator*")
                                    {

                                        mtfno = lines[6];
                                        double mtnum = Convert.ToDouble(mtfno);


                                        if (mtnum >= 0.43)
                                        {

                                            datastore_np();
                                            linecount++;



                                            //  var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
                                            if (query.Count() > 0)
                                            {
                                                mod = query.Single().Model;


                                                pouch_insertValues = pouch_insertValues + datastore_np();
                                            }
                                            linecount++;
                                        }
                                        else
                                        {
                                            PowerRejectMtf();
                                            linecount++;
                                        }


                                    }
                                    else
                                    {



                                        if (lines.Count() == 9)
                                        {

                                        }
                                        linecount++;
                                    }

                                }


                            }

                            // linecount++;


                        }
                    }
                }
                //else
                //{
                //    Messagebox("Please select Valid Brand_Name");
                //}

                if (pouch_insertValues == "")
                {
                    pouch_insertValues = "''";
                }
                else
                {
                    pouch_insertValues = pouch_insertValues.Remove(pouch_insertValues.Length - 1, 1);
                }

                con.Open();
                var checkSerial_dup = from pp in db2.POUCH_LABELs where pp.Lot_Prefix + pp.Lot_No == losrno select pp;

                var checklotpower_seg_dup = from lot in db.PowerSegregationChilds where lot.TumblingNo == tumbLot select lot;

                var checklotpouchlab_seg_dup = from pp in db2.POUCH_LABELs where pp.RefLot == tumbLot && pp.Lot_Prefix + pp.Lot_No == losrno select pp;

                int Serial_dup = checkSerial_dup.Count();
                int Power_dup = checklotpower_seg_dup.Count();
                int bothReflotSer_dup = checklotpouchlab_seg_dup.Count();

                if (Serial_dup == 0)

                {
                    if (Power_dup == 0)
                    {
                        if (bothReflotSer_dup == 0)
                        {

                            if (DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT300" || DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT200" || DropDownList1.Text == "SUPRAPHOB INFOCUS" && mod == "SP INFO")
                            {
                                //bulk insert data
                                sql_query = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,Power,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_no,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization,Sample_Taken,Type_sample," +
                                                   " BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,R_Power,rotlex_type,Label,RefLot,Status) VALUES " + pouch_insertValues;
                                LensmasterUpdate();
                                grview();

                            }
                            else if (DropDownList1.Text == "SUPRAPHOB TORIC" || DropDownList1.Text == "SUPRAPHOB REGEN")
                            {
                                sql_query = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,Power,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_no,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization,Sample_Taken,Type_sample," +
                                                 " BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,R_Power,rotlex_type,Label,RefLot,Status,Cylsize) VALUES " + pouch_insertValues;
                                LensmasterUpdate();
                                grview();

                            }

                            else if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                            {
                                sql_query = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,Power,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_no,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization,Sample_Taken,Type_sample," +
                                                  " BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,R_Power,rotlex_type,Label,RefLot,Status) VALUES " + pouch_insertValues;
                                LensmasterUpdate_Superphob();
                                grview3();
                            }
                            else if (DropDownList1.Text == "HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS" && mod == "SPNT300")
                            {
                                sql_query = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,Power,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_no,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization,Sample_Taken,Type_sample," +
                                             " BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,R_Power,rotlex_type,Label,RefLot,Status) VALUES " + pouch_insertValues;

                                LensmasterUpdate_NP();
                                grview1();

                            }

                        }
                        else
                        {
                            Messagebox("Tumbling Lot Number Already Exists in Pouch Label!!!");

                        }
                    }
                    else
                    {

                        Messagebox("Tumbling Lot Number Already Exists in Power Groupig !!!");

                    }
                }
                else
                {

                    Messagebox("Lot Serial Already in Pouch Table !!!");

                }
                Messagebox("Data Saved!!!");
                btn.Visible = true;
                con.Close();

            }
            catch (Exception ex)
            {
                Messagebox(ex.ToString());
            }
        }


        else if (Label14.Text == "ROTLEX")
        {
          
        

      if (droptyp.SelectedValue == "--Select--")

        {
            Messagebox("Choose the Type");
        }

        try
        {
            Update.Visible = false;
            Label7.Visible = false;
            Drop.Visible = false;
            btn.Visible = true;
            ImageButton4.Visible = false;
            Button1.Enabled = false;
            ImageButton1.Visible = true;


           // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
           // SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
           
            string fname = FileUpload1.FileName;
            string[] fnam1 = fname.Split('.');
            tumbLot = fnam1[0].ToString();
          
            var pouch_insertValues = string.Empty;
           



            StreamReader sr = new StreamReader(FileUpload1.FileContent);
            var linecount = 0;


            var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;

            if (query.Count() > 0)
            {

                mod = query.Single().Model;

                //string[] lines1 = new string[6];     
                while ((line = sr.ReadLine()) != null)
                {
                    string chk = line.Trim(new char[] { '\t' });
                    if (chk == "")
                    {
                    } //string[] tokens = line.Split(':');
                    else
                    {  //string last1 = tokens[tokens.Length - 1];
                        if (linecount < 16)
                        {
                            lines = line.Split(':');
                            string last = lines[lines.Length - 1];
                            string rpl = Regex.Replace(last, @"\s+|\t*", "");
                            char[] arr = new char[] { ' ', '\t', '/', '"', '*' };
                            last = rpl.Trim(arr);
                            string[] last1 = last.Split(',');
                            las = last1[0];
                            string first = lines[0];
                            string rplace = Regex.Replace(first, @"\s+|\t*", "");
                            char[] ar = new char[] { ' ', '\t', '/', '"', '*' };
                            first = rplace.Trim(ar);

                            if (first == "LOT")
                            {
                                losrno = las;
                                var r = from row in db.PowerSegregationTables where row.TumblingNo == tumbLot select row;
                                if (r.Count() > 0)
                                {

                                }
                                else
                                {
                                    con.Open();
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandText = "Insert into PowerSegregationTable (TumblingNo) values (@TumblingNo)";
                                    cmd.Connection = con;
                                    cmd.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = tumbLot;

                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                            if (first == "Batch")
                            {
                                btch = las;
                            }

                            else if (first == "Diameter")
                            {

                            }
                            else if (first == "Sampled*")
                            {
                                samp = Convert.ToInt32(las);
                                var q = from row in db.PowerSegregationTables where row.RecievedQty == samp && row.TumblingNo == tumbLot select row;
                                if (q.Count() == 0)
                                {
                                    con.Open();
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandText = "Update PowerSegregationTable set RecievedQty=@RecievedQty,TotalQty=@TotalQty where TumblingNo='" + tumbLot + "'";
                                    cmd.Connection = con;
                                    cmd.Parameters.Add("@RecievedQty", SqlDbType.Int).Value = las;
                                    cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = las;
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                            else if (first == "Passed")
                            {
                                pass = Convert.ToInt32(las);
                                var q = from row in db.PowerSegregationTables where row.AcceptedQty == pass && row.TumblingNo == tumbLot select row;
                                if (q.Count() == 0)
                                {
                                    con.Open();
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandText = "Update PowerSegregationTable set AcceptedQty=@AcceptedQty where TumblingNo='" + tumbLot + "'";
                                    cmd.Connection = con;
                                    cmd.Parameters.Add("@AcceptedQty", SqlDbType.Int).Value = las;
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }

                            else if (first == "Failed")
                            {
                                fail = Convert.ToInt32(las);

                                DateTime dt = DateTime.Now;

                                var q = from row in db.PowerSegregationTables where row.RejectedQty == fail && row.TumblingNo == tumbLot select row;
                                if (q.Count() == 0)
                                {
                                    con.Open();
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandText = "Update PowerSegregationTable set RejectedQty=@RejectedQty,Resolution=@Resolution,Date=@Date,Remarks=@Remarks where TumblingNo='" + tumbLot + "'";
                                    cmd.Connection = con;
                                    cmd.Parameters.Add("@RejectedQty", SqlDbType.Int).Value = las;
                                    cmd.Parameters.Add("@Resolution", SqlDbType.VarChar, 50).Value = "Good";
                                    cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dt;
                                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = "NIL";
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                            else if (first == "MTF rejected Limit")
                            {
                                MTF = Convert.ToDouble(las);
                            }

                            linecount++;
                            con.Close();
                        }

                        else if (linecount == 16)
                        {
                            linecount++;
                        }
                        else if (linecount > 16)
                        {
                            //  pass = Convert.ToInt32(las);
                            if (DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT300" || DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT200" || DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                            {
                                string replace = Regex.Replace(line, @"\t|\n", " ");

                                string wh = "\\s+";
                                lines = Regex.Split(replace, wh);
                                int xy = lines.Count();
                                if (xy == 8 && lines[0] != "*Operator*")
                                {

                                    mtfno = lines[6];
                                    double mtnum = Convert.ToDouble(mtfno);

                                    if (mtnum >= 0.43)
                                    {
                                        datastore_PreloadedWinPro();
                                        linecount++;

                                        mod = query.Single().Model;

                                        if (query.Count() > 0)
                                        {


                                            pouch_insertValues = pouch_insertValues + datastore_PreloadedWinPro();
                                        }
                                        linecount++;
                                    }
                                    else
                                    {
                                        PowerRejectMtf();
                                        linecount++;
                                    }

                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
            }
            else
            {
                   Messagebox("Bach allot Process Not Completed..");
                   return;
            }
              if (pouch_insertValues == "")
            {
                pouch_insertValues = "''";
            }
            else
            {
                pouch_insertValues = pouch_insertValues.Remove(pouch_insertValues.Length - 1, 1);
            }




              if (DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT300" || DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT200")
            {

                ReflotSer_dup = GetRefLotCount(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString, tumbLot);
                bothReflotSer_dup = GetLotCount(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString, losrno);
            }
            else if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
            {
                ReflotSer_dup = GetRefLotCount(ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString, tumbLot);
                bothReflotSer_dup = GetLotCount(ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString, losrno);
            }
            else if (DropDownList1.Text == "HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS" && mod == "SPNT300")
            {
                ReflotSer_dup = GetRefLotCount(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString, tumbLot);
                bothReflotSer_dup = GetLotCount(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString, losrno);
            }



            var checklotpower_seg_dup = from lot in db.PowerSegregationChilds where lot.TumblingNo == tumbLot select lot;
            int Power_dup = checklotpower_seg_dup.Count();


            if (ReflotSer_dup == 0)
            {
                if (Power_dup == 0)
                {
                    if (bothReflotSer_dup == 0)
                    {
                        //bulk insert data
                        if (DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT300" || DropDownList1.Text == "SUPRAPHOB" && mod == "SPNT200")
                        {

                            sql_query = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,Power,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_no,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization,Sample_Taken,Type_sample," +
                                               " BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,R_Power,rotlex_type,Label,RefLot,Status) VALUES " + pouch_insertValues;
                            LensmasterUpdate();
                            grview();

                        }
                        else if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                        {
                            sql_query = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,Power,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_no,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization,Sample_Taken,Type_sample," +
                                              " BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,R_Power,rotlex_type,Label,RefLot,Status) VALUES " + pouch_insertValues;
                            LensmasterUpdate_Superphob();
                            grview3();
                        }
                        else if (DropDownList1.Text == "HYDROPHOBIC FOLDABLE SINGLE PIECE INTRAOCULAR LENS" && mod == "SPNT300")
                        {
                            sql_query = "insert into POUCH_LABEL (Brand_Name,Model_Name,Reference_Name,Power,Qty,St_SrNo,St_EnNo,Lot_Prefix,Lot_no,Lot_SrNo,Mfd_Month,Mfd_Year,Exp_Month,Exp_Year,Sterilization,Sample_Taken,Type_sample," +
                                         " BPL_Taken,Box_Packing,Dc_Packing,Created_By,Created_Date,Modified_By,Modified_Date,Sterilization_Reject,Qty_1,Type,Sterilization_After,Box_Reject,Print_Name,R_Power,rotlex_type,Label,RefLot,Status) VALUES " + pouch_insertValues;

                            LensmasterUpdate_NP();
                            grview1();

                        }

                    }
                    else
                    {
                        Messagebox("Packing Lot Number Already Exists in Pouch Label!!!");

                    }
                }
                else
                {

                    Messagebox("Solution Lot Number Already Exists in Power Groupig !!!");

                }
            }
            else
            {

                Messagebox("Solution Lot Number Already Exists in Pouch Label !!!");

            }
           
            Messagebox("Data Saved!!!");
            btn.Visible = true;
            sr.Close();
           
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
   
    
        }
    }
    public int GetLotCount(string connectionString, string losrno)
    {
        int count = 0;

        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
        
            using (SqlCommand cmd = new SqlCommand())
            {
               
                cmd.CommandText = "SELECT     COUNT(*) AS RowsCount FROM         POUCH_LABEL WHERE Lot_Prefix + Lot_No = @losrno";
                cmd.Connection = connection;

                
                cmd.Parameters.AddWithValue("@losrno", losrno);

              
                connection.Open();

               
                count = (int)cmd.ExecuteScalar();
            }
        }

        return count;
    }
    public int GetRefLotCount(string connectionString, string tumbLot)
    {
        int count = 0;


        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            using (SqlCommand cmd = new SqlCommand())
            {

                cmd.CommandText = "SELECT     COUNT(*) AS RowsCount FROM         POUCH_LABEL WHERE reflot = @tumbLot";
                cmd.Connection = connection;


                cmd.Parameters.AddWithValue("@tumbLot", tumbLot);


                connection.Open();


                count = (int)cmd.ExecuteScalar();
            }
        }

        return count;
    }


    protected void LensmasterUpdate()
    {
     
        using (SqlCommand cmd = new SqlCommand(sql_query, con1))
        {
            if (con1.State == ConnectionState.Open)
            {
                con1.Close();
            }
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
        }

        //bulk update 
        string sql_query1 = "UPDATE  POUCH_LABEL SET GS_Code = (SELECT DISTINCT GS_Code  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power) and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "')  ,Reference_name = (SELECT DISTINCT Reference_name  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power) and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),Optic = (SELECT DISTINCT Optic  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),Length = (SELECT DISTINCT Length  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "')," +
                          "Lot_Unit = (SELECT DISTINCT Lot_Unit  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),A_Constant = (SELECT DISTINCT A_Constant  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "') ,Type_GS_Code = (SELECT DISTINCT Type_GS_Code  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "') where reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'  ";



        using (SqlCommand cmd = new SqlCommand(sql_query1, con1))
        {
            if (con1.State == ConnectionState.Open)
            {
                con1.Close();
            }
            con1.Open();
            cmd.ExecuteNonQuery();
            con1.Close();
        }

        //power segregation child updation

        string query12 = @"
                            SELECT RefLot, Power, SUM(Qty_1) AS qty
                            FROM POUCH_LABEL
                            WHERE RefLot ='" + tumbLot + "' GROUP BY RefLot, Power ORDER BY RefLot, Power";

        DataTable dataTable = new DataTable();
        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query12, con1))
        {
            if (con1.State == ConnectionState.Open)
            {
                con1.Close();
            }
            dataAdapter.Fill(dataTable);
            con1.Open();

            con1.Close();
        }

        foreach (DataRow row in dataTable.Rows)
        {
            string insertQuery = @"
                                        INSERT INTO PowerSegregationChild (TumblingNo, Power, qty,GlassyRecordRef)
                                        VALUES (@TumblingNo, @Power, @qty,@GlassyRecordRef)";

            using (SqlCommand insertCommand = new SqlCommand(insertQuery, con))
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                insertCommand.Parameters.AddWithValue("@TumblingNo", row["RefLot"]);
                insertCommand.Parameters.AddWithValue("@Power", row["Power"]);
                insertCommand.Parameters.AddWithValue("@qty", row["qty"]);
                insertCommand.Parameters.AddWithValue("@GlassyRecordRef", "GR_" + row["Power"]);

                con.Open();
                // Execute the insert command
                insertCommand.ExecuteNonQuery();


                con.Close();
            }
        }
      
    }
    protected void LensmasterUpdate_NP()
    {

        using (SqlCommand cmd = new SqlCommand(sql_query, con2))
        {
            if (con2.State == ConnectionState.Open)
            {
                con2.Close();
            }
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
        }

        //bulk update 
        string sql_query1 = "UPDATE  POUCH_LABEL SET GS_Code = (SELECT DISTINCT GS_Code  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power) and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "')  ,Reference_name = (SELECT DISTINCT Reference_name  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power) and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),Optic = (SELECT DISTINCT Optic  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),Length = (SELECT DISTINCT Length  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "')," +
                          "Lot_Unit = (SELECT DISTINCT Lot_Unit  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),A_Constant = (SELECT DISTINCT A_Constant  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "') ,Type_GS_Code = (SELECT DISTINCT Type_GS_Code  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "') where reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'  ";



        using (SqlCommand cmd = new SqlCommand(sql_query1, con2))
        {
            if (con2.State == ConnectionState.Open)
            {
                con2.Close();
            }
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
        }

        //power segregation child updation

        string query12 = @"
                            SELECT RefLot, Power, SUM(Qty_1) AS qty
                            FROM POUCH_LABEL
                            WHERE RefLot ='" + tumbLot + "' GROUP BY RefLot, Power ORDER BY RefLot, Power";

        DataTable dataTable = new DataTable();
        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query12, con2))
        {
            if (con2.State == ConnectionState.Open)
            {
                con2.Close();
            }
            dataAdapter.Fill(dataTable);
            con2.Open();

            con2.Close();
        }

        foreach (DataRow row in dataTable.Rows)
        {
            string insertQuery = @"
                                        INSERT INTO PowerSegregationChild (TumblingNo, Power, qty,GlassyRecordRef)
                                        VALUES (@TumblingNo, @Power, @qty,@GlassyRecordRef)";

            using (SqlCommand insertCommand = new SqlCommand(insertQuery, con))
            {
                con.Open();

                insertCommand.Parameters.AddWithValue("@TumblingNo", row["RefLot"]);
                insertCommand.Parameters.AddWithValue("@Power", row["Power"]);
                insertCommand.Parameters.AddWithValue("@qty", row["qty"]);
                insertCommand.Parameters.AddWithValue("@GlassyRecordRef", "GR_" + row["Power"]);

                // Execute the insert command
                insertCommand.ExecuteNonQuery();


                con.Close();
            }
        }
       
    }

    protected void LensmasterUpdate_Superphob()
    {

        using (SqlCommand cmd = new SqlCommand(sql_query, con3))
        {
            if (con3.State == ConnectionState.Open)
            {
                con3.Close();
            }
            con3.Open();
            cmd.ExecuteNonQuery();
            con3.Close();
        }

        //bulk update 
        string sql_query1 = "UPDATE  POUCH_LABEL SET GS_Code = (SELECT DISTINCT GS_Code  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power) and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "')  ,Reference_name = (SELECT DISTINCT Reference_name  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power) and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),Optic = (SELECT DISTINCT Optic  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),Length = (SELECT DISTINCT Length  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "')," +
                          "Lot_Unit = (SELECT DISTINCT Lot_Unit  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'),A_Constant = (SELECT DISTINCT A_Constant  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "') ,Type_GS_Code = (SELECT DISTINCT Type_GS_Code  FROM  LENS_MASTER  WHERE  (Model_Name = POUCH_LABEL.Model_Name) AND (Power = POUCH_LABEL.Power)  and reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "') where reflot='" + tumbLot + "' and  Lot_prefix+lot_no='" + losrno + "'  ";



        using (SqlCommand cmd = new SqlCommand(sql_query1, con3))
        {
            if (con3.State == ConnectionState.Open)
            {
                con3.Close();
            }
            con3.Open();
            cmd.ExecuteNonQuery();
            con3.Close();
        }

        //power segregation child updation

        string query12 = @"
                            SELECT RefLot, Power, SUM(Qty_1) AS qty
                            FROM POUCH_LABEL
                            WHERE RefLot ='" + tumbLot + "' GROUP BY RefLot, Power ORDER BY RefLot, Power";

        DataTable dataTable = new DataTable();
        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query12, con3))
        {
            if (con3.State == ConnectionState.Open)
            {
                con3.Close();
            }
            dataAdapter.Fill(dataTable);
            con3.Open();

            con3.Close();
        }

        foreach (DataRow row in dataTable.Rows)
        {
            string insertQuery = @"
                                        INSERT INTO PowerSegregationChild (TumblingNo, Power, qty,GlassyRecordRef)
                                        VALUES (@TumblingNo, @Power, @qty,@GlassyRecordRef)";

            using (SqlCommand insertCommand = new SqlCommand(insertQuery, con))
            {
                con.Open();

                insertCommand.Parameters.AddWithValue("@TumblingNo", row["RefLot"]);
                insertCommand.Parameters.AddWithValue("@Power", row["Power"]);
                insertCommand.Parameters.AddWithValue("@qty", row["qty"]);
                insertCommand.Parameters.AddWithValue("@GlassyRecordRef", "GR_" + row["Power"]);

                // Execute the insert command
                insertCommand.ExecuteNonQuery();


                con.Close();
            }
        }
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Button2.Enabled = true;
        Button6.Enabled = true;
        Win_btn.Enabled = true;

        List<string> brandNames = new List<string>();
        // Fetch data from first data source
        string strconn1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
        using (SqlConnection connection1 = new SqlConnection(strconn1))
        {
            string query1 = "Select distinct Type from Lot_Type";
            SqlCommand cmd1 = new SqlCommand(query1, connection1);
            connection1.Open();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string brandName = reader1["Type"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader1.Close();
        }

        // Fetch data from second data source
        string strconn2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
        using (SqlConnection connection2 = new SqlConnection(strconn2))
        {
            string query2 = "Select distinct Type from Lot_Type";
            SqlCommand cmd2 = new SqlCommand(query2, connection2);
            connection2.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string brandName = reader2["Type"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader2.Close();
        }

        // Fetch data from third data source
        string strconn3 = ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString;
        using (SqlConnection connection3 = new SqlConnection(strconn3))
        {
            string query3 = "Select distinct Type from Lot_Type";
            SqlCommand cmd3 = new SqlCommand(query3, connection3);
            connection3.Open();
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string brandName = reader3["Type"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader3.Close();
        }

        // Bind combined list to DropDownList
        droptyp.Items.Clear();
        droptyp.Items.Insert(0, new ListItem("--Select--", "0"));
        foreach (string brandName in brandNames)
        {
            droptyp.Items.Add(new ListItem(brandName, brandName));
        }
    }
    protected void BindGrid()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + DropDownList2.SelectedValue + "' group by Power,Status", con1);
        GridView1.DataSource = cmd.ExecuteReader();
        GridView1.DataBind();
        con1.Close();
    }
    protected void Gridbind()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + DropDownList5.SelectedValue + "' group by Power,Status", con1);
        GridView3.DataSource = cmd.ExecuteReader();
        GridView3.DataBind();
        con1.Close();
    }
    protected void Gridviewbind()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + DropDownList4.SelectedValue + "' group by Power", con1);
        GridView7.DataSource = cmd.ExecuteReader();
        GridView7.DataBind();
        con1.Close();
    }
    protected void Gridviewbind1()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
        con1.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + DropDownList7.SelectedValue + "' group by Power", con1);
        GridView8.DataSource = cmd.ExecuteReader();
        GridView8.DataBind();
        con1.Close();
    }
    protected void grview1()
    {
        SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
        con2.Open();
        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + tumbLot + "' group by Power", con2);
        GridView5.DataSource = cmd.ExecuteReader();
        GridView5.DataBind();
        con2.Close();
    }
    protected void grview()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
        con1.Open();

        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + tumbLot + "' group by Power", con1);
        GridView5.DataSource = cmd.ExecuteReader();
        GridView5.DataBind();
        con1.Close();

    }
    protected void grview3()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString);
        con1.Open();

        SqlCommand cmd = new SqlCommand("select Max(Brand_Name) as Brand_Name,Max(Model_Name) as Model_Name,Max(Power) as Power,Count(*) as Qty,Max(RefLot) as RefLot,Max(Status) as Status from POUCH_LABEL where RefLot='" + tumbLot + "' group by Power", con1);
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
                string con1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
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
                SqlDataReader dr1 = cmd.ExecuteReader();
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
                    bulkdata.WriteToServer(dr1);
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
                string con2 = ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString;
                SqlConnection delpow = new SqlConnection(con2);
                SqlCommand cmdpw = new SqlCommand();
                cmdpw.CommandText = "Delete from PowerSegregationChild where TumblingNo='" + lblref.Text + "' and Power='" + Convert.ToDecimal(lblpow.Text) + "'";
                cmdpw.Connection = delpow;
                delpow.Open();
                cmdpw.ExecuteNonQuery();
                delpow.Close();
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
        tumbno = (TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox1");
        pow = (TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox2");
        qty = (TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox3");
        txtglass = (TextBox)GridView2.Rows[e.RowIndex].FindControl("TextBox4");
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
        Win_btn.Visible = false;
        Buttons.Visible = false;
        Bind_Brand_Name();
        Label14.Text = btnaps.Text;

    }



    protected void btn_win_Click(object sender, EventArgs e)
    {

        Drop.Visible = true;
        Win_btn.Visible = false;
        Button2.Visible = true;
        Buttons.Visible = false;
        Bind_Brand_Name();
        Label14.Text = btn_win.Text;
    }
    protected void btnmoria_Click(object sender, EventArgs e)
    {
        Buttons.Visible = false;
        Drop1.Visible = true;
        Win_btn.Visible = true;
        Bind_Brand_Name();
     

    }
    protected void Bind_Brand_Name()
    {
       


        List<string> brandNames = new List<string>();
        // Fetch data from first data source
        string strconn1 = ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString;
        using (SqlConnection connection1 = new SqlConnection(strconn1))
        {
            string query1 = "Select distinct Brand_Name from LENS_MASTER";
            SqlCommand cmd1 = new SqlCommand(query1, connection1);
            connection1.Open();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                string brandName = reader1["Brand_Name"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader1.Close();
        }

        // Fetch data from second data source
        string strconn2 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
        using (SqlConnection connection2 = new SqlConnection(strconn2))
        {
            string query2 = "Select distinct Brand_Name from LENS_MASTER";
            SqlCommand cmd2 = new SqlCommand(query2, connection2);
            connection2.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string brandName = reader2["Brand_Name"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader2.Close();
        }

        // Fetch data from third data source
        string strconn3 = ConfigurationManager.ConnectionStrings["APS_SuperphobConnectionString"].ConnectionString;
        using (SqlConnection connection3 = new SqlConnection(strconn3))
        {
            string query3 = "Select distinct Brand_Name from LENS_MASTER";
            SqlCommand cmd3 = new SqlCommand(query3, connection3);
            connection3.Open();
            SqlDataReader reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                string brandName = reader3["Brand_Name"].ToString();
                if (!brandNames.Contains(brandName))
                {
                    brandNames.Add(brandName);
                }
            }
            reader3.Close();
        }

        // Bind combined list to DropDownList
        DropDownList1.Items.Clear();
        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
        foreach (string brandName in brandNames)
        {
            DropDownList1.Items.Add(new ListItem(brandName, brandName));
        }

    }
   
  
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
    
    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
           
            Update1.Visible = false;
            Label8.Visible = false;
            Drop1.Visible = false;
            Button9.Visible = false;
            btn1.Visible = true;
            Button12.Enabled = false;
            Button10.Visible = true;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PHOBICConnectionString"].ConnectionString);
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
            //con.Open();
            //con1.Open();
            string fname = FileUpload2.FileName;
            string[] fnam1 = fname.Split('.');
            tumbLot = fnam1[0].ToString();
            StreamReader sr = new StreamReader(FileUpload2.FileContent);
            var linecount = 0;
               
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
                    if (linecount < 14)
                    {
                        lines = line.Split(':');
                        string last = lines[lines.Length - 1];
                        string rpl = Regex.Replace(last, @"\s+|\t", "");
                        char[] arr = new char[] { ' ', '\t', '/', '"' };
                        last = rpl.Trim(arr);
                        string[] last1 = last.Split(',');
                        string las = last1[0];
                        string first = lines[0];
                        string rplace = Regex.Replace(first, @"\s+|\t", "");
                        char[] ar = new char[] { ' ', '\t', '/', '"' };
                        first = rplace.Trim(ar);

                        if (first == "LOT")
                        {
                            losrno = las;
                            var r = from row in db.PowerSegregationTables where row.TumblingNo == tumbLot select row;
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
                                cmd.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = tumbLot;
                                //cmd.Parameters.Add("@Power", SqlDbType.VarChar, 50).Value = last;
                                //cmd.Parameters.Add("@Batch", SqlDbType.VarChar, 50).Value = last;
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        if (first == "Batch")
                        {
                            btch = las;
                        }

                        else if (first == "Diameter")
                        {
                            //dia = Convert.ToDecimal(last);
                        }
                        else if (first == "Sampled")
                        {
                            samp = Convert.ToInt32(las);
                            var q = from row in db.PowerSegregationTables where row.RecievedQty == samp && row.TumblingNo == tumbLot select row;
                            if (q.Count() == 0)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "Update PowerSegregationTable set RecievedQty=@RecievedQty,TotalQty=@TotalQty where TumblingNo='" + tumbLot + "'";
                                cmd.Connection = con;
                                cmd.Parameters.Add("@RecievedQty", SqlDbType.Int).Value = las;
                                cmd.Parameters.Add("@TotalQty", SqlDbType.Int).Value = las;
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        else if (first == "Passed")
                        {
                            pass = Convert.ToInt32(last);
                            var q = from row in db.PowerSegregationTables where row.AcceptedQty == pass && row.TumblingNo == tumbLot select row;
                            if (q.Count() == 0)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "Update PowerSegregationTable set AcceptedQty=@AcceptedQty where TumblingNo='" + tumbLot + "'";
                                cmd.Connection = con;
                                cmd.Parameters.Add("@AcceptedQty", SqlDbType.Int).Value = las;
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        else if (first == "Failed")
                        {
                            fail = Convert.ToInt32(last);
                            DateTime dt = System.DateTime.Now;
                            var q = from row in db.PowerSegregationTables where row.RejectedQty == fail && row.TumblingNo == tumbLot select row;
                            if (q.Count() == 0)
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "Update PowerSegregationTable set RejectedQty=@RejectedQty,Resolution=@Resolution,Date=@Date,Remarks=@Remarks where TumblingNo='" + tumbLot + "'";
                                cmd.Connection = con;
                                cmd.Parameters.Add("@RejectedQty", SqlDbType.Int).Value = las;
                                cmd.Parameters.Add("@Resolution", SqlDbType.VarChar, 50).Value = "Good";
                                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = dt;
                                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 50).Value = "NIL";
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

                    else if (linecount == 14)
                    {
                        //string replace = Regex.Replace(line, @"\t|\n", " ");
                        //string wh = "\\s+";
                        //lines = Regex.Split(replace, wh);
                        //MTFQual = lines[6];
                        linecount++;
                    }
                    else if (linecount > 14)
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

                            //if (MTFQual == "MTF")
                            //{
                            if (mtnum >= 0.50)
                            {
                                datastoremoria();
                                linecount++;
                            }
                            else
                            {
                                PowerRejectMtfMoria();
                                linecount++;
                                
                            }
                            //}
                            //else if (MTFQual == "Quality")
                            //{
                            //    if (mtnum >= 6.00)
                            //    {
                            //        datastoremoria();
                            //        linecount++;
                            //    }
                            //    else
                            //    {
                            //        PowerRejectMtfMoria();
                            //        linecount++;
                            //    }
                            //}
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
            btn1.Visible = true;
            sr.Close();
            //File.WriteAllText("d:/file1.txt", string.Empty);
            //con.Close();
            //con1.Close();
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
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
                string con1 = ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString;
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
                SqlDataReader dr1 = cmd.ExecuteReader();
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
                    bulkdata.WriteToServer(dr1);
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
                string con2 = ConfigurationManager.ConnectionStrings["IOLConnectionString"].ConnectionString;
                SqlConnection delpow = new SqlConnection(con2);
                SqlCommand cmdpw = new SqlCommand();
                cmdpw.CommandText = "Delete from PowerSegregationChild where TumblingNo='" + lblref.Text + "' and Power='" + Convert.ToDecimal(lblpow.Text) + "'";
                cmdpw.Connection = delpow;
                delpow.Open();
                cmdpw.ExecuteNonQuery();
                delpow.Close();


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
    protected string datastore_np()
    {
        var insertVal = String.Empty;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
        try
        {

            con1.Open();
            // Check Serial Already Done or not
            s = lines[2];
            // s = lines[1];
            s1 = s.Replace(losrno, "");

            //string str = "Select count(*) from POUCH_LABEL where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' ";
            //SqlCommand com = new SqlCommand(str, con1);
            int counts = 0;
            //con1.Close();

            if (counts == 0)
            {

                int count = 0;
                string lab = string.Empty;
                foreach (char c in s1)
                {
                    count++;
                }
                if (count == 1)
                {
                    lab = "00" + s1;
                }
                else if (count == 2)
                {
                    lab = "0" + s1;
                }
                else if (count == 3)
                {
                    lab = s1;
                }
                int totlab_count = count;


                DateTime dt = System.DateTime.Today;
                SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AOD'", con1);
                SqlDataReader dar = recm.ExecuteReader();
                if (dar.Read())
                {

                    try
                    {
                        totexp1 = Convert.ToInt32(dar["Tot_Exp"]);


                        string initialString = losrno;
                        System.Text.RegularExpressions.Regex nonNumericCharacters = new System.Text.RegularExpressions.Regex(@"\D");
                        string numericOnlyString = nonNumericCharacters.Replace(initialString, String.Empty);
                        stryear = System.DateTime.Now.ToString("yy");
                        strmonth = System.DateTime.Now.ToString("MM");

                        lotno = losrno.Substring(losrno.Length - 4);
                        int num = losrno.Length - lotno.Length;
                        prefix = losrno.Substring(0, num);

                        //Expiry Calculation
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

                        //Insert bulk data
                        insertVal = "('" + DropDownList1.SelectedValue + "','" + mod + "','" + refname + "','" + lines[7] + "','" + pass + "','" + lab + "','" + pass + "','"
                        + prefix + "','" + lotno + "','" + losrno + " " + lab + "','" + strmanfmonth + "','" + strmanfyear + "','" + expmonth + "','" + expyear + "',0,0,'NO' ,0,0,0,'APS','"
                        + dt + "','APS','" + dt + "',0,1,'" + droptyp.SelectedValue + "',0,0,'" + DropDownList1.SelectedValue + "','" + lines[5] + "' ,'" + btch + "','"
                        + s1 + "','" + tumbLot + "','Not Labelled'),";

                    }
                    catch (Exception ex)
                    {

                        Messagebox(ex.ToString());
                        return String.Empty;
                    }
                }

                con1.Close();


            }

            else
            {
                Messagebox("Serial Number Already Saved....");
            }


            return insertVal;
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
            return String.Empty;
        }





    }
    protected string datastore_Normal()
    {
        var insertVal = String.Empty;
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
        try
        {

            con1.Open();
            if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
            {
                con3.Open();
            }
            // Check Serial Already Done or not
            s = lines[2];
            // s = lines[1];
            s1 = s.Replace(losrno, "");

            //string str = "Select count(*) from POUCH_LABEL where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' ";
            //SqlCommand com = new SqlCommand(str, con1);
            int counts = 0;
            //con1.Close();

            if (counts == 0)
            {
                int count = 0;
                string lab = string.Empty;
                foreach (char c in s1)
                {
                    count++;
                }
                if (count == 1)
                {
                    lab = "00" + s1;
                }
                else if (count == 2)
                {
                    lab = "0" + s1;
                }
                else if (count == 3)
                {
                    lab = s1;

                }
                int totlab_count = count;

                SqlCommand recm;
                DateTime dt = System.DateTime.Today;
                if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                {
                   recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AI'", con3);
                }
                else if (DropDownList1.Text == "SUPRAPHOB INFOCUS" && mod == "SP INFO" || DropDownList1.Text == "SUPRAPHOB TORIC" || DropDownList1.Text == "SUPRAPHOB REGEN")
                {
                    recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[6] + "' AND Type_GS_Code='AOD'", con1);
                }
                else
                {
                    recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AOD'", con1);
                }
                SqlDataReader dar = recm.ExecuteReader();
                if (dar.Read())
                {
                    try
                        {
                    totexp1 = Convert.ToInt32(dar["Tot_Exp"]);

                    string initialString = losrno;
                    System.Text.RegularExpressions.Regex nonNumericCharacters = new System.Text.RegularExpressions.Regex(@"\D");
                    string numericOnlyString = nonNumericCharacters.Replace(initialString, String.Empty);

                    stryear = System.DateTime.Now.ToString("yy");
                    strmonth = System.DateTime.Now.ToString("MM");




                    if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                    {
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


                            prefix = losrno.Substring(0, 3);

                            lotno = losrno.Substring(losrno.Length - 2);



                        }
                        else if (i == 2)
                        {

                            prefix = losrno.Substring(0, 4);
                            lotno = losrno.Substring(4, 2);
                        }
                        else
                        {

                            prefix = losrno.Substring(0, 4);
                            lotno = losrno.Substring(4, 2);


                        }

                    }
                    else
                    {
                        lotno = losrno.Substring(losrno.Length - 4);
                        int num = losrno.Length - lotno.Length;
                        prefix = losrno.Substring(0, num);

                    }
                //Expiry Calculation

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

                    if (DropDownList1.Text == "SUPRAPHOB INFOCUS" && mod == "SP INFO" )
                    {
                        insertVal = "('" + DropDownList1.SelectedValue + "','" + mod + "','" + refname + "','" + lines[6] + "','" + pass + "','" + lab + "','" + pass + "','"
                          + prefix + "','" + lotno + "','" + losrno + " " + lab + "','" + strmanfmonth + "','" + strmanfyear + "','" + expmonth + "','" + expyear + "',0,0,'NO' ,0,0,0,'APS','"
                          + dt + "','APS','" + dt + "',0,1,'" + droptyp.SelectedValue + "',0,0,'" + DropDownList1.SelectedValue + "','" + lines[5] + "' ,'" + btch + "','"
                          + s1 + "','" + tumbLot + "','Not Labelled'),";
                    }
                    else if (DropDownList1.Text == "SUPRAPHOB TORIC" || DropDownList1.Text == "SUPRAPHOB REGEN")
                    {
                        insertVal = "('" + DropDownList1.SelectedValue + "','" + mod + "','" + refname + "','" + lines[6] + "','" + pass + "','" + lab + "','" + pass + "','"
                         + prefix + "','" + lotno + "','" + losrno + " " + lab + "','" + strmanfmonth + "','" + strmanfyear + "','" + expmonth + "','" + expyear + "',0,0,'NO' ,0,0,0,'APS','"
                         + dt + "','APS','" + dt + "',0,1,'" + droptyp.SelectedValue + "',0,0,'" + DropDownList1.SelectedValue + "','" + lines[5] + "' ,'" + btch + "','"
                         + s1 + "','" + tumbLot + "','Not Labelled','" + lines[7] + "'),";
                    }
                    else
                    {
                        insertVal = "('" + DropDownList1.SelectedValue + "','" + mod + "','" + refname + "','" + lines[7] + "','" + pass + "','" + lab + "','" + pass + "','"
                         + prefix + "','" + lotno + "','" + losrno + " " + lab + "','" + strmanfmonth + "','" + strmanfyear + "','" + expmonth + "','" + expyear + "',0,0,'NO' ,0,0,0,'APS','"
                         + dt + "','APS','" + dt + "',0,1,'" + droptyp.SelectedValue + "',0,0,'" + DropDownList1.SelectedValue + "','" + lines[5] + "' ,'" + btch + "','"
                         + s1 + "','" + tumbLot + "','Not Labelled'),";
                    }
                        }
                    catch (Exception ex)
                    {

                        Messagebox(ex.ToString());
                        return String.Empty;
                    }
                }
                //Insert bulk data

               

                // grview();
                if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                {
                    con3.Close();
                }
                con1.Close();
            }

            else
            {
                Messagebox("Serial Number Already Saved....");
            }


            return insertVal;
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
            return String.Empty;
        }
    }
    protected void datastore()
     {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
        try
        {
            s = lines[2];
            s1 = s.Replace(losrno, ""); 
            string mod = string.Empty, bat = string.Empty;
            con1.Open();
            string str = "Select count(*) from POUCH_LABEL where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' AND Type='AOD'";
            SqlCommand com = new SqlCommand(str, con1);
            int counts = Convert.ToInt32(com.ExecuteScalar());
            con1.Close();
            //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
            //var query = from model in db.MattTumblingLens where model.TumblingLotNo == tumbLot select model;
            //var query2 = from model1 in db.RemattTumblingLens where model1.RetumblingRef1 == tumbLot || model1.RetumblingRef2 == tumbLot || model1.RetumblingRef3 == tumbLot select model1;
            //if (query.Count() > 0)
            //{
            //    var query1 = from modl in db.BatchAllots where modl.LotNo == query.Take(1).Single().LensCutLot select modl;
            //    mod = query1.Single().ModelNo;
            //    bat = query1.Single().BatchNo;
            //}
            //else if (query2.Count() > 0)
            //{
            //    string tumblott = query2.Single().TumblingLotNo.ToString();
            //    var qu1 = from x2 in db.MattTumblingLens where x2.TumblingLotNo == tumblott select x2;
            //    if (qu1.Count() > 0)
            //    {
            //        var qu2 = from x4 in db.BatchAllots where x4.LotNo == qu1.Take(1).Single().LensCutLot select x4;
            //        mod = qu2.Single().ModelNo;
            //        bat = qu2.Single().BatchNo;
            //    }
            //}


            var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
            if (query.Count() > 0)
            {
                mod = query.Single().Model;

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
                    //string s = lines[2];
                    //string s1 = s.Replace(losrno, "");                    
                    int count = 0;
                    string lab = string.Empty;
                    foreach (char c in s1)



                    {
                        count++;
                    }

                    if (count == 1)

                    {
                        lab = "00" + s1;
                    }

                    else if (count == 2)

                    {
                        lab = "0" + s1;
                    }
                                           
                    else if (count == 3)

                    {
                        lab = s1;
                    }


                    
                    //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;

                    
                    
                    SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[6] + "' AND Type_GS_Code='AOD'", con1);
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

                        con1.Close();
                        con1.Open();
                        DateTime dt = System.DateTime.Now;
                        string initialString = losrno;
                        System.Text.RegularExpressions.Regex nonNumericCharacters = new System.Text.RegularExpressions.Regex(@"\D");
                        string numericOnlyString = nonNumericCharacters.Replace(initialString, String.Empty);
                        //stryear = numericOnlyString.Substring(0, 2);
                        //strmonth = numericOnlyString.Substring(2, 2);
                        stryear = System.DateTime.Now.ToString("yy");
                        strmonth = System.DateTime.Now.ToString("MM");

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
                            lotno = losrno.Substring(losrno.Length - 4);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);
                        }
                        else if (i == 2)
                        {
                            lotno = losrno.Substring(losrno.Length - 4);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);
                        }
                        else
                        {
                            lotno = losrno.Substring(losrno.Length - 4);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);

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
                        cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[6];
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
                        //cmd.Parameters.Add("@Lot_SrNo", SqlDbType.NVarChar, 50).Value = losrno +  lab;
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
                        cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = droptyp.SelectedValue;
                        cmd.Parameters.Add("@Sterilization_After", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@Box_Reject", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@Print_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
                        cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
                        //cmd.Parameters.Add("@Cylsize", SqlDbType.NVarChar, 50).Value = lines[14];
                        cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
                        cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = s1;
                        cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = tumbLot;
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = "Not Labelled";
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "Update POUCH_LABEL set St_EnNo=@St_EnNo,Qty=@Qty where RefLot='" + tumbLot + "'";
                        cmd1.Connection = con1;
                        cmd1.Parameters.Add("@St_EnNo", SqlDbType.VarChar, 50).Value = endsrno + 1;
                        cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = endsrno + 1;
                        cmd1.ExecuteNonQuery();
                        grview();
                        con1.Close();
                        con.Close();
                        con.Open();
                        SqlCommand sm = new SqlCommand();
                        sm.CommandText = "Update PowerSegregationTable set InspectedBy=@InspectedBy where TumblingNo='" + tumbLot + "'";
                        sm.Connection = con;
                        sm.Parameters.Add("@InspectedBy", SqlDbType.VarChar, 50).Value = lines[1];
                        sm.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlCommand cm = new SqlCommand("Select Qty from PowerSegregationChild where TumblingNo='" + tumbLot + "' and Power='" + lines[6] + "'", con);
                        SqlDataReader dr = cm.ExecuteReader();
                        int quantity = 0;
                        if (dr.Read())
                        {
                            quantity = Convert.ToInt32(dr["Qty"]);
                            con.Close();
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand();
                            //int quant = Convert.ToInt32(pr.First().Qty);
                            cmd2.CommandText = "Update PowerSegregationChild set Qty=@Qty where TumblingNo='" + tumbLot + "' and Power='" + lines[6] + "'";
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
                            cmd2.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = tumbLot;
                            cmd2.Parameters.Add("@Power", SqlDbType.Decimal).Value =(lines[6]);
                            cmd2.Parameters.Add("@Qty", SqlDbType.Int).Value = quant1 + 1;
                            cmd2.Parameters.Add("@GlassyRecordRef", SqlDbType.VarChar, 50).Value = "GR" + s1;
                            cmd2.ExecuteNonQuery();


                        }
                        endsrno = Convert.ToInt32(lines[2]);
                        con.Close();
                        //}
                    }
                    else
                    {
                        Messagebox("Choose Valid Brand Name");
                    }
                }
                else
                {
                    Messagebox("Data Already Saved!!!");
                    Drop.Visible = true;
                    btn.Visible = false;
                }
            }
            else
            {
                Messagebox("Before Process Might not be Completed");
            }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
    }
    protected void datastore1()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
        try
        {
            s = lines[2];
            s1 = s.Replace(losrno, "");
            string mod = string.Empty, bat = string.Empty;
            con1.Open();
            string str = "Select count(*) from POUCH_LABEL where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' AND Type='Water-CE'";
            SqlCommand com = new SqlCommand(str, con1);
            int counts = Convert.ToInt32(com.ExecuteScalar());
            con1.Close();
            //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
            //var query = from model in db.MattTumblingLens where model.TumblingLotNo == tumbLot select model;
            //var query2 = from model1 in db.RemattTumblingLens where model1.RetumblingRef1 == tumbLot || model1.RetumblingRef2 == tumbLot || model1.RetumblingRef3 == tumbLot select model1;
            //if (query.Count() > 0)
            //{
            //    var query1 = from modl in db.BatchAllots where modl.LotNo == query.Take(1).Single().LensCutLot select modl;
            //    mod = query1.Single().ModelNo;
            //    bat = query1.Single().BatchNo;
            //}
            //else if (query2.Count() > 0)
            //{
            //    string tumblott = query2.Single().TumblingLotNo.ToString();
            //    var qu1 = from x2 in db.MattTumblingLens where x2.TumblingLotNo == tumblott select x2;
            //    if (qu1.Count() > 0)
            //    {
            //        var qu2 = from x4 in db.BatchAllots where x4.LotNo == qu1.Take(1).Single().LensCutLot select x4;
            //        mod = qu2.Single().ModelNo;
            //        bat = qu2.Single().BatchNo;
            //    }
            //}
            var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
            if (query.Count() > 0)
            {
                mod = query.Single().Model;

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
                    //string s = lines[2];
                    //string s1 = s.Replace(losrno, "");                    
                    int count = 0;
                    string lab = string.Empty;
                    foreach (char c in s1)
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        lab = "00" + s1;
                    }
                    else if (count == 2)
                    {
                        lab = "0" + s1;
                    }
                    else if (count == 3)
                    {
                        lab = s1;
                    }
                    //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;

                    SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[8] + "' AND Type_GS_Code='AOD'", con1);
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
                            lotno = losrno.Substring(losrno.Length - 3);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);
                        }
                        else if (i == 2)
                        {
                            lotno = losrno.Substring(losrno.Length - 3);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);
                        }
                        else
                        {
                            lotno = losrno.Substring(losrno.Length - 3);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);

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
                        cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[8];
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
                        cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "Water-CE";
                        cmd.Parameters.Add("@Sterilization_After", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@Box_Reject", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@Print_Name", SqlDbType.NVarChar, 50).Value = DropDownList1.SelectedValue;
                        cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
                        //cmd.Parameters.Add("@Cylsize", SqlDbType.NVarChar, 50).Value = lines[14];
                        cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
                        cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = s1;
                        cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = tumbLot;
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = "Not Labelled";
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "Update POUCH_LABEL set St_EnNo=@St_EnNo,Qty=@Qty where RefLot='" + tumbLot + "'";
                        cmd1.Connection = con1;
                        cmd1.Parameters.Add("@St_EnNo", SqlDbType.VarChar, 50).Value = endsrno + 1;
                        cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = endsrno + 1;
                        cmd1.ExecuteNonQuery();
                        grview();
                        con1.Close();
                        con.Close();
                        con.Open();
                        SqlCommand sm = new SqlCommand();
                        sm.CommandText = "Update PowerSegregationTable set InspectedBy=@InspectedBy where TumblingNo='" + tumbLot + "'";
                        sm.Connection = con;
                        sm.Parameters.Add("@InspectedBy", SqlDbType.VarChar, 50).Value = lines[1];
                        sm.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlCommand cm = new SqlCommand("Select Qty from PowerSegregationChild where TumblingNo='" + tumbLot + "' and Power='" + lines[8] + "'", con);
                        SqlDataReader dr = cm.ExecuteReader();
                        int quantity = 0;
                        if (dr.Read())
                        {
                            quantity = Convert.ToInt32(dr["Qty"]);
                            con.Close();
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand();
                            //int quant = Convert.ToInt32(pr.First().Qty);
                            cmd2.CommandText = "Update PowerSegregationChild set Qty=@Qty where TumblingNo='" + tumbLot + "' and Power='" + lines[8] + "'";
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
                            cmd2.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = tumbLot;
                            cmd2.Parameters.Add("@Power", SqlDbType.Decimal).Value = (lines[8]);
                            cmd2.Parameters.Add("@Qty", SqlDbType.Int).Value = quant1 + 1;
                            cmd2.Parameters.Add("@GlassyRecordRef", SqlDbType.VarChar, 50).Value = "GR" + s1;
                            cmd2.ExecuteNonQuery();


                        }
                        endsrno = Convert.ToInt32(lines[2]);
                        con.Close();
                        //}
                    }
                    else
                    {
                        Messagebox("Choose Valid Brand Name");
                    }
                }
                else
                {
                    Messagebox("Data Already Saved!!!");
                    Drop.Visible = true;
                    btn.Visible = false;
                }
            }
            else
            {
                Messagebox("Before Process Might not be Completed");
            }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
    }
    protected void PowerRejectMtf()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
        try
        {
            s = lines[2];
            s1 = s.Replace(losrno, ""); 
            string mod = string.Empty, bat = string.Empty;
            con.Open();
            string str = "Select count(*) from PowerReject where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' AND Type='Water-CE'";
            SqlCommand com = new SqlCommand(str, con);
            int counts = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
            var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
            if (query.Count() > 0)
            {
                mod = query.Single().Model;
                //var query1 = from modl in db.BatchAllots where modl.LotNo == query.Take(1).Single().LensCutLot select modl;
                //mod = query1.Single().ModelNo;
                //bat = query1.Single().BatchNo;
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
                    SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AOD'", con1);
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
                    else
                    {
                        Messagebox("Choose Valid Brand Name");
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
                    cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "Water-CE";
                    cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
                    cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
                    cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = s1;
                    cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = tumbLot;
                    //cmd.Parameters.Add("@CySize", SqlDbType.VarChar, 50).Value = lines[7];
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand();
                    int r = 0;
                    cmd1.CommandText = "Update PowerReject set Qty=@Qty where RefLot='" + tumbLot + "'";
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

            else
            {
                Messagebox("Before Process Might Not be Completed");
            }
        }

        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
    }
    protected void PowerReject()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
        try
        {
            s = lines[2];
            s1 = s.Replace(losrno, ""); 
            string mod = string.Empty, bat = string.Empty;
            con.Open();
            string str = "Select count(*) from PowerReject where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' AND Type='Water-CE'";
            SqlCommand com = new SqlCommand(str, con);
            int counts = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
            var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
            if (query.Count() > 0)
            {
                mod = query.Single().Model;
                //var query1 = from modl in db.BatchAllots where modl.LotNo == query.Take(1).Single().LensCutLot select modl;
                //mod = query1.Single().ModelNo;
                //bat = query1.Single().BatchNo;            
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
                    SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[8] + "' AND Type_GS_Code='AOD'", con1);
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
                    else
                    {
                        Messagebox("Choose Valid Brand Name");
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
                    cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "Water-CE";
                    cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
                    cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
                    cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = s1;
                    cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = tumbLot;
                    //cmd.Parameters.Add("@CySize", SqlDbType.VarChar, 50).Value = lines[7];
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand();
                    int r = 0;
                    cmd1.CommandText = "Update PowerReject set Qty=@Qty where RefLot='" + tumbLot + "'";
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
            else
            {
                Messagebox("Before Process Might Not be Completed");
            }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
    }
    protected void datastoremoria()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
        try
        {
            s = lines[2];
            s1 = s.Replace(losrno, ""); 
            string mod = string.Empty, bat = string.Empty;
            con1.Open();
            string str = "Select count(*) from POUCH_LABEL where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' AND Type='Water-CE'";
            SqlCommand com = new SqlCommand(str, con1);
            int counts = Convert.ToInt32(com.ExecuteScalar());
            con1.Close();
           
            var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
            if (query.Count() > 0)
            {
                mod = query.Single().Model;
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
                    //string s = lines[2];
                    int count = 0;
                    string lab = string.Empty;
                    foreach (char c in s)
                    {
                        count++;
                    }
                    if (count == 1)
                    {
                        lab = "00" + s1;
                    }
                    else if (count == 2)
                    {
                        lab = "0" + s1;
                    }
                    else if (count == 3)
                    {
                        lab = s1;
                    }
                    //var gs1 = from g1 in db2.LENS_MASTERs where g1.Brand_Name == DropDownList1.SelectedValue && g1.Model_Name == mod && g1.Power == Convert.ToDecimal(lines[10]) && g1.Type_GS_Code == "AI" select g1;
                    //SqlCommand recm1 = new SqlCommand("Select Brand_Name from LENS_MASTER where Replace(Model_Name,' ','')='" + mod + "' AND Power='" + lines[7] + "'", con1);
                    SqlCommand recm1 = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList9.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AOD'", con1);
                    
                    SqlDataReader dar = recm1.ExecuteReader();
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
                            lotno = losrno.Substring(losrno.Length - 3);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);
                        }
                        else if (i == 2)
                        {
                            lotno = losrno.Substring(losrno.Length - 3);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);
                        }
                        else
                        {
                            lotno = losrno.Substring(losrno.Length - 3);
                            int num = losrno.Length - lotno.Length;
                            prefix = losrno.Substring(0, num);
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

                        cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = DropDownList9.SelectedValue;
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
                        cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "Water-CE";
                        cmd.Parameters.Add("@Sterilization_After", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@Box_Reject", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@Print_Name", SqlDbType.NVarChar, 50).Value = DropDownList9.SelectedValue;
                        cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
                        //cmd.Parameters.Add("@Cylsize", SqlDbType.NVarChar, 50).Value = lines[7];
                        cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
                        cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = s1;
                        cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = tumbLot;
                        cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = "Not Labelled";
                        cmd.ExecuteNonQuery();
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.CommandText = "Update POUCH_LABEL set St_EnNo=@St_EnNo,Qty=@Qty where RefLot='" + tumbLot + "'";
                        cmd1.Connection = con1;
                        cmd1.Parameters.Add("@St_EnNo", SqlDbType.VarChar, 50).Value = endsrno + 1;
                        cmd1.Parameters.Add("@Qty", SqlDbType.Int).Value = endsrno + 1;
                        cmd1.ExecuteNonQuery();
                        grview1();
                        con1.Close();
                        con.Open();
                        SqlCommand sm = new SqlCommand();
                        sm.CommandText = "Update PowerSegregationTable set InspectedBy=@InspectedBy where TumblingNo='" + tumbLot + "'";
                        sm.Connection = con;
                        sm.Parameters.Add("@InspectedBy", SqlDbType.VarChar, 50).Value = lines[1];
                        sm.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        SqlCommand cm = new SqlCommand("Select Qty from PowerSegregationChild where TumblingNo='" + tumbLot + "' and Power='" + lines[7] + "'", con);
                        SqlDataReader dr = cm.ExecuteReader();
                        int quantity = 0;
                        if (dr.Read())
                        {
                            quantity = Convert.ToInt32(dr["Qty"]);
                            con.Close();
                            con.Open();
                            SqlCommand cmd2 = new SqlCommand();
                            //int quant = Convert.ToInt32(pr.First().Qty);
                            cmd2.CommandText = "Update PowerSegregationChild set Qty=@Qty where TumblingNo='" + tumbLot + "' and Power='" + lines[7] + "'";
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
                            cmd2.Parameters.Add("@TumblingNo", SqlDbType.VarChar, 50).Value = tumbLot;
                            cmd2.Parameters.Add("@Power", SqlDbType.Decimal).Value = lines[7];
                            cmd2.Parameters.Add("@Qty", SqlDbType.Int).Value = quant1 + 1;
                            cmd2.Parameters.Add("@GlassyRecordRef", SqlDbType.VarChar, 50).Value = "GR" + s1;
                            cmd2.ExecuteNonQuery();

                        }
                        endsrno = Convert.ToInt32(lines[2]);
                        con.Close();
                        //}
                    }
                    else
                    {
                        Messagebox("Choose Valid Brand Name");
                    }
                }
                else
                {
                    Messagebox("Data Already Saved!!!");
                    Drop1.Visible = true;
                    btn1.Visible = false;
                }
            }
            else
            {
                Messagebox("Before Process Might not be Completed");
            }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
    }
    protected void PowerRejectMtfMoria()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
        //try
        //{
            s = lines[2];
            s1 = s.Replace(losrno, ""); 
            string mod = string.Empty, bat = string.Empty;
            con.Open();
            string str = "Select count(*) from PowerReject where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' AND Type='Water-CE'";
            SqlCommand com = new SqlCommand(str, con);
            int counts = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
            var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
            //var query1 = from modl in db.BatchAllots where modl.LotNo == query.Take(1).Single().LensCutLot select modl;
            //mod = query1.Single().ModelNo;
            //bat = query1.Single().BatchNo;
            if (query.Count() > 0)
            {
                mod = query.Single().Model;

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
                    SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList9.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AOD'", con1);
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
                    cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = DropDownList9.SelectedValue;
                    cmd.Parameters.Add("@Model_Name", SqlDbType.NVarChar, 50).Value = mod;
                    cmd.Parameters.Add("@Reference_Name", SqlDbType.NVarChar, 50).Value = refname;
                    cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[7];
                    cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = "APS";
                    cmd.Parameters.Add("@Created_Date", SqlDbType.DateTime).Value = dt;
                    cmd.Parameters.Add("@Modified_By", SqlDbType.VarChar, 50).Value = "APS";
                    cmd.Parameters.Add("@Modified_Date", SqlDbType.DateTime).Value = dt;
                    cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "Water-CE";
                    cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
                    cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
                    cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = s1;
                    cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = tumbLot;
                    //cmd.Parameters.Add("@CySize", SqlDbType.VarChar, 50).Value = lines[7];
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand();
                    int r = 0;
                    cmd1.CommandText = "Update PowerReject set Qty=@Qty where RefLot='" + tumbLot + "'";
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
            else
            {
                Messagebox("Before Process Might Not Be Completed");
            }
        //}
        //catch (Exception ex)
        //{
        //    Messagebox(ex.ToString());
        //}
    }
    protected void PowerRejectMoria()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NonPreloadedConnectionString"].ConnectionString);
        try
        {
            s = lines[2];
            s1 = s.Replace(losrno, ""); 
            string mod = string.Empty, bat = string.Empty;
            con.Open();
            string str = "Select count(*) from PowerReject where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' AND Type='Water-CE'";
            SqlCommand com = new SqlCommand(str, con);
            int counts = Convert.ToInt32(com.ExecuteScalar());
            con.Close();
            //var r1 = from row in db2.POUCH_LABELs where row.rotlex_type == btch && row.RefLot == losrno && row.Label == Convert.ToInt32(lines[1]) && row.Type == "PHOBIC" select row;
            var query = from model in db.NewBtchAllots where model.LotNo == tumbLot select model;
            //var query1 = from modl in db.BatchAllots where modl.LotNo == query.Take(1).Single().LensCutLot select modl;
            //string mod = query1.Single().ModelNo;
            //string bat = query1.Single().BatchNo;
            if (query.Count() > 0)
            {
                mod = query.Single().Model;
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
                    SqlCommand recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList9.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[8] + "' AND Type_GS_Code='AOD'", con1);
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
                    cmd.Parameters.Add("@Brand_Name", SqlDbType.NVarChar, 50).Value = DropDownList9.SelectedValue;
                    cmd.Parameters.Add("@Model_Name", SqlDbType.NVarChar, 50).Value = mod;
                    cmd.Parameters.Add("@Reference_Name", SqlDbType.NVarChar, 50).Value = refname;
                    cmd.Parameters.Add("@Power", SqlDbType.VarChar, 10).Value = lines[8];
                    cmd.Parameters.Add("@Qty", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 50).Value = "APS";
                    cmd.Parameters.Add("@Created_Date", SqlDbType.DateTime).Value = dt;
                    cmd.Parameters.Add("@Modified_By", SqlDbType.VarChar, 50).Value = "APS";
                    cmd.Parameters.Add("@Modified_Date", SqlDbType.DateTime).Value = dt;
                    cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "Water-CE";
                    cmd.Parameters.Add("@R_Power", SqlDbType.NVarChar, 50).Value = lines[5];
                    cmd.Parameters.Add("@rotlex_type", SqlDbType.VarChar, 50).Value = btch;
                    cmd.Parameters.Add("@Label", SqlDbType.VarChar, 50).Value = s1;
                    cmd.Parameters.Add("@RefLot", SqlDbType.VarChar, 50).Value = tumbLot;
                    //cmd.Parameters.Add("@CySize", SqlDbType.VarChar, 50).Value = lines[7];
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand();
                    int r = 0;
                    cmd1.CommandText = "Update PowerReject set Qty=@Qty where RefLot='" + tumbLot + "'";
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
            else
            {
                Messagebox("Before Process Might Not Be Completed");
            }
        }
        catch (Exception ex)
        {
            Messagebox(ex.ToString());
        }
    }
  

    protected string datastore_PreloadedWinPro()
       {
           var insertVal = String.Empty;
           SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["APS_NEWConnectionString"].ConnectionString);
           try
           {

               con1.Open();
               if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
               {
                   con3.Open();
               }
               // Check Serial Already Done or not
               s1 = lines[2];
               // s = lines[1];
              // s1 = s.Replace(losrno, "");

               //string str = "Select count(*) from POUCH_LABEL where rotlex_type='" + btch + "' AND RefLot='" + tumbLot + "' AND Label='" + s1 + "' ";
               //SqlCommand com = new SqlCommand(str, con1);
               int counts = 0;
               //con1.Close();

               if (counts == 0)
               {
                   int count = 0;
                   string lab = string.Empty;
                  
                   if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                   {

                       foreach (char c in s1)
                       {
                           count++;
                       }
                       if (count == 1)
                       {
                           lab = "0000" + s1;
                       }
                       else if (count == 2)
                       {
                           lab = "000" + s1;
                       }

                       else if (count == 3)
                       {
                           lab = "00" + s1;
                           lab = s1;
                       }
                       else if (count == 4)
                       {
                           lab = "0" + s1;

                       }
                       else if (count == 5)
                       {

                           lab = s1;
                       }

                   }
                   else
                   {
                       foreach (char c in s1)
                       {
                           count++;
                       }
                       if (count == 1)
                       {
                           lab = "00" + s1;
                       }
                       else if (count == 2)
                       {
                           lab = "0" + s1;
                       }
                       else if (count == 3)
                       {
                           lab = s1;

                       }
                   }



                   int totlab_count = count;

                   SqlCommand recm;
                   DateTime dt = System.DateTime.Today;
                   if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                   {
                       recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AI'", con3);
                   }
                   else
                   {
                       recm = new SqlCommand("Select * from LENS_MASTER where Brand_Name='" + DropDownList1.SelectedValue + "' AND Model_Name='" + mod + "' AND Power='" + lines[7] + "' AND Type_GS_Code='AOD'", con1);
                   }

                   SqlDataReader dar = recm.ExecuteReader();
                   if (dar.Read())
                   {
                       try
                       {
                           totexp1 = Convert.ToInt32(dar["Tot_Exp"]);

                           string initialString = losrno;
                           System.Text.RegularExpressions.Regex nonNumericCharacters = new System.Text.RegularExpressions.Regex(@"\D");
                           string numericOnlyString = nonNumericCharacters.Replace(initialString, String.Empty);

                           stryear = System.DateTime.Now.ToString("yy");
                           strmonth = System.DateTime.Now.ToString("MM");




                           if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                           {
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


                                   prefix = losrno.Substring(0, 3);

                                   lotno = losrno.Substring(losrno.Length - 2);



                               }
                               else if (i == 2)
                               {

                                   prefix = losrno.Substring(0, 4);
                                   lotno = losrno.Substring(4, 2);
                               }
                               else
                               {

                                   prefix = losrno.Substring(0, 4);
                                   lotno = losrno.Substring(4, 2);


                               }

                           }
                           else
                           {
                               lotno = losrno.Substring(losrno.Length - 4);
                               int num = losrno.Length - lotno.Length;
                               prefix = losrno.Substring(0, num);

                           }


                           //Expiry Calculation
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


                           if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                           {

                               insertVal = "('" + DropDownList1.SelectedValue + "','" + mod + "','" + refname + "','" + lines[7] + "','" + pass + "','" + lab + "','" + pass + "','"
                         + prefix + "','" + lotno + "','" + losrno + lab + "','" + strmanfmonth + "','" + strmanfyear + "','" + expmonth + "','" + expyear + "',0,0,'NO' ,0,0,0,'APS','"
                         + dt + "','APS','" + dt + "',0,1,'" + droptyp.SelectedValue + "',0,0,'" + DropDownList1.SelectedValue + "','" + lines[5] + "' ,'" + btch + "','"
                         + s1 + "','" + tumbLot + "','Not Labelled'),";
                           }
                           else
                           {

                               insertVal = "('" + DropDownList1.SelectedValue + "','" + mod + "','" + refname + "','" + lines[7] + "','" + pass + "','" + lab + "','" + pass + "','"
                        + prefix + "','" + lotno + "','" + losrno + " " + lab + "','" + strmanfmonth + "','" + strmanfyear + "','" + expmonth + "','" + expyear + "',0,0,'NO' ,0,0,0,'APS','"
                        + dt + "','APS','" + dt + "',0,1,'" + droptyp.SelectedValue + "',0,0,'" + DropDownList1.SelectedValue + "','" + lines[5] + "' ,'" + btch + "','"
                        + s1 + "','" + tumbLot + "','Not Labelled'),";

                           }
                       }
                       catch (Exception ex)
                       {

                           Messagebox(ex.ToString());
                           return String.Empty;
                       }
                   }
                   //Insert bulk data


                   if (DropDownList1.Text == "SUPERPHOB" && mod == "AE-01")
                   {
                       con3.Close();
                   }
                   // grview();

                   con1.Close();
               }

               else
               {
                   Messagebox("Serial Number Already Saved....");
               }


               return insertVal;
           }
           catch (Exception ex)
           {
               Messagebox(ex.ToString());
               return String.Empty;
           }
       }

    protected void droptyp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Win_btn_Click(object sender, EventArgs e)
    {

    }
}







