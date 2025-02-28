<%@ Page Title="Label Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LabelDetails.aspx.cs" Inherits="LabelDetails" %>

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
                <strong>Label Details For Packing</strong></td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="LotNo"></asp:Label>
                        </td>
                        <td><asp:TextBox ID="txtLotNos" runat="server" CssClass="textbox" Enabled="true" 
                                Width="150px" AutoPostBack="True" ontextchanged="txtGlassyNo_TextChanged"></asp:TextBox>
                            </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="Model"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModel" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" CssClass="textlbl" Text="TotalQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalQty" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                    <td>
                     <asp:Label ID="Label15" runat="server" CssClass="textlbl" Text="TumblingRefNo"></asp:Label>
                    </td>
                    <td>
                    <asp:TextBox ID="txtTumblingRef" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>                    
                    </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <table cellspacing="0" cellpadding="2" width="100%">
                                <tr>
                                    <td class="nav">
                                        <asp:Label ID="Label5" runat="server" Text="SubModel" CssClass="textlbl" 
                                            Font-Bold="True"></asp:Label>  </td>
                                    <td class="nav">
                                        <asp:Label ID="Label6" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text="BrandName"></asp:Label>
                                    </td>
                                    <td class="nav">
                                    <asp:Label ID="Label7" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text="Power"></asp:Label>
                                        </td>
                                    <td class="nav">
                                        <asp:Label ID="Label8" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text="LotNo"></asp:Label>
                                        </td>
                                    <td class="nav">
                                    <asp:Label ID="Label9" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text="StartNo"></asp:Label>
                                      </td>
                                    <td class="nav">
                                     <asp:Label ID="Label10" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text="EndNo"></asp:Label>
                                        </td>
                                    <td class="nav">
                                    <asp:Label ID="Label11" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text="Qty"></asp:Label>
                                        </td>
                                    <td class="nav">
                                      <asp:Label ID="Label12" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text=" Remarks"></asp:Label>
                                       </td>
                                    <td class="nav">
                                     <asp:Label ID="Label13" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text="Date"></asp:Label>
                                        </td>
                                    <td class="nav">
                                      <asp:Label ID="Label14" runat="server" CssClass="textlbl" Font-Bold="True" 
                                            Text="Packed By"></asp:Label>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="nav" >
                                        <asp:DropDownList ID="ddlSubModel" runat="server" AppendDataBoundItems="True" 
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlSubModel_SelectedIndexChanged" CssClass="textbox" 
                                            Height="22px" Width="80px">
                                            <asp:ListItem Selected="True" Value="0" Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtBrandName" runat="server" Enabled="False" Width="75px" 
                                            CssClass="textbox" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td class="nav">
                                   <%--<asp:TextBox ID="txtPower" runat="server" Enabled="False" Width="75px" 
                                            CssClass="textbox" AutoPostBack="True"></asp:TextBox>--%>
                                   <asp:DropDownList ID="drpPower" runat="server" AutoPostBack="true" 
                                            AppendDataBoundItems="true" Width="90px" CssClass="dropdown" 
                                            onselectedindexchanged="drpPower_SelectedIndexChanged">
                                   <asp:ListItem>--Select--</asp:ListItem>
                                   </asp:DropDownList>
                                        
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" MaxLength="10" 
                                             Width="75px" CssClass="textbox" ontextchanged="txtLotNo_TextChanged"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" TargetControlID="txtLotNo">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtStartNo" runat="server" Width="40px" CssClass="textbox"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtStartNo_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtStartNo">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtEndNo" runat="server" AutoPostBack="True" 
                                            ontextchanged="txtEndNo_TextChanged" Width="40px" CssClass="textbox"></asp:TextBox>
                                        <%--<cc1:FilteredTextBoxExtender ID="txtEndNo_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtEndNo">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtQty" runat="server" AutoPostBack="True" 
                                            ontextchanged="txtQty_TextChanged" Width="40px" CssClass="textbox" 
                                            Enabled="False"></asp:TextBox>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" 
                                            ontextchanged="txtRemarks_TextChanged" Width="75px" CssClass="textbox"></asp:TextBox>
                                       <%-- <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterMode="InvalidChars" 
                                            InvalidChars="1234567890" TargetControlID="txtRemarks">
                                        </cc1:FilteredTextBoxExtender>--%>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtDate" runat="server" Width="75px" CssClass="textbox"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtPackedBy" runat="server" AutoPostBack="True" 
                                            ontextchanged="txtPackedBy_TextChanged" Width="75px" CssClass="textbox"></asp:TextBox>
                                        <%--<cc1:FilteredTextBoxExtender ID="txtPackedBy_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtPackedBy" 
                                            ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                                        </cc1:FilteredTextBoxExtender>--%>
                                        </td>
                                </tr>
                            </table>
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
                                            ImageUrl="~/images/btn_clear.png" Visible="False" 
                                            onclick="btnClear_Click" />
                                    </td>
                                    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                    </cc1:ToolkitScriptManager>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" align="center">
                            <asp:GridView ID="gvLabelDetails" runat="server" AutoGenerateColumns="False" 
                                BorderColor="#B1B1B1" BorderStyle="Solid" BorderWidth="1px" 
                                EnableModelValidation="True" 
                                onselectedindexchanged="gvLabelDetails_SelectedIndexChanged" Width="100%">
                                <AlternatingRowStyle CssClass="AltRow" />
                                <Columns>
                                    <%--<asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" 
                                        ShowSelectButton="True">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" />
                                    </asp:CommandField>   --%>
                                    <asp:BoundField DataField="GlassyNo" HeaderText="GlassyNo">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>                                 
                                    <asp:BoundField DataField="Model" HeaderText="Model">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SubModel" HeaderText="SubModel">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BrandName" HeaderText="BrandName">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalQty" HeaderText="TotalQty">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Power" HeaderText="Power">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LotNo" HeaderText="LotNo">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StartNo" HeaderText="StartNo">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EndNo" HeaderText="EndNo">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qty" HeaderText="Qty">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date" DataFormatString="{0:dd/MM/yyyy}" 
                                        HeaderText="Date">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PackedBy" HeaderText="PackedBy">
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                        <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False">
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

