﻿using System;
using System.Threading.Tasks;
using DemoStaff.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace DemoStaff;

public class Program
{
   public async static Task<int> Main(string[] args)
   {
      try
      {
         Log.Information("Starting DemoStaff.HttpApi.Host.");
         var builder = WebApplication.CreateBuilder(args);
         builder.Host
             .AddAppSettingsSecretsJson()
             .UseAutofac()
             .UseSerilog((context, services, loggerConfiguration) =>
             {
                loggerConfiguration
#if DEBUG
                       .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
                       .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                       .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                       .Enrich.FromLogContext()
                       .WriteTo.Async(c => c.File("Logs/logs.txt"))
                       .WriteTo.Async(c => c.Console())
                       .WriteTo.Async(c => c.AbpStudio(services));
             });

         builder.Services.AddDbContext<DemoStaffDbContext>(options =>
         {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
         });

         await builder.AddApplicationAsync<DemoStaffHttpApiHostModule>();
         var app = builder.Build();
         await app.InitializeApplicationAsync();
         await app.RunAsync();
         return 0;
      }
      catch (Exception ex)
      {
         if (ex is HostAbortedException)
         {
            throw;
         }

         Log.Fatal(ex, "Host terminated unexpectedly!");
         return 1;
      }
      finally
      {
         Log.CloseAndFlush();
      }
   }
}
