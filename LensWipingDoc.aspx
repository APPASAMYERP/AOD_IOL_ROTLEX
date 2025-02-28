<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LensWipingDoc.aspx.cs" Inherits="LensWipingDoc" Title="Lens Wiping" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnSave"/>
   <asp:PostBackTrigger ControlID = "btnUpdate" />
   <asp:PostBackTrigger ControlID = "btnClear" />
   </Triggers>
   <ContentTemplate>
    <table width="100%" id="table_left">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                LENS WIPING
            </td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label17" runat="server" CssClass="textlbl" Text="Lot No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="13" 
                                Width="125px" ontextchanged="txtLotNo_TextChanged"></asp:TextBox>                            
                        </td>
                        <td>
                            <asp:Label ID="Label20" runat="server" CssClass="textlbl" 
                                Text="Power"></asp:Label>
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtPower" runat="server" CssClass="textbox" Enabled="False" Width="125px"></asp:TextBox>--%>
                            <asp:DropDownList ID="drpPower" runat="server" CssClass="dropdown" 
                                AutoPostBack="true" Width="131px" AppendDataBoundItems="true" 
                                onselectedindexchanged="drpPower_SelectedIndexChanged">
                            <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label18" runat="server" CssClass="textlbl" Text="Model"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModelNo" runat="server" CssClass="textbox" Enabled="False" 
                                Width="125px"></asp:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label19" runat="server" CssClass="textlbl" Text="Total Quantity"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalQuantity" runat="server" CssClass="textbox" 
                                Enabled="False" Width="125px"></asp:TextBox>
                        </td>                        
                        <td>
                            <asp:Label ID="Label24" runat="server" CssClass="textlbl" Text="ReceivedQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReceivedQty" runat="server" CssClass="textbox" 
                                Width="125px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label28" runat="server" CssClass="textlbl" Text="ProgressingQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProgressingQty" runat="server" CssClass="textbox" 
                                Width="125px" AutoPostBack="True" 
                                ontextchanged="txtProgressingQty_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label21" runat="server" CssClass="textlbl" Text="BalanceQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBalanceQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False" Width="125px">0</asp:TextBox>
                        </td>
                         <td>
                            <asp:Label ID="Label22" runat="server" CssClass="textlbl" Text="AcceptedQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAcceptedQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Width="125px" 
                                ontextchanged="txtAcceptedQty_TextChanged"></asp:TextBox>
                        </td>
                         <td>
                            <asp:Label ID="Label26" runat="server" CssClass="textlbl" Text="RejectedQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejectedQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False" Width="125px"></asp:TextBox>
                        </td>
                        
                    </tr>                    
                    <tr>
                    <td>
                            <asp:Label ID="Label25" runat="server" CssClass="textlbl" Text="TumblingRefNo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTumblingRef" runat="server" CssClass="textbox" 
                                Enabled="False" Width="125px"></asp:TextBox>
                            
                        </td>
                        <td>
                            <asp:Label ID="Label29" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" 
                                CssClass="textbox"  Width="125px" ontextchanged="txtRemarks_TextChanged"></asp:TextBox>                           
                        </td>
                        <td>
                            <asp:Label ID="Label23" runat="server" CssClass="textlbl" Text="Wiping Done by"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtWipDnby" runat="server" AutoPostBack="True" 
                                CssClass="textbox"  Width="125px" ontextchanged="txtWipDnby_TextChanged"></asp:TextBox>                            
                        </td>                        
                        
                    </tr>
                    <tr>
                    <td>
                            <asp:Label ID="Label31" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" 
                                 Width="125px" AutoPostBack="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                TargetControlID="txtDate" Format="yyyy-MM-dd">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                             Visible="False" onclick="btnSave_Click" />
                                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnUpdate" runat="server" 
                                            ImageUrl="~/images/btn_update.png"  Visible="False" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnClear" runat="server" 
                                            ImageUrl="~/images/btn_clear.png"  
                                            Visible="False" onclick="btnClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center" >
                        
                            <asp:GridView ID="gvLenswiping" runat="server" AutoGenerateColumns="False" 
                                BorderColor="#B1B1B1" EnableModelValidation="True" 
                                onselectedindexchanged="gvLenswiping_SelectedIndexChanged" Width="100%" 
                                EnableTheming="False" HorizontalAlign="Center">
                                <AlternatingRowStyle CssClass="AltRow" />
                                <Columns>
                                    <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" 
                                        ShowSelectButton="True">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:CommandField>--%>
                                   
                                    <asp:BoundField DataField="GlassyNo" HeaderText="GlassyNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="TotalQuantity" HeaderText="TotalQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  />
                                    <asp:BoundField DataField="Power" HeaderText="Power" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="ReceivedQty" HeaderText="ReceivedQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="ProgressingQty" HeaderText="ProgressedQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="BalanceQty" HeaderText="BalanceQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"  />
                                    <asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="TumblingNo" HeaderText="TumblingRefNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="WipingBy" HeaderText="WipingBy" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                </Columns>
                                <FooterStyle />
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

