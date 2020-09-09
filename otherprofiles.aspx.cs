using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class otherprofiles : System.Web.UI.Page
{
    public string f_name;
    public string l_name;
    public string u_name;
    public string email;

    public int following;
    public int followers;

    public bool isFollowing;

    public int ou_id;


    protected void Page_Load(object sender, EventArgs e)
    {
        LogStatus.DeleteCookies();

        if (LogStatus.IsLoggedIn() <= 0)
        {
            Response.Redirect("home.aspx");
        }

        ou_id = Convert.ToInt32(Request.QueryString["ou_id"]);

        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT f_name, l_name, u_name, email FROM users WHERE u_id = @ou_id", conn))
        {

            command.Parameters.AddWithValue("@ou_id", ou_id);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                f_name = reader["f_name"].ToString();
                l_name = reader["l_name"].ToString();
                u_name = reader["u_name"].ToString();
                email = reader["email"].ToString();
            }
        }

        conn.Close();

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT COUNT(following) AS following FROM follow WHERE following=@ou_id", conn))
        {

            command.Parameters.AddWithValue("@ou_id", ou_id);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                following = Convert.ToInt32(reader["following"].ToString());
            }
        }

        conn.Close();

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT COUNT(being_followed) AS followers FROM follow WHERE being_followed=@ou_id", conn))
        {

            command.Parameters.AddWithValue("@ou_id", ou_id);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                followers = Convert.ToInt32(reader["followers"].ToString());
            }
        }

        conn.Close();

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT following FROM follow WHERE being_followed=@ou_id AND following= @u_id", conn))
        {

            command.Parameters.AddWithValue("@ou_id", ou_id);
            command.Parameters.AddWithValue("@u_id", LogStatus.IsLoggedIn());
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFollowing = true;
                followButton.Text = "Unfollow";
            }
            else
            {
                isFollowing = false;
                followButton.Text = "Follow";
            }
        }

        conn.Close();
    }

    protected void followButton_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT * FROM follow WHERE being_followed=@ou_id AND following= @u_id", conn))
        {

            command.Parameters.AddWithValue("@ou_id", ou_id);
            command.Parameters.AddWithValue("@u_id", LogStatus.IsLoggedIn());
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFollowing = true;
                followButton.Text = "Unfollow";
            }
            else
            {
                isFollowing = false;
                followButton.Text = "Follow";
            }
        }

        conn.Close();


        if(!isFollowing)
        {
            conn.Open();

            using (SqlCommand command = new SqlCommand("INSERT INTO follow VALUES (@following, @being_followed)", conn))
            {

                command.Parameters.AddWithValue("@following", LogStatus.IsLoggedIn());
                command.Parameters.AddWithValue("@being_followed", ou_id);
                command.ExecuteNonQuery();
            }

            conn.Close();

            followButton.Text = "Unfollow";
        }
        else
        {
            conn.Open();

            using (SqlCommand command = new SqlCommand("DELETE FROM follow WHERE following = @following AND being_followed = @being_followed", conn))
            {

                command.Parameters.AddWithValue("@following", LogStatus.IsLoggedIn());
                command.Parameters.AddWithValue("@being_followed", ou_id);
                command.ExecuteNonQuery();
            }

            conn.Close();

            followButton.Text = "Follow";
        }

        Response.Redirect("otherprofiles.aspx?ou_id=" + ou_id);
    }  
}

    