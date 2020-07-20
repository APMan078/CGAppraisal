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
    public partial class user : System.Web.UI.Page
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

            using (CG_AppraisalEntities db = new CG_AppraisalEntities())
            {
                if (txtKeyword.Text != "")
                {
                    lvItems.DataSource = db.SetUsers.
                                Where(x => x.FirstName.Contains(txtKeyword.Text) || 
                                        x.LastName.Contains(txtKeyword.Text)).ToList();
                }
                else
                {
                    lvItems.DataSource = db.SetUsers.ToList();
                }
                lvItems.DataBind();
            }
        }
        protected void btnupdt_Click(object sender, EventArgs e)
        {
            LinkButton item = (LinkButton)sender;
            if (item.CommandArgument != null)
            {
                Response.Redirect("~/settings/userDetails?id=" + item.CommandArgument);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", "alert(\"Item is not Exist!\");", true);
                lvItems.Items.Clear();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            loadItem();
        }
        protected void lvItems_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvItems.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadItem();
        }

        protected void createPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/settings/userDetails/");
        }
    }
}