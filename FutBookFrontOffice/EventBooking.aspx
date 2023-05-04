<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBooking.aspx.cs" Inherits="FutBookFrontOffice.EventBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" />
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>

    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <!-- jQuery UI -->
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>


    <script>
    function updatePrice() {
        var participants = document.getElementById('Participants').value;
        var price = participants * 20;
        document.getElementById('lblPrice').innerHTML = "Total Price: £" + price;
    }
    </script>

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

        <asp:Label ID="lblGreeting" runat="server" class="nav-link ml-auto lblGreeting"></asp:Label>


    </nav>
    <br />


    <div class="logo">
        <img src="IMG/logoFutBook.png" />
    </div>


    <div class="container min-vh-100">

                <div class="col-12 mt-4 text-center">
            <h2 class="text-white">Booking Events Page</h2>
        </div>
        
            <div class="row" style="border: none; margin-top:40px; ">

                

                    <div class="col-lg-5">
                        





                        <form runat="server">
                            <div class="form-group">
                                <label for="lblEventName">Event Name</label>
                                <asp:TextBox class="form-control" id="EventName" runat="server" placeholder="Enter event name"></asp:TextBox>
                            </div>


                            <div class="form-group">
                                <label for="lblParticipants">Participants</label>
                                <input type="number" class="form-control" id="Participants" runat="server" min="3" max="50" step="2" value="2" oninput="updatePrice()" />
                            </div>

                            <div class="form-group">
                                <label id="lblPrice" class="font-weight-bold">Total Price: £20</label>
                            </div>




                            <div class="form-group">
                                <label for="lblDate">Date</label>
<%--                                <asp:TextBox class="form-control" id="EventDate" runat="server" placeholder="Select date" type="date"></asp:TextBox>--%>
                                <asp:Calendar id="EventDate" runat="server"></asp:Calendar>

                            </div>
                            <div class="form-group">
                                <label for="lblSpecialRequests">Special Requests</label>
                                <asp:TextBox class="form-control" id="SpecialRequests" runat="server" placeholder="Enter special requests" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            
                            <asp:Button ID="btnBook" runat="server" Text="Book" OnClick="btnBook_Click" class="btn btn-primary"/>
                            
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </form>

                        </div>

                        <div class="col-lg-7">
                            <p>
                                Welcome to our booking events page, where you can easily book your upcoming event. Our page features a simple and intuitive form that allows you to enter all the necessary event details, including the event name, email address, date, and number of participants. We understand the importance of choosing the right date for your event, which is why our date field comes equipped with a calendar picker, making it easy for you to select your preferred date. To help you budget for your event, our page also includes a pricing calculator that automatically calculates the price per person and total price based on the number of participants you select. Please note that the minimum number of participants is <b>3</b> and the maximum number of participants is <b>50</b>. If you require more than 30 participants, please contact us directly to discuss your options. Our booking events page is designed to be easy to use, providing you with a seamless experience from start to finish.
                            </p>

                            <div class="col-13 ml-0">
                                <img src="IMG/Food.EventBooking_page.jpg" class="img-fluid" />
                            </div>
                        </div>



                    
            
            
            
            
            </div>
        </div>
    <div class="footer-pad">
        <p class="text-center">© FUTBOOK 2023 </p>
    </div>
</body>
</html>

