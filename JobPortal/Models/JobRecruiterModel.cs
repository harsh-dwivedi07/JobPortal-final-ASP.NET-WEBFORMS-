using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class JobRecruiterModel
    {
        public Guid UserId { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String Mobile { get; set; }
        public DateTime? DOB { get; set; }
        public String CompanyName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}


    }
}