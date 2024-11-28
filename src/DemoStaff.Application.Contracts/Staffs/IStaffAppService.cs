using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace DemoStaff.Staffs
{
  public interface IStaffAppService : ICrudAppService<StaffDto, Guid, PagedAndSortedResultRequestDto, UpsertStaffDto>
  {
    Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync();
    Task CreateStaff(UpsertStaffDto input);
    Task EnableStaff(Guid id);
  }
}
