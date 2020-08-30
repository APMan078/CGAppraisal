using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

namespace SampleApp.transaction
{
    public partial class appraisalDetailsItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                var dtCbItems = new DataTable();
                dtCbItems.Columns.Clear();
                dtCbItems.Columns.Add("item", typeof(string));
                dtCbItems.Rows.Clear();

                cbItem.Items.Clear();

                using (CG_AppraisalEntities db = new CG_AppraisalEntities())
                {
                    var _item = db.TxnAppraisalItems.Select(x => x.ItemDescription).Distinct().OrderBy(z => z).ToList();
                    foreach (var x in _item)
                    {
                        cbItem.Items.Add(x);
                    }
                }

                if(dtCbItems.Rows.Count > 0)
                {
                    ViewState["dtCbItems"] = dtCbItems;
                }
                else
                {
                    ViewState["dtCbItems"] = null;
                }
                grdItems.DataSource = GetTableItem();
                grdItems.DataBind();
            }
        }

        public DataTable GetTableItem() // returns only structure if the select columns
        {
            var dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add("RowNo", typeof(string));
            dt.Columns.Add("Item", typeof(string));

            //dr = dt.NewRow();
            //dr["RowNo"] = 1;
            //dr["Item"] = string.Empty;
            //dt.Rows.Add(dr); 

            dt.TableName = "dtItems";
            ViewState["dtItems"] = dt;

            return dt;
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
                        ComboBox txtItem = (ComboBox)grdItems.Rows[rowIndex].Cells[1].FindControl("txtItem");


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
                if (dt.Rows.Count > 0)
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
            } 
        }
        protected void btnAddRowItems_Click(object sender, EventArgs e)
        {
            if (ViewState["dtItems"] != null)
            { 
                DataTable dt = (DataTable)ViewState["dtItems"];
                DataRow dr;
                if (dt.Rows.Count >= 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //extract the TextBox values                         
                        TextBox txtItem = (TextBox)grdItems.Rows[i].Cells[1].FindControl("txtItem");
                        //txtItem.DataSource = (DataTable)ViewState["dtCbItems"];

                        dt.Rows[i]["RowNo"] = i + 1;
                        dt.Rows[i]["Item"] = txtItem.Text;
                    }

                    dr = dt.NewRow(); // add last empty row
                    dr["Item"] = cbItem.Text;

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

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/transaction/appraisalDetails");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}