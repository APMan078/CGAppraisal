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
    public partial class paymentDetails : System.Web.UI.Page
    {

        string id = "";
        bool isEdit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    isEdit = true;
                    using (DataTable dt = DataProcess.LoadPayment(id, "▲▲▲"))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            txtName.Text = dr["name"].ToString(); 
                            isActive.Checked = (Convert.ToBoolean(dr["IsActive"].ToString() == "" ? "false" : dr["IsActive"].ToString()));
                            txtDefaultAmount.Text = dr["AccountNumber"].ToString();
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
        protected void btnBackToList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/settings/payment");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}