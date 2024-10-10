using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace DemoStaff.Departments
{
   public class GetDepartmentListDto : PagedAndSortedResultRequestDto
   {
      public string? Filter { get; set; }
   }
}