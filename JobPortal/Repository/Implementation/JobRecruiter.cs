using JobPortal.Models;
using JobPortal.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using static System.Collections.Specialized.BitVector32;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;

namespace JobPortal.Repository.Implementation
{
    public class JobRecruiter : IJobRecruiter
    {
        private DataContext db = new DataContext();

        public JobRecruiterModel AddJobRecruiter(JobRecruiterModel jobrecruiter)
        {
            db.jobRecruiter.Add(jobrecruiter);
            db.SaveChanges();
            return jobrecruiter;
        }
        public JobRecruiterModel GetJobRecruiterByUserId(Guid UserId)
        {
            JobRecruiterModel recruiter = db.jobRecruiter.Where(x => x.UserId == UserId).FirstOrDefault();
            if (recruiter == null) return null;
            return recruiter;
        }
        public JobDetailsModel AddNewJob(JobDetailsModel jobDetail)
        {
            db.jobDetails.Add(jobDetail);
            db.SaveChanges();
            return jobDetail;
        }
        public JobDetailsModel GetJobDetailByJobId(Guid JobId)
        {

            JobDetailsModel jobs = db.jobDetails.Where(x => x.JobId == JobId).FirstOrDefault();
            if (jobs == null) return null;
            return jobs;
        }
        public List<JobDetailsModel> GetAllJobsByUserId(Guid UserId)
        {
            List<JobDetailsModel> jobs = db.jobDetails.Where(x => x.UserId == UserId).ToList();
            if (jobs == null) return null;
            return jobs;
        }

        public JobRecruiterModel UpdateJobRecruiterDetails(Guid UserId, JobRecruiterModel Seeker)
        {

            var seek = db.jobRecruiter.Find(UserId);
            if (seek == null)
            {

                AddJobRecruiter(Seeker);
            }
            else
            {
                db.jobRecruiter.Attach(seek);

                //seek.email = Seeker.email;
                seek.firstName = Seeker.firstName;
                seek.lastName = Seeker.lastName;
                seek.DOB = Seeker.DOB;
                seek.CompanyName = Seeker.CompanyName;
                seek.Mobile = Seeker.Mobile;
                seek.UpdatedAt = DateTime.Now;
                var entry = db.Entry(seek);
                entry.Property(e => e.CompanyName).IsModified = true;

                db.SaveChanges();
            }
            return Seeker;

        }
        public List<Guid> GetAllUserIdByJobId(Guid JobId)
        {
            List<Guid> ids = db.appliedJobs.Where(x => x.JobId == JobId).Select(x => x.UserId).ToList();
            return ids;
        }
        public List<AppliedJobsModel> GetAllUsersByJobId(Guid JobId)
        {
            List<AppliedJobsModel> ids = db.appliedJobs.Where(x => x.JobId == JobId).ToList();
            return ids;
        }
        
        public List<JobSeekerModel> GetAllApplicantsForJobId(Guid JobId)
        {
           
            List<Guid> ids = GetAllUserIdByJobId(JobId);
            List<JobSeekerModel> applic = db.jobSeeker.Where(x => ids.Contains(x.UserId)).ToList();            
            return applic;
        }
        public List<Guid> GetAllUserIdByJobIdAndStatus(Guid JobId, int Status)
        {
            List<Guid> ids = db.appliedJobs.Where(x => x.JobId == JobId && x.Status==Status).Select(X=>X.UserId).ToList();
            return ids;
        }
        public List<JobSeekerModel> GetAllApplicantsForJobIdAndStatus(Guid JobId,int Status)
        {

            List<Guid> ids = GetAllUserIdByJobIdAndStatus(JobId,Status);
            List<JobSeekerModel> applic = db.jobSeeker.Where(x => ids.Contains(x.UserId)).ToList();
            return applic;
        }
        public AppliedJobsModel GetApplicantByJobIdandUserId(Guid JobId, Guid UserId){
            AppliedJobsModel seeker = db.appliedJobs.Where(x => x.UserId == UserId && x.JobId==JobId).FirstOrDefault();
            return seeker;
        }
        public void SelectCandidate(Guid UserId, Guid JobId)
        {          
                AppliedJobsModel candidate = GetApplicantByJobIdandUserId(JobId, UserId);
                candidate.Status = 2;
                db.appliedJobs.AddOrUpdate(candidate);
                db.SaveChanges();          
        }
        public void RejectCandidate(Guid UserId, Guid JobId)
        {
            AppliedJobsModel candidate = GetApplicantByJobIdandUserId(JobId, UserId);
            candidate.Status = 0;
            db.appliedJobs.AddOrUpdate(candidate);
            db.SaveChanges();
        }
        public void DeleteJob(Guid jobId)
        {
            Guid jobid = jobId;
            JobDetailsModel job = db.jobDetails.Where(x => x.JobId == jobid).FirstOrDefault();
            job.isActive = 0;
            db.jobDetails.AddOrUpdate(job);
            db.SaveChanges();
        }
        public List<JobSeekerModel> GetAllApplicantsByCompanyName(String cname)
        {
            List<JobSeekerModel> seekers= new List<JobSeekerModel>();
            SqlParameter param = new SqlParameter("@companyname", SqlDbType.NVarChar);
            param.Value = cname;

            seekers = db.Database.SqlQuery<JobSeekerModel>("proc_getAllSeekersForCompany @companyname", param).ToList();
            return seekers;
        }
    }
}