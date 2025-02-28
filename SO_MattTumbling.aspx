<%@ Page Title="SO For Matt Tumbling" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SO_MattTumbling.aspx.cs" Inherits="SI_DuringTumbling_" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


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
                Matt Tumbling Surface Observations</td>
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
                                <asp:ListItem Value="Matt">                                                  Tumbling</asp:ListItem>
                                <asp:ListItem Value="Rematt">                                                Retumbling</asp:ListItem>
                               
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="TumblingNo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTumblingNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" MaxLength="13" ontextchanged="txtTumblingNo_TextChanged" 
                                Width="100px"></asp:TextBox>
                            
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="ModelNo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModelNo" runat="server" CssClass="textbox" Enabled="False" 
                                Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="JarNo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtJarNo" runat="server" CssClass="textbox" 
                                Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="Duration"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDuration" runat="server" CssClass="textbox" 
                                Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="8" style="padding: 2px">
                            <table class="con_table" width="100%">
                                <tr>
                                    <td align="left" 
                                        
                                        style="background-color: #6986C2; font-family: Arial; font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
                                        <strong>Sample Details</strong></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table cellpadding="3" cellspacing="0" width="100%">
                                            <tr class="textlbl" style="font-weight:bold;">
                                                <td class="nav">
                                                    SampleNo</td>
                                                <td class="nav">
                                                    Date</td>
                                                <td class="nav">
                                                    Time</td>
                                                <td class="nav">
                                                    Power</td>
                                                <td class="nav">
                                                    Status</td>
                                                <td class="nav">
                                                    Remarks</td>
                                                <td class="nav">
                                                    Inspected By</td>
                                            </tr>
                                            <tr>
                                                <td class="nav">
                                                    <asp:DropDownList ID="ddlSampleNo" runat="server" CssClass="textbox_small" 
                                                        Enabled="False" Height="18px" Width="70px" 
                                                        onselectedindexchanged="ddlSampleNo_SelectedIndexChanged">
                                                        <asp:ListItem>Sample1</asp:ListItem>
                                                        <asp:ListItem>Sample2</asp:ListItem>
                                                        <asp:ListItem>Sample3</asp:ListItem>
                                                        <asp:ListItem>Sample4</asp:ListItem>
                                                        <asp:ListItem>Sample5</asp:ListItem>
                                                        <asp:ListItem>Sample6</asp:ListItem>
                                                        <asp:ListItem>Sample7</asp:ListItem>
                                                        <asp:ListItem>Sample8</asp:ListItem>
                                                        <asp:ListItem>Sample9</asp:ListItem>
                                                        <asp:ListItem>Sample10</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="nav">
                                                    <asp:TextBox ID="txtDateIsnpection" runat="server" CssClass="textbox_small" 
                                                        Width="60px"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="txtDateIsnpection_CalendarExtender" runat="server" 
                                                        Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDateIsnpection">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td class="nav">
                                                    <asp:TextBox ID="txtTime" runat="server" AutoPostBack="True" CssClass="textbox_small" 
                                                        ontextchanged="txtTime_TextChanged" Width="40px"></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="txtTime_MaskedEditExtender" runat="server" 
                                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                                        Mask="99:99" MaskType="Time" TargetControlID="txtTime">
                                                    </cc1:MaskedEditExtender>
                                                    <asp:DropDownList ID="ddlDay" runat="server" CssClass="textbox_small" Height="18px" 
                                                        Width="50px">
                                                        <asp:ListItem>AM</asp:ListItem>
                                                        <asp:ListItem>PM</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="nav">
                                                    <asp:TextBox ID="txtPower" runat="server" AutoPostBack="True" 
                                                        CssClass="textbox_small" MaxLength="6" ontextchanged="txtPower_TextChanged" 
                                                        Width="40px"></asp:TextBox>
                                                    <%--<cc1:FilteredTextBoxExtender ID="txtPower_FilteredTextBoxExtender" 
                                                        runat="server" Enabled="True" TargetControlID="txtPower" 
                                                        ValidChars=".1234567890-">
                                                    </cc1:FilteredTextBoxExtender>--%>
                                                </td>
                                                <td class="nav">
                                                    <asp:CheckBox ID="chkAccepted" runat="server" AutoPostBack="True" 
                                                        Checked="True" CssClass="textlbl_small" oncheckedchanged="chkAccepted_CheckedChanged" 
                                                        Text="Accepted" />
                                                    <asp:CheckBox ID="chkRejected" runat="server" AutoPostBack="True" 
                                                        CssClass="textlbl_small" oncheckedchanged="chkRejected_CheckedChanged" 
                                                        Text="Rejected" />
                                                </td>
                                                <td class="nav">
                                                    <asp:CheckBox ID="chkcontinueremarks" runat="server" AutoPostBack="True" 
                                                        Checked="True" CssClass="textlbl_small" oncheckedchanged="chkcontinue_CheckedChanged" 
                                                        Text="Continue" />
                                                    <asp:CheckBox ID="chkStopRemarks" runat="server" AutoPostBack="True" 
                                                        CssClass="textlbl_small" oncheckedchanged="chkStop_CheckedChanged" Text="Stop" />
                                                </td>
                                                <td class="nav">
                                                    <asp:TextBox ID="txtInspectedBy" runat="server" AutoPostBack="True" 
                                                        CssClass="textbox_small" ontextchanged="txtInspectedBy_TextChanged" Width="100px"></asp:TextBox>
                                                   <%-- <cc1:FilteredTextBoxExtender ID="txtInspectedBy_FilteredTextBoxExtender" 
                                                        runat="server" Enabled="True" TargetControlID="txtInspectedBy" 
                                                        ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                                    </cc1:FilteredTextBoxExtender>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="8">
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
                        <td colspan="8" style="height: 191px">
                            <asp:GridView ID="gvTumblingInspection" runat="server" 
                                AutoGenerateColumns="False" BorderColor="#B1B1B1" EnableModelValidation="True" 
                                onselectedindexchanged="gvTumblingInspection_SelectedIndexChanged"
                                Width="100%" AllowPaging="True" Height="16px" style="margin-bottom: 0px">
                                <AlternatingRowStyle CssClass="AltRow" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" 
                                        ShowSelectButton="True">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" />
                                    </asp:CommandField>--%>
                                    <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                                    <asp:BoundField DataField="JarNo" HeaderText="JarNo" />
                                    <asp:BoundField DataField="SampleNo" HeaderText="SampleNo">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                        HeaderText="Date">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Time" HeaderText="Time">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Day" HeaderText="Day">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Power" HeaderText="Power">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Duration" HeaderText="Duration" />
                                    <asp:BoundField DataField="Status" HeaderText="Status">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="InspectedBy" HeaderText="InspectedBy">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle CssClass="footer" />
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

