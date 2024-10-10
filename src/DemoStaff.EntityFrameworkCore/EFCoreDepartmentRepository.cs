using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using DemoStaff.Departments;
using DemoStaff.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace DemoStaff
{
   public class EFCoreDepartmentRepository : EfCoreRepository<DemoStaffDbContext, Department, Guid> , IDepartmentRepository
   {
      public EFCoreDepartmentRepository(IDbContextProvider<DemoStaffDbContext> dbContextProvider)
         : base(dbContextProvider)
      {
      }

      public async Task<Department> FindByNameAsync(string name)
      {
         var dbSet = await GetDbSetAsync();
         return await dbSet.FirstOrDefaultAsync(d => d.Name == name);
      }

      public async Task<List<Department>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
      {
         var dbSet = await GetDbSetAsync();
         return await dbSet
            .WhereIf(!filter.IsNullOrWhiteSpace(), d => d.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
      }
   }
}
