using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class quotes : System.Web.UI.Page
{
    public string quote;
    public int randomizer;

    public Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.Cookies["SNID"] != null)
        {
            LogStatus.DeleteCookies();
        }

        if (LogStatus.IsLoggedIn() <= 0)
        {
            Response.Redirect("home.aspx");
        }

        randomizer = random.Next(1, 46);

        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT quote FROM quotes WHERE q_id = @q_id", conn))
        {
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@q_id", randomizer);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                quote = reader["quote"].ToString();
            }
        }

        conn.Close();

    }

    protected void refresh(object sender, EventArgs e)
    {
        Response.Redirect("quotes.aspx");
    }
}