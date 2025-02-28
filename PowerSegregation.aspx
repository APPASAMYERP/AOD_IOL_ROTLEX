<%@ Page Title="Power Segregation" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PowerSegregation.aspx.cs" Inherits="PowerSegregation" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:PostBackTrigger ControlID ="btnSave" />
    <asp:PostBackTrigger ControlID ="btnUpdate" />
     <asp:PostBackTrigger ControlID ="btnClear" />
    </Triggers>
    <ContentTemplate>
    <table width="100%" style="margin-top: -2px; margin-left: -4px;">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                Power Segregation</td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlbl_ps" Text="LotNo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTumblingNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="13" ontextchanged="txtTumblingNo_TextChanged" 
                                Width="150px"></asp:TextBox>
<%--                            <cc1:FilteredTextBoxExtender ID="txtTumblingNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtTumblingNo" 
                                ValidChars="phyt1234567890PHYT">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="textlbl_ps" Text="Recieved Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRecievedQty" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlbl_ps" Text="Accepted Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAcceptedQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtAcceptedQty_TextChanged" 
                                Width="150px"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtAcceptedQty_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtAcceptedQty" 
                                ValidChars="1234567890">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="textlbl_ps" Text="Rejected Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejectedQty" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="textlbl_ps" Text="Reason"></asp:Label>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkGoodReason" runat="server" AutoPostBack="True" 
                                            Checked="True" CssClass="textlbl_ps" 
                                            oncheckedchanged="chkGoodReason_CheckedChanged" Text="Good" />
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="chkBadReason" runat="server" AutoPostBack="True" 
                                            CssClass="textlbl" oncheckedchanged="chkBadReason_CheckedChanged" Text="Bad" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="textlbl_ps" Text="Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Width="150px" 
                                AutoPostBack="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                TargetControlID="txtDate" Format="yyyy-MM-dd">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="textlbl_ps" Text="Tumbling RefNo"></asp:Label>
                        </td>
                        <td>                            
                            <asp:TextBox ID="txtTumblingrefno" runat="server" AutoPostBack="True" 
                                CssClass="textbox"  Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label10" runat="server" CssClass="textlbl_ps" Text="Remarks"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtRemarks_TextChanged" Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterMode="InvalidChars" 
                                InvalidChars="1234567890" TargetControlID="txtRemarks">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" CssClass="textlbl_ps" Text="Inspected By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInspectedBy" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtInspectedBy_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtInspectedBy_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtInspectedBy" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <%--<tr>
                        <td colspan="6" align="center">
                            <table class="nav">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label12" runat="server" CssClass="textlbl_ps" Text="Power"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtObservedPower" runat="server" CssClass="textbox" 
                                            MaxLength="7" Width="54px"></asp:TextBox>
                                       <cc1:FilteredTextBoxExtender ID="txtObservedPower_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtObservedPower" 
                                            ValidChars="1234567890.-">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" CssClass="textlbl_ps" Text="Qty"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" Width="54px"></asp:TextBox>
                                    </td>
                                    <td>
                                     <asp:Label ID="LabelgrfNo" runat="server" CssClass="textlbl_ps" Text="Glassy Record Ref"></asp:Label>
                                    </td>
                                    <td>
                                    <asp:TextBox ID="txtGrfNo" runat="server" CssClass="textbox" Width="90px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/btn_aad.gif" 
                                            onclick="btnAdd_Click" Width="32px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:GridView ID="gvPowerSegregation" runat="server" 
                                AutoGenerateColumns="False" BorderColor="#B1B1B1" EnableModelValidation="True" 
                                onrowcancelingedit="gvPowerSegregation_RowCancelingEdit" 
                                onrowediting="gvPowerSegregation_RowEditing" 
                                onrowupdating="gvPowerSegregation_RowUpdating" Width="70%" 
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1">
                                <AlternatingRowStyle CssClass="AltRow" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Observrd Power">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ObservedPower") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("ObservedPower") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Glassy Record Ref">
                                    <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("GlassyRef") %>' ReadOnly='true'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("GlassyRef") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/gvCancel.png" 
                                        EditImageUrl="~/images/gvedit.png" ShowEditButton="True" 
                                        UpdateImageUrl="~/images/gvUpdate.png">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" Width="12px" />
                                    </asp:CommandField>
                                </Columns>
                                <FooterStyle CssClass="footer" />
                                <HeaderStyle CssClass="grd_Header" />
                                <PagerStyle CssClass="pager" />
                                <RowStyle CssClass="narmal_row" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="center" colspan="3">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbTotalQuantity" runat="server" CssClass="textlbl" 
                                            Text="Total Quantity" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotalQty" runat="server" CssClass="textbox" Enabled="False" 
                                            Visible="False" Width="70px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>--%>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="center" colspan="5">
                            <table>
                                <tr>
                                    <td>
                                        <%--<asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                            onclick="btnSave_Click" />--%>
                                         
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                            onclick="btnSave_Click1" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnUpdate" runat="server" 
                                            ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" Visible="False" />
                                    </td>
                                    <td style="width: 127px">
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
                        <td align="center" colspan="6">
                            <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="false"
                                          BorderColor="#B1B1B1" EnableModelValidation="True" Width="100%"
                                          EnableTheming="False" HorizontalAlign="Center">
                                <AlternatingRowStyle CssClass="AltRow" />
                                <Columns>
                                    <asp:BoundField DataField="TumblingNo" HeaderText="Lot No" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="RecievedQty" HeaderText="Received Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="AcceptedQty" HeaderText="Accepted Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="RejectedQty" HeaderText="Rejected Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Resolution" HeaderText="Resolution" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="TotalQty" HeaderText="Total Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Remarks" HeaderText="Remark" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="InspectedBy" HeaderText="Insp.By" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                </Columns>
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

