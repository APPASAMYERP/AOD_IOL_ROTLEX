<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PowerWiseReport.aspx.cs" Inherits="PowerWiseReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="nav" width="100%">
    <tr align="center">
         <td align="left" 
                style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                Power Wise Packing Report</td>
    </tr>
    <%--<tr>
        <td class="style6">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
    </tr>--%>
   <tr>
            <td style="padding-top: 3px">
                                         <table class="con_table" width="100%">
    <tr>
        <td class="textlbl">
            TumblingNo</td>
        <td class="style6">
            <%--<asp:DropDownList ID="drptumbNo" runat="server" AutoPostBack="true" 
                AppendDataBoundItems="true" CssClass="dropdown" 
                onselectedindexchanged="drptumbNo_SelectedIndexChanged">
                <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList>--%>
            <cc1:ComboBox ID="drptumbNo" runat="server" AutoPostBack="true"
                 AppendDataBoundItems="true" Width="125px"                                  
                 AutoCompleteMode="Suggest" OnSelectedIndexChanged="drptumbNo_SelectedIndexChanged">
            <asp:ListItem>--Select--</asp:ListItem>
            </cc1:ComboBox>
        </td>
        <td class="textlbl">
            Power</td>
        <td class="style6">
            <asp:DropDownList ID="drpPower" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="dropdown">
                <asp:ListItem>--Select--</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="textlbl">
            &nbsp;</td>        
        <td class="textlbl">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
    </tr>
    <tr align="center">
        <td class="style6" colspan="4">
            <asp:ImageButton ID="btnGenerate" runat="server" 
                ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" />
        </td>
    </tr>
    <tr>
        <td class="textlbl">
            &nbsp;</td>
        <td class="style6">
            <cc1:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
            </cc1:toolkitscriptmanager>
        </td>
        <td class="textlbl">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="4">
            <rsweb:reportviewer ID="ReportViewer1" runat="server" 
                Width="100%" Font-Names="Verdana" Font-Size="8pt" 
                InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
                WaitMessageFont-Size="14pt">
                <LocalReport ReportPath="PowerWiseReport.rdlc">
                </LocalReport>
            </rsweb:reportviewer>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            &nbsp;</td>
    </tr>
    </table>
    </td>
    </tr>
</table>
</asp:Content>
