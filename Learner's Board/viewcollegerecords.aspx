<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viewcollegerecords.aspx.cs" Inherits="Learner_s_Board.viewcollegerecords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <br>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card bg-dark text-white">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                           <h4>View Records</h4>
                        </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                           <img width="100px" src="imgs/approved.png" />
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
                                <label>Document ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Document ID"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col ml-3">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ErrorMessage="ID is required" ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                        <br>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-info" OnClick="Button2_Click" runat="server" Text="View Record" />
                            </div>
                        </div>
                        <br>
                    </div>
                </div>
                <br>
            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                           <h4>Record List</h4>
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
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server"></asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
