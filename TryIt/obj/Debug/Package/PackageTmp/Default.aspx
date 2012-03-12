<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TryIt._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>Top10 Try It Page</h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Enter URL: "></asp:Label>
&nbsp;
        <asp:TextBox ID="txtURL" runat="server" Width="547px" 
            ontextchanged="TextBox1_TextChanged"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Top10 Words" 
            onclick="Button1_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Height="162px" Width="631px" 
            TextMode="MultiLine" Wrap="False"></asp:TextBox>
    </p>
    </asp:Content>
