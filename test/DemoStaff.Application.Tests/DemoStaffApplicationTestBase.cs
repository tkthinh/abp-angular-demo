using Volo.Abp.Modularity;

namespace DemoStaff;

public abstract class DemoStaffApplicationTestBase<TStartupModule> : DemoStaffTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
