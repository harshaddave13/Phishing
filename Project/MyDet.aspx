<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="MyDet.aspx.cs" Inherits="MyDet" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="headertitle"><p class="fs-1 fw-bold">My Details</p></div>
    
    <div class="col-lg-12">
        <div class="card mb-4">
          <div class="card-body">
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Name</p>
              </div>
              <div class="col-sm-9">
                  <asp:Label ID="Label2" runat="server" Text="Name" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Email ID</p>
              </div>
              <div class="col-sm-9">
                  <asp:Label ID="Label4" runat="server" Text="Email" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Address</p>
              </div>
              <div class="col-sm-9">
                  <asp:Label ID="Label6" runat="server" Text="Address" class="text-muted mb-0"></asp:Label>

              </div>
            </div>
            <hr>
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0">Mobile</p>
              </div>
              <div class="col-sm-9">
                   <asp:Label ID="Label8" runat="server" Text="Label" class="text-muted mb-0"></asp:Label>
              </div>
            </div>
          </div>
        </div>

</asp:Content>