using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using JobPortal.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Xml.Linq;
using JobPortal.Repository.Implementation;
using JobPortal.Repository.Interface;
using System.Data.Entity.Migrations;
using System.Web.Script.Services;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JobPortal.WebServices
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        IJobRecruiter _jobrecruiter = new JobRecruiter();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UpdateRecruiterDetails(object recruiter)
        {
            string myJSON = JsonConvert.SerializeObject(recruiter);
            JObject jsonObject = JObject.Parse(myJSON);

            Guid userid = (Guid)jsonObject["UserId"];
           
            JobRecruiterModel rec = new JobRecruiterModel {
                UserId = (Guid)jsonObject["UserId"],
                firstName= (string)jsonObject["firstName"],
                lastName= (string)jsonObject["lastName"],
                Mobile = (string)jsonObject["Mobile"],
                CompanyName= (string)jsonObject["CompanyName"],
                DOB= (DateTime)jsonObject["DOB"],
            };
           
            if (userid != null && rec != null)
            {
                _jobrecruiter.UpdateJobRecruiterDetails(userid, rec);
                return "success";
            }
            return "BadReq";
           
        }
    }
}
