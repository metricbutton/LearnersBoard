using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Learner_s_Board
{
    public partial class schooluploadtypes : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con1 = new SqlConnection(strcon);
            if (con1.State == ConnectionState.Closed)
            {
                con1.Open();

            }
            String shortname = "B Com";
            SqlCommand cmd1 = new SqlCommand("select degree_term from degree_master_tbl where short_name='" + shortname + "' ORDER BY degree_term DESC", con1);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            int term = (int) dt1.Rows[0][0];

            for (var i = 1; i <= term; i++)
            {
                var item = new ListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                };
                ddlSearchColumn2.Items.Add(item);
            }
            ddlSearchColumn2.Items.Insert(0, new ListItem("Please select", ""));

            //var items2 = new List<ListItem>()
            //{
            //    new ListItem("Select Option", ""),
            //    new ListItem("DDL 2 Test 1"),
            //    new ListItem("DDL 2 Test 2"),
            //    new ListItem("DDL 2 Test 3")
            //};

            //ddlSearchColumn2.DataSource = items2;
            ddlSearchColumn2.DataBind();


            //For College
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            String name = "Dhaval";
            SqlCommand cmd = new SqlCommand("select class from testtest where name='" + name + "' ORDER BY class DESC", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int Class = (int)dt.Rows[0][0] + 2;

            for (int i = Class; i <= term; i++)
            {
                ddlSearchColumn2.Items.FindByValue(i.ToString()).Attributes.Add("Disabled", "Disabled");
            }





            //For School
            //SqlConnection con = new SqlConnection(strcon);
            //    if (con.State == ConnectionState.Closed)
            //    {
            //        con.Open();

            //    }
            //    String name = "AA";
            //    SqlCommand cmd = new SqlCommand("select * from testtest where name='" + name + "' ORDER BY class DESC", con);
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {

            //    }
            //    else
            //    {
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.warning('No rows')", true);
            //        DropDownList1.Items.FindByValue("12").Attributes.Add("Disabled", "Disabled");
            //        //Response.Write("<script>alert('Invalid credentials');</script>");
            //    }






            //var items2 = new List<ListItem>()
            //{
            //    new ListItem("Select Option", ""),
            //    new ListItem("10"),
            //    new ListItem("12")
            //};

            //ddlSearchColumn2.DataSource = items2;
            //ddlSearchColumn2.DataBind();



            //bool display = true;
            //if (display)
            //{
            //    twelth.Attributes.Add("visible", "false");
            //    twelth.Visible = false;
            //    twelth.Attributes.Add("visibility", "hidden");

            //}

        }
    }
}