<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBookingUpdate.aspx.cs" Inherits="FutBookFrontOffice.EventBookingUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <link href="CSS/FutBookStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" />
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
                <asp:HyperLink ID="hypShop" runat="server" class="nav-link" NavigateUrl="~/ShopAdmin.aspx">SHOP</asp:HyperLink>
            </li>

            <li class="nav-item">
                <asp:HyperLink ID="hypAddStock" runat="server" class="nav-link" NavigateUrl="~/ShopAdd.aspx">ADD STOCK</asp:HyperLink>
            </li>

            <li class="nav-item">
                <asp:HyperLink ID="hypUpdateStock" runat="server" class="nav-link" NavigateUrl="~/ShopUpdate.aspx">UPDATE STOCK</asp:HyperLink>
            </li>

            <li class="nav-item ml-auto">
                <asp:HyperLink ID="hypDeleteStock" runat="server" class="nav-link" NavigateUrl="~/ShopDelete.aspx">DELETE STOCK</asp:HyperLink>
            </li>

            <li class="nav-item">
                <asp:HyperLink ID="hypSignIn" runat="server" class="nav-link" NavigateUrl="~/SignIn.aspx">SIGN IN</asp:HyperLink>
            </li>

            
        </ul>

        <asp:Label ID="lblGreeting" runat="server" class="nav-link ml-auto lblGreeting"></asp:Label>

    </nav>
    <br />


    <div class="logo">
        <img src="IMG/logoFutBook.png" />
    </div>

    <div class="container min-vh-100">

        

        

        

        <div class="row" style="border: none; margin-left: 0px; margin-top: 40px; color: #ffffff">
            <div class="col">
                <h1 class="text-center">ADMIN - UPDATE EVENT BOOKING</h1>
                <br />
            </div>

        </div>

        <div class="col">
                        
                        <form runat="server">

                            <div class="search text-center">
                                <label for="product"><b style="color: #fff">SEARCH EVENT NAME :</b></label>
                                <div class="row justify-content-center">
                                    <div class="col-md-6">
                                        <asp:TextBox class="form-control" ID="idEventSearch" runat="server" placeholder="Enter event name"></asp:TextBox>
                                    </div>
                                    <div class="col-md-auto">
                                        <asp:Button ID="btnEventSearch" runat="server" Text="Search" OnClick="btnEventSearch_Click" class="myButton" />
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="form-group">
                                <label for="lblEventList"><b>Event List:</b></label>
                                <asp:ListBox class="form-control" ID="idEventList" runat="server" SelectionMode="Multiple" Rows="10"></asp:ListBox>
                            </div>
                                                        
                            
                            <asp:Button ID="btnUpdate" runat="server" Text="Update Event" OnClick="btnUpdateEvent_Click" class="myButton"/>
                            
                            <asp:Label ID="lblError" runat="server"></asp:Label>
                        </form>

                        
                    </div>

      
        <br />
        <br />



    </div>



    <div class="footer-pad">
        <p class="text-center">© FUTBOOK 2023 </p>
    </div>
</body>
</html>

