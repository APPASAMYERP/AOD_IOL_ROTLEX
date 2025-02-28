<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LathCut.aspx.cs" Inherits="LathCut" Title="Lathe Cut"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td >
                                    <table class="con_table" width="100%">
                                          <tr>
                                            <td class="textlbl" width="117px">
                                                
                                                <asp:Label ID="Label3" runat="server" Text="Lot No"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    MaxLength="11" OnTextChanged="txtLotNo_TextChanged"></asp:TextBox>
                                               <%-- <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterType="Numbers" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" TargetControlID="txtLotNo">
                                                </cc1:FilteredTextBoxExtender>--%>
                                            </td>
                                            <td class="textlbl" width="117px">
                                            <asp:Label ID="Label4" runat="server" Text=" Lathe Type"></asp:Label>
                                               
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBlockingType" runat="server" CssClass="textbox" 
                                                    Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlbl1">
                                                <asp:Label ID="Label5" runat="server" Text=" Received Quantity"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtReceivedQuantity" runat="server" CssClass="textbox" 
                                                    Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="textlbl">
                                            <asp:Label ID="Label6" runat="server" Text="Finished Quantity"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFinishedQuantity" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    MaxLength="2" OnTextChanged="txtFinishedQuantity_TextChanged"></asp:TextBox>
                                                <%--<cc1:FilteredTextBoxExtender ID="txtFinishedQuantity_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtFinishedQuantity">
                                                </cc1:FilteredTextBoxExtender>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlbl">
                                            <asp:Label ID="Label7" runat="server" Text="Balance Quantity"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBalanceQuantity" runat="server" CssClass="textbox" 
                                                    Enabled="False">0</asp:TextBox>
                                            </td>
                                            <td class="textlbl1">
                                            <asp:Label ID="Label8" runat="server" Text="Accepted Quantity"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAcceptedQuantity" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    MaxLength="2" OnTextChanged="txtAcceptedQuantity_TextChanged" ></asp:TextBox>
                                               <%-- <cc1:FilteredTextBoxExtender ID="txtAcceptedQuantity_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtAcceptedQuantity">
                                                </cc1:FilteredTextBoxExtender>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlbl">
                                            <asp:Label ID="Label9" runat="server" Text="Rejected Quantity"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRejectedQuantity" runat="server" CssClass="textbox" 
                                                    Enabled="False"></asp:TextBox>
                                            </td>
                                            <td class="textlbl">
                                            <asp:Label ID="Label10" runat="server" Text="Lath No"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlLathNo" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                                    CssClass="dropdown" 
                                                    OnSelectedIndexChanged="drpLathNO_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlbl">
                                            <asp:Label ID="Label11" runat="server" Text=" Tool Id "></asp:Label>                                                
                                            </td>
                                            <td id="Td1" runat="server">
                                                <asp:DropDownList ID="drpToolId" runat="server" AutoPostBack="True" 
                                                    CssClass="dropdown">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="textlbl">
                                            <asp:Label ID="Label12" runat="server" Text=" Start Time"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStartTime" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    OnTextChanged="txtStartTime_TextChanged" 
                                                    ValidationGroup="^([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$"></asp:TextBox>
                                                 <cc1:MaskedEditExtender ID="txtStartTime_MaskedEditExtender" runat="server" 
                                                       AcceptAMPM="True" ClearTextOnInvalid="True"                                                          
                                                        Mask="99:99" MaskType="Time" TargetControlID="txtStartTime">
                                                    </cc1:MaskedEditExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlbl">
                                            <asp:Label ID="Label13" runat="server" Text=" End Time"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStopTime" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    OnTextChanged="txtStopTime_TextChanged" ></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="txtStopTime_MaskedEditExtender" runat="server"
                                                    AcceptAMPM="True" ClearTextOnInvalid="True"
                                                    Mask="99:99" MaskType="Time" TargetControlID="txtStopTime">
                                                </cc1:MaskedEditExtender>
                                            </td>
                                            <td class="textlbl">
                                            <asp:Label ID="Label14" runat="server" Text=" Duration"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDuration" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlbl">
                                            <asp:Label ID="Label15" runat="server" Text="Operator Name"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOperatorName" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    OnTextChanged="txtOperatorName_TextChanged" ></asp:TextBox>
                                                <%--<cc1:FilteredTextBoxExtender ID="txtOperatorName_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" TargetControlID="txtOperatorName" ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                                </cc1:FilteredTextBoxExtender>--%>
                                            </td>
                                            <td class="textlbl">
                                            <asp:Label ID="Label16" runat="server" Text="Remarks"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" CssClass="textbox"
                                                    OnTextChanged="txtRemarks_TextChanged" ></asp:TextBox>
                                               <%-- <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterMode="InvalidChars" InvalidChars="12345687890" TargetControlID="txtRemarks">
                                                </cc1:FilteredTextBoxExtender>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlbl">
                                            <asp:Label ID="Label17" runat="server" Text="Date"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox>
                                               <%-- <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                                    TargetControlID="txtDate" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>--%>
                                            </td>
                                            <td class="textlbl">
                                            <asp:Label ID="Label18" runat="server" Text="Shift"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="drpShift" runat="server" CssClass="dropdown">
                                                    <asp:ListItem>Select</asp:ListItem>
                                                    <asp:ListItem>I</asp:ListItem>
                                                    <asp:ListItem>II</asp:ListItem>
                                                    <asp:ListItem>III</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="textlbl">
                                               <asp:Label ID="lblradius" runat="server" Text="Radius"></asp:Label> 
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtradius" runat="server" CssClass="textbox" AutoPostBack="true">
                                                </asp:TextBox>
                                            </td>
                                             <td class="textlbl">
                                                 &nbsp;
                                             </td>
                                             <td>
                                                 &nbsp;
                                             </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" OnClick="btnSave_Click"
                                                    Visible="False" />
                                                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_update.png"
                                                    OnClick="btnUpdate_Click1" Visible="False" />
                                                <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/btn_clear.png"
                                                    OnClick="btnClear_Click" Visible="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <div class="scroll">
                                                    <asp:GridView ID="gvLathCut" runat="server" AutoGenerateColumns="False" BorderColor="#B1B1B1"
                                                        CellPadding="1" EnableModelValidation="True" OnSelectedIndexChanged="gvLathCut_SelectedIndexChanged" HorizontalAlign="Center"
                                                        Width="100%">
                                                        <AlternatingRowStyle CssClass="AltRow" />
                                                        <Columns>
                                                            <asp:CommandField ButtonType="Image" HeaderText="Select" 
                                                                SelectImageUrl="~/images/select.PNG" Visible="False">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:CommandField>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdNo") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="LotNo" HeaderText="LotNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="LatheType" HeaderText="LatheType" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FinishedQuantity" HeaderText="Finsh.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acp.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="LatheNo" HeaderText="LatheNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ToolId" HeaderText="ToolId" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="StartTime" HeaderText="S.Time" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" ItemStyle-Width="25px">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="EndTime" HeaderText="E.Time" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Duration" HeaderText="Dur" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="OperatorName" HeaderText="OperName" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Remarks" HeaderText="Rmks" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="shift" HeaderText="Shift" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                                <HeaderStyle CssClass="headeritem" />
                                                                <ItemStyle CssClass="itemstyle" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <FooterStyle CssClass="footer" />
                                                        <PagerStyle CssClass="pager" />
                                                        <SelectedRowStyle CssClass="selectedrow" />
                                                        <HeaderStyle CssClass="grd_Header" />
                                                        <RowStyle CssClass="narmal_row" />
                                                    </asp:GridView>
                                                    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                                                </div>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
            <asp:PostBackTrigger ControlID="btnClear" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

