<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MicroscopicInspec.aspx.cs" Inherits="MicroscopicInspec" Title="Microscopic Inspection" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnSave"/>
   <asp:PostBackTrigger ControlID = "btnUpdate" />
   <asp:PostBackTrigger ControlID = "btnClear" />
   </Triggers>
   <ContentTemplate>
    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top: 3px">
                                <table class="con_table" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="LotNo"></asp:Label>
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
                                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="Shift"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlShift1" runat="server" CssClass="dropdown" 
                                                Width="153px" onselectedindexchanged="ddlShift1_SelectedIndexChanged">
                                                <asp:ListItem>Select</asp:ListItem>
                                                <asp:ListItem>I</asp:ListItem>
                                                <asp:ListItem>II</asp:ListItem>
                                                <asp:ListItem>III</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" CssClass="textlbl" Text="Cut Type"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCutType" runat="server" CssClass="textbox" Enabled="False" 
                                                EnableTheming="False" Width="150px" ontextchanged="txtCutType_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="6">
                                            <table cellspacing="0">
                                                <tr>
                                                    <td class="nav">
                                                        <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Sample1"></asp:Label>
                                                    </td>
                                                    <td class="nav">
                                                        <asp:CheckBox ID="ChkbAccepted1" runat="server" AutoPostBack="True" 
                                                            Checked="True" CssClass="textlbl" Font-Bold="False" 
                                                            oncheckedchanged="ChkbAccepted1_CheckedChanged" Text="Accepted" Width="128px" />
                                                    </td>
                                                    <td class="nav">
                                                        <asp:CheckBox ID="chkbRejected1" runat="server" AutoPostBack="True" 
                                                            CssClass="textlbl" Font-Bold="False" 
                                                            oncheckedchanged="chkbRejected1_CheckedChanged" Text="Rejected" Width="128px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="nav">
                                                        <asp:Label ID="Label8" runat="server" CssClass="textlbl" Text="Sample2"></asp:Label>
                                                    </td>
                                                    <td class="nav">
                                                        <asp:CheckBox ID="chkbAccepted2" runat="server" AutoPostBack="True" 
                                                            Checked="True" CssClass="textlbl" Font-Bold="False" 
                                                            oncheckedchanged="chkbAccepted2_CheckedChanged" Text="Accepted" Width="128px" />
                                                    </td>
                                                    <td class="nav">
                                                        <asp:CheckBox ID="chkbRejected2" runat="server" AutoPostBack="True" 
                                                            CssClass="textlbl" Font-Bold="False" 
                                                            oncheckedchanged="chkbRejected2_CheckedChanged" Text="Rejected" Width="128px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="nav">
                                                        <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="Sample3"></asp:Label>
                                                    </td>
                                                    <td class="nav">
                                                        <asp:CheckBox ID="chkbAccepted3" runat="server" AutoPostBack="True" 
                                                            Checked="True" CssClass="textlbl" Font-Bold="False" 
                                                            oncheckedchanged="chkbAccepted3_CheckedChanged" Text="Accepted" Width="128px" />
                                                    </td>
                                                    <td class="nav">
                                                        <asp:CheckBox ID="chkbRejected3" runat="server" AutoPostBack="True" 
                                                            CssClass="textlbl" Font-Bold="False" 
                                                            oncheckedchanged="chkbRejected3_CheckedChanged" Text="Rejected" Width="128px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label10" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRemarks1" runat="server" AutoPostBack="True" 
                                                CssClass="textbox" ontextchanged="txtRemarks1_TextChanged" Width="150px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtRemarks1_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" FilterMode="InvalidChars" 
                                                InvalidChars="1235467890" TargetControlID="txtRemarks1">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" CssClass="textlbl" Text="InspectedBy"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInspectedBy1" runat="server" AutoPostBack="True" 
                                                CssClass="textbox" ontextchanged="txtInspectedBy1_TextChanged" Width="150px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtInspectedBy1_FilteredTextBoxExtender" 
                                                runat="server" Enabled="True" TargetControlID="txtInspectedBy1" 
                                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDate1" runat="server" CssClass="textbox" Enabled="False" 
                                                Width="150px" ontextchanged="txtDate1_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="RejMtsNo"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRejMtsNo" runat="server" CssClass="textbox" Width="150px" 
                                                ontextchanged="txtRejMtsNo_TextChanged"></asp:TextBox>
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
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                                BorderColor="#B1B1B1" onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                                Width="100%">
                                                <FooterStyle CssClass="grd_Header " />
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
                                                    <asp:BoundField DataField="BlockingType" HeaderText="BlockingType">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample1Shift" HeaderText="Sft">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample1Status" HeaderText="S.No1 stat.">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample2Status" HeaderText="S.No2 stat.">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample3Status" HeaderText="S.No3 stat.">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample1Remarks" HeaderText="Rmks">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample1InspectedBy" HeaderText="InspectedBy">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RejMTSNo" HeaderText="Rej.MTSNo" Visible="False">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample1Date" DataFormatString="{0:dd/MM/yyyy}" 
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

