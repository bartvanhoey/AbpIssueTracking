namespace IssueTracking.Permissions;

public static class IssueTrackingPermissions
{
    public const string GroupName = "IssueTracking";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Organizations
    {
        public const string Default = GroupName + ".Organizations";
        public const string Create = Default + ".Create";
        public const string Update = Default+ ".Update";
        public const string Delete = Default + ".Delete";
    }
}
