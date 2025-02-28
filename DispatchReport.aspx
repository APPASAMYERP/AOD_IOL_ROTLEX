<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DispatchReport.aspx.cs" Inherits="DespatchReport" Title="Untitled Page" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="con_table">
        <tr>
            <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
                                Dispatch Report</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                Dc No:&nbsp;
                <asp:TextBox ID="txtDcNo" runat="server" AutoPostBack="True" 
                    ontextchanged="txtDcNo_TextChanged"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtDcNo_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtDcNo">
                </cc1:FilteredTextBoxExtender>
&nbsp;&nbsp;
                <asp:ImageButton ID="btnGenerate" runat="server" 
                    ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="500px" 
                    Width="750px">
                </rsweb:ReportViewer>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

