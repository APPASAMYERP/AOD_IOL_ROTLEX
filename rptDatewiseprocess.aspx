<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rptDatewiseprocess.aspx.cs" Inherits="rptDatewiseprocess" Title="Date wise Process Reports" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DateWise Report</title>
    <script type="text/javascript">
    
      function pageLoad() {
      
      }
    
    </script>
    <link href="CSS/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-family: Arial;
            font-size: 9pt;
            color: #313131;
            padding-left: 5px;
            height: 27px;
        }
    </style>
</head>
<body class="textlbl">
    <form id="form1" runat="server">
    <div>
         <table align="center" class="nav">
        <tr>
            <td align="center">
                <b>Production Report</b></td>
                                 </tr>
                                 <tr>
                                     <td align="center">
                                         
                                         

                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                         <Triggers>
                                         <asp:PostBackTrigger ControlID ="btnGenerate" />
                                         </Triggers>
                                             <ContentTemplate>
                                                  DateFrom:
                                                 <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" 
                 runat="server" Enabled="True" TargetControlID="txtDate" 
                 ValidChars="/-0123456789">
             </cc1:FilteredTextBoxExtender>
                    <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                        Enabled="True" TargetControlID="txtDate" Format="MM/dd/yyyy">
                    </cc1:CalendarExtender>
                                               
                                                  DateTo:
                                                 <asp:TextBox ID="txtDate1" runat="server" CssClass="textbox"></asp:TextBox>
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
                                     <td class="textlbl" align="left">
                                         </td>
        </tr>
                                 <tr>
                                     <td class="textlbl" align="left">
                                         <asp:Label ID="lblBatchAllot" runat="server" CssClass="textlbl" 
                                             Text="Batch Allot" Visible="False"></asp:Label>
</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvBatchAllot" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="AllotedQuantity" HeaderText="Qty" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td class="style1" align="left">
                <asp:Label ID="lblBlocking" runat="server" CssClass="textlbl" 
                    Text="Blocking-Ist Cut" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvBlock" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
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
                </td>
        </tr>
        <tr>
            <td class="style6" align="left">
                
                <asp:Label ID="lblLatheCut" runat="server" CssClass="textlbl" 
                    Text="Lathe  Ist Cut" Visible="False"></asp:Label>
</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvLatheCut" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
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
                </td>
        </tr>
                
        <tr>
            <td>
                <asp:Label ID="lblMicroscopicInspectionCollet" runat="server" CssClass="textlbl" 
                    Text="MicroscopicInspectionWithCollet" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMicroScopicWithCollet" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
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
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDeBlocking" runat="server" CssClass="textlbl" 
                    Text="DeBlocking Ist Cut" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvDeBlock" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
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
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLotResult" runat="server" CssClass="textlbl" 
                    Text="Lot Result-Ist Cut" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvLotResult" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" />
                        <asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty" />
                      
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblBlocking2" runat="server" CssClass="textlbl" 
                    Text="Blocking 2nd Cut" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvBlock2cut" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
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
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLatheCut2" runat="server" CssClass="textlbl" 
                    Text="Lathe IInd Cut" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvLathe2ndCut" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
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
                </td>
        </tr>
     
        <tr>
            <td>
                <asp:Label ID="lblMicroscopicInspectionCollet2ndCut" runat="server" CssClass="textlbl" 
                    Text="MicroscopicInspectionWithCollet2ndCut" Visible="False"></asp:Label>
            </td>
        </tr>
     <tr>
            <td>
                <asp:GridView ID="gvMicroScopicWithCollet2ndCut" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" />
                        <asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty" />
                      
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMilling" runat="server" CssClass="textlbl" 
                    Text="Milling" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMilling" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" />
                        <asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty" />
                       
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
       
              <tr>
            <td>
                <asp:Label ID="lblDeBlocking2" runat="server" CssClass="textlbl" 
                    Text="DeBlocking IInd Cut" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvDeBlock2" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" />
                        <asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty" />
                        
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblHydBefHyd" runat="server" CssClass="textlbl" 
                    Text="HydrationBefHyd" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvHydBefTumb" runat="server" AutoGenerateColumns="False" 
                    BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                    CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                     <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" />
                        <asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty" />
                        
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMICleanedLens" runat="server" CssClass="textlbl" 
                    Text="MICleanedLens" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMICleanedLens" runat="server" AutoGenerateColumns="False" 
                    BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                    CellPadding="4" CellSpacing="2" ForeColor="Black">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                      <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="InspecQty" HeaderText="InspecQty" />
                        <asp:BoundField DataField="AccQty" HeaderText="AccQty" />
                        <asp:BoundField DataField="RejQty" HeaderText="RejQty" />
                        <asp:BoundField DataField="ESC" HeaderText="ESC" />
                        <asp:BoundField DataField="SCR" HeaderText="SCR" />
                        <asp:BoundField DataField="LB" HeaderText="LB" />
                        <asp:BoundField DataField="CHIP" HeaderText="CHIP" />
                        <asp:BoundField DataField="BURR" HeaderText="BURR" />
                        <asp:BoundField DataField="Thick" HeaderText="Thick" />
                        <asp:BoundField DataField="TotalRejQty" HeaderText="TotRejQty" />
                      
                        
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                </td>
        </tr>
    </table><br />
    </div>
    </form>
</body>
</html>
