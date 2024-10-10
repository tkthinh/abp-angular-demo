using DemoStaff.Samples;
using Xunit;

namespace DemoStaff.EntityFrameworkCore.Applications;

[Collection(DemoStaffTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<DemoStaffEntityFrameworkCoreTestModule>
{

}
