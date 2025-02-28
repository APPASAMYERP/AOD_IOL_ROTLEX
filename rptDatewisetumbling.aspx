<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptDatewisetumbling.aspx.cs" Inherits="rptDatewisetumbling" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
    <link href="CSS/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p style="width: 910px">
        <table class="nav">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style1">
                    <asp:Label ID="Label1" runat="server" CssClass="textlbl" 
                        Text="TUMBLING REPORTS"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="textlbl" align="center">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                         <Triggers>
                                         <asp:PostBackTrigger ControlID ="btnGenerate" />
                                         </Triggers>
                                             <ContentTemplate>
                                                  Date From:
                                                 <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"></asp:TextBox>
                    &nbsp;
                    <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" 
                 runat="server" Enabled="True" TargetControlID="txtDate" 
                 ValidChars="/-0123456789">
             </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDate" Format="MM/dd/yyyy">
                    </cc1:CalendarExtender>
                                               
                                                  Date To:&nbsp;&nbsp;
                                                 <asp:TextBox ID="txtDate1" runat="server" CssClass="textbox"></asp:TextBox>
                                                  &nbsp;&nbsp;
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                 runat="server" Enabled="True" TargetControlID="txtDate" 
                 ValidChars="/-0123456789">
             </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                        Enabled="True" TargetControlID="txtDate1" Format="MM/dd/yyyy">
                    </cc1:CalendarExtender>
                                                  <asp:ImageButton ID="btnGenerate" runat="server" 
                                                     ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" 
                                                     Visible="False" />
                                                 <asp:ImageButton ID="btnHome" runat="server" BorderColor="#990000" 
                                                     onclick="btnHome_Click" ImageUrl="~/images/btn_home_icon.png" 
                                                      Width="26px" />
                                                 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </cc1:ToolkitScriptManager>
                                             </ContentTemplate>
                                         </asp:UpdatePanel>
                                         
                                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLenspreptumb" runat="server" CssClass="textlbl" 
                        Text="LensPreparationTumbling" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvLenPrepTumb" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                            <asp:BoundField DataField="Power" HeaderText="Power" />
                            <asp:BoundField DataField="Qty" HeaderText="Qty" />
                            
                         </Columns>
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMIFqiLens" runat="server" CssClass="textlbl" 
                        Text="MicroscopicInspectionforCleanedLens" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvMi4lens" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                             <asp:BoundField DataField="Power" HeaderText="Pwr" />
                            <asp:BoundField DataField="AccQty" HeaderText="AccQty" />
                            <asp:BoundField DataField="RejQty" HeaderText="RejQty" />
                            <asp:BoundField DataField="DOTS" HeaderText="DOTS" />
                            <asp:BoundField DataField="ISLANDS" HeaderText="ISLANDS" />
                            <asp:BoundField DataField="LB" HeaderText="LB" />
                            <asp:BoundField DataField="SCR" HeaderText="SCR" />
                            <asp:BoundField DataField="PIMP" HeaderText="PIMP" />
                            <asp:BoundField DataField="HeatProb" HeaderText="HeatProb" />
                                                     
                        </Columns>
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            
           
       
        </table>
        <br />
    </p>
    </form>
</body>
</html>
