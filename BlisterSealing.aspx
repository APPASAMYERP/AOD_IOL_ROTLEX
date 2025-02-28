<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="BlisterSealing"  AutoEventWireup="true" CodeFile="BlisterSealing.aspx.cs" Inherits="BlisterSealing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
            <asp:PostBackTrigger ControlID="btnClear" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" id="table_left">
                <tr>
                    <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                        <asp:Label ID="lbProcessName" runat="server" Style="font-weight: 700" Text="BLISTERSEALING"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="con_table" width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" CssClass="textlbl" Text="Lot No&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" CssClass="textbox"
                                       ontextchanged="txtGlassyNo_TextChanged"></asp:TextBox>
                                  
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
                                    <asp:Label ID="Label29" runat="server" CssClass="textlbl" Text="Power"></asp:Label>
                                </td>
                                <td>
                                <%--<asp:TextBox ID="txtPower" runat="server" CssClass="textbox" Enabled="False"></asp:TextBox>--%>
                                <asp:DropDownList ID="drpPower" runat="server" CssClass="dropdown" 
                                        AppendDataBoundItems="true" AutoPostBack="true" 
                                        onselectedindexchanged="drpPower_SelectedIndexChanged">
                                <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList>                                    
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" CssClass="textlbl" Text="Total Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalQuantity" runat="server" CssClass="textbox" 
                                        Enabled="False"></asp:TextBox>
                                </td>                               
                            </tr>                           
                            <tr>
                                <td>
                                    <asp:Label ID="Label20" runat="server" CssClass="textlbl" Text="Rec. Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReceivedQuantity" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" ontextchanged="txtReceivedQuantity_TextChanged" ></asp:TextBox>
                                </td>
                                 <td>
                                    <asp:Label ID="Label30" runat="server" CssClass="textlbl" Text="Prog&nbsp; Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProgQty" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" ontextchanged="txtProgQty_TextChanged"></asp:TextBox>                                   
                                </td>
                               
                            </tr>
                            <tr>
                             <td>
                                    <asp:Label ID="Label25" runat="server" CssClass="textlbl" Text="Bal. Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBalanceQty" runat="server" CssClass="textbox" Enabled="False">0</asp:TextBox>                                  
                                </td>
                               
                                <td>
                                    <asp:Label ID="Label21" runat="server" CssClass="textlbl" Text="Accepted Qty"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAccpQty" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" ontextchanged="txtAccpQty_TextChanged"></asp:TextBox>                                   
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
                                        CssClass="textbox" ontextchanged="txtWipDnby0_TextChanged"></asp:TextBox>                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label22" runat="server" CssClass="textlbl" Text="Magnifier Done by"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWipDnby" runat="server" AutoPostBack="True" 
                                        CssClass="textbox" ontextchanged="txtWipDnby_TextChanged"></asp:TextBox>                                   
                                </td>
                                <td>
                                    <asp:Label ID="Label27" runat="server" CssClass="textlbl" Text="&nbsp;Date&nbsp;"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" AutoPostBack="True" 
                                       ></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                        TargetControlID="txtDate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                                    Visible="False" onclick="btnSave_Click" />
                                                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                                </cc1:ToolkitScriptManager>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_update.png"
                                                    Visible="False" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/btn_clear.png"
                                                    Visible="False" onclick="btnClear_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" align="center">
                                    
                                        <asp:GridView ID="gvSealingPro" runat="server" AutoGenerateColumns="False" BorderColor="#B1B1B1" HorizontalAlign="Center"
                                            EnableModelValidation="True">
                                            <AlternatingRowStyle CssClass="AltRow" />
                                            <Columns>
                                                <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" ShowSelectButton="True">
                                                    <HeaderStyle CssClass="headeritem" />
                                                    <ItemStyle CssClass="itemstyle" />
                                                </asp:CommandField>--%>
                                                <asp:BoundField DataField="GlassyNo" HeaderText="GlassyNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="Model" HeaderText="Model" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="Power" HeaderText="Power" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="TotalQty" HeaderText="TotalQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="ReceivedQty" HeaderText="ReceivedQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="BalanceQty" HeaderText="BalanceQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="ProgressQty" HeaderText="ProgressQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="SealdoneBy" HeaderText="SealdoneBy" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="MagnidoneBy" HeaderText="MagnidoneBy" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
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



