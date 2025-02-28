<%@ Page Title="MI_FQI" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MI_FQI.aspx.cs" Inherits="MI_FQI" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</cc1:ToolkitScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers >
    <asp:PostBackTrigger ControlID ="btnSave" />
    <asp:PostBackTrigger ControlID ="btnUpdate" />
     <asp:PostBackTrigger ControlID ="btnClear" />
    </Triggers>
    <ContentTemplate>
    <link href="CSS/css.css" rel="Stylesheet" type="text/css" />
     <script type="text/javascript" src="JS/jquery.min.js"></script>
    <script type="text/javascript">
        function Search_Gridview(strKey, strGV) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }    
</script>
 <style type="text/css">
.overlay
{
position: fixed;
left:0px;
z-index: 999;
margin:0px,0px,0px,0px;
height: 100%;
width: 200%;
top: 0;
background-color: white;
filter: alpha(opacity=60);
opacity: 0.6;
-moz-opacity: 0.4;
}
</style>
<script type="text/javascript">
    function showProgress() {
        var updateProgress = $get("<%= UpdateProgress.ClientID %>");
        updateProgress.style.display = "block";
    }
</script>
    <table width="100%" id="table_left">
        <tr>
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">MI In FQI</td>
        </tr>
        <tr>
            <td>
                <table class="con_table" width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="Label22" runat="server" CssClass="textlbl" Text="Lot No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLotNo" runat="server" CssClass="textbox" 
                                Width="150px" Height="18px" ontextchanged="txtGlassyNo_TextChanged" 
                                AutoPostBack="True"></asp:TextBox>
                            
                        </td>
                        <td>
                            <asp:Label ID="Label25" runat="server" CssClass="textlbl" Text="Power"></asp:Label>
                        </td>
                        <td>
                             <%--<asp:TextBox ID="txtPower" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>--%>
                             <asp:DropDownList ID="drpPower" runat="server" CssClass="dropdown" 
                                 AppendDataBoundItems="true" AutoPostBack="true" 
                                 onselectedindexchanged="drpPower_SelectedIndexChanged">
                             <asp:ListItem>--Select--</asp:ListItem>
                             </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label23" runat="server" CssClass="textlbl" Text="Model"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtModel" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px" Height="18px"></asp:TextBox>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label24" runat="server" CssClass="textlbl" Text="TotalQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalQty" runat="server" CssClass="textbox" Enabled="False" 
                                Width="150px"></asp:TextBox>
                        </td>                        
                        <td>
                            <asp:Label ID="Label28" runat="server" CssClass="textlbl" Text="RecievedQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRecievedQty" runat="server" CssClass="textbox" 
                                Width="150px" ontextchanged="txtRecievedQty_TextChanged" 
                                AutoPostBack="True"></asp:TextBox>
                        </td>
                          <td>
                            <asp:Label ID="Label31" runat="server" CssClass="textlbl" Text="ProgressQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProgressQty" runat="server" CssClass="textbox" 
                                Width="150px" AutoPostBack="True" 
                                ontextchanged="txtProgressQty_TextChanged"></asp:TextBox>
                       </td>                                                               
                    </tr>
                    <tr>
                    <td>
                            <asp:Label ID="Label26" runat="server" CssClass="textlbl" Text="BalanceQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBalanceQty" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px">0</asp:TextBox>
                        </td>
                  
                        <td>
                            <asp:Label ID="Label29" runat="server" CssClass="textlbl" Text="AcceptedQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAcceptedQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox"  Width="150px" 
                                ontextchanged="txtAcceptedQty_TextChanged"></asp:TextBox>
                            
                        </td>
                        <td>
                            <asp:Label ID="Label32" runat="server" CssClass="textlbl" Text="RetumblingQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRetumbQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Width="150px" ontextchanged="txtRetumbQty_TextChanged"></asp:TextBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label27" runat="server" CssClass="textlbl" Text="RejectedQty"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejectedQty" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px" AutoPostBack="True" 
                                ontextchanged="txtRejectedQty_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                        <asp:Label ID="Label38" runat="server" CssClass="textlbl" Text="TumblingRefNo"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="txtTumblingRef" runat="server" CssClass="textbox" 
                                Enabled="False" Width="150px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label30" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Width="150px" 
                                AutoPostBack="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                TargetControlID="txtDate" Format="yyyy-MM-dd">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-top: 3px; height: 124px;">
                <table class="con_table" width="100%">
                    <tr>
                        <td colspan="6" 
                            style="padding: 5px; font-weight: bold; background-color: #6986C2; font-family: Arial; font-size: 9pt; color: #FFFFFF;">
                            <strong>Rejection Details</strong></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label33" runat="server" CssClass="textlbl" Text="Burr"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDots" runat="server" AutoPostBack="True" CssClass="textbox" 
                                ontextchanged="txtDots_TextChanged" Width="150px">0</asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtDots_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtDots">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label34" runat="server" CssClass="textlbl" Text="Punching"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtIslands" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtIslands_TextChanged" Width="150px">0</asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtIslands_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtIslands">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label35" runat="server" CssClass="textlbl" Text="L.B"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLB" runat="server" AutoPostBack="True" CssClass="textbox" 
                                ontextchanged="txtLB_TextChanged" Width="150px">0</asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtLB_FilteredTextBoxExtender" runat="server" 
                                Enabled="True" FilterType="Numbers" TargetControlID="txtLB">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label36" runat="server" CssClass="textlbl" Text="SCR"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSCR" runat="server" AutoPostBack="True" CssClass="textbox" 
                                ontextchanged="txtSCR_TextChanged" Width="150px">0</asp:TextBox>
                            <%--<cc1:FilteredTextBoxExtender ID="txtSCR_FilteredTextBoxExtender" runat="server" 
                                Enabled="True" FilterType="Numbers" TargetControlID="txtSCR">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label37" runat="server" CssClass="textlbl" Text="Solution"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCutting" runat="server" AutoPostBack="True" CssClass="textbox" 
                                 Width="150px" ontextchanged="txtCutting_TextChanged">0</asp:TextBox>                           
                        </td>  
                        <td>
                            <asp:Label ID="Label42" runat="server" CssClass="textlbl" Text="Others"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOther" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtOther_TextChanged" Width="150px">0</asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtOther_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" 
                                TargetControlID="txtOther">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>                     
                    </tr>
                    <tr>
                    <td>
                         <asp:Label ID="Total" runat="server" CssClass="textlbl" Text="Total"></asp:Label>
                        </td>                        
                        <td>
                        <asp:TextBox ID="txttotrejqty" runat="server" AutoPostBack="True" 
                                CssClass="textbox"  Width="150px" ontextchanged="txttotrejqty_TextChanged">0</asp:TextBox>
                        
                        </td>
                        
                        <td>
                            <asp:Label ID="Label39" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtRemarks_TextChanged" Width="150px"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterMode="InvalidChars" 
                                InvalidChars="1234567890" TargetControlID="txtRemarks">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td>
                            <asp:Label ID="Label40" runat="server" CssClass="textlbl" Text="RejMTS No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRejMTSNo" runat="server" CssClass="textbox" Width="150px" 
                                AutoPostBack="True" ontextchanged="txtRejMTSNo_TextChanged"></asp:TextBox>
                        </td>
                        
                        
                        </td>
                        </tr>    
                        <tr>                   
                        <td>
                        
                            <asp:Label ID="Label41" runat="server" CssClass="textlbl" Text="ApprovedBy"></asp:Label>
                        
                        </td>
                        <td>
                            <%--<asp:DropDownList ID="drpApprov" runat="server" AppendDataBoundItems="true"
                                       AutoPostBack="true" CssClass="dropdown" Width="156px" 
                                onselectedindexchanged="drpApprov_SelectedIndexChanged">
                                <asp:ListItem>Select</asp:ListItem>
                            </asp:DropDownList>--%>
                            <asp:TextBox ID="txtApprovedBy" runat="server" AutoPostBack="True" 
                                CssClass="textbox" ontextchanged="txtApprovedBy_TextChanged" Width="150px"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txtApprovedBy_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" TargetControlID="txtApprovedBy" 
                                ValidChars="abcdefghijklmnopqrstuvwxyz. ABCDEFGHIJKLMNOPQRSTUVWXYZ">
                            </cc1:FilteredTextBoxExtender>--%>
                            </td>
                        </tr>                   
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                    <div style="text-align: right;">
                          <span><asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'GrdPouch')"
                              style="border-radius: 10px; border: 1px solid #198996; padding: 4px; text-align:center;" 
                              placeholder="Enter LabelNo to Search" 
                              ontextchanged="txtSearch_TextChanged" AutoPostBack="true"></asp:TextBox></span>        
                       <%-- <span>
                          <asp:ImageButton ID="btnSubmit" runat="server" 
                              ImageUrl="~/Images/SearchGrd.png" title="Click to Search" onclick="btnSubmit_Click" 
                             /></span>--%>
                    </div>
            </td>
         </tr>
         <tr>
            <td>
                <asp:GridView ID="gvMIinFQI" runat="server" AutoGenerateColumns="False" 
                    BorderColor="#B1B1B1" EnableModelValidation="True" 
                     Width="100%" onselectedindexchanged="gvMIinFQI_SelectedIndexChanged1">
                    
                    <AlternatingRowStyle CssClass="AltRow" />
                    <Columns>
                        <asp:CommandField SelectImageUrl="~/images/select.PNG" 
                            ShowSelectButton="True" ButtonType="Image" SelectText="">
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="GlassyNo">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("GlassyNo") %>'></asp:TextBox></EditItemTemplate><ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("GlassyNo") %>'></asp:Label></ItemTemplate></asp:TemplateField><asp:BoundField DataField="Model" HeaderText="Model" />
                        <asp:BoundField DataField="TotalQty" HeaderText="TotQty" />
                        <asp:BoundField DataField="RecievedQty" HeaderText="Rec.Qty" />
                        <asp:BoundField DataField="ProgressQty" HeaderText="Prog.Qty" />
                        <asp:BoundField DataField="BalanceQty" HeaderText="Bal.Qty" />
                        <asp:BoundField DataField="AcceptedQty" HeaderText="AccepQty" />
                        <asp:BoundField DataField="RetumblingQty" HeaderText="RetumQty" />
                        <asp:BoundField DataField="RejectedQty" HeaderText="RejQty" />
                        <asp:BoundField DataField="TumblingRefNo" HeaderText="TumRefNo" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                        <asp:BoundField DataField="ApprovedBy" HeaderText="ApprovedBy" />
                    </Columns>
                    <FooterStyle CssClass="footer" />
                    <SelectedRowStyle CssClass="selectedrow" />
                    <HeaderStyle CssClass="grd_Header" />
                    <PagerStyle CssClass="pager" />
                    <RowStyle CssClass="narmal_row" />
                </asp:GridView>
            </td>
        </tr>
         <tr>
            <td align="center">
            <div id="gridpuch" runat="server" class="scroll" style="height:200px;" >
                <asp:GridView ID="GrdPouch" runat="server" AutoGenerateColumns="False" Width="100%"
                              BorderColor="#B1B1B1" EnableModelValidation="True" DataKeyNames="Lot_SrNo" Visible="false" > 
                    <AlternatingRowStyle CssClass="AltRow" />                   
                    <Columns> 
                                      
                        <asp:TemplateField HeaderText="Brand Name" SortExpression="Brand_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Brand_Name") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model Name" SortExpression="Model_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Model_Name") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Model_Name") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Power" SortExpression="Power">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Power") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Power") %>'></asp:Label></EditItemTemplate>
                                <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TumblingNo" SortExpression="RefLot">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("RefLot") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("RefLot") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lot SrNo" SortExpression="Lot_SrNo">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Lot_SrNo") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Lot_SrNo") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Label" SortExpression="Label">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Label") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Label") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Process">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="GrdPouch_CheckChange" AutoPostBack="true" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>            
                    </Columns>
                    <FooterStyle CssClass="footer" />
                    <SelectedRowStyle CssClass="selectedrow" />
                    <HeaderStyle CssClass="grd_Header" />
                    <PagerStyle CssClass="pager" />
                    <RowStyle CssClass="narmal_row" />
                </asp:GridView>               
                
               </div> 
            </td>
        </tr>
        <tr>
            <td align="center">
                <div id="gridpuchchild" runat="server" class="scroll" style="height:200px;">
                   
                    <asp:GridView ID="GrdPouchChild" runat="server" BorderColor="#B1B1B1" AutoGenerateColumns="false"
                                     EnableModelValidation="true" Width="100%" DataKeyNames="Id" Visible="false" OnRowDeleting="GrdPouchChild_Delete">
                              <AlternatingRowStyle CssClass="AltRow" />                   
                    <Columns> 
                          <asp:BoundField HeaderText="ID" DataField="Id" />           
                        <asp:TemplateField HeaderText="Brand Name" SortExpression="Brand_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Brand_Name") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model Name" SortExpression="Model_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Model_Name") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Model_Name") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Power" SortExpression="Power">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Power") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Power") %>'></asp:Label></EditItemTemplate>
                                <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TumblingNo" SortExpression="RefLot">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("RefLot") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("RefLot") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lot SrNo" SortExpression="Lot_SrNo">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Lot_SrNo") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Lot_SrNo") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Label" SortExpression="Label">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Label") %>'></asp:Label></ItemTemplate><EditItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Label") %>'></asp:Label></EditItemTemplate><HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="true" />
                        <%--<asp:TemplateField HeaderText="Process">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="GrdPouch_CheckChange" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                        </asp:TemplateField>   --%>         
                    </Columns>
                    <FooterStyle CssClass="footer" />
                    <SelectedRowStyle CssClass="selectedrow" />
                    <HeaderStyle CssClass="grd_Header" />
                    <PagerStyle CssClass="pager" />
                    <RowStyle CssClass="narmal_row" />
                    </asp:GridView>      
                    
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table>
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="Upl" runat="server" UpdateMode="Conditional">                         
                            <Triggers><asp:PostBackTrigger ControlID="btnSave" /></Triggers>
                            <ContentTemplate>
                            <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                onclick="btnSave_Click" Visible="False" OnClientClick="showProgress()" />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="Upl2" runat="server" UpdateMode="Conditional">                         
                            <Triggers><asp:PostBackTrigger ControlID="btnUpdate" /></Triggers>
                            <ContentTemplate>
                            <asp:ImageButton ID="btnUpdate" runat="server" 
                                ImageUrl="~/images/btn_update.png"  Visible="False" 
                                onclick="btnUpdate_Click" OnClientClick="showProgress()" />
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnClear" runat="server" 
                                ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" 
                                Visible="False" />
                        </td>                        
                    </tr>
                </table>
            </td>
        </tr>        
    </table>
      </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Upl">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index:1000;margin-left:580px; margin-top: 300px; opacity:1; -moz-opacity:1;">
                    <%--<img alt="" src="images/hourglass (1).gif" />--%>
                    <img alt="" src="images/hourglass (1).gif" />
                    <p style="visibility:visible;" id="imagee">
                    <asp:Label ID="imagee" runat="server" Text="Saving Plz Wait..." style="font-size:15pt; font-weight:bolder;color:#000000;"></asp:Label>
                    </p>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="Upl2">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index:1000;margin-left:580px; margin-top: 300px; opacity:1; -moz-opacity:1;">
                    <%--<img alt="" src="images/hourglass (1).gif" />--%>
                    <img alt="" src="images/hourglass (1).gif" />
                    <p style="visibility:visible;" id="imagee1">
                    <asp:Label ID="imagee1" runat="server" Text="Saving Plz Wait..." style="font-size:15pt; font-weight:bolder;color:#000000;"></asp:Label>
                    </p>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

