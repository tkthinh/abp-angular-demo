using Xunit;

namespace DemoStaff.EntityFrameworkCore;

[CollectionDefinition(DemoStaffTestConsts.CollectionDefinitionName)]
public class DemoStaffEntityFrameworkCoreCollection : ICollectionFixture<DemoStaffEntityFrameworkCoreFixture>
{

}
