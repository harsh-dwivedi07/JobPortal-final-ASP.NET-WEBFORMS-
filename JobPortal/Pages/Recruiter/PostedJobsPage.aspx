<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostedJobsPage.aspx.cs" Inherits="JobPortal.Pages.Recruiter.PostedJobsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .jobs-heading {
            text-align: center;
        }

        .main-div {
            display: flex;
            align-items: center;
            justify-content: center;
        }

        /*  table {
            border-radius: 1em;
        }

        table, tr, td, th {
            padding: 1em;
        }

        table, tr, td {
            border: 1px solid black;
        }*/

        .btn-1, .btn-2 {
            padding: 1em 3em;
            border-radius: 1em;
            color: white;
            border: none;
        }

            .btn-1:hover, .btn-2:hover {
                cursor: pointer;
            }

        .btn-1 {
            background-color: red;
        }

        .btn-2 {
            background-color: green;
        }
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="heading">
        <h1>Welcome to Job Portal!!</h1>
    </div>
    <h3>Jobs Posted are:-</h3>
    <%--<pre data-bind="text: ko.toJSON($data, null, 2)"></pre>--%>
    <input id="userId" type="hidden" runat="server" />
    <div>

        <%--        <ul data-bind="foreach:items">
            <li data-bind="text: $data"></li>
        </ul>--%>
        <div class="container">
            <table class="table">
                <thead>
                    <tr>
                        <th>Company Name</th>
                        <th>Company Location</th>
                        <th>Job Title</th>
                        <th>Job Description</th>
                        <th>View Applicants</th>
                    </tr>
                </thead>
                <tbody data-bind="foreach:items">
                    <tr>
                        <td data-bind="text: CompanyName"></td>
                        <td data-bind="text: CompanyLocation"></td>
                        <td data-bind="text: JobTitle"></td>
                        <td data-bind="text: JobDescription"></td>
                        <!-- ko if: $parent.getStatus($data) === 'Closed' -->
                        <td>
                            <span style='color: red'>Job Is Closed</span>
                        </td>
                        <!-- /ko -->
                        <!-- ko if: $parent.getStatus($data) === 'Open' -->
                        <td>
                            <button data-bind="click: $parent.onClick" class="btn btn-primary">View Applicants</button></td>
                        <td>
                            <button data-bind="click: $parent.delete" class="btn btn-danger">Delete Job</button>
                        </td>
                        <!-- /ko -->
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/knockout@3.5.1/build/output/knockout-latest.js"></script>
    <script src="../../Scripts/JSFiles/postedjobs.js"></script>
</body>
</html>
