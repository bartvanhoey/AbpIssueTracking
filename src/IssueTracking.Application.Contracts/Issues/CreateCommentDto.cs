using System;

namespace IssueTracking.Issues
{
    public class AddCommentDto
    {
        public Guid IssueId { get; set; }
        public string? Text { get; set; }
    }
}