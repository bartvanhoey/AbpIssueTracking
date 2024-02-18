using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace IssueTracking.Issues
{
    public class IssueAppService : ApplicationService, IIssueAppService
    {
        private readonly IRepository<Issue, Guid> _issueRepository;

        public IssueAppService(IRepository<Issue, Guid> issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task CreateAsync(CreateCommentDto input)
        {
            var issue  = await _issueRepository.GetAsync(input.IssueId, includeDetails: true);
            issue.AddComment(CurrentUser.GetId(), input.Text);
            await _issueRepository.UpdateAsync(issue, autoSave:true);
        }
    }


}