using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracking.Issues
{
    public class UpdateIssueDto
    {
        [Required]
        public string? Title { get; set; }
        public string? Text { get; set; }   
        public Guid? AssignedUserId { get; set; }
    }
}