﻿using System;
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

            LinkButton5.Visible = false; // institute
            LinkButton7.Visible = false; // Coordinator
            LinkButton4.Visible = false; //hellouser
            LinkButton3.Visible = false; // logout link button
            try
            {
              
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button

                    LinkButton5.Visible = false; // institute
                    LinkButton7.Visible = false; // Coordinator
                    LinkButton4.Visible = false; //hellouser
                    LinkButton3.Visible = false; // logout link button







                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = true; // user login link button
                    LinkButton2.Visible = true; // sign up link button

                    LinkButton5.Visible = false; // institute
                    LinkButton7.Visible = false; // Coordinator
                    LinkButton3.Visible = false; // logout link button
                    LinkButton4.Text = "Hello " + Session["username"].ToString();


                    

                }

                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton5.Visible = true; // institute
                    LinkButton7.Visible = true; // Coordinator
                    LinkButton3.Visible = true; // logout link button
                    LinkButton4.Text = "Hello Admin";


                   
                }
                else if (Session["role"].Equals("coordinator"))
                {
                    LinkButton1.Visible = false; // user login link button
                    LinkButton2.Visible = false; // sign up link button

                    LinkButton5.Visible = false; // institute
                    LinkButton7.Visible = false; // Coordinator
                    LinkButton3.Visible = true; // logout link button
                    LinkButton4.Text = "Hello " + Session["username"].ToString();




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
    }
}