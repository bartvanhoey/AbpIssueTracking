using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace IssueTracking.Issues
{
    public class MileStoneSpecification : Specification<Issue>
    {

        public MileStoneSpecification(Guid mileStoneId) => MileStoneId = mileStoneId;

        public Guid MileStoneId { get; }

        public override Expression<Func<Issue, bool>> ToExpression() => i => i.MileStoneId == MileStoneId;
    }
}