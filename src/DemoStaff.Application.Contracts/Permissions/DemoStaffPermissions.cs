namespace DemoStaff.Permissions;

public static class DemoStaffPermissions
{
    public const string GroupName = "DemoStaff";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

   public static class Staffs
   {
      public const string Default = GroupName + ".Staffs";
      public const string Create = Default + ".Create";
      public const string Update = Default + ".Update";
      public const string Delete = Default + ".Delete";
   }

   public static class Departments 
   {
      public const string Default = GroupName + ".Departments";
      public const string Create = Default + ".Create";
      public const string Update = Default + ".Update";
      public const string Delete = Default + ".Delete";
   }
}
