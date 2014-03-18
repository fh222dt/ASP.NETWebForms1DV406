<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ItemDelete.aspx.cs" Inherits="Decorhelp.Pages.DecorItems.ItemDelete" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h2>Ta bort inredningsföremål</h2>
    <p>Är du säker på att du vill ta bort föremålet?</p>

    <asp:LinkButton runat="server" ID="DeleteLinkButton" Text="Ta bort"
            onCommand="DeleteLinkButton_Command" CommandArgument='<%$ RouteValue:id %>' CssClass="btn btn-default btn-xs" />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreas") %>' CssClass="btn btn-default btn-xs" Text='Avbryt' />
</asp:Content>
