using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp.transaction
{
    public partial class appraisalDetailsPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["doneItem"] == null)
            {
                Response.Redirect("~/transaction/appraisalDetails/");
            }

        }

        protected void btnAddRowItems_Click(object sender, EventArgs e)
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



    }
}