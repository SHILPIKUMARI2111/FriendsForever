<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" dir="ltr">
<head>
    <meta charset="utf-8">
    <title>Friends Forever</title>
    <link rel="stylesheet" href="css/home.css">
</head>
<body>
    <nav class="nav">
        <div class="container">
            <div class="logo">
                <a href="home.aspx">Friends Forever</a>
            </div>
            <div id="mainListDiv" class="main_list">
                <ul class="navlinks">
                    <li><a href="login.aspx">Login</a></li>
                    <li><a href="signup.aspx">SignUp</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="cont">
        <img src="images/ff.png" alt="">
    </div>
</body>
</html>

<!--ngrok http 50024 -host-header="localhost:50024/html.aspx"-->