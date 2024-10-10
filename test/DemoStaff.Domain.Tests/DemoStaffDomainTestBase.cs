using Volo.Abp.Modularity;

namespace DemoStaff;

/* Inherit from this class for your domain layer tests. */
public abstract class DemoStaffDomainTestBase<TStartupModule> : DemoStaffTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
