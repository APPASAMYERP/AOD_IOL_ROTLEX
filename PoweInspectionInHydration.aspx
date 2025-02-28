<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PoweInspectionInHydration.aspx.cs" Inherits="PoweInspection_Bef_And_Aft__Hydration"
    Title="Power Inspection In Hydration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
            <asp:PostBackTrigger ControlID="btnClear" />
        </Triggers>
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                        <strong>Power Inspection</strong>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-top: 3px">
                        <table class="con_table" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Lot No."></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" CssClass="textbox"
                                        MaxLength="8" OnTextChanged="txtLotNo_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtLotNo" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="Blocking Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBlockingType" runat="server" CssClass="textbox" Enabled="False"
                                        Width="150px">IInd Cut</asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSampleNo1Date" runat="server" CssClass="textbox" Enabled="False"
                                        Width="150px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSmpNo1" runat="server" CssClass="textlbl" Font-Bold="False" Text="SampleNo1"></asp:Label>
                                </td>
                                <td>
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckb1SampleNo1PwrSts1Gd1" runat="server" AutoPostBack="True" Checked="True"
                                                    CssClass="textlbl" Font-Bold="False" OnCheckedChanged="ckb1SampleNo1PwrSts1Gd1_CheckedChanged"
                                                    Text="Accepted" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkb2SampleNo1PwrSts1Bad1" runat="server" AutoPostBack="True" CssClass="textlbl"
                                                    Font-Bold="False" OnCheckedChanged="chkb2SampleNo1PwrSts1Bad1_CheckedChanged"
                                                    Text="Rejected" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="Before Hydration"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSmpNo1BfHyd" runat="server" AutoPostBack="True" CssClass="textbox"
                                        MaxLength="5" OnTextChanged="txtSmpNo1BfHyd_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSmpNo1BfHyd_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtSmpNo1BfHyd" ValidChars="1234567890.">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="After Hyderation"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSmpNo1AftHyd" runat="server" AutoPostBack="True" CssClass="textbox"
                                        MaxLength="5" OnTextChanged="txtSmpNo1AftHyd_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSmpNo1AftHyd_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtSmpNo1AftHyd" ValidChars="1234567890.">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSmpNo2" runat="server" CssClass="textlbl" Font-Bold="False" Text="SampleNo2"></asp:Label>
                                </td>
                                <td>
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkb3SampleNo2PwrSts2Gd2" runat="server" AutoPostBack="True" Checked="True"
                                                    CssClass="textlbl" Font-Bold="False" OnCheckedChanged="chkb3SampleNo2PwrSts2Gd2_CheckedChanged"
                                                    Text="Accepted" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkb4SampleNo2PwrSts2Bad2" runat="server" AutoPostBack="True" CssClass="textlbl"
                                                    Font-Bold="False" OnCheckedChanged="chkb4SampleNo2PwrSts2Bad2_CheckedChanged"
                                                    Text="Rejected" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" CssClass="textlbl" Text="Before Hydration"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSmpNo2BfHyd" runat="server" AutoPostBack="True" CssClass="textbox"
                                        MaxLength="5" OnTextChanged="txtSmpNo2BfHyd_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSmpNo2BfHyd_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtSmpNo2BfHyd" ValidChars="1234567890.">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="After Hyderation"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSmpNo2AftHyd" runat="server" AutoPostBack="True" CssClass="textbox"
                                        MaxLength="5" OnTextChanged="txtSmpNo2AftHyd_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSmpNo2AftHyd_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtSmpNo2AftHyd" ValidChars="1234567890.">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblSmpNo3" runat="server" CssClass="textlbl" Font-Bold="False" Font-Italic="False"
                                        Text="SampleNo3"></asp:Label>
                                </td>
                                <td>
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="chkb5SampleNo3PwrSts3Gd3" runat="server" AutoPostBack="True" Checked="True"
                                                    CssClass="textlbl" Font-Bold="False" OnCheckedChanged="chkb5SampleNo3PwrSts3Gd3_CheckedChanged"
                                                    Text="Accepted" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkb6SampleNo3PwrSts3Bad3" runat="server" AutoPostBack="True" CssClass="textlbl"
                                                    Font-Bold="False" OnCheckedChanged="chkb6SampleNo3PwrSts3Bad3_CheckedChanged"
                                                    Text="Rejected" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" CssClass="textlbl" Text="Before Hydration"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSmpNo3BfHyd" runat="server" AutoPostBack="True" CssClass="textbox"
                                        MaxLength="5" OnTextChanged="txtSmpNo3BfHyd_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSmpNo3BfHyd_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtSmpNo3BfHyd" ValidChars="1234567890.">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" CssClass="textlbl" Text="After Hyderation"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSmpNo3AftHyd" runat="server" AutoPostBack="True" CssClass="textbox"
                                        MaxLength="5" OnTextChanged="txtSmpNo3AftHyd_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSmpNo3AftHyd_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtSmpNo3AftHyd" ValidChars="1234567890.">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSampleNo1Rmks" runat="server" AutoPostBack="True" CssClass="textbox"
                                        OnTextChanged="txtSampleNo1Rmks_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSampleNo1Rmks_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890"
                                        TargetControlID="txtSampleNo1Rmks">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" CssClass="textlbl" Text="Inspected By"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSampleNo1InspBy" runat="server" AutoPostBack="True" CssClass="textbox"
                                        OnTextChanged="txtSampleNo1InspBy_TextChanged" Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSampleNo1InspBy_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtSampleNo1InspBy" ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" CssClass="textlbl" Text="Shift"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSampleNo1Shift1" runat="server" CssClass="dropdown" Width="150px">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>I</asp:ListItem>
                                        <asp:ListItem>II</asp:ListItem>
                                        <asp:ListItem>III</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" OnClick="btnSave_Click"
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_update.png"
                                                    OnClick="btnUpdate_Click" Visible="False" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/btn_clear.png"
                                                    OnClick="btnClear_Click" Visible="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="center">
                                <div style="width:730px; overflow:scroll;">
                                    <asp:GridView ID="gvPowerInspec" runat="server" AutoGenerateColumns="False" BorderColor="#B1B1B1"
                                        OnSelectedIndexChanged="gvPowerInspec_SelectedIndexChanged" Width="1000px">
                                        <FooterStyle CssClass="footer" />
                                        <RowStyle CssClass="narmal_row" />
                                        <Columns>
                                            <asp:CommandField ButtonType="Image" HeaderText="Select" SelectImageUrl="~/images/select.PNG"
                                                ShowSelectButton="True">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="LotNo" HeaderText="LotNo">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BlockingType" HeaderText="Blocking">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PowerStatus1" HeaderText="SNo1">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BeforeHydSample1" HeaderText="SNo1 Bf.Hy">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AfterHydSample1" HeaderText="SNo1 Af Hy">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PowerStatus1" HeaderText="SNo2">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BeforeHydSample1" HeaderText="SNo2 Bf.Hy">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AfterHydSample2" HeaderText="SNo2 Af Hy">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PowerStatus3" HeaderText="SNo3">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="BeforeHydSample3" HeaderText="SNo3 Bf.Hy">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AfterHydSample3" HeaderText="SNo3 Af Hy">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sample1Remarks" HeaderText="Rmks">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sample1InspectedBy" HeaderText="Insp">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sample1Shift" HeaderText="Shft">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sample1Date" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date">
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                        </Columns>
                                        <PagerStyle CssClass="pager" />
                                        <SelectedRowStyle CssClass="selectedrow" />
                                        <HeaderStyle CssClass="grd_Header" />
                                        <AlternatingRowStyle CssClass="AltRow" />
                                    </asp:GridView>
                                    </div>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
