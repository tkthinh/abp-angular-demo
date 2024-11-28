using System;
using DemoStaff.Departments;
using Volo.Abp.Domain.Entities.Auditing;

namespace DemoStaff.Titles
{
   public class Title : FullAuditedEntity<Guid>
   {
      public Guid DepartmentId { get; set; }
      public string Name { get; set; }

      public Title()
      {
      }

      public Title(Guid id, string name) : base(id)
      {
         Name = name;
      }

      internal Title ChangeName(string name)
      {
         Name = name;
         return this;
      }
   }
}
