<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MillingProcess.aspx.cs" Inherits="MillingProcess" Title="Milling Process" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
            <asp:PostBackTrigger ControlID="btnClear" />
        </Triggers>
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                        MILLING
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table width="100%" class="con_table">
                            <tr>
                                <td class="textlbl" width="117px">
                                    Lot No
                                </td>
                                <td width="30%">
                                    <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" OnTextChanged="txtLotNo_TextChanged"
                                        MaxLength="11" CssClass="textbox"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" TargetControlID="txtLotNo">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl" width="117px">
                                    Process Type
                                </td>
                                <td width="30%">
                                    <asp:TextBox ID="txtProcessType" runat="server" Enabled="False" CssClass="textbox">Milling</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Received Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReceivedQuantity" runat="server" CssClass="textbox"></asp:TextBox>
                                    <%--<cc1:FilteredTextBoxExtender ID="txtReceivedQuantity_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtReceivedQuantity">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl">
                                    Finished Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFinishedQuantity" runat="server" AutoPostBack="True" OnTextChanged="txtFinishedQuantity_TextChanged"
                                        CssClass="textbox" MaxLength="2"></asp:TextBox>
                                 <%--   <cc1:FilteredTextBoxExtender ID="txtFinishedQuantity_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtFinishedQuantity">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Accepted Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAcceptedQuantity" runat="server" AutoPostBack="True" OnTextChanged="txtAcceptedQuantity_TextChanged"
                                        CssClass="textbox" MaxLength="2"></asp:TextBox>
                                  <%--  <cc1:FilteredTextBoxExtender ID="txtAcceptedQuantity_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtAcceptedQuantity">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl">
                                    Balance Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBalanceQuantity" runat="server" Enabled="False" CssClass="textbox">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Rejected Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRejectedQuantity" runat="server" Enabled="False" CssClass="textbox"></asp:TextBox>
                                 <%--   <cc1:FilteredTextBoxExtender ID="txtRejectedQuantity_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtRejectedQuantity">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl">
                                    Milling LathNo
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpMillingLathNo" runat="server" CssClass="dropdown"> 
                                        
                                        <asp:ListItem Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Start Time
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStartTime" runat="server" CssClass="textbox" AutoPostBack="True"
                                        OnTextChanged="txtStartTime_TextChanged"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="txtStartTime_MaskedEditExtender" runat="server" AcceptAMPM="True"
                                         ClearTextOnInvalid="True" Mask="99:99" MaskType="Time" TargetControlID="txtStartTime">
                                    </cc1:MaskedEditExtender>
                                </td>
                                <td class="textlbl">
                                    End Time
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStopTime" runat="server" AutoPostBack="True" CssClass="textbox"
                                        OnTextChanged="txtStopTime_TextChanged1"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="txtStopTime_MaskedEditExtender" runat="server" AcceptAMPM="True"
                                        ClearTextOnInvalid="True" Mask="99:99" MaskType="Time" TargetControlID="txtStopTime">
                                    </cc1:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Duration
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDuration" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>
                                </td>
                                <td class="textlbl">
                                    Remarks
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" AutoPostBack="True"
                                        OnTextChanged="txtRemarks_TextChanged"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890"
                                        TargetControlID="txtRemarks">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Operator Name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOperatorName" runat="server" CssClass="textbox" AutoPostBack="True"
                                        OnTextChanged="txtOperatorName_TextChanged"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="txtOperatorName_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtOperatorName" ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl">
                                    Shift
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpShift" runat="server" CssClass="dropdown">
                                        <asp:ListItem Value="Select"></asp:ListItem>
                                        <asp:ListItem Value="I">I</asp:ListItem>
                                        <asp:ListItem Value="II">II</asp:ListItem>
                                        <asp:ListItem Value="III">III</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" CssClass="textbox" 
                                        OnTextChanged="txtDate_TextChanged"></asp:TextBox>
                                    <%--<cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                        TargetControlID="txtDate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>--%>
                                </td>
                                <td class="textlbl">
                                    &nbsp;
                                </td>
                                <td>
                                   &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="justify" colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" OnClick="btnSave_Click"
                                        Visible="False" />
                                    <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_update.png"
                                        OnClick="btnUpdate_Click" Visible="False" />
                                    <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/btn_clear.png"
                                        OnClick="btnClear_Click" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                                  <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                                    
                                        <asp:GridView ID="gvMilling" runat="server" AutoGenerateColumns="False" CellPadding="1"
                                            OnSelectedIndexChanged="gvMilling_SelectedIndexChanged" BorderColor="#B1B1B1" HorizontalAlign="Center"
                                            EnableModelValidation="True" Width="100%">
                                            <AlternatingRowStyle CssClass="AltRow" />
                                            <Columns>
                                                <asp:CommandField HeaderText="Select" ButtonType="Image"
                                                    SelectImageUrl="~/images/select.PNG" Visible="False">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="ID" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdNo") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle Width="0px" CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="LotNo" HeaderText="LotNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin. Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acp. Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal. Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej. Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MillingLatheNo" HeaderText="LathNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" > 
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="StartTime" HeaderText="S.Time" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EndTime" HeaderText="E.Time" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Duration" HeaderText="Dur" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Remarks" HeaderText="Rmks" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="OperatorName" HeaderText="OperatorName" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Shift" HeaderText="Shift" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                            </Columns>
                                            <FooterStyle CssClass="footer" />
                                            <SelectedRowStyle CssClass="selectedrow" />
                                            <HeaderStyle CssClass="grd_Header" />
                                            <PagerStyle CssClass="pager" />
                                            <RowStyle CssClass="narmal_row" />
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
