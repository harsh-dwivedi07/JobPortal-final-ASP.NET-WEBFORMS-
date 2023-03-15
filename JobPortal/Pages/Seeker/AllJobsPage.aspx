<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AllJobsPage.aspx.cs" Inherits="JobPortal.Pages.Seeker.AllJobsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

    <asp:Repeater ID="repeater" runat="server">
        <HeaderTemplate>
             <div class="container">
            <table class="table">
                <tr>
                    <th>Job Title</th>
                    <th>Job Description</th>
                    <th>Company Name</th>
                    <th>Company Location</th>

                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <asp:Label ID="LabelJobId" runat="server" Text='<%# Eval("JobId") %>' Visible="false" />
                <td><%# Eval("JobTitle") %></td>
                <td><%# Eval("JobDescription") %></td>
                <td><%# Eval("CompanyName") %></td>
                <td><%# Eval("CompanyLocation") %></td>

                <td>
                    <asp:Button class="btn-2" ID="Button1" runat="server" Text="Apply" OnClick="Apply_Click"
                        Visible='<%# Convert.ToInt32(Eval("isActive")) == 1 %>' /></td>


            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
            </div>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
