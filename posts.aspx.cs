using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class posts : System.Web.UI.Page
{
    public string u_name;
    public string[] u_names;
    public string[] msgs;
    public string[] datetimes;
    public int count = 0;

    public static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTime dateTime_Indian = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, India_Standard_Time);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["SNID"] != null)
        {
            LogStatus.DeleteCookies();
        }

        if(LogStatus.IsLoggedIn()<=0)
        {
            Response.Redirect("home.aspx");
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT u_name FROM users WHERE u_id=@u_id", conn))
        {
            command.Parameters.AddWithValue("@u_id", LogStatus.IsLoggedIn());
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                u_name = reader["u_name"].ToString();
            }
        }

        conn.Close();
        
        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT COUNT(m_id) AS count FROM messages", conn))
        {
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                count = Convert.ToInt32(reader["count"].ToString());
            }
        }

        conn.Close();

        if(count>100)
        {
            count = 100;
        }

        u_names = new string[count];
        msgs = new string[count];
        datetimes = new string[count];

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT TOP(100) u_name, msg, datetime FROM messages ORDER BY m_id DESC", conn))
        {
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            int i = 0;

            while(reader.Read())
            {
                if (reader["u_name"].ToString() == u_name)
                {
                    u_names[i] = "*"+reader["u_name"].ToString();
                    msgs[i] = reader["msg"].ToString();
                    datetimes[i] = reader["datetime"].ToString();
                }
                else
                {
                    u_names[i] = reader["u_name"].ToString();
                    msgs[i] = reader["msg"].ToString();
                    datetimes[i] = reader["datetime"].ToString();
                }
                i++;
            }
        }

        conn.Close();

    }
    protected void post_Click(object sender, EventArgs e)
    {
        if(message.Text.Length>0)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True");

            conn.Open();

            using (SqlCommand command = new SqlCommand("SELECT u_name FROM users WHERE u_id=@u_id", conn))
            {
                command.Parameters.AddWithValue("@u_id", LogStatus.IsLoggedIn());
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    u_name = reader["u_name"].ToString();
                }
            }

            conn.Close();


            conn.Open();

            using (SqlCommand command = new SqlCommand("INSERT INTO messages VALUES (@u_name, @msg, @datetime)", conn))
            {
                command.Parameters.AddWithValue("@u_name", u_name);
                command.Parameters.AddWithValue("@msg", message.Text);
                command.Parameters.AddWithValue("@datetime", dateTime_Indian);
                command.ExecuteNonQuery();
            }

            conn.Close();

            Response.Redirect("posts.aspx");
        }
    }
}