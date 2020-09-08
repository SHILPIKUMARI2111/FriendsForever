<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Login</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <script type="text/javascript" src="https://use.fontawesome.com/c5d4139649.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">

    <link rel="stylesheet" type="text/css" href="css/login.css">

</head>
<body>

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">

                <div class="login100-pic js-tilt">
                    <img src="images/img-01.png" alt="IMG">
                </div>

                <form class="login100-form validate-form" id="form1" runat="server">
                    <span class="login100-form-title">
                        Login
                    </span>

                    <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">
                        <!--<input class="input100" type="text" name="email" placeholder="Email" id="username">-->

                        <asp:TextBox class="input100" ID="email" runat="server" placeholder="Email"></asp:TextBox>

                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <i class="fa fa-envelope"></i>
                        </span>
                    </div>

                    <div class="wrap-input100 validate-input" data-validate="Password is required">
                        <!--<input class="input100" type="password" name="password" placeholder="Password">-->

                        <asp:TextBox class="input100" ID="password" runat="server" type="password" placeholder="Password"></asp:TextBox>

                        <span class="focus-input100"></span>
                        <span class="symbol-input100">
                            <i class="fa fa-lock" aria-hidden="true"></i>
                        </span>
                    </div>

                    <div class="container-login100-form-btn">
                        <!--<input class="login100-form-btn" type="submit" name="login" value="Login">-->
                        <asp:Button class="login100-form-btn" ID="Login" runat="server" Text="Login" OnClick="Login_Click"/>
                    </div>

                    <div class="text-center p-t-136">
                        <a class="txt2" href="signup.aspx">
                            Create Account
                            <i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
                        </a>
                    </div>
                </form>


            </div>
        </div>
    </div>
</body>
</html>


