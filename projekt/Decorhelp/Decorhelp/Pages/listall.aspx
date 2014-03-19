<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="listall.aspx.cs" Inherits="Decorhelp.Pages.listall" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <div id="welcome">
        <p>Välkommen till Decorhelp! Här kan du planera din inredning och få koll på hur du ska dekorera ditt hem under 
            olika perioder. Lägg till nya föremål i menyn här ovan!
        </p>
    </div>
    
    <%-- lista alla föremål --%>
    <h2>Alla inredningsföremål</h2>

    <asp:ListView ID="SummaryListView" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        SelectMethod="SummaryListView_GetData"
        DataKeyNames="decorItemID" >
        <LayoutTemplate>
            <table class="table table-hover">
                <tr>
                    <th>Föremål</th>
                    <th>Inredningsyta</th>
                    <th>Rum</th>                    
                </tr>

                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>

        <ItemTemplate>                
            <tr id="row" runat="server">
                <td>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("DecorItemDetails", new { id = Item.decorItemID })  %>'
                    Text='<%#: Item.decorItemName %>' />
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreaDetails", new { id = Item.decorAreaID })  %>'
                        Text='<%#: Item.decorAreaName %>' />
                </td>
                <td>
                    <asp:Literal ID="Literal1" runat="server" Text='<%#: Item.roomName %>'></asp:Literal>
                </td>               
            </tr>
        </ItemTemplate>

        <EmptyDataTemplate>                
            <table>
                <tr>
                    <td>Inga inredningsföremål kunde hittas</td>
                </tr>
            </table>
        </EmptyDataTemplate>
          
    </asp:ListView>
  
</asp:Content>
