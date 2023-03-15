using JobPortal.Models;
using JobPortal.Repository.Implementation;
using JobPortal.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Pages.Seeker
{
    public partial class AppliedJobsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        protected void DisplayData()
        {
            IJobSeeker _jobSeeker = new JobSeeker();
            Guid userId = (Guid)Session["UserID"];

            var modelData = _jobSeeker.GetAllJobsByUserId(userId); // retrieve your model data
            repeater.DataSource = modelData;
            repeater.DataBind();
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            Guid userId = (Guid)Session["UserID"];
            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            Label JobLabel = (Label)item.FindControl("LabelJobId");
            string ColumnName = JobLabel.Text;
            Guid JobId = new Guid(ColumnName);
            IJobSeeker _jobSeeker = new JobSeeker();
            _jobSeeker.WithdrawApplication(userId,JobId);
            Response.Redirect("AppliedJobsPage.aspx");

        }
        protected void JobDetails_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            RepeaterItem item = (RepeaterItem)button.NamingContainer;
            Label JobLabel = (Label)item.FindControl("LabelJobId");
            string ColumnName = JobLabel.Text;
            Session["JobId"] = new Guid(ColumnName);
            Response.Redirect("JobDetails.aspx");
        }


    }
}