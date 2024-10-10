using Volo.Abp.Settings;

namespace DemoStaff.Settings;

public class DemoStaffSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DemoStaffSettings.MySetting1));
    }
}
