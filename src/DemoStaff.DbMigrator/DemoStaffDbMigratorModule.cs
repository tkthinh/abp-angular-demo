using DemoStaff.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DemoStaff.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DemoStaffEntityFrameworkCoreModule),
    typeof(DemoStaffApplicationContractsModule)
)]
public class DemoStaffDbMigratorModule : AbpModule
{
}
