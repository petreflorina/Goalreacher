<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
   
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <DayPilot:DayPilotCalendar ID="DayPilotCalendar1" runat="server" 
          DataStartField="starttime" 
          DataEndField="endtime"
          DataTextField="title" 
          DataIdField="Id" 
          Days="7"
          EventClickHandling="PostBack"
          OnEventClick="DayPilotCalendar1_EventClick"/>
      <div>
    <h2>
        Event details
    </h2>
    <div>
        <ol>
            <li>
                <asp:Label ID="Label1" runat="server" AssociatedControlID="TitleBox">Title</asp:Label>
                <asp:TextBox runat="server" ID="TitleBox" EnableViewState="true"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TitleBox"
                    CssClass="field-validation-error" ErrorMessage="The title field is required." />
            </li>
            <li>
                <asp:Label ID="Label3" runat="server" AssociatedControlID="StartDate">Start Date</asp:Label>
                <asp:TextBox runat="server" ID="StartDate" ClientIDMode="static" EnableViewState="true" Height="30"/>   
             </li>
             <li>
                <asp:Label ID="Label4" runat="server" AssociatedControlID="StartTime">Start Time</asp:Label>
                <asp:TextBox runat="server" ID="StartTime" ClientIDMode="static" EnableViewState="true"/>   
            </li>
             <li>
                <asp:Label ID="Label5" runat="server" AssociatedControlID="EndDate">End Date</asp:Label>
                <asp:TextBox runat="server" ID="EndDate" ClientIDMode="static" EnableViewState="true" Height="30"/>   
             </li>
             <li>
                <asp:Label ID="Label8" runat="server" AssociatedControlID="EndTime">End Time</asp:Label>
                <asp:TextBox runat="server" ID="EndTime" ClientIDMode="static" EnableViewState="true"/>   
            </li>
             <li>
                <asp:Label ID="Label2" runat="server" AssociatedControlID="Points">Points</asp:Label>
                <asp:TextBox runat="server" ID="Points" EnableViewState="true"/>
            </li>
            <li>
                <asp:Label ID="Label10" runat="server" AssociatedControlID="Acc">Accomplished</asp:Label>
                <asp:CheckBox runat="server" ID="Acc"/>
            </li>
        </ol>
    </div>
     <asp:Button ID="addButton" runat="server" Text="Add event" OnClick="addButton_Click"/>
     <asp:Button ID="editButton" runat="server" Text="Edit event" OnClick="editButton_Click"/>
     <asp:Button ID="deleteButton" runat="server" Text="Delete event" OnClick="deleteButton_Click"/>
</div>
     <script>
         $('#StartDate').datepicker(
         {
             format:'dd/mm/yyyy'
         });
    </script>

 <script>
     $('#EndDate').datepicker(
         {
             format:'dd/mm/yyyy'
         });
    </script>
     <script type="text/javascript">
         $('#StartTime').timepicker(
         {
             showMeridian: false,
             showSeconds: true
         });
    </script>
    <script type="text/javascript">
        $('#EndTime').timepicker(
        {
            showMeridian: false,
            showSeconds: true
        });
    </script>
</asp:Content>