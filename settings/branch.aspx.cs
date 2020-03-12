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
    public partial class branch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void loadItem()
        {
            lvItems.Items.Clear();
            using (DataTable dt = DataProcess.LoadBranch(string.Empty, txtKeyword.Text + "▲▲▲"))
            {
                if (dt.Rows.Count == 0)
                {
                    return;
                }

                lvItems.DataSource = dt;
                lvItems.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            loadItem();
        }

        protected void createBank_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/settings/branchDetails/");
        }

        protected void btnupdt_Click(object sender, EventArgs e)
        {
            LinkButton item = (LinkButton)sender;
            if (item.CommandArgument != null)
            {
                Response.Redirect("~/settings/branchDetails?id=" + item.CommandArgument);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", "alert(\"Item is not Exist!\");", true);
                lvItems.Items.Clear();
            }
        }
    }
}