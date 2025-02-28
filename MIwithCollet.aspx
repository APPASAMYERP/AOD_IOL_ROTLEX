<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MIwithCollet.aspx.cs" Inherits="MIwithCollet" Title="Haptic Inspection"%>

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
                                <asp:Label ID="Label2" runat="server" Text="HapticInspection"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left">
                             <table class="con_table" width="100%">
        <tr>
            <td class="textlbl" width="117px" >
                Lot No</td>
            <td  >
                <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                                             ontextchanged="txtLotNo_TextChanged" 
                    MaxLength="8" CssClass="textbox"></asp:TextBox>
                <%--<cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                                             runat="server" Enabled="True" FilterType="Numbers" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" TargetControlID="txtLotNo">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
            <td class="textlbl"  >
                                          Cut Type</td>
            <td >
                <asp:TextBox ID="txtCutType" runat="server" 
                    CssClass="textbox" Enabled="False">IInd Cut</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="textlbl">
                Received Quantity</td>
            <td >
                <asp:TextBox ID="txtReceivedQuantity" runat="server" Enabled="False" 
                    CssClass="textbox"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtReceivedQuantity_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtReceivedQuantity">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
            <td class="textlbl">
                                         Finished Quantity</td>
            <td>
                <asp:TextBox ID="txtFinishedQuantity" runat="server" AutoPostBack="True" 
                                             ontextchanged="txtFinishedQuantity_TextChanged" 
                    CssClass="textbox" MaxLength="2"></asp:TextBox>
              <%--  <cc1:FilteredTextBoxExtender ID="txtFinishedQuantity_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtFinishedQuantity">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
        </tr>
        <tr>
            <td class="textlbl">
                Balance Quantity</td>
            <td>
                <asp:TextBox ID="txtBalanceQuantity" runat="server" Enabled="False" 
                    CssClass="textbox">0</asp:TextBox>
            </td>
            <td class="textlbl">
                Accepted Quantity</td>
            <td>
                <asp:TextBox ID="txtAcceptedQuantity" runat="server" AutoPostBack="True" 
                                             ontextchanged="txtAcceptedQuantity_TextChanged" 
                    CssClass="textbox" MaxLength="2"></asp:TextBox>
              <%--  <cc1:FilteredTextBoxExtender ID="txtAcceptedQuantity_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtAcceptedQuantity">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
        </tr>
        <tr>
            <td class="textlbl">
                Rejected Quantity</td>
            <td>
                <asp:TextBox ID="txtRejectedQuantity" runat="server" Enabled="False" 
                    CssClass="textbox"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtRejectedQuantity_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtRejectedQuantity">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
<%--            <td class="textlbl">
                </td>--%>
                <td class="textlbl">
                Remarks</td>
            <td>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtRemarks_TextChanged"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterMode="InvalidChars" 
                    InvalidChars="1234567890" TargetControlID="txtRemarks">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
<%--            <td>
                <asp:TextBox ID="txtRejectedMtsNo" runat="server" CssClass="textbox" 
                    Enabled="False"></asp:TextBox>
            </td>--%>
        </tr>
        <tr>
            
            <td class="textlbl">
                Inspected By</td>
            <td>
                <asp:TextBox ID="txtBlockedBy" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtBlockedBy_TextChanged"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtBlockedBy_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtBlockedBy" 
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
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" AutoPostBack="True" 
                   ></asp:TextBox>
               <%-- <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    TargetControlID="txtDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>--%>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
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
                <asp:GridView ID="gvBlocking" runat="server" AutoGenerateColumns="False" 
                    CellPadding="1" onselectedindexchanged="gvBlocking_SelectedIndexChanged" 
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
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle Width="0px" CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal. Qty" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acp.Qty" >
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
                        <asp:BoundField DataField="InspectedBy" HeaderText="InspectedBy" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shift" HeaderText="Shift" >
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

