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
    public partial class admininstitutemanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfInstituteExists())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.warning('Institute with this ID already Exist. You cannot add another Institute with the same Institute ID')", true);
                //Response.Write("<script>alert('Institute with this ID already Exist. You cannot add another Institute with the same Institute ID');</script>");
            }
            else
            {
                addNewInstitute();
            }
        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfInstituteExists())
            {
                updateInstitute();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Institute does not exist')", true);
                //Response.Write("<script>alert('Institute does not exist');</script>");
            }
        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfInstituteExists())
            {
                deleteInstitute();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Institute does not exist')", true);
                //Response.Write("<script>alert('Institute does not exist');</script>");
            }
        }

        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getInstituteByID();
        }

        void addNewInstitute()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO institute_master_tbl(name,affiliation,type,city,state) values(@name,@affiliation,@type,@city,@state)", con);

                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@affiliation", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@type", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList2.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Institute added Successfully')", true);
                //Response.Write("<script>alert('Institute added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfInstituteExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from institute_master_tbl where institute_id='" + TextBox1.Text.Trim() + "';", con);
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

        void updateInstitute()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE institute_master_tbl SET name=@name,affiliation=@affiliation,type=@type,city=@city,state=@state WHERE institute_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@affiliation", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@type", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList2.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Institute Updated Successfully')", true);
                //Response.Write("<script>alert('Institute Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteInstitute()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from institute_master_tbl WHERE institute_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Institute Deleted Successfully')", true);
                //Response.Write("<script>alert('Institute Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getInstituteByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from institute_master_tbl where institute_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox4.Text = dt.Rows[0][2].ToString();
                    DropDownList1.Text = dt.Rows[0][3].ToString();
                    TextBox3.Text = dt.Rows[0][4].ToString();
                    DropDownList2.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.warning('Invalid Institute ID')", true);
                    //Response.Write("<script>alert('Invalid Institute ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            DropDownList1.SelectedValue = "Select Type";
            DropDownList2.SelectedValue = "Select State";
        }

        
    }
}