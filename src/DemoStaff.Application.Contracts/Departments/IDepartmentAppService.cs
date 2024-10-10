using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DemoStaff.Departments
{
   public interface IDepartmentAppService : IApplicationService
   {
      Task<DepartmentDto> GetAsync(Guid id);
      Task<PagedResultDto<DepartmentDto>> GetListAsync(GetDepartmentListDto input);
      Task<DepartmentDto> CreateAsync(CreateDepartmentDto input);
      Task UpdateAsync(Guid id, UpdateDepartmentDto input);
      Task DeleteAsync(Guid id);
   }
}
