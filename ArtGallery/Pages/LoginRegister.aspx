<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginRegister.aspx.cs" Inherits="ArtGallery.Pages.LoginRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<link href="CSS/LoginRegister.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <div class='container'>
      <div class='top'>
        <a class='title'>ART-X</a>
        <a style='position: relative; top: -42px; left: 40px;'>WORKS</a>
        <a style='position: relative; top: -8px; right: 75px;'>ACCOUNT</a>
      </div>

      <div class='form' id='login'>
        <div class="mainForm" style='display: flex; flex-direction: row;'>
          <div class='title' style='margin-top: 52px;'>
            <input type='submit' value='LOGIN'>
          </div>
          <div class='inputs' style='margin-left: -30px'>
            <input type='text' name='username' placeholder='username'>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <input type='password' name='password' placeholder='password'>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
          </div>
        </div>
      </div>

      <div class='form' id='register'>
        <div class="mainForm">
          <div class='title' style='margin-top: 90px; margin-left: -30px;'>
            <input type='submit' value='REGISTER'>
          </div>
          <div class='inputs' style='margin-left: -65px;'>
            <input type='text' name='username' placeholder='username'>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <input type='text' name='email' placeholder='email'>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <input type='password' name='password' placeholder='password'>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <input type='text' name='position' placeholder='position'>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
          </div>
        </div>
      </div>

    </div>
    </form>
</body>
</html>
