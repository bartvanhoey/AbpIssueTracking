using IssueTracking.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace IssueTracking.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IssueTrackingEntityFrameworkCoreModule),
    typeof(IssueTrackingApplicationContractsModule)
    )]
public class IssueTrackingDbMigratorModule : AbpModule
{
}
