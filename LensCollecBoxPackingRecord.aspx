
<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LensCollecBoxPackingRecord.aspx.cs" Inherits="LensCollecBoxPackingRecord" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="javascript" id ="ffKeyTrap" >

var altKey  = false;
var keyCode = 0;
 
function closeSession(evt){
 
    evt = (evt) ? evt : event;
 
    clickY  = evt.clientY;
    altKey  = evt.altKey;
    keyCode = evt.keyCode;
 
    if(!evt.clientY){
        // Window Closing in FireFox
        // capturing ALT + F4
        keyVals = document.getElementById('ffKeyTrap');
        if(keyVals.value == 'true115'){
            return 'close 1';
        }
 
        if(keyVals.value == ''){
            // capturing a window close by "X" ?
            // we have no keycodes
            return 'close 2';
        }
 
    } else {
        // Window Closing in IE
        // capturing ALT + F4
        if (altKey == true && keyCode == 115){
            alert('close 1');
        // capturing a window close by "X"
        } else if(clickY < 0){
        PageMethods.Close();
            alert('close 2');
        // simply leaving the page via a link
        } else {
            //alert('close 3');
            return void(0);
        }
    }
}
 
function whatKey(evt){
    evt = (evt) ? evt : event;
    keyVals = document.getElementById('ffKeyTrap');
    altKey  = evt.altKey;
    keyCode = evt.keyCode;
    if(altKey && keyCode == 115){
        keyVals.value = String(altKey) + String(keyCode);
    }
}
 
window.onkeydown      = whatKey;
window.onbeforeunload = closeSession;

</script>
 

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:PostBackTrigger ControlID = "btnSave" />
    <asp:PostBackTrigger ControlID = "btnAdd" />
    <asp:PostBackTrigger ControlID = "btnClear" />
     </Triggers>
   <ContentTemplate>

    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
                LENS COLLECTION CUM BOX PACKING RECORD
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 3px">
                <table class="con_table" >
                    <tr>
                        <td style="width: 50px" colspan="2">
                            Bpl No</td>
                        <td style="width: 50px" colspan="2">
                            <asp:TextBox ID="txtBPLno" runat="server" AutoPostBack="True" 
                                ontextchanged="txtBPLno_TextChanged"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtBPLno_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtBPLno">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="2">
                            Model</td>
                        <td>
                            <asp:TextBox ID="txtModel" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            Power</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtPower" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td colspan="3">
                            Brand</td>
                        <td>
                            <asp:TextBox ID="txtBrand" runat="server" 
                                ontextchanged="txtBrand_TextChanged" Enabled="False"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 50px" colspan="2">
                            Rec.Qty</td>
                        <td style="width: 50px" colspan="2">
                            <asp:TextBox ID="txtRecQty" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                        <td colspan="2">
                            Acc.Qty</td>
                        <td>
                            <asp:TextBox ID="txtAccQty" runat="server" AutoPostBack="True" 
                                ontextchanged="txtAccQty_TextChanged"></asp:TextBox>
                                                </td>
                        <td>
                            Rej Qty</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtRejQty" runat="server" Enabled="False">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                            Date</td>
                        <td colspan="2">
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtDate_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtDate" 
                    ValidChars="01234568789/-">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                                                </td>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="17">
                            <asp:Panel ID="pnlRejQDet" runat="server" Visible="False">
                                <table cellpadding="1" cellspacing="1" border=".5" 
    title="hidden">
                                    <tr>
                                        <td rowspan="2">
                                            Lotno</td>
                                        <td rowspan="2">
                                            SNo</td>
                                        <td rowspan="2">
                                            Lens Model</td>
                                        <td colspan="4">
                                            Pouch</td>
                                        <td colspan="4">
                                            Packing Case</td>
                                        <td colspan="6">
                                            Packing case/Pouch</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Dama</td>
                                        <td>
                                            Seal</td>
                                        <td>
                                            Strain</td>
                                        <td>
                                            Stain</td>
                                        <td>
                                            dama</td>
                                        <td>
                                            Dots</td>
                                        <td>
                                            Label</td>
                                        <td>
                                            Seal</td>
                                        <td>
                                            Hair</td>
                                        <td>
                                            Dust</td>
                                        <td>
                                            Burr</td>
                                        <td>
                                            Thread</td>
                                        <td>
                                            Liq Lev</td>
                                        <td>
                                            Other</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtInlotno" runat="server" Height="18px" Width="71px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtInlotno_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtInlotno">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInSno" runat="server" Width="50px" CssClass="textbox_200"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtInSno_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtInSno">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtInmodel" runat="server" Height="21px" Width="50px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtInmodel_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtInmodel">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPDama" runat="server" Height="21px" Width="50px" 
                                                ontextchanged="txtPDama_TextChanged">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPDama_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtPDama">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPSeal" runat="server" Height="21px" Width="50px" 
                                                AutoPostBack="True">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPSeal_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtPSeal">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtstrain" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtstrain_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" TargetControlID="txtstrain" 
                                            FilterType="Numbers">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtstain" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtstain_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtstain">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPcdama" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPcdama_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtPcdama">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPcDots" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPcDots_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtPcDots">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPclabel" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPclabel_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtPclabel">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPcseal" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPcseal_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtPcseal">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtppHair" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtppHair_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtppHair">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtppDust" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtppDust_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtppDust">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtppBurr" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtppBurr_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtppBurr">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtThread" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtThread_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtThread">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPPLiqlev" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPPLiqlev_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtPPLiqlev">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPPOther" runat="server" Height="21px" Width="50px">0</asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtPPOther_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtPPOther">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                    </tr>
                                    <tr>
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
                                            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/btn_Add.png" 
                                            onclick="btnAdd_Click" />
                                        </td>
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
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="17" id="lotdetails">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="17" style="height: 135px">
                            <asp:GridView ID="gvBoxInspection" runat="server" AutoGenerateColumns="False" 
                                onselectedindexchanged="gvBoxInspection_SelectedIndexChanged">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="LotNo" HeaderText="Lno" />
                                    <asp:BoundField DataField="SerialNo" HeaderText="Sno" />
                                    <asp:BoundField DataField="LensModel" HeaderText="mdl" />
                                    <asp:BoundField DataField="Pdama" HeaderText="dama" />
                                    <asp:BoundField DataField="Pseal" HeaderText="seal" />
                                    <asp:BoundField DataField="Pstrain" HeaderText="strn" />
                                    <asp:BoundField DataField="Pstain" HeaderText="stain" />
                                    <asp:BoundField DataField="PCdama" HeaderText="Dama" />
                                    <asp:BoundField DataField="PCdots" HeaderText="dots" />
                                    <asp:BoundField DataField="PClabel" HeaderText="lbl" />
                                    <asp:BoundField DataField="PCseal" HeaderText="seal" />
                                    <asp:BoundField DataField="PPhair" HeaderText="Hair" />
                                    <asp:BoundField DataField="PPdust" HeaderText="dst" />
                                    <asp:BoundField DataField="PPburr" HeaderText="brr" />
                                    <asp:BoundField DataField="PPthread" HeaderText="Thrd" />
                                    <asp:BoundField DataField="PPliqLev" HeaderText="LL" />
                                    <asp:BoundField DataField="PPoth" HeaderText="oth" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 72px">
                            Inspec By</td>
                        <td style="width: 50px" colspan="3">
            <asp:TextBox ID="txtInspecBy" runat="server" 
                AutoPostBack="True" ontextchanged="txtInspecBy_TextChanged"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtInspecBy_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtInspecBy" 
                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="2">
                            Sno of&nbsp; Rej Lens</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtSnoRejLens" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtSnoRejLens_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtSnoRejLens">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="17">
                            </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width: 100px">
                            Label printed by</td>
                        <td colspan="2" style="width: 172px">
                            Box Prerared By</td>
                        <td colspan="2" style="width: 172px">
                            Packing &amp; Outer LabelBy</td>
                        <td colspan="2">
                            Shrink Packed By</td>
                        <td colspan="2">
                            Remarks</td>
                        <td colspan="4">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width: 100px">
            <asp:TextBox ID="txtLabelprintedBuy" runat="server" 
                AutoPostBack="True" ontextchanged="txtLabelprintedBuy_TextChanged"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtLabelprintedBuy_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtLabelprintedBuy" 
                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="2" style="width: 172px">
            <asp:TextBox ID="txtBoxPrepBy" runat="server" 
                AutoPostBack="True" ontextchanged="txtBoxPrepBy_TextChanged"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtBoxPrepBy_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtBoxPrepBy" 
                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="2" style="width: 172px">
            <asp:TextBox ID="txtPnOlabelby" runat="server" 
                AutoPostBack="True" ontextchanged="txtPnOlabelby_TextChanged"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtPnOlabelby_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtPnOlabelby" 
                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="2">
            <asp:TextBox ID="txtShrkPackBy" runat="server" 
                AutoPostBack="True" ontextchanged="txtShrkPackBy_TextChanged"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtShrkPackBy_FilteredTextBoxExtender" 
                runat="server" Enabled="True" TargetControlID="txtShrkPackBy" 
                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="2">
            <asp:TextBox ID="txtRmks" runat="server" 
                AutoPostBack="True"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="txtRmks_FilteredTextBoxExtender" 
                runat="server" Enabled="True" FilterMode="InvalidChars" 
                InvalidChars="123456789" TargetControlID="txtRmks">
            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="4">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="17">
                            <table class="style1" cellpadding="1" cellspacing="1">
                                <tr>
                                    <td colspan="3" style="width: 163px">
                            Lot No of packed lens<td>
                                    </td>
                        <td colspan="5">
                            Box Packed Lens to FP Stores</td>
                        <td colspan="3">
                            Rej.Lens for Rework -to tumb</td>
                        <td colspan="2">
                            &nbsp;Rej for Scrap - To stores&nbsp;</td>
                    </tr>
                                <tr>
                                    <td colspan="3" style="width: 163px">
                                        &nbsp;<td colspan="2">
                                                                            &nbsp;</td>
                                                                        <td colspan="2">
                                                                            &nbsp;</td>
                                                                        <td colspan="2">
                                                                            &nbsp;</td>
                        <td colspan="3">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Lot No</td>
                        <td style="width: 66px">
                            Qty</td>
                        <td colspan="2">
                            Qty</td>
                        <td colspan="2">
                            Date</td>
                        <td colspan="2">
                            MTS no</td>
                        <td>
                            Date</td>
                        <td>
                            Mts no</td>
                        <td>
                            Qty</td>
                        <td>
                            Date</td>
                        <td>
                            Mts no</td>
                        <td>
                            Qty</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtPackLno" runat="server"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtPackLno_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtPackLno">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td style="width: 66px">
                                        <asp:TextBox ID="txtLNpckQty" runat="server" Height="21px" 
                                Width="50px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtLNpckQty_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtLNpckQty">
                                        </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="2">
                                        <asp:TextBox ID="txtFpstrQty" runat="server" Height="21px" 
                                Width="50px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtFpstrQty_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtFpstrQty">
                                        </cc1:FilteredTextBoxExtender>
                        </td>
                        <td colspan="2">
        <asp:TextBox ID="txtFpDate" runat="server" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtFpDate_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtFpDate" 
                    ValidChars="0123456789/-">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtFpDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtFpDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                        </td>
                        <td colspan="2">
                                        <asp:TextBox ID="txtfpMTSno" runat="server" Height="21px" 
                                Width="50px"></asp:TextBox>
                        </td>
                        <td>
        <asp:TextBox ID="txtthbDate" runat="server" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtthbDate_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtthbDate" 
                    ValidChars="0123456789/-">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtthbDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtthbDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                        </td>
                        <td>
                                        <asp:TextBox ID="txtThmbMTSno" runat="server" Height="21px" 
                                Width="50px"></asp:TextBox>
                        </td>
                        <td>
                                        <asp:TextBox ID="txtThbQty" runat="server" Height="21px" 
                                Width="50px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtThbQty_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtThbQty">
                                        </cc1:FilteredTextBoxExtender>
                        </td>
                        <td>
        <asp:TextBox ID="txtTostoreDate" runat="server" Width="50px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="txtTostoreDate_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="txtTostoreDate" 
                    ValidChars="0123456789/-">
                </cc1:FilteredTextBoxExtender>
                <cc1:CalendarExtender ID="txtTostoreDate_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtTostoreDate" Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                        </td>
                        <td>
                                        <asp:TextBox ID="txtTOstoreMTSno" runat="server" Height="21px" 
                                Width="50px"></asp:TextBox>
                        </td>
                        <td>
                                        <asp:TextBox ID="txtTOstoreQty" runat="server" Height="21px" 
                                Width="50px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtTOstoreQty_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtTOstoreQty">
                                        </cc1:FilteredTextBoxExtender>
                        </td></td>
                                </tr>
                    <tr>
                        <td style="width: 100px">
                            &nbsp;</td>
                        <td style="width: 66px">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td colspan="2">
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
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width: 100px">
                            &nbsp;</td>
                        <td colspan="4" style="width: 172px">
                            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods=true>
                            </asp:ScriptManager>
                        </td>
                        <td colspan="4">
                            <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                onclick="btnSave_Click" Visible="False" />
                            <asp:ImageButton ID="btnUpdate" runat="server" 
                                ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" Visible="False" />
                            <asp:ImageButton ID="btnClear" runat="server" 
                                ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" />
                        </td>
                        <td colspan="4">
                            &nbsp;</td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                </table>
     </ContentTemplate>
     </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

