<%@ Page Title="Power Inspection During Packing" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PowerInspectionDuringPacking.aspx.cs" Inherits="PowerInspectionDuringPacking" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                <strong>Sample Power Inspection During Packing</strong></td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                <asp:Label ID="lblTumblingLotNo" runat="server" Text="TumblingLotNo" 
                    CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNo1" runat="server" style="margin-bottom: 0px" 
                ontextchanged="txtTmbLotNo1_TextChanged" MaxLength="8" AutoPostBack="True" 
                    CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTmbLotNo1_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtTmbLotNo1" 
                    ValidChars="t1234567890T">
                </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                <asp:Label ID="lblSample1" runat="server" Text="Sample1" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNo1Smp11" runat="server" CssClass="textbox" 
                    MaxLength="6" AutoPostBack="True" ontextchanged="txtTmbLotNo1Smp11_TextChanged" 
               ></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTmbLotNo1Smp11_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtTmbLotNo1Smp11" 
                    ValidChars=".0123456789">
                </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="lblPower" runat="server" Text="Power" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:DropDownList ID="ddlPower" runat="server" CssClass="dropdown" 
                                AppendDataBoundItems="True">
                </asp:DropDownList>
                        </td>
                        <td>
                <asp:Label ID="lblSample2" runat="server" Text="Sample2" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNo1Smp21" runat="server" CssClass="textbox" 
                    MaxLength="6" AutoPostBack="True" 
                    ontextchanged="txtTmbLotNo1Smp21_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTmbLotNo1Smp21_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtTmbLotNo1Smp21" 
                    ValidChars="0123456789.">
                </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="lblPower0" runat="server" Text="Date" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNo1Dt1" runat="server" CssClass="textbox" 
                ></asp:TextBox>
                        </td>
                        <td>
                <asp:Label ID="lblSample3" runat="server" Text="Sample3" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmpLotNo1Smp31" runat="server" CssClass="textbox" 
                    MaxLength="6" AutoPostBack="True" 
                    ontextchanged="txtTmpLotNo1Smp31_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTmpLotNo1Smp31_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtTmpLotNo1Smp31" 
                    ValidChars="0123456789.">
                </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="lblInspectedBy" runat="server" Text="InspectedBy" 
                    CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNo1InpBy1" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtTmbLotNo1InpBy1_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTmbLotNo1InpBy1_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtTmbLotNo1InpBy1" 
                    ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                <asp:Label ID="lblSample4" runat="server" Text="Sample4" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNoSmp41" runat="server" CssClass="textbox" 
                    MaxLength="6" AutoPostBack="True" 
                    ontextchanged="txtTmbLotNoSmp41_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTmbLotNoSmp41_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtTmbLotNoSmp41" 
                    ValidChars="0123456789.">
                </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td>
                <asp:Label ID="lblRemarks" runat="server" Text="Remarks" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNo1Rmks1" runat="server" CssClass="textbox" 
                    AutoPostBack="True" ontextchanged="txtTmbLotNo1Rmks1_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTmbLotNo1Rmks1_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterMode="InvalidChars" 
                    InvalidChars="1234567890" TargetControlID="txtTmbLotNo1Rmks1">
                </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
                <asp:Label ID="lblSample5" runat="server" Text="Sample5" CssClass="textlbl"></asp:Label>
                        </td>
                        <td>
                <asp:TextBox ID="txtTmbLotNoSMP51" runat="server" CssClass="textbox" 
                    MaxLength="6" AutoPostBack="True" 
                    ontextchanged="txtTmbLotNoSMP51_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTmbLotNoSMP51_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtTmbLotNoSMP51" 
                    ValidChars="0123456789.">
                </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <table>
                                <tr>
                                    <td>
                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                    onclick="btnSave_Click" Visible="False" />
                                    </td>
                                    <td>
                <asp:ImageButton ID="btnUpdate" runat="server" 
                    ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" 
                    Visible="False" />
                                    </td>
                                    <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:ImageButton ID="btnClear" runat="server" 
                    ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" 
                    Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    AutoGenerateColumns="False" BorderColor="#B1B1B1" 
                    EnableModelValidation="True" Width="100%">
                    <AlternatingRowStyle CssClass="AltRow" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                            SelectImageUrl="~/images/select.PNG" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="TumblingLotNo1" HeaderText="TumblingNo" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling1Power1" HeaderText="Power" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling11Sample1" HeaderText="Sample1" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling21Sample1" HeaderText="Sample2" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling31Sample1" HeaderText="Sample3" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling41Sample1" HeaderText="Sample4" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling21Sample1" HeaderText="Sample5" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling1Remarks1" HeaderText="Remarks" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling1InspectedBy" HeaderText="InspectedBy" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Tumbling1Date1" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" >
                        <HeaderStyle CssClass="headeritem" />
                        <ItemStyle CssClass="itemstyle" />
                        </asp:BoundField>
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
</asp:Content>

