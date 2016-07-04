<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <section id="loginForm">
        <h2>Use a local account to log in.</h2>
        <p class="validation-summary-errors">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
        <p> 
            <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">User name</asp:Label>
            <asp:TextBox runat="server" ID="UserName" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">Password</asp:Label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
            </p>
          <p>
            <asp:Button runat="server" ID="LoginButton" CommandName="Login" Text="Log in" OnClick="LoginButton_Click" />
        </p>
        </section>
</asp:Content>