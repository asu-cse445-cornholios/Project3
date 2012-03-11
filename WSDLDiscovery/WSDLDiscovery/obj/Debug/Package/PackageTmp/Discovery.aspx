<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Discovery.aspx.cs" Inherits="WSDLDiscovery.Discovery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: Calibri; font-size: xx-large; font-weight: bold; background-color: #0066CC;">
        WSDL DISCOVERY SERVICE</div>
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" 
        Font-Size="X-Large" Text="Enter Keywords:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox" runat="server" Height="20px" ViewStateMode="Disabled" 
        Width="210px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Height="24px" onclick="Button1_Click" 
        Text="GO" Width="85px" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Small" 
        Text="(Enter keywords deliminated by space, commas, or semi-colons)"></asp:Label>
    <p>
        <asp:Label ID="outputLabel" runat="server" Font-Bold="False" 
            Font-Names="Calibri"></asp:Label>
    </p>
    </form>
</body>
</html>
