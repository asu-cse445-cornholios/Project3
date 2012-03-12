<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tryIt.aspx.cs" Inherits="MusicLookupService.tryIt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Enter name to search:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="198px"></asp:TextBox>
    
    </div>
    <asp:Label ID="Label2" runat="server" Text="Which method:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>findArtists</asp:ListItem>
        <asp:ListItem>findReleaseGroups</asp:ListItem>
        <asp:ListItem>findReleases</asp:ListItem>
        <asp:ListItem>findRecordings</asp:ListItem>
        <asp:ListItem>findLabels</asp:ListItem>
        <asp:ListItem>findWorks</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Invoke" />
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Height="208px" ReadOnly="True" 
            style="margin-left: 2px" TextMode="MultiLine" Width="675px"></asp:TextBox>
    </p>
    </form>
</body>
</html>
