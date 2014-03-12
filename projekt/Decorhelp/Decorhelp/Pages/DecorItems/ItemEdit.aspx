<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ItemEdit.aspx.cs" Inherits="Decorhelp.Pages.DecorItems.ItemEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Ändra inredningsyta</h2>
    <asp:FormView ID="ItemEditFormView" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        SelectMethod="ItemEditFormView_GetItem"
        UpdateMethod="ItemEditFormView_UpdateItem"
        DataKeyNames="decorItemID"
        DefaultMode="Edit"
        RenderOuterTable="false" >
        <EditItemTemplate>
            <div>
                <label for="Name">Namn:</label> 
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.decorItemName %>'></asp:TextBox>
            </div>
            <%-- inte klart! hämta fr db area-tabellen--%>
            <div>
                <label for="Area">Tillhör inredningsyta:</label> 
                <asp:DropDownList ID="AreaDropDownList" runat="server" >
                    
                </asp:DropDownList>
            </div>
            <div>
                <label for="Description">Kommentar: (ej obligatorisk)</label> 
                <asp:TextBox ID="DescTextBox" runat="server" Text='<%# BindItem.decorItemDescription %>'></asp:TextBox>
            </div>

            <asp:LinkButton runat="server" Text="Spara" CommandName="Update" CssClass="btn btn-default btn-xs" />
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorItemDetails", new { id = Item.decorItemID })  %>' CssClass="btn btn-default btn-xs" Text='Avbryt' />                     
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
