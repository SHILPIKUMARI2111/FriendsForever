using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profile : System.Web.UI.Page
{
    public string f_name;
    public string l_name;
    public string u_name;
    public string email;
    public string dob;
    public string gender;

    public int following;
    public int followers;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(LogStatus.IsLoggedIn()<=0)
        {
            Response.Redirect("home.aspx");
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT f_name, l_name, u_name, email, dob, gender FROM users WHERE u_id = @user_id", conn))
        {

            command.Parameters.AddWithValue("@user_id", LogStatus.IsLoggedIn());
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if(reader.Read())
            {
                f_name = reader["f_name"].ToString();
                l_name = reader["l_name"].ToString();
                u_name = reader["u_name"].ToString();
                email = reader["email"].ToString();
                dob = reader["dob"].ToString();
                gender = reader["gender"].ToString();
            }
        }

        conn.Close();

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT COUNT(following) AS following FROM follow WHERE following=@user_id", conn))
        {

            command.Parameters.AddWithValue("@user_id", LogStatus.IsLoggedIn());
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                following = Convert.ToInt32(reader["following"].ToString());
            }
        }

        conn.Close();

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT COUNT(being_followed) AS followers FROM follow WHERE being_followed=@user_id", conn))
        {

            command.Parameters.AddWithValue("@user_id", LogStatus.IsLoggedIn());
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                followers = Convert.ToInt32(reader["followers"].ToString());
            }
        }

        conn.Close();
    }
}