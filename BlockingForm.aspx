<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BlockingForm.aspx.cs" Inherits="BlockingForm" Title="Blocking" %>

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
                        <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="background-color: #00207D; font-family: Arial; font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
                                <asp:Label ID="Label2" runat="server" Text="Label" ></asp:Label></td>
                        </tr>
                            <table class="con_table" width="100%">
                                <tr>
                                    <td class="textlbl" width="117px">
                                        Lot No</td>
                                    <td>
                                        <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="11" ontextchanged="txtLotNo_TextChanged"></asp:TextBox>
                                        <%--<cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLotNo" 
                                            ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="textlbl">
                                        Blocking Type</td>
                                    <td class="style19">
                                        <asp:TextBox ID="txtBlockingType" runat="server" CssClass="textbox" 
                                            Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlbl">
                                        Received Quantity</td>
                                    <td class="style8">
                                        <asp:TextBox ID="txtReceivedQuantity" runat="server" CssClass="textbox" 
                                            Enabled="False"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtReceivedQuantity_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtReceivedQuantity">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="textlbl">
                                        Finished Quantity</td>
                                    <td>
                                        <asp:TextBox ID="txtFinishedQuantity" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="2" 
                                            ontextchanged="txtFinishedQuantity_TextChanged"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtFinishedQuantity_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtFinishedQuantity">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlbl">
                                        Balance Quantity</td>
                                    <td class="style8">
                                        <asp:TextBox ID="txtBalanceQuantity" runat="server" CssClass="textbox" 
                                            Enabled="False">0</asp:TextBox>
                                    </td>
                                    <td class="textlbl">
                                        Accepted Quantity</td>
                                    <td>
                                        <asp:TextBox ID="txtAcceptedQuantity" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="2" ontextchanged="txtAcceptedQuantity_TextChanged"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtAcceptedQuantity_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtAcceptedQuantity">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlbl">
                                        Rejected Quantity</td>
                                    <td class="style8">
                                        <asp:TextBox ID="txtRejectedQuantity" runat="server" CssClass="textbox" 
                                            Enabled="False"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtRejectedQuantity_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtRejectedQuantity">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="textlbl">
                                        Cooling Temperature(ºc)</td>
                                    <td>
                                        <asp:DropDownList ID="drpWaxTemperature" runat="server" CssClass="dropdown">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlbl">
                                        Remarks</td>
                                    <td class="style8">
                                        <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" ontextchanged="txtRemarks_TextChanged"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterMode="InvalidChars" 
                                            InvalidChars="1234567890" TargetControlID="txtRemarks">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="textlbl">
                                        Blocked By</td>
                                    <td>
                                        <asp:TextBox ID="txtBlockedBy" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" ontextchanged="txtBlockedBy_TextChanged"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtBlockedBy_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtBlockedBy" 
                                            ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlbl">
                                        Shift</td>
                                    <td class="style8">
                                        <asp:DropDownList ID="drpShift" runat="server" CssClass="dropdown">
                                            <asp:ListItem Value="Select"></asp:ListItem>
                                            <asp:ListItem Value=" I"></asp:ListItem>
                                            <asp:ListItem Value=" II"></asp:ListItem>
                                            <asp:ListItem Value=" III"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="textlbl">
                                        Date</td>
                                    <td>
                                        <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" CssClass="textbox"></asp:TextBox>
                                       <%-- <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtDate" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                        --%>
                                        <%--<cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtDate" 
                                            ValidChars="1234567890./-">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="textlbl">
                                        Radius </td>
                                    <td>
                                        <asp:TextBox ID="txtradius" runat="server" AutoPostBack="true" CssClass="textbox"></asp:TextBox>
                                    </td>
                                
                                    <td class="textlbl">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;                                                                                            
                                       
                                    </td>     
                                </tr>
                                <tr>
                                    <td align="center" class="style20" colspan="4" width="815px">
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                            onclick="btnSave_Click" Visible="False" />
                                        <asp:ImageButton ID="btnUpdate" runat="server" 
                                            ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click1" Visible="False" />
                                        <asp:ImageButton ID="btnClear" runat="server" 
                                            ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" 
                                            Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                                        <asp:GridView ID="gvBlocking" runat="server" AutoGenerateColumns="False" 
                                            BorderColor="#B1B1B1" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" 
                                            onselectedindexchanged="gvBlocking_SelectedIndexChanged" Width="100%">
                                            <RowStyle CssClass="narmal_row" />
                                            <Columns>
                                                <%--<asp:CommandField HeaderText="Select" 
                            ButtonType="Image" SelectImageUrl="~/images/select.PNG" SelectText="" 
                            ShowSelectButton="True" >
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
                        </asp:TemplateField>--%>
                                                <asp:BoundField DataField="LotNo" HeaderText="LotNo">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass=" itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BlockingType" HeaderText="BlockType">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass=" itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty">
                                                    <HeaderStyle CssClass=" headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal. Qty">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acp. Qty">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej. Qty">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="WaxTemp" HeaderText="CoolTemp">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" NullDisplayText=" --">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Blockedby" HeaderText="Blockedby" 
                                                    NullDisplayText=" -- ">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Shift" HeaderText="Shift">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                                    HeaderText="Date">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerStyle CssClass="pager" />
                                            <FooterStyle CssClass="footer" />
                                            <SelectedRowStyle CssClass="selectedrow" />
                                            <HeaderStyle CssClass="grd_Header" />
                                            <AlternatingRowStyle CssClass="AltRow" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                    </table>
    </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>

