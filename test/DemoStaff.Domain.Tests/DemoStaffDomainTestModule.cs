using Volo.Abp.Modularity;

namespace DemoStaff;

[DependsOn(
    typeof(DemoStaffDomainModule),
    typeof(DemoStaffTestBaseModule)
)]
public class DemoStaffDomainTestModule : AbpModule
{

}
