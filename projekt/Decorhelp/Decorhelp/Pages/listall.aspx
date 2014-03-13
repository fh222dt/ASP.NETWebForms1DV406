<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="listall.aspx.cs" Inherits="Decorhelp.Pages.listall" %>

<%-- Sida för listning med uppdelning per rum & yta --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <%-- lista alla föremål --%>

    <asp:Table ID="Table1" runat="server" ></asp:Table>
    



    <asp:ListView ID="SummaryListView" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        SelectMethod="SummaryListView_GetData"
        DataKeyNames="decorItemID" >
        <LayoutTemplate>
            <table class="table table-hover">
                <tr>
                    <th>Rum</th>
                    <th>Inredningsyta</th>
                    <th>Föremål</th>                    
                </tr>
                <tr>
                    <td rowspan="4">Köket</td>
                    <td rowspan="4">Skänken</td>
                    <td>Skål</td>
                    <tr><td>Blomma</td></tr>
                    <tr><td>tavla</td></tr>
                    <tr><td>duk</td></tr>
                </tr>
                <%-- Platshållare för nya rader --%>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <%-- Mall för nya rader. --%>
            <ItemTemplate>                
                <tr id="row" runat="server">
                    <td><asp:Literal ID="Literal1" runat="server" Text='<%#: Item.roomName %>'></asp:Literal></td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreaDetails", new { id = Item.decorAreaID })  %>'
                         Text='<%#: Item.decorAreaName %>' />
                    </td>                    
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# GetRouteUrl("DecorItemDetails", new { id = Item.decorItemID })  %>'
                        Text='<%#: Item.decorItemName %>' />

                    </td>
                </tr>
            </ItemTemplate>
            <%-- Detta visas då uppgifter saknas i databasen. --%>
            <EmptyDataTemplate>                
                <table>
                    <tr>
                        <td>Inga inredningsföremål kunde hittas</td>
                    </tr>
                </table>
            </EmptyDataTemplate>  

    </asp:ListView>
  
</asp:Content>
