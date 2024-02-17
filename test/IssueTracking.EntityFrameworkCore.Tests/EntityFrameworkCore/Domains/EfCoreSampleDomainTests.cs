using IssueTracking.Samples;
using Xunit;

namespace IssueTracking.EntityFrameworkCore.Domains;

[Collection(IssueTrackingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<IssueTrackingEntityFrameworkCoreTestModule>
{

}
