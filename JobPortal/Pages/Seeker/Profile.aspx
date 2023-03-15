<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" Async="true" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="JobPortal.Pages.Seeker.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            background-color: #f2f2f2;
        }

        .main-div {
            display: flex;
            align-items: center;
            justify-content: center;
        }

        #form1 {
            background-color: white;
            /*          width: 30%;*/
            height: 40%;
            border-radius: 1em;
            padding: 2em;
            text-align: center;
        }
/*
        p {
            font-weight: bold;
            padding: 1em;
            display: flex;
            align-items: center;
            justify-content: space-between;
        }*/

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
    </style>
    <h3>View Your Details!!</h3>
    <div id="form1">
        <p class="firstname mb-3">

            <label for="name" class="form-label">FirstName:</label>
            <asp:TextBox ID="FirstName" CssClass="form-control" runat="server" ToolTip="Enter First Name"></asp:TextBox>
        </p>
        <p class="lastname mb-3">

            <label for="name" class="form-label">LastName:</label>
            <asp:TextBox ID="LastName" CssClass="form-control" runat="server" ToolTip="Enter Last Name"></asp:TextBox>
        </p>
        <p class="email mb-3">

            <label for="name" class="form-label">E-mail:</label>
            <asp:TextBox ID="Email" runat="server" CssClass="form-control" ToolTip="Enter Email" ReadOnly="true"></asp:TextBox>
        </p>
        <p class="mobile mb-3">

            <label for="name" class="form-label">Mobile No.:</label>
            <asp:TextBox ID="Mobile" runat="server" CssClass="form-control" ToolTip="Enter Mobile Number"></asp:TextBox>
        </p>
        <p class="dob mb-3">

            <label for="name" class="form-label">D.O.B:</label>
            <asp:TextBox ID="DOB" runat="server" CssClass="form-control" ToolTip="Enter DOB"></asp:TextBox>
        </p>
        <p class="location mb-3">

            <label for="name" class="form-label">Current Location:</label>
            <asp:TextBox ID="Location" runat="server" CssClass="form-control" ToolTip="Enter Current Location"></asp:TextBox>
        </p>
        <p class="location mb-3">

            <label for="name" class="form-label">Experience:</label>
            <asp:TextBox ID="Experience" runat="server" CssClass="form-control" ToolTip="Enter Current Location"></asp:TextBox>
        </p>
        <p class="about mb-3">
            
             <label for="name" class="form-label">Short Description:</label>
       <asp:TextBox ID="about" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
        </p>
        <asp:Button Class="btn-2" ID="Button1" runat="server" Text="Update Details" OnClick="Button1_Click" />
    </div>
</asp:Content>
