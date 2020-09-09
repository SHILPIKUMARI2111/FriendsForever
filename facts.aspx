<%@ Page Language="C#" AutoEventWireup="true" CodeFile="facts.aspx.cs" Inherits="facts" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Facts</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<script type="text/javascript" src="https://use.fontawesome.com/c5d4139649.js"></script>
  <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
  <link href="https://fonts.googleapis.com/css2?family=Roboto&family=Source+Sans+Pro&display=swap" rel="stylesheet">
  <link href="https://fonts.googleapis.com/css2?family=Roboto+Slab&display=swap" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="css/wall.css">


</head>
<body>

	<div class="limiter">
		<div class="container-login100">

      <div class="lgtlink">
        <a href="profile.aspx"><span class="userstext">Profile</span></a>
        <a href="search.aspx"><span class="userstext">Search</span></a>
		<a href="logout.aspx"><span class="logouttext">Logout</span></a>
        </div>

			<div class="wrap-login100">
                <span class="headtitle">Random Fact</span>

                  <div class="facts">
                    <% Response.Write("<span id='fact-text'>" + fact + "</span><br/>");%>

                      <form class="refresh" runat="server" >
                        <asp:Button id="refreshbutton" runat="server" Text="Next" OnClick="refresh"/>
                      </form>
                  </div>
			</div>
		</div>
	</div>

</body>
</html>
