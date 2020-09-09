using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class facts : System.Web.UI.Page
{

    public string fact;
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

        randomizer = random.Next(1, 74);

        SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=friendsforever;Integrated Security=True"); //Create Connection

        conn.Open();

        using (SqlCommand command = new SqlCommand("SELECT fact FROM facts WHERE fact_id = @fact_id", conn))
        {
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@fact_id", randomizer);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                fact = reader["fact"].ToString();
            }
        }

        conn.Close();

    }

    protected void refresh(object sender, EventArgs e)
    {
        Response.Redirect("facts.aspx");
    }
}