<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" MasterPageFile="~/Pages/ArtGallery.Master" Inherits="ArtGallery.Pages.Payment" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" >
    <title>Art Gallery :: Payment</title>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
	<script src="JavaScript/Payment.js"></script>
	<link href="CSS/Payment.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto+Condensed&display=swap" rel="stylesheet">

        <div class='main'>
			<!-- ERROR MESSAGE -->
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="label errorMsg"></asp:Label>
            <asp:Button ID="btnSubmit" runat="server" Text="CONFIRM PAYMENT" OnClick="btnSubmit_Click" />
            <asp:TextBox ID="txtCardHolderName" placeholder='card holder name' runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <asp:TextBox ID="txtCardNo" placeholder='card no.' runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <asp:TextBox ID="txtExpDate" placeholder='exp. date' runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
            <asp:TextBox ID="txtCvv" placeholder='cvv' runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
			<asp:TextBox ID="txtAddress" placeholder='Delivery address' runat="server"></asp:TextBox>
            <img src='https://image.flaticon.com/icons/svg/3/3897.svg'>
        </div>

        <div class='cart'>

          <div class='left'>
            <a href='#'>BACK TO CART</a>
            <img src='https://i.imgur.com/DXquOBN.png'>
          </div>

          <div class='right'>
            <div class='text'>
              <a class='grey'>TOTAL</a>
              <asp:Label ID="lblTotalPrice" CssClass="label" runat="server" style='margin-left: 20px;'>RM 231</asp:Label>
            </div>
            <div class='text'>
              <a class='grey'>ITEMS</a>
              <asp:Label ID="lblTotalItems" CssClass="label" runat="server" style='margin-left: 25px;'>6 PCS</asp:Label>
            </div>
          </div>

        </div>
</asp:Content>