using DemoStaff.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace DemoStaff.Permissions;

public class DemoStaffPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        //var myGroup = context.AddGroup(DemoStaffPermissions.GroupName);

      var demoStaffGroup = context.AddGroup(DemoStaffPermissions.GroupName, L("Permission:DemoStaff"));

      //Define your own permissions here. Example:
      //myGroup.AddPermission(DemoStaffPermissions.MyPermission1, L("Permission:MyPermission1"));

      var staffsPermission = demoStaffGroup.AddPermission(DemoStaffPermissions.Staffs.Default, L("Permission:Staffs"));
      staffsPermission.AddChild(DemoStaffPermissions.Staffs.Create, L("Permission:Staffs.Create"));
      staffsPermission.AddChild(DemoStaffPermissions.Staffs.Update, L("Permission:Staffs.Update"));
      staffsPermission.AddChild(DemoStaffPermissions.Staffs.Delete, L("Permission:Staffs.Delete"));

      var departmentsPermission = demoStaffGroup.AddPermission(DemoStaffPermissions.Departments.Default, L("Permission:Departments"));
      departmentsPermission.AddChild(DemoStaffPermissions.Departments.Create, L("Permission:Departments.Create"));
      departmentsPermission.AddChild(DemoStaffPermissions.Departments.Update, L("Permission:Departments.Update"));
      departmentsPermission.AddChild(DemoStaffPermissions.Departments.Delete, L("Permission:Departments.Delete"));
   }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DemoStaffResource>(name);
    }
}
