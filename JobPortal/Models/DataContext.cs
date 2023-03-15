using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppliedJobsModel>()
                .ToTable("JobsApplied")
                .HasKey(p => new { p.UserId, p.JobId }); ;
            modelBuilder.Entity<JobDetailsModel>()
                .ToTable("JobDetails")
                .HasKey(e => e.JobId);

            modelBuilder.Entity<JobRecruiterModel>()
               .ToTable("JobRecruiter")
               .HasKey(e => e.UserId);
            modelBuilder.Entity<JobSeekerModel>()
              .ToTable("JobSeeker")
              .HasKey(e => e.UserId);


        }

        public DbSet<AppliedJobsModel> appliedJobs { get; set; }
        public DbSet<JobDetailsModel> jobDetails { get; set; }
        public DbSet<JobRecruiterModel> jobRecruiter { get; set; }
        public DbSet<JobSeekerModel> jobSeeker { get; set; }




    }
}