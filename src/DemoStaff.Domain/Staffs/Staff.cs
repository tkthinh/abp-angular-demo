using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace DemoStaff.Staffs;

public class Staff : AuditedAggregateRoot<Guid>
{
   public string Name { get; set; }
   public Gender Gender { get; set; }
   public string Email { get; set; }
   public string Phone { get; set; }
   public Guid DepartmentId { get; set; }
   //public string Department { get; set; }
   public string Title { get; set; }

   public Staff()
   {
      Id = Guid.NewGuid();
   }
}
