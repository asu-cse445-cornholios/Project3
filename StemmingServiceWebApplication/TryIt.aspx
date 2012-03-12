<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs"
    Inherits="StemmingServiceWebApplication.StemmingServiceTryItPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }

        .auto-style2
        {
            width: 125px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Words to Analyze:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtInput" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Replace Words with Stem" 
                        OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Result:"></asp:Label></td>
                <td>
                    <asp:Label ID="lblResult" runat="server" Width="100%"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
