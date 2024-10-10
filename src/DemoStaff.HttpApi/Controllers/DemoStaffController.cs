using DemoStaff.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoStaff.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DemoStaffController : AbpControllerBase
{
    protected DemoStaffController()
    {
        LocalizationResource = typeof(DemoStaffResource);
    }
}
