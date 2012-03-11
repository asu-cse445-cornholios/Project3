<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WsHashOperations.aspx.cs" Inherits="WebClient.WsHashOperations" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="font-size: x-large; background-color: #0000FF; color: #FFFFFF; font-weight: bolder; height: 31px;">
            WsHashOperations<br />
        </div>
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Url:     " Width="50px"></asp:Label>
    
        <asp:TextBox ID="txtInput" runat="server" Width="595px"></asp:TextBox>
        <asp:Button ID="btnInvoke" runat="server" Text="Invoke" 
            onclick="btnInvoke_Click" />
    
    </div>
    <p>
        <asp:TextBox ID="txtResponse" runat="server" Height="183px" ReadOnly="True" 
            TextMode="MultiLine" Width="715px"></asp:TextBox>
    </p>
    </form>
</body>
</html>
