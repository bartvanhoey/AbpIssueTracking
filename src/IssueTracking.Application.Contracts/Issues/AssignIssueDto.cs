using System;

namespace IssueTracking.Issues
{
    public class AssignIssueDto
    {
        public Guid IssueId { get; set; }
        public Guid UserId { get; set; }
    }
}