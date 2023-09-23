<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionQueue.aspx.cs" Inherits="Ramen.View.TransactionQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Queue</h1>
    <br />
    <br />
    <% if (headerlist != null) 
        { %>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:TemplateField HeaderText="Hanlde">
                    <ItemTemplate>
                        <asp:Button ID="btnHandleHeader" runat="server" Text="Handle Order" CommandName="Handle" CommandArgument='<%# Eval("Id") %>' OnClick="btnHandleHeader_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <% } 
    %>
</asp:Content>
