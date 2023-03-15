<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="JobDetails.aspx.cs" Inherits="JobPortal.Pages.Seeker.JobDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content class="main-div" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .main-div {
            display: flex;
            align-items: center;
            justify-content: center;
        }
        p{
            font-weight:bold;
            padding: 1em;
        }
        span{
            font-weight:100;
        }
        .content-div {
            background-color: white;
            padding: 3em;
            border-radius: 2em;
        }

    </style>
    <div class="content-div">
    <p>
    Company Name :
        
    <asp:Label ID="CompanyLabel" runat="server" Text=""></asp:Label><br />
        </p>
    <p>
    Job Title:
               
    <asp:Label ID="JobTitleLabel" runat="server" Text="Label"></asp:Label><br />
         </p>
    <p>
    Company Location:

    <asp:Label ID="LocationLabel" runat="server" Text="Label"></asp:Label><br />
     </p>

    <p>
    Job Description:

    <asp:Label ID="DescriptionLabel" runat="server" Text="Label"></asp:Label>
     </p>
        </div>

</asp:Content>
