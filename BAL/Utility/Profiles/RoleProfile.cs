using AutoMapper;
using BAL.Models;
using DAL.Domain.Entities;

namespace BAL.Utility.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDTO, Role>();

            CreateMap<Role, RoleDTO>();
        }
    }
}
