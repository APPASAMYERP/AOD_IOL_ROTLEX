<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LensPreparationTumbling.aspx.cs" Inherits="LensPreparationTumbling" Title="Lens Preparation for Tumbling" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:PostBackTrigger ControlID ="btnSave" />
    <asp:PostBackTrigger ControlID ="btnUpdate" />
     <asp:PostBackTrigger ControlID ="btnClear" />
    </Triggers>
      <ContentTemplate>
    <table width="100%">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                Lens Preparation For Tumbling</td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Tumbling No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTumblingNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="11" ontextchanged="txtTumblingNo_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtTumblingNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtTumblingNo" 
                                ValidChars="t1234567890T">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="Model"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModelNo" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="Qty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="Jar No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtJarNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="5" ontextchanged="txtJarNo_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtJarNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtJarNo" 
                                ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="Location"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLocation" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="3" ontextchanged="txtLocation_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLocation_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtLocation" 
                                ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" CssClass="textlbl" Text="Start Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server" CssClass="textbox" Width="150px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtStartDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Start Time"></asp:Label>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtStartTime" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" ontextchanged="txtStartTime_TextChanged" Width="80px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="txtStartTime_MaskedEditExtender" runat="server" 
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="99:99" MaskType="Time" TargetControlID="txtStartTime">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td class="textlbl">
                                        /&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlStartDay" runat="server" CssClass="dropdown" 
                                            Width="50px">
                                            <asp:ListItem>AM</asp:ListItem>
                                            <asp:ListItem>PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" CssClass="textlbl" Text="Stop Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStopDate" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False" ontextchanged="txtStopDate_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtStopDate_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtStopDate">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="Stop Time"></asp:Label>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtStopTime" runat="server" AutoPostBack="True" 
                                            Enabled="False" ontextchanged="txtStopTime_TextChanged" Width="80px" 
                                            CssClass="textbox"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="txtStopTime_MaskedEditExtender" runat="server" 
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="99:99" MaskType="Time" TargetControlID="txtStopTime">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td class="textlbl">
                                        /&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlStopDay" runat="server" Enabled="False" 
                                            onselectedindexchanged="ddlStopDay_SelectedIndexChanged" Width="50px" 
                                            CssClass="dropdown">
                                            <asp:ListItem>AM</asp:ListItem>
                                            <asp:ListItem>PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" CssClass="textlbl" Text="Duration"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDuration" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False" ontextchanged="txtRemarks_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterMode="InvalidChars" 
                                InvalidChars="1234567890" TargetControlID="txtRemarks">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" CssClass="textlbl" Text="Tumbled By"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTumbledBy" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Enabled="False" ontextchanged="txtTumbledBy_TextChanged" 
                                Width="150px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtTumbledBy_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtTumbledBy" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
                            <asp:GridView ID="GridView1" runat="server" BorderColor="#B1B1B1" 
                                BorderStyle="Solid" BorderWidth="1px" Width="70%">
                                <AlternatingRowStyle CssClass="AltRow" />
                                <FooterStyle CssClass="footer" />
                                <HeaderStyle CssClass="grd_Header" />
                                <PagerStyle CssClass="pager" />
                                <RowStyle CssClass="narmal_row" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="6">
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
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

