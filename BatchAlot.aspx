<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BatchAlot.aspx.cs" Inherits="BatchAlot" Title="BATCH ALLOT" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
  

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>--%>
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
                            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                                BATCH ALLOT</td>
                        </tr>
                        <tr>
                            <td align="left">
                                
                                <table width="100%" class="con_table">
        <tr>
            <td class="style28">
                <asp:Label ID="lblLotNo" runat="server" Font-Bold="False" Text="Lot No" 
                    CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLotNo" runat="server" BackColor="White" 
                ontextchanged="txtLotNo_TextChanged" AutoPostBack="True" MaxLength="11" 
                    CssClass="textbox"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                    runat="server" Enabled="True"  ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890" TargetControlID="txtLotNo">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server"  Text="Date" 
                     CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" 
                    TabIndex="1" ontextchanged="txtDate_TextChanged" AutoPostBack="True"></asp:TextBox>
                <%--<cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    TargetControlID="txtDate" Enabled="True" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>--%>
            </td>
        </tr>
        <tr>
            <td class="style28">
                <asp:Label ID="lblShift" runat="server" Font-Bold="False" Text="Shift" 
                    CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlShift" runat="server" CssClass="dropdown" TabIndex="2">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>II</asp:ListItem>
                    <asp:ListItem>III</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblBatchNo" runat="server"  Text="Phobic ID" 
                     CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBatchNo" runat="server" BackColor="White" 
                    CssClass="textbox" 
                    ontextchanged="txtBatchNo_TextChanged" TabIndex="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style28">
                <asp:Label ID="lblModel" runat="server" Font-Bold="False" Text="Model" 
                    CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModelNo" runat="server" AppendDataBoundItems="True" 
                    CssClass="dropdown" TabIndex="4">
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblAllotedQty" runat="server"  Text="Alloted Quantity" 
                             CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAllotedQty" runat="server" BackColor="White" 
                    CssClass="textbox" AutoPostBack="True" MaxLength="2" 
                    ontextchanged="txtAllotedQty_TextChanged" TabIndex="5"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtAllotedQty_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtAllotedQty">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
        </tr>
        <tr>
            <td class="style28">
                <asp:Label ID="lblPower" runat="server"  Text="Power" 
                     CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPower" runat="server" AutoPostBack="True" 
                    CssClass="dropdown" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                    AppendDataBoundItems="True" BackColor="White" TabIndex="6" >
                    <asp:ListItem>Select</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="lblRadius" runat="server"  Text="Radius" 
                     CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRadius" runat="server" Enabled="False" 
                    CssClass="textbox" TabIndex="7"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style28">
                <asp:Label ID="lblWaxId" runat="server"  Text="Optic" 
                     CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtWaxId" runat="server" 
                    CssClass="textbox" MaxLength="6" 
                     TabIndex="8" Enabled="False"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtWaxId_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtWaxId" 
                    ValidChars="1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
            <td>
                <asp:Label ID="lblApprovedBy" runat="server"  Text="Approved By" 
                             CssClass="textlbl"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApprovedBy" runat="server" BackColor="White" 
                    CssClass="textbox" AutoPostBack="True" 
                    ontextchanged="txtApprovedBy_TextChanged" TabIndex="9"></asp:TextBox>
               <%-- <cc1:FilteredTextBoxExtender ID="txtApprovedBy_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtApprovedBy" 
                    ValidChars=" abcdefghijklmnopqrstuvwxyz.ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                </cc1:FilteredTextBoxExtender>--%>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="margin-top: 20px;">
                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                    onclick="btnSave_Click" Visible="False" TabIndex="10" />
                &nbsp;<asp:ImageButton ID="btnUpdate" runat="server" 
                    ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" 
                    Visible="False" TabIndex="11" />
                &nbsp;<asp:ImageButton ID="btnClear" runat="server" 
                    ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click1" 
                    Visible="False" TabIndex="12" />
                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>
            </td>
            
        </tr>
        <tr>
            <td align="center" class="style28" colspan="4">
                <asp:GridView ID="gvBatchAllot" runat="server" AutoGenerateColumns="False" 
                    BorderColor="#B1B1B1" HorizontalAlign="Center"
                    onselectedindexchanged="gvBatchAllot_SelectedIndexChanged" Width="100%" 
                    BorderStyle="Solid" BorderWidth="1px">
                    <FooterStyle CssClass="footer" />
                    <RowStyle CssClass="narmal_row" />
                    <Columns>
                        <asp:CommandField ButtonType="Image" HeaderText="Select" 
                            SelectImageUrl="~/images/select.PNG" 
                            Visible="False">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:CommandField>
                        <asp:BoundField DataField="LotNo" HeaderText="Lot No" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                            DataFormatString="{0:dd/MM/yyyy}">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Shift" HeaderText="Shift" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BatchNo" HeaderText="PhobicID" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AllotedQuantity" HeaderText="Allot.Qty" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Power" HeaderText="Power" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Radius" HeaderText="Radius" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="WaxId" HeaderText="Optic" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ApprovedBy" HeaderText="ApprovedBy" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="pager" />
                    <SelectedRowStyle CssClass="selectedrow" />
                    <HeaderStyle CssClass="grd_Header" />
                    <AlternatingRowStyle CssClass="AltRow" />
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

