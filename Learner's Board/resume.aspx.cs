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
    public partial class resume : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Session["learner_id"].ToString();
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from learner_master_tbl where learner_id='" + id + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);





                if (dt.Rows.Count >= 1)
                {
                    Label6.Text = dt.Rows[0][10].ToString(); //Learner ID
                    Label1.Text = dt.Rows[0][0].ToString(); //Fullname
                    Label9.Text = dt.Rows[0][0].ToString(); //Fullname
                    Label2.Text = dt.Rows[0][8].ToString(); //Username
                    Session["learner_username"] = dt.Rows[0][8].ToString();
                    String degree_id = dt.Rows[0][12].ToString();
                    String institute_id = dt.Rows[0][7].ToString();

                    SqlCommand cmd1 = new SqlCommand("SELECT degree_name from degree_master_tbl where degree_id='" + degree_id + "';", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    Label8.Text = dt1.Rows[0][0].ToString(); //Degree

                    SqlCommand cmd2 = new SqlCommand("SELECT name from institute_master_tbl where institute_id='" + institute_id + "';", con);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    Label4.Text = dt2.Rows[0][0].ToString(); //Institute
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.warning('Invalid Learner ID')", true);
                    //Response.Write("<script>alert('Invalid Coordinator ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewschoolrecords.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewcertificates.aspx");
        }

        protected void LinkButton13_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewcollegerecords.aspx");
        }
    }
}