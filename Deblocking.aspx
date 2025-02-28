<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Deblocking.aspx.cs" Inherits="Deblocking" Title="Deblocking" %>

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
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table class="con_table" width="100%">
                            <tr>
                                <td class="textlbl" width="117px">
                                    Lot No
                                </td>
                                <td class="style20">
                                    <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" OnTextChanged="txtLotNo_TextChanged"
                                        MaxLength="11" CssClass="textbox"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtLotNo" FilterType="Numbers" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl">
                                    Blocking Type
                                </td>
                                <td class="style19">
                                    <asp:TextBox ID="txtCutType" runat="server" Enabled="False" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl1">
                                    Received Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReceivedQuantity" runat="server" Enabled="False" CssClass="textbox"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="txtReceivedQuantity_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtReceivedQuantity" FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl">
                                    Finished Quantity
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFinishedQuantity" runat="server" AutoPostBack="True" OnTextChanged="txtFinishedQuantity_TextChanged2"
                                        CssClass="textbox" MaxLength="2"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="txtFinishedQuantity_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtFinishedQuantity">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Accepted Quantity
                                </td>
                                <td class="style8">
                                    <asp:TextBox ID="txtAcceptedQuantity" runat="server" AutoPostBack="True" OnTextChanged="txtAcceptedQuantity_TextChanged"
                                        CssClass="textbox" MaxLength="2"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="txtAcceptedQuantity_FilteredTextBoxExtender" runat="server"
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
                                <td class="style8">
                                    <asp:TextBox ID="txtRejectedQuantity" runat="server" Enabled="False" CssClass="textbox"></asp:TextBox>
                                  <%--  <cc1:FilteredTextBoxExtender ID="txtRejectedQuantity_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtRejectedQuantity">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl">
                                    Cooling Temperature(ºc)
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpWaxTemperature" runat="server" CssClass="dropdown">
                                        <asp:ListItem Value="Select"></asp:ListItem>
                                        <asp:ListItem Value="5">5</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Remarks
                                </td>
                                <td class="style8">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" AutoPostBack="True"
                                        OnTextChanged="txtRemarks_TextChanged"></asp:TextBox>
                                   <%-- <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterMode="InvalidChars" FilterType="Numbers" InvalidChars="1234567890."
                                        TargetControlID="txtRemarks">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                                <td class="textlbl">
                                    De-Blocked By
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDeblockedBy" runat="server" CssClass="textbox" AutoPostBack="True"
                                        OnTextChanged="txtDeblockedBy_TextChanged"></asp:TextBox>
                                  <%--  <cc1:FilteredTextBoxExtender ID="txtDeblockedBy_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtDeblockedBy" ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                    </cc1:FilteredTextBoxExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Shift
                                </td>
                                <td class="style8">
                                    <asp:DropDownList ID="drpShift" runat="server" CssClass="dropdown">
                                        <asp:ListItem Value="Select"></asp:ListItem>
                                        <asp:ListItem Value=" I"></asp:ListItem>
                                        <asp:ListItem Value=" II"></asp:ListItem>
                                        <asp:ListItem Value=" III"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="textlbl">
                                    Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" OnTextChanged="txtDate_TextChanged"
                                        CssClass="textbox"></asp:TextBox>
                                    <%--<cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                        TargetControlID="txtDate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="textlbl">
                                    Radius
                                </td>
                                <td>
                                    <asp:TextBox ID="txtradius" runat="server" AutoPostBack="true" CssClass="textbox">
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
                                <td align="center" class="textlbl" colspan="4">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                                    OnClick="btnSave_Click" Visible="False" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnUpdate" runat="server" 
                                                    ImageUrl="~/images/btn_update.png" OnClick="btnUpdate_Click" Visible="False" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnClear" runat="server" 
                                                    ImageUrl="~/images/btn_clear.png" OnClick="btnClear_Click" 
                                                    Visible="False" />
                                                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                                </cc1:ToolkitScriptManager>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:GridView ID="gvDeblocking" runat="server" AutoGenerateColumns="False" CellPadding="1" HorizontalAlign="Center"
                                        OnSelectedIndexChanged="gvDeblocking_SelectedIndexChanged" BorderColor="#B1B1B1"
                                        BorderStyle="Solid" BorderWidth="1px" Width="100%">
                                        <RowStyle CssClass="narmal_row" />
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
                                            <asp:BoundField DataField="BlockingType" HeaderText="Blocking" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec. Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FinishedQuantity" HeaderText="Finsh.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
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
                                            <asp:BoundField DataField="WaxTemp" HeaderText="CoolTemp" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
                                                <HeaderStyle CssClass="headeritem" />
                                                <ItemStyle CssClass="itemstyle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DeBlockedBy" HeaderText="DeBlockedby" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" >
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
                                        <PagerStyle CssClass="pager" />
                                        <FooterStyle CssClass="footer" />
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
