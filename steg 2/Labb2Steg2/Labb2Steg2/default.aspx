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
        <asp:ValidationSummary ID="ValidationSummary" runat="server"  HeaderText="Fel inträffade. Åtgärda felen och försök igen."/>
        
        <%-- Visa rättmeddelande --%>
        <asp:PlaceHolder ID="InsertPlaceHolder" runat="server" Visible="false">
            <p>Ny kontakt har lagts till!</p>
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="EditPlaceHolder" runat="server" Visible="false">
            <p>Din kontakt har ändrats!</p>
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="DeletePlaceHolder" runat="server" Visible="false">
            <p>Din kontakt har tagits bort!</p>
        </asp:PlaceHolder>

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
                        <th>Efternamn</th>
                        <th>E-post</th>
                        <th></th>
                    </tr>
                    <%-- Platshållare för nya rader --%>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </table>
                <asp:DataPager ID="DataPager" runat="server" PageSize="20">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" FirstPageText="<<"
                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="true" LastPageText=">>"
                             ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <%-- Mall för nya rader. --%>
            <ItemTemplate>                
                <tr>
                    <td><%#: Item.FirstName %></td>
                    <td><%#: Item.LastName %></td>
                    <td><%#: Item.EmailAddress %></td>                        
                    <td>
                        <%-- "Kommandknappar" för att ta bort och redigera kunduppgifter. --%>
                        <asp:LinkButton ID="LinkButton3"  runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        <asp:LinkButton  runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" 
                            OnClientClick='<%# String.Format("return confirm(\"Ta bort kontakten {0} {1}?\")", Item.FirstName, Item.LastName)%>' />                        
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
                    <td><asp:TextBox ID="firstName" runat="server" Text='<%# BindItem.FirstName %>'  MaxLength="50"/></td>
                    <%-- validering --%>
                    <asp:RequiredFieldValidator ID="firstNameRequiredFieldValidator" runat="server" ErrorMessage="Förnamn måste anges" Display="Dynamic" 
                        ControlToValidate="firstName" ValidationGroup="insert"></asp:RequiredFieldValidator>

                    <td><asp:TextBox ID="lastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50"/></td>
                    <%-- validering --%>
                    <asp:RequiredFieldValidator ID="lastNameRequiredFieldValidator" runat="server" ErrorMessage="Efternamn måste anges" Display="Dynamic" 
                        ControlToValidate="lastName" ValidationGroup="insert"></asp:RequiredFieldValidator>

                    <td><asp:TextBox ID="emailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' MaxLength="50" /></td>
                    <%-- validering --%>
                    <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="Epost måste anges" Display="Dynamic" 
                        ControlToValidate="emailAddress" ValidationGroup="insert"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailExpressionValidator" runat="server" ErrorMessage="Epost-format är felaktigt" 
                        Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailAddress" ValidationGroup="insert"></asp:RegularExpressionValidator>
                    <td>
                        <%-- "Kommandknappar" för att lägga till en ny kunduppgift och rensa texfälten. --%>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" ValidationGroup="insert" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                    </td>
                </tr>                
            </InsertItemTemplate>
            <%-- Mall för rad i tabellen för att redigera kunduppgifter. --%>
            <EditItemTemplate>                
                <tr>
                    <td><asp:TextBox ID="firstName" runat="server" Text='<%# BindItem.FirstName %>'  MaxLength="50"/></td>
                    <%-- validering --%>
                    <asp:RequiredFieldValidator ID="firstNameRequiredFieldValidator" runat="server" ErrorMessage="Förnamn måste anges" Display="Dynamic" 
                        ControlToValidate="firstName" ValidationGroup="edit"></asp:RequiredFieldValidator>

                    <td><asp:TextBox ID="lastName" runat="server" Text='<%# BindItem.LastName %>' MaxLength="50"/></td>
                    <%-- validering --%>
                    <asp:RequiredFieldValidator ID="lastNameRequiredFieldValidator" runat="server" ErrorMessage="Efternamn måste anges" Display="Dynamic" 
                        ControlToValidate="lastName" ValidationGroup="edit"></asp:RequiredFieldValidator>

                    <td><asp:TextBox ID="emailAddress" runat="server" Text='<%# BindItem.EmailAddress %>' MaxLength="50" /></td>
                    <%-- validering --%>
                    <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" ErrorMessage="Epost måste anges" Display="Dynamic" 
                        ControlToValidate="emailAddress" ValidationGroup="edit"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailExpressionValidator" runat="server" ErrorMessage="Epost-format är felaktigt" 
                        Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailAddress" 
                        ValidationGroup="edit"></asp:RegularExpressionValidator>

                    <td>
                        <%-- "Kommandknappar" för att uppdatera en kunduppgift och avbryta. --%>
                        <asp:LinkButton  runat="server" CommandName="Update" Text="Spara" ValidationGroup="edit" CausesValidation="true" />
                        <asp:LinkButton  runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>                
            </EditItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
