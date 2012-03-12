<%@ Page Title="news" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewFocus.aspx.cs" Inherits="TryIt.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        Enter topics in boxes below</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Width="124px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Width="133px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Width="133px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Width="133px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Width="133px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Click to search for news" 
            onclick="Button1_Click" />
    </p>
    </asp:Content>
