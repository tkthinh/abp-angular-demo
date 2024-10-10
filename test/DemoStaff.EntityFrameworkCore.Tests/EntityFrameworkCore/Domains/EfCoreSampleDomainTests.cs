using DemoStaff.Samples;
using Xunit;

namespace DemoStaff.EntityFrameworkCore.Domains;

[Collection(DemoStaffTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<DemoStaffEntityFrameworkCoreTestModule>
{

}
