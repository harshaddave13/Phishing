<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Reg.aspx.cs" Inherits="Reg" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section  style="margin-left: -30%;margin-right:20%;">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="images\reg.png"
          class="img-fluid" alt="Sample image">
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form>
          <div class="form-outline mb-4">
              <asp:TextBox ID="TextBox1" runat="server" placeholder="Name" class="form-control form-control-lg"></asp:TextBox>
          </div>

          <div class="form-outline mb-2">
              <asp:TextBox ID="TextBox2" runat="server" placeholder="Email" class="form-control form-control-lg"></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="Invalid" 
            ForeColor="Red" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
          </div>

             <div class="form-outline mb-4">
              <asp:TextBox ID="TextBox3" runat="server" placeholder="Address" class="form-control form-control-lg"></asp:TextBox>
          </div>

             <div class="form-outline mb-2">
              <asp:TextBox ID="TextBox4" runat="server" placeholder="Phone" class="form-control form-control-lg"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="TextBox4" ErrorMessage="Invalid" 
            ForeColor="Red" ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$"></asp:RegularExpressionValidator>
          </div>

             <div class="form-outline mb-4">
              <asp:TextBox ID="TextBox5" runat="server" placeholder="Username" class="form-control form-control-lg"></asp:TextBox>
          </div>

             <div class="form-outline mb-4">
              <asp:TextBox ID="TextBox6" runat="server" placeholder="Password" class="form-control form-control-lg"></asp:TextBox>
          </div>

            <div class="text-center text-lg-start mt-4 pt-2">
            <asp:Button ID="Button1" runat="server" Text="Register"  CssClass="btn btn-primary btn-lg" 
        onclick="Button1_Click" style="padding-left: 2.5rem; padding-right: 2.5rem;"/>
                </div>

        </form>
      </div>
    </div>
  </div>
</asp:Content>
