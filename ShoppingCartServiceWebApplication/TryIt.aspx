<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="ShoppingCartServiceWebApplication.ShoppingCartServiceTryItPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="Button2" runat="server" Text="Create New Cart" 
                        OnClick="Button2_Click" />
                </td>
            </tr>
           
              <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Cart Id:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCartId" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Result:"></asp:Label></td>
                <td>
                    <asp:Label ID="lblResult" runat="server" Width="100%"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Item to Add:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtInput" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
           <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Item Quantity:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtItemQuantity" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Add Item" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Item number:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtItemNumber" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
           
             <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="Button3" runat="server" Text="Remove Item" 
                        onclick="Button3_Click" />
                </td>
            </tr>
             <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="Button4" runat="server" Text="Update Item" 
                        onclick="Button4_Click" />
                </td>
            </tr>
             <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="Button5" runat="server" Text="Clear Shopping Cart" 
                        onclick="Button5_Click" />
                </td>
            </tr>
             <tr>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="Button6" runat="server" Text="Remove Cart" onclick="Button6_Click" 
                       />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
