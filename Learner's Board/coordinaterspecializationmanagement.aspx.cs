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
    public partial class coordinaterspecializationmanagement1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                GridView1.DataBind();
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand com = new SqlCommand("select degree_id,degree_name from degree_master_tbl", con);

                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = sdr["degree_name"].ToString();
                    //item.Value = sdr["name"].ToString();
                    item.Value = sdr["degree_id"].ToString();
                    DropDownList1.Items.Add(item);

                }


                con.Close();
                DropDownList1.Items.Insert(0, new ListItem("Select Degree", "0"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e) //Go
        {
            getSpecializationByID();
        }

        protected void Button2_Click(object sender, EventArgs e) //Add
        {
            if (checkIfSpecializationExists())
            {
                Response.Write("<script>alert('Specialization with this ID already Exist. You cannot add another Specialization with the same Specialization ID');</script>");
            }
            else
            {
                addNewSpecialization();
                GridView1.DataBind();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) //Update
        {
            if (checkIfSpecializationExists())
            {
                updateSpecialization();
                GridView1.DataBind();

            }
            else
            {
                Response.Write("<script>alert('Specialization does not exist');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e) //Delete
        {
            if (checkIfSpecializationExists())
            {
                deleteSpecialization();
                GridView1.DataBind();

            }
            else
            {
                Response.Write("<script>alert('Specialization does not exist');</script>");
            }
        }

        void addNewSpecialization()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO specialization_master_tbl(specialization_name,degree_id) values(@specialization_name,@degree_id)", con);

                cmd.Parameters.AddWithValue("@specialization_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@degree_id", DropDownList1.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Specialization added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfSpecializationExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from specialization_master_tbl where specialization_id='" + TextBox1.Text.Trim() + "';", con);
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

        void updateSpecialization()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE specialization_master_tbl SET specialization_name=@specialization_name,degree_id=@degree_id WHERE specialization_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@specialization_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@degree_id", DropDownList1.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Specialization Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteSpecialization()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from specialization_master_tbl WHERE specialization_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Specialization Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getSpecializationByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from specialization_master_tbl where specialization_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);





                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();

                    //TextBox4.Text = dt.Rows[0][2].ToString();
                    String id = dt.Rows[0][2].ToString();

                    SqlCommand cmd1 = new SqlCommand("SELECT * from degree_master_tbl where degree_id='" + id + "';", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    DropDownList1.ClearSelection();
                    DropDownList1.Items.FindByText(dt1.Rows[0][1].ToString()).Selected = true;

                }
                else
                {
                    Response.Write("<script>alert('Invalid Specialization ID');</script>");
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
            //DropDownList1.Items.FindByText("Select Degree").Selected = true;
            DropDownList1.SelectedIndex = -1;
            //DropDownList1.SelectedValue = "";
        }
    }
}