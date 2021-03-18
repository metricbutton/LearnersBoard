<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="certificateupload.aspx.cs" Inherits="Learner_s_Board.certificateupload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <br>
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">

                <div class="card bg-navyblue text-light">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="imgs/certificate.png"/>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Upload Certificate</h4>
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
                            <div class="col-md-12">
                                <label>Event Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Event Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Event Name is required" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Date is required" ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Type</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" >
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Techfest" Value="Techfest" />
                                        <asp:ListItem Text="Workshop" Value="Workshop" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Type is required" initialvalue="select" ControlToValidate="DropDownList2" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>File Upload</label>
                                <div>
                                    <asp:FileUpload ID="FileUpLoad1" CssClass="form-control" runat="server" accept=".pdf"/>
                                    <asp:RegularExpressionValidator
                                        ID="FileUpLoadValidator" runat="server"
                                        ErrorMessage="Upload PDFs only."
                                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf)$"
                                        ControlToValidate="FileUpload1">  
                                    </asp:RegularExpressionValidator>

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
