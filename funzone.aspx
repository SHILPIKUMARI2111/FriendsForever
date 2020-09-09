<%@ Page Language="C#" AutoEventWireup="true" CodeFile="funzone.aspx.cs" Inherits="funzone" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Search</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<script type="text/javascript" src="https://use.fontawesome.com/c5d4139649.js"></script>
    <link href="https://fonts.googleapis.com/css2?family=Frijole&family=Luckiest+Guy&display=swap" rel="stylesheet">
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
        <span class="funzone-title">Fun Zone !!!</span>

				<div class="funzone-list">
                    <a class="funzone-text" href="facts.aspx">Facts</a>
                    <a class="funzone-text" href="quotes.aspx">Quotes</a>
                    <a class="funzone-text" href="games.aspx">Games</a>
                </div>

			</div>
		</div>
	</div>

</body>
</html>
