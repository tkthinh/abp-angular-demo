using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DemoStaff.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class DemoStaffDbContextFactory : IDesignTimeDbContextFactory<DemoStaffDbContext>
{
    public DemoStaffDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        DemoStaffEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<DemoStaffDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new DemoStaffDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DemoStaff.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
