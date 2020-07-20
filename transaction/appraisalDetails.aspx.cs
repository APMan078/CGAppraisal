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

            lblIsEdit.Text = "New";

            if (!IsPostBack)
            {
                grdItems.DataSource = GetTableWithNoData(); // get first initial data
                grdItems.DataBind();
            }

        }
        public DataTable GetTableWithInitialData() // this might be your sp for select
        {
            DataTable table = new DataTable();
            table.Columns.Add("Items", typeof(string)); 
             
            return table;
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            DataTable dt = GetTableWithNoData(); // get select column header only records not required
            DataRow dr;
            int x = 0;
            foreach (GridViewRow gvr in grdItems.Rows)
            {
                x = x + 1;
                dr = dt.NewRow(); 
               // TextBox txtItem = gvr.FindControl("txtRowNo") as TextBox;
                TextBox txtDescription = gvr.FindControl("txtPaymentDetails") as TextBox;
                TextBox txtAmount = gvr.FindControl("txtAmount") as TextBox;

                dr["RowNo"] = x;
                dr["PaymentDetails"] = txtDescription.Text;
                dr["Amount"] = txtAmount.Text;

                dt.Rows.Add(dr); // add grid values in to row and add row to the blank table
            }

            dr = dt.NewRow(); // add last empty row
            dt.Rows.Add(dr);

            grdItems.DataSource = dt; // bind new datatable to grid
            grdItems.DataBind();
        }
        public DataTable GetTableWithNoData() // returns only structure if the select columns
        {
            DataTable table = new DataTable();
            table.Columns.Add("RowNo", typeof(string));
            table.Columns.Add("PaymentDetails", typeof(string));
            table.Columns.Add("Amount", typeof(string));

            table.TableName = "ItemsPaymentDetails";
            return table;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";
            if(string.IsNullOrEmpty(txtBatchReference.Text))
            {
                msg = "Reference number is required.";
            }
            if(string.IsNullOrEmpty(txtAccountName.Text))
            {
                msg += "\nReference number is required.";
            }
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
        }
    }
}