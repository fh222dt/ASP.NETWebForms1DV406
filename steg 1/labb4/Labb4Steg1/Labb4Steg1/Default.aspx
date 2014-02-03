<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Labb4Steg1.Default" ViewStateMode="Disabled" %>

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
                <p><asp:Label ID="ResultLabel" runat="server" Text="{0} {1}"></asp:Label></p>
            </asp:PlaceHolder>

            <div id="newGuess">
                <asp:PlaceHolder ID="NewGuessPlaceHolder" runat="server" Visible="false" >
                    <asp:Button ID="NewGuessButton" runat="server" Text="Slumpa nytt hemligt tal" OnClick="NewGuessButton_Click" />
                </asp:PlaceHolder>                    
            </div>
            
        </div>
    </form>
</body>
</html>
