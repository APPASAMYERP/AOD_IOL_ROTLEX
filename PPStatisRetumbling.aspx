<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="PPStatisRetumbling.aspx.cs" Inherits="PPStatisRetumbling" Title="ReTumbling Report"%>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="margin-left: -5px; margin-top: -1px;">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 12pt; font-weight: bold; color: #FFFFFF; padding: 5px; text-align:center;">
                Production Planning Report for Re-Tumbling
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
                    Height="471px" ShowDocumentMapButton="False" ShowFindControls="False" 
                    ShowPrintButton="False" ShowPromptAreaButton="False" 
                    ShowZoomControl="False">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>
