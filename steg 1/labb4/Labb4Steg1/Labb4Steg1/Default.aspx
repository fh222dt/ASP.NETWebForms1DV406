<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Labb4Steg1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fridas Labb 4 -Gissa det hemliga talet</title>
    <link href="~/Content/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>Gissa det hemliga talet</h1>
    <form id="form1" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade. Åtgärda felen och försök igen." />
    <%-- inmatning av gissning --%>
    <div id="guess">
        <asp:Label ID="GuessNumberLabel" runat="server" Text="Ange ett tal mellan 1 & 100: "></asp:Label>
        <asp:TextBox ID="GuessNumberTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="GuessButton" runat="server" Text="Skicka gissning" OnClick="GuessButton_Click" />
        <%-- validering --%>
        <asp:RequiredFieldValidator ID="GuessNumberTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Ett tal måste anges" ControlToValidate="GuessNumberTextBox" Display="Dynamic">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="GuessNumberTextBoxRangeValidator" runat="server" ErrorMessage="Ange ett tal mellan 1 & 100" ControlToValidate="GuessNumberTextBox" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
    </div>

    <%-- presentation av gissningar --%>
        <div id="results">
            <asp:PlaceHolder ID="ResultPlaceHolder" runat="server" Visible="false">
                <p></p><asp:Label ID="NumberResultLabel" runat="server" Text="här ska gissade tal synas || {0} "></asp:Label></p>
                <p><asp:Label ID="ResultatLabel" runat="server" Text="Grattis du klarade det på {0} försök!"></asp:Label></p>
                <div id="newGuess">
                    <asp:Button ID="NewGuessButton" runat="server" Text="Slumpa nytt hemligt tal" />
                </div>
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
