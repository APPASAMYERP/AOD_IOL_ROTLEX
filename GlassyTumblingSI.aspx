<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GlassyTumblingSI.aspx.cs" Inherits="GlassyTumblingSI" Title="Glassy Tumbling" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnSave"/>
   <asp:PostBackTrigger ControlID = "btnUpdate" />
   <asp:PostBackTrigger ControlID = "btnClear" />
   </Triggers>
   <ContentTemplate>
    <table width="100%" id="table_left">
                        <tr>
                            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                                <asp:Label ID="Label1" runat="server" 
                                    Text="Glassy Tumbling Surface Observations"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table class="con_table" width="100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="Glassy No"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                                                CssClass="textbox" MaxLength="11" ontextchanged="txtLotNo_TextChanged" 
                                                Width="150px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="ReMatt LotNo" 
                                                ></asp:Label>
                                        </td>
                                        <td>
                                           <asp:TextBox ID="txtGFF" runat="server" CssClass="textbox" Enabled="False" 
                                                EnableTheming="False" Width="150px" TabIndex="1"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" CssClass="textlbl" Text="Model"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtMoNo" runat="server" CssClass="textbox" Enabled="False" 
                                                EnableTheming="False" Width="150px" TabIndex="2"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td>
                                            <asp:Label ID="lblGtPower" runat="server" CssClass="textlbl" Text="Power"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGTPower" runat="server" CssClass="textbox" Enabled="False" 
                                                EnableTheming="False" Width="150px" TabIndex="3"></asp:TextBox>
                                        </td>
                                        <td>
                                         <asp:Label ID="lblGtJarNo" runat="server" CssClass="textlbl" Text="Jar No"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGTJarNo" runat="server" CssClass="textbox" 
                                               Width="150px" ></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblGtDate" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtGTDate" runat="server" CssClass="textbox"
                                                Width="150px" TabIndex="5" AutoPostBack="True"></asp:TextBox>
                                            <cc1:CalendarExtender ID="txtGTDate_CalendarExtender" runat="server" 
                                                TargetControlID="txtGTDate" Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>
                             
                              <tr>
                                        <td>
                                            <asp:Label ID="lblGtStart" runat="server" CssClass="textlbl" Text="Start Time" Width="100px"></asp:Label>
                                        </td>
                                            <td>
                                                <asp:TextBox ID="txtGTStartTime" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    OnTextChanged="txtGTStartTime_TextChanged" 
                                                    ValidationGroup="^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$" 
                                                    Width="150px"></asp:TextBox>
                                                 <cc1:MaskedEditExtender ID="txtGTStartTime_MaskedEditExtender" runat="server" 
                                                       AcceptAMPM="True" ClearTextOnInvalid="True"                                                          
                                                        Mask="99:99" MaskType="Time" TargetControlID="txtGTStartTime">
                                                    </cc1:MaskedEditExtender>

                                            </td>
                                        <td>
                                            <asp:Label ID="lblGtStop" runat="server" CssClass="textlbl" Text="Stop Time" Width="100px"></asp:Label>
                                        </td>
                                            <td>
                                                <asp:TextBox ID="txtGTStopTime" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    OnTextChanged="txtGTStopTime_TextChanged" Width="150px"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="txtGTStopTime_MaskedEditExtender" runat="server"
                                                    AcceptAMPM="True" ClearTextOnInvalid="True"
                                                    Mask="99:99" MaskType="Time" TargetControlID="txtGTStopTime">
                                                </cc1:MaskedEditExtender>

                                            </td>
                                            <td>
                                            <asp:Label ID="lblGtDuration" runat="server" CssClass="textlbl" Text="Duration" Width="100px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGTDuration" runat="server" CssClass="textbox" Enabled="False" 
                                                    Width="150px" TabIndex="8"></asp:TextBox>
                                            </td>
                              </tr>
                                    
                                    <tr>
                                        <td align="center" colspan="6">
                                            <table cellspacing="0">
                                                <tr>
                                                    <td class="nav">
                                                        <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Sample1" Width="100px"></asp:Label>
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
                                                        <asp:Label ID="Label8" runat="server" CssClass="textlbl" Text="Sample2" Width="100px"></asp:Label>
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
                                                        <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="Sample3" Width="100px"></asp:Label>
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
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" CssClass="textlbl" Text="Inspected By"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInspectedBy1" runat="server" AutoPostBack="True" 
                                                CssClass="textbox" ontextchanged="txtInspectedBy1_TextChanged" Width="150px"></asp:TextBox>
                                        </td>
                                        <%--<td>
                                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="Phobic ID"></asp:Label>
                                        </td>
                                        <td>
                                           <asp:TextBox ID="txtphob" runat="server" CssClass="textbox" Enabled="False" 
                                                EnableTheming="False" Width="150px"></asp:TextBox>
                                        </td>--%>
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
                                                            ImageUrl="~/images/btn_update.png" Visible="False" 
                                                            onclick="btnUpdate_Click" />
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
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
                                                BorderColor="#B1B1B1" Width="100%" 
                                                onselectedindexchanged="GridView1_SelectedIndexChanged">
                                                <FooterStyle CssClass="grd_Header " />
                                                <RowStyle CssClass="narmal_row" />
                                                <Columns>
                                                    <%--<asp:CommandField ButtonType="Image" HeaderText="Select" 
                                                        SelectImageUrl="~/images/select.PNG" ShowSelectButton="True">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:CommandField>--%>
                                                    <asp:BoundField DataField="GRFLotNo" HeaderText="GRF" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TumblingLotNo" HeaderText="TumblingNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ModelNo" HeaderText="Model" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Power" HeaderText="Power" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="JarNo" HeaderText="JarNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SampleDate" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                        HeaderText="Date">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample1Status" HeaderText="Sample1" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample2Status" HeaderText="Sample2" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sample3Status" HeaderText="Sample3" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SampleRemarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SampleInspectedBy" HeaderText="InspectedBy" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="StartTime" HeaderText="StartTime" Visible="False" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EndTime" 
                                                        HeaderText="StopTime" Visible="False" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Duration" HeaderText="Duration" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                </Columns>
                                                <PagerStyle CssClass="pager" />
                                                <SelectedRowStyle CssClass="selectedrow" />
                                                <HeaderStyle CssClass="grd_Header" />
                                                <AlternatingRowStyle CssClass="AltRow" />
                                            </asp:GridView>
                                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                                        </td>
                                    </tr>
                                </table>
                               
                                
                            </td>
                        </tr>
                    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

