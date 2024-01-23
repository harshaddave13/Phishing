<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="WebP.aspx.cs" Inherits="WebP" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <br />
    <asp:Label ID="Label1" runat="server" Text="Website" Font-Bold="True"></asp:Label>
    &nbsp;
    <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="545px"></asp:TextBox><br /><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="intabular" 
    Height="30px" onclick="Button1_Click" Width="86px" />
    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:Label ID="Label7" runat="server" Text="Label" Visible="False"></asp:Label>
<br />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
<br />
<asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
    <br />
    <br />
    <br />
<iframe id="I1" runat="server" name="I1" class="auto-height" frameborder="1" 
        width="100%">your browser does not support IFRAMEs</iframe><br />
<br />
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #I1
        {
            height: 500px;
        }
    </style>
</asp:Content>