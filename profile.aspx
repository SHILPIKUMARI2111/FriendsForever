<%@ Page Language="C#" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>


<!DOCTYPE html>
<html lang="en">
<head>
	<title><% Response.Write(u_name);%>'s Profile</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<script type="text/javascript" src="https://use.fontawesome.com/c5d4139649.js"></script>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
	<link rel="stylesheet" type="text/css" href="css/profile.css">


</head>
<body>

	<div class="limiter">
		<div class="container-login100">

			<div class="lgtlinkposts">
        <a href="posts.aspx"><span class="userstext">Posts</span></a>
        <a href="search.aspx"><span class="userstext">Search</span></a>
				<a href="logout.aspx"><span class="logouttext">Logout</span></a>
			</div>

			<div class="wrap-login100">
        <span class="login100-form-title">Your Profile</span>

				<div class="login100-pic">
					<img src="images/propics/<% Response.Write(u_name);%>.jpg" onerror=this.src="images/propics/default.png">
				</div>

				<div class="yourprofiledetails">
          <h2><% Response.Write(f_name+" ");%> <% Response.Write(l_name);%></h2>
          <h2><% Response.Write(dob);%></h2>
          <h2><% Response.Write(gender);%></h2>
          <h2><% Response.Write(email);%></h2>
          <h2><% Response.Write(following + " following");%></h2>
          <h2><% Response.Write(followers + " followers");%></h2>
        </div>
			</div>
		</div>
	</div>

</body>
</html>
