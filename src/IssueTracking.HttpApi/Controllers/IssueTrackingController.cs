using IssueTracking.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace IssueTracking.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IssueTrackingController : AbpControllerBase
{
    protected IssueTrackingController()
    {
        LocalizationResource = typeof(IssueTrackingResource);
    }
}
