<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="Learner_s_Board.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <img src="imgs/uppercover.jpg" class="img-fluid"/>
    </section>

    <div class="container text-white">
        <div class="row">
            <div class="col-12">
                <center>
                    <h2>Our Features</h2>
                    <p><b>Our 3 Primary Features</b></p>
                </center>
            </div>
        </div>

        <div class="row">
                <div class="col-md-4">
                    <center>
                     <img width="150px" src="imgs/digital-inventory.png"/>
                     <h4>Digital Inventory</h4>
                    <p class="text-center">Stores all your academic information and achievements </p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                     <img width="150px" src="imgs/badge.png"/>
                     <h4>View Achievements</h4>
                    <p class="text-center">View all your details in a comprehensive manner</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                     <img width="150px" src="imgs/centralized.png"/>
                     <h4>Centralized Platform</h4>
                    <p class="text-center">A dedicated platform for all scholars</p>
                    </center>
                </div>
        </div>
    </div>

     <section>
         <img src="imgs/bottomcover.png" class="img-fluid"/>
        
    </section>

    <section>
        <div class="container text-white">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our Process</h2>
                    <p><b>We have a Simple 3 Step Process</b></p>
                    </center>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/sign-up.png" />
                     
                     <h4>Sign Up</h4>
                    <p class="text-center">Register yourself by filling the relevant details</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                     <img width="150px" src="imgs/add-file.png"/>
                     <h4>Add Record</h4>
                    <p class="text-center">File your academic information and achievements</p>
                    </center>
                </div>

                <div class="col-md-4">
                    <center>
                     <img width="150px" src="imgs/approved.png"/>
                     <h4>Get It Verified</h4>
                    <p class="text-center">Your details will be verified by respective Corrdinator</p>
                    </center>
                </div>
            </div>
        </div>

    </section>
</asp:Content>

