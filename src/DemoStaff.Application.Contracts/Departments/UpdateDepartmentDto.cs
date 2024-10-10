using System.ComponentModel.DataAnnotations;

namespace DemoStaff.Departments
{
   public class UpdateDepartmentDto
   {
      [Required]
      [StringLength(DepartmentConsts.MaxNameLength)]
      public string Name { get; set; } = string.Empty;
   }
}