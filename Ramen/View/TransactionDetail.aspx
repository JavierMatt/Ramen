<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="Ramen.View.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Detail</h1>
    <br />
    <br />
     <% if (detaillist != null) 
        { %>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="HeaderId" HeaderText="HeaderId" />
                <asp:TemplateField HeaderText="Ramen">
                    <ItemTemplate>
                        <%# getRamenName(Eval("RamenId")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            </Columns>
        </asp:GridView>
        <% } 
    %>
</asp:Content>
