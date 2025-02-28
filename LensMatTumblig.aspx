<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LensMatTumblig.aspx.cs" Inherits="LensMatTumblig" Title="LT For Matt Tumbling" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<script runat="server">

   
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:PostBackTrigger ControlID ="btnSave" />
    <asp:PostBackTrigger ControlID ="btnUpdate" />
     <asp:PostBackTrigger ControlID ="btnClear" />
    </Triggers>
      <ContentTemplate>
    <table width="100%" id="table_left">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                <b>Lens Taken For Matt Tumbling</b></td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                         <td align="center">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                            AutoPostBack="True" RepeatDirection="Horizontal" 
                            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                            BorderStyle="None">
                                <asp:ListItem Value="Matt">                                                  Matt</asp:ListItem>
                                <asp:ListItem Value="Ist Rematt">                                            Ist Rematt</asp:ListItem>
                                <asp:ListItem Value="IInd Rematt">                                           IInd Rematt</asp:ListItem>
                                <asp:ListItem Value="IIIrd Rematt">                                          IIIrd Rematt</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <table class="con_table" width="100%">
                    <tr>
                        <td height="22" style="width: 231px">
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Lot No"></asp:Label>
                        </td>
                        <td height="22" style="width: 306px">
                            <asp:TextBox ID="txtLotno" runat="server" AutoPostBack="True" 
                                CssClass="textbox"  ontextchanged="txtLotno_TextChanged"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtLotno_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtLotno" 
                                ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td height="22" style="width: 158px">
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text=" Date"></asp:Label>
                        </td>
                        <td height="22" style="width: 264px">
                            <asp:TextBox ID="txtSatrtDate" runat="server" CssClass="textbox" AutoPostBack="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtSatrtDate_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtSatrtDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td height="22" style="width: 231px">
                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" 
                                Text="Accepted Quantity"></asp:Label>
                        </td>
                        <td height="22" style="width: 306px">
                            <asp:TextBox ID="txtAcceptedQty" runat="server" CssClass="textbox" 
                                Enabled="False" MaxLength="2"></asp:TextBox>
                        </td>
                        <td height="22" style="width: 158px">
                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="PhobicID"></asp:Label>
                        </td>
                        <td height="22" style="width: 264px">
                            <asp:TextBox ID="txtPhobicId" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtPhobicId_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtPhobicId">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td height="22" style="width: 231px">
                            <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Model"></asp:Label>
                        </td>
                        <td height="22" style="width: 306px">
                            <asp:TextBox ID="txtModel" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False" MaxLength="2"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtModel_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtModel">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td height="22" style="width: 158px">
                            <asp:Label ID="Label8" runat="server" CssClass="textlbl2" Text="Tumbling Ref No"></asp:Label>
                        </td>
                        <td height="22" style="width: 264px">
                            <asp:TextBox ID="txtTumblingRefno" runat="server" CssClass="textbox" 
                                ontextchanged="txtTumblingRefno_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 231px">
                            <asp:Label ID="Label10" runat="server" CssClass="textlbl" Text="Power"></asp:Label>
                        </td>
                        <td style="width: 306px">
                            <asp:TextBox ID="txtPower" runat="server" 
                                CssClass="textbox" Enabled="False"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtPower_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterMode="InvalidChars" FilterType="Numbers" 
                                InvalidChars="1234567890" TargetControlID="txtPower">
                            </cc1:FilteredTextBoxExtender>--%>
                            <td height="22" style="width: 143px">
                                <asp:Label ID="Label13" runat="server" CssClass="textlbl" Text="Prepared by"></asp:Label>
                            </td>
                            <td height="22" style="width: 306px">
                                <asp:TextBox ID="txtPreparedBy" runat="server" AutoPostBack="True" 
                                    CssClass="textbox" ontextchanged="txtPreparedBy_TextChanged"></asp:TextBox>
                                <%--<cc1:FilteredTextBoxExtender ID="txtPreparedBy_FilteredTextBoxExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtPreparedBy" 
                                    ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                </cc1:FilteredTextBoxExtender>--%>
                            </td>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="height: 37px">
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
                        <td align="center" colspan="4">
                            <asp:GridView ID="gvLotResult" runat="server" AutoGenerateColumns="False" 
                                BorderColor="#B1B1B1" CellPadding="1" EnableModelValidation="True" 
                                onselectedindexchanged="gvDeblocking_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle CssClass="AltRow" />
                                <Columns>
                                    <asp:CommandField ButtonType="Image" HeaderText="Select" 
                                        SelectImageUrl="~/images/select.PNG" ShowSelectButton="True">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="ID" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdNo") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label14" runat="server" Text='<%# Bind("IdNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="LensCutLot" HeaderText="LotNo">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalQuantity" HeaderText="Accp Qty">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" Width="81px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PhobicID" HeaderText="Phobic ID">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" Width="81px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ModelNo" HeaderText="Model">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TumblingLotNo" HeaderText="Tumbling No">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Power" HeaderText="Power">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Tumbledby" HeaderText="Prepared By">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                        HeaderText="Date">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle CssClass="footer" />
                                <HeaderStyle CssClass="grd_Header" />
                                <PagerStyle CssClass="pager" />
                                <RowStyle CssClass="narmal_row" />
                                <SelectedRowStyle CssClass="selectedrow" Font-Italic="False" />
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

