<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="blackliste_words_list.aspx.cs" Inherits="blackliste_words_list" %>
<asp:Content ID="h" ContentPlaceHolderID="head" runat="server">
   <script type = "text/javascript">
       function Confirm() {
           var confirm_value = document.createElement("INPUT");
           confirm_value.type = "hidden";
           confirm_value.name = "confirm_value";
           if (confirm("Do you want to blacklist this word?")) {
               confirm_value.value = "Yes";
           } else {
               confirm_value.value = "No";
           }
           document.forms[0].appendChild(confirm_value);
       }
    </script>
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="headertitle"><p class="fs-1 fw-bold">Blacklisted Word Confirmation</p></div>

    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover mt-5" ForeColor="#000000"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" OnRowCommand="GridView1_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" /> 
    <Columns>
        <asp:TemplateField HeaderText ="Blacklist">
         <ItemTemplate>
        <asp:LinkButton ID="yes" runat ="server" CommandArgument='<%#Eval("word")%>' Text ="Click" CommandName ="yes" ></asp:LinkButton>
      </ItemTemplate>
    </asp:TemplateField>
    </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" 
        HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
</asp:GridView>

    <asp:Panel ID="Panel1" runat="server">
      <div class="row mt-5">
              <div class="col-sm-2">
                <p class="mb-0 ml-4">Blacklisted Word</p>
              </div>
              <div class="col-sm-9">
                  <asp:TextBox ID="TextBox1" runat="server" class="form-control form-control-md"></asp:TextBox>
              </div>
            </div>

    <div class="text-center text-lg-start mt-4 pt-2">
              <asp:Button ID="Button1" runat="server" Text="Submit"  CssClass="btn btn-primary btn-md" 
        onclick="Button1_Click" style="padding-left: 2.5rem; padding-right: 2.5rem;" OnClientClick = "Confirm()"/>
          </div>
        </asp:Panel>

   <%-- <table width="80%">

<tr><td colspan="2" class="style2"><br /></td></tr>
<tr><td colspan="2" align="center">
    
</td></tr>
<tr><td colspan="2"><br /></td></tr>
<tr><td colspan="2">
    <asp:Panel ID="Panel1" runat="server">
    <table width="80%">
    <tr><td colspan="2"><br /></td></tr>
    <tr><td align="left">
        <asp:Label ID="Label2" runat="server" Text="Blacklisted Word" 
            Font-Names="Gadugi" Font-Size="Large"></asp:Label></td><td align="left">
            <asp:TextBox ID="TextBox1" runat="server" Height="30px" Width="163px"></asp:TextBox></td></tr>
    <tr><td colspan="2"><br /></td></tr>
     <tr><td colspan="2" align="center">
         <asp:Button ID="Button1" runat="server" Text="Submit" Height="40px" 
             onclick="Button1_Click" OnClientClick = "Confirm()" Width="75px" />&nbsp;</td></tr>
    </table>
    </asp:Panel>
</td></tr>
</table>--%>

</asp:Content>

