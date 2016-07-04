using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();
        string checkUser = "SELECT COUNT(*) FROM [User] WHERE username = '" + UserName.Text + "' AND password = '" + Password.Text + "';";
        SqlCommand comanda = new SqlCommand(checkUser, connection);
        int temp = Convert.ToInt32(comanda.ExecuteScalar().ToString());
        if (temp == 1)
        {
            string getName = "SELECT Name FROM [User] WHERE username = '" + UserName.Text + "' AND password = '" + Password.Text + "';";
            comanda = new SqlCommand(getName, connection);
            FormsAuthentication.SetAuthCookie(UserName.Text, true);
            Response.Redirect("~/Default.aspx");
        }
        else
            FailureText.Text = "Wrong user/password";
        connection.Close();

    }
}