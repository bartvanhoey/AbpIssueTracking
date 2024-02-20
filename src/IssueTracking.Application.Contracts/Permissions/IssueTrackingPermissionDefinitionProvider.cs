using IssueTracking.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace IssueTracking.Permissions;

public class IssueTrackingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(IssueTrackingPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(IssueTrackingPermissions.MyPermission1, L("Permission:MyPermission1"));

        var organizationGroup = context.AddGroup(IssueTrackingPermissions.GroupName, L("Permission:OrganizationGroup"));
        
        //"Permission:OrganizationGroup": "Organization management",
        var organizationPermission = organizationGroup.AddPermission(IssueTrackingPermissions.Organizations.Default, L("Permission:Organizations"));
        organizationPermission.AddChild(IssueTrackingPermissions.Organizations.Create, L("Permission:Organizations:Create"));
        organizationPermission.AddChild(IssueTrackingPermissions.Organizations.Update, L("Permission:Organizations:Update"));
        organizationPermission.AddChild(IssueTrackingPermissions.Organizations.Delete, L("Permission:Organizations:Delete"));
        
        //"Permission:Organizations": "Organizations management",
        //"Permission:Organizations:Create": "Creating Organizations",
        //"Permission:Organizations:Update": "Editing Organizations",
        //"Permission:Organizations:Delete": "Deleting Organizations",

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<IssueTrackingResource>(name);
    }
}
