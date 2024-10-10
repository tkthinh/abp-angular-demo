using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using DemoStaff.Staffs;
using Volo.Abp.EntityFrameworkCore.Modeling;
using System;
using DemoStaff.Departments;

namespace DemoStaff.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class DemoStaffDbContext :
    AbpDbContext<DemoStaffDbContext>,
    IIdentityDbContext,
   ITenantManagementDbContext
{
   /* Add DbSet properties for your Aggregate Roots / Entities here. */
   public DbSet<Staff> Staffs { get; set; }
   public DbSet<Department> Departments { get; set; }


   #region Entities from the modules

   // Identity
   public DbSet<IdentityUser> Users { get; set; }
   public DbSet<IdentityRole> Roles { get; set; }
   public DbSet<IdentityClaimType> ClaimTypes { get; set; }
   public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
   public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
   public DbSet<IdentityLinkUser> LinkUsers { get; set; }
   public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
   public DbSet<IdentitySession> Sessions { get; set; }

   // Tenant Management
   public DbSet<Tenant> Tenants { get; set; }
   public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

   #endregion

   public DemoStaffDbContext(DbContextOptions<DemoStaffDbContext> options)
       : base(options)
   {

   }

   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);

      /* Include modules to your migration db context */

      builder.ConfigurePermissionManagement();
      builder.ConfigureSettingManagement();
      builder.ConfigureBackgroundJobs();
      builder.ConfigureAuditLogging();
      builder.ConfigureFeatureManagement();
      builder.ConfigureIdentity();
      builder.ConfigureOpenIddict();
      builder.ConfigureTenantManagement();
      builder.ConfigureBlobStoring();

      /* Configure your own tables/entities inside here */

      //builder.Entity<YourEntity>(b =>
      //{
      //    b.ToTable(DemoStaffConsts.DbTablePrefix + "YourEntities", DemoStaffConsts.DbSchema);
      //    b.ConfigureByConvention(); //auto configure for the base class props
      //    //...
      //});

      builder.Entity<Staff>(s =>
      {
         s.ToTable(DemoStaffConsts.DbTablePrefix + "Staffs", DemoStaffConsts.DbSchema);
         s.ConfigureByConvention(); //auto configure for the base class props
         s.Property(x => x.Name).IsRequired().HasMaxLength(128);

         s.HasOne<Department>().WithMany().HasForeignKey(x => x.DepartmentId);
      });

      builder.Entity<Department>(d =>
      {
         d.ToTable(DemoStaffConsts.DbTablePrefix + "Departments", DemoStaffConsts.DbSchema);
         d.ConfigureByConvention(); //auto configure for the base class props
         d.Property(x => x.Name).IsRequired().HasMaxLength(128);
         d.HasIndex(x => x.Name);
      });
   }
}
