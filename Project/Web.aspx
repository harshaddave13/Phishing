<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master" CodeFile="Web.aspx.cs" Inherits="Web" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
<script>
    $(document).ready(function () {
        $("#flip").click(function () {
            $("#panel").slideToggle("slow");
        });
    });
</script>

<style> 
#panel, #flip {
    padding: 5px;
    text-align:left;
    color:Blue;
    background-color: white;
    border: solid 1px none;
}

#panel {
    padding: 25px;
    display: none;
}
</style>
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;
   
    <br /><br />
     <div   id="flip"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Enter Website URL</b></div>
                <div id="panel">
                    <img src="images/srch.png" height="20px" width="20px" /> <asp:TextBox ID="TextBox1" runat="server" Height="34px" Width="545px" 
    CssClass="intabular" BorderColor="Aqua"></asp:TextBox>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" 
    Text="Search" CssClass="intabular" 
    Height="33px" onclick="Button1_Click" Width="206px" 
    BorderColor="Aqua" />        
                </div>
    
    <br />
    <asp:Label ID="Label9" runat="server" Font-Bold="True" 
        Font-Names="Comic Sans MS" ForeColor="#CC0000"></asp:Label>
    <br />
    
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Aharoni"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
<br />
    <asp:Label ID="Label7" runat="server" Font-Names="Aharoni"></asp:Label>
&nbsp;&nbsp;&nbsp;<asp:Label ID="title1" runat="server" Text="Label" 
    Visible="False"></asp:Label>
    &nbsp;&nbsp;
<br />
    <asp:Label ID="Label8" runat="server" Font-Names="Aharoni"></asp:Label>
&nbsp;<asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Visible="false">    
    <marquee direction="right"><img src="images/blck.png" height="30px"/></marquee><br />
    </asp:Panel>
     <asp:Panel ID="Panel2" runat="server" Visible="false">    
    <marquee direction="right"><img src="images/nblck.png" height="30px"/></marquee><br />
    </asp:Panel>
<iframe id="I1" runat="server" name="I1"  frameborder="1" 
        width="100%" style="height: 650px; width: 850px;" visible="False">your browser does not support IFRAMEs</iframe>
    <br />
    <br />
    <br />
    
    <br />
<br />
</asp:Content>


