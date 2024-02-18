using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace IssueTracking.Issues
{
    public class InActiveIssueSpecification : Specification<Issue>
    {
        public override Expression<Func<Issue, bool>> ToExpression() 
            => x => !x.IsClosed && x.AssignedUserId == null && x.CreationTime < DateTime.Now.AddDays(-30) && (x.LastCommentTime == null || x.LastCommentTime < DateTime.Now.AddDays(-30));
    }
}