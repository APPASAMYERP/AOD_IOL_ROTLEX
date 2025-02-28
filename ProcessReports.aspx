<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcessReports.aspx.cs" Inherits="ProcessReports" Title="Process Reports" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
    
      function pageLoad() {
      
      }
    
    </script>
    <link href="CSS/css.css" rel="stylesheet" type="text/css" />
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
                                             <span>LotNo:</span>
                                             <span><asp:TextBox ID="txtLotNo" runat="server" AutoPostBack="True" MaxLength="11" 
                                                     ontextchanged="txtLotNo_TextChanged"></asp:TextBox></span>
                                                 <span style="margin-left:5px"><asp:ImageButton ID="btnGenerate" runat="server" 
                                                     ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click" 
                                                     Visible="False" /></span>
                                                 <span><asp:ImageButton ID="btnHome" runat="server" BorderColor="#990000" 
                                                     onclick="btnHome_Click" ImageUrl="~/images/btn_home_icon.png" /></span>
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BatchNo" HeaderText="PhobicID" />
                        <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                        <asp:BoundField DataField="AllotedQuantity" HeaderText="Allot.Qty" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="Radius" HeaderText="Radius" />
                        <asp:BoundField DataField="WaxId" HeaderText="Optic" />
                        <asp:BoundField DataField="ApprovedBy" HeaderText="ApprovedBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
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
            <td class="textlbl" align="left">
                <asp:Label ID="lblBlocking" runat="server" CssClass="textlbl" 
                    Text="Blocking Ist Cut" Visible="False"></asp:Label>
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="Waxtemp" HeaderText="CoolTemp" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Blockedby" HeaderText="BlockedBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="LatheType" HeaderText="LatheType" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="LatheNo" HeaderText="LatheNo" />
                        <asp:BoundField DataField="ToolId" HeaderText="ToolId" />
                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                        <asp:BoundField DataField="EndTime" HeaderText="EndTime" />
                        <asp:BoundField DataField="Duration" HeaderText="Duration" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                        <asp:BoundField DataField="OperatorName" HeaderText="Oper.Name" />
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="MillingLatheNo" HeaderText="MillLatheNo" />
                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                        <asp:BoundField DataField="EndTime" HeaderText="EndTime" />
                        <asp:BoundField DataField="Duration" HeaderText="Duration" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                        <asp:BoundField DataField="OperatorName" HeaderText="Oper.Name" />
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
                    Text="Blocking IInd Cut" Visible="False"></asp:Label>
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="Waxtemp" HeaderText="CoolTemp" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Blockedby" HeaderText="BlockedBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="LatheType" HeaderText="LatheType" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="LatheNo" HeaderText="LatheNo" />
                        <asp:BoundField DataField="ToolId" HeaderText="ToolId" />
                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                        <asp:BoundField DataField="EndTime" HeaderText="EndTime" />
                        <asp:BoundField DataField="Duration" HeaderText="Duration" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                        <asp:BoundField DataField="OperatorName" HeaderText="Oper.Name" />
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="WaxTemp" HeaderText="CoolTemp" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="DeBlockedby" HeaderText="DeBlockedBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
<%--        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMicroscopicInspection" runat="server" CssClass="textlbl" 
                    Text="MicroscopicInspection" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMicroscopic" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Sample1Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="Sample1Status" HeaderText="Sample1Stat." />
                        <asp:BoundField DataField="Sample2Status" HeaderText="Sample2Stat" />
                        <asp:BoundField DataField="Sample3Status" HeaderText="Sample3Stat" />
                        <asp:BoundField DataField="Sample1Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Sample1InspectedBy" HeaderText="Inspec.By" />
                        <asp:BoundField DataField="Sample1Shift" HeaderText="Shift" />
                        <asp:BoundField DataField="RejMTSNo" HeaderText="Rej.MTSNo" />
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
                <asp:Label ID="lblLensMeasurement" runat="server" CssClass="textlbl" 
                    Text="LensMeasurement" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvLensMeasurement" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="SampleNo1Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="SampleNo1Status" HeaderText="SNo1 Stat." />
                        <asp:BoundField DataField="SampleNo2Status" HeaderText="SNo2 Stat." />
                        <asp:BoundField DataField="SampleNo3Status" HeaderText="SNo3 Stat." />
                        <asp:BoundField DataField="SampleNo1LensDiameter" HeaderText="SNo1 Dia" />
                        <asp:BoundField DataField="SampleNo2LensDiameter2" HeaderText="SNo2 Dia." />
                        <asp:BoundField DataField="SampleNo3LensDiameter3" HeaderText="SNo3 Dia" />
                        <asp:BoundField DataField="SampleNo1LensThickness" HeaderText="SNo1 Thick" />
                        <asp:BoundField DataField="SampleNo2LensThickness2" HeaderText="SNo2 Thick" />
                        <asp:BoundField DataField="SampleNo3LensThickness3" HeaderText="SNo3 Thick" />
                        <asp:BoundField DataField="Remarks1" HeaderText="Rmks" />
                        <asp:BoundField DataField="StatusShift" HeaderText="Shft" />
                        <asp:BoundField DataField="Inspectedby1" HeaderText="Inspec.By" />
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="RejMTS" HeaderText="RejMTSNo" />
                        <asp:BoundField DataField="Remarks" HeaderText="Rmrks" />
                        <asp:BoundField DataField="InspectedBy" HeaderText="InspBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shft" />
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="WaxTemp" HeaderText="WaxTemp" />
                        <asp:BoundField DataField="Remarks" HeaderText="Rmrks" />
                        <asp:BoundField DataField="DeBlockedby" HeaderText="DeBlockedBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shft" />
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>--%>
                <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMicroscopicHapThick" runat="server" CssClass="textlbl" 
                    Text="Sample Inspection" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvHaptic" runat="server" AutoGenerateColumns="False" 
                    BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                    CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Sample1Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="Sample1MiStatus" HeaderText="SNo1MiStat" />
                        <asp:BoundField DataField="Sample2MiStatus" HeaderText="SNo2MiStat" />
                        <asp:BoundField DataField="Sample3MiStatus" HeaderText="SNo3MiStat." />
                        <asp:BoundField DataField="Sample1ProfileStatus" HeaderText="SNo1ProfStat" />
                        <asp:BoundField DataField="Sample2ProfileStatus" HeaderText="SNo2profstat" />
                        <asp:BoundField DataField="Sample3ProfileStatus" HeaderText="SNo3profstat" />
                        <asp:BoundField DataField="Sample1Haptic" HeaderText="SNo1Hap" />
                        <asp:BoundField DataField="Sample2Haptic" HeaderText="SNo2Hap" />
                        <asp:BoundField DataField="Sample3Haptic" HeaderText="SNo3Hap" />
                        <asp:BoundField DataField="Sample1Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Sample1InspectedBy" HeaderText="InspectedBy" />
                        <asp:BoundField DataField="Sample1Shift" HeaderText="Shift" />
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
                    Text="MI Cleaned Lens" Visible="False"></asp:Label>
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="InspectedQuantity" HeaderText="InspQty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="AccQty" />
                        <asp:BoundField DataField="RejectedQty" HeaderText="RejQty" />
                        <asp:BoundField DataField="ESC" HeaderText="ESC" />
                        <asp:BoundField DataField="SCR" HeaderText="SCR" />
                        <asp:BoundField DataField="LB" HeaderText="LB" />
                        <asp:BoundField DataField="CHIP" HeaderText="CHIP" />
                        <asp:BoundField DataField="BURR" HeaderText="BURR" />
                        <asp:BoundField DataField="THICK" HeaderText="THICK" />
                        <asp:BoundField DataField="OTHERS" HeaderText="OTHERS" />
                        <asp:BoundField DataField="OFFSET" HeaderText="OFFSET" />
                        <asp:BoundField DataField="CUTTING" HeaderText="CUTTING" />
                        <asp:BoundField DataField="TotalRejQty" HeaderText="TotRejQty" />
                        <asp:BoundField DataField="Inspectedby" HeaderText="InspBy" />
                        <asp:BoundField DataField="Approvedby" HeaderText="ApprBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
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
                <asp:Label ID="lblResolution" runat="server" CssClass="textlbl" 
                    Text="Haptic & Power" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvResolution" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="PowerSample1" HeaderText="PowerSample1" />
                        <asp:BoundField DataField="PowerSample2" HeaderText="PowerSample2" />
                        <asp:BoundField DataField="PowerSample3" HeaderText="PowerSample3" />
                        <asp:BoundField DataField="PowerValue1" HeaderText="PowerValue1" />
                        <asp:BoundField DataField="PowerValue2" HeaderText="PowerValue2" />
                         <asp:BoundField DataField="PowerValue3" HeaderText="PowerValue3" />
                          <asp:BoundField DataField="Haptic1" HeaderText="Haptic1" />
                           <asp:BoundField DataField="Haptic2" HeaderText="Haptic2" />
                            <asp:BoundField DataField="Haptic3" HeaderText="Haptic3" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="InspectedBy" HeaderText="InspectedBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
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
       <%-- <tr>
            <td>
                <asp:Label ID="lblMicroscopicInspectionCollet2ndCut" runat="server" CssClass="textlbl" 
                    Text="Haptic Inspection" Visible="False"></asp:Label>
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="InspectedBy" HeaderText="InspectedBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>--%>
        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLotResult" runat="server" CssClass="textlbl" 
                    Text="Lot Result" Visible="False"></asp:Label>
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="FinishedQuantity" HeaderText="Fin.Qty" />
                        <asp:BoundField DataField="AcceptedQuantity" HeaderText="Acc.Qty" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="RejectedQuantity" HeaderText="Rej.Qty" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="InspectedBy" HeaderText="InspectedBy" />
                        <asp:BoundField DataField="Shift" HeaderText="Shift" />
                    </Columns>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>


<%--        <tr>
            <td>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMicroscopicInspection2" runat="server" CssClass="textlbl" 
                    Text="MicroscopicInspection 2nd cut" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMicroscopic2ndCut" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Sample1Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="Sample1Status" HeaderText="Sample1Stat." />
                        <asp:BoundField DataField="Sample2Status" HeaderText="Sample2Stat" />
                        <asp:BoundField DataField="Sample3Status" HeaderText="Sample3Stat" />
                        <asp:BoundField DataField="Sample1Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Sample1InspectedBy" HeaderText="Inspec.By" />
                        <asp:BoundField DataField="Sample1Shift" HeaderText="Shift" />
                        <asp:BoundField DataField="RejMTSNo" HeaderText="Rej.MTSNo" />
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
                <asp:Label ID="lblPowerInspection" runat="server" CssClass="textlbl" 
                    Text="PowerInspection" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvPowerInspec" runat="server" AutoGenerateColumns="False" 
                    BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                    CellPadding="4" CellSpacing="2" ForeColor="Black">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Sample1Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="PowerStatus1" HeaderText="Stat1" />
                        <asp:BoundField DataField="PowerStatus2" HeaderText="Stat2" />
                        <asp:BoundField DataField="PowerStatus3" HeaderText="Stat3" />
                        <asp:BoundField DataField="BeforeHydSample1" HeaderText="SNo1BefHyd" />
                        <asp:BoundField DataField="BeforeHydSample2" HeaderText="SNo2BefHyd" />
                        <asp:BoundField DataField="BeforeHydSample3" HeaderText="SNo3Befhyd" />
                        <asp:BoundField DataField="AfterHydSample1" HeaderText="SNo1Afthyd" />
                        <asp:BoundField DataField="AfterHydSample2" HeaderText="SNo2AftHyd" />
                        <asp:BoundField DataField="AfterHydSample3" HeaderText="SNo3AftHyd" />
                        <asp:BoundField DataField="Sample1Remarks" HeaderText="Rmks" />
                        <asp:BoundField DataField="Sample1InspectedBy" HeaderText="Inspec." />
                        <asp:BoundField DataField="Sample1Shift" HeaderText="Shft" />
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
                <asp:Label ID="lblMicroscopicInspectionMiling" runat="server" CssClass="textlbl" 
                    Text="MicroscopicInspection-Milling" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMicroscopicMilling" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <FooterStyle BackColor="#CCCCCC" />
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Sample1Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="BlockingType" HeaderText="Blocking" />
                        <asp:BoundField DataField="Sample1Status" HeaderText="Sample1Stat." />
                        <asp:BoundField DataField="Sample2Status" HeaderText="Sample2Stat" />
                        <asp:BoundField DataField="Sample3Status" HeaderText="Sample3Stat" />
                        <asp:BoundField DataField="Sample1Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="Sample1InspectedBy" HeaderText="Inspec.By" />
                        <asp:BoundField DataField="Sample1Shift" HeaderText="Shift" />
                        <asp:BoundField DataField="RejMTSNo" HeaderText="Rej.MTSNo" />
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
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                        <asp:BoundField DataField="StopDate" HeaderText="StopDate" 
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="StopTime" HeaderText="StopTime" />
                        <asp:BoundField DataField="StartQty" HeaderText="StrtQty" />
                        <asp:BoundField DataField="Acceptedqty" HeaderText="AccQty" />
                        <asp:BoundField DataField="Rejectedqty" HeaderText="RejQty" />
                        <asp:BoundField DataField="Duration" HeaderText="Dur" />
                        <asp:BoundField DataField="RejectedReason" HeaderText="Rej.Reas" />
                        <asp:BoundField DataField="RejMTSNo" HeaderText="RejMTSno" />
                        <asp:BoundField DataField="Shift" HeaderText="Sft" />
                        <asp:BoundField DataField="Hydratedby" HeaderText="HydBy" />
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
        </tr>--%>
    </table><br />
    </div>
    </form>
</body>
</html>
