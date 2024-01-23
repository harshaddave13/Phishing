<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Phishing_webpage.aspx.cs" Inherits="Phishing_webpage" %>


<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="headertitle"><p class="fs-1 fw-bold">Scan Website Url</p></div>

     <div class="row mt-5">
              <div class="col-sm-2">
                <p class="mb-0 ml-4">Enter Url :</p>
              </div>
              <div class="col-sm-9">
                  <asp:TextBox ID="TextBox1" runat="server" placeholder="URL" class="form-control form-control-md"></asp:TextBox>
              </div>
            </div>

     <div class="text-center text-lg-start mt-4 pt-2">
              <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="btn btn-primary btn-md" 
        onclick="Button1_Click" style="padding-left: 2.5rem; padding-right: 2.5rem;"/>
          </div>

    <table width="80%">
    <tr><td colspan="1" class="style2" align="left">
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Gadugi" 
            Font-Size="Large" ForeColor="Black"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Names="Gadugi" Font-Size="Medium" 
            ForeColor="#3333CC"></asp:Label>
        <br />
        </td></tr>
    <tr><td colspan="2"><iframe id="I1" runat="server" name="I1"  frameborder="1" 
        width="100%" style="height: 650px; width: 850px;" visible="False">your browser does not support IFRAMEs</iframe></td></tr>
</table>

</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
    .style2
    {
        height: 23px;
    }
    table{
        margin-left:10%;
    }
</style>
</asp:Content>

