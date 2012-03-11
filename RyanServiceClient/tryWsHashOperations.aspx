<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tryWsHashOperations.aspx.cs" Inherits="WebClient._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<div style="background-color: #6699FF; font-size: x-large; height: 47px;">Get WS 
    operations service</div>
    <form id="frmMain" runat="server">
    <div>
    
        <br />
    
        <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <asp:Button ID="btnInvoke" runat="server" onclick="btnInvoke_Click" 
            Text="Invoke" />
        <br />
        <br />
        <asp:TextBox ID="txtResponse" runat="server" Height="99px" Rows="4" 
            TextMode="MultiLine" Width="267px"></asp:TextBox>
        <br />
    
    </div>
    </form>
</body>
</html>
