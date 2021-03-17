<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="collegeupload.aspx.cs" Inherits="Learner_s_Board.collegeupload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <br>
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">

                <div class="card bg-dark text-light">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="imgs/college.png"/>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Upload for College</h4>
                                    </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Username</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Username"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username is required" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>College</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="College is required" initialvalue="0" ControlToValidate="DropDownList1" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Semester</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Semester is required" initialvalue="0" ControlToValidate="DropDownList2" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>File Upload</label>
                                <div>
                                    <asp:FileUpload ID="FileUpLoad1" CssClass="form-control" runat="server" />

                                </div>
                            </div>


                        </div>

                        <div class="form-group">
                            <br />
                            <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

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
