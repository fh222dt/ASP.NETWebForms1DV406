<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="listall.aspx.cs" Inherits="Decorhelp.Pages.listall" %>

<%-- Sida för listning med uppdelning per rum & yta --%>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <%-- lista alla föremål --%>
    <asp:ListView ID="SummaryListView" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        SelectMethod="SummaryListView_GetData"
        DataKeyNames="decorItemID"
        >
        <LayoutTemplate>
            <table class="table table-hover">
                <tr>
                    <th>Rum</th>
                    <th>Yta</th>
                    <th>Föremål</th>
                    <th></th>
                </tr>
                <%-- Platshållare för nya rader --%>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <%-- Mall för nya rader. --%>
            <ItemTemplate>                
                <tr>
                    <td>Rumsnamn</td>
                    <td>
                        <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreaDetails", new { id = Item.decorAreaID })  %>'
                         Text='<%#: Item.decorAreaID %>' />
                    </td>                    
                    <td>
                        <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorItemDetails", new { id = Item.decorItemID })  %>'
                        Text='<%#: Item.decorItemName %>' />

                    </td>
                                            
                    <td>                        
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
