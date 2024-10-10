using Microsoft.Extensions.Localization;
using DemoStaff.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DemoStaff;

[Dependency(ReplaceServices = true)]
public class DemoStaffBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<DemoStaffResource> _localizer;

    public DemoStaffBrandingProvider(IStringLocalizer<DemoStaffResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
