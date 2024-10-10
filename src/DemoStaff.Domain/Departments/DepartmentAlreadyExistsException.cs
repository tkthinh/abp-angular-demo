using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace DemoStaff.Departments
{
   public class DepartmentAlreadyExistsException : BusinessException
   {
      public DepartmentAlreadyExistsException(string name)
         : base(DemoStaffDomainErrorCodes.DepartmentAlreadyExists)
      {
         WithData("name", name);
      }
   }
}
