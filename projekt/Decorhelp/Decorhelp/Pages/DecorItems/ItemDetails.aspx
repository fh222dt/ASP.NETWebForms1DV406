<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ItemDetails.aspx.cs" Inherits="Decorhelp.Pages.DecorItems.ItemDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Detaljer inredningsföremål</h2>
    <asp:FormView ID="ItemDetailsFormView" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        SelectMethod="ItemDetailsFormView_GetItem"
        RenderOuterTable="false" >
        <ItemTemplate>
            <div>Namn: <%#: Item.decorItemName %></div>
            <div>Tillhör inredningsyta: <%#: Item.decorAreaID %></div>
            <div>Kommentar: <%#: Item.decorItemDescription %></div>
            <asp:HyperLink runat="server" Text="Redigera" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorItemEdit", new { id = Item.decorItemID }) %>' />
            <asp:HyperLink runat="server" Text="Ta bort" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorItemDelete", new { id = Item.decorItemID }) %>' />
            <asp:HyperLink runat="server" Text="Tillbaka" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorItem")%>' />                      
        </ItemTemplate>

    </asp:FormView>
</asp:Content>
