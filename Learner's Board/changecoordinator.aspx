<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="changecoordinator.aspx.cs" Inherits="Learner_s_Board.changecoordinator" %>
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
                                        <img width="150px" src="imgs/coordinator.png"/>
                                    </center>
                                </div>
                        </div>

                        <div class="row">
                                <div class="col">
                                    <center>
                                        <h3>Change Coordinator</h3>
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
                                <div class="row">
                            <div class="col">
                                <label>Coordinator</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList6" AppendDataBoundItems="true" runat="server" ></asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="Red" initialvalue="0" runat="server" ErrorMessage="Coordinator is required" ControlToValidate="DropDownList6" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                            </div>
                        </div>

                        <div class="row">
                                <div class="col">

                                    <div class="form-group">
                                        <br/>
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"/>

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
