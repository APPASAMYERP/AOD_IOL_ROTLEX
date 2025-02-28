<%--<%@ Page Title="ModelAndPowerConfirm" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModelPowerConfirm.aspx.cs" Inherits="ModelPowerConfirm" %>--%>
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModelPowerConfirm.aspx.cs" Inherits="ModelPowerConfirm" Title="ModelAndPowerConfirm" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" id="table_left">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                <strong>Model And Power Confirmation - Sample Inspection</strong></td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                <asp:Label ID="lblGRFNo" runat="server" Text="Lot No" 
                    CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtLotNo" runat="server" style="margin-bottom: 0px" 
                MaxLength="11" AutoPostBack="True" CssClass="textbox" ontextchanged="txtGRFNO_TextChanged"></asp:TextBox>
                        </td>
                         <td>
                <asp:Label ID="lblPower" runat="server" Text="Power" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <%--<asp:TextBox ID="txtPower" runat="server" style="margin-bottom: 0px" 
                AutoPostBack="True" CssClass="textbox" Enabled="False"></asp:TextBox>--%>
                <asp:DropDownList ID="drpPower" runat="server" AutoPostBack="true" 
                                AppendDataBoundItems="true" CssClass="dropdown" 
                                onselectedindexchanged="drpPower_SelectedIndexChanged">
                <asp:ListItem>--Select--</asp:ListItem>
                </asp:DropDownList>
                        </td>                       
                    </tr>
                    <tr>
                    <td>
                <asp:Label ID="lblModel" runat="server" Text="Model" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtModel" runat="server" style="margin-bottom: 0px" 
                AutoPostBack="True" CssClass="textbox" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                <asp:Label ID="lblTumblingLotNo" runat="server" Text="TumblingLotNo" 
                    CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNo1" runat="server" style="margin-bottom: 0px" 
                MaxLength="8" AutoPostBack="True" CssClass="textbox" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                       <%-- <td>
                <asp:Label ID="lblJarNo" runat="server" Text="JarNo" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtJarNo" runat="server" CssClass="textbox" Enabled="true" 
                                ontextchanged="txtJarNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                        </td>--%>
                        <td>
                <asp:Label ID="lblDate" runat="server" Text="Date" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" AutoPostBack="True" 
                    ></asp:TextBox>

                           <%-- <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                TargetControlID="txtDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>--%>

                        </td>
                    </tr>
 <tr>
                                        <td align="center" colspan="6">
                                            <table cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td class='nav'>
                                                        <asp:Label ID="LblSamp" runat="server" Text="Samples" CssClass="textlbl" 
                                                            Width="53px" ></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:Label ID="Lbl_1" runat="server" Text="1" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 54px">
                                                        <asp:Label ID="Label3" runat="server" Text="2" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 52px">
                                                        <asp:Label ID="Lbl_3" runat="server" Text="3" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:Label ID="Lbl_4" runat="server" Text="4" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:Label ID="Lbl_5" runat="server" Text="5" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 53px">
                                                        <asp:Label ID="Lbl_6" runat="server" Text="6" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 53px">
                                                        <asp:Label ID="Lbl_7" runat="server" Text="7" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 45px">
                                                        <asp:Label ID="Lbl_8" runat="server" Text="8" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 45px">
                                                        <asp:Label ID="Lbl_9" runat="server" Text="9" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 53px">
                                                        <asp:Label ID="Lbl_10" runat="server" Text="10" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="text-align:center; width: 54px;">
                                                        <span style="font-size: 9pt; font-family: Arial">&nbsp; A &nbsp; &nbsp; &nbsp; R</span><span 
                                                            style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">&nbsp;</span>&nbsp;
                                                    </td>
                                                    <td class='nav'>
                                                        <asp:Label ID="Lbl_Inspected" runat="server" Text="Inspected By" CssClass="textlbl"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class='nav'>
                                                        <asp:Label ID="Lbl_model" runat="server" Text="Model" CssClass="textlbl" 
                                                            Width="45px"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:CheckBox ID="chk1" runat="server" EnableTheming="True" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="chk1_CheckedChanged" />
                                                    </td>
                                                    <td class='nav' style="width: 54px">
                                                        <asp:CheckBox ID="Chk2" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="Chk2_CheckedChanged" />
                                                        </td>
                                                    <td class='nav' style="width: 52px">
                                                        <asp:CheckBox ID="Chk3" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="Chk3_CheckedChanged" />
                                                        </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:CheckBox ID="Chk4" runat="server" CssClass="textlbl" 
                                                            oncheckedchanged="Chk4_CheckedChanged" />
                                                        </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:CheckBox ID="Chk5" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="Chk5_CheckedChanged" />
                                                        </td>
                                                    <td class='nav' style="width: 53px">
                                                        <asp:CheckBox ID="Chk6" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="Chk6_CheckedChanged" />
                                                        </td>
                                                    <td class='nav' style="width: 53px">
                                                        <asp:CheckBox ID="Chk7" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="Chk7_CheckedChanged" />
                                                        </td>
                                                    <td class='nav' style="width: 45px">
                                                        <asp:CheckBox ID="Chk8" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="Chk8_CheckedChanged" />
                                                        </td>
                                                    <td class='nav' style="width: 45px">
                                                        <asp:CheckBox ID="Chk9" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="Chk9_CheckedChanged" />
                                                        </td>
                                                    <td class='nav' style="width: 53px">
                                                        <asp:CheckBox ID="Chk10" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="Chk10_CheckedChanged" />
                                                        </td>
                                                    <td class='nav'>
                                                        <asp:CheckBox ID="ChkAccept" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="ChkAccept_CheckedChanged" />
                                                        <asp:CheckBox ID="ChkReject" runat="server" AutoPostBack="True" 
                                                            CausesValidation="True" CssClass="textlbl" 
                                                            oncheckedchanged="ChkReject_CheckedChanged" />
                                                        </td>
                                                    <td class='nav'>
                                                        <asp:TextBox ID="TextModInsBy" runat="server" Width="63px" AutoPostBack="True" 
                                                            ontextchanged="TextModInsBy_TextChanged"></asp:TextBox>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td class='nav'>
                                                        <asp:Label ID="Lbl_power" runat="server" Text="Power" CssClass="textlbl" 
                                                            Width="53px" Height="16px"></asp:Label>
                                                    </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:TextBox ID="Textpow1" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 54px">
                                                        <asp:TextBox ID="Textpow2" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 52px">
                                                        <asp:TextBox ID="Textpow3" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:TextBox ID="Textpow4" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 49px">
                                                        <asp:TextBox ID="Textpow5" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 53px">
                                                        <asp:TextBox ID="Textpow6" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 53px"> 
                                                      <asp:TextBox ID="Textpow7" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 45px">
                                                        <asp:TextBox ID="Textpow8" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 45px">
                                                        <asp:TextBox ID="Textpow9" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav' style="width: 53px">
                                                        <asp:TextBox ID="Textpow10" runat="server" Width="49px"></asp:TextBox>
                                                    </td>
                                                    <td class='nav'>
                                                        <asp:CheckBox ID="ChkAccep1" CssClass="textlbl"  runat="server" 
                                                            oncheckedchanged="ChkAccep1_CheckedChanged" />
                                                        <asp:CheckBox ID="ChkRejec1" CssClass="textlbl"  runat="server" 
                                                            oncheckedchanged="ChkRejec1_CheckedChanged" />
                                                    </td>
                                                    <td class='nav' >
                                                        <asp:TextBox ID="TextPowInsBy" runat="server" Width="63px" AutoPostBack="True" 
                                                            ontextchanged="TextPowInsBy_TextChanged"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                    
                    <tr>
                        <td align="center" colspan="4">
                            <table>
                                <tr>
                                    <td>
                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" Visible="False" 
                                            onclick="btnSave_Click" />
                                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                                    </td>
                                    <td>
                <asp:ImageButton ID="btnUpdate" runat="server" 
                    ImageUrl="~/images/btn_update.png" 
                    Visible="False" />
                                    </td>
                                    <td>
                <asp:ImageButton ID="btnClear" runat="server" 
                    ImageUrl="~/images/btn_clear.png" 
                    Visible="False" onclick="btnClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <%--<%@ Page Title="ModelAndPowerConfirm" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModelPowerConfirm.aspx.cs" Inherits="ModelPowerConfirm" %>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
</asp:Content>
