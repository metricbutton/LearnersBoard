<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="learnerlogin.aspx.cs" Inherits="Learner_s_Board.learnerlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br><br>
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
                                        <h3>Learner Login</h3>
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
                                        <label>Learner ID</label>
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Learner ID"></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label>Password</label>
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>

                                    </div>

                                    <div class="form-group">
                                        <br/>
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />

                                    </div>

                                    

                                </div>
                        </div>


                    </div>
                </div>
<br><br>
            </div>
            
        </div>
    </div>
</asp:Content>
