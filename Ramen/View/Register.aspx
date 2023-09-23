<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Ramen.View.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Register</h1>
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

            <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lblErrPassword" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />

            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password: "></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="lblErrConfirmPassword" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />

            <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label>
            <asp:RadioButton ID="radioBtnGenderMale" runat="server" Text="Male" GroupName="gender" />  
            <asp:RadioButton ID="radioBtnGenderFemale" runat="server" Text="Female" GroupName="gender" />  
            <br />
            <asp:Label ID="lblErrGender" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />

            <asp:Label ID="lblRole" runat="server" Text="Role: "></asp:Label>
            <asp:RadioButton ID="radioBtnRoleStaff" runat="server" Text="Staff" GroupName="role" />  
            <asp:RadioButton ID="radioBtnRoleMember" runat="server" Text="member" GroupName="role" />  
            <br />
            <asp:Label ID="lblErrRole" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />

            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />

</asp:Content>
