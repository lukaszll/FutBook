<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookingPitch.aspx.cs" Inherits="FutBookFrontOffice.BookingPitch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css"/>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <script src="JavaScriptBooking.js"></script>
    <title>FutBook</title>
</head>
<body style="background-color:#ed3b3b;">

    <nav class="navbar navbar-expand-sm navbar-dark fixed-top">
      <!-- Brand -->
      <a class="navbar-brand" href="Default_aut.aspx">FUTBOOK</a>

      <!-- Links -->
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" href="Shop.aspx">SHOP</a>
        </li>
        
        <!-- Dropdown -->
        <li class="nav-item dropdown">
          <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">
            BOOKINGS
          </a>
          <div class="dropdown-menu">
            <a class="dropdown-item" href="#">PITCH</a>
            <a class="dropdown-item" href="#">EVENT</a>
          </div>
        </li>

        <li class="nav-item">
          <a class="nav-link" href="SignUp.aspx">SIGN UP</a>
        </li>

        <li class="nav-item">
          <a class="nav-link" href="SignIN.aspx">SIGN IN</a>
        </li>


      </ul>
    </nav>
    <br>
  

    <div class="logo">
            <img src="IMG/logoFutBook.png" />
    </div>


<div class="container min-vh-100">
  <div class="row" style="border: none; margin-left: 0px; margin-top:40px; width:50%; ">
    <div class="col">
      <h2>BOOKING PITCH</h2>
      <form id="Form1" runat="server" onsubmit="return validateBookingForm()" OnServerSubmit="btnBookingPitch_Click">
        <div class="form-group">
          <label for="date">Select Date:</label>&nbsp;
            <br />
          <asp:DropDownList ID="ddlDate" runat="server"></asp:DropDownList>
            <br />
          <label for="hour">Select Hour:</label>
          <br />
          <asp:DropDownList ID="DropDownList1" runat="server" Width="139px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>9:00</asp:ListItem>
            <asp:ListItem>10:00</asp:ListItem>
            <asp:ListItem>11:00</asp:ListItem>
            <asp:ListItem>12:00</asp:ListItem>
            <asp:ListItem>13:00</asp:ListItem>
            <asp:ListItem>14:00</asp:ListItem>
            <asp:ListItem>15:00</asp:ListItem>
            <asp:ListItem>16:00</asp:ListItem>
            <asp:ListItem>17:00</asp:ListItem>
            <asp:ListItem>18:00</asp:ListItem>
            <asp:ListItem>19:00</asp:ListItem>
            <asp:ListItem>20:00</asp:ListItem>
            <asp:ListItem>21:00</asp:ListItem>
            <asp:ListItem>22:00</asp:ListItem>
            <asp:ListItem>23:00</asp:ListItem>
          </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Book" OnClick="Button1_Click" />
        </div>
          <asp:Label ID="lblError" runat="server"></asp:Label>
        <div class="error" id="error">Please select a valid time</div>
      </form>
    </div>
  </div>
</div>





    <div class="footer-pad">  
    <p class="text-center"> © FUTBOOK 2023 </p>  
    </div>  

</body>
</html>

