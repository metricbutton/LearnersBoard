<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="coordinaterspecializationmanagement.aspx.cs" Inherits="Learner_s_Board.coordinaterspecializationmanagement1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
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
                                        <h4>Specialization Details</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="imgs/degree.png" />
                                       
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Specialization ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ID is required" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" CausesValidation="False" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Specialization Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Specialization Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name is required" ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-12">
                                <label>Degree Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Degree Name is required" ControlToValidate="DropDownList1" Display="Dynamic" InitialValue="Select Degree"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                            </div>
                        </div>


                    </div>
                </div>
                <br>
                <br>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Specialization List</h4>
                                    </center>
                            </div>
                        </div>



                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:learnersboardDBConnectionString4 %>" SelectCommand="SELECT * FROM [specialization_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="specialization_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="specialization_id" HeaderText="specialization_id" InsertVisible="False" ReadOnly="True" SortExpression="specialization_id" />
                                        <asp:BoundField DataField="specialization_name" HeaderText="specialization_name" SortExpression="specialization_name" />
                                        <asp:BoundField DataField="degree_id" HeaderText="degree_id" SortExpression="degree_id" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>




                    </div>
                </div>


            </div>

        </div>
    </div>
</asp:Content>
