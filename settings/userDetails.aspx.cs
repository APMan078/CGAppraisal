using SampleApp.Controller;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp.settings
{
    public partial class userDetails : System.Web.UI.Page
    {
        int id = -1;
        bool isEdit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/");
            }
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != "")
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                }
                if (!string.IsNullOrEmpty(id.ToString()))
                {
                    isEdit = true;
                    using (var db = new CG_AppraisalEntities())
                    {
                        var userItems = db.SetUsers.Where(x => x.Id == id).ToList();

                        foreach (var item in userItems)
                        {
                            txtFirstname.Text = item.FirstName;
                            txtMiddlename.Text = item.MiddleName;
                            txtLastname.Text = item.LastName;
                            isActive.Checked = item.IsActive ?? false;
                        }
                    }
                    //using (DataTable dt = DataProcess.LoadPayment(id, "▲▲▲"))
                    //{
                    //    foreach (DataRow dr in dt.Rows)
                    //    {
                    //        txtName.Text = dr["name"].ToString();
                    //        isActive.Checked = (Convert.ToBoolean(dr["IsActive"].ToString() == "" ? "false" : dr["IsActive"].ToString()));
                    //        txtDefaultAmount.Text = dr["AccountNumber"].ToString();
                    //    }
                    //}
                }
            }
            else
            {
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

        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/settings/user");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = "";

            using (CG_AppraisalEntities context = new CG_AppraisalEntities())
            {
                if (isEdit)
                {
                    SetUser item = context.SetUsers.Where(x => x.Id == id).First();

                    item.FirstName = txtFirstname.Text;
                    item.LastName = txtLastname.Text;
                    item.MiddleName = txtMiddlename.Text;
                    item.AccessId = 1;
                    item.IsActive = isActive.Checked;
                    item.Password = PubFunc.Encrypt(txtUsername.Text);
                    item.Username = PubFunc.Encrypt(txtPassword.Text);

                    context.SaveChanges();
                }
                else
                {
                    var item = context.SetUsers.Add(new SetUser()
                    {
                        FirstName = txtFirstname.Text,
                        LastName = txtLastname.Text,
                        MiddleName = txtMiddlename.Text,
                        AccessId = 1,
                        DateEncoded = DateTime.Now,
                        IsActive = isActive.Checked,
                        Password = PubFunc.Encrypt(txtPassword.Text),
                        Username = PubFunc.Encrypt(txtUsername.Text)
                    });
                    context.SetUsers.Add(item);
                    context.SaveChanges();
                }


                if (msg != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "ServerControlScript", @"alert(\" + msg + "\");", true);
                    Response.Redirect("~/settings/branch");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                       "ServerControlScript", @"alert(\Error in saving\);", true);
                }
            }
        }
    }
}