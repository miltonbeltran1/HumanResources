using AutoMapper;
using BAL.Models;
using DAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Utility.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {

            CreateMap<EmployeeDTO, Employee>()
               .ForMember(x => x.id, y => y.MapFrom(src => src.id))
               .ForMember(x => x.name, y => y.MapFrom(src => src.name))
               .ForMember(x => x.hourlySalary, y => y.MapFrom(src => src.hourlySalary))
               .ForMember(x => x.monthlySalary, y => y.MapFrom(src => src.monthlySalary))
               .ForMember(x => x.contractTypeName, y => y.MapFrom(src => src.contractTypeName))
               .ForPath(x => x.role, y => y.MapFrom(src => src.role));

            CreateMap<Employee, EmployeeDTO>()
               .ForMember(x => x.id, y => y.MapFrom(src => src.id))
               .ForMember(x => x.name, y => y.MapFrom(src => src.name))
               .ForMember(x => x.hourlySalary, y => y.MapFrom(src => src.hourlySalary))
               .ForMember(x => x.monthlySalary, y => y.MapFrom(src => src.monthlySalary))
               .ForMember(x => x.contractTypeName, y => y.MapFrom(src => src.contractTypeName))
               .ForPath(x => x.role, y => y.MapFrom(src => src.role));
        }
    }
}
