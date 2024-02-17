using Volo.Abp.Modularity;

namespace IssueTracking;

[DependsOn(
    typeof(IssueTrackingDomainModule),
    typeof(IssueTrackingTestBaseModule)
)]
public class IssueTrackingDomainTestModule : AbpModule
{

}
