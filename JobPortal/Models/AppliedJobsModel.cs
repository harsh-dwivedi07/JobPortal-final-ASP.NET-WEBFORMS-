using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class AppliedJobsModel
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public String CompanyName { get; set; }     
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}