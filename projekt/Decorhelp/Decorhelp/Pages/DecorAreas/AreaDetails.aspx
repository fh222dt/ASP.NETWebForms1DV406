<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AreaDetails.aspx.cs" Inherits="Decorhelp.Pages.DecorAreas.AreaDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Detaljer inredningsyta</h2>
    <asp:FormView ID="AreaDetailsFormView" runat="server"
        ItemType="Decorhelp.Model.Decorarea"
        SelectMethod="AreaDetailsFormView_GetItem"
        RenderOuterTable="false" >
        <ItemTemplate>
            <div>Namn: <%#: Item.decorAreaName %></div>
            <div>Tillhör rum: <%#: Item.roomID %></div>
            <div>Kommentar: <%#: Item.decorAreaDescription %></div>
            <asp:HyperLink runat="server" Text="Redigera" CssClass="btn btn-default btn-sm" NavigateUrl='<%# GetRouteUrl("DecorAreaEdit", new { id = Item.decorAreaID }) %>' />
            <asp:HyperLink runat="server" Text="Ta bort" CssClass="btn btn-default btn-sm" NavigateUrl='<%# GetRouteUrl("DecorAreaDelete", new { id = Item.decorAreaID }) %>' />
            <asp:HyperLink runat="server" Text="Tillbaka" CssClass="btn btn-default btn-sm" NavigateUrl='<%# GetRouteUrl("DecorAreas", null)%>' />
                      
        </ItemTemplate>

    </asp:FormView>
</asp:Content>
