using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DemoStaff.Data;

/* This is used if database provider does't define
 * IDemoStaffDbSchemaMigrator implementation.
 */
public class NullDemoStaffDbSchemaMigrator : IDemoStaffDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
