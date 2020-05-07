using SampleApp.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp.settings
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/");
            }
        }
        void loadItem()
        {
            lvItems.Items.Clear();
            using (DataTable dt = DataProcess.LoadPayment(string.Empty, txtKeyword.Text + "▲▲▲"))
            {
                //if (dt.Rows.Count == 0)
                //{
                //    return;
                //}

                lvItems.DataSource = dt;
                lvItems.DataBind();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            loadItem();
        }
         
        protected void btnupdt_Click(object sender, EventArgs e)
        {
            LinkButton item = (LinkButton)sender;
            if (item.CommandArgument != null)
            {
                Response.Redirect("~/settings/paymentDetails?id=" + item.CommandArgument);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", "alert(\"Item is not Exist!\");", true);
                lvItems.Items.Clear();
            }
        }

        protected void lvItems_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvItems.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadItem();
        }

        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            loadItem();
        }

        protected void createPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/settings/paymentDetails/");
        }
    }
}