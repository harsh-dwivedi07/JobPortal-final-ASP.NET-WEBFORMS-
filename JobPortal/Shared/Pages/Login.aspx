<%@ Page Language="C#" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JobPortal.Shared.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
                body {
            background-color: #f2f2f2;
        }
        .main-div{
            display: flex;
            align-items:center;
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
        .login-text{
            
            text-decoration: none;
            color: black;
            font-weight: bold;
            font-size: 2em;
        }
        td{
            padding: 1em;
            text-align: center;
        }
        .btn-2{
            padding: 1em 3em;
            border-radius: 1em;
            color: white;
            border: none;
            text-align: center;
        }
        .btn-2:hover{
            cursor: pointer;
        }
        .btn-2{
            background-color: green;
        }
    </style>
</head>
<body>
    <div class="main-div">
    <form id="form1" runat="server">
        <div>
            <asp:Login ID="myLogin" runat="server">
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="2" class="login-text">Log In</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ForeColor="Red" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="myLogin"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ForeColor="Red" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="myLogin"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button CssClass="btn-2" ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="myLogin" OnClick="Button1_Click" />
                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 

                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:Login>

        </div>
    </form>
        </div>
</body>
</html>

