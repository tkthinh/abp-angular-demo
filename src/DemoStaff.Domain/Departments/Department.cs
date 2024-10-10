using System;
using DemoStaff.Departments;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace DemoStaff.Departments
{
   public class Department : FullAuditedEntity<Guid>
   {
      public string Name { get; set; }

      public Department(){
         //Id = Guid.NewGuid();
      }

      internal Department(Guid id, string name) : base(id)
      {
         Name = name;
      }

      internal Department ChangeName (string name)
      {
         Name = name;
         return this;
      }

      private void SetName(string name)
      {
         Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: DepartmentConsts.MaxNameLength);
      }
   }
}
