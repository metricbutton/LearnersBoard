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
    public partial class admincoordinatormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            { 
            GridView1.DataBind();
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            SqlCommand com = new SqlCommand("select institute_id,name from institute_master_tbl", con) ;

            SqlDataReader sdr = com.ExecuteReader();
            while(sdr.Read())
            {
                ListItem item = new ListItem();
                item.Text = sdr["name"].ToString();
                //item.Value = sdr["name"].ToString();
                item.Value = sdr["institute_id"].ToString();
                DropDownList1.Items.Add(item);

            }

            
            con.Close();
            DropDownList1.Items.Insert(0, new ListItem("Select Institute", "0"));
            }
        }

        
        
        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfCoordinatorExists())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.warning('Coordinator with this ID already Exist. You cannot add another Coordinator with the same Coordinator ID')", true);
                //Response.Write("<script>alert('Coordinator with this ID already Exist. You cannot add another Coordinator with the same Coordinator ID');</script>");
            }
            else
            {
                addNewCoordinator();
                GridView1.DataBind();
            }
        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfCoordinatorExists())
            {
                updateCoordinator();
                GridView1.DataBind();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Coordinator does not exist')", true);
                //Response.Write("<script>alert('Coordinator does not exist');</script>");
            }
        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfCoordinatorExists())
            {
                deleteCoordinator();
                GridView1.DataBind();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Coordinator does not exist')", true);
                //Response.Write("<script>alert('Coordinator does not exist');</script>");
            }
        }

        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getCoordinatorByID();
        }

        void addNewCoordinator()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO coordinator_master_tbl(name,institute_id,email,username,password) values(@name,@institute_id,@email,@username,@password)", con);

                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@institute_id", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@email", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@username", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox5.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Coordinator added Successfully')", true);
                //Response.Write("<script>alert('Coordinator added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfCoordinatorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from coordinator_master_tbl where id='" + TextBox1.Text.Trim() + "';", con);
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

        void updateCoordinator()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE coordinator_master_tbl SET name=@name,institute_id=@institute_id WHERE id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@institute_id", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@email", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Coordinator Updated Successfully')", true);
                //Response.Write("<script>alert('Coordinator Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteCoordinator()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from coordinator_master_tbl WHERE id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Coordinator Deleted Successfully')", true);
                //Response.Write("<script>alert('Coordinator Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void getCoordinatorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from coordinator_master_tbl where id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);





                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();

                    //TextBox4.Text = dt.Rows[0][2].ToString();
                    TextBox6.Text = dt.Rows[0][3].ToString();
                    String id = dt.Rows[0][2].ToString();

                    SqlCommand cmd1 = new SqlCommand("SELECT * from institute_master_tbl where institute_id='" + id + "';", con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    DropDownList1.ClearSelection();
                    DropDownList1.Items.FindByText(dt1.Rows[0][1].ToString()).Selected = true;

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.warning('Invalid Coordinator ID')", true);
                    //Response.Write("<script>alert('Invalid Coordinator ID');</script>");
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
            //DropDownList1.SelectedValue = "select";
            DropDownList1.SelectedIndex = -1;
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        
    }
}