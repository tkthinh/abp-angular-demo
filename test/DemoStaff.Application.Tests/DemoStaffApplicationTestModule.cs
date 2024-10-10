using Volo.Abp.Modularity;

namespace DemoStaff;

[DependsOn(
    typeof(DemoStaffApplicationModule),
    typeof(DemoStaffDomainTestModule)
)]
public class DemoStaffApplicationTestModule : AbpModule
{

}
