using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IssueTracking.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace IssueTracking.Issues
{
    public class IssueRepository : EfCoreRepository<IssueTrackingDbContext, Issue, Guid>, IIssueRepository
    {
    public IssueRepository(IDbContextProvider<IssueTrackingDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

        public async Task<List<Issue>> GetInActiveIssuesAsync()
        {
            
            // var daysAgo30 = DateTime.Now.Subtract(TimeSpan.FromDays(30));
            var daysAgo30 = DateTime.Now.AddDays(-30);

            var dbSet = await GetDbSetAsync();

            return await dbSet.Where(x => !x.IsClosed && x.AssignedUserId == null && x.CreationTime < daysAgo30 && (x.LastCommentTime == null || x.LastCommentTime < daysAgo30) ).ToListAsync();

        }
    }
}