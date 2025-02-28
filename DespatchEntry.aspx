<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DespatchEntry.aspx.cs" Inherits="DespatchEntry" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <script language="javascript">
var altKey = false;
var keyCode = 0;

function closeSession(evt){

evt = (evt) ? evt : event;

clickY = evt.clientY;
altKey = evt.altKey;
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

alert('The Browser Will exit');
//// simply leaving the page via a link

} else {
//alert('close 3');
return void(0);
}
}
}

function whatKey(evt){
evt = (evt) ? evt : event;
keyVals = document.getElementById('ffKeyTrap');
altKey = evt.altKey;
keyCode = evt.keyCode;
if(altKey && keyCode == 115){
keyVals.value = String(altKey) + String(keyCode);
}
}

window.onkeydown = whatKey;
window.onbeforeunload = closeSession;
    </script>
  
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   
    <ContentTemplate>
  
    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="background-color: #666666; font-family: Arial; font-size: 9pt; font-weight: bold; color: #FFFFFF; padding: 5px;">
                                Despatch Entry</td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top: 3px">
                                
                               <table class="style1">
        <tr>
            <td>
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                    Width="100%" AutoPostBack="True" 
                    onactivetabchanged="TabContainer1_ActiveTabChanged">
                    <cc1:TabPanel runat="server" HeaderText="Outward Transcation" ID="TabPanel1">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td colspan="2">
                                        Dc No
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtDCNo" runat="server" AutoPostBack="True" OnTextChanged="txtDCNo_TextChanged"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtDCNo_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtDCNo">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td colspan="2">
                                        Dc Date
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtDcDate" runat="server"></asp:TextBox><cc1:CalendarExtender ID="txtDcDate_CalendarExtender"
                                            runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtDcDate">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;To
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtToAddress" runat="server"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        Mode of&#160; Despatch
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtModeofDespatch" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Address</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        Your Order ref No</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtOrderRefNo" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Indent No</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtIndentNo" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtIndentNo_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtIndentNo">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td colspan="2">
                                        Remarks
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtRemarks" runat="server" AutoPostBack="True" 
                                            CssClass="textbox_200"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtRemarks_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterMode="InvalidChars" FilterType="Numbers" 
                                            InvalidChars="123456789" TargetControlID="txtRemarks">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        No of Packing</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtNoofPacking" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtNoofPacking_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtNoofPacking">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                    <td colspan="2">
                                        Trans Date
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtTransDate" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        Model
                                    </td>
                                    <td colspan="2">
                                        SubModel
                                    </td>
                                    <td>
                                        Brand
                                    </td>
                                    <td>
                                        Power
                                    </td>
                                    <td colspan="2">
                                        Stock
                                    </td>
                                    <td>
                                        Quantity
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlModel" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlSubModel" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlSubModel_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBrand" runat="server" EnableViewState="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPower" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlPower_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtStock" runat="server" EnableViewState="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRequiredQty" runat="server"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtRequiredQty_FilteredTextBoxExtender" 
                                            runat="server" Enabled="True" FilterType="Numbers" 
                                            TargetControlID="txtRequiredQty">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="8">
                                        <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/btn_Add.png" 
                                            OnClick="btnAdd_Click" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="8">
                                        <asp:GridView ID="gvDespatch" runat="server" OnRowCancelingEdit="gvUpdate_RowCancelingEdit"
                                            OnRowEditing="gvUpdate_RowEditing" OnRowUpdating="gvUpdate_RowUpdating" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Model">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Model") %>'></asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Model") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SubModel">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("SubModel") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("SubModel") %>'> </asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Brand">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Brand") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("Brand") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Power">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Power") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("Power") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("Quantity") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("Quantity") %>'> </asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="LotNo" HeaderText="LotNo" />
                                                <asp:TemplateField HeaderText="RefID" Visible="False">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("RefID") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("RefID") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Type" HeaderText="Type" Visible="False" />
                                            </Columns>
                                        </asp:GridView>
                                        <asp:GridView ID="gvUpdate" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvUpdate_RowCancelingEdit"
                                            OnRowEditing="gvUpdate_RowEditing" OnRowUpdating="gvUpdate_RowUpdating">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Model">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Model") %>'></asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Model") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SubModel">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SubModel") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("SubModel") %>'> </asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Brand">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Brand") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Brand") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Power">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Power") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Power") %>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Quantity") %>'> </asp:TextBox></EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Quantity") %>'> </asp:Label></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/gvCancel.png" EditImageUrl="~/images/gvedit.png"
                                                    HeaderText="Update" ShowEditButton="True" UpdateImageUrl="~/images/gvUpdate.png" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="8">
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/btn_save.png" 
                                            OnClick="btnSave_Click" Visible="False" /><asp:ImageButton
                                            ID="btnUpdate" runat="server" ImageUrl="~/images/btn_update.png" 
                                            OnClick="btnUpdate_Click" Visible="False" /><asp:ImageButton
                                                ID="btnClear" runat="server" ImageUrl="~/images/btn_clear.png" 
                                            OnClick="btnClear_Click" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &#160;
                                    </td>
                                    <td colspan="2">
                                        &#160;
                                    </td>
                                    <td colspan="2">
                                        &#160;
                                    </td>
                                    <td colspan="2">
                                        &#160;
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Search">
                        <ContentTemplate>
                            <table class="style1">
                                <tr>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Search Code
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearchBox" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" 
                                            ImageUrl="~/images/btn_search.png" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="btnViewAll" runat="server" OnClick="btnViewAll_Click" 
                                            ImageUrl="~/images/btn_viewall.png" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                    <td>
                                        &#160;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="DCNO" HeaderText="DCNO" />
                                                <asp:BoundField DataField="DcDate" HeaderText="DcDate" 
                                                    DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField DataField="ToName" HeaderText="To" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
    </table>
                                
                            </td>
                        </tr>
                    </table>
    
    </ContentTemplate>
     </asp:UpdatePanel>
</asp:Content>
