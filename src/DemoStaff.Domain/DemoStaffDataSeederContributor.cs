using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoStaff.Departments;
using DemoStaff.Staffs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace DemoStaff
{
   public class DemoStaffDataSeederContributor : IDataSeedContributor, ITransientDependency
   {
      private readonly IRepository<Staff, Guid> _staffRepository;
      private readonly IRepository<Department, Guid> _departmentRepository;
      private readonly TitleManager _departmentManager;

      public DemoStaffDataSeederContributor(
          IRepository<Staff, Guid> staffRepository,
          IRepository<Department, Guid> departmentRepository,
          TitleManager departmentManager)
      {
         _staffRepository = staffRepository;
         _departmentRepository = departmentRepository;
         _departmentManager = departmentManager;
      }

      public async Task SeedAsync(DataSeedContext context)
      {
         // Check if there are any departments in the repository
         if (await _departmentRepository.GetCountAsync() > 0)
         {
            return;
         }

         // Insert departments
         var hrDepartment = await _departmentRepository.InsertAsync(
             new Department(Guid.NewGuid(), "Human Resources")
         );

         var itDepartment = await _departmentRepository.InsertAsync(
             new Department(Guid.NewGuid(), "IT Department")
         );

         var financeDepartment = await _departmentRepository.InsertAsync(
             new Department(Guid.NewGuid(), "Finance")
         );

         var marketingDepartment = await _departmentRepository.InsertAsync(
             new Department(Guid.NewGuid(), "Marketing")
         );

         // Insert staff members and assign them to departments
         await _staffRepository.InsertAsync(
             new Staff
             {
                Name = "Alice Johnson",
                Gender = Gender.Female,
                Email = "alice.johnson@example.com",
                Phone = "1234567890",
                DepartmentId = hrDepartment.Id,
                Title = "HR Manager"
             },
             autoSave: true
         );

         await _staffRepository.InsertAsync(
             new Staff
             {
                Name = "Bob Smith",
                Gender = Gender.Male,
                Email = "bob.smith@example.com",
                Phone = "0987654321",
                DepartmentId = itDepartment.Id,
                Title = "Senior Software Engineer"
             },
             autoSave: true
         );

         await _staffRepository.InsertAsync(
             new Staff
             {
                Name = "Carol Davis",
                Gender = Gender.Female,
                Email = "carol.davis@example.com",
                Phone = "2345678901",
                DepartmentId = financeDepartment.Id,
                Title = "Finance Analyst"
             },
             autoSave: true
         );

         await _staffRepository.InsertAsync(
             new Staff
             {
                Name = "David Miller",
                Gender = Gender.Male,
                Email = "david.miller@example.com",
                Phone = "8765432109",
                DepartmentId = marketingDepartment.Id,
                Title = "Marketing Specialist"
             },
             autoSave: true
         );

         await _staffRepository.InsertAsync(
             new Staff
             {
                Name = "Emily Clark",
                Gender = Gender.Female,
                Email = "emily.clark@example.com",
                Phone = "3216549870",
                DepartmentId = itDepartment.Id,
                Title = "DevOps Engineer"
             },
             autoSave: true
         );

         await _staffRepository.InsertAsync(
             new Staff
             {
                Name = "Frank Thompson",
                Gender = Gender.Male,
                Email = "frank.thompson@example.com",
                Phone = "5678901234",
                DepartmentId = hrDepartment.Id,
                Title = "HR Assistant"
             },
             autoSave: true
         );

         await _staffRepository.InsertAsync(
             new Staff
             {
                Name = "Grace Wilson",
                Gender = Gender.Female,
                Email = "grace.wilson@example.com",
                Phone = "6543219876",
                DepartmentId = marketingDepartment.Id,
                Title = "Content Manager"
             },
             autoSave: true
         );

         await _staffRepository.InsertAsync(
             new Staff
             {
                Name = "Henry Moore",
                Gender = Gender.Male,
                Email = "henry.moore@example.com",
                Phone = "4567890123",
                DepartmentId = financeDepartment.Id,
                Title = "Finance Manager"
             },
             autoSave: true
         );
      }

   }
}
