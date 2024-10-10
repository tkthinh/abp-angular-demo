using DemoStaff.Localization;
using Volo.Abp.Application.Services;

namespace DemoStaff;

/* Inherit your application services from this class.
 */
public abstract class DemoStaffAppService : ApplicationService
{
    protected DemoStaffAppService()
    {
        LocalizationResource = typeof(DemoStaffResource);
    }
}
