using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleApp.settings
{
    public partial class bank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            txtfrom.Text = firstDayOfMonth.ToString("MM/dd/yyyy");
            txtto.Text = lastDayOfMonth.ToString("MM/dd/yyyy");

        }

        protected void createBank_Click(object sender, EventArgs e)
        {

        }
        protected void clndrfrom_SelectionChanged(object sender, EventArgs e)
        {
            txtfrom.Text = clndrfrom.SelectedDate.ToString("MM/dd/yyyy");
            clndrfrom.Visible = false;
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

        protected void lbTo_Click(object sender, EventArgs e)
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

        protected void clndrto_SelectionChanged(object sender, EventArgs e)
        {
            txtto.Text = clndrfrom.SelectedDate.ToString("MM/dd/yyyy");
            clndrto.Visible = false;
        }
    }
}