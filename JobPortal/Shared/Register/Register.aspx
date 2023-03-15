<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="JobPortal.Shared.Membership.CreatingUserAccount" %>

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
            width: 30%;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            border-radius: 1em;
            padding: 2em;
            margin: 6em 0em;
            text-align: center;
        }

        .login-text {
            text-decoration: none;
            color: black;
            font-weight: bold;
            font-size: 2em;
        }

        p {
            padding: 1em;
            text-align: center;
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
    <h2>Create a new User:</h2>
    <p>
        Enter a Username:
        <asp:TextBox ID="Username" runat="server"></asp:TextBox>

    </p>
    <p>
        Who you are?
     
            <asp:Repeater ID="UsersRoleList" runat="server">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true"
                        Text='<%# Container.DataItem %>' OnCheckedChanged="RoleCheckBox_CheckChanged" />
                </ItemTemplate>
            </asp:Repeater>
    </p>
    <p>
        Enter your Password:

        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
    </p>
    <p>
        Enter your Email Address:
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="SecurityQuestion" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="SecurityAnswer" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button CssClass="btn-2" ID="Button1" runat="server" Text="Create The User Account" OnClick="CreateAccountButton_Click" />
    </p>
    <asp:Label ID="CreateAccountResults" forecolor="Red" runat="server" Text=""></asp:Label>
</asp:Content>
