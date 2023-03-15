<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AppliedJobsPage.aspx.cs" Inherits="JobPortal.Pages.Seeker.AppliedJobsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .jobs-heading {
            text-align: center;
        }
                .main-div{
            display: flex;
            align-items:center;
            justify-content: center;
        }
              /*  table{
                    border-radius: 1em;
                }
        table, tr, td, th {
            padding: 1em;
        }
        table, tr, td {
             border: 1px solid black;
        }*/
        .btn-1, .btn-2{
            padding: 1em 3em;
            border-radius: 1em;
            color: white;
            border: none;
        }
        .btn-1:hover, .btn-2:hover{
            cursor: pointer;
        }
        /*.btn-1{
            background-color: red;
        }
        .btn-2{
            background-color: green;
        }*/
    </style>
    <div class="jobs-heading">
        <h3>Here are your applied Jobs Listing</h3>
    </div>
    <asp:Repeater ID="repeater" runat="server">
        <HeaderTemplate>
 <div class="container">
            <table class="table">
                <tr>
                    <th>Job ID</th>
                    <th>Name</th>
                </tr>
                
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="LabelJobId" runat="server"  Text='<%# Eval("JobId") %>'></asp:Label></td>
                <td><%# Eval("CompanyName") %></td>
                <td>
                    <asp:Button  ID="Button1" CssClass="btn btn-danger" runat="server" Text="Withdraw" OnClick="btnWithdraw_Click" /></td>
                <td>
                    <asp:Button  CssClass="btn btn-primary" ID="Button2" runat="server" Text="Details" OnClick="JobDetails_Click" /></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            </div>
        </FooterTemplate>
    </asp:Repeater>
   
</asp:Content>
