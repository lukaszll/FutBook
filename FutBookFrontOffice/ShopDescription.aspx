<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShopDescription.aspx.cs" Inherits="FutBookFrontOffice.ShopDescription" %>

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

    <body>

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
          <a class="nav-link dropdown-toggle" href="#" id="navbardrop" data-toggle="dropdown">
            BOOKINGS
          </a>
          <div class="dropdown-menu">
            <a class="dropdown-item" href="#">PITCH</a>
            <a class="dropdown-item" href="EventBooking.aspx">EVENT</a>
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
    <br/>
  

    <div class="logo">
            <img src="IMG/logoFutBook.png" />
    </div>


        <div class="container min-vh-100">
            <div class="row">
                <div class="col-4 mt-5">
                    <img src="IMG/tshirtRM.jpg" style="height: 260px;" />
                </div>
                <div class="col-6 mt-5">
                    <h2>Real Madrid T-Shirt</h2>
                    <p style="font-size: 14px; color: #e6e6e6;">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Viverra nam libero justo laoreet sit amet. Consequat mauris nunc congue nisi. Purus in mollis nunc sed id semper risus in hendrerit. Ante metus dictum at tempor commodo ullamcorper. Venenatis urna cursus eget nunc scelerisque viverra mauris in aliquam. Quis risus sed vulputate odio ut. Aliquam sem fringilla ut morbi tincidunt augue interdum. Purus faucibus ornare suspendisse sed nisi lacus sed viverra tellus. Faucibus in ornare quam viverra orci sagittis eu volutpat. Eget mi proin sed libero enim sed. Integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus.</p>
                </div>
            </div>

            <form runat="server">
                <div class="col-md-12 text-left mt-5">
                    <asp:Button ID="btnAddToBasket" runat="server" Text="Add to basket" OnClick="btnAddToBasket_Click" class="btn btn-success" />
                    <p style="font-size: 12px; margin-left: 5px;">You need to log in first!</p>
                </div>
            </form>

            
        </div>

    <div class="footer-pad">  
    <p class="text-center"> © FUTBOOK 2023 </p>  
    </div>  
</body>
</html>

