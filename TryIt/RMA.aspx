<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RMA.aspx.cs" Inherits="TryIt.RMA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Enter the required details and press submit.</p>
    <p>
        Customer ID:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Width="193px"></asp:TextBox>
    </p>
    <p>
        Order ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="193px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
    </p>
    <p>
        <asp:TextBox ID="TextBox3" runat="server" Height="270px" ReadOnly="True" 
            TextMode="MultiLine" Width="408px"></asp:TextBox>
    </p>
</asp:Content>
