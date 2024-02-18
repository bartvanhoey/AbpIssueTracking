using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueTracking.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Specifications;

namespace IssueTracking.Issues
{
    public class IssueRepository : EfCoreRepository<IssueTrackingDbContext, Issue, Guid>, IIssueRepository
    {
        public IssueRepository(IDbContextProvider<IssueTrackingDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Issue>> GetIssuesAsync(ISpecification<Issue> spec)
            => await (await GetDbSetAsync()).Where(spec.ToExpression()).ToListAsync();
    }
}