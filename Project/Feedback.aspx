<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="headertitle"><p class="fs-1 fw-bold">Feedback Form</p></div>

     <div class="row mt-5">
              <div class="col-sm-2">
                <p class="mb-0 ml-4 fs-3 fw-semibold">User Id</p>
              </div>
              <div class="col-sm-9">
                  <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
              </div>
            </div>

    <div class="row mt-5">
              <div class="col-sm-2">
                <p class="mb-0 ml-4 fs-3 fw-semibold">Feedback</p>
              </div>
              <div class="col-sm-9">
                  <asp:TextBox ID="TextBox1" runat="server" Height="121px" Width="226px" class="form-control form-control-md"></asp:TextBox>
              </div>
            </div>

<%--    <div class="text-lg-start mt-4 pt-2">--%>
        <div class="row mt-5">
        <div class="col-sm-2">
              </div>
            <div class="col-sm-9">
              <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="btn btn-primary btn-md" 
        onclick="Button1_Click" style="padding-left: 2.5rem; padding-right: 2.5rem;"/>
                 </div>
<%--          </div>--%>


</asp:Content>
