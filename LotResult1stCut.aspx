<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LotResult1stCut.aspx.cs" Inherits="LotResult1stCut" Title="Lot Result" %>

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
                                LOT RESULT</td>
                        </tr>
                        <tr>
                            <td align="left">
                                <table class="con_table" width="100%">
    <tr>
        <td class="textlbl">
                Lot No</td>
        <td >
            <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                CssClass="textbox" MaxLength="11" ontextchanged="txtLotNo_TextChanged"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                                             runat="server" Enabled="True" FilterType="Numbers" 
                                             TargetControlID="txtLotNo" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"></cc1:FilteredTextBoxExtender>--%>
        </td>
        <td class="textlbl">
                Blocking Type</td>
        <td>
            <asp:TextBox ID="txtInspectedBy0" runat="server" CssClass="textbox" 
                Enabled="False">Ist Cut</asp:TextBox>
        </td>
    </tr>
        <tr>
            <td class="textlbl">
                Received Quantity</td>
            <td >
                <asp:TextBox ID="txtReceivedQuantity" runat="server" CssClass="textbox" 
                    Enabled="False"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="txtReceivedQuantity_FilteredTextBoxExtender" 
                    runat="server" BehaviorID="txtReceivedQuantity_FilteredTextBoxExtender" 
                    Enabled="True" FilterType="Numbers" TargetControlID="txtReceivedQuantity">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
            <td class="textlbl">
                Finished Quantity</td>
            <td>
                <asp:TextBox ID="txtFinishedQuantity" runat="server" AutoPostBack="True" 
                    CssClass="textbox" ontextchanged="txtFinishedQuantity_TextChanged1" 
                    MaxLength="2"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="txtFinishedQuantity_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtFinishedQuantity">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
        </tr>
    <tr>
        <td class="textlbl">
                Accepted Quantity</td>
        <td >
            <asp:TextBox ID="txtAcceptedQuantity" runat="server" AutoPostBack="True" 
                ontextchanged="txtAcceptedQuantity_TextChanged" CssClass="textbox" 
                MaxLength="2"></asp:TextBox>
            <%--<cc1:FilteredTextBoxExtender ID="txtAcceptedQuantity_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtAcceptedQuantity">
            </cc1:FilteredTextBoxExtender>--%>
        </td>
        <td class="textlbl">
                Balance Quantity</td>
        <td>
            <asp:TextBox ID="txtBalanceQuantity" runat="server" Enabled="False" 
                CssClass="textbox">0</asp:TextBox>
           <%-- <cc1:FilteredTextBoxExtender ID="txtBalanceQuantity_FilteredTextBoxExtender" 
                runat="server" Enabled="True" FilterType="Numbers" 
                TargetControlID="txtBalanceQuantity">
            </cc1:FilteredTextBoxExtender>--%>
        </td>
    </tr>
    <tr>
        <td class="textlbl">
                Rejected Quantity</td>
        <td >
            <asp:TextBox ID="txtRejectedQuantity" runat="server" ReadOnly="True" 
                Enabled="False" CssClass="textbox"></asp:TextBox>
            <%--<cc1:FilteredTextBoxExtender ID="txtRejectedQuantity_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtRejectedQuantity">
            </cc1:FilteredTextBoxExtender>--%>
        </td>
        <td class="textlbl">
                Remarks</td>
        <td>
            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" 
                AutoPostBack="True" ontextchanged="txtRemarks_TextChanged"></asp:TextBox>
            <%--<cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                runat="server" Enabled="True" FilterMode="InvalidChars" FilterType="Numbers" 
                InvalidChars="123456789" TargetControlID="txtRemarks">
            </cc1:FilteredTextBoxExtender>--%>
        </td>
    </tr>
    <tr>
        <td class="textlbl">
                Inspected By</td>
        <td >
            <asp:TextBox ID="txtInspectedBy" runat="server" CssClass="textbox" 
                AutoPostBack="True" ontextchanged="txtInspectedBy_TextChanged"></asp:TextBox>
            <%--<cc1:FilteredTextBoxExtender ID="txtInspectedBy_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtInspectedBy" 
                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
            </cc1:FilteredTextBoxExtender>--%>
        </td>
        <td class="textlbl">
                Shift</td>
        <td>
            <asp:DropDownList ID="drpShift" runat="server" CssClass="dropdown">
                <asp:ListItem Value="Select"></asp:ListItem>
                <asp:ListItem Value=" I"></asp:ListItem>
                <asp:ListItem Value=" II"></asp:ListItem>
                <asp:ListItem Value=" III"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="textlbl">
                Date</td>
        <td>
            <asp:TextBox ID="txtDate" runat="server" 
                ontextchanged="txtDate_TextChanged" CssClass="textbox" AutoPostBack="True"></asp:TextBox>
           <%-- <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                TargetControlID="txtDate" Format="dd/MM/yyyy">
            </cc1:CalendarExtender>--%>
        </td>
        <td >
        </td>
        <td >
            </td>
    </tr>
        <tr>
            <td colspan="4" align="center">
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
                            <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </cc1:ToolkitScriptManager>
                        </td>
                    </tr>
                </table>
                </td>
        </tr>
    <tr>
        <td  align="center" colspan="4">
                <asp:GridView ID="gvLotResult" runat="server" 
                    AutoGenerateColumns="False" CellPadding="1" onselectedindexchanged="gvDeblocking_SelectedIndexChanged" 
                    BorderColor="#B1B1B1" EnableModelValidation="True" Width="100%">
                    <AlternatingRowStyle CssClass="AltRow" />
                    <Columns>
                        <asp:CommandField HeaderText="Select" 
                            ButtonType="Image" SelectImageUrl="~/images/select.PNG" Visible="False" >
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
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec. Qty" >
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle Width="81px" CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin. Qty" >
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle Width="81px" CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acp. Qty" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal. Qty" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej. Qty" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Remarks" HeaderText="Rmks" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Inspectedby" HeaderText="Inspec.by" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Shift" HeaderText="Shift" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                    </Columns>
                    <FooterStyle CssClass="footer" />
                    <HeaderStyle CssClass="grd_Header" />
                    <PagerStyle CssClass="pager" />
                    <RowStyle CssClass="narmal_row" />
                    <SelectedRowStyle Font-Italic="False" CssClass="selectedrow" />
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

