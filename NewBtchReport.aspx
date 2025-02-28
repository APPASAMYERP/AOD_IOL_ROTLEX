<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="NewBtchReport.aspx.cs" Inherits="NewBtchReport" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold;color: #FFFFFF; padding: 8px;" 
                align="left">
                Batch Allot Report</td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td style="height: 31px">
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Start Date : "></asp:Label>
                        </td>
                        <td style="height: 31px">
        <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" ontextchanged="txtDate_TextChanged"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" 
                 runat="server" Enabled="True" TargetControlID="txtDate" 
                 ValidChars="/-0123456789">
             </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDate" Format="yyyy-MM-dd">
                    </cc1:CalendarExtender>
                        </td>
                        <td style="height: 31px">
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="End Date :"></asp:Label>
                        </td>
                        <td style="height: 31px">
        <asp:TextBox ID="txtDate1" runat="server" CssClass="textbox" ontextchanged="txtDate1_TextChanged"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtDate1_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" TargetControlID="txtDate1" 
                        ValidChars="/-0123456789">
                    </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtDate1_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDate1" Format="yyyy-MM-dd">
                    </cc1:CalendarExtender>
                        </td>
                        <td style="height: 31px">
                <asp:ImageButton ID="btnGenerate" runat="server" 
                    ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="750px" Height="426px">
                </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
</asp:Content>

