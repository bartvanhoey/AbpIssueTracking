using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace IssueTracking.Issues
{
    public class IssueManager : DomainService
    {
        private readonly IRepository<Issue, Guid> _issueRepository;

        public IssueManager(IRepository<Issue, Guid> issueRepository)
            => _issueRepository = issueRepository;

        public async Task<Issue> CreateAsync(Guid repositoryId, string title, string? text = null)
        {
            if (await _issueRepository.AnyAsync(x => x.Title == title))
            {
                throw new BusinessException("IssueTracking:IssueWithSameTitleExist");
            }
            return new  Issue(GuidGenerator.Create(), repositoryId, title, text);
        }



        public async Task AssignToAsync(Issue issue, IdentityUser user)
        {
            var openIssueCount = await _issueRepository.CountAsync(i => i.AssignedUserId == user.Id && !i.IsClosed);
            if (openIssueCount >= 3)
            {
                throw new BusinessException("IssueTracking:ConcurrentOpenIssueLimit");
            }

            issue.AssignedUserId = user.Id;
        }
    }
}