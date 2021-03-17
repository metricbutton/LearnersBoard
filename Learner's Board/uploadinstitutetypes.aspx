<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="uploadinstitutetypes.aspx.cs" Inherits="Learner_s_Board.uploadinstitutetypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <br>
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card bg-light" style="width: 400px">
                    <img class="card-img-top" src="imgs/school.png" alt="Card image" style="width: 100%">
                    <div class="card-body text-center">
                        <a href="schoolupload.aspx" class="btn btn-success stretched-link">School</a>
                    </div>
                </div>

            </div>
            <div class="col-md-6 mx-auto">
                <div class="card bg-light" style="width: 400px">
                    <img class="card-img-top" src="imgs/college.png" alt="Card image" style="width: 100%">
                    <div class="card-body text-center">
                        <a href="collegeupload.aspx" class="btn btn-success stretched-link">College</a>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <br>
    <br>
</asp:Content>
