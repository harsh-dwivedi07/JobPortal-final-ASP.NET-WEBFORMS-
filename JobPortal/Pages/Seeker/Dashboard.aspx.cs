using JobPortal.Repository.Implementation;
using JobPortal.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Pages.Seeker
{
    public partial class Dashboard : System.Web.UI.Page
    {
        IJobSeeker _jobseeker = new JobSeeker();
        protected void Page_Load(object sender, EventArgs e)
        {
            Guid userID = (Guid)Session["UserID"];
            subapp.Text= _jobseeker.countOfTotalApplicantsByUserId(userID).ToString();
            selectedapp.Text= _jobseeker.countOfTotalApplicantsSelectedByUserId(userID).ToString();
        }

        protected void Profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void AppliedJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppliedJobsPage.aspx");
        }

        protected void AllJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllJobsPage.aspx");
        }
    }
}