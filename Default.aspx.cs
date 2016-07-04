using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using DayPilot;
using DayPilot.Web;
using DayPilot.Web.Ui;
using DayPilot.Web.Ui.Events;
using System.Security.Principal;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DayPilotCalendar1.StartDate = DateTime.Now;
            DayPilotCalendar1.DataSource = dbGetEvents(DayPilotCalendar1.StartDate, DayPilotCalendar1.Days);
            DataBind();
        }
    }

    private DataTable dbGetEvents(DateTime start, int days)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();

        Int32 userId = 0;
        string userName = Page.User.Identity.Name;

        string getuser = "SELECT Id FROM [User] WHERE username='" + userName + "';";
        SqlCommand comm = new SqlCommand(getuser, connection);
        userId = Convert.ToInt32(comm.ExecuteScalar().ToString());

        string getEvents = "SELECT Id, title, starttime, endtime FROM Goal JOIN userGoal ON Goal.Id = userGoal.GoalId AND userGoal.UserId = " + userId.ToString() + " WHERE NOT ((endtime <= @start) OR (starttime >= @end))";

        SqlDataAdapter da = new SqlDataAdapter(getEvents, connection);
        da.SelectCommand.Parameters.AddWithValue("start", start);
        da.SelectCommand.Parameters.AddWithValue("end", start.AddDays(days));
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    protected void addButton_Click(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();
        string checkEvent = "SELECT COUNT(*) FROM Goal WHERE title = '" + TitleBox.Text + "';";
        SqlCommand command = new SqlCommand(checkEvent, connection);
        int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        if (temp == 1)
        {
            connection.Close();
        }
        else
            try
            {
                DateTime startTime = Convert.ToDateTime(StartDate.Text);
                Int32 year = startTime.Year;
                Int32 month = startTime.Month;
                Int32 day = startTime.Day;

                String str = StartTime.Text;
                String[] s = str.Split(':');
                Int32 hour = Convert.ToInt32(s[0]);
                Int32 minute = Convert.ToInt32(s[1]);
                Int32 sec = Convert.ToInt32(s[2]);

                startTime = new DateTime(year, month, day, hour, minute, sec);

                DateTime endTime = Convert.ToDateTime(EndDate.Text);
                year = endTime.Year;
                month = endTime.Month;
                day = endTime.Day;

                str = EndTime.Text;
                s = str.Split(':');
                hour = Convert.ToInt32(s[0]);
                minute = Convert.ToInt32(s[1]);
                sec = Convert.ToInt32(s[2]);

                endTime = new DateTime(year, month, day, hour, minute, sec);

                string insertEvent = "INSERT INTO Goal(title, startTime, endTime, points, accomplished) VALUES (@title, @startTime, @endTime, @points, @accomplished);";
                command = new SqlCommand(insertEvent, connection);
                command.Parameters.AddWithValue("@title", TitleBox.Text);
                command.Parameters.AddWithValue("@startTime", startTime);
                command.Parameters.AddWithValue("@endTime", endTime);
                command.Parameters.AddWithValue("@points", Convert.ToInt32(Points.Text));
                command.Parameters.AddWithValue("@accomplished", Acc.Checked ? 1 : 0);
                command.ExecuteNonQuery();

                Int32 userId = 0;
                string userName = Page.User.Identity.Name;

                string getuser = "SELECT Id FROM [User] WHERE username='" + userName + "';";
                SqlCommand comm = new SqlCommand(getuser, connection);
                userId = Convert.ToInt32(comm.ExecuteScalar().ToString());

                checkEvent = "SELECT Id FROM [Goal] WHERE title = '" + TitleBox.Text + "';";
                comm = new SqlCommand(checkEvent, connection);
                temp = Convert.ToInt32(comm.ExecuteScalar().ToString());

                string addLink = "INSERT INTO userGoal(UserId, GoalId) VALUES (@userId, @goalId);";
                command = new SqlCommand(addLink, connection);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@goalId", temp);
                command.ExecuteNonQuery();

                connection.Close();
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex.ToString());
            }
    }
  
    public void UpdateData()
    {
        Int32 EventId = Convert.ToInt32(Request.Cookies["SyncCookie"]["CurrentEventId"]);

        if (EventId != 0)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();
            string checkEvent = "SELECT COUNT(*) FROM Goal WHERE Id = '" + EventId + "';";
            SqlCommand command = new SqlCommand(checkEvent, connection);
            int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            if (temp != 1)
            {
                connection.Close();
            }
            else
                try
                {
                    string getEventData = "SELECT title, starttime, endtime, points, accomplished FROM Goal WHERE Id = '" + EventId + "';";
                    command = new SqlCommand(getEventData, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TitleBox.Text = reader.GetString(0);
                        StartDate.Text = reader.GetDateTime(1).ToShortDateString();
                        EndDate.Text = reader.GetDateTime(2).ToShortDateString();
                        Points.Text = reader.GetInt32(3).ToString();
                        Acc.Checked = reader.GetInt32(4) == 1;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error" + ex.ToString());
                }
        }

        editButton.Visible = true;
        deleteButton.Visible = true;
        addButton.Visible = false;
    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {
            Int32 EventId = Convert.ToInt32(Request.Cookies["SyncCookie"]["CurrentEventId"]);

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();
            string checkEvent = "SELECT COUNT(*) FROM Goal WHERE Id = '" + EventId + "';";
            SqlCommand command = new SqlCommand(checkEvent, connection);
            int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
            if (temp != 1)
            {
                connection.Close();
            }
            else
                try
                {
                    string deleteEvent = "DELETE FROM Goal WHERE Id ='" + EventId.ToString() + "';";
                    command = new SqlCommand(deleteEvent, connection);
                    command.ExecuteNonQuery();

                    connection.Close();
                    Response.Redirect("~/Default.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write("Error" + ex.ToString());
                }
        }

    protected void editButton_Click(object sender, EventArgs e)
    {
        Int32 EventId = Convert.ToInt32(Request.Cookies["SyncCookie"]["CurrentEvent"]);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        connection.Open();
        string checkEvent = "SELECT COUNT(*) FROM Goal WHERE Id = '" + EventId + "';";
        SqlCommand command = new SqlCommand(checkEvent, connection);
        int temp = Convert.ToInt32(command.ExecuteScalar().ToString());
        if (temp != 1)
        {
            connection.Close();
        }
        else
            try
            {
                DateTime startTime = Convert.ToDateTime(StartDate.Text);
                Int32 year = startTime.Year;
                Int32 month = startTime.Month;
                Int32 day = startTime.Day;

                String str = StartTime.Text;
                String[] s = str.Split(':');
                Int32 hour = Convert.ToInt32(s[0]);
                Int32 minute = Convert.ToInt32(s[1]);
                Int32 sec = Convert.ToInt32(s[2]);

                startTime = new DateTime(year, month, day, hour, minute, sec);

                DateTime endTime = Convert.ToDateTime(EndDate.Text);
                year = endTime.Year;
                month = endTime.Month;
                day = endTime.Day;

                str = EndTime.Text;
                s = str.Split(':');
                hour = Convert.ToInt32(s[0]);
                minute = Convert.ToInt32(s[1]);
                sec = Convert.ToInt32(s[2]);

                endTime = new DateTime(year, month, day, hour, minute, sec);

                string updateEvent = "UPDATE Events SET Title = @Title, Type = @Type, Location = @Location, StartTime = @StartTime, EndTime = @EndTime, Category = @Category, PartOfSchedule = @PartOfSchedule WHERE Id ='" + EventId.ToString() + "';";
                command = new SqlCommand(updateEvent, connection);
                command.Parameters.AddWithValue("@title", TitleBox.Text);
                command.Parameters.AddWithValue("@starttime", startTime);
                command.Parameters.AddWithValue("@endtime", endTime);
                command.Parameters.AddWithValue("@points", Convert.ToInt32(Points.Text));
                command.Parameters.AddWithValue("@accomplished", Acc.Checked ? 1 : 0);
                command.ExecuteNonQuery();

                connection.Close();
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Error" + ex.ToString());
            }
    }
    protected void DayPilotCalendar1_EventClick(object sender, EventClickEventArgs e)
    {
        Response.Cookies["SyncCookie"]["CurrentEventId"] = e.Id;

        UpdateData();
    }
}