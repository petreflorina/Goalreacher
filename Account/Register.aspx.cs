using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Account_Register : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void register_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();
        string checkUser = "SELECT COUNT(*) FROM [User] WHERE username = '" + UserName.Text + "';";
        SqlCommand command = new SqlCommand(checkUser, connection);
        int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        if (temp == 1)
        {
            connection.Close();
        }
        else
            try
            {
                string insertUser = "INSERT INTO [User](username, password) VALUES (@Username, @Password);";
                command = new SqlCommand(insertUser, connection);
                command.Parameters.AddWithValue("@Username", UserName.Text);
                command.Parameters.AddWithValue("@Password", Password.Text);
                command.ExecuteNonQuery();
                Response.Redirect("~/Account/Login.aspx");
                connection.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex.ToString());
            }
    }
}