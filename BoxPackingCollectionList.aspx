<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BoxPackingCollectionList.aspx.cs" Inherits="BoxPackingCollectionList" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnSave"/>
   
   <asp:PostBackTrigger ControlID = "btnClear" />
   </Triggers>
   <ContentTemplate>
<body>  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 8pt; font-weight: bold; color: #FFFFFF; padding: 7px;" align="left">
                BOX PACKING COLLECTION LIST
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 3px" class="con_table">
               
                <table class="style1">
                    <tr>
                        <td>
                            Bpl No</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtBPLno" runat="server" AutoPostBack="True" 
                                ontextchanged="txtBPLno_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            Model</td>
                        <td>
                            <asp:TextBox ID="txtModel" runat="server" Enabled="False" Width="99px"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            Power</td>
                        <td>
                            <asp:TextBox ID="txtPower" runat="server" Enabled="False" Width="99px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="8">
                            <asp:GridView ID="gvBoxpacking" runat="server" AllowPaging="True" 
                                onpageindexchanging="gvBoxpacking_PageIndexChanging" Width="401px" 
                                CellPadding="1">
                                <RowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total</td>
                        <td>
                            <asp:TextBox ID="txttotal" runat="server" Enabled="False" Width="99px"></asp:TextBox>
                        </td>
                        <td>
                            Collecqty</td>
                        <td>
                            <asp:TextBox ID="txtcollected" runat="server" Enabled="False" Width="99px"></asp:TextBox>
                        </td>
                        <td>
                            Balance</td>
                        <td>
                            <asp:TextBox ID="txtBalance" runat="server" Enabled="False" Width="99px"></asp:TextBox>
                        </td>
                        <td>
                            CollBy</td>
                        <td>
                            <asp:TextBox ID="txtCollecBy" runat="server" AutoPostBack="True" 
                                ontextchanged="txtCollecBy_TextChanged" Width="99px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtCollecBy_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtCollecBy" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center">
                            <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                onclick="btnSave_Click" Visible="False" />
                            <asp:ImageButton ID="btnUpdate" runat="server" 
                                ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" Visible="False" />
                            <asp:ImageButton ID="btnClear" runat="server" 
                                ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" />
                            <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/images/chart.png" 
                                onclick="btnPrint_Click" Visible="False" />
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        </td>
                    </tr>
                </table>
               
            </td>
 <td>
 
 </td>
        </tr>
    </table>
    </body>
 </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>

