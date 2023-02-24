<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FutBookFrontOffice.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css"/>
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.1/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>FutBook</title>
</head>
<body style="background-color:#ed3b3b;">

    <nav class="navbar navbar-expand-sm navbar-dark fixed-top">
      <!-- Brand -->
      <a class="navbar-brand" href="Default.aspx">FUTBOOK</a>

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
          <a class="nav-link" href="Login.aspx">LOG IN</a>
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
                        <h2>SIGN UP</h2>
                        <form runat="server">
                            <div class="form-group">
                                <label for="lblEmail">Email address</label>
                                <asp:TextBox class="form-control" id="idEmail" runat="server" aria-describedby="emailHelp" placeholder="Enter email"></asp:TextBox>
                                <!--<input type="email" class="form-control" id="idEmaila" aria-describedby="emailHelp" placeholder="Enter email"/>-->
                            </div>
                            <div class="form-group">
                                <label for="lblFirstName">First name</label>
                                <input type="firstName" class="form-control" id="idFirstName" placeholder="Enter email"/>
                            </div>
                            <div class="form-group">
                                <label for="lblLastName">Last name</label>
                                <input type="lastName" class="form-control" id="idLastName" placeholder="Enter email"/>
                            </div>
                            <div class="form-group">
                                <label for="lblAddress">Address</label>
                                <input type="address" class="form-control" id="idAddress" placeholder="Enter email"/>
                            </div>
                            <div class="form-group">
                                <label for="lblPhoneNo">PhoneNo</label>
                                <input type="phoneNo" class="form-control" id="idPhoneNo" placeholder="Enter email"/>
                            </div>
                            <div class="form-group">
                                <label for="lblPassword1">Create password</label>
                                <asp:TextBox type="password" class="form-control" id="idPassword1" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <!--<input type="password" class="form-control" id="idPassword1" placeholder="Password"/>-->
                            </div>
                            <div class="form-group">
                                <label for="lblPassword2">Confirm password</label>
                                <asp:TextBox type="password" class="form-control" id="idPassword2" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <!--<input type="password" class="form-control" id="idPassword2" placeholder="Password"/>-->
                            </div>
                            
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                            <asp:Button ID="btnSignUp" runat="server" Text="Sign-Up" OnClick="btnSignUp_Click" class="btn btn-primary"/>
                        </form>

                        
                    </div>
                    
       </div>
    </div>

    <div class="footer-pad">  
    <p class="text-center"> © FUTBOOK 2023 </p>  
    </div>  

</body>
</html>
