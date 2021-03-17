<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="fileupload.aspx.cs" Inherits="Learner_s_Board.fileupload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-8 mx-auto">

                <div class="card bg-dark text-white">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="imgs/student.png"/>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Learner Sign Up</h4>
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
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fullname is required" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>File Upload</label>
                                <div class="form-group">
                                    <asp:FileUpload id="FileUpLoad1" runat="server" />  
                                    <asp:Label ID="Label1" runat="server" Text="Label" Enabled="false" Visible="false"></asp:Label>

                                </div>
                            </div>

                            
                        </div>




                        



                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:Button ID="bttnpdf" runat="server" Text="Click for open PDF" Font-Bold="True" OnClick="bttnpdf_Click" /> 

                                </div>
                            </div>
                        </div>

                        
                </div>
                <br>
            </div>

        </div>
    </div>
</asp:Content>
