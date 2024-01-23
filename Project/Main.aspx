<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Main.aspx.cs" Inherits="Main" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <img src="images/main.png" style="width: 30%;margin-left:20%" alt="Sample image">
    <div class="card" style="width: 21rem;height:12rem;margin-left:20%">
  <div class="card-body" style="display:grid;align-items:center;justify-content:center">
    <a href="AdminLogin.aspx"><button type="button" class="btn btn-primary btn-arrow-left">Admin Login</button></a>
    <a href="Login.aspx"><button type="button" class="btn btn-primary btn-arrow-right">User Login</button></a>
  </div>
</div>

</asp:Content>
