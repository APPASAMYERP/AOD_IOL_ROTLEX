<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InspectionDocument.aspx.cs" Inherits="InspectionDocument" Title="Inspection Document" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
Inspection Document</td>
</tr>
<tr>
<td align="left" style="padding-top: 3px">

<table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" >&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" >
                <asp:Label ID="lblLotNo" runat="server" Text="LotNo "></asp:Label>
                            <asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" 
                                BorderStyle="Solid" ontextchanged="TextBox1_TextChanged" Width="100px" 
                                MaxLength="8" BorderWidth="1px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtLotNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtLotNo" 
                                ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                            </cc1:FilteredTextBoxExtender>
                <asp:ImageButton ID="btnChart" runat="server" ImageUrl="~/images/btn_chart_icon.png" 
                    onclick="btnChart_Click" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" >
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="Model" HeaderText="Model" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="StartNo" HeaderText="Serial From" />
                        <asp:BoundField DataField="EndNo" HeaderText="Serial To" />
                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                        <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" >
                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                    onclick="btnSave_Click" Visible="False" />
                <asp:ImageButton ID="btnUpdate" runat="server" 
                    ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" 
                    Visible="False" />
                <asp:ImageButton ID="btnClear" runat="server" 
                    ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" 
                    Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top: 3px">
                                
                                 <table class="nav">
        <tr>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
&nbsp;
                </td>
        </tr>
        <tr>
            <td>
            <asp:Button ID="btnPopup" runat="server" Text="Button" Style="display: none" />

                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup">
                    <table class="style5">
                        <tr>
                            <td align="left">
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server" CellPadding="1" 
                                    CellSpacing="15" RepeatColumns="20" RepeatDirection="Horizontal" 
                                    Width="400px">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/btn_Add.png" 
                                    onclick="btnAdd_Click" />
                                <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/btn_close.png" 
                                    onclick="btnClose_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
                <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" runat="server" 
                    DynamicServicePath="" Enabled="True" PopupControlID="panel1" 
                    TargetControlID="btnPopup" DropShadow="true" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
    </table>
                                
                            </td>
                        </tr>
                    </table>

</td>
</tr>
</table>


  
</asp:Content>

