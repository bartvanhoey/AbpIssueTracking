using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace IssueTracking.Issues
{
    public interface IIssueAppService : IApplicationService
    {
        Task CreateAsync(CreateCommentDto input);
        Task<List<IssueDto>> GetInActiveIssuesListAsync(GetIssueListDto input);
        Task<List<IssueDto>> GetInActiveIssuesFromMileStoneListAsync(GetIssueListDto input);
    }

    public class GetIssueListDto
    {
        public Guid MileStoneId { get; set; }
    }

    public class IssueDto
    {
    }

    public class CreateCommentDto
    {
        public Guid IssueId { get; set; }
        public string? Text { get; set; }
    }

    public class CommentDto
    {
    }
}