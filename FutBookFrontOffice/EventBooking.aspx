﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBooking.aspx.cs" Inherits="FutBookFrontOffice.EventBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <!-- jQuery -->

    <!-- jQuery UI -->
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
   
    <title>FutBook</title>
</head>

<body style="background-color: #ed3b3b;">

    <nav class="navbar navbar-expand-sm navbar-dark fixed-top">
        <!-- Brand -->
        <a class="navbar-brand" href="Default_aut.aspx">FUTBOOK</a>

        <!-- Links -->
        <ul class="navbar-nav">
            <li class="nav-item">
                <asp:HyperLink ID="hypShop" runat="server" class="nav-link" NavigateUrl="~/ShopHome.aspx">SHOP</asp:HyperLink>
            </li>

            <!-- Dropdown -->
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">BOOKINGS
                </a>
                <div class="dropdown-menu">
                    <a class="dropdown-item" href="#">PITCH</a>
                    <a class="dropdown-item" href="#">EVENT</a>
                </div>
            </li>

            <li class="nav-item">
                <asp:HyperLink ID="hypSignUp" runat="server" class="nav-link" NavigateUrl="~/Registration.aspx">SIGN UP</asp:HyperLink>
            </li>

            <li class="nav-item">
                <asp:HyperLink ID="hypSignIn" runat="server" class="nav-link" NavigateUrl="~/SignIn.aspx">SIGN IN</asp:HyperLink>
            </li>

            <li class="nav-item ml-auto">
                <asp:HyperLink ID="hypSignOut" runat="server" class="nav-link" NavigateUrl="~/SignOut.aspx">SIGN OUT</asp:HyperLink>
            </li>


        </ul>
    </nav>
    <br />


    <div class="logo">
        <img src="IMG/logoFutBook.png" />
    </div>


    <div class="container min-vh-100">
        <div class="row" style="border: none; margin-left: 0px; margin-top: 40px; color: #ffffff">
            <div class="col">
                <h1 class="text-center">Booking Events Page</h1>

                <br />
                <p> Welcome to our booking events page, where you can easily book your upcoming event. Our page features a simple and intuitive form that allows you to enter all the necessary event details, including the event name, email address, date, and number of participants. We understand the importance of choosing the right date for your event, which is why our date field comes equipped with a calendar picker, making it easy for you to select your preferred date. To help you budget for your event, our page also includes a pricing calculator that automatically calculates the price per person and total price based on the number of participants you select. Please note that the minimum number of participants is <b>2</b> and the maximum number of participants is <b>30</b>. If you require more than 30 participants, please contact us directly to discuss your options. Our booking events page is designed to be easy to use, providing you with a seamless experience from start to finish.</p>

            </div>


            <img src="IMG/pexels-askar-abayev-5638732.jpg" class="img-fluid w-50 mr-3 mb-5 " alt="80">


            <div class="container min-vh-100">
      <div class="row" style="border: none; margin-left: 0px; margin-top:40px; width:50%; ">
                    <div class="col">
                        <h2>Event Booking</h2>
                        <form runat="server">
                            <div class="form-group">
                                <label for="lblEmail">Email address</label>
                                <asp:TextBox class="form-control" id="idEmail" runat="server" aria-describedby="emailHelp" placeholder="Enter email"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblFirstName">First name</label>
                                <asp:TextBox class="form-control" id="idFirstName" runat="server" placeholder="Enter first name"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblSurname">Surname</label>
                                <asp:TextBox class="form-control" id="idSurname" runat="server" placeholder="Enter surname"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="lblNumParticipants">Number of participants</label>
                                <asp:TextBox class="form-control" id="idNumParticipants" runat="server" placeholder="Enter Number of participants"></asp:TextBox>
                            </div>

<%--                                      <div class="form-group">
                                <label for="lblPricePerPerson">Price per person</label>
                                <asp:TextBox class="form-control" id="PricePerPerson" runat="server" placeholder="Price Per Person"></asp:TextBox>
                            </div>
                            --%>
                            <asp:Button ID="btnBookEvent" runat="server" Text="Book Event" OnClick="btnBookEvent_Click" class="btn btn-primary"/>
                            
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </form>

        </div>
    </div>

    <div class="footer-pad">
        <p class="text-center">© FUTBOOK 2023 </p>
    </div>
</body>
</html>

 