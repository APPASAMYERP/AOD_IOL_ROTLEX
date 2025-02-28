<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LensMeasurementInspection.aspx.cs" Inherits="LensMeasurementInspection" Title="Lens Measurement Inspection" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnSave"/>
   <asp:PostBackTrigger ControlID = "btnUpdate" />
   <asp:PostBackTrigger ControlID = "btnClear" />
   </Triggers>
   <ContentTemplate>

    <table width="100%">
        
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                                Lens Measurement Inspection</td>
        </tr>
        <tr>
            <td style="padding-top: 3px">
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Lot No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="8" ontextchanged="txtLotNo_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" TargetControlID="txtLotNo">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" 
                                Text="Blocking&nbsp;Type"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBlockingType" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSampleNo1" runat="server" CssClass="textlbl" 
                                Text="Sample No1"></asp:Label>
                        </td>
                        <td>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkAcccepted1" runat="server" AutoPostBack="True" 
                                            Checked="True" CssClass="textlbl" 
                                            oncheckedchanged="ChkAcccepted1_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkRejected1" runat="server" AutoPostBack="True" 
                                            CssClass="textlbl" oncheckedchanged="chkRejected1_CheckedChanged" 
                                            Text="Rejected" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="Diameter"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDiameter1" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="5" ontextchanged="txtDiameter1_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtDiameter1_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtDiameter1" 
                                ValidChars="1234567890.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="textlbl" Text="Thickness"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtThkness1" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="5" ontextchanged="txtThkness1_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtThkness1_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtThkness1" 
                                ValidChars="1234567890.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSampleNo4" runat="server" CssClass="textlbl" 
                                Text="Sample&nbsp;No2"></asp:Label>
                        </td>
                        <td>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkAccepted2" runat="server" AutoPostBack="True" 
                                            Checked="True" CssClass="textlbl" 
                                            oncheckedchanged="ChkAccepted2_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkRejected2" runat="server" AutoPostBack="True" 
                                            CssClass="textlbl" oncheckedchanged="chkRejected2_CheckedChanged" 
                                            Text="Rejected" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Diameter"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDiameter2" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="5" ontextchanged="txtDiameter2_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtDiameter2_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtDiameter2" 
                                ValidChars="1234567890.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label10" runat="server" CssClass="textlbl" Text="Thickness"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtThkness2" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="5" ontextchanged="txtThkness2_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtThkness2_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtThkness2" 
                                ValidChars="1234567890.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSampleNo5" runat="server" CssClass="textlbl" 
                                Text="Sample&nbsp;No3"></asp:Label>
                        </td>
                        <td>
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChkAccepted3" runat="server" AutoPostBack="True" 
                                            Checked="True" CssClass="textlbl" 
                                            oncheckedchanged="ChkAccepted3_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkRejected3" runat="server" AutoPostBack="True" 
                                            CssClass="textlbl" oncheckedchanged="chkRejected3_CheckedChanged" 
                                            Text="Rejected" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="Diameter"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDiameter3" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="5" ontextchanged="txtDiameter3_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtDiameter3_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtDiameter3" 
                                ValidChars="1234567890.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" CssClass="textlbl" Text="Thickness"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtThkness3" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="5" ontextchanged="txtThkness3_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtThkness3_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtThkness3" 
                                ValidChars="1234567890.">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtRemarks_TextChanged" Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterMode="InvalidChars" FilterType="Numbers" 
                                InvalidChars="1234567890." TargetControlID="txtRemarks">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label13" runat="server" CssClass="textlbl" Text="Inspected By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInspectedby" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtInspectedby_TextChanged" Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtInspectedby_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtInspectedby" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label14" runat="server" CssClass="textlbl" Text="Shift"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpShift" runat="server" CssClass="dropdown" 
                                Width="153px">
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
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                            onclick="btnSave_Click" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnUpdate" runat="server" 
                                            ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnClear" runat="server" 
                                            ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" 
                                            Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:GridView ID="gvLensMeas" runat="server" AutoGenerateColumns="False" 
                                BorderColor="#B1B1B1" EnableModelValidation="True" 
                                onselectedindexchanged="GridView1_SelectedIndexChanged" Width="100%">
                                <FooterStyle CssClass="footer" />
                                <RowStyle CssClass="narmal_row" />
                                <Columns>
                                    <asp:CommandField ButtonType="Image" HeaderText="Select" 
                                        SelectImageUrl="~/images/select.PNG" ShowSelectButton="True">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="LotNo" HeaderText="LotNo">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo1Date" DataFormatString="{0:dd/MM/yyyy}" 
                                        HeaderText="Date">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo1Status" HeaderText="S.No1">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo1LensDiameter" HeaderText="Dia">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo1LensThickness" HeaderText="Thick">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo2Status" HeaderText="S.No2">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo2LensDiameter2" HeaderText="Dia.">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo2LensThickness2" HeaderText="Thick.">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo3Status" HeaderText="S.No3">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo3LensDiameter3" HeaderText="Dia">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SampleNo3LensThickness3" HeaderText="Thick">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Inspectedby1" HeaderText="Inspec.">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StatusShift" HeaderText="Sft">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle CssClass="pager" />
                                <SelectedRowStyle CssClass="selectedrow" />
                                <HeaderStyle CssClass="grd_Header" />
                                <AlternatingRowStyle CssClass="AltRow" />
                            </asp:GridView>
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

