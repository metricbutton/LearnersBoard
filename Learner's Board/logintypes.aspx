<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="logintypes.aspx.cs" Inherits="Learner_s_Board.logintypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br><br>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="card bg-primary" style="width: 400px">
                    <img class="card-img-top" src="imgs/coordinator.png" alt="Card image" style="width: 100%">
                    <div class="card-body text-center">
                        <a href="coordinatorlogin.aspx" class="btn btn-success stretched-link">Coordinator Login</a>
                    </div>
                </div>

            </div>
             <div class="col-md-6">
                <div class="card bg-danger" style="width: 400px">
                    <img class="card-img-top" src="imgs/admin.png" alt="Card image" style="width: 100%">
                    <div class="card-body text-center">
                        <a href="adminlogin.aspx" class="btn btn-success stretched-link">Admin Login</a>
                    </div>
                </div>

            </div>

        </div>

    </div>
    <br><br>
</asp:Content>
