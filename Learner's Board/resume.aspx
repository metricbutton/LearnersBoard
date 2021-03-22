<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="resume.aspx.cs" Inherits="Learner_s_Board.resume" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <br>
    <div class="container">
        <div class="row">
            <div class="col-md-12 mx-auto">

                <div class="card bg-dark text-light">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Resume</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="jumbotron bg-info">
                            <h1 class="text-center" style="font-family: Brush Script MT;"><asp:Label ID="Label9" runat="server" Text="Label"></asp:Label></h1>
                            <%--<p>
                                Bootstrap
                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                is the most popular HTML, CSS, and JS framework for developing
    responsive, mobile-first projects on the web.
                            </p>--%>
                        </div>

                        <%--<div class="row">
                            <div class="col">
                                <center>
                                        <h4>Upload Certificate</h4>
                                    </center>
                            </div>
                        </div>--%>


                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-2">
                                <%--<img width="50px" src="imgs/certificate.png"/>--%>
                                <asp:LinkButton class="btn btn-success btn-lg btn-block" ID="LinkButton2" runat="server">Learner ID</asp:LinkButton>
                            </div>
                            <div class="col-md-10">
                                <asp:LinkButton class="btn btn-success btn-lg btn-block" ID="LinkButton1" runat="server"><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></asp:LinkButton>
                            </div>
                        </div><br>
                         <div class="row">
                            <div class="col-md-2">
                                <%--<img width="50px" src="imgs/certificate.png"/>--%>
                                <asp:LinkButton class="btn btn-primary btn-lg btn-block" ID="LinkButton3" runat="server">Full Name</asp:LinkButton>
                            </div>
                            <div class="col-md-10">
                                <asp:LinkButton class="btn btn-primary btn-lg btn-block" ID="LinkButton4" runat="server"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></asp:LinkButton>
                            </div>
                        </div><br>
                         <div class="row">
                            <div class="col-md-2">
                                <%--<img width="50px" src="imgs/certificate.png"/>--%>
                                <asp:LinkButton class="btn btn-danger btn-lg btn-block" ID="LinkButton5" runat="server">Username</asp:LinkButton>
                            </div>
                            <div class="col-md-10">
                                <asp:LinkButton class="btn btn-danger btn-lg btn-block" ID="LinkButton6" runat="server"><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></asp:LinkButton>
                            </div>
                        </div><br>
                         <div class="row">
                            <div class="col-md-2">
                                <%--<img width="50px" src="imgs/certificate.png"/>--%>
                                <asp:LinkButton class="btn btn-warning btn-lg btn-block" ID="LinkButton7" runat="server"><i class="fas fa-university"></i></asp:LinkButton>
                            </div>
                            <div class="col-md-10">
                                <asp:LinkButton class="btn btn-warning btn-lg btn-block" ID="LinkButton8" runat="server"><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></asp:LinkButton>
                            </div>
                        </div><br>
                         <div class="row">
                            <div class="col-md-2">
                                <%--<img width="50px" src="imgs/certificate.png"/>--%>
                                <asp:LinkButton class="btn btn-light btn-lg btn-block" ID="LinkButton9" runat="server"><i class="fas fa-certificate"></i></asp:LinkButton>
                            </div>
                            <div class="col-md-10">
                                <asp:LinkButton class="btn btn-light btn-lg btn-block" ID="LinkButton10" runat="server"><asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></asp:LinkButton>
                            </div>
                        </div><br>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <%--<img width="50px" src="imgs/certificate.png"/>--%>
                                <asp:LinkButton class="btn btn-info btn-lg btn-block" ID="LinkButton11" runat="server" OnClick="LinkButton11_Click">Certificates</asp:LinkButton>
                            </div>
                            <div class="col-md-4">
                                <asp:LinkButton class="btn btn-primary btn-lg btn-block" ID="LinkButton12" runat="server" OnClick="LinkButton12_Click">School</asp:LinkButton>
                            </div>
                            <div class="col-md-4">
                                <asp:LinkButton class="btn btn-success btn-lg btn-block" ID="LinkButton13" runat="server" OnClick="LinkButton13_Click">College</asp:LinkButton>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>


                    </div>
                </div>
                <br>
            </div>

        </div>
    </div>
    <br>
    <br>
</asp:Content>
