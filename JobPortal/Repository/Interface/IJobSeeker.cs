using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace JobPortal.Repository.Interface
{
    internal interface IJobSeeker
    {
        JobSeekerModel AddJobSeeker(JobSeekerModel jobSeeker);

        JobSeekerModel GetJobSeekerByUserId(Guid UserId);
        List<JobDetailsModel> GetAllJobDetails();
        List<AppliedJobsModel> GetAllJobsByUserId(Guid UserId);
        JobDetailsModel GetJobDetailsByJobId(Guid JobId);
        AppliedJobsModel ApplyForJob(Guid JobId,Guid UserId);
        JobSeekerModel UpdateJobSeekerDetails(Guid UserId, JobSeekerModel Seeker);
        int countOfTotalApplicantsByUserId(Guid UserId);
        int countOfTotalApplicantsSelectedByUserId(Guid UserId);
        void WithdrawApplication(Guid UserId, Guid JobId);

    }
}
