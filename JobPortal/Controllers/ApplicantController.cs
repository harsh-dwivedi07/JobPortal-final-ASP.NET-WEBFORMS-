using JobPortal.Models;
using JobPortal.Repository.Implementation;
using JobPortal.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobPortal.Controllers
{
    public class ApplicantController : ApiController
    {
        IJobSeeker _jobSeeker = new JobSeeker();
        [HttpPost]
        public JobSeekerModel AddJobSeeker([FromBody] JobSeekerModel jobSeeker) //
        {

            if (jobSeeker != null)
            {
                try
                {
                    return _jobSeeker.AddJobSeeker(jobSeeker);
                }
                catch (Exception)
                {

                    throw;
                }
               
            }
            else
            {
                //return Request.CreateResponse(HttpStatusCode.Created, "Failed");
                return null;
            }
        }
        [HttpGet]
        public JobSeekerModel GetJobSeekerByUserId(Guid UserId)
        {

            if (UserId != null)
            {
                try
                {
                    return _jobSeeker.GetJobSeekerByUserId(UserId);
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            else
            {
                return null;
            }
        }
        [HttpGet]
        public List<JobDetailsModel> GetAllJobDetails()
        {
            try
            {
                return _jobSeeker.GetAllJobDetails();
            }
            catch (Exception)
            {
                throw;
            }          
        }
        [HttpGet]
        public JobDetailsModel GetJobDetailsByJobId(Guid JobId)
        {
            try
            {
                return _jobSeeker.GetJobDetailsByJobId(JobId);
            }
            catch (Exception)
            {

                throw;
            }         
        }

        [HttpGet]
        public List<AppliedJobsModel> GetAllJobsByUserId(Guid UserId)
        {
            if (UserId != null)
            {
                try
                {
                    return _jobSeeker.GetAllJobsByUserId(UserId);
                }
                catch (Exception)
                {

                    throw;
                }              
            }
            else
            {
                return null;
            }
        }
        [HttpPut]
        public IHttpActionResult UpdateJobSeekerDetails(Guid UserId, JobSeekerModel Seeker)
        {
            if (UserId != null && Seeker!= null)
            {
                try
                {
                    _jobSeeker.UpdateJobSeekerDetails(UserId, Seeker);
                    return Ok();
                }
                catch (Exception)
                {
                    throw;
                }             
            }          
            return BadRequest();            
        }

        [HttpDelete]
        public IHttpActionResult WithdrawApplication(Guid UserId, Guid JobId)
        {
            if (UserId != null && JobId != null)
            {
                try
                {
                    _jobSeeker.WithdrawApplication(UserId, JobId);
                    return Ok();
                }
                catch (Exception)
                {
                    throw;
                }             
            }
            return BadRequest();
        }
    }
}

