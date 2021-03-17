<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="schooluploadtypes.aspx.cs" Inherits="Learner_s_Board.schooluploadtypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="form-group">
            <asp:DropDownList class="form-control dropdown" ID="DropDownList1" runat="server">
                    <asp:ListItem Text="Select" Value="select" />
                    <asp:ListItem Text="10" Value="10" />
                    <asp:ListItem Text="12" Value="12" />

            </asp:DropDownList>
        </div>

        <asp:DropDownList ID="ddlSearchColumn2" class="form-control dropdown" runat="server" AutoPostBack="true" />
        <asp:ListItem Text="Select" Value="select" />
        </asp:DropDownList>

        </div>



</asp:Content>
