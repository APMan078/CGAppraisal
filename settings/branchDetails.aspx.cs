using SampleApp.Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp.settings
{
    public partial class branchDetails : System.Web.UI.Page
    {
        ArrayList arr = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!Page.IsPostBack)
            {
                loadCbItems();
                id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    isEdit = true;
                    using (DataTable dt = DataProcess.LoadBranch(id, "▲▲▲"))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            txtName.Text = dr["name"].ToString();
                            cmbBank.Text = dr["BankName"].ToString();
                            isActive.Checked = (Convert.ToBoolean(dr["IsActive"].ToString() == "" ?
                                                    "false" : dr["IsActive"].ToString()));
                            txtAccountNo.Text = dr["AccountNumber"].ToString();
                        }
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    isEdit = true;
                    id = Request.QueryString["id"];
                }
                else
                {
                    isEdit = false;
                }
            }
        }
        void loadCbItems()
        {
            arr.Clear();
            cmbBank.Items.Clear();
            using (DataTable dt = DataProcess.LoadBank(string.Empty, "▲▲▲true"))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    arr.Add(dr["id"].ToString());
                    cmbBank.Items.Add(dr["name"].ToString());
                }
            }
            if (cmbBank.Items.Count > 0)
            {
                cmbBank.SelectedIndex = 0;
            }
        }
        string id = "";
        bool isEdit = false;
        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/settings/branch");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string msg = DataProcess.SaveUpdateBankDetails(isEdit, id + "▲" + txtName.Text + "▲" + isActive.Checked + "▲" + arr[cmbBank.SelectedIndex] + "▲" + txtAccountNo.Text + "▲");
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