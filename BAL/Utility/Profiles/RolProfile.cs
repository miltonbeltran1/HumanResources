using AutoMapper;
using BAL.Models;
using DAL.Domain.Entities;

namespace BAL.Utility.Profiles
{
    public class RolProfile : Profile
    {
        public RolProfile()
        {
            CreateMap<RoleDTO, Role>();

            CreateMap<Role, RoleDTO>();
        }
    }
}
