<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Ramen.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profile</h1>
    <br />

    <asp:GridView ID="GridViewProfile" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Username" HeaderText="Username" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" />
            <asp:BoundField DataField="Password" HeaderText="Password" />
        </Columns>
    </asp:GridView>
    <br />
    <br />

    <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblErrUsername" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />

    <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblErrEmail" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />

    <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
    <asp:RadioButton ID="radioBtnGenderMale" runat="server" Text="Male" GroupName="gender" />  
    <asp:RadioButton ID="radioBtnGenderFemale" runat="server" Text="Female" GroupName="gender" />  
    <br />
    <asp:Label ID="lblErrGender" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />

    <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblErrPassword" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />

    <asp:Button ID="btnChangeProfileInformation" runat="server" Text="Change Profile Information" OnClick="btnChangeProfileInformation_Click" />
</asp:Content>
