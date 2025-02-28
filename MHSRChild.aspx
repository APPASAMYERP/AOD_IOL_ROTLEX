<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MHSRChild.aspx.cs" Inherits="MHSRChild" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:PostBackTrigger ControlID = "btnSave" />
    <asp:PostBackTrigger ControlID = "btnUpdate" />
    <asp:PostBackTrigger ControlID = "btnClear" />
     </Triggers>
   <ContentTemplate>
    <table class="style1">
        <tr>
            <td colspan="6">
                &nbsp;</td>
        </tr>
        <tr class="textlbl">
            <td>
                MHSR NO:</td>
            <td>
                <asp:TextBox ID="txtMHSRNo" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtMHSRNo_TextChanged"></asp:TextBox>
            </td>
            <td>
                Date</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
            </td>
            <td>
                                                    Shift</td>
            <td>
                <asp:DropDownList ID="ddlShift" runat="server" CssClass="dropdown">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>II</asp:ListItem>
                    <asp:ListItem>III</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <table border="1" cellspacing="1" class="style5">
                    <tr class="colorvision">
                        <td align="center" colspan="14">
                            <b>Moist Heat Sterilization Record</b></td>
                    </tr>
                    <tr class="textlbl">
                        <td>
                            Date</td>
                        <td>
                            B.No</td>
                        <td>
                            Particulars</td>
                        <td>
                            Door Closed Time</td>
                        <td>
                            Steam opened<br />Time</td>
                        <td>
                            Vent closed<br />Time</td>
                        <td>
                            press attained Time</td>
                        <td>
                            press</td>
                        <td>
                            Temp</td>
                        <td>
                            Maintained upto</td>
                        <td>
                            vent Opened<br />Time</td>
                        <td>
                            Door Opened Time</td>
                        <td>
                            Operator</td>
                        <td>
                            Chemist</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtDateMHSR" runat="server" Width="80px"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="txtDateMHSR_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDateMHSR">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtBatchNoMHSR" runat="server" Width="80px" Enabled="False"></asp:TextBox>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtParticulars" runat="server" Width="80px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtDoorClosedTime" runat="server" Width="60px"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="txtDoorClosedTime_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99:99" MaskType="Time" TargetControlID="txtDoorClosedTime">
                                                                </cc1:MaskedEditExtender>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtSteamOpenedTime" runat="server" Width="60px"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="txtSteamOpenedTime_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99:99" MaskType="Time" TargetControlID="txtSteamOpenedTime">
                                                                </cc1:MaskedEditExtender>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtVentClosedTime" runat="server" Width="60px"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="txtVentClosedTime_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99:99" MaskType="Time" TargetControlID="txtVentClosedTime">
                                                                </cc1:MaskedEditExtender>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtPressAttainedTime" runat="server" Width="60px"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="txtPressAttainedTime_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99:99" MaskType="Time" TargetControlID="txtPressAttainedTime">
                                                                </cc1:MaskedEditExtender>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="TxtPress" runat="server" Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtTemp" runat="server" Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtMaintainedUpto" runat="server" Width="60px"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="txtMaintainedUpto_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99:99" MaskType="Time" TargetControlID="txtMaintainedUpto">
                                                                </cc1:MaskedEditExtender>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtVentOpenedTime" runat="server" Width="60px"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="txtVentOpenedTime_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99:99" MaskType="Time" TargetControlID="txtVentOpenedTime">
                                                                </cc1:MaskedEditExtender>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtDoorOpenedTime" runat="server" Width="60px"></asp:TextBox>
                                                                <cc1:MaskedEditExtender ID="txtDoorOpenedTime_MaskedEditExtender" 
                                runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99:99" MaskType="Time" TargetControlID="txtDoorOpenedTime">
                                                                </cc1:MaskedEditExtender>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtOperator" runat="server" Width="60px"></asp:TextBox>
                                                            </td>
                                                            <td class="style6">
                                                                <asp:TextBox ID="txtChemist" runat="server" Width="80px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="6" align="center">
                                                    <table border="1" cellspacing="1" class="style5">
                                                        <tr align="center" class="header">
                                                            <td>
                                                                <b>Product Test</b></td>
                                                            <td>
                                                                <b>Sterility Test-Biological Indicator</b></td>
                                                            <td>
                                                                <b>Cycle Result</b></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table class="style5">
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Sterility Test</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtSterilityTest" runat="server" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Lal Test</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtLalTest" runat="server" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Other Test</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtOtherTest" runat="server" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table class="style5">
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Result</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlResult" runat="server" CssClass="dropdown">
                                                                                <asp:ListItem>Accepted</asp:ListItem>
                                                                                <asp:ListItem>Rejected</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Record Ref</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRecordRef" runat="server" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Checked By</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCheckedBySterility" runat="server" AutoPostBack="True" 
                                                                                CssClass="textbox" ontextchanged="txtCheckedBySterility_TextChanged"></asp:TextBox>
                                                                            <cc1:FilteredTextBoxExtender ID="txtCheckedBySterility_FilteredTextBoxExtender" 
                                                                                runat="server" Enabled="True" TargetControlID="txtCheckedBySterility" 
                                                                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table class="style5">
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Result</td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlResultCycle" runat="server" CssClass="dropdown">
                                                                                <asp:ListItem>Accepted</asp:ListItem>
                                                                                <asp:ListItem>Rejected</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Quality Control</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtQQualityControl" runat="server" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="textlbl">
                                                                            Product Release No</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtProductRelease" runat="server" CssClass="textbox"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
            <td align="center" colspan="6">
                <asp:ImageButton ID="btnSave" runat="server" 
                    ImageUrl="~/images/btn_save.png" onclick="btnSave_Click" Visible="False" />
                <asp:ImageButton ID="btnUpdate" runat="server" 
                    ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" 
                    Visible="False" />
                <asp:ImageButton ID="btnClear" runat="server" 
                    ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" 
                    Visible="False" />
            </td>
        </tr>
                                            <tr>
                                                <td colspan="6">
                                                    &nbsp;</td>
                                            </tr>
                                           
     
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </table>
    </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

