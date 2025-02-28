<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loginpage.aspx.cs" Inherits="Loginpage" Title="Login page"%>

<%@ Register namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
            
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        #txtUserName, #txtPassword{
border-radius: 25px;
padding: 13px;
width: 245px;
font-size: 18px;
text-align: center;
border: 2px solid #215292;
}
body{
    background-image: url(<%=ResolveClientUrl("~/images/bg.png")%>);
    background-repeat: repeat;
    
}
    </style>
    
            
</head>
<body style="margin: 5% 20%;">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers >
   <asp:PostBackTrigger ControlID = "btnLogin"/>
  
   </Triggers>
   <ContentTemplate>
        <table width="990" style="border: 2px solid darkblue;">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" width="100%" style="background-color: #fff;">
                        <tr>
                            <td align="center" style="width: 285px; height: 75px; padding-top: 3px;">
                                <img alt="" src="images/Phobic_logo.png" style="width: 271px; height: 75px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="left" style="width: 285px; height: 75px">
                                &nbsp;<img alt="AAlogo" src="images/appa_logo.png" style="width: 276px; height: 75px" /></td>
                        </tr>
                    </table>
                </td>
                </tr>
                    <tr>
                <td valign="middle" align="center" height="450" style="background-color: rgba(239, 249, 255, 0.81);">
                <div style="margin-top:-30px;"> 
                <p><asp:TextBox ID="txtUserName" runat="server" placeholder="User Name" required=""
                                                            MaxLength="30" ontextchanged="txtUserName_TextChanged" TabIndex="1" 
                                                            AutoPostBack="True"></asp:TextBox>
                                                </p>
                <p> <asp:TextBox ID="txtPassword" runat="server"  placeholder="Password" required=""
                                                            MaxLength="30" TabIndex="2" TextMode="Password" ontextchanged="txtPassword_TextChanged"></asp:TextBox>
                                                </p>
                                                 <p><asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/images/btn_login.png" 
                                                OnClick="btnLogin_Click" TabIndex="3" />
                                                </p>
                </div>
             </td>
            </tr>
                                <tr>
             <td align="center" bgcolor="#666666" style="padding: 5px; font-family: Arial; font-size: 9pt;
                    color: #FFFFFF;">
                    Copyright © 2010, Appasamy Associates. All rights reserved
                </td>
            </tr>
            </table>  
           </ContentTemplate>
           </asp:UpdatePanel>    
      
</div>
    </form>
</body>
</html>--%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta charset="utf-8">
<title>Login Page</title>
    <link href="CSS/login.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Button1_onclick() {

        }

// ]]>
    </script>
</head>
<body>

<div class="container">
<div style="margin-top: 10px; margin-left: 10px;">
<span style="float:left;"> <img alt="" src="images/Phobic_logo.png" style="width: 271px; height: 75px" /></span>
<span style="float:right;"> <img alt="AAlogo" src="images/appa_logo.png" style="width: 276px; height: 75px" /></span>
</div>
	<section id="content">
		<form id="Form1" runat="server">
			<h1>Login Form</h1>
			<div >
				<input type="text" placeholder="Username" required id="username" runat="server"/>
			</div>
			<div>
				<input type="password" placeholder="Password" required id="password" runat="server" />
			</div>
			<div>
			<input id="Button1" type="submit" value="Login" onserverclick="btnLogin_Click" runat="server" onclick="return Button1_onclick()" />
				</div>
		</form>
	</section><!-- content -->
	<div>
<span style="float: left;
font-family: Arial;
font-size: 13pt;
color: #000A7A;
margin-top: -75px; margin-left: 10px;"> Copyright © 2014, Appasamy Associates. All rights reserved</span>
<span style="float:right; margin-right: 10px; margin-top: -104px;"> <img alt="" src="images/erp_logo.png" /></span>
</div>
</div><!-- container -->
</body>
</html>
