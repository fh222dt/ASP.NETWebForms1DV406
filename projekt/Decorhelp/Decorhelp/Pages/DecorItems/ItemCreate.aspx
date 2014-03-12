<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ItemCreate.aspx.cs" Inherits="Decorhelp.Pages.DecorItems.ItemCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Lägg till inredningsföremål</h2>
    <asp:FormView ID="ItemCreateFormView" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        InsertMethod="ItemCreateFormView_InsertItem"
        DefaultMode="Insert"
        RenderOuterTable="false" >
        <InsertItemTemplate>
            <div>
                <label for="Name">Namn:</label> 
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.decorItemName %>'></asp:TextBox>
            </div>
            <%-- inte klart! hämta fr areatabellen--%>
            <div>
                <label for="Area">Tillhör inredningsyta:</label> 
                <asp:DropDownList ID="AreaDropDownList" runat="server"
                    ItemType="Decorhelp.Model.Decorarea"
                    SelectMethod="AreaDropDownList_GetData"
                    DataTextField="decorAreaName"
                    DataValueField="decorareaID"
                    SelectedValue='<%# BindItem.decorAreaID %>'>                    
                </asp:DropDownList>
            </div>
            <div>
                <label for="Name">Kommentar: (ej obligatorisk)</label> 
                <asp:TextBox ID="DescTextBox" runat="server" Text='<%# BindItem.decorItemDescription %>'></asp:TextBox>
            </div>

            <asp:LinkButton runat="server" Text="Spara" CommandName="Insert" CssClass="btn btn-default btn-xs" />
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreas") %>'  CssClass="btn btn-default btn-xs" Text='Avbryt' />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
