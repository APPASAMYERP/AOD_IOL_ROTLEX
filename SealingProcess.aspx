<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SealingProcess.aspx.cs" Inherits="SealingProcess" Title="Sealing Process" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
            <asp:PostBackTrigger ControlID="btnClear" />
        </Triggers>
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td colspan="6" align="left" style="background-color: #666666; font-family: Arial;
                        font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
                        <asp:Label ID="lbProcessName" runat="server" Style="font-weight: 700" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6" style="padding-top: 3px">
                        <table class="con_table" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" CssClass="textlbl" Text="TumbLot No&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" CssClass="textbox"
                                        MaxLength="8" OnTextChanged="txtLotNo_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtLotNo" ValidChars="t1234567890T">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label23" runat="server" CssClass="textlbl" Text="Model"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtModelNo" runat="server" CssClass="textbox" Enabled="False" 
                                       ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label28" runat="server" CssClass="textlbl" Text="Total Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalQuantity" runat="server" CssClass="textbox" 
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" CssClass="textlbl" 
                                        Text="Tot Completed Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTCompQty" runat="server" CssClass="textbox" Enabled="False" 
                                       >0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label24" runat="server" CssClass="textlbl" Text="Rec/prv Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrevDate" runat="server" CssClass="textbox" Enabled="False" 
                                       ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label29" runat="server" CssClass="textlbl" Text="Power"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpPwr" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" Height="18px" 
                                        OnSelectedIndexChanged="drpPwr_SelectedIndexChanged" 
                                        AppendDataBoundItems="True">
                                        <asp:ListItem Value="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label20" runat="server" CssClass="textlbl" Text="Rec. Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReceivedQuantity" runat="server" AutoPostBack="True" CssClass="textbox"
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" CssClass="textlbl" Text="Bal. Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBalanceQty" runat="server" CssClass="textbox" Enabled="False"
                                        OnTextChanged="txtProgQty_TextChanged">0</asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtBalanceQty_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" FilterType="Numbers" TargetControlID="txtBalanceQty">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label30" runat="server" CssClass="textlbl" Text="Prog&nbsp; Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProgQty" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" OnTextChanged="txtProgQty_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtProgQty_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtProgQty">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label21" runat="server" CssClass="textlbl" Text="Accepted Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAccpQty" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" OnTextChanged="txtAccpQty_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtAccpQty_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtAccpQty">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label26" runat="server" CssClass="textlbl" Text="Rejected Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRejQty" runat="server" CssClass="textbox" Enabled="False" 
                                       ></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label31" runat="server" CssClass="textlbl" 
                                        Text="Sealing Done by"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWipDnby0" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" OnTextChanged="txtWipDnby0_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtWipDnby0_FilteredTextBoxExtender" 
                                        runat="server" Enabled="True" TargetControlID="txtWipDnby0" 
                                        ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" CssClass="textlbl" Text="Magnifier Done by"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWipDnby" runat="server" AutoPostBack="True" CssClass="textbox"
                                        OnTextChanged="txtWipDnby_TextChanged"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtWipDnby_FilteredTextBoxExtender" runat="server"
                                        Enabled="True" TargetControlID="txtWipDnby" ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td>
                                    <asp:Label ID="Label27" runat="server" CssClass="textlbl" Text="&nbsp;Date&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Enabled="False" 
                                       ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" OnClick="btnSave_Click"
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_update.png"
                                                    OnClick="btnUpdate_Click" Visible="False" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/btn_clear.png"
                                                    OnClick="btnClear_Click" Visible="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    <div style="width: 700px; overflow: scroll;">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:GridView ID="gvSealingPro" runat="server" AutoGenerateColumns="False" BorderColor="#B1B1B1"
                                            EnableModelValidation="True" OnSelectedIndexChanged="gvSealingPro_SelectedIndexChanged"
                                            Width="1100px">
                                            <AlternatingRowStyle CssClass="AltRow" />
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" ShowSelectButton="True">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="id" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sealing Pro">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SealingProcess") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("SealingProcess") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="T.LotNo">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("TumblingLotNo") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("TumblingLotNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="M.No">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ModelNo") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ModelNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="T.Qty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("TotalQuantity") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("TotalQuantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="T.C.Qty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("TotCompletedQuantity") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("TotCompletedQuantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="P.date">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("PrevDate") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("PrevDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Pwr">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Power") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Power") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="R.qty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("ReceivedQuantity") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("ReceivedQuantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BalQty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("BalanceQty") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("BalanceQty") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ProgQty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("ProgQuantity") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("ProgQuantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Acc.Qty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("AcceptedQuantity") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("AcceptedQuantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rej.Qty">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("RejectedQuantity") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("RejectedQuantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SealDoneby1">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("SealingDoneby1") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("SealingDoneby1") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sealdoneby2">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("SealingDoneby2") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("SealingDoneby2") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("Date") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("Date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle CssClass="footer" />
                                            <SelectedRowStyle CssClass="selectedrow" />
                                            <HeaderStyle CssClass="grd_Header" />
                                            <PagerStyle CssClass="pager" />
                                            <RowStyle CssClass="narmal_row" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
  
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
