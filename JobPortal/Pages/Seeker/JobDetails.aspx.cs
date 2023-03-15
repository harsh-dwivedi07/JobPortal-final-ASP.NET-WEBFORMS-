using JobPortal.Models;
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
    public partial class JobDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IJobSeeker _jobseeker = new JobSeeker();
            Guid JobId= (Guid)Session["JobId"];
           JobDetailsModel job= _jobseeker.GetJobDetailsByJobId(JobId);
            CompanyLabel.Text = job.CompanyName;
            JobTitleLabel.Text = job.JobTitle;
            LocationLabel.Text = job.CompanyLocation;
            DescriptionLabel.Text = job.JobDescription;
        }
    }
}