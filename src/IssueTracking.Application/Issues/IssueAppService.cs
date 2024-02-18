using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;
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
            var issue = await _issueRepository.GetAsync(input.IssueId, includeDetails: true);
            issue.AddComment(CurrentUser.GetId(), input.Text);
            await _issueRepository.UpdateAsync(issue, autoSave: true);
        }

        public async Task<List<IssueDto>> GetInActiveIssuesFromMileStoneListAsync(GetIssueListDto input)
        {

            var queryable = await _issueRepository.GetQueryableAsync();
            // var issues = await AsyncExecuter.ToListAsync(queryable.Where(new MileStoneSpecification(input.MileStoneId)
            //         .And(new InActiveIssueSpecification()).ToExpression()));

            var issues = await AsyncExecuter.ToListAsync(queryable
                .Where(new InActiveIssueSpecification()
                .And(new MileStoneSpecification(input.MileStoneId)).ToExpression()));

            return ObjectMapper.Map<List<Issue>, List<IssueDto>>(issues);
        }

        public async Task<List<IssueDto>> GetInActiveIssuesListAsync(GetIssueListDto input)
        {
            var queryable = await _issueRepository.GetQueryableAsync();
            var issues = await AsyncExecuter.ToListAsync(queryable.Where(new InActiveIssueSpecification()));
            return ObjectMapper.Map<List<Issue>, List<IssueDto>>(issues);
        }
    }


}