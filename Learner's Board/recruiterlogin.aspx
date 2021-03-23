<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="recruiterlogin.aspx.cs" Inherits="Learner_s_Board.recruiterlogin" %>
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
                                        <img width="150px" src="imgs/recruiter.png"/>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h3>Recruiter Login</h3>
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
                                    <label>Recruiter Username</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Recruiter Username"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Recruiter Username is required" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>

                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required" ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>

                                <div class="form-group">
                                    <br />
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>

                                </div>
                                  <div class="form-group">
                                        <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button2" runat="server" Text="Forgot Password" OnClick="Button2_Click"/>

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
