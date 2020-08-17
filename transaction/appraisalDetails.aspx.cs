using SampleApp.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace SampleApp.transaction
{
    public partial class appraisalDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["id"] == null)
            //{
            //    Response.Redirect("~/");
            //}
            //if(Convert.ToString(Session["transaction"]) != "appraisalDetails")
            //{
            //    Response.Redirect("~/transaction/appraisal");
            //}
            //else if (Convert.ToString(Session["transaction"]) != "appraisalDetailsItem")
            //{

            //}


            lblIsEdit.Text = "New";

            if (!IsPostBack)
            {
                //DataTable dt = GetTableWithNoData(); // get select column header only records not required

                grdItems.DataSource = GetTableItem();
                grdItems.DataBind();

                grdPaymentDetails.DataSource = GetTablePaymentDetails(); // get first initial data
                grdPaymentDetails.DataBind();

                ddNotedBy.Items.Clear();
                ddPreparedBy.Items.Clear();
                


                if (!string.IsNullOrEmpty(Request.QueryString["id"]) && Request.QueryString["id"] != "0")
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                }

                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    isEdit = true;
                    using (var db = new CG_AppraisalEntities())
                    {
                        var userlist = db.SetUsers.Where(x => x.IsActive == true)
                            .Select(g => new {
                                id = g.Id,
                                userName = g.LastName + ", " + g.FirstName
                            }
                        ).OrderBy(a=>a.userName).ToList();

                        ddNotedBy.DataSource = userlist;
                        ddNotedBy.DataValueField = "id";
                        ddNotedBy.DataTextField = "userName";
                        ddNotedBy.DataBind();


                        ddPreparedBy.DataSource = userlist;
                        ddPreparedBy.DataValueField = "id";
                        ddPreparedBy.DataTextField = "userName";
                        ddPreparedBy.DataBind();


                        var userItems = db.TxnAppraisals.Where(x => x.Id == id).ToList();

                        foreach (var item in userItems)
                        {
                            txtBatchReference.Text = item.BatchCode;
                            txtAccountName.Text = item.AccountName;
                            txtCompanyName.Text = item.CompanyName;
                            txtPropertyLocation.Text = item.TotalProperty;
                            txtTCTNo.Text = item.CTCNo;
                            txtTotalArea.Text = item.TotalProperty; 

                            if(item.NotedBy >= 0)
                            {
                                ddNotedBy.Text = db.SetUsers.Where(z => z.Id == item.NotedBy).Select(x => x.LastName + ", " + x.FirstName).FirstOrDefault();
                            }
                            if (item.ApprovedBy >= 0)
                            {
                                ddPreparedBy.Text = db.SetUsers.Where(z=>z.Id == item.ApprovedBy).Select(x => x.LastName + ", " + x.FirstName).FirstOrDefault();
                            }
                        }
                    }



                    var dtCbItems = new DataTable();
                    dtCbItems.Columns.Clear();
                    dtCbItems.Columns.Add("item", typeof(string));
                    dtCbItems.Rows.Clear();

                    cbAppraisalItem.Items.Clear();

                    using (CG_AppraisalEntities db = new CG_AppraisalEntities())
                    {
                        var _item = db.TxnAppraisalItems.Select(x => x.ItemDescription).Distinct().OrderBy(z => z).ToList();
                        foreach (var x in _item)
                        {
                            cbAppraisalItem.Items.Add(x);
                        }
                    }

                    if (dtCbItems.Rows.Count > 0)
                    {
                        ViewState["dtCbItems"] = dtCbItems;
                    }
                    else
                    {
                        ViewState["dtCbItems"] = null;
                    }
                    
                }
                else
                {
                    lblIsEdit.Text = "Edit";
                    if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    {
                        isEdit = true;
                        id = Convert.ToInt32(Request.QueryString["id"]);
                    }
                    else
                    {                         
                        isEdit = false;
                    }
                }
            }
            else
            {
                if (PublicVariables.pubTxnAppraisal.Count > 0)
                {
                    foreach (var x in PublicVariables.pubTxnAppraisal)
                    {
                        txtAccountName.Text = x.AccountName;
                    }
                }
            }
        }


        int id = -1;
        bool isEdit = false;
        bool isExist = false;
        bool isEmptyField = false;
        protected void btnOk_Click(object sender, ImageClickEventArgs e)
        { 
            mpePopUp.Hide();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblText.Text = "";
            isEmptyField = false;
            isExist = false;
            if (string.IsNullOrEmpty(txtAccountName.Text))
            {
                isEmptyField = true;
            }
            else if (string.IsNullOrEmpty(txtPropertyLocation.Text))
            {
                isEmptyField = true;
            }
            else if (string.IsNullOrEmpty(txtTotalArea.Text))
            {
                isEmptyField = true;
            }

            if (isEmptyField)
            {
                lblText.Text = "Please fill the required fields(*)";
                mpePopUp.Show();
                return;
            }

            if (txtBatchReference.Text != "") {
                using (CG_AppraisalEntities db = new CG_AppraisalEntities())
                {
                    var checkIfBatchIsExist = db.TxnAppraisals.Where(x => x.BatchCode == txtBatchReference.Text).ToList();
                    if (checkIfBatchIsExist.Count >= 0)
                    {
                        isExist = true;
                    }
                }
            }

            if (isExist)
            {
                lblText.Text = "Batch Reference is already exist";
                //ValidationSummary2.Visible = true;
                mpePopUp.Show();
                return;
            }



            ViewState["doneDetails1"] = true;

            TxnAppraisal txnAppraisal = new TxnAppraisal();
            txnAppraisal.AccountName = txtAccountName.Text;
            txnAppraisal.BatchCode = txtBatchReference.Text;
            txnAppraisal.CompanyName = txtCompanyName.Text;
            txnAppraisal.Address = txtPropertyLocation.Text;
            txnAppraisal.CTCNo = txtTCTNo.Text; 

            PublicVariables.pubTxnAppraisal.Add(txnAppraisal);
            
 

           foreach(GridViewRow items in grdItems.Rows)
            {
                 


            }
        }

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Session["transaction"] = "";
            Response.Redirect("~/transaction/appraisal");
        }

        public DataTable GetTablePaymentDetails() // returns only structure if the select columns
        {
            var dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add("RowNo", typeof(string));
            dt.Columns.Add("PaymentDetails", typeof(string));
            dt.Columns.Add("Amount", typeof(string));

            dr = dt.NewRow();
            dr["RowNo"] = 1;
            dr["PaymentDetails"] = string.Empty;
            dr["Amount"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["dtPaymentDetails"] = dt;

            return dt;
        }
        public DataTable GetTableItem() // returns only structure if the select columns
        {
            var dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add("RowNo", typeof(string));
            dt.Columns.Add("Item", typeof(string));

            dr = dt.NewRow();
            dr["RowNo"] = 1;
            dr["Item"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["dtItems"] = dt;

            return dt;
        }
        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            if (ViewState["dtPaymentDetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtPaymentDetails"];
                DataRow dr;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //extract the TextBox values                         
                        TextBox txtPaymentDescription = (TextBox)grdPaymentDetails.Rows[i].Cells[1].FindControl("txtPaymentDetails");
                        TextBox txtAmount = (TextBox)grdPaymentDetails.Rows[i].Cells[2].FindControl("txtAmount");

                        dt.Rows[i]["RowNo"] = i + 1;
                        dt.Rows[i]["PaymentDetails"] = txtPaymentDescription.Text;
                        dt.Rows[i]["Amount"] = txtAmount.Text;
                    }
                    dr = dt.NewRow(); // add last empty row
                    dt.Rows.Add(dr);
                    ViewState["dtPaymentDetails"] = dt;
                    grdPaymentDetails.DataSource = dt; // bind new datatable to grid
                    grdPaymentDetails.DataBind();
                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ViewState is null');", true);
                    //Response.Write("ViewState is null");
                }
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[1].Text;
                foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }
        private void SetPreviousDataPaymentDetails()
        {
            int rowIndex = 0;
            if (ViewState["dtPaymentDetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtPaymentDetails"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txtPaymentDescription = (TextBox)grdPaymentDetails.Rows[rowIndex].Cells[1].FindControl("txtPaymentDetails");
                        TextBox txtAmount = (TextBox)grdPaymentDetails.Rows[rowIndex].Cells[2].FindControl("txtAmount");


                        dt.Rows[i]["RowNo"] = i + 1;
                        txtPaymentDescription.Text = dt.Rows[i]["PaymentDetails"].ToString();
                        txtAmount.Text = dt.Rows[i]["Amount"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

        protected void grdPaymentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowDataPaymentDetails();
            if (ViewState["dtPaymentDetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtPaymentDetails"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["dtPaymentDetails"] = dt;
                    grdPaymentDetails.DataSource = dt;
                    grdPaymentDetails.DataBind();

                    //for (int i = 0; i < grdItems.Rows.Count - 1; i++)
                    for (int i = 0; i < grdPaymentDetails.Rows.Count; i++)
                    {
                        grdPaymentDetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousDataPaymentDetails();
                }
            }
        }

        private void SetRowDataPaymentDetails()
        {
            int rowIndex = 0;

            if (ViewState["dtPaymentDetails"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtPaymentDetails"];
                DataRow dr = null;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i <= dt.Rows.Count; i++)
                    {
                        TextBox txtPaymentDescription = (TextBox)grdPaymentDetails.Rows[rowIndex].Cells[1].FindControl("txtPaymentDetails");
                        TextBox txtAmount = (TextBox)grdPaymentDetails.Rows[rowIndex].Cells[2].FindControl("txtAmount");


                        dr = dt.NewRow();
                        dt.Rows[i - 1]["RowNo"] = i + 1;
                        dt.Rows[i - 1]["PaymentDetails"] = txtPaymentDescription.Text;
                        dt.Rows[i - 1]["Amount"] = txtAmount.Text;
                        rowIndex++;
                    }

                    ViewState["dtPaymentDetails"] = dt;
                    grdPaymentDetails.DataSource = dt;
                    grdPaymentDetails.DataBind();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ViewState is null');", true);
                //Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        protected void btnAddRowItems_Click(object sender, EventArgs e)
        {
            if (ViewState["dtItems"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtItems"];
                DataRow dr;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //extract the TextBox values                         
                        TextBox txtItem = (TextBox)grdItems.Rows[i].Cells[1].FindControl("txtItem");

                        dt.Rows[i]["RowNo"] = i + 1;
                        dt.Rows[i]["Item"] = txtItem.Text;
                    }
                    dr = dt.NewRow(); // add last empty row
                    dt.Rows.Add(dr);
                    ViewState["dtItems"] = dt;
                    grdItems.DataSource = dt; // bind new datatable to grid
                    grdItems.DataBind();
                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ViewState is null');", true);
                    //Response.Write("ViewState is null");
                }
            }
        }
        private void SetPreviousDataItem()
        {
            int rowIndex = 0;
            if (ViewState["dtItems"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtItems"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txtItem = (TextBox)grdItems.Rows[rowIndex].Cells[1].FindControl("txtItem");


                        dt.Rows[i]["RowNo"] = i + 1;
                        txtItem.Text = dt.Rows[i]["Item"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowDataItem();
            if (ViewState["dtItems"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtItems"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["dtItems"] = dt;
                    grdItems.DataSource = dt;
                    grdItems.DataBind();

                    //for (int i = 0; i < grdItems.Rows.Count - 1; i++)
                    for (int i = 0; i < grdItems.Rows.Count; i++)
                    {
                        grdItems.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    }
                    SetPreviousDataItem();
                }
            }
        }
        private void SetRowDataItem()
        {
            int rowIndex = 0;

            if (ViewState["dtItems"] != null)
            {
                DataTable dt = (DataTable)ViewState["dtItems"];
                DataRow dr = null;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i <= dt.Rows.Count; i++)
                    {
                        TextBox txtItem = (TextBox)grdItems.Rows[rowIndex].Cells[1].FindControl("txtItem");


                        dr = dt.NewRow();
                        dt.Rows[i - 1]["RowNo"] = i + 1;
                        dt.Rows[i - 1]["Item"] = txtItem.Text;
                        rowIndex++;
                    }

                    ViewState["dtItems"] = dt;
                    grdItems.DataSource = dt;
                    grdItems.DataBind();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ViewState is null');", true);
                //Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        protected void chkWithVat_CheckedChanged(object sender, EventArgs e)
        {
            if(chkWithVat.Checked)
            {
                lblWithVat.Text = "With Vat 12%";
            }
            else
            {
                lblWithVat.Text = "";
            }
        }
    }
}



//public DataTable GetTablePaymentDetails() // returns only structure if the select columns
//{
//    var dt = new DataTable();
//    DataRow dr = null;

//    dt.Columns.Add("RowNo", typeof(string));
//    dt.Columns.Add("PaymentDetails", typeof(string));
//    dt.Columns.Add("Amount", typeof(string));

//    dr = dt.NewRow();
//    dr["RowNo"] = 1;
//    dr["PaymentDetails"] = string.Empty;
//    dr["Amount"] = string.Empty;
//    dt.Rows.Add(dr);

//    ViewState["dtPaymentDetails"] = dt;

//    return dt;
//}
//public DataTable GetTableItem() // returns only structure if the select columns
//{
//    var dt = new DataTable();
//    DataRow dr = null;

//    dt.Columns.Add("RowNo", typeof(string));
//    dt.Columns.Add("Item", typeof(string)); 

//    dr = dt.NewRow();
//    dr["RowNo"] = 1;
//    dr["Item"] = string.Empty; 
//    dt.Rows.Add(dr);

//    ViewState["dtItems"] = dt;

//    return dt;
//}
//protected void btnAddRow_Click(object sender, EventArgs e)
//{ 
//    if (ViewState["dtPaymentDetails"] != null)
//    {
//        DataTable dt = (DataTable)ViewState["dtPaymentDetails"];
//        DataRow dr; 
//        if (dt.Rows.Count > 0)
//        { 
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                //extract the TextBox values                         
//                TextBox txtPaymentDescription = (TextBox)grdPaymentDetails.Rows[i].Cells[1].FindControl("txtPaymentDetails");
//                TextBox txtAmount = (TextBox)grdPaymentDetails.Rows[i].Cells[2].FindControl("txtAmount");

//                dt.Rows[i]["RowNo"] = i + 1;
//                dt.Rows[i]["PaymentDetails"] = txtPaymentDescription.Text;
//                dt.Rows[i]["Amount"] = txtAmount.Text;  
//            } 
//            dr = dt.NewRow(); // add last empty row
//            dt.Rows.Add(dr);
//            ViewState["dtPaymentDetails"] = dt;
//            grdPaymentDetails.DataSource = dt; // bind new datatable to grid
//            grdPaymentDetails.DataBind();
//        }
//        else
//        {

//            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ViewState is null');", true);
//            //Response.Write("ViewState is null");
//        }
//    }
//}
//protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
//{
//    if (e.Row.RowType == DataControlRowType.DataRow)
//    {
//        string item = e.Row.Cells[1].Text;
//        foreach (Button button in e.Row.Cells[2].Controls.OfType<Button>())
//        {
//            if (button.CommandName == "Delete")
//            {
//                button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
//            }
//        }
//    }
//}
//private void SetPreviousDataPaymentDetails()
//{
//    int rowIndex = 0;
//    if (ViewState["dtPaymentDetails"] != null)
//    {
//        DataTable dt = (DataTable)ViewState["dtPaymentDetails"]; 
//        if (dt.Rows.Count > 0)
//        {
//            for (int i = 0; i < dt.Rows.Count; i++)
//            { 
//                TextBox txtPaymentDescription = (TextBox)grdPaymentDetails.Rows[rowIndex].Cells[1].FindControl("txtPaymentDetails");
//                TextBox txtAmount = (TextBox)grdPaymentDetails.Rows[rowIndex].Cells[2].FindControl("txtAmount");


//                dt.Rows[i]["RowNo"] = i + 1;
//                txtPaymentDescription.Text = dt.Rows[i]["PaymentDetails"].ToString();
//                txtAmount.Text = dt.Rows[i]["Amount"].ToString(); 
//                rowIndex++;
//            }
//        }
//    }
//}

//protected void grdPaymentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
//{
//    SetRowDataPaymentDetails();
//    if (ViewState["dtPaymentDetails"] != null)
//    {
//        DataTable dt = (DataTable)ViewState["dtPaymentDetails"];
//        DataRow drCurrentRow = null;
//        int rowIndex = Convert.ToInt32(e.RowIndex);
//        if (dt.Rows.Count > 1)
//        {
//            dt.Rows.Remove(dt.Rows[rowIndex]);
//            drCurrentRow = dt.NewRow();
//            ViewState["dtPaymentDetails"] = dt;
//            grdPaymentDetails.DataSource = dt;
//            grdPaymentDetails.DataBind();

//            //for (int i = 0; i < grdItems.Rows.Count - 1; i++)
//            for (int i = 0; i < grdPaymentDetails.Rows.Count; i++)
//            {
//                grdPaymentDetails.Rows[i].Cells[0].Text = Convert.ToString(i+ 1);
//            }
//            SetPreviousDataPaymentDetails();
//        }
//    }
//}

//private void SetRowDataPaymentDetails()
//{
//    int rowIndex = 0;

//    if (ViewState["dtPaymentDetails"] != null)
//    {
//        DataTable dt = (DataTable)ViewState["dtPaymentDetails"];
//        DataRow dr = null; 
//        if (dt.Rows.Count > 0)
//        {
//            for (int i = 1; i <= dt.Rows.Count; i++)
//            { 
//                TextBox txtPaymentDescription = (TextBox)grdPaymentDetails.Rows[rowIndex].Cells[1].FindControl("txtPaymentDetails");
//                TextBox txtAmount = (TextBox)grdPaymentDetails.Rows[rowIndex].Cells[2].FindControl("txtAmount");


//                dr = dt.NewRow();
//                dt.Rows[i - 1]["RowNo"] = i + 1;
//                dt.Rows[i - 1]["PaymentDetails"] = txtPaymentDescription.Text;
//                dt.Rows[i - 1]["Amount"] = txtAmount.Text; 
//                rowIndex++;
//            }

//            ViewState["dtPaymentDetails"] = dt;
//            grdPaymentDetails.DataSource = dt;
//            grdPaymentDetails.DataBind();
//        }
//    }
//    else
//    {
//        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ViewState is null');", true);
//        //Response.Write("ViewState is null");
//    }
//    //SetPreviousData();
//}

//protected void btnAddRowItems_Click(object sender, EventArgs e)
//{
//    if (ViewState["dtItems"] != null)
//    {
//        DataTable dt = (DataTable)ViewState["dtItems"];
//        DataRow dr;
//        if (dt.Rows.Count > 0)
//        {
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                //extract the TextBox values                         
//                TextBox txtItem = (TextBox)grdItems.Rows[i].Cells[1].FindControl("txtItem"); 

//                dt.Rows[i]["RowNo"] = i + 1;
//                dt.Rows[i]["Item"] = txtItem.Text; 
//            }
//            dr = dt.NewRow(); // add last empty row
//            dt.Rows.Add(dr);
//            ViewState["dtItems"] = dt;
//            grdItems.DataSource = dt; // bind new datatable to grid
//            grdItems.DataBind();
//        }
//        else
//        {

//            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ViewState is null');", true);
//            //Response.Write("ViewState is null");
//        }
//    }
//}
//private void SetPreviousDataItem()
//{
//    int rowIndex = 0;
//    if (ViewState["dtItems"] != null)
//    {
//        DataTable dt = (DataTable)ViewState["dtItems"];
//        if (dt.Rows.Count > 0)
//        {
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                TextBox txtItem = (TextBox)grdItems.Rows[rowIndex].Cells[1].FindControl("txtItem"); 


//                dt.Rows[i]["RowNo"] = i + 1;
//                txtItem.Text = dt.Rows[i]["Item"].ToString(); 
//                rowIndex++;
//            }
//        }
//    }
//}
//protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
//{
//    SetRowDataItem();
//    if (ViewState["dtItems"] != null)
//    {
//        DataTable dt = (DataTable)ViewState["dtItems"];
//        DataRow drCurrentRow = null;
//        int rowIndex = Convert.ToInt32(e.RowIndex);
//        if (dt.Rows.Count > 1)
//        {
//            dt.Rows.Remove(dt.Rows[rowIndex]);
//            drCurrentRow = dt.NewRow();
//            ViewState["dtItems"] = dt;
//            grdItems.DataSource = dt;
//            grdItems.DataBind();

//            //for (int i = 0; i < grdItems.Rows.Count - 1; i++)
//            for (int i = 0; i < grdItems.Rows.Count; i++)
//            {
//                grdItems.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
//            }
//            SetPreviousDataItem();
//        }
//    }
//}
//private void SetRowDataItem()
//{
//    int rowIndex = 0;

//    if (ViewState["dtItems"] != null)
//    {
//        DataTable dt = (DataTable)ViewState["dtItems"];
//        DataRow dr = null;
//        if (dt.Rows.Count > 0)
//        {
//            for (int i = 1; i <= dt.Rows.Count; i++)
//            {
//                TextBox txtItem = (TextBox)grdItems.Rows[rowIndex].Cells[1].FindControl("txtItem"); 


//                dr = dt.NewRow();
//                dt.Rows[i - 1]["RowNo"] = i + 1;
//                dt.Rows[i - 1]["Item"] = txtItem.Text; 
//                rowIndex++;
//            }

//            ViewState["dtItems"] = dt;
//            grdItems.DataSource = dt;
//            grdItems.DataBind();
//        }
//    }
//    else
//    {
//        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('ViewState is null');", true);
//        //Response.Write("ViewState is null");
//    }
//    //SetPreviousData();
//}