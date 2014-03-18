<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ItemCreate.aspx.cs" Inherits="Decorhelp.Pages.DecorItems.ItemCreate" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <h2>Lägg till inredningsföremål</h2>

    <asp:ValidationSummary ID="ValidationSummary" runat="server" />

    <asp:FormView ID="ItemCreateFormView" runat="server"
        ItemType="Decorhelp.Model.Decoritem"
        InsertMethod="ItemCreateFormView_InsertItem"
        DefaultMode="Insert"
        RenderOuterTable="false" >
        
        <InsertItemTemplate>
            <div>
                <label for="Name">Namn:</label> 
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.decorItemName %>' MaxLength="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Namn måste anges"
                     Display="Dynamic" ControlToValidate="NameTextBox">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="Area">Tillhör inredningsyta:</label> 
                <asp:DropDownList ID="AreaDropDownList" runat="server"
                    ItemType="Decorhelp.Model.Decorarea"
                    SelectMethod="AreaDropDownList_GetData"
                    DataTextField="decorAreaName"
                    DataValueField="decorareaID"
                    SelectedValue='<%# BindItem.decorAreaID %>'
                    AppendDataBoundItems="true">
                    <asp:ListItem Value="">Välj yta</asp:ListItem>                    
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RoomDropDownListRequiredFieldValidator" runat="server" ErrorMessage="Inredningsyta måste anges"
                     ControlToValidate="AreaDropDownList" Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="Name">Kommentar: (ej obligatorisk)</label> 
                <asp:TextBox ID="DescTextBox" runat="server" Text='<%# BindItem.decorItemDescription %>' MaxLength="40"></asp:TextBox>
            </div>
            <asp:LinkButton runat="server" Text="Spara" CommandName="Insert" CssClass="btn btn-default btn-xs" />
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreas") %>'  CssClass="btn btn-default btn-xs" Text='Avbryt' />
        </InsertItemTemplate>

    </asp:FormView>

</asp:Content>
