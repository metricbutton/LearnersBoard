using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Learner_s_Board
{
    public partial class certificateupload : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = true;
            TextBox1.Text = Session["username"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                string ext = Path.GetExtension(FileUpLoad1.FileName);
                string name =  TextBox2.Text + Session["username"].ToString() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ext;
                string filePath = @"C:\temp\Certificate\" + name;
                FileUpLoad1.SaveAs(@"C:\temp\Certificate\" + name);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('File Uploaded')", true);
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO certificate_master_tbl(learner_username,learner_fullname, date,type,status,coordinator_id,event_name,document_path) values(@learner_username,@learner_fullname,@date,@type,@status,@coordinator_id,@event_name,@document_path)", con);

                    cmd.Parameters.AddWithValue("@learner_username", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@learner_fullname", Session["fullname"].ToString());
                    cmd.Parameters.AddWithValue("@date", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@type", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@status", "Pending");
                    cmd.Parameters.AddWithValue("@coordinator_id", Session["coordinator_id"].ToString());
                    cmd.Parameters.AddWithValue("@event_name", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@document_path", filePath);

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
                //Label1.Text = "No File Uploaded.";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('No File Uploaded')", true);
            }
            FileUpLoadValidator.IsValid = true;
            HtmlMeta oScript = new HtmlMeta();
            oScript.Attributes.Add("http-equiv", "REFRESH");
            oScript.Attributes.Add("content", "5; url='https://localhost:44312/certificateupload.aspx'");
            Page.Header.Controls.Add(oScript);
        }
        
    }

}