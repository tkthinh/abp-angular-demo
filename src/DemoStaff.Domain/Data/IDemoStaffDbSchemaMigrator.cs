using System.Threading.Tasks;

namespace DemoStaff.Data;

public interface IDemoStaffDbSchemaMigrator
{
    Task MigrateAsync();
}
