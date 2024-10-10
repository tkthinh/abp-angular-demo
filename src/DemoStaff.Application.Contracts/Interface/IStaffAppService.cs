using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoStaff.Staffs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DemoStaff.Interface
{
   public interface IStaffAppService : ICrudAppService<StaffDto, Guid, PagedAndSortedResultRequestDto, UpsertStaffDto>
   {
      Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync();
   }
}
