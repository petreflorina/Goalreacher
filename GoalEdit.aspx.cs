using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GoalEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addButton_Click(object sender, EventArgs e)
    {
        //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //connection.Open();
        //string checkEvent = "SELECT COUNT(*) FROM Events WHERE Title = '" + Title.Text + "';";
        //SqlCommand command = new SqlCommand(checkEvent, connection);
        //int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        //if (temp == 1)
        //{
        //    connection.Close();
        //}
        //else
        //    try
        //    {
        //        string insertEvent = "INSERT INTO Events(Title, Type, Location, StartTime, EndTime, Category, PartOfSchedule) VALUES (@Title, @Type, @Location, @StartTime, @EndTime, @Category, @PartOfSchedule);";
        //        command = new SqlCommand(insertEvent, connection);
        //        command.Parameters.AddWithValue("@Title", Title.Text);
        //        command.Parameters.AddWithValue("@Type", Type.SelectedIndex);
        //        command.Parameters.AddWithValue("@StartTime", Convert.ToDateTime(StartTime.Text));
        //        command.Parameters.AddWithValue("@EndTime", Convert.ToDateTime(EndTime.Text));
        //        command.Parameters.AddWithValue("@Location", Location.Text);
        //        command.Parameters.AddWithValue("@Category", Category.SelectedIndex);
        //        command.Parameters.AddWithValue("@PartOfSchedule", SchedulePart.Checked);
        //        command.ExecuteNonQuery();

        //        checkEvent = "SELECT Id FROM Events WHERE Title = '" + Title.Text + "';";
        //        command = new SqlCommand(checkEvent, connection);
        //        temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        //        if (temp > 0)
        //        {
        //            Int32 id = temp;
        //            String checkUser = "SELECT Id FROM Users WHERE Username='" + user.Identity.Name + "';";
        //            command = new SqlCommand(checkUser, connection);
        //            Int32 userId = Convert.ToInt32(command.ExecuteScalar().ToString());
        //            if (temp > 0)
        //            {
        //                String addEventLink = "INSERT INTO UserEventLink (UserId, EventId) VALUES (@UserId, @EventId);";
        //                command = new SqlCommand(addEventLink, connection);
        //                command.Parameters.AddWithValue("@UserId", userId);
        //                command.Parameters.AddWithValue("@EventId", temp);
        //                command.ExecuteNonQuery();
        //            }
        //        }

        //        connection.Close();
        //        Response.Redirect("~/UserPage.aspx");
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Error" + ex.ToString());
        //    }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        //Int32 EventId = Convert.ToInt32(Request.Cookies["SyncCookie"]["CurrentEventId"]);

        //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //connection.Open();
        //string checkEvent = "SELECT COUNT(*) FROM Events WHERE Id = '" + EventId + "';";
        //SqlCommand command = new SqlCommand(checkEvent, connection);
        //int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        //if (temp != 1)
        //{
        //    connection.Close();
        //}
        //else
        //    try
        //    {
        //        string updateEvent = "UPDATE Events SET Title = @Title, Type = @Type, Location = @Location, StartTime = @StartTime, EndTime = @EndTime, Category = @Category, PartOfSchedule = @PartOfSchedule WHERE Id ='" + EventId.ToString() + "';";
        //        command = new SqlCommand(updateEvent, connection);
        //        command.Parameters.AddWithValue("@Title", Title.Text);
        //        command.Parameters.AddWithValue("@Type", Type.SelectedIndex);
        //        command.Parameters.AddWithValue("@StartTime", Convert.ToDateTime(StartTime.Text));
        //        command.Parameters.AddWithValue("@EndTime", Convert.ToDateTime(EndTime.Text));
        //        command.Parameters.AddWithValue("@Location", Location.Text);
        //        command.Parameters.AddWithValue("@Category", Category.SelectedIndex);
        //        command.Parameters.AddWithValue("@PartOfSchedule", SchedulePart.Checked);
        //        command.ExecuteNonQuery();

        //        connection.Close();
        //        Response.Redirect("~/UserPage.aspx");
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("Error" + ex.ToString());
        //    }
    }

    public void UpdateData()
    {
        //Int32 EventId = Convert.ToInt32(Request.Cookies["SyncCookie"]["CurrentEventId"]);

        //if (EventId != 0)
        //{
        //    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //    connection.Open();
        //    string checkEvent = "SELECT COUNT(*) FROM Events WHERE Id = '" + EventId + "';";
        //    SqlCommand command = new SqlCommand(checkEvent, connection);
        //    int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        //    if (temp != 1)
        //    {
        //        connection.Close();
        //    }
        //    else
        //        try
        //        {
        //            string getEventData = "SELECT Title, Type, Location, StartTime, EndTime, Category, PartOfSchedule FROM Events WHERE Id = '" + EventId + "';";
        //            command = new SqlCommand(getEventData, connection);
        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                Title.Text = reader.GetString(0);
        //                Type.SelectedIndex = reader.GetInt32(1);
        //                Location.Text = reader.GetString(2);
        //                StartTime.Text = Convert.ToString(reader[3]);
        //                EndTime.Text = Convert.ToString(reader[4]);
        //                Category.SelectedIndex = reader.GetInt32(5);
        //                SchedulePart.Checked = reader.GetBoolean(6);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Error" + ex.ToString());
        //        }
        //}

        //updateButton.Visible = EventId != 0;
        //addButton.Visible = EventId == 0;
        //deleteButton.Visible = EventId != 0;
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
        //    Int32 EventId = Convert.ToInt32(Request.Cookies["SyncCookie"]["CurrentEventId"]);

        //    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //    connection.Open();
        //    string checkEvent = "SELECT COUNT(*) FROM Events WHERE Id = '" + EventId + "';";
        //    SqlCommand command = new SqlCommand(checkEvent, connection);
        //    int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        //    if (temp != 1)
        //    {
        //        connection.Close();
        //    }
        //    else
        //        try
        //        {
        //            string deleteEvent = "DELETE FROM Events WHERE Id ='" + EventId.ToString() + "';";
        //            command = new SqlCommand(deleteEvent, connection);
        //            command.ExecuteNonQuery();

        //            connection.Close();
        //            Response.Redirect("~/UserPage.aspx");
        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write("Error" + ex.ToString());
        //        }
        //}
    }
}