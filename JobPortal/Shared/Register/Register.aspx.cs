using JobPortal.Models;
using JobPortal.Repository.Implementation;
using JobPortal.Repository.Interface;
using JobPortal.Shared.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Shared.Membership
{
    public partial class CreatingUserAccount : System.Web.UI.Page
    {
        const string passwordQuestion = "What is your favorite color";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SecurityQuestion.Text = passwordQuestion;
                BindRolesToList();

            }
           
        }
        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus createStatus;
            MembershipUser newUser = System.Web.Security.Membership.CreateUser(Username.Text, Password.Text, Email.Text, passwordQuestion, SecurityAnswer.Text, true, out createStatus);
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    CreateAccountResults.Text = "The user account was successfully created!";
                    AddUser();
                    Response.Redirect("../Pages/Login.aspx");
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    CreateAccountResults.Text = "There already exists a user with this username.";
                    break;

                case MembershipCreateStatus.DuplicateEmail:
                    CreateAccountResults.Text = "There already exists a user with this email address.";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    CreateAccountResults.Text = "There email address you provided in invalid.";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    CreateAccountResults.Text = "There security answer was invalid.";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    CreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";

                    break;
                default:
                    CreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }
        }

        private void BindRolesToList()
        {
            // Get all of the roles 

            string[] roles = System.Web.Security.Roles.GetAllRoles();
            UsersRoleList.DataSource = roles;
            UsersRoleList.DataBind();

            //RoleList.DataSource = roles;
            //RoleList.DataBind();
        }

        protected void RoleCheckBox_CheckChanged(object sender, EventArgs e)
        {
            // Reference the CheckBox that raised this event 
            CheckBox RoleCheckBox = sender as CheckBox;

            // Get the currently selected user and role 
            string selectedUserName = Username.Text;

            string roleName = RoleCheckBox.Text;

            // Determine if we need to add or remove the user from this role 
            if (RoleCheckBox.Checked)
            {
                // Add the user to the role 
                System.Web.Security.Roles.AddUserToRole(selectedUserName, roleName);
               
            }
            else
            {
                // Remove the user from the role 
                System.Web.Security.Roles.RemoveUserFromRole(selectedUserName, roleName);
              
            }
        }

        private void AddUser()
        {
            MembershipUser usrInfo = System.Web.Security.Membership.GetUser(Username.Text);
            String[] Role = System.Web.Security.Roles.GetRolesForUser(usrInfo.UserName);
            if (Role[0] == "Recruiters")
            {
                JobRecruiterModel rec = new JobRecruiterModel();
                rec.UserId = (Guid)usrInfo.ProviderUserKey;
                rec.CreatedAt= DateTime.Now;
                rec.UpdatedAt= DateTime.Now;
                rec.DOB=DateTime.Now;
                rec.email = Email.Text;
                rec.firstName = "";
                rec.lastName = "";
                rec.CompanyName = "";
                rec.Mobile = "";
                IJobRecruiter _jobrec = new JobRecruiter();
                _jobrec.AddJobRecruiter(rec);
            }
            if (Role[0] == "Applicant")
            {
                JobSeekerModel seek = new JobSeekerModel();
                seek.UserId = (Guid)usrInfo.ProviderUserKey;
                seek.CreatedAt = DateTime.Now;
                seek.UpdatedAt = DateTime.Now;
                seek.DOB = DateTime.Now;
                seek.email = Email.Text;
                IJobSeeker _jobrec = new JobSeeker();
                _jobrec.AddJobSeeker(seek);
            }

        }

    }
}