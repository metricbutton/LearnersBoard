<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="coordinaterdegreemanagement.aspx.cs" Inherits="Learner_s_Board.coordinaterdegreemanagement" %>
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
                                        <h4>Degree Details</h4>
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
                                <label>Degree ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ID is required" ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Go" CausesValidation="False" onClick="Button1_Click"/>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Degree Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Degree Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name is required" ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-12">
                                <label>Short Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Short Name" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Short name is required" ControlToValidate="TextBox4" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-12">
                                <label>Term</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Term in years"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Email is required" ControlToValidate="TextBox6" Display="Dynamic"></asp:RequiredFieldValidator>

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
                                <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" Onclick="Button4_Click"/>
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
                                        <h4>Degree List</h4>
                                    </center>
                            </div>
                        </div>



                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:learnersboardDBConnectionString3 %>" SelectCommand="SELECT * FROM [degree_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="degree_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="degree_id" HeaderText="degree_id" InsertVisible="False" ReadOnly="True" SortExpression="degree_id" />
                                        <asp:BoundField DataField="degree_name" HeaderText="degree_name" SortExpression="degree_name" />
                                        <asp:BoundField DataField="short_name" HeaderText="short_name" SortExpression="short_name" />
                                        <asp:BoundField DataField="degree_term" HeaderText="degree_term" SortExpression="degree_term" />
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
