<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryGetWsOperations.aspx.cs" Inherits="WebClient.TryGetWsOperations" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div style="height: 34px; font-weight: bolder; color: #FFFFFF; background-color: #0000FF; font-size: x-large;">
            GetWsOperations</div>
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="url" Width="50px"></asp:Label>
    
        <asp:TextBox ID="txtInput" runat="server" Width="623px"></asp:TextBox>
        <asp:Button ID="btnInvoke" runat="server" onclick="btnInvoke_Click" 
            Text="Invoke" />
    
    </div>
    <p>
        <asp:TextBox ID="txtResponse" runat="server" Height="194px" ReadOnly="True" 
            TextMode="MultiLine" Width="729px"></asp:TextBox>
    </p>
    </form>
</body>
</html>
