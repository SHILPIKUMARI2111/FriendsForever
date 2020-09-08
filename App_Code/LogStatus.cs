using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class LogStatus
{
    public static int user_id;
    public static string auth_Token;

    public static int IsLoggedIn()
    {
        bool cookieExists = HttpContext.Current.Request.Cookies["SNID"] != null;

        if (cookieExists)
        {
            Check_Token();
            bool cookie2Exists = HttpContext.Current.Request.Cookies["SNID_"] != null;

            if(cookie2Exists)
            {
                return user_id;
            }

            else
            {
                GenerateToken();

                SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

                conn.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO login_tokens VALUES (@token, @user_id)", conn))
                {
                    command.Parameters.AddWithValue("@token", auth_Token);
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.ExecuteNonQuery();
                }

                conn.Close();

                conn.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM login_tokens WHERE token = @old_token", conn))
                {
                    command.Parameters.AddWithValue("@old_token", HttpContext.Current.Request.Cookies["SNID"].Value);
                    command.ExecuteNonQuery();
                }

                conn.Close();

                SetCookie();

                return user_id;
            }
        }
        else
        {
            return -2;
        }

    }

    public static void Check_Token()
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT user_id FROM login_tokens WHERE token = @token", conn))
        {
            command.Parameters.AddWithValue("@token", HttpContext.Current.Request.Cookies["SNID"].Value);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            if(reader.Read())
            {
                user_id = Convert.ToInt32(reader["user_id"].ToString());
            }

            if(user_id <0 || user_id == null)
            {
                user_id = -1;
            }
        }

        conn.Close();
    }

    public static void GenerateToken()
    {
        var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=/*";
        var random = new Random();
        var resultToken = new string(Enumerable.Repeat(allChar, 64).Select(token => token[random.Next(token.Length)]).ToArray());

        auth_Token = resultToken.ToString();
    }

    public static void SetCookie()
    {

        HttpCookie SNID = new HttpCookie("SNID");
        SNID.Value = auth_Token;
        SNID.Expires = DateTime.Now.AddHours(72);
        HttpContext.Current.Response.Cookies.Add(SNID);

        HttpCookie SNID_ = new HttpCookie("SNID_");
        SNID_.Value = "1";
        SNID_.Expires = DateTime.Now.AddHours(168);
        HttpContext.Current.Response.Cookies.Add(SNID_);
    }

}