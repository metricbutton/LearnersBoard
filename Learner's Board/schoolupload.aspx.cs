using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Learner_s_Board
{
    public partial class schoolupload : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //For School
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
            String name = Session["username"].ToString();
            SqlCommand cmd = new SqlCommand("select standard from school_document_master_tbl where learner_username='" + name + "' ORDER BY standard DESC", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int standard = (int)dt.Rows[0][0];
                    if (standard == 10)
                    {
                        DropDownList2.Items.FindByValue("10").Attributes.Add("Disabled", "Disabled");
                    }
                    else if (standard == 12)
                    {
                        DropDownList2.Items.FindByValue("10").Attributes.Add("Disabled", "Disabled");
                        DropDownList2.Items.FindByValue("12").Attributes.Add("Disabled", "Disabled");
                    }
                }
                else
                {
                    DropDownList2.Items.FindByValue("12").Attributes.Add("Disabled", "Disabled");
                }
            }
            if (!IsPostBack)
            {
                TextBox1.ReadOnly = true;
                TextBox1.Text = Session["username"].ToString();

                SqlConnection con1 = new SqlConnection(strcon);
                con1.Open();

                SqlCommand com1 = new SqlCommand("select institute_id,name from institute_master_tbl where type='School'", con1);

                SqlDataReader sdr1 = com1.ExecuteReader();
                while (sdr1.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = sdr1["name"].ToString();
                    item.Value = sdr1["name"].ToString();
                    DropDownList1.Items.Add(item);

                }


                con1.Close();
                DropDownList1.Items.Insert(0, new ListItem("Select School", "0"));

                //For School
                //SqlConnection con = new SqlConnection(strcon);
                //if (con.State == ConnectionState.Closed)
                //{
                //    con.Open();

                //}
                //String name = Session["username"].ToString();
                //SqlCommand cmd = new SqlCommand("select standard from school_document_master_tbl where learner_username='" + name + "' ORDER BY standard DESC", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //da.Fill(dt);
                

                //if (dt != null)
                //{
                //    if (dt.Rows.Count > 0)
                //    {
                //        int standard = (int)dt.Rows[0][0];
                //        if (standard == 10)
                //        {
                //            DropDownList2.Items.FindByValue("10").Attributes.Add("Disabled", "Disabled");
                //        }
                //        else if (standard == 12)
                //        {
                //            DropDownList2.Items.FindByValue("10").Attributes.Add("Disabled", "Disabled");
                //            DropDownList2.Items.FindByValue("12").Attributes.Add("Disabled", "Disabled");
                //        }
                //    }
                //    else
                //    {
                //        DropDownList2.Items.FindByValue("12").Attributes.Add("Disabled", "Disabled");
                //    }
                //}
            }

            


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpLoad1.HasFile)
            {
                string ext = Path.GetExtension(FileUpLoad1.FileName);
                string name = Session["username"].ToString() + DropDownList2.SelectedItem.Value + ext;
                string filePath = @"C:\temp\School\" + name;
                FileUpLoad1.SaveAs(@"C:\temp\School\" + name);
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

                    SqlCommand cmd = new SqlCommand("INSERT INTO school_document_master_tbl(learner_username,learner_fullname, institute_name,standard,status,coordinator_id,document_path) values(@learner_username,@learner_fullname,@institute_name,@standard,@status,@coordinator_id,@document_path)", con);

                    cmd.Parameters.AddWithValue("@learner_username", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@learner_fullname", Session["fullname"].ToString());
                    cmd.Parameters.AddWithValue("@institute_name", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@standard", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@status", "Pending");
                    cmd.Parameters.AddWithValue("@coordinator_id", Session["coordinator_id"].ToString());
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
            oScript.Attributes.Add("content", "5; url='https://localhost:44312/schoolupload.aspx'");
            Page.Header.Controls.Add(oScript);
        }
    }
}