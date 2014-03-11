<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AreaEdit.aspx.cs" Inherits="Decorhelp.Pages.DecorAreas.AreaEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Ändra inredningsyta</h2>
    <asp:FormView ID="AreaEditFormView" runat="server"
        ItemType="Decorhelp.Model.Decorarea"
        SelectMethod="AreaEditFormView_GetItem"
        UpdateMethod="AreaEditFormView_UpdateItem"
        DataKeyNames="decorAreaID"
        DefaultMode="Edit"
        RenderOuterTable="false" >
        <EditItemTemplate>
            <div>
                <label for="Name">Namn:</label> 
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.decorAreaName %>'></asp:TextBox>
            </div>
            <%-- inte klart! --%>
            <div>
                <label for="Room">Tillhör rum:</label> 
                <asp:DropDownList ID="RoomDropDownList" runat="server">
                    <asp:ListItem>Köket</asp:ListItem>
                    <asp:ListItem>Vardagsrummet</asp:ListItem>
                    <asp:ListItem>Sovrummet</asp:ListItem>
                    <asp:ListItem>Gästrummet</asp:ListItem>
                    <asp:ListItem>Hallen</asp:ListItem>
                    <asp:ListItem>Badrummet</asp:ListItem>
                    <asp:ListItem>Uterummet</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label for="Name">Kommentar: (ej obligatorisk)</label> 
                <asp:TextBox ID="DescTextBox" runat="server" Text='<%# BindItem.decorAreaDescription %>'></asp:TextBox>
            </div>

            <asp:LinkButton runat="server" Text="Spara" CommandName="Update" CssClass="btn btn-default btn-xs" />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreaDetails", new { id = Item.decorAreaID })  %>' CssClass="btn btn-default btn-xs" Text='Avbryt' />
                         
                      
        </EditItemTemplate>

    </asp:FormView>
</asp:Content>
