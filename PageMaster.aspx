<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PageMaster.aspx.cs" Inherits="PageMaster" Title="Master Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                Master Form</td>
        </tr>
        <tr>
            <td style="padding-top: 3px">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="4" Width="100%"
                    CssClass="ajax__tab_technorati-theme" AutoPostBack="True" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged">
                    
                    <cc1:TabPanel runat="server" HeaderText="Power Details" ID="TabPanel1">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                                        Power Details
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="padding-top: 3px">
                                        <table class="con_table" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" CssClass="textlbl" Text="Power "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPower" runat="server" AutoPostBack="True" 
                                                        CssClass="textbox" OnTextChanged="txtPower_TextChanged" Width="175px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" CssClass="textlbl" Text="Radius1 "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRadius1" runat="server" CssClass="textbox" Width="175px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" CssClass="textlbl" Text="Radius2 "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRadius2" runat="server" CssClass="textbox" Width="175px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="center" colspan="3">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/btn_Add.png" 
                                                                    OnClick="btnAdd_Click" Visible="False" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnUpdate" runat="server" 
                                                                    ImageUrl="~/images/btn_update.png" OnClick="btnUpdate_Click" Visible="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6">
                                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                    </asp:ScriptManager>
                                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                                                        AutoGenerateColumns="False" BorderColor="#B1B1B1" BorderStyle="Solid" 
                                                        BorderWidth="1px" CellPadding="1" GridLines="None" 
                                                        OnPageIndexChanging="GridView1_PageIndexChanging" 
                                                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="70%">
                                                        <AlternatingRowStyle CssClass="AltRow" />
                                                        <RowStyle CssClass=" narmal_row" />
                                                        <Columns>
                                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" 
                                                                ShowSelectButton="True">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="Power" HeaderText="Power">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Radius1" HeaderText="Radius1">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Radius2" HeaderText="Radius2">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle Font-Bold="True" />
                                                        <HeaderStyle CssClass="grd_Header" Font-Bold="True" />
                                                        <PagerStyle CssClass="pager" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Model Details">
                        <HeaderTemplate>
                            Model Details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                                        Model Master
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 3px">
                                     
                                        <table class="con_table" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" CssClass="textlbl" Text="Model "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtModel" runat="server" CssClass="textbox" 
                                                        OnTextChanged="txtModel_TextChanged" Width="175px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="SubModel "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSubModel" runat="server" CssClass="textbox" Width="175px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" CssClass="textlbl" Text="BrandName "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBrandName" runat="server" CssClass="textbox" Width="175px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td align="center" colspan="3">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnAddModel" runat="server" 
                                                                    ImageUrl="~/images/btn_Add.png" OnClick="btnAddModel_Click" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnUpdateModel" runat="server" 
                                                                    ImageUrl="~/images/btn_update.png" OnClick="btnUpdateModel_Click" 
                                                                    Visible="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                                <td colspan="3">
                                                    <asp:GridView ID="gvModel" runat="server" AutoGenerateColumns="False" 
                                                        BorderColor="#B1B1B1" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" 
                                                        GridLines="None" OnSelectedIndexChanged="gvModel_SelectedIndexChanged" 
                                                        Width="100%">
                                                        <AlternatingRowStyle CssClass="AltRow" />
                                                        <Columns>
                                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" 
                                                                ShowSelectButton="True">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="Model" HeaderText="Model">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SubModel" HeaderText="SubModel">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BrandName" HeaderText="BrandName">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle CssClass="grd_Header" Font-Bold="True" />
                                                        <PagerStyle CssClass="pager" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="narmal_row" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    </asp:GridView>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                     
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="LathNo details">
                        <HeaderTemplate>
                            LathNo details
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="left" 
                                        style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                                        ToolId</td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 3px">
                                        <table class="con_table" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" CssClass="textlbl" Text="LatheNo "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLatheNo" runat="server" AutoPostBack="True" 
                                                        CssClass="textbox" OnTextChanged="txtLatheNo_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" CssClass="textlbl" Text="TooId "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtToolId" runat="server" CssClass="textbox"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnAddLatheNo" runat="server" 
                                                                    ImageUrl="~/images/btn_Add.png" OnClick="btnAddLatheNo_Click" Visible="False" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnUpdateLatheNo" runat="server" 
                                                                    ImageUrl="~/images/btn_update.png" OnClick="btnUpdateLatheNo_Click" 
                                                                    Visible="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:GridView ID="gvLathe" runat="server" AutoGenerateColumns="False" 
                                                        BorderColor="#B1B1B1" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" 
                                                        GridLines="None" OnSelectedIndexChanged="gvLathe_SelectedIndexChanged" 
                                                        Width="70%">
                                                        <AlternatingRowStyle CssClass="AltRow" />
                                                        <Columns>
                                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" 
                                                                ShowSelectButton="True">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="LatheNo" HeaderText="LatheNo">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ToolId" HeaderText="ToolId">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle CssClass="grd_Header" Font-Bold="True" />
                                                        <PagerStyle CssClass="pager" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="narmal_row" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
                        <HeaderTemplate>
                            <span>User Accounts</span>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table align="center" width="70%">
                                <tr>
                                    <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                                        User Accounts
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <table class="con_table" width="100%">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label13" runat="server" CssClass="textlbl" Text="UserName"></asp:Label>
                                                </td>
                                                <td width="200">
                                                    <asp:TextBox ID="txtUsername" runat="server" AutoPostBack="True" 
                                                        CssClass="textbox" OnTextChanged="txtUsername_TextChanged"></asp:TextBox>
                                                </td>
                                                <td width="125">
                                                    <asp:Label ID="lblSuccess" runat="server" ForeColor="#00CC66" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label14" runat="server" CssClass="textlbl" Text="Password"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" runat="server" AutoPostBack="True" 
                                                        CssClass="textbox"></asp:TextBox>
                                                    <cc1:PasswordStrength ID="txtPassword_PasswordStrength" runat="server" 
                                                        Enabled="True" PreferredPasswordLength="6" TargetControlID="txtPassword">
                                                    </cc1:PasswordStrength>
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnAddusrAdm" runat="server" 
                                                                    ImageUrl="~/images/btn_Add.png" OnClick="btnAddusrAdm_Click" Visible="False" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnChange" runat="server" 
                                                                    ImageUrl="~/images/btn_update.png" OnClick="btnChange_Click" Visible="False" />
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="btnClearChange" runat="server" 
                                                                    ImageUrl="~/images/btn_clear.png" OnClick="btnClearChange_Click" 
                                                                    Visible="False" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3">
                                                    <asp:GridView ID="gvUserAdmin" runat="server" AllowPaging="True" 
                                                        AutoGenerateColumns="False" BorderColor="#B1B1B1" BorderStyle="Solid" 
                                                        BorderWidth="1px" CellPadding="1" GridLines="None" 
                                                        OnSelectedIndexChanged="gvUserAdmin_SelectedIndexChanged" Width="50%">
                                                        <AlternatingRowStyle CssClass="AltRow" />
                                                        <Columns>
                                                            <asp:CommandField ButtonType="Image" HeaderText="Select" 
                                                                SelectImageUrl="~/images/select.PNG" ShowSelectButton="True">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="LoginName" HeaderText="UserName">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Password" HeaderText="Password">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="id" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle CssClass="grd_Header" Font-Bold="True" />
                                                        <PagerStyle CssClass="grd_Header" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="narmal_row" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    
                    
                    
                    <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Milling Lathe No">
                       <HeaderTemplate>
                            Milling Lathe No
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="left" 
                                        style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold;color: #FFFFFF; padding: 5px;">
                                        Milling Lathe No</td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 3px">
                                        <table class="con_table" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" CssClass="textlbl" Text="Milling Lathe No"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMillingno" runat="server" AutoPostBack="True" 
                                                        CssClass="textbox"></asp:TextBox>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="btnMillingAdd" runat="server" 
                                                                    ImageUrl="~/images/btn_Add.png" OnClick="btnMillingAdd_Click" />
                                                                <asp:ImageButton ID="btnMillingupdate" runat="server" 
                                                                    ImageUrl="~/images/btn_update.png" OnClick="btnMillingupdate_Click" 
                                                                    Visible="False" />
                                                                <asp:ImageButton ID="btnMillingClear" runat="server" 
                                                                    ImageUrl="~/images/btn_clear.png" OnClick="btnMillingClear_Click" 
                                                                    Width="93px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4">
                                                    <asp:GridView ID="dgvMilling" runat="server" AutoGenerateColumns="False" 
                                                        BorderColor="#B1B1B1" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" 
                                                        GridLines="None" OnSelectedIndexChanged="dgvMilling_SelectedIndexChanged" 
                                                        Width="37%">
                                                        <AlternatingRowStyle CssClass="AltRow" />
                                                        <Columns>
                                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/select.PNG" 
                                                                ShowSelectButton="True">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Center" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="MillingLatheNo" HeaderText="Milling Lathe No">
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="headeritem" HorizontalAlign="Center" />
                                                                <ItemStyle CssClass="itemstyle" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle CssClass="grd_Header" Font-Bold="True" />
                                                        <PagerStyle CssClass="pager" HorizontalAlign="Center" />
                                                        <RowStyle CssClass="narmal_row" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    
                    
                    
                </cc1:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
