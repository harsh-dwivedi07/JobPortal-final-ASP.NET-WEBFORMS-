﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Pages.Recruiter
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Job_Posted(object sender, EventArgs e)
        {
            Response.Redirect("PostedJobsPage.aspx");
        }
    }
}