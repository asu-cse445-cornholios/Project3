<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="definition.aspx.cs" Inherits="TryIt.definition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Please enter word to define"></asp:Label>
&nbsp;<asp:TextBox ID="txtWord" runat="server" Width="237px"></asp:TextBox>
&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Search Definitions" 
        onclick="Button1_Click" />
    <br />
    <br />
    <br />
    Results:<br />
    <asp:TextBox ID="txtResult" runat="server" Height="379px" TextMode="MultiLine" 
        Width="659px"></asp:TextBox>
</asp:Content>
