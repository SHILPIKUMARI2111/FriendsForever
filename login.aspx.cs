using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    string auth_Token;
    int user_id;
    
    protected void Page_Load(object sender, EventArgs e)
    {
       if(LogStatus.IsLoggedIn()>0)
       {
           Response.Redirect("profile.aspx");
       }
    }

     public string Hash(string password)
    {
        var bytes = new UTF8Encoding().GetBytes(password);
        byte[] hashBytes;
        using (var algorithm = new System.Security.Cryptography.SHA512Managed())
        {
            hashBytes = algorithm.ComputeHash(bytes);
        }
        return Convert.ToBase64String(hashBytes);
    }

    public void GenerateToken()
    {
         var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=/*";
         var random = new Random();
         var resultToken = new string(Enumerable.Repeat(allChar, 64).Select(token => token[random.Next(token.Length)]).ToArray());

         auth_Token = resultToken.ToString();  
     }

    public void InsertToken()
    {
        SqlConnection conn1 = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn1.Open();

        using (SqlCommand command = new SqlCommand("SELECT u_id FROM users WHERE email = @email", conn1))
        {

            command.Parameters.AddWithValue("@email", email.Text);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                user_id = Convert.ToInt32(reader["u_id"].ToString());
            }
        }

        conn1.Close();

        GenerateToken();

        SqlConnection conn2 = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True");

        conn2.Open();

        using (SqlCommand command = new SqlCommand("INSERT INTO login_tokens VALUES (@token, @user_id)", conn2))
        {
            command.Parameters.AddWithValue("@token", auth_Token);
            command.Parameters.AddWithValue("@user_id", user_id);
            command.ExecuteNonQuery();
        }

        conn2.Close();

        SetCookie();
    }

    public void SetCookie()
    {

        HttpCookie SNID = new HttpCookie("SNID");
        SNID.Value = auth_Token;
        SNID.Expires = DateTime.Now.AddHours(72);
        Response.Cookies.Add(SNID);

        HttpCookie SNID_ = new HttpCookie("SNID_");
        SNID_.Value = "1";
        SNID_.Expires = DateTime.Now.AddHours(168);
        Response.Cookies.Add(SNID_);
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT email, password FROM users WHERE email = @email", conn))
        {
            bool userExists = false;

            command.Parameters.AddWithValue("@email", email.Text);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader["password"].ToString() == Hash(password.Text))
                {
                    Response.Write("<h3 style = 'color:green' >Login Successful !!!</h3>");
                    InsertToken();

                    Response.Redirect("profile.aspx");

                }
                else
                {
                    Response.Write("<h3 style = 'color:red' >Incorrect Password !!!</h3>");
                }
                userExists = true;
            }
            if(!reader.Read() && !userExists)
            {
                Response.Write("<h3 style = 'color:red' >User doesn't exist !!!</h3>");
            }
        }
    }
}