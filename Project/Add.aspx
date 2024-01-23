<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Add.aspx.cs" Inherits="Add" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="headertitle"><p class="fs-1 fw-bold">Add To Blacklist</p></div>

 
    <div class="row mt-5">
              <div class="col-sm-2">
                <p class="mb-0 ml-4">URL :</p>
              </div>
              <div class="col-sm-9">
                  <asp:TextBox ID="TextBox1" runat="server" placeholder="URL" class="form-control form-control-md"></asp:TextBox>
              </div>
            </div>

<asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
<br />
<asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label> 

    <div class="text-center text-lg-start mt-4 pt-2">
              <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="btn btn-primary btn-md" 
        onclick="Button1_Click" style="padding-left: 2.5rem; padding-right: 2.5rem;"/>
          </div>
<br />
<br />
</asp:Content>