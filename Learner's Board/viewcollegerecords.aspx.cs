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
    public partial class viewcollegerecords : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            updateGridView();
        }

        void updateGridView()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("SELECT document_id,learner_username,learner_fullname,institute_name,semester from college_document_master_tbl where learner_username='" + Session["learner_username"].ToString() + "' and status='Approved'; ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT document_path from college_document_master_tbl where document_id='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    string path = Convert.ToString(dt.Rows[0][0]);
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
    }
}