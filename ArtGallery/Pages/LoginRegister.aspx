<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRegister.aspx.cs" Inherits="ArtGallery.Pages.LoginRegister" %>

<%@ Import Namespace="ArtGallery.Classes" %>
<%@ Import Namespace="ArtGallery.Util" %> 

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/LoginRegister.js"></script>
	<link href="CSS/LoginRegister.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
      <div class='container'>
      <div class='top'>
        <a href='Home.aspx' class='title'>ART-X</a>
        <a href='AllGallery.aspx' style='position: relative; top: -42px; left: 40px;'>WORKS</a>
        <!--<a href='ArtistProfile.aspx?username=session' style='position: relative; top: -8px; right: 56px;'>ACCOUNT</a>-->
      </div>

      <div class='form' id='login'>
        <div class="mainForm" style='display: flex; flex-direction: row;'>
          <div class='title' style='margin-top: 40px;'>
            <asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
          </div>
          <div class='inputs' style='margin-left: -30px'>
            <asp:TextBox ID="txtLoginUsername" Placeholder="username" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'/>
            <asp:TextBox ID="txtLoginPassword" Placeholder="password" runat="server" TextMode="Password"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'/>
          </div>
        </div>
      </div>

      <div class='form' id='register'>
        <div class="mainForm">
          <div class='title' style='margin-top: 75px; margin-left: -30px;'>
            <asp:Button ID="btnRegister" runat="server" Text="REGISTER" OnClick="btnRegister_Click" />
          </div>
          <div class='inputs' style='margin-left: -65px;'>
            <asp:TextBox ID="txtRegisterUsername" Placeholder="username" runat="server" ></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'/>
			<asp:TextBox ID="txtRegisterDisplayName" Placeholder="display name" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'/>
            <asp:TextBox ID="txtRegisterEmail" Placeholder="email" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'/>
            <asp:TextBox ID="txtRegisterPassword" Placeholder="password" runat="server" TextMode="Password"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'/>
            <!--<asp:TextBox ID="txtRegisterPosition" Placeholder="position" runat="server"></asp:TextBox>-->
            <asp:DropDownList ID="ddlRegisterPosition" runat="server">
                <asp:ListItem>Artist</asp:ListItem>
                <asp:ListItem>Customer</asp:ListItem>
              </asp:DropDownList>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'/>
          </div>
        </div>
      </div>

    </div>
    </form>
</body>
</html>
