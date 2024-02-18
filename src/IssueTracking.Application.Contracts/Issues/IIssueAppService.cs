using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace IssueTracking.Issues
{
    public interface IIssueAppService : IApplicationService
    {
        Task AddCommentAsync(AddCommentDto input);
        Task AssignToAsync(AssignIssueDto input);
        Task<List<IssueDto>> GetInActiveIssuesListAsync(GetIssueListDto input);
        Task<List<IssueDto>> GetInActiveIssuesFromMileStoneListAsync(GetIssueListDto input);


    }

    public class AssignIssueDto
    {
        public Guid IssueId { get; set; }
        public Guid UserId { get; set; }
    }
}