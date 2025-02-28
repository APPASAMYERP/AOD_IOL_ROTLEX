<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MillingShiftReport.aspx.cs" Inherits="MillingShiftReport" Title="Milling Shift Report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="nav">
        <tr>
            <td align="center" colspan="7" >
                Milling -Shift Report</td>
                                 </tr>
                                 <%--<tr>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                 </tr>--%>
                                 <tr>
                                     <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                         DATE:</td>
            <td>
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDate">
                </cc1:CalendarExtender>
            </td>
            <td>
                Shift</td>
                                     <td>
                                         <asp:DropDownList ID="ddlShift" runat="server">
                                             <asp:ListItem>Select</asp:ListItem>
                                             <asp:ListItem>I</asp:ListItem>
                                             <asp:ListItem>II</asp:ListItem>
                                         </asp:DropDownList>
                                     </td>
                                     <td>
                                         Supervisor Name</td>
            <td>
                <asp:TextBox ID="txtSupervisorName" runat="server"></asp:TextBox>
                <asp:ImageButton ID="btnGenerate" runat="server" 
                    ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="7">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
                    Height="484px">
                </rsweb:ReportViewer>
            </td>
        </tr>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
    </table>
</asp:Content>

