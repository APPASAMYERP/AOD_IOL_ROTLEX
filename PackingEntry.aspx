<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PackingEntry.aspx.cs" Inherits="PackingEntry" Title="Untitled Page" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnSave"/> 
   <asp:PostBackTrigger ControlID = "btnSearch"/> 
   </Triggers>
   <ContentTemplate>
<table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                                Packing Entry</td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top: 3px">
                                
                               <table class="con_table">
        <tr>
            <td colspan="8">
                &nbsp;</td>
        </tr>
        <tr class="textlbl">
            <td>
                Model</td>
            <td>
                <asp:DropDownList ID="ddlModel" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True" CssClass="dropdown_200" 
                    onselectedindexchanged="ddlModel_SelectedIndexChanged" Width="70px">
                </asp:DropDownList>
            </td>
            <td>
                SubModel
            </td>
            <td>
                <asp:DropDownList ID="ddlSubModel" runat="server" AppendDataBoundItems="True" 
                    AutoPostBack="True" CssClass="dropdown_200" 
                    onselectedindexchanged="ddlSubModel_SelectedIndexChanged" Width="100px">
                </asp:DropDownList>
            </td>
            <td>
                Brand</td>
            <td>
                <asp:TextBox ID="txtBrand" runat="server" CssClass="textbox_200" Width="120px" 
                    Enabled="False"></asp:TextBox>
            </td>
            <td>
                Power</td>
            <td>
                <asp:DropDownList ID="ddlPower" runat="server" AppendDataBoundItems="True" 
                    CssClass="dropdown_200" Width="70px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="textlbl">
            <td align="center" colspan="8">
                <asp:ImageButton ID="btnSearch" runat="server" Height="19px" 
                    ImageUrl="~/images/btn_search.png" onclick="btnSearch_Click" 
                    Width="72px" />
            </td>
        </tr>
        <tr>
            <td colspan="8" align="center">
                <asp:GridView ID="gvPackingEntry" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="Model" HeaderText="Model" />
                        <asp:BoundField DataField="SubModel" HeaderText="SubModel" />
                        <asp:BoundField DataField="Brand" HeaderText="Brand" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="SerialFrom" HeaderText="SerialFrom" />
                        <asp:BoundField DataField="SerialTo" HeaderText="SerialTo" />
                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                        <asp:BoundField DataField="RemainingQty" HeaderText="RemainingQty" />
                        <asp:BoundField DataField="SterileBatchNo" HeaderText="SterileBNo" />
                        <asp:BoundField DataField="ManufactureDate" DataFormatString="{0:d}" 
                            HeaderText="M.Date" />
                        <asp:BoundField DataField="ExpiryDate" DataFormatString="{0:d}" 
                            HeaderText="Exp.Date" />
                        <asp:TemplateField HeaderText="Id" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
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
            <td class="textlbl">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="textlbl">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="textlbl">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td class="textlbl">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="textlbl">
                <asp:Label ID="Label2" runat="server" Text="Available Qty" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAvailableQty" runat="server" CssClass="textbox_200" 
                    Visible="False" Width="80px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtAvailableQty_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtAvailableQty">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="textlbl">
                <asp:Label ID="Label3" runat="server" Text="Required Qty" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRequiredQty" runat="server" CssClass="textbox_200" 
                    Visible="False" Width="80px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtRequiredQty_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" 
                    TargetControlID="txtRequiredQty">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="textlbl">
                <asp:Label ID="Label4" runat="server" Text="BPLNO" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBPLNO" runat="server" CssClass="textbox_200" 
                    Visible="False" Width="120px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtBPLNO_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtBPLNO">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td class="textlbl">
                <asp:Label ID="Label5" runat="server" Text="Date" Visible="False"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox_200" Visible="False" 
                    Width="120px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td align="center" class="textlbl" colspan="8">
                <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                    onclick="btnSave_Click" Visible="False" />
            </td>
        </tr>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </table>
                                
                            </td>
                        </tr>
                    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

