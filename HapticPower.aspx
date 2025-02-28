<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HapticPower.aspx.cs" Inherits="HapticPower" Title="Haptic & Power" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers> 
            <asp:PostBackTrigger ControlID="btnsave" />
            <asp:PostBackTrigger ControlID="btnclear" />
            <asp:PostBackTrigger ControlID="btnupdate" />
        </Triggers>
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                        <strong>Haptic & Power</strong>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="padding-top: 3px">
                        <table class="con_table" width="100%">
                            <tr> 
                                <td>
                                    <asp:Label ID="lbllotno" runat="server" CssClass="textlbl" Text="Lot No"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlotno" runat="server" AutoPostBack="true" CssClass="textbox" 
                                         Width="150px" MaxLength="10" ontextchanged="txtlotno_TextChanged">  </asp:TextBox>                                    
                                </td>
                                <td>
                                    <asp:Label ID="lbltype" runat="server" CssClass="textlbl" Text="Blocking Type"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBlockingType" runat="server" CssClass="textbox" Enabled="False"
                                        Width="150px">IInd Cut</asp:TextBox>
                                </td> 
                                <td>
                                    <asp:Label ID="lbldate" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" Enabled="False"
                                        Width="150px" ></asp:TextBox>
                                </td>  
                            </tr>
                            <tr>
                                 <td colspan="6" align="center">
                                <table cellpadding="1" cellspacing="0">
                                <tr>
                                    <td class="nav" style="font-weight: bold">
                                        <asp:Label ID="lblsampleno" runat="server" CssClass="textlbl" Text="Sample No"></asp:Label>
                                    </td>
                                    <td class="nav" colspan="2" style="font-weight: bold">
                                      <asp:Label ID="lblpower" runat="server" CssClass="textlbl" Text="Power"></asp:Label>
                                    </td>
                                    <td class="nav" style="font-weight: bold">
                                        <asp:Label ID="lblpowvalue" runat="server" CssClass="textlbl" Text="Power Value"></asp:Label>
                                    </td>
                                    <td class="nav" style="font-weight: bold">
                                        <asp:Label ID="lblhap" runat="server" CssClass="textlbl" Text="Haptic Thickness"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nav">
                                        <asp:Label ID="lblSample1" runat="server" CssClass="textlbl" 
                                            Font-Bold="False" Text="SampleNo1"></asp:Label>
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkpoweracc1" runat="server" 
                                            AutoPostBack="True" Checked="True" CssClass="textlbl" Font-Bold="False" 
                                             Text="Accepted" oncheckedchanged="chkpoweracc1_CheckedChanged" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkpowerrej1" runat="server" 
                                            AutoPostBack="True" CssClass="textlbl" Font-Bold="False" 
                                             Text="Rejected" oncheckedchanged="chkpowerrej1_CheckedChanged" />
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtpowervalue1" runat="server" AutoPostBack="true"
                                              CssClass="textbox" MaxLength="6" 
                                            ontextchanged="txtpowervalue1_TextChanged"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtpower1_filter" runat="server" Enabled="true"
                                              TargetControlID="txtpowervalue1" ValidChars="1234567890.-">
                                        </cc1:FilteredTextBoxExtender> 
                                    </td>                                       
                                    <td class="nav">
                                        <asp:TextBox ID="txthaptic1" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="6" ontextchanged="txthaptic1_TextChanged"></asp:TextBox>                                            
                                        <cc1:FilteredTextBoxExtender ID="txthaptic1_filter" 
                                            runat="server" Enabled="True" TargetControlID="txthaptic1" 
                                            ValidChars="1234567890.">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nav">
                                        <asp:Label ID="lblsample2" runat="server" CssClass="textlbl" 
                                            Font-Bold="False" Text="SampleNo2"></asp:Label>
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkpoweracc2" runat="server" 
                                            AutoPostBack="True" Checked="True" CssClass="textlbl" Font-Bold="False" 
                                             Text="Accepted" oncheckedchanged="chkpoweracc2_CheckedChanged" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkpowerrej2" runat="server" 
                                            AutoPostBack="True" CssClass="textlbl" Font-Bold="False" 
                                             Text="Rejected" oncheckedchanged="Chkpowerrej2_CheckedChanged" />
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtpowervalue2" runat="server" AutoPostBack="true"
                                              CssClass="textbox" MaxLength="6"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtpowervalue2_filter" runat="server" Enabled="true"
                                              TargetControlID="txtpowervalue2" ValidChars="1234567890.-">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txthaptic2" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="6" ontextchanged="txthaptic2_TextChanged"></asp:TextBox>                                            
                                        <cc1:FilteredTextBoxExtender ID="txthaptic2_filter" 
                                            runat="server" Enabled="True" TargetControlID="txthaptic2" 
                                            ValidChars="1234567890.">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="nav">
                                        <asp:Label ID="lblsample3" runat="server" CssClass="textlbl" 
                                            Font-Bold="False" Text="SampleNo3"></asp:Label>
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkpoweracc3" runat="server" 
                                            AutoPostBack="True" Checked="True" CssClass="textlbl" Font-Bold="False" 
                                             Text="Accepted" oncheckedchanged="chkpoweracc3_CheckedChanged" />
                                    </td>
                                    <td class="nav">
                                        <asp:CheckBox ID="chkpowerrej3" runat="server" 
                                            AutoPostBack="True" CssClass="textlbl" Font-Bold="False" 
                                             Text="Rejected" oncheckedchanged="chkpowerrej3_CheckedChanged" />
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txtpowervalue3" runat="server" AutoPostBack="true"
                                              CssClass="textbox" MaxLength="6" 
                                            ontextchanged="txtpowervalue3_TextChanged"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtpowervalue3_filter" runat="server" Enabled="true"
                                              TargetControlID="txtpowervalue3" ValidChars="1234567890.-">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td class="nav">
                                        <asp:TextBox ID="txthaptic3" runat="server" AutoPostBack="True" 
                                            CssClass="textbox" MaxLength="6" ontextchanged="txthaptic3_TextChanged"></asp:TextBox>                                            
                                        <cc1:FilteredTextBoxExtender ID="txthaptic3_filter" 
                                            runat="server" Enabled="True" TargetControlID="txthaptic3" 
                                            ValidChars="1234567890.">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>                           
                        </table>
                    </td>
                </tr>
                <tr>
                     <td>
                         <asp:Label ID="lblremark" runat="server" CssClass="textlbl" Text="Remarks"></asp:Label>
                     </td>
                     <td>
                         <asp:TextBox ID="txtremark" runat="server" AutoPostBack="True" 
                              CssClass="textbox" Width="150px" ontextchanged="txtremark_TextChanged"></asp:TextBox>
                     </td>
                      <td>
                          <asp:Label ID="lblinsp" runat="server" CssClass="textlbl" Text="InspectedBy"></asp:Label>
                      </td>
                      <td>
                          <asp:TextBox ID="txtinsp" runat="server" AutoPostBack="true" 
                                CssClass="textbox" Width="150px"></asp:TextBox>
                      </td>
                      <td>                            
                          <asp:Label ID="Label6" runat="server" CssClass="textlbl" Text="Shift"></asp:Label>
                      </td>
                      <td>
                         <asp:DropDownList ID="ddlSample1Shif" runat="server" CssClass="dropdown" 
                              Width="150px">
                              <asp:ListItem>Select</asp:ListItem>
                              <asp:ListItem>I</asp:ListItem>
                              <asp:ListItem>II</asp:ListItem>
                              <asp:ListItem>III</asp:ListItem>
                          </asp:DropDownList>
                      </td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                         <table>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                            onclick="btnSave_Click" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnUpdate" runat="server" 
                                            ImageUrl="~/images/btn_update.png" onclick="btnUpdate_Click" Visible="False" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnClear" runat="server" 
                                            ImageUrl="~/images/btn_clear.png" onclick="btnClear_Click" 
                                            Visible="False" />
                                    </td>
                                </tr>
                            </table>
                             <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                            </cc1:ToolkitScriptManager>    
                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                    <asp:GridView ID="grdview" runat="server" AutoGenerateColumns="False"
                                BorderColor="#B1B1B1" HorizontalAlign="Center"> 
                           
                                <FooterStyle CssClass="footer" />
                                <RowStyle CssClass="narmal_row" />                      
                                <Columns>
                                    <asp:BoundField DataField="LotNo" HeaderText="LotNo" ReadOnly="True" 
                                        SortExpression="LotNo" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="BlockingType" HeaderText="BlockingType" 
                                        ReadOnly="True" SortExpression="BlockingType" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="PowerSample1" HeaderText="PowerSample1" 
                                        ReadOnly="True" SortExpression="PowerSample1" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="PowerSample2" HeaderText="PowerSample2" 
                                        ReadOnly="True" SortExpression="PowerSample2" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="PowerSample3" HeaderText="PowerSample3" 
                                        ReadOnly="True" SortExpression="PowerSample3" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="PowerValue1" HeaderText="PowerValue1" 
                                        ReadOnly="True" SortExpression="PowerValue1" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />  
                                    <asp:BoundField DataField="PowerValue2" HeaderText="PowerValue2" 
                                        ReadOnly="True" SortExpression="PowerValue2" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" /> 
                                    <asp:BoundField DataField="PowerValue3" HeaderText="PowerValue3" 
                                        ReadOnly="True" SortExpression="PowerValue3" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />  
                                   
                                   
                                    <asp:BoundField DataField="Haptic1" HeaderText="Haptic1" ReadOnly="True" 
                                        SortExpression="Haptic1" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Haptic2" HeaderText="Haptic2" ReadOnly="True" 
                                        SortExpression="Haptic2" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Haptic3" HeaderText="Haptic3" ReadOnly="True" 
                                        SortExpression="Haptic3" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                   
                                   
                                                        
                                    <asp:BoundField DataField="InspectedBy" HeaderText="InspectedBy" 
                                        ReadOnly="True" SortExpression="InspectedBy" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Shift" HeaderText="Shift" ReadOnly="True" 
                                        SortExpression="Shift" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" 
                                        SortExpression="Date" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" />
                                </Columns>
                       <HeaderStyle CssClass="grd_Header" />        
                     </asp:GridView>                       
                        
                        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
                            ContextTypeName="SoftLensDataContext" 
                            Select="new (LotNo, BlockingType, PowerSample1, Haptic3, Haptic2, Haptic1, PowerValue3, PowerValue2, PowerValue1, PowerSample3, PowerSample2, InspectedBy, Shift, Date)" 
                            TableName="HapticPowerTables">
                        </asp:LinqDataSource>
                        
                    </td>
                </tr>
            </table>
            </td>
           </tr>
          </table>         
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
