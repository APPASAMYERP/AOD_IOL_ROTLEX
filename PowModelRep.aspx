<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PowModelRep.aspx.cs" Inherits="PowModelRep" Title="Power&Model Report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" id="table_left">
    <tr>
        <td align="left" 
                style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold;color: #FFFFFF; padding: 8px;">
               Power-Model Report</td>
    </tr>
    <tr>
        <td>
            <table class="con_table" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="From :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="To :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtToDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnGenerate" runat="server" 
                    ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

