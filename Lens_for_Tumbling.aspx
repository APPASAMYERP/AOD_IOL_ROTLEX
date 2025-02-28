<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Lens_for_Tumbling.aspx.cs" Title="LensPreparation for Tumbling" Inherits="Lens_for_Tumbling" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
    <Triggers >
    
    <asp:PostBackTrigger ControlID ="btnSave" />
    <asp:PostBackTrigger ControlID ="btnUpdate" />
     <asp:PostBackTrigger ControlID ="btnClear" />
     
    </Triggers>
    
      <ContentTemplate>
      
    <table width="100%" id="table_left">
    
        <tr>
        
            <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                <b>Lens Preperation for Tumbling</b>
             </td>
             
        </tr>
        
        <tr>
        
            <td> 
                          
                <table class="con_table" width="100%">
                
                    <tr>
                        <td>
                            <span style="margin-left: 201px;"><asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Tumbling No"></asp:Label></span>
                        </td>
                        <td>
                            <asp:TextBox ID="txttumblingNo" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Width="201px" ontextchanged="txttumblingNo_TextChanged"></asp:TextBox>
                           <%-- <cc1:FilteredTextBoxExtender ID="txttumblingNo_FilteredTextBoxExtender" 
                                runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txttumblingNo" 
                                ValidChars="/.-ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        
                    </tr>
                    
                    <tr>
                    <td align="center" colspan="4" style="height: 37px">
                    <table>
                    <tr>
                    <td>
                     <asp:ImageButton ID="btngenerate" runat="server" ImageUrl="~/images/btn_Generate.png" 
                                             Visible="False" onclick="btngenerate_Click" />                    
                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </cc1:ToolkitScriptManager>
                    </td>
                    </tr>
                    </table>
                    </tr>
                    
                    <tr>
                        <td align="center" colspan="4">
                            <asp:GridView ID="gvLensPrepare" runat="server" AutoGenerateColumns="False" 
                                BorderColor="#B1B1B1" CellPadding="1" EnableModelValidation="True" Width="100%">
                                <AlternatingRowStyle CssClass="AltRow" />
                                <Columns>
                                    <asp:CommandField ButtonType="Image" HeaderText="Select" 
                                        SelectImageUrl="~/images/select.PNG" ShowSelectButton="True">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:CommandField>          
                                    
                                    <asp:BoundField DataField="LotNo" HeaderText="LotNo">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>                                                                                     
                                                                                                    
                                    <asp:BoundField DataField="Model" HeaderText="Model">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="Power" HeaderText="Power">
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>      
                                    
                                    <asp:BoundField DataField="Qty" HeaderText="TotalQty"> 
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>  
                                    <asp:BoundField DataField="PhobicId" HeaderText="PhobicId"> 
                                        <HeaderStyle CssClass="headeritem" />
                                        <ItemStyle CssClass="itemstyle" />
                                    </asp:BoundField>                      
                                 </Columns>
                                <FooterStyle CssClass="footer" />
                                <HeaderStyle CssClass="grd_Header" />
                                <PagerStyle CssClass="pager" />
                                <RowStyle CssClass="narmal_row" />
                                <SelectedRowStyle CssClass="selectedrow" Font-Italic="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                    
                    <tr>
                     <td height="22" style="width: 231px">
                      <asp:Label ID="totalQty" runat="server" CssClass="textlbl" Text="TotalQty"></asp:Label>                      
                    </td>
                     <td height="22" style="width: 306px">
                            <asp:TextBox ID="txttotalQty" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Width="201px"></asp:TextBox>                           
                        </td>                      
                                        
                    </tr>
                    
                    <tr id="Startdatetime" runat="server">
                    
                    <td height="22" style="width: 158px">
                            <asp:Label ID="lblstartdate" runat="server" CssClass="textlbl" Text="StartDate"></asp:Label>
                    </td>
                    
                    <td height="22" style="width: 264px; margin-left: 80px;">
                            <asp:TextBox ID="txtSatrtDate" runat="server" CssClass="textbox" Width="201px" 
                                AutoPostBack="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtSatrtDate_CalendarExtender" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtSatrtDate">
                            </cc1:CalendarExtender>
                    </td> 
                    
                    <td>
                        <asp:Label ID="lblstartTime" runat="server" CssClass="textlbl" Text="StartTime"></asp:Label>
                    </td>
                    
                    <td>
                    <table>
                          <tr>
                                    <td>
                                        <asp:TextBox ID="txtStartTime" runat="server" AutoPostBack="True" 
                                            CssClass="textbox"  Width="80px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="txtStartTime_MaskedEditExtender" runat="server" 
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="99:99" MaskType="Time" TargetControlID="txtStartTime">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td class="textlbl">
                                        /&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlStartDay" runat="server" CssClass="dropdown" 
                                            Width="50px">
                                            <asp:ListItem>AM</asp:ListItem>
                                            <asp:ListItem>PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>                
                    </tr>
                    
                    <tr id="Enddatetime" runat="server">
                    <td height="22" style="width: 158px">
                            <asp:Label ID="lblEnddate" runat="server" CssClass="textlbl" Text="EndDate"></asp:Label>
                    </td>
                    
                    <td height="22" style="width: 264px">
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="textbox" Width="201px" 
                                AutoPostBack="True"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtEndDate">
                            </cc1:CalendarExtender>
                        </td> 
                        
                      <td>
                        <asp:Label ID="lblEndtime" runat="server" CssClass="textlbl" Text="EndTime"></asp:Label>
                    </td>
                    
                     <td>
                    <table >
                          <tr>
                                    <td style="margin-left: 160px">
                                        <asp:TextBox ID="txtEndTime" runat="server" AutoPostBack="True" 
                                            CssClass="textbox"  Width="80px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                                            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                            Mask="99:99" MaskType="Time" TargetControlID="txtEndTime">
                                        </cc1:MaskedEditExtender>
                                    </td>
                                    <td class="textlbl">
                                        /&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlEndday" runat="server" CssClass="dropdown" 
                                            Width="50px">
                                            <asp:ListItem>AM</asp:ListItem>
                                            <asp:ListItem>PM</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>          
                        </tr> 
                        
                        <tr>
                        
                        <td height="22" style="width: 264px">
                        <asp:Label ID="lblDuration" runat="server" CssClass="textlbl" Text="Duration" Visible="false"></asp:Label></td>                       
                         <td height="22" style="width: 306px">
                            <asp:TextBox ID="txtDuration" runat="server" AutoPostBack="True" 
                                CssClass="textbox" Width="201px" Visible="false"></asp:TextBox>  
                        </td>
                        </tr>    
                            
                    <tr>
                        <td align="center" colspan="4" style="height: 37px">
                            <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                             Visible="False" onclick="btnSave_Click" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnUpdate" runat="server" 
                                            ImageUrl="~/images/btn_update.png"  Visible="False" 
                                            onclick="btnUpdate_Click" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnClear" runat="server" 
                                            ImageUrl="~/images/btn_clear.png" Visible="False" 
                                            onclick="btnClear_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                </table>
                
            </td>
            
        </tr>
        
    </table>
    
     </ContentTemplate>
     
    </asp:UpdatePanel>
    
</asp:Content>



