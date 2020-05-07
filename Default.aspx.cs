using SampleApp.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                Response.Redirect("~/Dashboard.aspx");
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            using (DataTable _dt = DataProcess.Login(txtusername.Text, txtpassword.Text))
            {
                if (_dt.Rows.Count == 0)
                {
                    lblmsg.Text = "Invalid username or password";
                    return;
                }

                foreach (DataRow dr in _dt.Rows)
                {
                    Session["id"] = dr["id"].ToString();
                    Session["name"] = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                }
                Response.Redirect("~/Dashboard");
            }
        }
    }
}