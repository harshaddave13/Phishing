<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Update.aspx.cs" Inherits="Update" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<table><tr><td>
    <asp:Label ID="Label3" runat="server" Text="User Id" Font-Names="Gadugi" 
        Font-Size="Large"></asp:Label>
    <br />
    <br />
</td>
<td>
    <asp:Label ID="Label4" runat="server" Text="Label" Font-Names="Gadugi"></asp:Label>
    <br />
    <br />
    </td>
</tr>
<tr><td colspan="2"></td></tr>
<tr><td>
    <asp:Label ID="Label1" runat="server" Text="Old Password" Font-Names="Gadugi"></asp:Label>
    <br />
    <br />
</td>
<td>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    </td>
</tr>

<tr><td>
    <asp:Label ID="Label2" runat="server" Text="New Password" Font-Names="Gadugi"></asp:Label>
    <br />
    <br />
</td>
<td>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />
    </td>
</tr>
<tr><td colspan="2">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Update" CssClass="intabular" 
        Height="33px" Width="95px" onclick="Button1_Click" BorderColor="Red" />
    <br />
    <br />
    </td></tr>

</table>
</asp:Content>
