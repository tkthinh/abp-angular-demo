using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoStaff.Staffs;
using Volo.Abp.Application.Dtos;

namespace DemoStaff.Staffs
{
   public class StaffDto : AuditedEntityDto<Guid>
   {
      public string Name { get; set; }
      public Gender Gender { get; set; }
      public string Email { get; set; }
      public string Phone { get; set; }
      public Guid DepartmentId { get; set; }
      public string DepartmentName { get; set; }
      public string Title { get; set; }
   }
}
