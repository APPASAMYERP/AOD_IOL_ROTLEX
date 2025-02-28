<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CleanedLenReport.aspx.cs" Inherits="CleanedLenReport" Title="MI Cleaned Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                Cleaned Lens Report</td>
        </tr>
        <tr>
            <td style="padding-top: 3px">
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" 
                                Text="Start&nbsp; Date :"></asp:Label>
                        </td>
                        <td>
        <asp:TextBox ID="txtDate1" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtDate1_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtDate1" 
                    ValidChars="01234568789/-">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtDate1_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDate1" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="End Date :"></asp:Label>
                        </td>
                        <td>
        <asp:TextBox ID="txtDate2" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtDate2_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtDate2" 
                    ValidChars="0123456789/-">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtDate2_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDate2" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                        </td>
                        <td>
                <asp:ImageButton ID="txtGenerate" runat="server" 
                    ImageUrl="~/images/btn_Generate.png" onclick="txtGenerate_Click1" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                <rsweb:ReportViewer ID="rvCleanedLens" runat="server" Width="100%">
                </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
</asp:Content>

