<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressTry.aspx.cs" Inherits="Address.Address" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Calibri; font-size: xx-large; font-weight: bold; background-color: #0066CC;">
        WSDL ADDRESS SERVICE</div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" 
        Font-Size="X-Large" Text="Enter Website:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox" runat="server" Height="20px" ViewStateMode="Disabled" 
        Width="184px">http://</asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Height="24px" onclick="Button1_Click" 
        Text="GO" Width="85px" />
    <p>
        <asp:Label ID="outputLabel" runat="server" Font-Bold="False" 
            Font-Names="Calibri"></asp:Label>
    </p>
    </form>
</body>
</html>
