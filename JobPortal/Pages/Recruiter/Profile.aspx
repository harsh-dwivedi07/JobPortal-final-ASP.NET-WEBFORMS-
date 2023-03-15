<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="JobPortal.Pages.Recruiter.Profile" %>

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
        }

        .main-div {
            display: flex;
            align-items: center;
            justify-content: center;
        }

        #form1 {
            background-color: white;
            width: 30%;
            height: 40%;
            border-radius: 1em;
            padding: 2em;
            text-align: center;
        }

        p {
            font-weight: bold;
            padding: 1em;
            display: flex;
            align-items: center;
            justify-content: space-between;
        }

        span {
            font-weight: 100;
        }

        .content-div {
            background-color: white;
            padding: 3em;
            border-radius: 2em;
        }

        .btn-2 {
            padding: 1em 3em;
            border-radius: 1em;
            color: white;
            border: none;
        }

            .btn-2:hover {
                cursor: pointer;
            }

        .btn-2 {
            background-color: green;
        }

        input {
            color: black;
        }
    </style>
</head>
<body>
    <div class="heading">
        <h3>View Your Details!!</h3>
    </div>
    <div class="main-div">

        <form id="form1" data-bind="submit: submitForm">
            <p class="firstname">
                FirstName
      <input id="firstName" alt="Enter First Name" data-bind="value: firstName"/>
            </p>
            <p class="lastname">
                LastName:
       <input id="lastName" text="Enter Last Name" data-bind="value: lastName"/>
            </p>
            <p class="email">
                E-mail:
       <input id="email" text="Enter Email" readonly="true" data-bind="value: email"/>
            </p>
            <p class="mobile">
                Mobile No.:
       <input id="Mobile" text="Enter Mobile Number" data-bind="value: Mobile"/>
            </p>
            <p class="dob">
                D.O.B:
       <input id="DOB" text="Enter DOB"  data-bind="value: DOB"/>
            </p>

            <p class="companyname">
                Company Name:
       <input id="CompanyName" data-bind="value: CompanyName"/>
            </p>
            <button class="btn-2" id="Button1" text="Update Details">Update Details</button>
        </form>
        <input id="userId" type="hidden" runat="server" />
    </div>
    <script src="https://cdn.jsdelivr.net/npm/knockout@3.5.1/build/output/knockout-latest.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../../Scripts/JSFiles/profile.js"></script>
</body>
</html>
