<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gissa_Det_Hemliga_Talet.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Gissa Det Hemliga Talet!</h1>
    </div>
        <%-- Presentation av felmeddelanden --%>

        <div>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="error" />
        </div>

        <%-- Inmatning av gissning --%>
        <div>
        <asp:label ID="Label1" runat="server" text="Ange ett tal mellan 1-100"></asp:label>
        <asp:TextBox ID="Input" runat="server"></asp:TextBox>

        <asp:Button ID="Send" runat="server" Text="Skicka gissning" OnClick="Send_Click" />
    </div>
        
        <%-- Presentation av gjorda gissningar och om gissningen är hög, låg eller rätt --%>
        <div>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </asp:PlaceHolder>
            
            <div>
            <asp:PlaceHolder ID="ButtonHolder" runat="server" Visible="false">
                <asp:Button ID="NewNumber" runat="server" Text="New Number?" OnClick="NewNumber_Click" />
            </asp:PlaceHolder>
            </div>
    </div>
        <%-- Validation --%>
        <div>
            <asp:RequiredFieldValidator ID="NotEmpty" runat="server" ErrorMessage="Du måste ange en gissning" ControlToValidate="Input" Display="Dynamic" Text=""></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Input" ErrorMessage="Ange ett tal mellan 1-100" MaximumValue="100" MinimumValue="1" Type="Integer" Display="Dynamic" Text=""></asp:RangeValidator>
        </div>
    </form>
</body>
</html>
