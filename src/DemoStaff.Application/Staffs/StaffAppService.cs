using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using DemoStaff.Departments;
using DemoStaff.Interface;
using DemoStaff.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace DemoStaff.Staffs
{
   [Authorize(DemoStaffPermissions.Staffs.Default)]
   public class StaffAppService : CrudAppService<Staff, StaffDto, Guid, PagedAndSortedResultRequestDto, UpsertStaffDto>, IStaffAppService
   {
      //private readonly IRepository<Staff, Guid> _staffRepository;
      private readonly IDepartmentRepository _departmentRepository;

      public StaffAppService(IRepository<Staff, Guid> repository, IDepartmentRepository departmentRepository) : base(repository)
      {
         _departmentRepository = departmentRepository;

         GetPolicyName = DemoStaffPermissions.Staffs.Default;
         GetListPolicyName = DemoStaffPermissions.Staffs.Default;
         CreatePolicyName = DemoStaffPermissions.Staffs.Create;
         UpdatePolicyName = DemoStaffPermissions.Staffs.Update;
         DeletePolicyName = DemoStaffPermissions.Staffs.Delete;
      }

      public async Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync()
      {
         var departments = await _departmentRepository.GetListAsync();
         
         return new ListResultDto<DepartmentLookupDto>(
            ObjectMapper.Map<List<Department>, List<DepartmentLookupDto>>(departments)
         ); 
      }

      public override async Task<StaffDto> GetAsync(Guid id)
      {
         var queryable = await Repository.GetQueryableAsync();

         var query = from staff in queryable
                     join department in await _departmentRepository.GetQueryableAsync() on staff.DepartmentId equals department.Id
                     where staff.Id == id
                     select new { staff, department };

         var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
         if (queryResult == null)
         {
            throw new EntityNotFoundException(typeof(Staff), id);
         }

         var staffDto = ObjectMapper.Map<Staff, StaffDto>(queryResult.staff);
         staffDto.DepartmentName= queryResult.department.Name;
         return staffDto;
      }

      public override async Task<PagedResultDto<StaffDto>> GetListAsync(PagedAndSortedResultRequestDto input)
      {
         var queryable = await Repository.GetQueryableAsync();

         var query = from staff in queryable
                     join department in await _departmentRepository.GetQueryableAsync() on staff.DepartmentId equals department.Id
                     select new { staff, department };

         // Phan trang
         query = query
             .OrderBy(NormalizeSorting(input.Sorting))
             .Skip(input.SkipCount)
             .Take(input.MaxResultCount);

         var queryResult = await AsyncExecuter.ToListAsync(query);

         //Chuyen ket qua sang StaffDto objects
         var staffDtos = queryResult.Select(x =>
         {
            var staffDto = ObjectMapper.Map<Staff, StaffDto>(x.staff);
            staffDto.DepartmentName = x.department.Name;
            return staffDto;
         }).ToList();

         //Get the total count with another query
         var totalCount = await Repository.GetCountAsync();

         return new PagedResultDto<StaffDto>(
             totalCount,
             staffDtos
         );
      }

      private static string NormalizeSorting(string sorting)
      {
         if (sorting.IsNullOrEmpty())
         {
            return $"staff.{nameof(Staff.Name)}";
         }

         if (sorting.Contains("departmentName", StringComparison.OrdinalIgnoreCase))
         {
            return sorting.Replace(
                "departmentName",
                "department.Name",
                StringComparison.OrdinalIgnoreCase
            );
         }

         return $"staff.{sorting}";
      }
   }
}
