using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace IssueTracking.Issues
{
    public class Comment:  Entity<Guid>,   IHasCreationTime
    {
        public string? Text { get; set; }
        public DateTime CreationTime { get; set; }

        public Guid IssueId { get; set; }
        public Guid UserId { get; set; }

    }
}