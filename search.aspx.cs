using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
{
    public int count;
    public string[] users;

    public int other_user_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(LogStatus.IsLoggedIn()<=0)
        {
            Response.Write("home.aspx");
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT COUNT(u_name) AS count FROM users WHERE u_id <> @user_id", conn))
        {

            command.Parameters.AddWithValue("@user_id", LogStatus.IsLoggedIn());
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if(reader.Read())
            {
                count = Convert.ToInt32(reader["count"].ToString());
            }
        }

        conn.Close();

        users = new string[count];

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT u_name FROM users WHERE u_id <> @user_id", conn))
        {

            command.Parameters.AddWithValue("@user_id", LogStatus.IsLoggedIn());
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            int i = 0;
            while(reader.Read())
            {
                users[i] = reader["u_name"].ToString();
                i++;
            }
        }

        conn.Close();
    }

    protected void searchsubmit_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT u_id FROM users WHERE u_name = @u_name", conn))
        {

            command.Parameters.AddWithValue("@u_name", name.Text);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                other_user_id = Convert.ToInt32(reader["u_id"].ToString());
                Response.Redirect("otherprofiles.aspx?ou_id=" + other_user_id);
            }
            else
            {
                Response.Write("<h3 style = 'color:red' >User not found !!!</h3>");
            }
        }

        conn.Close();
    }
}