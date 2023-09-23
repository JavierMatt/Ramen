<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="Ramen.View.OrderRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Order Ramen</h1>
    <br />
     <br />
    <br />
    <% if (ramenlist != null) 
        { %>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderText="Meat">
                    <ItemTemplate>
                        <%# getMeatName(Eval("MeatId")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Broth" HeaderText="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField HeaderText="Order">
                    <ItemTemplate>
                        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CommandName="AddToCart" CommandArgument='<%# Eval("Id") %>' OnClick="btnAddToCart_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <% } 
    %>
    <br />
    <br />
    <br />

    <h2>Cart</h2>
    <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Ramen.Name" HeaderText="Name" />
            <asp:TemplateField HeaderText="Meat">
                <ItemTemplate>
                    <%# getMeatNameSession((CartItem)Container.DataItem) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Ramen.Broth" HeaderText="Broth" />
            <asp:BoundField DataField="Ramen.Price" HeaderText="Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnPurchase" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
    <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" OnClick="btnClearCart_Click" />
</asp:Content>
