using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DemoStaff.Departments;
using DemoStaff.Staffs;

namespace DemoStaff
{
   public class StaffApplicationAutoMapperProfile : Profile
   {
      public StaffApplicationAutoMapperProfile() { 
         CreateMap<Staff, StaffDto>();
         CreateMap<UpsertStaffDto, Staff>();

         CreateMap<Department, DepartmentDto>();
         CreateMap<Department, DepartmentLookupDto>();
      }
   }
}
