<%@ Page Language="C#" AutoEventWireup="true" CodeFile="posts.aspx.cs" Inherits="posts" %>

<!DOCTYPE html>
<html lang="en">
<head>
	<title>Posts</title>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">

	<script type="text/javascript" src="https://use.fontawesome.com/c5d4139649.js"></script>
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
  <link href="https://fonts.googleapis.com/css2?family=Roboto&family=Source+Sans+Pro&display=swap" rel="stylesheet">
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
        <span class="login100-form-title">Posting Wall</span>
        <span class="whatsonmind" id='search'>What's on your mind ?</span>

            <form class="choose" runat="server" >
              <!--<input type="text" name="message" placeholder="Write something here..." value="">-->
                <asp:TextBox ID="message" runat="server" placeholder="Write something here..."></asp:TextBox>
              <!--<input id="searchsubmit" type="submit" name="post" value="Post">-->
                <asp:Button id="searchsubmit" runat="server" Text="Post" OnClick="post_Click"/>
            </form>

          <span id="recentposts">Recent Posts</span>

          
            <% for (int i = 0; i < count; i++)
               {
                   if(u_names[i][0] == '*')
                   {
                       Response.Write("<div class='posts'>");
                       Response.Write("<span id='p-uname'>" + u_names[i].Substring(1) + "</span><br/>");
                       Response.Write("<span id='p-msg'>" + msgs[i] + "</span><br/>");
                       Response.Write("<span id='p-dt'>" + "@" + datetimes[i] + "</span><br/>");
                       Response.Write("</div>");
                   }
                   else
                   {
                       Response.Write("<div class='postsothers'>");
                       Response.Write("<span id='p-unameothers'>" + u_names[i] + "</span><br/>");
                       Response.Write("<span id='p-msg'>" + msgs[i] + "</span><br/>");
                       Response.Write("<span id='p-dt'>" + "@" + datetimes[i] + "</span><br/>");
                       Response.Write("</div>");
                   }
               }
            %>

			</div>
		</div>
	</div>

</body>
</html>
