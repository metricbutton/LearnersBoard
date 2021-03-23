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
    public partial class changecoordinator : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand com = new SqlCommand("select id,name from coordinator_master_tbl WHERE institute_id='" + Session["institute_id"].ToString() + "'", con);

                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = sdr["name"].ToString();
                    item.Value = sdr["id"].ToString();
                    DropDownList6.Items.Add(item);

                }
                DropDownList6.Items.Insert(0, new ListItem("Select Coordinator", "0"));
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE learner_master_tbl SET coordinator_id=@coordinator_id WHERE learner_id='" + Session["learner_id"].ToString() + "'", con);

                cmd.Parameters.AddWithValue("@coordinator_id", DropDownList6.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Coordinator Updated Successfully')", true);
                //Response.Write("<script>alert('Coordinator Updated Successfully');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}