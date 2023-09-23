<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertRamen.aspx.cs" Inherits="Ramen.View.InsertRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Insert Ramen</h1>
    <br />
    <br />

    <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblErrName" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />

    <asp:Label ID="lblMeat" runat="server" Text="Meat: "></asp:Label>
    <asp:DropDownList ID="ddlMeat" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="lblErrMeat" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />

    <asp:Label ID="lblBroth" runat="server" Text="Broth: "></asp:Label>
    <asp:TextBox ID="txtBroth" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblErrBroth" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />

    <asp:Label ID="lblPrice" runat="server" Text="Price: "></asp:Label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblErrPrice" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />

    <br />
    <br />
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
</asp:Content>
