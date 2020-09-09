using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LogStatus.DeleteCookies();

        if(LogStatus.IsLoggedIn()<=0)
        {
            Response.Redirect("home.aspx");
        }
    }


    protected void LogoutButton_Click(object sender, EventArgs e)
    {
        if(alldevices.Checked)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

            conn.Open();

            using (SqlCommand command = new SqlCommand("DELETE FROM login_tokens WHERE user_id = @user_id", conn))
            {
                command.Parameters.AddWithValue("@user_id", LogStatus.IsLoggedIn());
                command.ExecuteNonQuery();
            }

            conn.Close();

            HttpCookie SNID = new HttpCookie("SNID");
            SNID.Expires = DateTime.Now.AddHours(-1);
            HttpContext.Current.Response.Cookies.Add(SNID);

            HttpCookie SNID_ = new HttpCookie("SNID_");
            SNID_.Expires = DateTime.Now.AddHours(-1);
            HttpContext.Current.Response.Cookies.Add(SNID_);

            Response.Redirect("home.aspx");
        }
        else
        {
            bool cookieExists = HttpContext.Current.Request.Cookies["SNID"] != null;

            if(cookieExists)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

                conn.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM login_tokens WHERE token = @token", conn))
                {
                    command.Parameters.AddWithValue("@token", HttpContext.Current.Request.Cookies["SNID"].Value);
                    command.ExecuteNonQuery();
                }

                conn.Close();

                HttpCookie SNID = new HttpCookie("SNID");
                SNID.Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies.Add(SNID);

                HttpCookie SNID_ = new HttpCookie("SNID_");
                SNID_.Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies.Add(SNID_);

                Response.Redirect("home.aspx");
            }
            
        }
    }
}