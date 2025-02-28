<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MI_FQIRejectionReport.aspx.cs" Inherits="MI_FQIRejectionReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table width="100%" style="height: 101px">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                Report</td>
        </tr>
        <tr>
            <td style="padding-top: 3px">
                <table class="con_table" width="100%">                 
                    <tr>
                        <td align="center">
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
                        <td align="center">
                            <asp:ImageButton ID="txtGenerate" runat="server" 
                                ImageUrl="~/images/btn_Generate.png" onclick="txtGenerate_Click" />         
                            <asp:ImageButton ID="txtclear" runat="server" ImageUrl="~/images/btn_clear.png" 
                                style="margin-left: 0px" onclick="txtclear_Click" />
                        </td>  
                    </tr>  
                </table>
                <div class="con_table">       
                    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </cc1:ToolkitScriptManager>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="777px" 
                         Font-Names="Verdana" Font-Size="8pt" Height="400px">                   
                    </rsweb:ReportViewer>                                           
                </div>             
            </td>
        </tr>
    </table>
</asp:Content>