using IssueTracking.Samples;
using Xunit;

namespace IssueTracking.EntityFrameworkCore.Applications;

[Collection(IssueTrackingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<IssueTrackingEntityFrameworkCoreTestModule>
{

}
