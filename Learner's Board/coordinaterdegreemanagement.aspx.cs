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
    public partial class coordinaterdegreemanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e) //Go
        {
            getDegreeByID();
        }

        protected void Button2_Click(object sender, EventArgs e) //Add
        {
            if (checkIfDegreeExists())
            {
                Response.Write("<script>alert('Degree with this ID already Exist. You cannot add another Degree with the same Degree ID');</script>");
            }
            else
            {
                addNewDegree();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) //Update
        {
            if (checkIfDegreeExists())
            {
                updateDegree();

            }
            else
            {
                Response.Write("<script>alert('Degree does not exist');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e) //Delete
        {
            if (checkIfDegreeExists())
            {
                deleteDegree();

            }
            else
            {
                Response.Write("<script>alert('Degree does not exist');</script>");
            }
        }

        bool checkIfDegreeExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from degree_master_tbl where degree_id='" + TextBox1.Text.Trim() + "';", con);
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

        void addNewDegree()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO degree_master_tbl(degree_name,short_name,degree_term) values(@degree_name,@short_name,@degree_term)", con);

                cmd.Parameters.AddWithValue("@degree_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@short_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@degree_term", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Degree added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateDegree()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE degree_master_tbl SET degree_name=@degree_name,short_name=@short_name,degree_term=@degree_term WHERE degree_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@degree_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@short_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@degree_term", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Degree Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteDegree()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from degree_master_tbl WHERE degree_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Degree Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getDegreeByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from degree_master_tbl where degree_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox4.Text = dt.Rows[0][2].ToString();
                    TextBox6.Text = dt.Rows[0][3].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Degree ID');</script>");
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
            TextBox4.Text = "";
            TextBox6.Text = "";
        }

    }
}