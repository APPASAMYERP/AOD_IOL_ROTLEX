<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Debug="true" AutoEventWireup="true" CodeFile="FQI CleanedReport.aspx.cs" Inherits="FQI_CleanedReport" Title="FQI Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
     <table width="100%" style="height: 101px">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                FQI Cleaned Report</td>
        </tr>
        <tr>
            <td style="padding-top: 3px">
                <table class="con_table" width="100%">
                <tr><td align="center">
                    <asp:Label ID="Label1" runat="server" Text="Lotno"></asp:Label>
                    <cc1:ComboBox ID="drpLotNo" runat="server" AutoPostBack="true"
                                 AppendDataBoundItems="true" Width="111px"                                  
                                 AutoCompleteMode="Suggest">
                            <asp:ListItem>--Select--</asp:ListItem>
                            </cc1:ComboBox>  
                    
                    </td>
                    </tr>
                   <%-- <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" CssClass="textlbl" 
                                Text="Start&nbsp; Date :"></asp:Label>
                        </td>
                        <td>
        <asp:TextBox ID="txtDate1" runat="server" CssClass="textbox"></asp:TextBox>
        <cc1:CalendarExtender ID="txtcal" runat="server" Enabled="true" Format="MM/dd/yyyy"
                               TargetControlID="txtDate1">
        </cc1:CalendarExtender>
        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="textlbl" Text="End Date :"></asp:Label>
                        </td>
                        <td>
        <asp:TextBox ID="txtDate2" runat="server" CssClass="textbox" ></asp:TextBox>
        <cc1:CalendarExtender ID="txtcal2" runat="server" Enabled="true" Format="MM/dd/yyyy"
                              TargetControlID="txtDate2">
        </cc1:CalendarExtender>
        </td>          
        </tr>--%>
        <tr>
          <%-- <td> <asp:Label ID="label4" runat="server" CssClass="textlbl" Text="Model"></asp:Label></td>
            <td><asp:DropDownList ID="ddlmodel" runat="server" AppendDataBoundItems="true" 
                    AutoPostBack="True" CssClass="dropdown" onselectedindexchanged="ddlmodel_SelectedIndexChanged">
            <asp:ListItem Value="Select Model">Select Model</asp:ListItem>
            </asp:DropDownList></td>
           <td><asp:Label ID="label5" runat="server" CssClass="textlbl" Text="Power"></asp:Label></td>
           <td><asp:DropDownList ID="ddlpower" runat="server" CssClass="dropdown" AppendDataBoundItems="true">
                   <asp:ListItem Value="Select Power">Select Power</asp:ListItem>
               </asp:DropDownList>
           </td>--%>
           <td align="center">
                <asp:ImageButton ID="txtGenerate" runat="server" 
                    ImageUrl="~/images/btn_Generate.png" onclick="txtGenerate_Click" />
             
              <asp:ImageButton ID="txtclear" runat="server" ImageUrl="~/images/btn_clear.png" 
                      style="margin-left: 0px" onclick="txtclear_Click" />
              </td>  
        </tr>      
      </table> 
      </td> 
      </tr>
      </table>      
           <div class="con_table">
                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="777px" 
                                Font-Names="Verdana" Font-Size="8pt" Height="400px">
                                <LocalReport ReportPath="FQI Report.rdlc">
                                    <DataSources>
                                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" 
                                            Name="PHOBICDataSet_MIinFQI" />
                                    </DataSources>
                                </LocalReport>
                            </rsweb:ReportViewer>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                    SelectMethod="GetData" 
                    TypeName="DataSet1TableAdapters.MillingCleanedLensTableAdapter">
                </asp:ObjectDataSource>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                SelectMethod="GetData" 
                                TypeName="PHOBICDataSetTableAdapters.MIinFQITableAdapter">
                            </asp:ObjectDataSource>                            
   </div>   
</asp:Content>

