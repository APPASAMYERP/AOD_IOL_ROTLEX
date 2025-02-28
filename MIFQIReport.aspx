<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MIFQIReport.aspx.cs" Inherits="FQIMiReort" Title="MI Cleaned Report
" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
    <table width="100%" class="nav">
    <tr>        
        <td class="content_title" colspan="5" style="background-color: #00207D; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
            &nbsp;FQI&nbsp; Inspection Report</td>
    </tr>    
    <tr>
        <td colspan="5">
            <table width="100%" class="con_table">
                <tr>
                    <td align="center" colspan="5">
                        <asp:Label ID="lblLotNo" runat="server" CssClass="textlbl" Text="LotNo"></asp:Label>                        
                        <%--<asp:DropDownList ID="drpLotNo" runat="server" CssClass="dropdown">
                        <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>--%>
                        <cc1:ComboBox ID="drpLotNo" runat="server" AutoPostBack="true"
                                 AppendDataBoundItems="true" Width="111px"                                  
                                 AutoCompleteMode="Suggest">
                        <asp:ListItem>--Select--</asp:ListItem>
                        </cc1:ComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <asp:ImageButton ID="txtGenerate" runat="server" 
                             ImageUrl="~/images/btn_Generate.png" onclick="txtGenerate_Click" />         
                        <asp:ImageButton ID="txtclear" runat="server" ImageUrl="~/images/btn_clear.png" 
                             style="margin-left: 0px" onclick="txtclear_Click" />
                    </td>  
                </tr>  
        <%--<td class="textlbl">
            Start&nbsp; Date &nbsp;</td>
        <td class="style6">
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtDate" 
                ValidChars="0123456789/-">
            </cc1:FilteredTextBoxExtender>
        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="txtDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        </td>
         <td class="textlbl">
            End Date&nbsp;</td>
        <td class="style6">
        <asp:TextBox ID="txtDate1" runat="server"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtDate1_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtDate1" 
                ValidChars="/-0123456789">
            </cc1:FilteredTextBoxExtender>
        <cc1:CalendarExtender ID="txtDate1_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="txtDate1" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        </td>
        <td class="style6">
            <asp:ImageButton ID="btnGenerate" runat="server" 
                ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" />
        </td>--%>     
    
                <tr>
                    <td colspan="5">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="400px" 
                                Width="100%">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;</td>
                </tr>
            </table>
        </td>
     </tr>
</table>
</asp:Content>

