<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ReportFinal.aspx.cs" Inherits="ReportFinal" Title="BatchReport"%>

<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
--%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="nav" width="100%">
 <tr>
            <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;" 
                align="left">PROCESS REPORT</td>
        </tr>
        <tr>
       <td style="padding-top: 3px">
                <table class="con_table" width="100%">
                    <tr>
                    <td style="height: 31px" align="center">
                     <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Phobic Id : " 
                                Width="60px" Height="16px"></asp:Label>                                                              
                       <asp:TextBox ID="txtPhobicId" runat="server" ontextchanged="txtLotno_TextChanged" 
                            AutoPostBack="True"></asp:TextBox>                 
                       <asp:ImageButton ID="btnGenerate" runat="server" 
                            ImageUrl="~/images/btn_Generate.png" Visible="false" 
                            onclick="btnGenerate_Click"/>
                       <asp:ImageButton ID="btnHome" runat="server" BorderColor="#990000" 
                            ImageUrl="~/images/btn_home_icon.png" onclick="btnHome_Click" />
                      </td>             
                     </tr>
                    <%-- <tr>
                     <td style="height: 31px">
                         &nbsp;</td>
                     </tr>--%>
                     <tr>                    
                     <td>
                     <asp:GridView ID="gvBatchAllot" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="Black" BackColor="#CCCCCC" 
                    BorderColor="#2461BF" BorderStyle="Solid" BorderWidth="3px" CellSpacing="2" 
                    Width="100%">
                    <RowStyle BackColor="White" />
                    <Columns>                        
                       <%-- <asp:BoundField DataField="Date" HeaderText="Date" 
                            DataFormatString="{0:dd/MM/yyyy}" />   --%><asp:BoundField 
                            DataField="PhobicId" HeaderText="PhobicId" />
                        <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                        <asp:BoundField DataField="Model" HeaderText="Model" />
                        <asp:BoundField DataField="Power" HeaderText="Power" />
                        <asp:BoundField DataField="AcceptedQty" HeaderText="AcceptedQty" />                        
<asp:BoundField DataField="RejectedQty" HeaderText="RejectedQty"></asp:BoundField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>                
                     </td>
                     </tr>
                 </table>
       </td>
       </tr>
        

</table>

</asp:Content>




