<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="Ramen.View.ManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Manage Ramen</h1>

    <br />
    <br />
    <% if (ramenlist != null) 
        { %>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView_RowCommand" OnRowUpdating="GridView_RowUpdating" OnRowDeleting="GridView_RowDeleting" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="true" />
                <asp:TemplateField HeaderText="Meat">
                    <ItemTemplate>
                        <%# getMeatName(Eval("MeatId")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Broth" HeaderText="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField HeaderText="Update">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Eval("Id") %>' OnClick="btnUpdate_Click" />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' OnClick="btnDelete_Click" />
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <% } 
    %>
    <br />
    <asp:Button ID="btnInsert" runat="server" Text="Insert Ramen" OnClick="btnInsert_Click" />
    


</asp:Content>
