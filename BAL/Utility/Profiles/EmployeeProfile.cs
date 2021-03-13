using AutoMapper;
using BAL.Models;
using DAL.Domain.Entities;

namespace BAL.Utility.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDTO, Employee>()
               .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
               .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
               .ForMember(x => x.HourlySalary, y => y.MapFrom(src => src.HourlySalary))
               .ForMember(x => x.MonthlySalary, y => y.MapFrom(src => src.MonthlySalary))
               .ForMember(x => x.ContractTypeName, y => y.MapFrom(src => src.ContractTypeName))
               .ForPath(x => x.Role, y => y.MapFrom(src => src.Role));

            CreateMap<Employee, EmployeeDTO>()
               .ForMember(x => x.Id, y => y.MapFrom(src => src.Id))
               .ForMember(x => x.Name, y => y.MapFrom(src => src.Name))
               .ForMember(x => x.HourlySalary, y => y.MapFrom(src => src.HourlySalary))
               .ForMember(x => x.MonthlySalary, y => y.MapFrom(src => src.MonthlySalary))
               .ForMember(x => x.ContractTypeName, y => y.MapFrom(src => src.ContractTypeName))
               .ForPath(x => x.Role, y => y.MapFrom(src => src.Role));
        }
    }
}
