<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TumblingReports.aspx.cs" Inherits="TumblingReports" Title="Tumbling Reports"%>

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
    <style type="text/css">
        .style1
        {
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
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
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <Triggers>
                    <asp:PostBackTrigger ControlID ="btnGenerate" />
                    </Triggers>
                        <ContentTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TumblingNo:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTumblingLotNo" runat="server" 
                                AutoPostBack="True" MaxLength="8" ontextchanged="txtLotNo_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtTumblingLotNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtTumblingLotNo" 
                                ValidChars="Tt1234567890">
                            </cc1:FilteredTextBoxExtender>
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="btnGenerate" runat="server" 
                                ImageUrl="~/images/btn_Generate.png" onclick="btnGenerate_Click1" 
                                Visible="False" />
&nbsp;<asp:ImageButton ID="btnHome" runat="server" 
                                onclick="btnHome_Click" ImageUrl="~/images/btn_home_icon.png" />
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
                            <asp:BoundField DataField="TumblingLotNo" HeaderText="TumblingNo" />
                            <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                            <asp:BoundField DataField="TotalQuantity" HeaderText="Tot.Qty" />
                            <asp:BoundField DataField="JarNo" HeaderText="JarNo" />
                            <asp:BoundField DataField="Location" HeaderText="Loc" />
                            <asp:BoundField DataField="StartDate" HeaderText="StrtDate" 
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="StartTime" HeaderText="StrtTime" />
                            <asp:BoundField DataField="StopDate" HeaderText="StpDate" 
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="StopTime" HeaderText="StpTime" />
                            <asp:BoundField DataField="Duration" HeaderText="Dur" />
                            <asp:BoundField DataField="Remarks" HeaderText="Rmks" />
                            <asp:BoundField DataField="Tumbledby" HeaderText="TumbBy" />
                        </Columns>
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="gvLenPrepTumbChild" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                            <asp:BoundField DataField="Power" HeaderText="Power" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
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
                    <asp:Label ID="lblHydAftTumb" runat="server" CssClass="textlbl" 
                        Text="HydrationAfterTumbling" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvHydAfrTumb" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TumblingLotNo" HeaderText="TumblingLotNo" />
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSIforTumb" runat="server" CssClass="textlbl" 
                        Text="SIForTumbling" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvSiTumb" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TumblingNo" HeaderText="TumblingNo" />
                            <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                            <asp:BoundField DataField="JarNo" HeaderText="JarNo" />
                            <asp:BoundField DataField="Location" HeaderText="Loc" />
                            <asp:BoundField DataField="Power" HeaderText="Pwr" />
                            <asp:BoundField DataField="InspectedBy" HeaderText="InspectedBy" />
                            <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Time" HeaderText="Time" />
                            <asp:BoundField DataField="Day" HeaderText="Day" />
                            <asp:BoundField DataField="Status" HeaderText="SampStat." />
                            <asp:BoundField DataField="Remarks" HeaderText="SampRmks" />
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
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLensWiping" runat="server" CssClass="textlbl" 
                        Text="Lens Wiping" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvLensWiping" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TumblingLotNo" HeaderText="TumblingLotNo" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="TotalQuantity" HeaderText="Tot.Qty" />
                            <asp:BoundField DataField="CompQuantity" HeaderText="CompQty" />
                            <asp:BoundField DataField="ProgressQuantity" HeaderText="ProgQty" />
                            <asp:BoundField DataField="Power" HeaderText="Pwr" />
                            <asp:BoundField DataField="ReceivedQuantity" HeaderText="Rec.Qty" />
                            <asp:BoundField DataField="BalanceQuantity" HeaderText="BalQty" />
                            <asp:BoundField DataField="AcceptedQuantity" HeaderText="AccQty" />
                            <asp:BoundField DataField="RejectedQuantity" HeaderText="RejQty" />
                            <asp:BoundField DataField="Remarks" HeaderText="Rmks" />
                            <asp:BoundField DataField="Rework" HeaderText="Rwk" />
                            <asp:BoundField DataField="WipingDoneby" HeaderText="WipingDnby" />
                            <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
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
                            <asp:BoundField DataField="TumblingNo" HeaderText="TumblingNo" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="TotalQty" HeaderText="TotQty" />
                            <asp:BoundField DataField="CompletedQty" HeaderText="CmpQty" />
                            <asp:BoundField DataField="Power" HeaderText="Pwr" />
                            <asp:BoundField DataField="RecievedQty" HeaderText="RecQty" />
                            <asp:BoundField DataField="BalanceQty" HeaderText="BalQty" />
                            <asp:BoundField DataField="ProgressQty" HeaderText="ProgQty" />
                            <asp:BoundField DataField="AcceptedQty" HeaderText="AccQty" />
                            <asp:BoundField DataField="RejectedQty" HeaderText="RejQty" />
                            <asp:BoundField DataField="DOTS" HeaderText="DOTS" />
                            <asp:BoundField DataField="ISLANDS" HeaderText="ISLANDS" />
                            <asp:BoundField DataField="LB" HeaderText="LB" />
                            <asp:BoundField DataField="SCR" HeaderText="SCR" />
                            <asp:BoundField DataField="PIMP" HeaderText="PIMP" />
                            <asp:BoundField DataField="HeatProb" HeaderText="HeatProb" />
                            <asp:BoundField DataField="Remarks" HeaderText="Rmks" />
                            <asp:BoundField DataField="RejMTSNo" HeaderText="RejMTSNo" />
                            <asp:BoundField DataField="ApprovedBy" HeaderText="AppBy" />
                            <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
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
                    <asp:Label ID="lblSealingCup" runat="server" CssClass="textlbl" 
                        Text="Sealing Cup" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvSealingCup" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TumblingLotNo" HeaderText="TumblingNo" />
                            <asp:BoundField DataField="SealingProcess" HeaderText="SealingProc" />
                            <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                            <asp:BoundField DataField="TotalQuantity" HeaderText="TotQty" />
                            <asp:BoundField DataField="TotCompletedQuantity" HeaderText="CompQty" />
                            <asp:BoundField DataField="Power" HeaderText="Pwr" />
                            <asp:BoundField DataField="ReceivedQuantity" HeaderText="RecQty" />
                            <asp:BoundField DataField="BalanceQty" HeaderText="BalQty" />
                            <asp:BoundField DataField="ProgQuantity" HeaderText="ProgQty" />
                            <asp:BoundField DataField="AcceptedQuantity" HeaderText="AccQty" />
                            <asp:BoundField DataField="RejectedQuantity" HeaderText="RejQty" />
                            <asp:BoundField DataField="SealingDoneBy1" HeaderText="Seal'gDoneBy" />
                            <asp:BoundField DataField="SealingDoneBy2" HeaderText="Seal'g Doneby" />
                            <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
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
                    <asp:Label ID="lblPowerInspec" runat="server" CssClass="textlbl" 
                        Text="Power Inspection" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvPowerinspec" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TumblingLotNo1" HeaderText="TumblingLotNo" />
                            <asp:BoundField DataField="Tumbling1Power1" HeaderText="Pwr" />
                            <asp:BoundField DataField="Tumbling11Sample1" HeaderText="Sample1" />
                            <asp:BoundField DataField="Tumbling21Sample1" HeaderText="Sample2" />
                            <asp:BoundField DataField="Tumbling31Sample1" HeaderText="Sample3" />
                            <asp:BoundField DataField="Tumbling41Sample1" HeaderText="Sample4" />
                            <asp:BoundField DataField="Tumbling51Sample1" HeaderText="Sample5" />
                            <asp:BoundField DataField="Tumbling1Remarks1" HeaderText="Rmks" />
                            <asp:BoundField DataField="Tumbling1InspectedBy" HeaderText="Inspec.By" />
                            <asp:BoundField DataField="Tumbling1Date1" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
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
                    <asp:Label ID="lblSealingPouch" runat="server" CssClass="textlbl" 
                        Text="Sealing Pouch" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvSealingPouch" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TumblingLotNo" HeaderText="TumblingNo" />
                            <asp:BoundField DataField="SealingProcess" HeaderText="SealingProc" />
                            <asp:BoundField DataField="ModelNo" HeaderText="ModelNo" />
                            <asp:BoundField DataField="TotalQuantity" HeaderText="TotQty" />
                            <asp:BoundField DataField="TotCompletedQuantity" HeaderText="CompQty" />
                            <asp:BoundField DataField="Power" HeaderText="Pwr" />
                            <asp:BoundField DataField="ReceivedQuantity" HeaderText="RecQty" />
                            <asp:BoundField DataField="BalanceQty" HeaderText="BalQty" />
                            <asp:BoundField DataField="ProgQuantity" HeaderText="ProgQty" />
                            <asp:BoundField DataField="AcceptedQuantity" HeaderText="AccQty" />
                            <asp:BoundField DataField="RejectedQuantity" HeaderText="RejQty" />
                            <asp:BoundField DataField="SealingDoneBy1" HeaderText="Seal'gDoneBy" />
                            <asp:BoundField DataField="SealingDoneBy2" HeaderText="Seal'g Doneby" />
                            <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
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
                    <asp:Label ID="lblPackingreport" runat="server" CssClass="textlbl" 
                        Text="Packingreport" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvPackingReport" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TumblingLotNo" HeaderText="TumblingNo" />
                            <asp:BoundField DataField="Model" HeaderText="ModelNo" />
                            <asp:BoundField DataField="TotalQty" HeaderText="TotQty" />
                            <asp:BoundField DataField="Power" HeaderText="Pwr" />
                            <asp:BoundField DataField="ReceivedQty" HeaderText="RecQty" />
                            <asp:BoundField DataField="BalanceQty" HeaderText="BalQty" />
                            <asp:BoundField DataField="ProgressQty" HeaderText="ProgQty" />
                            <asp:BoundField DataField="AcceptedQuantity" HeaderText="AccQty" />
                            <asp:BoundField DataField="TotalAcceptedQty" HeaderText="TotAccQty" />
                            <asp:BoundField DataField="RejectedQty" HeaderText="RejQty" />
                            <asp:BoundField DataField="TotalRejectedQty" HeaderText="TotRejQty" />
                            <asp:BoundField DataField="Rework" HeaderText="Rwk" />
                            <asp:BoundField DataField="ApprovedBy" HeaderText="ApprovBy" />
                            <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
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
                    <asp:Label ID="lbLabelDetail" runat="server" CssClass="textlbl" 
                        Text="Label Details" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvlabeldetail" runat="server" AutoGenerateColumns="False" 
                        BackColor="#CCCCCC" BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" 
                        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="100%">
                        <FooterStyle BackColor="#CCCCCC" />
                        <RowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="TumblingLotNo" HeaderText="TumblingNo" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="SubModel" HeaderText="SubModel" />
                            <asp:BoundField DataField="BrandName" HeaderText="BrandName" />
                            <asp:BoundField DataField="TotalQty" HeaderText="TotalQty" />
                            <asp:BoundField DataField="Power" HeaderText="Pwr" />
                            <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                            <asp:BoundField DataField="StartNo" HeaderText="StartNo" />
                            <asp:BoundField DataField="EndNo" HeaderText="EndNo" />
                            <asp:BoundField DataField="Qty" HeaderText="Qty" />
                            <asp:BoundField DataField="Remarks" HeaderText="Rmks" />
                            <asp:BoundField DataField="Date" HeaderText="Date" 
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="PackedBy" HeaderText="PackedBy" />
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
                    &nbsp;</td>
            </tr>
        </table>
        <br />
    </p>
    <div>
    </div>
    </form>
</body>
</html>
