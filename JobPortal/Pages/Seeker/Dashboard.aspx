<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="JobPortal.Pages.Seeker.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .heading{
            text-align:center;
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
        .butn:hover{
            cursor: pointer;
        }
        .buttons{
            text-align: center;
            padding: 1em;
        }
    </style>
    <div class="heading">
    <h3>Welcome Applicant!!</h3>
        </div>
    <div class="buttons">
    <asp:Button ID="Button1" CssClass="butn" runat="server" Text="Profile" OnClick="Profile_Click"/>
    <asp:Button ID="Button2" CssClass="butn" runat="server" Text="Applied Jobs" OnClick="AppliedJob_Click" />
    <asp:Button ID="Button3" CssClass="butn" runat="server" Text="AllJobs" OnClick="AllJobs_Click" />
        </div>
    <div>
        Total No. Of Applictions Submitted:-
        <asp:Label ID="subapp" runat="server" Text=""></asp:Label><br />
        Total No Of Applications Selected
        <asp:Label ID="selectedapp" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
