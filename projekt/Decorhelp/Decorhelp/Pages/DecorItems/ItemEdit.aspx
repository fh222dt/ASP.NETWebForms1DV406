<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ItemEdit.aspx.cs" Inherits="Decorhelp.Pages.DecorItems.ItemEdit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Ändra inredningsyta</h2>

    <asp:ValidationSummary ID="ValidationSummary" runat="server" />

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
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.decorItemName %>' MaxLength="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Namn måste anges"
                     Display="Dynamic" ControlToValidate="NameTextBox">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <%-- valideras ej då den är förvald vid edit --%>
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
                <label for="Description">Kommentar: (ej obligatorisk)</label> 
                <asp:TextBox ID="DescTextBox" runat="server" Text='<%# BindItem.decorItemDescription %>' MaxLength="40"></asp:TextBox>
            </div>

            <asp:LinkButton runat="server" Text="Spara" CommandName="Update" CssClass="btn btn-default btn-xs" />
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorItemDetails", new { id = Item.decorItemID })  %>' CssClass="btn btn-default btn-xs" Text='Avbryt' />                     
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
