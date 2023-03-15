using JobPortal.Models;
using JobPortal.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace JobPortal.Repository.Implementation
{
    public class JobSeeker:IJobSeeker
    {
        private DataContext db = new DataContext();

        public JobSeekerModel AddJobSeeker(JobSeekerModel jobSeeker)
        {
            db.jobSeeker.Add(jobSeeker);
            db.SaveChanges();
            return jobSeeker;
        }
        public JobSeekerModel GetJobSeekerByUserId(Guid UserId)
        {
            JobSeekerModel seeker=db.jobSeeker.Where(x =>x.UserId == UserId).FirstOrDefault();
            if (seeker == null) return null;
            return seeker;
        }
        public List<JobDetailsModel> GetAllJobDetails()
        {
            return db.jobDetails.ToList();
        }
        public JobDetailsModel GetJobDetailsByJobId(Guid JobId)
        {
            JobDetailsModel jobs= db.jobDetails.Where(x => x.JobId == JobId).FirstOrDefault();
            if (jobs == null) return null;
            return jobs;
        }
        public List<AppliedJobsModel> GetAllJobsByUserId(Guid UserId)
        {
            List<AppliedJobsModel> jobs = db.appliedJobs.Where(x => x.UserId == UserId).ToList();
            if (jobs == null) return null;
            return jobs;
        }
        public JobSeekerModel UpdateJobSeekerDetails(Guid UserId, JobSeekerModel Seeker)
        {
            
            var seek = db.jobSeeker.Find(UserId);
            if (seek == null)
            {
                
                AddJobSeeker(Seeker);
            }
            else
            {
                db.jobSeeker.Attach(seek);
                
                seek.About = Seeker.About;
                seek.email = Seeker.email;
                seek.firstName = Seeker.firstName;
                seek.lastName = Seeker.lastName;
                seek.DOB = Seeker.DOB;
                seek.CurrentLocation = Seeker.CurrentLocation;
                seek.Mobile = Seeker.Mobile;
                seek.Experience = Seeker.Experience;
                seek.UpdatedAt = DateTime.Now;
                var entry = db.Entry(seek);
                entry.Property(e => e.Experience).IsModified = true;
               
                db.SaveChanges();
            }
            return Seeker;
           
        }

        public AppliedJobsModel ApplyForJob(Guid custJobId, Guid custUserId)
        {

            JobDetailsModel jobDetails = GetJobDetailsByJobId(custJobId);
            AppliedJobsModel apply = new AppliedJobsModel()
            {
                UserId = custUserId,
                JobId = custJobId,
                CompanyName = jobDetails.CompanyName,
                CreatedAt = DateTime.Now,
                Status = 1,
            };
            db.appliedJobs.Add(apply);
            db.SaveChanges();
            return apply;
        }
        public AppliedJobsModel GetAllJobsByUserIdandJobId(Guid UserId, Guid JobId)
        {
            AppliedJobsModel jobs = db.appliedJobs.Where(x => x.UserId == UserId && x.JobId == JobId).FirstOrDefault();
            if (jobs == null) return null;
            return jobs;
        }
        public void WithdrawApplication(Guid UserId, Guid JobId)
        {
            AppliedJobsModel job= GetAllJobsByUserIdandJobId(UserId, JobId);

            db.appliedJobs.Remove(job);
            db.SaveChanges();
        }
        public int countOfTotalApplicantsByUserId(Guid UserId)
        {
            return db.appliedJobs.Where(x=> x.UserId== UserId).Count();
        }
        public int countOfTotalApplicantsSelectedByUserId(Guid UserId)
        {
            return db.appliedJobs.Where(x => x.UserId == UserId && x.Status == 2).Count();
        }

    }
}