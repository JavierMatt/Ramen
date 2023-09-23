<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Ramen.View.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>History</h1>
    <br />
    <br />
    <% if (headerlist != null) 
        { %>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" />
                <asp:BoundField DataField="StaffId" HeaderText="StaffId" />
                <asp:TemplateField HeaderText="Handled">
                    <ItemTemplate>
                        <asp:Label ID="lblHandled" runat="server" Text='<%# Convert.ToInt32(Eval("StaffId")) == 0 ? "not yet" : "done" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:TemplateField HeaderText="Detail">
                    <ItemTemplate>
                        <asp:Button ID="btnDetail" runat="server" Text="See Detail" CommandName="See Detail" CommandArgument='<%# Eval("Id") %>' OnClick="btnDetail_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <% } 
    %>


</asp:Content>
