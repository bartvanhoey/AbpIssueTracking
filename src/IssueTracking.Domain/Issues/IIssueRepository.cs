using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Specifications;

namespace IssueTracking.Issues
{
    public interface IIssueRepository :  IRepository<Issue, Guid>
    {
        Task<List<Issue>> GetIssuesAsync(ISpecification<Issue> spec);
    }
}