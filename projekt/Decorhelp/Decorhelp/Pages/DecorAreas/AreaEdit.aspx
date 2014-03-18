<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AreaEdit.aspx.cs" Inherits="Decorhelp.Pages.DecorAreas.AreaEdit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Ändra inredningsyta</h2>

    <asp:ValidationSummary ID="ValidationSummary" runat="server" />

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
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.decorAreaName %>' MaxLength="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Namn måste anges"
                     Display="Dynamic" ControlToValidate="NameTextBox">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <%-- valideras ej då den är förvald vid edit --%>
                <label for="Room">Tillhör rum:</label> 
                <asp:DropDownList ID="RoomDropDownList" runat="server">
                    <asp:ListItem Value="2">Köket</asp:ListItem>
                    <asp:ListItem Value="3">Vardagsrummet</asp:ListItem>
                    <asp:ListItem Value="4">Sovrummet</asp:ListItem>
                    <asp:ListItem Value="5">Gästrummet</asp:ListItem>
                    <asp:ListItem Value="6">Hallen</asp:ListItem>
                    <asp:ListItem Value="7">Badrummet</asp:ListItem>
                    <asp:ListItem Value="8">Uterummet</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label for="Name">Kommentar: (ej obligatorisk)</label> 
                <asp:TextBox ID="DescTextBox" runat="server" Text='<%# BindItem.decorAreaDescription %>' MaxLength="40"></asp:TextBox>
            </div>

            <asp:LinkButton runat="server" Text="Spara" CommandName="Update" CssClass="btn btn-default btn-xs" />
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreaDetails", new { id = Item.decorAreaID })  %>' CssClass="btn btn-default btn-xs" Text='Avbryt' />
                         
                      
        </EditItemTemplate>

    </asp:FormView>
</asp:Content>
