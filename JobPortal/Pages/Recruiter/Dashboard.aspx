<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="JobPortal.Pages.Recruiter.Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        body {
            background-color: #f2f2f2;
        }

        .heading {
            text-align: center;
            margin: 2em 0em;
        }

        .butn {
            height: 20vh;
            width: 30%;
            color: black;
            font-weight: bold;
            margin: 1em;
            background-color: #f9f9f9;
            border-radius: 1em;
        }

            .butn:hover {
                cursor: pointer;
            }

        .buttons {
            text-align: center;
            padding: 1em;
            display: flex;
            align-items: center;
            justify-content: space-evenly;
        }
    </style>
</head>
<body>
    <div class="heading">
        <h1>Welcome to Job Portal!!</h1>
    </div>
    <div class="heading">
        <h3>Welcome Recruiter!!</h3>
    </div>
    <div class="buttons">
        <button class="butn" type="button" id="profile">Profile</button><br />
        <button class="butn" type="button" id="jobButton">Jobs Posted.</button><br />
        <button class="butn" type="button" id="newjobButton">Post a Job.</button>
    </div>


    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../../Scripts/JSFiles/dashboard.js"></script>
</body>
</html>
