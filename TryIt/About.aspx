<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="TryIt.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Word Filter Try It Page</h2>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Enter  a string to filter"></asp:Label>
&nbsp;(please note: the webToString service that the service relies on has a limit of 
        8092 characters to work)</p>
<p>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtInputString" runat="server" Width="354px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Filter Stop Words" />
    </p>
    <p>
        <asp:TextBox ID="txtOutput" runat="server" Height="391px" Width="758px" 
            TextMode="MultiLine"></asp:TextBox>
    </p>
</asp:Content>
