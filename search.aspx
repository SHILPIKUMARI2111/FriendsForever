<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Search</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<script type="text/javascript" src="https://use.fontawesome.com/c5d4139649.js"></script>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
	<link rel="stylesheet" type="text/css" href="css/profile.css">


</head>
<body>

	<div class="limiter">
		<div class="container-login100">

            <div class="lgtlink">
                <a href="profile.aspx"><span class="userstext">Profile</span></a>
                <a href="posts.aspx"><span class="userstext">Posts</span></a>
		        <a href="logout.aspx"><span class="logouttext">Logout</span></a>
            </div>

			<div class="wrap-login100">
        <span class="login100-form-title">Find Friends</span>

        <form class="choose" runat="server">
          <!--<input type="text" name="username" value="" placeholder="friend's username...">-->
          <asp:TextBox class="input--style-4" ID="name" runat="server" placeholder="friend's username..."></asp:TextBox>
          <!--<input id="searchsubmit" type="submit" name="search" value="Search">-->
          <asp:Button id="searchsubmit" runat="server" Text="Search" OnClick="searchsubmit_Click"/>
        </form>

              <span class="login100-form-title">Users List</span>
				<div class="profile-list">

                  <% for (int i = 0; i < count; i++)
                     {
                         Response.Write("<h2>" + users[i] + "</h2>");
                     }
                  %>

                </div>
			</div>
		</div>
	</div>

</body>
</html>
