<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fridas Labb 3 -Konvertera temperaturer</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>Konvertera temperaturer</h1>
    <form id="form1" runat="server">
    <%-- starttemp --%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Fel inträffade. Åtgärda felen och försök igen." />
    <div>        
        <asp:Label ID="StartTempLabel" runat="server" Text="Starttemperatur:" AssociatedControlID="StartTempTextBox"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="StartTempTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ange en starttemperatur"
            ControlToValidate="StartTempTextBox" Display="Dynamic">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ange ett heltal" Type="Integer" 
            ControlToValidate="StartTempTextBox" Operator="DataTypeCheck">*</asp:CompareValidator>
    </div>
    <%-- sluttemp --%>
    <div>
        <asp:Label ID="StopTempLabel" runat="server" Text="Sluttemperatur:" AssociatedControlID="StopTempTextBox"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="StopTempTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ange en sluttemperatur"
            ControlToValidate="StopTempTextBox" Display="Dynamic" >*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="BiggerCompareValidator" runat="server" ErrorMessage="Sluttemperatur måste vara större än starttemperaturen" 
            Type="Integer" ControlToValidate="StopTempTextBox" Operator="GreaterThan" ControlToCompare="StartTempTextBox">*</asp:CompareValidator>
        <asp:CompareValidator ID="IntCompareValidator" runat="server" ErrorMessage="Ange ett heltal" Type="Integer" 
            ControlToValidate="StopTempTextBox" Operator="DataTypeCheck">*</asp:CompareValidator>
    </div>
    <%-- tempsteg --%>
    <div>
        <asp:Label ID="StepLabel" runat="server" Text="Temperatursteg:" AssociatedControlID="StepTextBox"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="StepTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ange ett temperatursteg"
            ControlToValidate="StepTextBox" Display="Dynamic" >*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Ange ett heltal" Type="Integer" 
            ControlToValidate="StepTextBox" Operator="DataTypeCheck">*</asp:CompareValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ange ett steg mellan 1 & 100" Type="Integer" 
            ControlToValidate="StepTextBox" MaximumValue="100" MinimumValue="1">*</asp:RangeValidator>
    </div>
    <div>
    <fieldset><legend>Välj typ av konvertering</legend>
        <div>
            <asp:RadioButton ID="CRadioButton" runat="server" Text="Celsius till Fahrenheit" GroupName="Temp" Checked="true"/>
        </div>
        <div>
            <asp:RadioButton ID="FRadioButton" runat="server" Text="Fahrenheit till Celsius"  GroupName="Temp" />
        </div>
    </fieldset>
    </div>
    <div>
        <asp:Button ID="ConvertButton" runat="server" Text="Konvertera" OnClick="ConvertButton_Click" />
    </div>
        <%-- Tabell --%>
        <asp:Table ID="TempTable" runat="server" Visible="false">
            <asp:TableRow>
                <asp:TableHeaderCell ID="Col1" Text="{0}"></asp:TableHeaderCell>
                <asp:TableHeaderCell ID="Col2" Text="{0}"></asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
