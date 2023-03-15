<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewApplicant.aspx.cs" Inherits="JobPortal.Pages.Recruiter.ViewApplicant" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #content-div {
            text-align: center;
            padding-left: 20vw;
        }

        span {
            padding: 2em;
        }

        .data-div {
            width: 50%;
            border: 1px solid black;
            padding: 1em 0em;
        }

        .heading {
            margin: 0;
            padding: 1em;
        }

        table {
            border-radius: 1em;
        }

        table, tr, td, th {
            padding: 1em;
        }

        table, tr, td {
            border: 1px solid black;
        }

        .applicant-btn {
            width: 10vw;
            height: 10vh;
            text-align: center;
            font-weight: bold;
             cursor: pointer;
        }

        .filterdiv {
            box-shadow: 2px 2px 4px rgba(0, 0, 0, 0.3);
            height: 15vh;
            width: 30vw;
            padding: 1em;
            margin: 20px;
        }

        .fetchbtn {
            height: 7vh;
            width: 8vw;
            margin-left: 15px;
            cursor: pointer;
            font-weight: bold;
            border-radius: 10px;
            border-width:0px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/knockout@3.5.1/build/output/knockout-latest.js"></script>
</head>
<body>
    <h4>Applicants Who Applied For This Job Are:-</h4>
    <div class="filterdiv">
        <p><b>View Applicants Who are:-</b></p>
        <label>
            <input type="radio" name="All" value="All" data-bind="checked: selectedOption" />
            All
        </label>
        <label>
            <input type="radio" name="Selected" value="Selected" data-bind="checked: selectedOption" />
            Selected
        </label>
        <label>
            <input type="radio" name="Rejected" value="Rejected" data-bind="checked: selectedOption" />
            Rejected
        </label>
        <button data-bind="click: fetch" class="fetchbtn">Fetch</button>
    </div>
    <br />
    <br />
    <div>
        <table>
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Email</th>
                    <th>Mobile Number</th>
                    <th>Experience</th>
                </tr>
            </thead>
            <tbody data-bind="foreach:items">
                <tr>
                    <td data-bind="text: firstName"></td>
                    <td data-bind="text:lastName"></td>
                    <td data-bind="text: email"></td>
                    <td data-bind="text: Mobile"></td>
                    <td data-bind="text: Experience"></td>


                    <td>
                        <!-- ko if: $parent.getStatus($data) === 'Selected' -->
                        <span style='color: green'>Candidate is Selected!!</span>
                        <!-- /ko -->
                        <!-- ko if: $parent.getStatus($data) === 'Rejected' -->
                        <span style='color: red'>Candidate got Rejected!!</span>
                        <!-- /ko -->
                        <!-- ko if: $parent.getStatus($data) === 'Pending' -->
                        <button data-bind="click: $parent.onClick_Select" style='color: green' class='applicant-btn'>Select Applicant</button>
                        <button data-bind="click: $parent.onClick_Reject" style='color: red' class='applicant-btn'>Reject Applicant</button>
                        <!-- /ko -->
                    </td>
                </tr>

            </tbody>
        </table>
    </div>
    <div id="content-div"></div>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/knockout@3.5.1/build/output/knockout-latest.js"></script>

    <script src="../../Scripts/JSFiles/viewapplicant.js"></script>
</body>
</html>
