using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Shared.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies.Clear();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (System.Web.Security.Membership.ValidateUser(myLogin.UserName, myLogin.Password))
            {
                bool rememberme = false;
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                             1, // Version number
                             myLogin.UserName, // User name
                              DateTime.Now, // Issue time
                             DateTime.Now.AddMinutes(30), // Expiration time
                              rememberme, // Whether to persist the cookie
                //userData, // User data (optional)
                              FormsAuthentication.FormsCookiePath // Cookie path
                                  );

                // Encrypt the ticket and create a cookie
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    encryptedTicket
                );

                // Add the cookie to the response
                Response.Cookies.Add(cookie);
                MembershipUser usrInfo = System.Web.Security.Membership.GetUser(myLogin.UserName);
                String[] Role = System.Web.Security.Roles.GetRolesForUser(usrInfo.UserName);
                Session["UserId"] = usrInfo.ProviderUserKey;
                if (Role[0] == "Applicant")
                {
                    Response.Redirect("../../Pages/Seeker/Dashboard.aspx");
                }

                else
                {

                    Response.Redirect("../../Pages/Recruiter/Dashboard.aspx");
                }

            }
            else
            {

            }
        }
    }
}