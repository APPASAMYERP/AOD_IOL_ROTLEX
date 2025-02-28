using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReportFinal : System.Web.UI.Page
{


    #region Declaration

    SoftLensDataContext db = new SoftLensDataContext();
    IFormatProvider provider = new System.Globalization.CultureInfo("en-CA", true);
    int FinAccept = 0;
    int FinReject = 0;
    //int acp1;
    //int rej1, rej2, rej3, rej4, rej5, rej6, rej7, rej8, rej9, rej10;

    #endregion
    

    #region Methods

    private void Messagebox(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Windows", "alert('" + msg + "')", true);
    }

    //public void AddList(int Count)
    //{
    //    BatchFinalReport br = new BatchFinalReport();
    //    var Q = (from row in db.BatchAllots where row.BatchNo == txtPhobicId.Text select row).ToList();
       
    //    List<string> Listval = new List<string>();
    //    foreach (var C in Q)
    //    {
    //        br.PhobicId = C.BatchNo;
    //        br.LotNo = C.LotNo;
    //        br.Model = C.ModelNo;
    //        Listval.Add(br.PhobicId);
    //        Listval.Add(br.LotNo);
    //        Listval.Add(br.Model);
    //        db.BatchFinalReports.InsertOnSubmit(br);
    //        db.SubmitChanges();
    //    }
    //    br.TotalQty = Count;
    //    db.BatchFinalReports.InsertOnSubmit(br);
    //    db.SubmitChanges();


    //}

    #endregion
    

    #region Events

    protected void txtLotno_TextChanged(object sender, EventArgs e)
    {
        string t = txtPhobicId.Text;
        txtPhobicId.Text = t.ToUpper();

        btnGenerate.Visible = true;
        btnGenerate.Focus();

        //LblBatch.Visible = true;
        //gvBatchAllot.DataSource = null;
        //gvBatchAllot.DataBind();

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnHome_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Welcome.aspx");
    }    

    protected void btnGenerate_Click(object sender, ImageClickEventArgs e)
    {

        var q = (from row in db.BatchAllots where row.BatchNo == txtPhobicId.Text select row.LotNo).Count();
        int count = q;
        int totqty = count * 50;

        var Q = from row in db.LensPreperation_Details where row.PhobicId == txtPhobicId.Text select row.TumblingRefNo;
        string Tumref = Q.FirstOrDefault();

        var Q1 = from row in db.PowerSegregationChilds where row.TumblingNo == Tumref select row.GlassyRecordRef;
        foreach (var Q2 in Q1)
        {
            //var Q3 = from row in db.RemattTumblingLens where row.g == Q2 select row;
            //int Accept =Convert.ToInt32(Q3.Single().AcceptedQty1);
            //FinAccept=FinAccept+Accept;
            //int Reject = Convert.ToInt32(Q3.Single());
            //FinReject = FinReject + Reject;
        }
       
       




       






        #region Delete
        //AddList(totqty);

        //BatchFinalReport bfs = new BatchFinalReport();
        //List<string> Add1 = new List<string>();
        //var Q = (from row in db.BatchAllots where row.BatchNo == txtPhobicId.Text select row).ToList();
        //foreach (var C in Q)
        //{
        //    bfs.PhobicId = C.BatchNo;
        //    bfs.LotNo = C.LotNo;
        //    bfs.Model = C.ModelNo;
   
            
        //    Add1.Add(bfs.PhobicId);
        //    Add1.Add(bfs.LotNo);
        //    Add1.Add(bfs.Model);
           
        //}       
        
        //bfs.TotalQty = totqty;
        //db.BatchFinalReports.InsertOnSubmit(bfs);
        //db.SubmitChanges();

        //var Q1 = from row in db.BatchFinalReports where row.PhobicId == txtPhobicId.Text select row;
        //gvBatchAllot.DataSource = Q1;
        //gvBatchAllot.DataBind();

        //Messagebox("Saved");
        #endregion

        












        #region Production_Status

        var q1 = from row in db.LensPreperation_Details where row.PhobicId == txtPhobicId.Text select row;
        var q2 = from row in db.FinalLensPreparations where row.PhobicId == txtPhobicId.Text select row;

        #endregion

       





    }

    #endregion



}






   

