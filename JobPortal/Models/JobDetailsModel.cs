using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class JobDetailsModel
    {
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public String CompanyName { get; set; }
        public String CompanyLocation { get; set; }
        public String JobDescription { get; set; }
        public String JobTitle { get; set; }
        public int isActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}