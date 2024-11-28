using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace DemoStaff.Titles
{
   public interface ITitleRepository : IRepository<Title, Guid>
   {
      Task<Title> FindByNameAsync(string name);
      Task<List<Title>> GetAll();
      Task<List<Title>> GetAllOfDepartment(Guid departmentId);
   }
}
