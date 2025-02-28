<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BtchforMould.aspx.cs" Inherits="BtchforMould" Title="Batch Allot" EnableSessionState="True"   %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
 



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnClear" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
        </Triggers>
        <ContentTemplate>
            <link href="/css/css.css" rel="stylesheet" type="text/css" runat="server" id="styleMain" visible="false" />
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px; text-align:left;">
                        BATCH ALLOT   
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <table width="100%" class="con_table">
                            <tr>
                               <%-- <td>
                                    <asp:Label ID="lbllotno" runat="server" Text="Lot No" CssClass="textlbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlotno" runat="server" CssClass="textbox" 
                                        AutoPostBack="true" ontextchanged="txtlotno_TextChanged"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:Label ID="lbllotno" runat="server" Text="Lot No" CssClass="textlbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtlotno" runat="server" CssClass="textbox" 
                                        AutoPostBack="true" ontextchanged="txtlotno_TextChanged"></asp:TextBox>

<%--
                                         <asp:DropDownList ID="txtlotno" runat="server" AutoPostBack="true" 
                                        AppendDataBoundItems="true" CssClass="textbox" onselectedindexchanged="txtlotno_SelectedIndexChanged"  Width="150px">

                                    </asp:DropDownList>--%>
                                </td>
                                <td>
                                    <asp:Label ID="lbldate" runat="server" CssClass="textlbl" Text="Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdate" runat="server" CssClass="textbox" AutoPostBack="true" Enabled="false"></asp:TextBox>
                                </td>                                   
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblshift" runat="server" Text="Shift" CssClass="textlbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpshift" runat="server" AutoPostBack="true" 
                                        AppendDataBoundItems="true" CssClass="dropdown" 
                                        onselectedindexchanged="drpshift_SelectedIndexChanged">
                                        <asp:ListItem>--Select--</asp:ListItem>
                                        <asp:ListItem>I</asp:ListItem>
                                        <asp:ListItem>II</asp:ListItem>
                                        <asp:ListItem>III</asp:ListItem>
                                          <asp:ListItem>GENERAL</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblslnid" runat="server" Text="Solution ID" CssClass="textlbl"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtslnid" runat="server" AutoPostBack="true" 
                                        CssClass="textbox" ontextchanged="txtslnid_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                              <td>
                                    <asp:Label ID="Label1" runat="server" CssClass="textlbl" Text="Brand"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drop_brand" runat="server" CssClass="dropdown" 
                                        AutoPostBack="true" AppendDataBoundItems="true" CausesValidation="True" onselectedindexchanged="drop_brand_SelectedIndexChanged" 
                                       >
                                    </asp:DropDownList>
                                </td>



                                <td>
                                    <asp:Label ID="lblmodel" runat="server" CssClass="textlbl" Text="Model"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpmodel" runat="server" CssClass="dropdown" 
                                        AutoPostBack="true" AppendDataBoundItems="true" 
                                        onselectedindexchanged="drpmodel_SelectedIndexChanged" 
                                        CausesValidation="True">
                                    </asp:DropDownList>
                                </td>
                               
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblQty" runat="server" CssClass="textlbl" Text="Quantity"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty" runat="server" CssClass="textbox" AutoPostBack="true" 
                                        ontextchanged="txtQty_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblapprvby" runat="server" CssClass="textlbl" Text="Approved By"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtapprvby" runat="server" CssClass="textbox" 
                                        AutoPostBack="true" ontextchanged="txtapprvby_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                             <td>
                                    <asp:Label ID="lblvolume" runat="server" CssClass="textlbl" Text="Volume(ml)"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtvolume" runat="server" CssClass="textbox" 
                                        AutoPostBack="true" ontextchanged="txtvolume_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                                     Visible="False" onclick="btnSave_Click" />
                                    &nbsp;<asp:ImageButton ID="btnUpdate" runat="server" ImageUrl="~/images/btn_update.png"
                                                     Visible="false" onclick="btnUpdate_Click" />
                                    &nbsp;<asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/images/btn_clear.png"
                                                     Visible="false" onclick="btnClear_Click" />
                                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                    </asp:ToolkitScriptManager>
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="false"
                                            BorderColor="#B1B1B1" HorizontalAlign="Center" Width="100%"
                                            BorderStyle="Solid" BorderWidth="1px" 
                                        onselectedindexchanged="gridview1_SelectedIndexChanged">
                                            <FooterStyle CssClass="footer" />
                                            <RowStyle CssClass="narmal_row" />
                                            <Columns>
                                                <asp:CommandField ButtonType="Image" HeaderText="Select" 
                                                        SelectImageUrl="~/images/select.PNG" ShowSelectButton="true" Visible="false" >                                                   
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="LotNo" HeaderText="Lot No" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Model" HeaderText="Model" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SolutionId" HeaderText="SolutionId" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Shift" HeaderText="Shift" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Volume" HeaderText="Volume" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                                                                DataFormatString="{0:dd/MM/yyyy}" >
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ApprovedBy" HeaderText="ApprovedBy" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                                        <HeaderStyle CssClass="headeritem" />
                                                        <ItemStyle CssClass="itemstyle" />
                                                </asp:BoundField>                                                
                                            </Columns>
                                            <PagerStyle CssClass="pager" />
                                            <SelectedRowStyle CssClass="selectedrow" />
                                            <HeaderStyle CssClass="grd_Header" />
                                            <AlternatingRowStyle CssClass="AltRow" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>              
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


