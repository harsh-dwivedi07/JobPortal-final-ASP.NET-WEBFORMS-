using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobPortal.Models
{
    public class JobSeekerModel
    {
        [Key]
        public Guid UserId { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String Mobile { get; set; }
        public DateTime? DOB { get; set; }
        public String CurrentLocation { get; set; }
        public String About { get; set; }
        public int Experience { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class JobSeekerModelProxy
    {
      
        public Guid UserId { get; set; }
        public Guid JobId { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String Mobile { get; set; }
        public DateTime? DOB { get; set; }
        public int Status { get; set; }

        public String About { get; set; }
        public int Experience { get; set; }

    }
}