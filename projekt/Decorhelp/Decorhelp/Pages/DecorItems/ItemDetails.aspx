<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ItemDetails.aspx.cs" Inherits="Decorhelp.Pages.DecorItems.ItemDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h2>Detaljer inredningsföremål</h2>

    <asp:FormView ID="ItemDetailsFormView" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        SelectMethod="ItemDetailsFormView_GetItem"
        RenderOuterTable="false">
        
        <ItemTemplate>
            <div><span class="details"><strong>Namn: </strong></span><span> <%#: Item.decorItemName %></span></div>
            <div><span class="details"><strong>Tillhör yta: </strong></span><span>
                        <asp:Label ID="AreaLabel" runat="server" Text="{0}" OnPreRender="AreaLabel_PreRender"/></span>
            </div>
            <div><span class="details"><strong>Kommentar: </strong></span><span> <%#: Item.decorItemDescription %></span></div>
            <div class="links">
                <asp:HyperLink runat="server" Text="Redigera" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorItemEdit", new { id = Item.decorItemID }) %>' />
                <asp:HyperLink runat="server" Text="Ta bort" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorItemDelete", new { id = Item.decorItemID }) %>' />
                <asp:HyperLink runat="server" Text="Tillbaka" CssClass="btn btn-default btn-xs" NavigateUrl='<%# GetRouteUrl("DecorItem")%>' /> 
            </div>                     
        </ItemTemplate>

    </asp:FormView>
</asp:Content>
