<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageRoles.aspx.cs" Inherits="JobPortal.Shared.Roles.ManageRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <b>Create a New Role: </b>
<asp:TextBox ID="RoleName" runat="server"></asp:TextBox>
<br />
<asp:Button ID="CreateRoleButton" runat="server" Text="Create Role" OnClick="CreateRoleButton_Click"/>
    <asp:GridView ID="RoleList" runat="server" AutoGenerateColumns="False" OnRowDeleting="RoleList_RowDeleting">
         <Columns>
 <asp:CommandField DeleteText="Delete Role" ShowDeleteButton="True" />
 <asp:TemplateField HeaderText="Role">
 <ItemTemplate>
 <asp:Label runat="server" ID="RoleNameLabel" Text='<%# Container.DataItem %>' />
 </ItemTemplate>
 </asp:TemplateField>
 </Columns>
    </asp:GridView>
</asp:Content>
