using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Learner_s_Board
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button

            LinkButton6.Visible = false; // degree
            LinkButton8.Visible = false; // specialization
            LinkButton5.Visible = false; // institute
            LinkButton7.Visible = false; // Coordinator
            LinkButton4.Visible = false; //hellouser
            LinkButton3.Visible = false; // logout link button
            LinkButton9.Visible = false; // Add Record
            LinkButton10.Visible = false; // Add Certificate
            try
            {
              
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button

                    LinkButton6.Visible = false; // degree
                    LinkButton8.Visible = false; // specialization
                    LinkButton5.Visible = false; // institute
                    LinkButton7.Visible = false; // Coordinator
                    LinkButton4.Visible = false; //hellouser
                    LinkButton3.Visible = false; // logout link button
                    LinkButton9.Visible = false; // Add Record
                    LinkButton10.Visible = false; // Add Certificate






                }
                else if (Session["role"].Equals("learner"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton6.Visible = false; // degree
                    LinkButton8.Visible = false; // specialization
                    LinkButton5.Visible = false; // institute
                    LinkButton7.Visible = false; // Coordinator
                    LinkButton9.Visible = true; // Add Record
                    LinkButton10.Visible = true; // Add Certificate
                    LinkButton3.Visible = true; // logout link button
                    LinkButton4.Text = "Hello " + Session["username"].ToString();
                    LinkButton4.Visible = true;
                    //LinkButton4.Text = "Hello " + Session["username"].ToString();




                }

                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton6.Visible = false; // degree
                    LinkButton8.Visible = false; // specialization
                    LinkButton5.Visible = true; // institute
                    LinkButton7.Visible = true; // Coordinator
                    LinkButton9.Visible = false; // Add Record
                    LinkButton10.Visible = false; // Add Certificate
                    LinkButton3.Visible = true; // logout link button
                    LinkButton4.Text = "Hello Admin";
                    LinkButton4.Visible = true;



                }
                else if (Session["role"].Equals("coordinator"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton6.Visible = true; // degree
                    LinkButton8.Visible = true; // specialization
                    LinkButton5.Visible = false; // institute
                    LinkButton7.Visible = false; // Coordinator
                    LinkButton9.Visible = false; // Add Record
                    LinkButton10.Visible = false; // Add Certificate
                    LinkButton3.Visible = true; // logout link button
                    LinkButton4.Text = "Hello " + Session["username"].ToString();
                    LinkButton4.Visible = true;




                }
            }
            catch (Exception ex)
            {

            }


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("logintypes.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("learnersignup.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("admininstitutemanagement.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("admincoordinatormanagement.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            LinkButton1.Visible = true; // user login link button
            LinkButton2.Visible = true; // sign up link button

            LinkButton5.Visible = false; // institute
            LinkButton7.Visible = false; // Coordinator
            LinkButton4.Visible = false; //hellouser
            LinkButton3.Visible = false; // logout link button

            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("coordinatordegreemanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("coordinatorspecializationmanagement.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("uploadinstitutetypes.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("certificateupload.aspx");
        }
    }
}