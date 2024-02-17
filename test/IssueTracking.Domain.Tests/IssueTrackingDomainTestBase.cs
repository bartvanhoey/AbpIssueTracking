using Volo.Abp.Modularity;

namespace IssueTracking;

/* Inherit from this class for your domain layer tests. */
public abstract class IssueTrackingDomainTestBase<TStartupModule> : IssueTrackingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
