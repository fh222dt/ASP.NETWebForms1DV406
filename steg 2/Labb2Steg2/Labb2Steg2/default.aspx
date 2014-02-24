<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Labb2Steg2._default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fridas Labb 2 -Kontakter</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>Kontakter</h1>
    
    <form id="form1" runat="server">
    <div>
        <%-- Validering av uppladdning --%>
        <asp:ValidationSummary ID="ValidationSummary" runat="server"  HeaderText="Fel inträffade. Åtgärda felen och försök igen."  />
                
        <%-- Tabell som visar kontakter --%>
        <asp:ListView ID="ContactListView" runat="server"
            ItemType="Labb2Steg2.Model.Contact"
            SelectMethod="ContactListView_GetData"
            InsertMethod="ContactListView_InsertItem"
            UpdateMethod="ContactListView_UpdateItem"
            DeleteMethod="ContactListView_DeleteItem"
            DataKeyNames="ContactId"
            InsertItemPosition="FirstItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Förnamn</th>
                        <th>EfterNamn</th>
                        <th>E-post</th>
                        <th></th>
                    </tr>
                    <%-- Platshållare för nya rader --%>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </table>
            </LayoutTemplate>
            <%-- Mall för nya rader. --%>
            <ItemTemplate>                
                <tr>
                    <td><%#: Item.FirstName %></td>
                    <td><%#: Item.LastName %></td>
                    <td><%#: Item.EmailAddress %></td>                        
                    <td class="command">
                        <%-- "Kommandknappar" för att ta bort och redigera kunduppgifter. Kommandonamnen är VIKTIGA! --%>
                        <asp:LinkButton ID="LinkButton3"  runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        <asp:LinkButton  runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" />                        
                    </td>
                </tr>
            </ItemTemplate>
            <%-- Detta visas då kunduppgifter saknas i databasen. --%>
            <EmptyDataTemplate>                
                <table>
                    <tr>
                        <td>Kunduppgifter saknas.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <%-- Mall för rad i tabellen för att lägga till nya kunduppgifter.--%>
            <InsertItemTemplate>                
                <tr>
                    <td><asp:TextBox ID="firstName" runat="server" Text='<%# BindItem.FirstName %>' /></td>
                    <td><asp:TextBox ID="lastName" runat="server" Text='<%# BindItem.LastName %>' /></td>
                    <td><asp:TextBox ID="emailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' /></td>
                    <td>
                        <%-- "Kommandknappar" för att lägga till en ny kunduppgift och rensa texfälten. --%>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                    </td>
                </tr>
                <%-- validering --%>

            </InsertItemTemplate>
            <%-- Mall för rad i tabellen för att redigera kunduppgifter. --%>
            <EditItemTemplate>                
                <tr>
                    <td><asp:TextBox ID="firstName" runat="server" Text='<%# BindItem.FirstName %>' /></td>
                    <td><asp:TextBox ID="lastName" runat="server" Text='<%# BindItem.LastName %>' /></td>
                    <td><asp:TextBox ID="emailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' /></td>
                    <td>
                        <%-- "Kommandknappar" för att uppdatera en kunduppgift och avbryta. --%>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara" />
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>
                <%-- validering --%>
            </EditItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
