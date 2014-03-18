<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="allItemsPeriod.aspx.cs" Inherits="Decorhelp.Pages.allItemsPeriod" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h2>Alla föremål per period</h2>
    <p>Här kan du få en snabb översikt över de föremål som är tänkta att dekoreras med under olika perioder.</p>

    <asp:ValidationSummary ID="ValidationSummary" runat="server" />

    <div>
        <%-- värden kommer fr tabell utanför projektet --%>
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
        DataKeyNames="decorItemID"  OnPreRender="ListView1_PreRender">
        
        <LayoutTemplate>
            <h3><asp:Literal ID="PeriodLiteral" runat="server" Text="Period: {0}"></asp:Literal></h3>
            <table class="table table-hover">
                <tr>
                    <th>Rum</th>
                    <th>Inredningsyta</th>
                    <th>Kommentar</th>
                    <th>Föremål</th>
                    <th>Kommentar</th>                    
                </tr>                

                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr id="row" runat="server">
                <td><asp:Literal ID="Literal1" runat="server" Text='<%#: Item.roomName %>'></asp:Literal></td>
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreaDetails", new { id = Item.decorAreaID })  %>'
                        Text='<%#: Item.decorAreaName %>' />                    
                </td> 
                <td>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </td>                   
                <td>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorItemDetails", new { id = Item.decorItemID })  %>'
                    Text='<%#: Item.decorItemName %>' />                    
                </td>
                <td>
                    <asp:Literal ID="Literal3" runat="server" Text='<%#: Item.decorItemDescription %>'></asp:Literal>
                </td>
            </tr>
        </ItemTemplate>

        <EmptyDataTemplate>
            <p>Inga inredningsföremål kunde hittas</p>
        </EmptyDataTemplate>

    </asp:ListView>
</asp:Content>
