<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TumblingRunningReport.aspx.cs" Inherits="TumblingRunningReport" Title="Untitled Page" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td align="left" class="textlbl">
                Tumbling Running Report
            </td>
        </tr>
        <tr>
            <td align="center" class="textlbl">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>

