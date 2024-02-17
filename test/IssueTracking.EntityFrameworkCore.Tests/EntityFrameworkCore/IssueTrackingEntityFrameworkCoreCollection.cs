using Xunit;

namespace IssueTracking.EntityFrameworkCore;

[CollectionDefinition(IssueTrackingTestConsts.CollectionDefinitionName)]
public class IssueTrackingEntityFrameworkCoreCollection : ICollectionFixture<IssueTrackingEntityFrameworkCoreFixture>
{

}
