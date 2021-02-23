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
    public partial class learnersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            SqlCommand com = new SqlCommand("select institute_id,name from institute_master_tbl", con);  

            SqlDataReader sdr = com.ExecuteReader();
            while (sdr.Read())
            {
                ListItem item = new ListItem();
                item.Text = sdr["name"].ToString();
                item.Value = sdr["institute_id"].ToString();
                DropDownList2.Items.Add(item);

            }


            con.Close();
            DropDownList2.Items.Insert(0, new ListItem("Select Institute", "0"));

            SqlConnection con1 = new SqlConnection(strcon);
            con1.Open();

            SqlCommand com1 = new SqlCommand("select degree_id,degree_name from degree_master_tbl", con1);

            SqlDataReader sdr1 = com1.ExecuteReader();
            while (sdr1.Read())
            {
                ListItem item1 = new ListItem();
                item1.Text = sdr1["degree_name"].ToString();
                item1.Value = sdr1["degree_id"].ToString();
                DropDownList3.Items.Add(item1);

            }


            con1.Close();
            DropDownList3.Items.Insert(0, new ListItem("Select Degree", "0"));
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.warning('Member Already Exist with this Username, try other Username')", true);
                //Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
            }
            else
            {
                signUpNewMember();
            }

        }

        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from learner_master_tbl where username='" + TextBox8.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }


        }



        void signUpNewMember()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO learner_master_tbl(full_name,dob,contact_no,email,state,city,pincode,institute_id,username,password,degree_id,specialization_id,coordinator_id) " +
                    "values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@institute_id,@username,@password,@degree_id,@specialization_id,@coordinator_id)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@institute_id", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@username", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@degree_id", DropDownList3.SelectedItem.Value);
                if ((DropDownList4.SelectedItem.Value == "NULL"))
                {
                    cmd.Parameters.AddWithValue("@specialization_id", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@specialization_id", DropDownList4.SelectedItem.Value);
                }
                cmd.Parameters.AddWithValue("@coordinator_id", DropDownList6.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Sign Up Successful. Go to User Login to Login')", true);
                //Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList4.Items.Clear();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            SqlCommand com = new SqlCommand("select specialization_id,specialization_name from specialization_master_tbl WHERE degree_id='" + DropDownList3.SelectedItem.Value + "'", con);

            SqlDataReader sdr = com.ExecuteReader();
            if(!sdr.HasRows)
            {
                DropDownList4.Items.Insert(0, new ListItem("Select Specialization", "0"));
                DropDownList4.Items.Insert(1, new ListItem("Not Applicable", "NULL"));
            }
            else
            {
                while (sdr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = sdr["specialization_name"].ToString();
                    item.Value = sdr["specialization_id"].ToString();
                    DropDownList4.Items.Add(item);

                }
                DropDownList4.Items.Insert(0, new ListItem("Select Specialization", "0"));
            }

            


            con.Close();
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList6.Items.Clear();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            SqlCommand com = new SqlCommand("select id,name from coordinator_master_tbl WHERE institute_id='" + DropDownList2.SelectedItem.Value + "'", con);

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
}