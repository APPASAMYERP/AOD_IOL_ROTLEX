        <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="qualityControlSample.aspx.cs" Inherits="qualityControlSample" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script runat="server"></script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
   <table cellpadding="0" cellspacing="0" width="100%" class="con_table">
                        <tr>
                            <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
                                Quality Control Sample</td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top: 3px">
                                
                                <table class="nav" cellpadding="1" cellspacing="1">
        <tr>
            <td class="textlbl">
                Date :</td>
            <td class="style6">
                <asp:TextBox ID="txtDate" runat="server" Width="100px" Enabled="False"></asp:TextBox>
                                 </td>
            <td class="style7">
                Batch No :
                                 </td>
            <td class="textlbl">
                <asp:TextBox ID="txtBatchNo" runat="server" Width="100px" AutoPostBack="True" 
                    ontextchanged="txtBatchNo_TextChanged"></asp:TextBox>
                                 </td>
            <td class="textlbl">
                Test Type:                 
                                 </td>
            <td class="textlbl">
                <asp:DropDownList ID="ddlTestType" 
                    runat="server" Width="90px" 
                    onselectedindexchanged="ddlTestType_SelectedIndexChanged" 
                    AutoPostBack="True">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Lal</asp:ListItem>
                    <asp:ListItem>Sterile</asp:ListItem>
                </asp:DropDownList>
                                 </td>
            <td class="style6">
                Lot No:</td>
            <td class="textlbl">
                <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                    ontextchanged="txtLotNo_TextChanged" Width="100px" MaxLength="8" 
                    Visible="False"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" TargetControlID="txtLotNo">
                </cc1:FilteredTextBoxExtender>
                                 <asp:DropDownList ID="ddlLabeldtlLotNo" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlLabeldtlLotNo_SelectedIndexChanged">
                                     <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
                                 </td>
        </tr>
        <tr>
            <td class="textlbl">
                Model :&nbsp;</td>
            <td class="style6">
                <asp:TextBox ID="txtModel" 
                    runat="server" Enabled="False" Width="100px" Visible="False"></asp:TextBox>
                                 <cc1:FilteredTextBoxExtender ID="txtModel_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtModel">
                </cc1:FilteredTextBoxExtender>
                                 <asp:DropDownList ID="ddlModelNumber" runat="server" 
                    AppendDataBoundItems="True">
                </asp:DropDownList>
                                 </td>
            <td class="style7">
                Power:&nbsp;
                                 </td>
            <td class="textlbl">
                <asp:DropDownList ID="ddlPower" runat="server" Width="100px" 
                    AppendDataBoundItems="True">
                </asp:DropDownList>
                                 </td>
            <td class="textlbl">
                &nbsp;Serial No:</td>
            <td class="textlbl">
                <asp:DropDownList ID="ddlSerialNo" 
                    runat="server" Width="90px">
                </asp:DropDownList>
                                 <asp:ImageButton ID="btnSerialNo" runat="server" 
                    ImageUrl="~/images/AddSerial.png" onclick="btnSerialNo_Click"  
                    Visible="False" />
                                 <cc1:ConfirmButtonExtender ID="btnSerialNo_ConfirmButtonExtender" 
                    runat="server" 
                    ConfirmText="Are you sure you need make changes. Click on ok  to continue. " 
                    Enabled="False" TargetControlID="btnSerialNo">
                </cc1:ConfirmButtonExtender>
                                 </td>
            <td class="style6">
                &nbsp;&nbsp;&nbsp;
                Quantiy:
                                 </td>
            <td class="textlbl">
                <asp:TextBox ID="txtQuantity" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                                 </td>
        </tr>
        <tr>
            <td class="textlbl">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style7">
                &nbsp;                 
                                 </td>
            <td class="textlbl">
                                 &nbsp;</td>
            <td class="textlbl">
                &nbsp;</td>
            <td class="textlbl">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="textlbl">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8" align="center">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     `
                 </ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID ="btnSave" />
    <asp:PostBackTrigger ControlID ="btnUpdate" />
    <asp:PostBackTrigger ControlID = "btnClear" />
    <asp:PostBackTrigger ControlID ="btnAdd" />
    <asp:PostBackTrigger ControlID ="btnClose" />
    </Triggers>
       </asp:UpdatePanel>
                <asp:Button ID="btnPopup" runat="server" Text="Button" Style="display: none" />
                <cc1:ModalPopupExtender ID="mpePopup" runat="server" TargetControlID="btnPopup" DropShadow="true"
                    Enabled="true" PopupControlID="Panel1" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup">
                    <table class="style5">
                        <tr>
                            <td align="left">
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" CellPadding="1" 
                                    CellSpacing="15" RepeatColumns="20" RepeatDirection="Horizontal" Width="400px">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/btn_Add.png" 
                                    onclick="btnAdd_Click" />
                                <asp:ImageButton ID="btnClose" runat="server" 
                                    ImageUrl="~/images/btn_close.png" onclick="btnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
             
                                 </td>
        </tr>
        <tr>
            <td align="center" colspan="8">
                                 <asp:ImageButton ID="btnSave" runat="server" 
                    ImageUrl="~/images/btn_save.png" onclick="btnSave_Click" Visible="False" />
                <asp:ImageButton ID="btnUpdate" runat="server" 
                    ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" 
                    Visible="False" />
                <asp:ImageButton ID="btnClear" runat="server" 
                    ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" Visible="False" />
                                 </td>
        </tr>
        <tr>
            <td align="left" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" colspan="8">
               
            </td>
        </tr>
    </table>
                                
                            </td>
                        </tr>
                    </table>
 
   
           
</asp:Content>
