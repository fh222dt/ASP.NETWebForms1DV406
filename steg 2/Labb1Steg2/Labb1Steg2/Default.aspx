<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Labb1Steg2.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fridas Labb 1 -Galleriet</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />

</head>
<body>
<h1>Galleriet</h1>
    <form id="form1" runat="server">
    <div>
     <%-- Rättmeddelande vid uppladdning av bild --%>
        <asp:PlaceHolder ID="SuccessPlaceHolder" runat="server" Visible="false">
            <div id="success">
                <div id="close"></div>
                <p>Bilden har sparats</p>
            </div>                
        </asp:PlaceHolder>
    <%-- En stor yta för bilden att visas --%>        
        <asp:Image ID="BigImage"  runat="server" />        
        <%-- Tumnaglar --%>
        <div id="thumbsArea">
            <div id="thumbs">
            <asp:Repeater ID="thumbsRepeater" runat="server" OnItemDataBound="thumbsRepeater_ItemDataBound">                
                <ItemTemplate>
                    <asp:HyperLink ID="thumbHyperLink" runat="server" NavigateUrl='<%# "~/default.aspx?name=" + Eval("Name", "{0}") %>'>
                        <asp:Image ID="ThumbImage" runat="server" CssClass="thumbs" ImageUrl='<%# Eval("Name", "~/img/thumbs/{0}") %>' CommandName="bigger" />
                    </asp:HyperLink> 
                </ItemTemplate>
            </asp:Repeater>
            </div>
        </div>
        <%-- Validering av uppladdning --%>
        <asp:ValidationSummary ID="ValidationSummary" runat="server"  HeaderText="Fel inträffade. Åtgärda felen och försök igen."  />
        
        
        <asp:RequiredFieldValidator ID="FileUploadRequiredFieldValidator" runat="server" ErrorMessage="En fil måste väljas." 
            ControlToValidate="galleryFileUpload" Display="Dynamic" >*</asp:RequiredFieldValidator>

        <asp:RegularExpressionValidator ID="FileUploadRegularExpressionValidator" runat="server" 
            ErrorMessage="Endast filer med filändelsen .gif, .jpg, eller .png är tillåten." ControlToValidate="galleryFileUpload"
            display="Dynamic" ValidationExpression="^.*\.(gif|GIF|jpg|JPG|png|PNG)$"  >*</asp:RegularExpressionValidator>
        <%-- Uppladdning av bild --%>
        <asp:FileUpload ID="galleryFileUpload" runat="server" />
        <asp:Button ID="uploadButton" runat="server" Text="Ladda upp" OnClick="uploadButton_Click" />
    </div>
    <script src="gallery.js"></script>
    </form>
    
</body>
</html>
