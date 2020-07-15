using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp.transaction
{
    public partial class appraisal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime now = DateTime.Now;
                var datestart = new DateTime(DateTime.Now.Year, 1, 1);
                var dateend = new DateTime(DateTime.Now.Year, 12, 31);

                txtfrom.Text = datestart.ToString("MM/dd/yyyy");
                txtto.Text = dateend.ToString("MM/dd/yyyy");
            }
            //if (Session["id"] == null)
            //{
            //    Response.Redirect("~/");
            //}

        }

        void loadItem()
        {
            lvItems.Items.Clear();

            using (CG_AppraisalEntities db = new CG_AppraisalEntities())
            { 
                if (txtKeyword.Text != "")
                {
                    lvItems.DataSource = db.TxnAppraisals.Where(x => x.BatchCode.Contains(txtKeyword.Text)).ToList();
                }
                else
                {
                    lvItems.DataSource = db.TxnAppraisals.ToList();
                }
                lvItems.DataBind();
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            loadItem();
        }
        protected void clndrto_SelectionChanged(object sender, EventArgs e)
        {
            txtto.Text = clndrto.SelectedDate.ToString("MM/dd/yyyy");
            clndrto.Visible = false;
        }
        protected void clndrfrom_SelectionChanged(object sender, EventArgs e)
        {
            txtfrom.Text = clndrfrom.SelectedDate.ToString("MM/dd/yyyy");
            clndrfrom.Visible = false;
        }
        protected void lbto_Click(object sender, EventArgs e)
        {
            if (!clndrto.Visible)
            {
                clndrto.Visible = true;
            }
            else
            {
                clndrto.Visible = false;
            }

        }
        protected void lbfrom_Click(object sender, EventArgs e)
        {
            if (!clndrfrom.Visible)
            {
                clndrfrom.Visible = true;
            }
            else
            {
                clndrfrom.Visible = false;
            }
        }
        protected void lvItems_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lvItems.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loadItem();
        }

        protected void createItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/transaction/appraisalDetails/");
        }
    }
}