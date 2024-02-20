using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Specifications;
using Volo.Abp.Users;

namespace IssueTracking.Issues
{
    public class IssueAppService : ApplicationService, IIssueAppService
    {
        private readonly IRepository<Issue, Guid> _issueRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IssueManager _issueManager;

        public IssueAppService(IRepository<Issue, Guid> issueRepository, IRepository<IdentityUser, Guid> userRepository, IssueManager issueManager)
        {
            _issueRepository = issueRepository;
            _userRepository = userRepository;
            _issueManager = issueManager;
        }

        public async Task AssignToAsync(AssignIssueDto input)
        {
            var issue = await _issueRepository.GetAsync(input.IssueId, includeDetails: true);
            var user = await _userRepository.GetAsync(input.UserId, includeDetails: true);
            await _issueManager.AssignToAsync(issue, user);
            await _issueRepository.UpdateAsync(issue, autoSave:true);
        }

        public async Task AddCommentAsync(AddCommentDto input)
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

        public async Task<IssueDto> CreateAsync(CreateIssueDto input)
        {
            //    var issue = new Issue(GuidGenerator.Create(), input.RepositoryId, input.Title, input.Text);

            var issue = await _issueManager.CreateAsync(input.RepositoryId, input.Title, input.Text);
            if (input.AssignedUserId.HasValue)
            {
                var user = await _userRepository.GetAsync(input.AssignedUserId.Value);
                await _issueManager.AssignToAsync(issue, user);
            }

            var insertedIssue = await _issueRepository.InsertAsync(issue, autoSave:true);
            return ObjectMapper.Map<Issue, IssueDto>(issue);
        }

        public async Task<IssueDto> UpdateAsync(Guid id, UpdateIssueDto input)
        {
            var issue = await _issueRepository.GetAsync(id);
            await _issueManager.ChangeTitleAsync(issue, input.Title);

            if (input.AssignedUserId.HasValue)
            {
                var user = await _userRepository.GetAsync(input.AssignedUserId.Value);
                await _issueManager.AssignToAsync(issue, user);
            }

            issue.Text = input.Text;

            await _issueRepository.UpdateAsync(issue, autoSave:true);

            return ObjectMapper.Map<Issue, IssueDto>(issue);
        }
    }


}