using JobPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace JobPortal.Repository.Interface
{
    internal interface IJobRecruiter
    {
        JobRecruiterModel AddJobRecruiter(JobRecruiterModel jobrecruiter);
        List<JobDetailsModel> GetAllJobsByUserId(Guid UserId);
        JobRecruiterModel GetJobRecruiterByUserId(Guid UserId);
        JobDetailsModel AddNewJob(JobDetailsModel jobDetail);
        JobDetailsModel GetJobDetailByJobId(Guid JobId);
        JobRecruiterModel UpdateJobRecruiterDetails(Guid UserId, JobRecruiterModel Seeker);
        List<JobSeekerModel> GetAllApplicantsForJobId(Guid JobId);
        List<Guid> GetAllUserIdByJobId(Guid JobId);
        List<AppliedJobsModel> GetAllUsersByJobId(Guid JobId);
        AppliedJobsModel GetApplicantByJobIdandUserId(Guid JobId,Guid UserId);
        List<Guid> GetAllUserIdByJobIdAndStatus(Guid JobId, int Status);
        List<JobSeekerModel> GetAllApplicantsForJobIdAndStatus(Guid JobId, int Status);
        void DeleteJob( Guid jobId);
        void SelectCandidate(Guid UserId, Guid JobId);
        void RejectCandidate(Guid UserId, Guid JobId);
        List<JobSeekerModel> GetAllApplicantsByCompanyName(String cname);
    }
}
