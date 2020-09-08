<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="logout" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<html lang="en">
<head>
    <title>Logout ?</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <script type="text/javascript" src="https://use.fontawesome.com/c5d4139649.js"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="css/logout.css">

</head>
<body>
    <div class="limiter">
        <div class="container-login100">

            <div class="lgtlink">
                <a href="profile.aspx"><span class="userstext">Profile</span></a>
            </div>

            <div class="wrap-login100">
                <span class="login100-form-title">Are you sure you'd like to logout?</span>

                <div class="logout">
                    <form id="form1" runat="server">
                        <!--<input type="checkbox" class="checkbox" name="alldevices" value="alldevices"><span class="logout-text"> Logout of all devices ?</span>-->
                        <asp:CheckBox class="checkbox" ID="alldevices" runat="server" /><span class="logout-text"> Logout of all devices ?</span>
                        <!--<input class="login100-form-btn" type="submit" name="confirm" value="Confirm">-->
                        <asp:Button class="login100-form-btn" ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click"/>
                    </form>
                </div>
            </div>
        </div>
    </div>
    </div>

</body>
</html>

