using Volo.Abp.Modularity;

namespace IssueTracking;

public abstract class IssueTrackingApplicationTestBase<TStartupModule> : IssueTrackingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
