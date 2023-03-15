using JobPortal.Models;
using JobPortal.Repository.Implementation;
using JobPortal.Repository.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Helpers;
using System.Web.Http;


namespace JobPortal.Controllers
{
    public class RecruiterController : ApiController
    {
        IJobRecruiter _jobrecruiter = new JobRecruiter();
        [HttpPost]
        public JobRecruiterModel AddJobRecruiter([FromBody] JobRecruiterModel jobrecruiter) //
        {

            if (jobrecruiter != null)
            {
                return _jobrecruiter.AddJobRecruiter(jobrecruiter);
            }
            else
            {
                //return Request.CreateResponse(HttpStatusCode.Created, "Failed");
                return jobrecruiter;
            }
        }
        [HttpGet]
        public JobRecruiterModel GetJobRecruiterByUserId(Guid UserId)
        {
            if (UserId != null)
            {
                try
                {
                    return _jobrecruiter.GetJobRecruiterByUserId(UserId);
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
        [HttpPost]
        public JobDetailsModel AddNewJob([FromBody] JobDetailsModel jobDetail) //
        {
            if (jobDetail != null)
            {
                try
                {
                    Guid JobId = Guid.NewGuid();
                    jobDetail.JobId = JobId;
                    jobDetail.CreatedAt = DateTime.Now;
                    jobDetail.UpdatedAt = DateTime.Now;
                    jobDetail.isActive = 1;
                    return _jobrecruiter.AddNewJob(jobDetail);
                }
                catch (Exception)
                {

                    throw;
                }
              
            }
            else
            {
                return jobDetail;
            }
        }
        [HttpPost]
        public IHttpActionResult DeleteJob(object jobid) //
        {
            string myJSON = JsonConvert.SerializeObject(jobid);
            JObject jsonObject = JObject.Parse(myJSON);

            Guid jobId = (Guid)jsonObject["jobId"];

            if (jobId != null)
            {
                try
                {
                    _jobrecruiter.DeleteJob(jobId);
                    return Ok("Success");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public JobDetailsModel GetJobDetailByJobId(Guid JobId)
        {
            if (JobId != null)
            {
                try
                {
                    return _jobrecruiter.GetJobDetailByJobId(JobId);
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
        public List<JobDetailsModel> GetAllJobsByUserId(Guid UserId)
        {
            if (UserId != null)
            {
                try
                {
                    return _jobrecruiter.GetAllJobsByUserId(UserId);
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
        [HttpPost]
        public IHttpActionResult UpdateJobRecruiterDetails(JobRecruiterModel Seeker)
        {
            var UserId = Seeker.UserId;
            if (UserId != null && Seeker != null)
            {
                try
                {
                    _jobrecruiter.UpdateJobRecruiterDetails(UserId, Seeker);
                    return Ok();
                }
                catch (Exception)
                {

                    throw;
                }
               
            }
            return BadRequest();
        }
        [HttpGet]
        public List<JobSeekerModelProxy> GetAllApplicantsForJobId(Guid JobId)
        {
            if (JobId != null)
            {
                try
                {
                    List<JobSeekerModel> seekers = _jobrecruiter.GetAllApplicantsForJobId(JobId);
                    List<JobSeekerModelProxy> seek = new List<JobSeekerModelProxy>();
                    foreach (JobSeekerModel seeker in seekers)
                    {
                        // Create a new ModelProxy object with the JobSeekerModel data and additional status data
                        JobSeekerModelProxy proxy = new JobSeekerModelProxy
                        {
                            // Add your desired status data here
                            firstName = seeker.firstName,
                            lastName = seeker.lastName,
                            email = seeker.email,
                            Mobile = seeker.Mobile,
                            DOB = seeker.DOB,
                            About = seeker.About,
                            Experience = seeker.Experience,
                            UserId = seeker.UserId,
                            Status = _jobrecruiter.GetApplicantByJobIdandUserId(JobId, seeker.UserId).Status,
                        };

                        seek.Add(proxy);
                    }
                    return seek;
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
        public List<JobSeekerModelProxy> GetAllApplicantsForJobIdAndStatus(Guid JobId, int Status)
        {
            if (JobId != null)
            {
                try
                {
                    List<JobSeekerModel> seekers = _jobrecruiter.GetAllApplicantsForJobIdAndStatus(JobId, Status);
                    List<JobSeekerModelProxy> seek = new List<JobSeekerModelProxy>();
                    foreach (JobSeekerModel seeker in seekers)
                    {
                        // Create a new ModelProxy object with the JobSeekerModel data and additional status data
                        JobSeekerModelProxy proxy = new JobSeekerModelProxy
                        {
                            // Add your desired status data here
                            firstName = seeker.firstName,
                            lastName = seeker.lastName,
                            email = seeker.email,
                            Mobile = seeker.Mobile,
                            DOB = seeker.DOB,
                            About = seeker.About,
                            Experience = seeker.Experience,
                            UserId = seeker.UserId,
                            Status = Status,
                        };

                        seek.Add(proxy);
                    }

                    return seek;
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
        public AppliedJobsModel GetApplicantByJobIdandUserId(Guid JobId, Guid UserId)
        {
            if (JobId != null && UserId != null)
            {
                try
                {
                    return _jobrecruiter.GetApplicantByJobIdandUserId(JobId, UserId);
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

        [HttpPost]
        public IHttpActionResult SelectCandidate(object formdata)
        {
            string myJSON = JsonConvert.SerializeObject(formdata);
            JObject jsonObject = JObject.Parse(myJSON);

            Guid? UserId = (Guid)jsonObject["UserId"];
            Guid? JobId = (Guid)jsonObject["JobId"];
            if (UserId.HasValue && JobId.HasValue)
            {
                try
                {
                    _jobrecruiter.SelectCandidate(UserId.Value, JobId.Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Ok("Success");
            }
            return BadRequest("Bad Req");
        }
        [HttpPost]
        public IHttpActionResult RejectCandidate(object formdata)
        {
            string myJSON = JsonConvert.SerializeObject(formdata);
            JObject jsonObject = JObject.Parse(myJSON);

            Guid userid = (Guid)jsonObject["UserId"];
            Guid jobid = (Guid)jsonObject["JobId"];
            // Guid UserId = (Guid)(formdata.UserId);
            if (userid != null && jobid != null)
            {
                try
                {
                    _jobrecruiter.RejectCandidate(userid, jobid);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return Ok("Success");
            }
            return BadRequest("Failed");
            //  return null;
        }
        [HttpGet]
        public List<AppliedJobsModel> GetAllUsersByJobId(Guid JobId)
        {
            if (JobId != null)
            {
                try
                {
                    return _jobrecruiter.GetAllUsersByJobId(JobId);
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
        public List<JobSeekerModel> GetAllApplicantsByCompanyName(String cname)
        {        
                try
                {
                    return _jobrecruiter.GetAllApplicantsByCompanyName(cname);
                }
                catch (Exception)
                {
                    throw;
                }          
        }
    }
}
