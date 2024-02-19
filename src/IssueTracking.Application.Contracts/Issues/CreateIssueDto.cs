using System;
using System.ComponentModel.DataAnnotations;

namespace IssueTracking.Issues
{
    public class CreateIssueDto
    {
        public Guid RepositoryId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Text { get; set; }

        public Guid? AssignedUserId { get; set; }
    }
}