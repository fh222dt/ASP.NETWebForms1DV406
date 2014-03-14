<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="AreaCreate.aspx.cs" Inherits="Decorhelp.Pages.DecorAreas.DecorAreaCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Lägg till inredningsyta</h2>

    <asp:ValidationSummary ID="ValidationSummarys" runat="server" />

    <asp:FormView ID="AreaCreateFormView" runat="server"
        ItemType="Decorhelp.Model.Decorarea"
        InsertMethod="AreaCreateFormView_InsertItem"
        DefaultMode="Insert"
        RenderOuterTable="false" >
        <InsertItemTemplate>
            <div>
                <label for="Name">Namn:</label> 
                <asp:TextBox ID="NameTextBox" runat="server" Text='<%# BindItem.decorAreaName %>' MaxLength="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Namn måste anges"
                     Display="Dynamic" ControlToValidate="NameTextBox">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="Room">Tillhör rum:</label> 
                <asp:DropDownList ID="RoomDropDownList" runat="server">
                    <asp:ListItem Value="">Välj rum</asp:ListItem>
                    <asp:ListItem Value="2">Köket</asp:ListItem>
                    <asp:ListItem Value="3">Vardagsrummet</asp:ListItem>
                    <asp:ListItem Value="4">Sovrummet</asp:ListItem>
                    <asp:ListItem Value="5">Gästrummet</asp:ListItem>
                    <asp:ListItem Value="6">Hallen</asp:ListItem>
                    <asp:ListItem Value="7">Badrummet</asp:ListItem>
                    <asp:ListItem Value="8">Uterummet</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RoomDropDownListRequiredFieldValidator" runat="server" ErrorMessage="Rum måste anges"
                     ControlToValidate="RoomDropDownList" Display="Dynamic">*</asp:RequiredFieldValidator>
            </div>
            <div>
                <label for="Name">Kommentar: (ej obligatorisk)</label> 
                <asp:TextBox ID="DescTextBox" runat="server" Text='<%# BindItem.decorAreaDescription %>' MaxLength="40"></asp:TextBox>
            </div>

            <asp:LinkButton ID="LinkButton1" runat="server" Text="Spara" CommandName="Insert" CssClass="btn btn-default btn-xs" />
            <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("DecorAreas") %>'  CssClass="btn btn-default btn-xs" Text='Avbryt' />                      
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
