<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Printsample.aspx.cs" Inherits="aaaa" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript">
function CallPrint(strid)
{
var prtContent = document.getElementById(strid);
//var WinPrint = window.open('');
var WinPrint = window.open('','','letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
WinPrint.document.write(prtContent.innerHTML);
WinPrint.document.close();
WinPrint.focus();
WinPrint.print();
WinPrint.close();
// prtContent.innerHTML = strOldOne;
}
</script>

<Div id="DivContent" >
    <asp:Panel ID="Panel1" runat="server">
        fhthjkgvik<br />
        fgcvjkmhbvukjn,jnbjk<br />
        <br />
        fgyichkfgcyiovkb<br />
        <asp:Button ID="Button1" runat="server" OnClientClick="CallPrint('DivContent')" onclick="Button1_Click" Text="Button" />
    </asp:Panel>
    </Div> 
</asp:Content>

