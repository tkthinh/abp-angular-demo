using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DemoStaff.Data;
using Volo.Abp.DependencyInjection;

namespace DemoStaff.EntityFrameworkCore;

public class EntityFrameworkCoreDemoStaffDbSchemaMigrator
    : IDemoStaffDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreDemoStaffDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the DemoStaffDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<DemoStaffDbContext>()
            .Database
            .MigrateAsync();
    }
}
