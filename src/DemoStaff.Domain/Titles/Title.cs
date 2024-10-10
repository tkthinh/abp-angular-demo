using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace YourProjectNamespace.Titles
{
   public class Title : FullAuditedEntity<Guid>
   {
      public string Name { get; set; }

      public Title()
      {
      }

      public Title(Guid id, string name) : base(id)
      {
         Name = name;
      }
   }
}
