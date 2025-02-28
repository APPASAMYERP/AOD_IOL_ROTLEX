
<%@ Page Title="MI for Cleaned Lens" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MIforCleanedLens.aspx.cs" Inherits="MIforCleanedLens" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


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
                MicroScopic Inspection For Cleaned Lens
            </td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="LotNo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNO" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="11" ontextchanged="txtLotNO_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                                             runat="server" Enabled="True" FilterType="Numbers" 
                                             TargetControlID="txtLotNo" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"></cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="Inspected Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInspectedQty" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="Accepted Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAcceptedQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="2" ontextchanged="txtAcceptedQty_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtAcceptedQty_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtAcceptedQty">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="Rejected Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejectedQty" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px"></asp:TextBox>
                        </td>
<%--                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="Rejected MTS No" 
                                Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejectedMtsNo" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px" Visible="False"></asp:TextBox>
                        </td>--%>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="textlbl" 
                                Text="Inspected&nbsp; By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtInspectedBy" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtInspectedBy_TextChanged" Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtInspectedBy_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtInspectedBy" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                         <td>
                            <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Approved By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtApprovedBy" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtApprovedBy_TextChanged" Width="150px"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtApprovedBy_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtApprovedBy" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <tr>
                       
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="textlbl" Text="Shift"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlShift" runat="server" CssClass="dropdown">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>I</asp:ListItem>
                                <asp:ListItem>II</asp:ListItem>
                                <asp:ListItem>III</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" 
                                Width="150px" AutoPostBack="True"></asp:TextBox>
                            <%--<cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                TargetControlID="txtDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>--%>
                            <%--<cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtDate" 
                                ValidChars="0123456789./-">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 3px;">
                <table class="con_table" width="100%">
                    <tr>
                        <td colspan="6" 
                            style="padding: 5px; font-weight: bold; background-color: #6986C2; font-family: Arial; font-size: 9pt; color: #FFFFFF;">
                            Rejection Details</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" CssClass="textlbl" Text="ESC"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtESC" runat="server" AutoPostBack="True" CssClass="textbox" 
                                MaxLength="2" ontextchanged="txtESC_TextChanged" Width="150px">0</asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtESC_FilteredTextBoxExtender" runat="server" 
                                Enabled="True" FilterType="Numbers" TargetControlID="txtESC">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" CssClass="textlbl" Text="SCR"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSCR" runat="server" AutoPostBack="True" CssClass="textbox" 
                                MaxLength="2" ontextchanged="txtSCR_TextChanged" Width="150px">0</asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtSCR_FilteredTextBoxExtender" runat="server" 
                                Enabled="True" FilterType="Numbers" TargetControlID="txtSCR">
                            </cc1:FilteredTextBoxExtender>--%>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="textlbl" Text="L.B"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLB" runat="server" AutoPostBack="True" CssClass="textbox" 
                                MaxLength="2" ontextchanged="txtLB_TextChanged" Width="150px">0</asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtLB_FilteredTextBoxExtender" runat="server" 
                                Enabled="True" FilterType="Numbers" TargetControlID="txtLB">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" CssClass="textlbl" Text="CHIP"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtChip" runat="server" AutoPostBack="True" CssClass="textbox" 
                                MaxLength="2" ontextchanged="txtChip_TextChanged" Width="150px">0</asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtChip_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtChip">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label15" runat="server" CssClass="textlbl" Text="BURR"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBurr" runat="server" AutoPostBack="True" CssClass="textbox" 
                                MaxLength="2" ontextchanged="txtBurr_TextChanged" Width="150px">0</asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtBurr_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtBurr">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td width="90">
                            <asp:Label ID="Label16" runat="server" CssClass="textlbl" Text="THICK"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtThick" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="2" ontextchanged="txtThick_TextChanged" 
                                Width="150px">0</asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtThick_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtThick">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td width="80" style="height: 22px">
                            <asp:Label ID="Label18" runat="server" CssClass="textlbl" Text="OTHERS"></asp:Label>
                        </td>
                        <td style="height: 22px">
                            
                            <asp:TextBox ID="txtothers" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="2" ontextchanged="txtothers_TextChanged" 
                                Width="150px">0</asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtothers_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtothers">
                            </cc1:FilteredTextBoxExtender>--%>
                            
                        </td>
                        <td width="80" style="height: 22px">
                            <asp:Label ID="Label21" runat="server" CssClass="textlbl" Text="OFFSET"></asp:Label>
                        </td>
                        <td style="height: 22px">
                            
                            <asp:TextBox ID="txtOffset" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="2" ontextchanged="txtOffset_TextChanged" 
                                Width="150px">0</asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtOffset_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtOffset">
                            </cc1:FilteredTextBoxExtender>
                            --%>
                        </td>
                        <td width="80" style="height: 22px">
                            <asp:Label ID="Label22" runat="server" CssClass="textlbl" Text="CUTTING"></asp:Label>
                        </td>
                        <td style="height: 22px">
                            
                            <asp:TextBox ID="txtCutting" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="2" ontextchanged="txtCutting_TextChanged" 
                                Width="150px">0</asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtCutting_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtCutting">
                            </cc1:FilteredTextBoxExtender>
                            --%>
                        </td>

                       <%-- <td width="60" style="height: 22px">
                            <asp:Label ID="Label17" runat="server" CssClass="textlbl" 
                                Text="TumblingNo " Visible="False"></asp:Label>
                        </td>
                        <td style="height: 22px">
                            <asp:TextBox ID="txtTumblingNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="8" 
                                Width="150px" Visible="False"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtTumblingNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtTumblingNo" 
                                ValidChars="t1234567890T">
                            </cc1:FilteredTextBoxExtender>
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 3px;">
                <table class="con_table" width="100%">
                    <tr>
                        <td style="height: 22px; font-weight:bold;">
                            <span style="margin-right: -21px;"><asp:Label ID="Label14" runat="server" CssClass="textlbl" Text="Total"></asp:Label></span>
                        </td>
                        <td style="height: 22px;">
                            <span style="font-weight:bold;"><asp:TextBox ID="txtTotal" runat="server" CssClass="textbox" Width="150px">0</asp:TextBox></span>
                            <%--<cc1:FilteredTextBoxExtender ID="txtTotal_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtTotal">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                 </table>
                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>
             </td>
          </tr>
        <tr>
            <td align="center">
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
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

