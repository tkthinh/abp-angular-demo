using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStaff.Staffs
{
   public class UpsertStaffDto
   {
      [Required]
      [StringLength(100)]
      public string Name { get; set; }
      [Required]
      public Gender Gender { get; set; }
      [Required] 
      [StringLength(100)]
      public string Email { get; set; }
      [Required]
      [StringLength(10)]
      public string Phone { get; set; }
      [Required]
      [StringLength(100)]
      public string Title { get; set; }
      public Guid DepartmentId { get; set; }
   }
}
