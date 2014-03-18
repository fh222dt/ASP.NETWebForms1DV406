﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="allItemsPeriod.aspx.cs" Inherits="Decorhelp.Pages.allItemsPeriod" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h2>Alla föremål per period</h2>
    <p>Här kan du få en snabb översikt över de föremål som är tänkta att användas under olika perioder.</p>

    <asp:ValidationSummary ID="ValidationSummary" runat="server" />

    <div>
        <label for="Period">Välj period att visa:</label>
        <asp:DropDownList ID="PeriodDropDownList" runat="server">
                        <asp:ListItem Value="">Välj period</asp:ListItem>
                        <asp:ListItem Value="1">Påsk</asp:ListItem>
                        <asp:ListItem Value="2">Sommar</asp:ListItem>
                        <asp:ListItem Value="3">Jul</asp:ListItem>
                        <asp:ListItem Value="4">Året runt</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="PeriodDropDownListRequiredFieldValidator" runat="server" ErrorMessage="Period måste anges"
                     ControlToValidate="PeriodDropDownList" Display="Dynamic">*</asp:RequiredFieldValidator>

        <asp:Button ID="PeriodButton" runat="server" Text="Visa" OnClick="PeriodButton_Click" CssClass="btn btn-default btn-xs"/>
    </div>
    <asp:ListView ID="ListView1" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        SelectMethod="ListView1_GetData"
        DataKeyNames="decorItemID" >
        
        <LayoutTemplate>
            <h3><asp:Literal ID="PeriodLiteral" runat="server" Text="Period {0}"></asp:Literal></h3>
            <table class="table table-hover">                
                <%-- Platshållare för nya rader --%>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr id="row" runat="server">
                <td><asp:Literal ID="Literal1" runat="server" Text='<%#: Item.roomName %>'></asp:Literal></td>
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreaDetails", new { id = Item.decorAreaID })  %>'
                        Text='<%#: Item.decorAreaName %>' />
                    <asp:Literal ID="Literal2" runat="server" Text='kommentar'></asp:Literal>
                </td>                    
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorItemDetails", new { id = Item.decorItemID })  %>'
                    Text='<%#: Item.decorItemName %>' />
                    <asp:Literal ID="Literal3" runat="server" Text=" ( )"></asp:Literal><span><%#: Item.decorItemDescription %></span>
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>Inga inredningsföremål kunde hittas</p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
