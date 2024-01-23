<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section  style="margin-left: -30%;margin-right:20%;margin-top:10%">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
          class="img-fluid" alt="Sample image">
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form>
          <!-- Email input -->
          <div class="form-outline mb-4">
              <asp:TextBox ID="TextBox1" runat="server" placeholder="User ID" class="form-control form-control-lg"></asp:TextBox>
          </div>

          <!-- Password input -->
          <div class="form-outline mb-3">
              <asp:TextBox ID="TextBox2" runat="server" type="password" placeholder="Password" class="form-control form-control-lg"></asp:TextBox>
          </div>

          <div class="text-center text-lg-start mt-4 pt-2">
              <asp:Button ID="Button1" runat="server" Text="Login"  CssClass="btn btn-primary btn-lg" 
        onclick="Button1_Click" style="padding-left: 2.5rem; padding-right: 2.5rem;"/>
            <p class="large fw-bold mt-2 pt-1 mb-0">Don't have an account? <a href="Reg.aspx"
                class="link-danger">Register</a></p>
          </div>

        </form>
      </div>
    </div>
  </div>

</asp:Content>