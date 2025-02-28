
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Datewiseproductionrpt.aspx.cs" Inherits="Datewiseproductionrpt" Title="Untitled Page" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="nav" width="100%">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 8px;" 
                align="left">
                Datewise Production</td>
        </tr>
        <tr>
            <td style="padding-top: 3px">
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Start Date : " 
                                Width="60px" Height="16px"></asp:Label>
                        </td>
                        <td>
        <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" 
                 runat="server" Enabled="True" TargetControlID="txtDate" 
                 ValidChars="/-0123456789">
             </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="End Date :" 
                                Width="60px"></asp:Label>
                        </td>
                        <td>
        <asp:TextBox ID="txtDate1" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtDate1_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" TargetControlID="txtDate1" 
                        ValidChars="/-0123456789">
                    </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtDate1_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDate1" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="5">
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="750px">
                </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
</asp:Content>

