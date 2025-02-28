<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductReleaseNote.aspx.cs" Inherits="ProductReleaseNote" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnSave"/>
  
   <asp:PostBackTrigger ControlID = "btnClear" />
   </Triggers>
   <ContentTemplate>
    <table cellpadding="0" cellspacing="0" width="100%" class="con_table">
    <tr>
        <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
            PRODUCT&nbsp; RELEASE&nbsp; NOTE</td>
    </tr>
    <tr>
        <td align="left" style="padding-top: 3px">
            <table class="style1">
                <tr>
                    <td style="width: 63px">
                        PRN&nbsp;No</td>
                    <td style="width: 5px">
                        <asp:TextBox ID="txtPRNno" runat="server" AutoPostBack="True" 
                            ontextchanged="txtPRNno_TextChanged"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtPRNno_FilteredTextBoxExtender" 
                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtPRNno">
                        </cc1:FilteredTextBoxExtender>
                    </td>
                    <td>
                        &nbsp;<asp:Label ID="lblSterileBNO" runat="server" Text="Sterile B.No" 
                            Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSterileBNo" runat="server" 
                            ontextchanged="txtSterileBNo_TextChanged" Enabled="False" Visible="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCurrentDate" runat="server" Text="Date" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCdate" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Panel ID="pnlPRN" runat="server">
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMHSRNo" runat="server" Text="MHSR No" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMHSRno" runat="server" Enabled="False" Visible="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDate" runat="server" Text="Date" Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" Enabled="False" 
                                            ontextchanged="txtDate_TextChanged" Visible="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:GridView ID="gvPRNno" runat="server" AllowPaging="True" 
                                            onpageindexchanging="gvPRNno_PageIndexChanging" Width="295px">
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblApprovedBy" runat="server" Text="Approved By" Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtAppBy" runat="server" AutoPostBack="True" 
                                            CssClass="textbox_200" ontextchanged="txtAppBy_TextChanged" Visible="False"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtAppBy_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtAppBy" 
                                            ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAuthSign" runat="server" Text="Authorised   signature" 
                                            Visible="False"></asp:Label>
                                        <asp:TextBox ID="txtAuthSig" runat="server" AutoPostBack="True" 
                                            CssClass="textbox_200" ontextchanged="txtAuthSig_TextChanged" Visible="False"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtAuthSig_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtAuthSig" 
                                            ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                            onclick="btnSave_Click" Visible="False" />
                                        <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_update.png" 
                                            onclick="btnUpdate_Click" Visible="False" />
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/btn_clear.png" 
                                            onclick="btnClear_Click" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

