using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace IssueTracking.Issues
{
    public interface IIssueAppService : IApplicationService
    {

        Task<IssueDto> CreateAsync(CreateIssueDto input);
        Task AddCommentAsync(AddCommentDto input);
        Task AssignToAsync(AssignIssueDto input);
        Task<List<IssueDto>> GetInActiveIssuesListAsync(GetIssueListDto input);
        Task<List<IssueDto>> GetInActiveIssuesFromMileStoneListAsync(GetIssueListDto input);


    }
}