<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PPStatisticalReport.aspx.cs" Inherits="PPStatisticalReport" Title="Tumbling Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="margin-left: -5px; margin-top: -1px;">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 12pt; font-weight: bold; color: #FFFFFF; padding: 5px; text-align:center;">
                Production Planning Report for Tumbling
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
                    Height="474px">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
</asp:Content>

