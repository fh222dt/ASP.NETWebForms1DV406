<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="listall.aspx.cs" Inherits="Decorhelp.Pages.listall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <%-- lista alla föremål --%>
    <asp:ListView ID="ListView1" runat="server">

    </asp:ListView>
</asp:Content>
