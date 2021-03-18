using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Learner_s_Board
{
    public partial class approvecollegerecords : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            updateGridView();
        }

        protected void Button2_Click(object sender, EventArgs e) //View Record
        {
            //string FilePath = Server.MapPath("C:\temp\e-Notes_PDF_All-Units_27042019074900AM.pdf");
            string path = Convert.ToString(HiddenField1.Value);
            //string FilePath = @"C:\temp\e-Notes_PDF_All-Units_27042019074900AM.pdf";
            string FilePath = path;
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e) //Approve Button
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE college_document_master_tbl SET status=@status WHERE document_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@status", "Approved");

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Approved Successfully')", true);
                //Response.Write("<script>alert('Institute Updated Successfully');</script>");
                clearForm();
                updateGridView();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e) //Disapprove Button
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE college_document_master_tbl SET status=@status WHERE document_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@status", "Disapproved");

                cmd.ExecuteNonQuery();
                con.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('Disapproved Successfully')", true);
                //Response.Write("<script>alert('Institute Updated Successfully');</script>");
                clearForm();
                updateGridView();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e) //Go Button
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from college_document_master_tbl where document_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString(); //Username
                    TextBox8.Text = dt.Rows[0][3].ToString(); //Institute Name
                    TextBox3.Text = dt.Rows[0][4].ToString(); //Semester
                    TextBox4.Text = dt.Rows[0][2].ToString(); //Full Name
                    HiddenField1.Value = dt.Rows[0][7].ToString(); //Document Path
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

        void updateGridView()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT document_id,learner_username,learner_fullname,institute_name,semester from college_document_master_tbl where coordinator_id='" + Session["coordinator_id"].ToString() + "' and status='Pending'; ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox8.Text = "";
        }
    }
}