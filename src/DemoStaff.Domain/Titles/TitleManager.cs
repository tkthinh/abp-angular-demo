using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace DemoStaff.Titles
{
   public class TitleManager : DomainService
   {
      private readonly ITitleRepository _titleRepository;

      public TitleManager(ITitleRepository titleRepository)
      {
         _titleRepository = titleRepository;
      }

      public async Task<Title> CreateAsync(string name)
      {
         var existingTitle = await _titleRepository.FindByNameAsync(name);
         if (existingTitle != null)
         {
            throw new TitleAlreadyExistsException(name);
         }

         return new Title(
            Guid.NewGuid(),
            name
         );
      }

      public async Task ChangeNameAsync(Title title, string name)
      {
         var existingTitle = await _titleRepository.FindByNameAsync(name);
         if (existingTitle != null && existingTitle.Id != title.Id)
         {
            throw new TitleAlreadyExistsException(name);
         }
         title.ChangeName(name);
      }
   }
}
