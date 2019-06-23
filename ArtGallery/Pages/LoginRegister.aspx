<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRegister.aspx.cs" Inherits="ArtGallery.Pages.LoginRegister" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/LoginRegister.js"></script>
	<link href="CSS/LoginRegister.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
      <div class='container'>
      <div class='top'>
        <a class='title'>ART-X</a>
        <a href='#' style='position: relative; top: -42px; left: 40px;'>WORKS</a>
        <a href='#' style='position: relative; top: -8px; right: 56px;'>ACCOUNT</a>
      </div>

      <div class='form' id='login'>
        <div class="mainForm" style='display: flex; flex-direction: row;'>
          <div class='title' style='margin-top: 40px;'>
            <asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
          </div>
          <div class='inputs' style='margin-left: -30px'>
            <asp:TextBox ID="txtLoginID" Placeholder="ID" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <asp:TextBox ID="txtLoginPassword" Placeholder="password" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
          </div>
        </div>
      </div>

      <div class='form' id='register'>
        <div class="mainForm">
          <div class='title' style='margin-top: 75px; margin-left: -30px;'>
            <asp:Button ID="btnRegister" runat="server" Text="REGISTER" OnClick="btnRegister_Click" />
          </div>
          <div class='inputs' style='margin-left: -65px;'>
			 <asp:TextBox ID="txtRegisterID" Placeholder="ID" runat="server" ></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <asp:TextBox ID="txtRegisterFname" Placeholder="first name" runat="server" ></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
			<asp:TextBox ID="txtRegisterLname" Placeholder="last name" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <asp:TextBox ID="txtRegisterEmail" Placeholder="email" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <asp:TextBox ID="txtRegisterPassword" Placeholder="password" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <asp:TextBox ID="txtRegisterPosition" Placeholder="position" runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
          </div>
        </div>
      </div>

    </div>
    </form>
</body>
</html>
