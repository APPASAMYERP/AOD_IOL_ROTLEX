<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MillingReport.aspx.cs" Inherits="MillingReport" Title="Milling Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" id="table_left">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                Milling -Shift Report</td>
        </tr>
        <tr>
            <td>
                                         <table class="con_table" width="100%">
                                             <tr>
                                                 <td>
                                                     <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Date :"></asp:Label>
                                                 </td>
                                                 <td>
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Width="125px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDate">
                </cc1:CalendarExtender>
                                                 </td>
                                                 <td>
                                                     <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="Shift :"></asp:Label>
                                                 </td>
                                                 <td>
                <asp:DropDownList ID="ddlShift" runat="server" CssClass="textbox" Height="22px" Width="125px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>II</asp:ListItem>
                </asp:DropDownList>
                                                 </td>
                                                 <td>
                                                     <asp:Label ID="Label3" runat="server" CssClass="textlbl" Text="Supervisor Name"></asp:Label>
                                                 </td>
                                                 <td>
                <asp:TextBox ID="txtSupervisorName" runat="server" CssClass="textbox" Width="125px"></asp:TextBox>
                                                 </td>
                                                 <td>
                <asp:ImageButton ID="btnGenerate" runat="server" 
                    ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" />
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td colspan="7">
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

