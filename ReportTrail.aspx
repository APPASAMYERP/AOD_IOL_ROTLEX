<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportTrail.aspx.cs" Inherits="ReportTrail" Title="Packing Report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers>
     <asp:PostBackTrigger ControlID ="btnSave" />
    <asp:PostBackTrigger ControlID ="btnUpdate" />
    <asp:PostBackTrigger ControlID ="btnClear" />
    </Triggers>
    <ContentTemplate>
    <link href="/css/css.css" rel="stylesheet" type="text/css" runat="server" id="styleMain" visible="false" />
   
    <table cellpadding="0" cellspacing="0" width="100%">
                        <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 8px;">
                                PACKING REPORTS</td>
                        </tr>
                        <tr>
                            <td >
                                
                                <table width="100%" class="con_table">
        <tr>
            <td class="style1" style="width: 139px">
                <asp:Label ID="lblGlassyNo" runat="server" Font-Bold="False" Text="Lot No" 
                    CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLotNo" runat="server" BackColor="White" 
                ontextchanged="txtGlassyNo_TextChanged" AutoPostBack="True" MaxLength="11" 
                    CssClass="textbox"></asp:TextBox>
            </td>
            <td>
                    <asp:Label ID="lblPower" runat="server" CssClass="textlbl" Text="Power"></asp:Label>
            </td>
            <td>
                   <%--<asp:TextBox ID="txtPower" runat="server" CssClass="textbox" Enabled="False" 
                    TabIndex="1"></asp:TextBox>--%>
                    <asp:DropDownList ID="drpPower" runat="server" CssClass="dropdown" 
                        AutoPostBack="true" AppendDataBoundItems="true" 
                        onselectedindexchanged="drpPower_SelectedIndexChanged">
                    <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
            </td>            
            </tr>
            
            
            <tr>
             <td class="style1" style="width: 139px">
                <asp:Label ID="lblModelNo" runat="server"  Text="Model No" 
                     CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtModelNo" runat="server" CssClass="textbox" Enabled="False" 
                    TabIndex="1"></asp:TextBox>
            </td>
             <td>
                <asp:Label ID="lblTumblingNo" runat="server"  Text="Tumbling No" 
                     CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTumblingNo" runat="server" CssClass="textbox" Enabled="False" 
                     TabIndex="1"></asp:TextBox>
            </td>
                </tr>
                
                
                 <tr>
                <td class="style1" style="width: 139px">
                    <asp:Label ID="lblTotalQty" runat="server" CssClass="textlbl" Text="Total Qty"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTotalQty" runat="server" CssClass="textbox" Enabled="False" 
                        TabIndex="1"></asp:TextBox>
                </td>
                            <td>
                                <asp:Label ID="lblDate" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"
                                 TabIndex="1" AutoPostBack="True"></asp:TextBox>
                                <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                    TargetControlID="txtDate" Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </td>
                 </tr>
                            
                                    <tr>                                        
                                                <td>
                                            <asp:Label ID="lblAcceptedQty" runat="server" CssClass="textlbl" 
                                                Text="Accepted Qty"></asp:Label>
                                                </td>
                                                <td>
                                            <asp:TextBox ID="txtAcceptedQty" runat="server" BackColor="White" 
                                                CssClass="textbox" ontextchanged="txtAcceptedQty_TextChanged" 
                                                        AutoPostBack="True" TabIndex="3" Enabled="False" ></asp:TextBox>
                                                </td>
                                                <td class="style1" style="width: 139px">
                                            <asp:Label ID="lblRetumblingQty" runat="server" CssClass="textlbl" 
                                                Font-Bold="False" Text="Retumbling Qty"></asp:Label>
                                                </td>
                                                <td>
                                            <asp:TextBox ID="txtRetumblingQty" runat="server" BackColor="White" CssClass="textbox" 
                                                AutoPostBack="True" TabIndex="4" Text="0" Enabled="false" ontextchanged="txtRetumblingQty_TextChanged" 
                                                        ></asp:TextBox>
                                                </td>
                                                </tr>
                                                
                                                
                                                
                                                <tr>
                                        
                                                <td>
                                            <asp:Label ID="lblRejectedQty" runat="server" CssClass="textlbl" 
                                                Text="Rejected Qty"></asp:Label>
                                                </td>
                                                <td>
                                            <asp:TextBox ID="txtRejectedQty" runat="server" BackColor="White" 
                                                CssClass="textbox" Enabled="False" AutoPostBack="True" TabIndex="5"></asp:TextBox>
                                                </td>
                                                <td class="style1" style="width: 139px">
                                            <asp:Label ID="lblRemarks" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                                            </td>
                                            <td>
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox"
                                                 ontextchanged="txtRemarks_TextChanged" AutoPostBack="True" TabIndex="7" 
                                                    Enabled="False"></asp:TextBox>
                                             </td>                                           
                                                
                                                </tr>
                                                
                                         <tr>
                                       
                                              <td>
                                            <asp:Label ID="lblApprovedBy" runat="server" CssClass="textlbl" 
                                                Text="Approved By"></asp:Label>
                                                </td>
                                                <td>
                                            <asp:TextBox ID="txtApprovedBy" runat="server" AutoPostBack="True" 
                                                BackColor="White" CssClass="textbox" 
                                                ontextchanged="txtApprovedBy_TextChanged" TabIndex="8" Enabled="False"></asp:TextBox>
                                                </td>
                                                </tr>

                                                <tr>
                                        <td align="center" colspan="4">
                                            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                            </asp:ToolkitScriptManager>
                                            <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                                onclick="btnSave_Click" TabIndex="9" Visible="False" />
                                            &nbsp;<asp:ImageButton ID="btnUpdate" runat="server" 
                                                ImageUrl="~/images/btn_update.png" TabIndex="10" 
                                                Visible="False" />
                                            &nbsp;<asp:ImageButton ID="btnClear" runat="server" 
                                                ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click1" TabIndex="11" 
                                                Visible="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style1" colspan="4">
                                            <asp:GridView ID="gvPackingReports" runat="server" AutoGenerateColumns="False" 
                                                BorderColor="#B1B1B1" BorderStyle="Solid" BorderWidth="1px" 
                                                 Width="100%">
                                                <FooterStyle CssClass="footer" />
                                                <RowStyle CssClass="narmal_row" />
                                                <Columns>
                                                    <asp:BoundField DataField="GlassyNo" HeaderText="GlassyNo">
                                                        <HeaderStyle CssClass="headeritem" Wrap="True" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="TumblingNo" DataField="TumblingNo">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Model" HeaderText="Model">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Power" HeaderText="Power">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="TotQty" DataField="TotalQty">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                                        HeaderText="Date">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="JarNo" DataField="JarNo">
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="AccQty" DataField="AcceptedQty">
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="RetumQty" DataField="RetumblingQty">
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="RejQty" DataField="RejectedQty" />
                                                    <asp:BoundField DataField="Shift" HeaderText="Shift">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Remarks" DataField="Remarks" />
                                                    <asp:BoundField DataField="ApprovedBy" HeaderText="AppBy">
                                                    </asp:BoundField>
                                                </Columns>
                                                <PagerStyle CssClass="pager" />
                                                <SelectedRowStyle CssClass="selectedrow" />
                                                <HeaderStyle CssClass="grd_Header" />
                                                <AlternatingRowStyle CssClass="AltRow" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
            </tr>
        </tr>
        </table>
                                
                            </td>
                        </tr>
                    </table>
        
        </ContentTemplate>

 </asp:UpdatePanel>
</asp:Content>

