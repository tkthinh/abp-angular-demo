using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoStaff.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace DemoStaff.Departments
{
   [Authorize(DemoStaffPermissions.Departments.Default)]
   public class DepartmentAppService : DemoStaffAppService, IDepartmentAppService
   {
      private readonly IDepartmentRepository _departmentRepository;
      private readonly DepartmentManager _departmentManager;

      public DepartmentAppService(IDepartmentRepository departmentRepository, DepartmentManager departmentManager)
      {
         _departmentRepository = departmentRepository;
         _departmentManager = departmentManager;
      }
      public async Task<DepartmentDto> GetAsync(Guid id)
      {
         var department = await _departmentRepository.GetAsync(id);
         return ObjectMapper.Map<Department, DepartmentDto>(department);
      }
      public async Task<PagedResultDto<DepartmentDto>> GetListAsync(GetDepartmentListDto input)
      {
         if (input.Sorting.IsNullOrWhiteSpace())
         {
            input.Sorting = nameof(Department.Name);
         }

         var departments = await _departmentRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
         );

         var totalCount = input.Filter == null
            ? await _departmentRepository.CountAsync()
            : await _departmentRepository.CountAsync(department => department.Name.Contains(input.Filter));

         return new PagedResultDto<DepartmentDto>(
            totalCount,
            ObjectMapper.Map<List<Department>, List<DepartmentDto>>(departments)
         );
      }

      [Authorize(DemoStaffPermissions.Departments.Create)]
      public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto input)
      {
         var newDepartment = await _departmentManager.CreateAsync(input.Name);
         await _departmentRepository.InsertAsync(newDepartment);

         return ObjectMapper.Map<Department, DepartmentDto>(newDepartment);
      }

      [Authorize(DemoStaffPermissions.Departments.Update)]
      public async Task UpdateAsync(Guid id, UpdateDepartmentDto input)
      {
         var existingDepartment = await _departmentRepository.GetAsync(id);

         if(input.Name != existingDepartment.Name)
         {
            await _departmentManager.ChangeNameAsync(existingDepartment, input.Name);
         }

         await _departmentRepository.UpdateAsync(existingDepartment);
      }

      [Authorize(DemoStaffPermissions.Departments.Delete)]
      public async Task DeleteAsync(Guid id)
      {
         await _departmentRepository.DeleteAsync(id);
      }

   }
}
