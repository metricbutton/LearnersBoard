<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="Learner_s_Board.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card bg-dark text-white">
                    <div class="card-body">

                        <div class="row">
                                <div class="col">
                                    <center>
                                        <img width="150px" src="imgs/admin.png"/>
                                    </center>
                                </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <center>
                                        <h3>Admin Login</h3>
                                    </center>
                                </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                        </div>


                        <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <label>Admin ID</label>
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Admin ID"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ID is required" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="form-group">
                                        <label>Password</label>
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required" ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>

                                    </div>

                                    <div class="form-group">
                                        <br/>
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />

                                    </div>
                                  

                                    

                                </div>
                        </div>


                    </div>
                </div>

               
            </div>
            
        </div>
    </div>
    <br>
</asp:Content>
