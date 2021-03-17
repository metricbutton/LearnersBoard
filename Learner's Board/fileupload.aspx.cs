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
    public partial class fileupload : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                string filePath = @"C:\temp\" + FileUpLoad1.FileName;
                FileUpLoad1.SaveAs(@"C:\temp\" + FileUpLoad1.FileName);
                Label1.Text = "File Uploaded: " + FileUpLoad1.FileName;
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO files(file_title, file_path) values(@file_title,@file_path)", con);

                    cmd.Parameters.AddWithValue("@file_title", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@file_path", filePath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('File added Successfully')", true);
                    //Response.Write("<script>alert('Coordinator added Successfully');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Label1.Text = "No File Uploaded.";
            }
        }

        protected void bttnpdf_Click(object sender, EventArgs e)
        {
            //string FilePath = Server.MapPath("C:\temp\e-Notes_PDF_All-Units_27042019074900AM.pdf");
            string FilePath = @"C:\temp\e-Notes_PDF_All-Units_27042019074900AM.pdf";
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }
    }
}