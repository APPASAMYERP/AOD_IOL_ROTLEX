<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frmPower.aspx.cs" Inherits="frmPower" Debug="true" Title="Power" %>


<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="JS/JScript.js"></script>

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

    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <div>
      <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
   <table cellpadding="0" cellspacing="0" width="100%">
   <tr>
    <td style="background-color: #00207D; font-family: Arial; font-size: 10pt; font-weight: bold; color: #FFFFFF; padding: 7px;">
    Rotlex Data Upload</td>
  </tr>
   <tr id="Buttons" runat="server">
     <td>
        <table width=100% class="con_table">
        <tr>
            <td align="right">
                <asp:Button ID="btnaps" runat="server" Text="NORMAL" 
                    onclick="btnaps_Click" /></td>        
            <td align="left">
                <asp:Button ID="btn_win" runat="server" Text="ROTLEX" onclick="btn_win_Click" style="height: 26px" 
                   />
                <asp:Label ID="Label14" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <%--   <asp:Button ID="Button23" runat="server" Text="WIN PRO" 
                    onclick="btnmoria_Click"/></td>--%>
        </tr>
       
        </table>
     </td>
  </tr>
     <tr id="Drop" runat="server"> 
   <td>   
       <%--<div id="Drop" runat="server">--%>
     <table width="100%" class="con_table">
    <%--  <tr>
        
        <td>
                <asp:Label ID="Label12" runat="server" Text="Choose Reflot No : " ></asp:Label>
        </td>
        
      <td>
                 <asp:DropDownList ID="Droplotno1" runat="server" style="width: 155px;"
          
                    AppendDataBoundItems="True" AutoPostBack="True" CssClass="dropdown">         
               </asp:DropDownList>   
        </td>
        
        </tr>--%>
    <tr>
    <td style="width:80px"></td>
    <td ><asp:Label ID="Label7" runat="server" CssClass="textlbl" Font-Bold="False" Text="Brand Name"></asp:Label></td>
     <td style="padding-top: 3px">
       <asp:DropDownList ID="DropDownList1" runat="server" style="width: 155px;"
           onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AppendDataBoundItems="True" AutoPostBack="True" CssClass="dropdown">         
       </asp:DropDownList>      
     </td>
     <td>
     <asp:UpdatePanel ID="Upanel" runat="server">
    <ContentTemplate>
     <asp:FileUpload ID="FileUpload1" runat="server" />
  
      
     </ContentTemplate>
    </asp:UpdatePanel>
     </td>
     <td>
         <asp:Label ID="LBLTYPE" runat="server" Text="Type"></asp:Label>
     <asp:DropDownList ID="droptyp" runat="server" Height="22px" Width="88px" 
             AppendDataBoundItems ="true" AutoPostBack ="true" 
             onselectedindexchanged="droptyp_SelectedIndexChanged" >
     <asp:ListItem >--Select--</asp:ListItem>
        </asp:DropDownList></td>
    </tr>  
    <tr>
    <td><asp:Button ID="btnclo" runat="server" Text="Close" onclick="btnclo_Click" /></td>
    
      
          <td align="center">
        <asp:Button ID="Button4" runat="server" Text="Deletion" OnClick="LinkButton2_Click" 
                  Visible="False" /> 
    </td>      
    <td align="right">     
        <asp:UpdatePanel ID="Upl" runat="server" UpdateMode="Conditional">
        <Triggers><asp:PostBackTrigger ControlID="Button2" /></Triggers>
        <ContentTemplate>
          <asp:Button ID="Button2" runat="server" Text="DataUpload" 
                OnClick="Linkbutton1_Click"  OnClientClick="showProgress()" Height="26px"/>


           <asp:Button ID="Win_btn" runat="server" Text="DataUpload_PRO"  
                OnClientClick="showProgress()" Height="26px" onclick="Win_btn_Click"/>
           </ContentTemplate>
 
</asp:UpdatePanel>     
      </td>
      <td align="center">
        <asp:Button ID="Button17" runat="server" Text="Existing" onclick="Button17_Click" 
              Visible="False" />
    </td> 
    <td align="center">
        <asp:Button ID="Button5" runat="server" Text="Glassy Updation" 
            onclick="Button5_Click" Visible="false"  />
    </td>
    </tr>
    </table>
       <%--   </div> --%>
   </td>
   </tr>
   <tr>
   <td>  
    <div id="btn" runat="server"> 
    <table align="center" class="con_table" width="100%">
      <tr>   
           <td >
           <asp:Button ID="ImageButton4" runat="server" Text="Save" /></td>
              
            <td>
                <asp:Button ID="ImageButton1" runat="server" Text="Clear" OnClick="ImageButton1_Click"/>
                </td>
        </tr> 
        <tr>
            <td>
                <asp:GridView ID="GridView5" runat="server" BorderColor="#B1B1B1" Width="100%" 
                    BorderStyle="Solid" BorderWidth="1px" AutoGenerateColumns="False" >
                   
                    <FooterStyle CssClass="footer" />
                       <RowStyle CssClass="narmal_row" />
                    <Columns>
                        <asp:TemplateField HeaderText="Brand_Name" SortExpression="Brand_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model_Name" SortExpression="Model_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Model_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Model_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Power" SortExpression="Power">
                            <ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Power") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Power") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RefLot" SortExpression="RefLot">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("RefLot") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("RefLot") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pager" />
            <SelectedRowStyle CssClass="selectedrow" />
            <HeaderStyle CssClass="grd_Header" />
            <AlternatingRowStyle CssClass="AltRow" />
                </asp:GridView>
           </td>
        </tr> 
      </table>
    </div>
    </td>
    </tr>
    <tr>
    <td>    
    <div>
        <table>
        </table>       
    </div>
    </td>
    </tr>
    <tr>
    <td align="left" style="padding-top: 3px">
     <div id="Del" runat="server">
     <table align="center" class="con_table" width="100%">
       <tr>
       <td style="width:119px"></td>   
          
        <td style="width:19px" ><asp:Label ID="lbllot" runat="server" CssClass="textlbl" Text="LotNo"></asp:Label></td>
        
        <td style="width:200px" ><asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="dropdown">
        </asp:DropDownList></td>
        <td >
            <asp:Button ID="ImageButton3" runat="server" Text="Search" OnClick="Button2_Click" />
           </td>
        </tr>
        <tr>
        <td align="center" class="style28" colspan="4">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
        BorderColor="#B1B1B1" Width="100%" BorderStyle="Solid" BorderWidth="1px">
        <FooterStyle CssClass="footer" />
         <RowStyle CssClass="narmal_row" />
        <Columns>
                <asp:TemplateField HeaderText="Brand_Name">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Brand_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Brand_Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Model_Name">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Model_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Model_Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Power">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Power") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Power") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Qty") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RefLot">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("RefLot") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("RefLot") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("Status") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Process">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="pager" />
            <SelectedRowStyle CssClass="selectedrow" />
            <HeaderStyle CssClass="grd_Header" />
            <AlternatingRowStyle CssClass="AltRow" />
    </asp:GridView>
    </td>
    </tr>
    <tr>
    <td></td>
    <td></td>
        <td align="right">
            <asp:Button ID="Button3" runat="server" Text="Delete" onclick="Button3_Click"></asp:Button></td>
            
        <td><asp:Button ID="Button1" runat="server" Text="Back" OnClick="ImageButton1_Click" /></td> 
     </tr>
     </table>
    </div>
     <div id="Update" runat="server">
     <table width="100%" class="con_table">
     <tr>
     <td>
         <asp:Label ID="Label11" runat="server" CssClass="textlbl" Font-Bold="False" Text="LotNo"></asp:Label></td>
        <td align="center"><asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" CssClass="dropdown" AppendDataBoundItems="true">
        </asp:DropDownList></td>
         <td><asp:Button ID="ImageButton2" runat="server" Text="Search" onclick="Button4_Click" /></td>
      </tr> 
      <tr>
      <td align="center" class="style28" colspan="4">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            OnRowEditing="Gridview2_Edit" OnRowUpdating="Gridview2_Update" OnRowCancelingEdit="Gridview2_Cancel"
            DataKeyNames="id" BorderColor="#B1B1B1" Width="100%" BorderStyle="Solid" 
              BorderWidth="1px" >
            <FooterStyle CssClass="footer" />
         <RowStyle CssClass="narmal_row" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TumblingNo" SortExpression="TumblingNo">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("TumblingNo") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TumblingNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Power" SortExpression="Power">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Power") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Power") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="GlassyRecordRef" 
                    SortExpression="GlassyRecordRef">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("GlassyRecordRef") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("GlassyRecordRef") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns> 
           <PagerStyle CssClass="pager" />
            <SelectedRowStyle CssClass="selectedrow" />
            <HeaderStyle CssClass="grd_Header" />
            <AlternatingRowStyle CssClass="AltRow" />

        </asp:GridView>
        </td> 
        </tr> 
        <tr>
            <td align="center">
                <asp:Button ID="Button16" runat="server" Text="Back" onclick="Button16_Click" /></td>
        </tr>  
        </table>    
    </div>
     </td>
   </tr>
   <tr id="Drop1" runat="server">
   <td>       
     <table width="100%" class="con_table">
    <tr>
    <td style="width:80px"></td>
    <td ><asp:Label ID="Label13" runat="server" CssClass="textlbl" Font-Bold="False" Text="Brand Name"></asp:Label></td>
     <td style="padding-top: 3px">
       <asp:DropDownList ID="DropDownList9" runat="server" style="width: 155px;"
           onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            AppendDataBoundItems="True" AutoPostBack="True" CssClass="dropdown">         
       </asp:DropDownList>      
     </td>
     <td><asp:FileUpload ID="FileUpload2" runat="server" /></td>
    </tr> 
   
    <tr>
    <td><asp:Button ID="btnclose" runat="server" Text="Close" 
            onclick="btnclose_Click" /></td>
     <td align="center">
        <asp:Button ID="Button7" runat="server" Text="Deletion" OnClick="Button7_Click" 
                  Height="26px" /> 
    </td>
      <td align="right">     
          <asp:Button ID="Button6" runat="server" Text="DataUpload" 
              OnClick="Button6_Click" style="height: 26px" />       
      </td>   
    
     <td align="center">
        <asp:Button ID="Button18" runat="server" Text="Existing" onclick="Button18_Click" />
    </td>  
    <td>
        <asp:Button ID="Button8" runat="server" Text="Glassy Updation" 
            onclick="Button8_Click" Visible="false" />
    </td>
    </tr>
    </table>     
  </td>
  </tr>
  <tr>
    <td>
        <div id="btn1" runat="server"> 
    <table align="center" class="con_table" width="100%">
      <tr>   
           <td >
           <asp:Button ID="Button9" runat="server" Text="Save"/></td>
              
            <td>
                <asp:Button ID="Button10" runat="server" Text="Clear" OnClick="Button10_Click"/>
                </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView6" runat="server" BorderColor="#B1B1B1" Width="100%" 
                    BorderStyle="Solid" BorderWidth="1px" AutoGenerateColumns="False"> 
                    
                   
                    <FooterStyle CssClass="footer" />
                       <RowStyle CssClass="narmal_row" />
                    <Columns>
                        <asp:TemplateField HeaderText="Brand_Name" SortExpression="Brand_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Model_Name" SortExpression="Model_Name">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Model_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Model_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Power" SortExpression="Power">
                            <ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Power") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Power") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RefLot" SortExpression="RefLot">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("RefLot") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("RefLot") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="headeritem" />
                            <ItemStyle CssClass="itemstyle" />
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pager" />
            <SelectedRowStyle CssClass="selectedrow" />
            <HeaderStyle CssClass="grd_Header" />
            <AlternatingRowStyle CssClass="AltRow" />
                </asp:GridView>
           </td>
        </tr>  
      </table>
    </div>
    </td>
  </tr>
   <tr>
    <td>    
    <div>
        <table>
        </table>       
    </div>
    </td>
    </tr>
    <tr>
    <td align="left" style="padding-top: 3px">
     <div id="Del1" runat="server">
     <table align="center" class="con_table" width="100%">
       <tr>
       <td style="width:119px"></td>   
          
        <td style="width:19px" ><asp:Label ID="Label9" runat="server" CssClass="textlbl" Text="LotNo"></asp:Label></td>
        
        <td style="width:200px" ><asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="true" AppendDataBoundItems="true" CssClass="dropdown">
        </asp:DropDownList></td>
        <td >
            <asp:Button ID="Button11" runat="server" Text="Search" OnClick="Button11_Click" />
           </td>
        </tr>
        <tr>
        <td align="center" class="style28" colspan="4">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false"
        BorderColor="#B1B1B1" Width="100%" BorderStyle="Solid" BorderWidth="1px">
        <FooterStyle CssClass="footer" />
         <RowStyle CssClass="narmal_row" />
        <Columns>
                <asp:TemplateField HeaderText="Brand_Name">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Brand_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Brand_Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Model_Name">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Model_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("Model_Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Power">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Power") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Power") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Qty") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RefLot">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("RefLot") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("RefLot") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("Status") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Process">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="pager" />
            <SelectedRowStyle CssClass="selectedrow" />
            <HeaderStyle CssClass="grd_Header" />
            <AlternatingRowStyle CssClass="AltRow" />
    </asp:GridView>
    </td>
    </tr>
    <tr>
    <td></td>
    <td></td>
        <td align="right">
            <asp:Button ID="Button13" runat="server" Text="Delete" onclick="Button13_Click"></asp:Button></td>
            
        <td><asp:Button ID="Button12" runat="server" Text="Back" OnClick="Button12_Click" /></td> 
     </tr>
     </table>
    </div>
     <div id="Update1" runat="server">
     <table width="100%" class="con_table">
     <tr>
     <td>
         <asp:Label ID="Label10" runat="server" CssClass="textlbl" Font-Bold="False" Text="LotNo"></asp:Label></td>
        <td align="center"><asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="true" CssClass="dropdown" AppendDataBoundItems="true">
        </asp:DropDownList></td>
         <td><asp:Button ID="Button14" runat="server" Text="Search" onclick="Button14_Click" /></td>
      </tr> 
      <tr>
      <td align="center" class="style28" colspan="4">
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
            OnRowEditing="Gridview4_Edit" OnRowUpdating="Gridview4_Update" OnRowCancelingEdit="Gridview4_Cancel"
            DataKeyNames="id" BorderColor="#B1B1B1" Width="100%" BorderStyle="Solid" 
              BorderWidth="1px" >
            <FooterStyle CssClass="footer" />
         <RowStyle CssClass="narmal_row" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                            CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                            CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TumblingNo" SortExpression="TumblingNo">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("TumblingNo") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("TumblingNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Power" SortExpression="Power">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Power") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Power") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="GlassyRecordRef" 
                    SortExpression="GlassyRecordRef">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("GlassyRecordRef") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("GlassyRecordRef") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="headeritem" />
                    <ItemStyle CssClass="itemstyle" />
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns> 
           <PagerStyle CssClass="pager" />
            <SelectedRowStyle CssClass="selectedrow" />
            <HeaderStyle CssClass="grd_Header" />
            <AlternatingRowStyle CssClass="AltRow" />

        </asp:GridView>
        </td> 
        </tr> 
        <tr>
            <td align="center">
                <asp:Button ID="Button15" runat="server" Text="Back" onclick="Button15_Click" /></td>
        </tr>  
        </table>    
    </div>
     </td>
   </tr>
    <tr id="Exist" runat="server">
      <td>
        <div>
            <table align="center" class="con_table" width="100%">
                <tr>
                    <td align="right"> <asp:Label ID="Label8" runat="server" CssClass="textlbl" Text="LotNo"></asp:Label></td>
                    <td align="center"><asp:DropDownList ID="DropDownList4" runat="server"
                     AutoPostBack="true" AppendDataBoundItems="true" CssClass="dropdown">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button21" runat="server" Text="Search"  onclick="ImageButton5_Click" /></td>
                </tr>
                <tr>
                    <td align="center" class="style28" colspan="4">
                        <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false"
                        BorderColor="#B1B1B1" Width="100%" BorderStyle="Solid" BorderWidth="1px">
                        <FooterStyle CssClass="footer" />  
                        <RowStyle CssClass="narmal_row" />                         
                            <Columns>
                                <asp:TemplateField HeaderText="Brand_Name" SortExpression="Brand_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                    <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Model_Name" SortExpression="Model_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Model_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                     <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Model_Name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Power" SortExpression="Power">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Power") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                    <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Power") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                    <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RefLot" SortExpression="RefLot">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("RefLot") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                    <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("RefLot") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                     <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pager" />
                            <SelectedRowStyle CssClass="selectedrow" />
                            <HeaderStyle CssClass="grd_Header" />
                            <AlternatingRowStyle CssClass="AltRow" />
                        </asp:GridView>                       
                    </td>
                </tr>
                <tr>
                    <td align="center"><asp:Button ID="Button19" runat="server" Text="Back" 
                            onclick="Button9_Click1" /></td>
                </tr>
            </table>
        </div>
      </td>
   </tr>  
   <tr id="Exist1" runat="server"> 
         <td>
        <div>
            <table align="center" class="con_table" width="100%">
                <tr>
                    <td align="right"> <asp:Label ID="lblno" runat="server" CssClass="textlbl" Text="LotNo"></asp:Label></td>
                    <td align="center"><asp:DropDownList ID="DropDownList7" runat="server"
                     AutoPostBack="true" AppendDataBoundItems="true" CssClass="dropdown">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button22" runat="server" Text="Search" onclick="ImageButton6_Click" /></td>
                </tr>
                <tr>
                    <td align="center" class="style28" colspan="4">
                        <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false"
                        BorderColor="#B1B1B1" Width="100%" BorderStyle="Solid" BorderWidth="1px">
                        <FooterStyle CssClass="footer" />  
                        <RowStyle CssClass="narmal_row" />                         
                            <Columns>
                                <asp:TemplateField HeaderText="Brand_Name" SortExpression="Brand_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                    <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Brand_Name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Model_Name" SortExpression="Model_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Model_Name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                     <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Model_Name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Power" SortExpression="Power">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Power") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                    <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Power") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty" SortExpression="Qty">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Qty") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                    <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Qty") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RefLot" SortExpression="RefLot">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("RefLot") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                    <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("RefLot") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="headeritem" />
                                     <ItemStyle CssClass="itemstyle" />
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pager" />
                            <SelectedRowStyle CssClass="selectedrow" />
                            <HeaderStyle CssClass="grd_Header" />
                            <AlternatingRowStyle CssClass="AltRow" />
                        </asp:GridView>                       
                    </td>
                </tr>
                <tr>
                    <td align="center"><asp:Button ID="Button20" runat="server" Text="Back" 
                            onclick="Button11_Click1" /></td>
                </tr>
            </table>
        </div>
      </td>
   </tr>
   </table>
  </div>
  
<asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Upl">
<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-left: 830px;margin-top:300px;opacity: 1;-moz-opacity: 1;">
    <img alt=""  src="images/hourglass (1).gif" />
     <p style="visibility:visible;" id="imagee" >
<asp:Label ID="imagee" runat="server" Text="Saving Plz Wait..." style="font-size:15pt; font-weight:bolder;color:#000000;"></asp:Label></p>
</div>
</ProgressTemplate>
</asp:UpdateProgress>
  </asp:Content>
 

