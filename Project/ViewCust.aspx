<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ViewCust.aspx.cs" Inherits="ViewCust" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="headertitle"><p class="fs-1 fw-bold">User List</p></div>

   
   <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" 
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
    <Columns>
    <asp:BoundField HeaderText="Name" DataField="name" />
     <asp:BoundField HeaderText="Email-id" DataField="email" />
      <asp:BoundField HeaderText="Address" DataField="addr" />
       <asp:BoundField HeaderText="Contact No" DataField="cont" />

    </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>--%>
    

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover mt-5" ForeColor="#000000"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                <AlternatingRowStyle BackColor="#CCCCCC" /> 
    <Columns>
        <asp:BoundField HeaderText="Name" DataField="name" />
     <asp:BoundField HeaderText="Email-id" DataField="email" />
      <asp:BoundField HeaderText="Address" DataField="addr" />
       <asp:BoundField HeaderText="Contact No" DataField="cont" />
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

</asp:Content>

