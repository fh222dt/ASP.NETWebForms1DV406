<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AreaDetails.aspx.cs" Inherits="Decorhelp.Pages.DecorAreas.AreaDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h2>Detaljer inredningsyta</h2>

    <asp:FormView ID="AreaDetailsFormView" runat="server"
        ItemType="Decorhelp.Model.Decorarea"
        SelectMethod="AreaDetailsFormView_GetItem"
        RenderOuterTable="false"  OnPreRender="AreaDetailsFormView_PreRender" >
        
        <ItemTemplate>
            <div><span class="details"><strong>Namn: </strong></span><span> <%#: Item.decorAreaName %></span></div>
            <div><span class="details"><strong>Tillhör rum:</strong></span>
                <span> <asp:Literal ID="RoomLiteral" runat="server" Text="Ej angett"></asp:Literal></span></div>
            <div><span class="details"><strong>Kommentar: </strong></span><span> <%#: Item.decorAreaDescription %></span></div>
            <div class="links">
                <asp:HyperLink runat="server" Text="Redigera" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorAreaEdit", new { id = Item.decorAreaID }) %>' />
                <asp:HyperLink runat="server" Text="Ta bort" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorAreaDelete", new { id = Item.decorAreaID }) %>' />
                <asp:HyperLink runat="server" Text="Tillbaka" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorAreas", null)%>' />
            </div>                      
        </ItemTemplate>

    </asp:FormView>
</asp:Content>
