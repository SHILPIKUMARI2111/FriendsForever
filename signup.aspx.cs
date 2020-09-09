using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Text;
using System.Data;

public partial class signup : System.Web.UI.Page
{
    bool emailIsValid = false;
    bool userEmailExists = false;
    bool usernameExists = false;
    string gender;

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

    public void Check_Email()
    {
        if (email.Text.Length > 4)
        {
            try
            {
                MailAddress m = new MailAddress(email.Text);
                emailIsValid = true;
            }
            catch (FormatException)
            {
                emailIsValid = false;
            }
        }
    }

    public void Check_Gender()
    {
        if (Male.Checked)
        {
            gender = "Male";
        }
        else if(Female.Checked)
        {
            gender = "Female";
        }
    }

    public void CheckIfUserExists()
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True");    //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT email FROM users WHERE email = @email", conn))
        {
            command.Parameters.AddWithValue("@email", email.Text);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if(reader["email"].ToString() == email.Text)
                {
                    userEmailExists = true;
                }
            }
        }
        conn.Close();

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT u_name FROM users WHERE u_name = @u_name", conn))
        {
            command.Parameters.AddWithValue("@u_name", u_name.Text);
            command.CommandType = CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader["u_name"].ToString() == u_name.Text)
                {
                    usernameExists = true;
                }
            }
        }

        conn.Close();
        
    }

    protected void SignupButton_Click(object sender, EventArgs e)
    {
        
        if (Regex.IsMatch(f_name.Text, "^[a-zA-Z0-9 ]*$") && f_name.Text.Length >= 3 && f_name.Text.Length <= 16)
        {
            if (Regex.IsMatch(l_name.Text, "^[a-zA-Z0-9 ]*$") && l_name.Text.Length <= 16)
            {
                if (u_name.Text.Length >= 3 && u_name.Text.Length <= 16)
                {
                    CheckIfUserExists();
                    if (!userEmailExists)
                    {
                        if (!usernameExists)
                        {
                            Check_Email();
                            if(emailIsValid)
                            {
                                if(dob.Text.Length > 6)
                                {
                                    if(Male.Checked || Female.Checked)
                                    {
                                        Check_Gender();
                                        if(password.Text.Length >= 8)
                                        {
                                            if(password.Text == rpassword.Text)
                                            {
                                                SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True");

                                                conn.Open();

                                                using (SqlCommand command = new SqlCommand("INSERT INTO users VALUES (@f_name, @l_name, @u_name, @email, @dob, @gender, @password)", conn))
                                                {
                                                    command.Parameters.AddWithValue("@f_name", f_name.Text);
                                                    command.Parameters.AddWithValue("@l_name", l_name.Text);
                                                    command.Parameters.AddWithValue("@u_name", u_name.Text);
                                                    command.Parameters.AddWithValue("@email", email.Text);
                                                    command.Parameters.AddWithValue("@dob", dob.Text);
                                                    command.Parameters.AddWithValue("@gender", gender);
                                                    command.Parameters.AddWithValue("@password", Hash(password.Text));
                                                    command.ExecuteNonQuery();
                                                }

                                                conn.Close();

                                                if (ProPic.PostedFile.ContentType == "image/jpeg")
                                                {
                                                    string filename = u_name.Text + ".jpg";
                                                    ProPic.SaveAs(@"C:\Users\shahin_saim\Documents\Visual Studio 2013\WebSites\FriendsForever\images\propics\" + filename);
                                                }

                                                Response.Write("<h3 style = 'color:green' >Account Created Successfully !!!</h3>");

                                                Response.Redirect("home.aspx");
                                            }
                                            else
                                            {
                                                Response.Write("<h3 style = 'color:red' >Passwords do not match !!!</h3>");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write("<h3 style = 'color:red' >Enter a valid password</h3>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<h3 style = 'color:red' >Select your gender</h3>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<h3 style = 'color:red' >Enter Date of Birth</h3>");
                                }
                            }
                            else
                            {
                                Response.Write("<h3 style = 'color:red' >Invalid email</h3>");
                            }
                        }
                        else
                        {
                            Response.Write("<h3 style = 'color:red' >Username already taken !!!</h3>");
                        }
                    }
                    else
                    {
                        Response.Write("<h3 style = 'color:red' >User with this email already exists !!!</h3>");
                    }
                }
                else
                {
                    Response.Write("<h3 style = 'color:red' >Enter a valid username</h3>");
                }
            }
            else
            {
                Response.Write("<h3 style = 'color:red' >Enter a valid last name</h3>");
            }
        }
        else
        {
            Response.Write("<h3 style = 'color:red' >Enter a valid first name</h3>");
        }
    }
}