using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Learner_s_Board
{
    public partial class collegeupload : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = true;
            TextBox1.Text = Session["username"].ToString();

            if (!IsPostBack)
            {


                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                string institute_id = Session["institute_id"].ToString();
                SqlCommand com = new SqlCommand("select institute_id,name from institute_master_tbl where type='College' AND institute_id = '" + institute_id + "'", con);

                SqlDataReader sdr = com.ExecuteReader();
                while (sdr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = sdr["name"].ToString();
                    item.Value = sdr["institute_id"].ToString();
                    DropDownList1.Items.Add(item);

                }


                con.Close();
                DropDownList1.Items.Insert(0, new ListItem("Select College", "0"));


               SqlConnection con1 = new SqlConnection(strcon);
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();

                }
                String degree = Session["degree_id"].ToString();
                SqlCommand cmd1 = new SqlCommand("select degree_term from degree_master_tbl where degree_id='" + degree + "' ORDER BY degree_term DESC", con1);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                int term = (int)dt1.Rows[0][0];

                for (var i = 1; i <= term; i++)
                {
                    var item = new ListItem
                    {
                        Text = i.ToString(),
                        Value = i.ToString()
                    };
                    DropDownList2.Items.Add(item);
                }
                DropDownList2.Items.Insert(0, new ListItem("Select Semester", "0"));
                DropDownList2.DataBind();

                SqlConnection con2 = new SqlConnection(strcon);
                if (con2.State == ConnectionState.Closed)
                {
                    con2.Open();

                }
                String name = Session["username"].ToString(); ;
                SqlCommand cmd2 = new SqlCommand("select semester from college_document_master_tbl where learner_username='" + name + "' ORDER BY semester DESC", con2);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);

                if (dt2 != null)
                {
                    if (dt2.Rows.Count > 0)
                    {
                        int Class = (int)dt2.Rows[0][0];
                        for (int i = 1; i <= Class; i++)
                        {
                            DropDownList2.Items.FindByValue(i.ToString()).Attributes.Add("Disabled", "Disabled");
                        }


                        for (int i = Class + 2; i <= term; i++)
                        {
                            DropDownList2.Items.FindByValue(i.ToString()).Attributes.Add("Disabled", "Disabled");
                        }
                    }
                    else
                    {
                        for (int i = 2; i <= term; i++)
                        {
                            DropDownList2.Items.FindByValue(i.ToString()).Attributes.Add("Disabled", "Disabled");
                        }
                    }
                }
                

                        

                
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                string ext = Path.GetExtension(FileUpLoad1.FileName);
                string name = Session["username"].ToString() + DropDownList2.SelectedItem.Value + ext;
                string filePath = @"C:\temp\College\" + name;
                FileUpLoad1.SaveAs(@"C:\temp\College\" + name);
                //string filePath = @"C:\temp\" + FileUpLoad1.FileName;
                //FileUpLoad1.SaveAs(@"C:\temp\" + FileUpLoad1.FileName);
                //Label1.Text = "File Uploaded: " + FileUpLoad1.FileName;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.success('File Uploaded')", true);
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO college_document_master_tbl(learner_username, institute_id,semester,status,document_path) values(@learner_username,@institute_id,@semester,@status,@document_path)", con);

                    cmd.Parameters.AddWithValue("@learner_username", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@institute_id", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@semester", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@status", "Pending");
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
        }
    }
}