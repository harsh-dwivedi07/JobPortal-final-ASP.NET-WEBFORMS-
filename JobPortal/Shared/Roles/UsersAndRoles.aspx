<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UsersAndRoles.aspx.cs" Inherits="JobPortal.Shared.Roles.UsersAndRoles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        .Important 
{ 
     font-size: large; 
     color: Red; 
}
    </style>
    <h3>User Role Management</h3>
    <p align="center"> 

     <asp:Label ID="ActionStatus" runat="server" CssClass="Important"></asp:Label> 
</p>
    <h3>Manage Roles By User</h3> 

<p> 
     <b>Select a User:</b> 
     <asp:DropDownList ID="UserList" runat="server" AutoPostBack="True" 
          DataTextField="UserName" DataValueField="UserName"> 

     </asp:DropDownList> 
</p> 
<p> 
     <asp:Repeater ID="UsersRoleList" runat="server"> 
          <ItemTemplate> 
               <asp:CheckBox runat="server" ID="RoleCheckBox" AutoPostBack="true" 

                    Text='<%# Container.DataItem %>' OnCheckedChanged="RoleCheckBox_CheckChanged"/> 
               <br /> 
          </ItemTemplate> 
     </asp:Repeater> 
</p>
    <%--<h3>Manage Users By Role</h3> 
<p> 
     <b>Select a Role:</b> 

     <asp:DropDownList ID="RoleList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RoleList_SelectedIndexChanged"></asp:DropDownList> 
</p> 
<p>      <asp:GridView ID="RolesUserList" runat="server" AutoGenerateColumns="false" 
        
          EmptyDataText="No users belong to this role."> 
          <Columns> 
               <asp:TemplateField HeaderText="Users"> 
                    <ItemTemplate> 
                         <asp:Label runat="server" id="UserNameLabel" 
                              Text='<%# Container.DataItem %>'></asp:Label> 

                    </ItemTemplate> 
               </asp:TemplateField> 
          </Columns> 
     </asp:GridView> </p>--%>
</asp:Content>
