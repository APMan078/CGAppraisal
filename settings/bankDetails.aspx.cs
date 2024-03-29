﻿using SampleApp.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp.settings
{
    public partial class bankDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/");
            }
            if (!Page.IsPostBack)
            {
                id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    isEdit = true;
                    using (DataTable dt = DataProcess.LoadBank(id, "▲▲▲"))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            txtName.Text = dr["name"].ToString();
                            isActive.Checked = (Convert.ToBoolean(dr["IsActive"].ToString() == "" ?
                                                    "false" : dr["IsActive"].ToString()));
                        }
                    } 
                }
            }
            else
            {
                if(!string.IsNullOrEmpty(Request.QueryString["id"]))
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
        string id = "";
        bool isEdit = false; 
        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/settings/bank");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool x = Convert.ToBoolean(isActive.Checked);
            string msg = DataProcess.SaveUpdateBank(isEdit, id + "▲" + txtName.Text + "▲" + isActive.Checked);
            if(msg != "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "ServerControlScript", @"alert(\" + msg + "\");", true);
                Response.Redirect("~/settings/bank");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                   "ServerControlScript", @"alert(\Error in saving\);", true);
            }
        }
    }
}