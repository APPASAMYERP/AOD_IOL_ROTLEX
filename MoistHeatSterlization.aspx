<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MoistHeatSterlization.aspx.cs" Inherits="MoistHeatSterlization" Title="Moist Heat Sterlization" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:PostBackTrigger ControlID = "btnSave" />
    <asp:PostBackTrigger ControlID = "btnUpdate" />
    <asp:PostBackTrigger ControlID = "btnClear" />
     </Triggers>
   <ContentTemplate>
    <table class="con_table">
        <tr>
            
                <td colspan="6" style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                                Moist Heat Sterilisation</td>
                                
        </tr>
        <tr class="textlbl">
            <td>
                MHSR NO:</td>
            <td>
                <asp:TextBox ID="txtMHSRNo" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtMHSRNo_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtMHSRNo_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMHSRNo">
                </cc1:FilteredTextBoxExtender>
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
            <td align="center" class="textlbl" colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <table class="style5" border="1" cellspacing="1">
                    <tr class="textlbl">
                        <td align="center" class="colorvision" colspan="8">
                <b>Load Details</b></td>
                    </tr>
                    <tr class="textlbl">
                        <td>
                            Product:</td>
                                                 <td>
                                                     <asp:TextBox ID="txtProduct" runat="server" CssClass="textbox" Enabled="False">Foldable 
                                                     Lens</asp:TextBox>
                                                 </td>
                                                 <td>
                                                     BatchNo                            </td>
                                                 <td>
                            <asp:TextBox ID="txtBatchNo" runat="server" CssClass="textbox" ontextchanged="txtBatchNo_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            Total Lot Qty</td>
                        <td>
                            <asp:TextBox ID="txtTotalLotQty" runat="server" Enabled="False" 
                                CssClass="textbox">1200</asp:TextBox>
                        </td>
                        <td>
                            Date</td>
                        <td>
                            <asp:TextBox ID="txtDateLoad" runat="server" CssClass="textbox"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDateLoad_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDateLoad">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr class="textlbl">
                        <td>
                            LotNo</td>
                        <td>
                            <asp:TextBox ID="txtLotNo1" runat="server" CssClass="textbox" 
                                AutoPostBack="True" ontextchanged="txtLotNo1_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLotNo1_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLotNo1">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo2" runat="server" CssClass="textbox" 
                                AutoPostBack="True" ontextchanged="txtLotNo2_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLotNo2_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLotNo2">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo3" runat="server" CssClass="textbox" 
                                AutoPostBack="True" ontextchanged="txtLotNo3_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLotNo3_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLotNo3">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo4" runat="server" CssClass="textbox" 
                                AutoPostBack="True" ontextchanged="txtLotNo4_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLotNo4_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLotNo4">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo5" runat="server" CssClass="textbox" 
                                AutoPostBack="True" ontextchanged="txtLotNo5_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLotNo5_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLotNo5">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo6" runat="server" CssClass="textbox" 
                                AutoPostBack="True" ontextchanged="txtLotNo6_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLotNo6_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLotNo6">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDummy" runat="server" Enabled="False" CssClass="textbox">Dummy</asp:TextBox>
                        </td>
                    </tr>
                    <tr class="textlbl">
                        <td>
                            Qty</td>
                        <td>
                            <asp:TextBox ID="txtQty1" runat="server" CssClass="textbox" Enabled="False" 
                               ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtQty1_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtQty1">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQty2" runat="server" CssClass="textbox" Enabled="False" 
                                ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtQty2_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtQty2">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQty3" runat="server" CssClass="textbox" Enabled="False" 
                                ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtQty3_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtQty3">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQty4" runat="server" CssClass="textbox" Enabled="False" 
                              ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtQty4_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtQty4">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQty5" runat="server" CssClass="textbox" Enabled="False" 
                               ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtQty5_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtQty5">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQty6" runat="server" CssClass="textbox" Enabled="False" 
                                ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtQty6_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtQty6">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQtyDummy" runat="server" CssClass="textbox" Enabled="False">1200</asp:TextBox>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <table class="style5">
                    <tr>
                        <td>
                            <table border="1" cellspacing="1" class="style5">
                                <tr class="header">
                                    <td align="center">
                                        <b>Biological Indicator</b></td>
                                    <td align="center">
                                        <b>Cycle Detail</b></td>
                                    <td align="center">
                                        <b>Colour Change - chemical Indicator</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="chklbBiological" runat="server" CellPadding="5" 
                                            CellSpacing="5" RepeatColumns="4" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                    </td>
                                    <td>
                                        <table border="1" cellspacing="1" class="style5">
                                            <tr>
                                                <td class="textlbl">
                                                    Mode</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMode" runat="server">
                                                        <asp:ListItem>Auto</asp:ListItem>
                                                        <asp:ListItem>Mannual</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="textlbl">
                                                    Exposure Time</td>
                                                <td>
                                                    <asp:TextBox ID="txtExposureTime" runat="server" Width="60px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="textlbl">
                                                    Room temp</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlRoomTemp" runat="server">
                                                        <asp:ListItem>29°C</asp:ListItem>
                                                        <asp:ListItem>30°C</asp:ListItem>
                                                        <asp:ListItem>31°C</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="textlbl">
                                                    Start Time</td>
                                                <td class="textlbl">
                                                    Comp. Time</td>
                                                <td class="textlbl">
                                                    Cycle Time</td>
                                            </tr>
                                            <tr>
                                                <td class="textlbl">
                                                    <asp:TextBox ID="txtStartTime" runat="server" Width="60px" AutoPostBack="True" 
                                                        ontextchanged="txtStartTime_TextChanged"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="txtStartTime_MaskedEditExtender" runat="server" 
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                        Mask="99:99" MaskType="Time" TargetControlID="txtStartTime">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:DropDownList ID="ddlDayStart" runat="server" Width="45px" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlDayStart_SelectedIndexChanged" Visible="False">
                                                        <asp:ListItem>AM</asp:ListItem>
                                                        <asp:ListItem>PM</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtStopTime" runat="server" Width="60px" AutoPostBack="True" 
                                                        ontextchanged="txtStopTime_TextChanged" style="height: 22px"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="txtStopTime_MaskedEditExtender" runat="server" 
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                        Mask="99:99" MaskType="Time" TargetControlID="txtStopTime">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:DropDownList ID="ddlDayStop" runat="server" Width="45px" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlDayStop_SelectedIndexChanged" Visible="False">
                                                        <asp:ListItem>AM</asp:ListItem>
                                                        <asp:ListItem>PM</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCycleTime" runat="server" Width="60px" Enabled="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="middle">
                                        <table border="1" cellspacing="1" class="style5">
                                            <tr class="colorvision">
                                                <td>
                                                    <b>Color Change</b></td>
                                                <td>
                                                    <b>Before Sterile</b></td>
                                                <td>
                                                    <b>After sterile</b></td>
                                                <td>
                                                    <b>Result</b></td>
                                                <td>
                                                    <b>Checked By</b></td>
                                            </tr>
                                            <tr class="textlbl">
                                                <td>
                                                    Chem Indicator</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBeforeChemical" runat="server">
                                                        <asp:ListItem>Pink</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlAfterChemical" runat="server">
                                                        <asp:ListItem>Brown</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtResultChemical" runat="server" BorderWidth="1px" 
                                                        Height="15px" Width="50px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCheckedByChemical" runat="server" CssClass="textbox100" 
                                                        ontextchanged="txtCheckedByChemical_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txtCheckedByChemical_FilteredTextBoxExtender" 
                                                        runat="server" Enabled="True" TargetControlID="txtCheckedByChemical" 
                                                        ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                                    </cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr class="textlbl">
                                                <td>
                                                    Bio Indicator</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBeforeBio" runat="server">
                                                        <asp:ListItem>Pink</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlAfterBio" runat="server">
                                                        <asp:ListItem>Brown</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtResultBio" runat="server" BorderWidth="1px" Height="15px" 
                                                        Width="50px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCheckedByBio" runat="server" CssClass="textbox100" 
                                                        ontextchanged="txtCheckedByBio_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txtCheckedByBio_FilteredTextBoxExtender" 
                                                        runat="server" Enabled="True" TargetControlID="txtCheckedByBio" 
                                                        ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                                    </cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                        </table>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </table>
    </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>

