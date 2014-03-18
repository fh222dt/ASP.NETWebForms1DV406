<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="errorpage.aspx.cs" Inherits="Decorhelp.Pages.Shared.errorpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Serverfel</h2>
    <p>Vi beklagar att ett fel inträffade och vi inte kunde hantera din förfrågan.</p>
    <a href='<%$ RouteUrl:routename=Default %>'  runat="server">Tillbaka till startsidan</a>
</asp:Content>
