<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostNewJob.aspx.cs" Inherits="JobPortal.Pages.Recruiter.PostNewJob" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #f2f2f2 !important;
        }

        .heading {
            text-align: center;
            margin: 2em 0em;
        }

        .main-div {
            display: flex;
            align-items: center;
            justify-content: center;
        }

        #form {
            background-color: white;
            width: 30%;
            height: 40%;
            border-radius: 1em;
            padding: 2em;
            text-align: center;
        }

        p {
            font-weight: bold;
            padding: 0em 1em;
            display: flex;
            align-items: center;
            flex-direction: column;
        }

        span {
            font-weight: 100;
            text-align: right;
        }

        .content-div {
            background-color: white;
            padding: 3em;
            border-radius: 2em;
        }

        input, textarea {
            margin: 1em;
        }

        .btn-2 {
            padding: 1em 3em;
            border-radius: 1em;
            color: white;
            border: none;
            text-align: center;
        }

            .btn-2:hover {
                cursor: pointer;
            }

        .btn-2 {
            background-color: green;
        }
    </style>

</head>
<body>
    <div class="heading">
        <h1>Welcome to Job Portal!!</h1>
    </div>
    <div class="heading">
        Hey Recruiter Post a new Job:-
    </div>
    <div class="main-div">

        <br />
        <br />
        <br />
        <form id="form" data-bind="submit: submitForm">
            <p>

                <label for="name" class="form-label">Company Name:-</label>
                <input type="text" data-bind="value: cmpName" /><br />
            </p>
            <p>

                <label for="name" class="form-label">Job Title:-</label>
                <input type="text" data-bind="value: jobTtl" /><br />
            </p>
            <p>
                <label for="name" class="form-label">Company Location:-</label>

                <input type="text" data-bind="value: cmpLoc" /><br />
            </p>
            <p>
                <label for="name" class="form-label">Job Description:-</label>
                <textarea name="message" data-bind="value: jobDesc"></textarea><br />
            </p>
            <p>
                <%-- <input class="btn-2" type="submit" value="Submit"/>--%>
                <button class="btn-2" type="submit" data-bind="enable: isValid">Submit</button>
        </form>
        <input id="userId" type="hidden" runat="server" />
    </div>


    <script src="https://cdn.jsdelivr.net/npm/knockout@3.5.1/build/output/knockout-latest.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/knockout-validation/2.0.3/knockout.validation.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="../../Scripts/JSFiles/postnewjob.js"></script>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
