using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace DemoStaff.Titles
{
   public class TitleAlreadyExistsException : BusinessException
   {
      public TitleAlreadyExistsException(string name)
         : base(DemoStaffDomainErrorCodes.TitleAlreadyExists)
      {
         WithData("name", name);
      }
   }
}
