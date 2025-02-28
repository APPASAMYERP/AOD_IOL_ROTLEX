<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MicroscopeHapticThick.aspx.cs" Inherits="MicroscopeHapticThick" Title="Microscope Haptic Thick" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnSave"/>
   <asp:PostBackTrigger ControlID = "btnUpdate" />
   <asp:PostBackTrigger ControlID = "btnClear" />
   </Triggers>
   <ContentTemplate>
    <table width="100%" id="table_left" >
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                <strong>MI For Haptic &amp; Thickness</strong></td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%" style="margin-top: -1px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Lot No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="8" ontextchanged="txtLotNo_TextChanged" 
                                Width="150px"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" TargetControlID="txtLotNo">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="Blocking Type"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCutType" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" 
                                Width="150px" AutoPostBack="True"></asp:TextBox>
                           <%-- <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                TargetControlID="txtDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <table cellpadding="1" cellspacing="0">
                                <tr>
                                    <td class="nav" style="font-weight: bold">
                                        <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Sample No"></asp:Label>
                                    </td>
                                    <td class="nav" colspan="2" style="font-weight: bold">
                                      <asp:Label ID="Label8" runat="server" CssClass="textlbl" Text="MI Status"></asp:Label>
                                    </td>
                                    <td class="nav" colspan="2" style="font-weight: bold">
                                        <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="Resolution"></asp:Label>
                                    </td>
                                    <td class="nav" style="font-weight: bold">
                                        <asp:Label ID="Label10" runat="server" CssClass="textlbl" Text="Outer Diameter"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nav">
                                        <asp:Label ID="lblSampleNo1" runat="server" CssClass="textlbl" 
                                            Font-Bold="False" Text="SampleNo1"></asp:Label>
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb1SampleNo1MiStatusAccp1" runat="server" 
                                            AutoPostBack="True" Checked="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb1SampleNo1MiStatusAccp1_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb2SampleNo1MiStatusRej1" runat="server" 
                                            AutoPostBack="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb2SampleNo1MiStatusRej1_CheckedChanged" Text="Rejected" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb7SampleNo1PfStsAccp1" runat="server" AutoPostBack="True" 
                                            Checked="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb7SampleNo1PfStsAccp1_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb8SampleNo1PfStsRej1" runat="server" AutoPostBack="True" 
                                            CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb8SampleNo1PfStsRej1_CheckedChanged" Text="Rejected" />
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtSample1HaptiThick1" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="5" 
                                            ontextchanged="txtSample1HaptiThick1_TextChanged"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtSample1HaptiThick1_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtSample1HaptiThick1" 
                                            ValidChars="1234567890.">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nav">
                                        <asp:Label ID="lblSampleNo2" runat="server" CssClass="textlbl" 
                                            Font-Bold="False" Text="SampleNo2"></asp:Label>
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb3SampleNo2MiStatusAccp2" runat="server" 
                                            AutoPostBack="True" Checked="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb3SampleNo2MiStatusAccp2_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb4SampleNo2MiStatusRej2" runat="server" 
                                            AutoPostBack="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb4SampleNo2MiStatusRej2_CheckedChanged" 
                                            Text="Rejected" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb9SampleNo2PfStsAccp2" runat="server" AutoPostBack="True" 
                                            Checked="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb9SampleNo2PfStsAccp2_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb10SampleNo2PfStsRej2" runat="server" AutoPostBack="True" 
                                            CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb10SampleNo2PfStsRej2_CheckedChanged" Text="Rejected" />
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtSample2HaptiThick2" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="5" 
                                            ontextchanged="txtSample2HaptiThick2_TextChanged"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtSample2HaptiThick2_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtSample2HaptiThick2" 
                                            ValidChars="1234567890.">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nav">
                                        <asp:Label ID="lblSampleNo3" runat="server" CssClass="textlbl" 
                                            Font-Bold="False" Text="SampleNo3"></asp:Label>
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb5SampleNo3MiStatusAccp3" runat="server" 
                                            AutoPostBack="True" Checked="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb5SampleNo3MiStatusAccp3_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb6SampleNo3MiStatusRej3" runat="server" 
                                            AutoPostBack="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb6SampleNo3MiStatusRej3_CheckedChanged" Text="Rejected" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb11SampleNo3PfStsAccp3" runat="server" AutoPostBack="True" 
                                            Checked="True" CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb11SampleNo3PfStsAccp3_CheckedChanged" Text="Accepted" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkb12SampleNo3PfStsRej3" runat="server" AutoPostBack="True" 
                                            CssClass="textlbl" Font-Bold="False" 
                                            oncheckedchanged="chkb12SampleNo3PfStsRej3_CheckedChanged" Text="Rejected" />
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtSample3HaptiThick3" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="5" 
                                            ontextchanged="txtSample3HaptiThick3_TextChanged"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtSample3HaptiThick3_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtSample3HaptiThick3" 
                                            ValidChars="1234567890.">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSample1Remarks" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtSample1Remarks_TextChanged" Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtSample1Remarks_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterMode="InvalidChars" FilterType="Numbers" 
                                InvalidChars="1234567890" TargetControlID="txtSample1Remarks">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="InspectedBy"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSample1InspBy" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtSample1InspBy_TextChanged" Width="150px"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtSample1InspBy_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtSample1InspBy" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="textlbl" Text="Shift"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSample1Shif" runat="server" CssClass="dropdown" 
                                Width="150px">
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
                            
                            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </cc1:ToolkitScriptManager>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            BorderColor="#B1B1B1" onselectedindexchanged="GridView1_SelectedIndexChanged" HorizontalAlign="Center">
                                            <FooterStyle CssClass="footer" />
                                            <RowStyle CssClass="narmal_row" />
                                            <Columns>
                                                <%--<asp:CommandField ButtonType="Image" HeaderText="Select" 
                                                    SelectImageUrl="~/images/select.PNG" ShowSelectButton="True">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:CommandField>--%>
                                                <asp:BoundField DataField="LotNo" HeaderText="LotNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BlockingType" HeaderText="Blocking" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample1MiStatus" HeaderText="SNo1 MI" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample1ProfileStatus" HeaderText="SNo1Prof" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample1Haptic" HeaderText="SNo1Hap" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample2MiStatus" HeaderText="SNo2 MI" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample2ProfileStatus" HeaderText="SNo2prof" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample2Haptic" HeaderText="SNo2Hap" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample3MiStatus" HeaderText="SNo3 MI" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample3ProfileStatus" HeaderText="SNo3prof" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample3Haptic" HeaderText="SNo3Hap" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <%--<asp:BoundField DataField="Sample1Remarks" HeaderText="Rmks">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="Sample1InspectedBy" HeaderText="Insp" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample1Shift" HeaderText="Sft" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Sample1Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                    HeaderText="Date">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle CssClass="pager" />
                                            <SelectedRowStyle CssClass="selectedrow" />
                                            <HeaderStyle CssClass="grd_Header" />
                                            <AlternatingRowStyle CssClass="AltRow" />
                                        </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

