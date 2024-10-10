using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace DemoStaff.Departments
{
   public class DepartmentManager : DomainService
   {
      private readonly IDepartmentRepository _departmentRepository;

      public DepartmentManager(IDepartmentRepository departmentRepository)
      {
         _departmentRepository = departmentRepository;
      }

      public async Task<Department> CreateAsync(string name)
      {
         var existingDepartment = await _departmentRepository.FindByNameAsync(name);
         if (existingDepartment != null)
         {
            throw new DepartmentAlreadyExistsException(name);
         }

         return new Department(
            Guid.NewGuid(),
            name
         );
      }

      public async Task ChangeNameAsync(Department department, string name)
      {
         var existingDepartment = await _departmentRepository.FindByNameAsync(name);
         if (existingDepartment != null && existingDepartment.Id != department.Id)
         {
            throw new DepartmentAlreadyExistsException(name);
         }
         department.ChangeName(name);
      }
   }
}
