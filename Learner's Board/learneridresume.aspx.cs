using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Learner_s_Board
{
    public partial class learneridresume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["learner_id"] = TextBox1.Text.Trim();
            Response.Redirect("resume.aspx");
        }
    }
}