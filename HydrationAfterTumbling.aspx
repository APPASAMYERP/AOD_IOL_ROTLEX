﻿<%@ Page Title="Hydration After Tumbling" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HydrationAfterTumbling.aspx.cs" Inherits="HydrationAfterTumbling"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:PostBackTrigger ControlID ="btnSave" />
    <asp:PostBackTrigger ControlID ="btnUpdate" />
     <asp:PostBackTrigger ControlID ="btnClear" />
    </Triggers>
      <ContentTemplate>
    <table>
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                Hyderation After Tumbling</td>
        </tr>
        <tr>
            <td style="padding-top: 3px">
                <table class="con_table">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" 
                                Text="Tumbling Ref. No "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTumblingNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="8" ontextchanged="txtTumblingNo_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtTumblingNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtTumblingNo" 
                                ValidChars="t1234567890T">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="Start Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtStartDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="Start Time"></asp:Label>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtStartTime" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" ontextchanged="txtStartTime_TextChanged" Width="80px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="txtStartTime_MaskedEditExtender" runat="server" 
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="99:99" MaskType="Time" TargetControlID="txtStartTime">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpStartTimeDay" runat="server" CssClass="textbox" 
                                            Height="18px" Width="50px">
                                            <asp:ListItem>AM</asp:ListItem>
                                            <asp:ListItem>PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="textlbl" Text="Start Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartQty" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="Stop Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStopDate" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False" ontextchanged="txtStopDate_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtStopDate_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtStopDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="Stop time "></asp:Label>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtStopTime" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" Enabled="False" ontextchanged="txtStopTime_TextChanged" 
                                            Width="80px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="txtStopTime_MaskedEditExtender" runat="server" 
                                            ClearTextOnInvalid="True" CultureAMPMPlaceholder="" 
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="99:99" MaskType="Time" TargetControlID="txtStopTime">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="drpStopTimeDay" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" Enabled="False" Height="18px" 
                                            onselectedindexchanged="drpStopTimeDay_SelectedIndexChanged" Width="50px">
                                            <asp:ListItem>AM</asp:ListItem>
                                            <asp:ListItem>PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Accp Qtyty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAccpQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False" ontextchanged="txtAccpQty_TextChanged" 
                                Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="textlbl" 
                                Text="Rejected&nbsp; Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejectedQty" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="Duration"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDuration" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" CssClass="textlbl" 
                                Text="Rejection Reason "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejectionReason" runat="server" CssClass="textbox" 
                                Enabled="False" ontextchanged="txtRejectionReason_TextChanged" Width="150px"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtRejectionReason_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterMode="InvalidChars" 
                                InvalidChars="1234567890" TargetControlID="txtRejectionReason">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="textlbl" 
                                Text="Rejected MTS No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejectedMTS" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" CssClass="textlbl" Text="Shift"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpShift" runat="server" CssClass="textbox" Height="18px" 
                                Width="153px">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>I</asp:ListItem>
                                <asp:ListItem>II</asp:ListItem>
                                <asp:ListItem>III</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" CssClass="textlbl" Text="Hyderated by"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtHydratedBy" runat="server" CssClass="textbox" 
                                Enabled="False" ontextchanged="txtHydratedBy_TextChanged" Width="150px"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtHydratedBy_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtHydratedBy" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                            onclick="btnSave_Click" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnUpdate" runat="server" 
                                            ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:ImageButton ID="btnClear" runat="server" 
                                            ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" 
                                            Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

