<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gissa_Det_Hemliga_Talet.Default" ViewStateMode="Enabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Gissa Det Hemliga Talet!</h1>
    </div>
        <asp:Label ID="Guess" runat="server" Text=""></asp:Label>
        <div>
            <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="error" />
        </div>

        <div>
        <asp:label ID="Label1" runat="server" text="Ange ett tal mellan 1-100"></asp:label>
        <asp:TextBox ID="Input" runat="server"></asp:TextBox>

        <asp:Button ID="Send" runat="server" Text="Skicka gissning" OnClick="Send_Click" />
    </div>
        
        <div>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </asp:PlaceHolder>
        
       </div>
        
        <div>

        </div>

        <div>
            <asp:RequiredFieldValidator ID="NotEmpty" runat="server" ErrorMessage="Du måste ange en gissning" ControlToValidate="Input" ></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Input" ErrorMessage="Ange ett tal mellan 1-100" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        </div>
    </form>
</body>
</html>
