using AutoMapper;
using BAL.Utility.Profiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources.Installer
{

    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(EmployeeProfile));
            services.AddAutoMapper(typeof(RolProfile));
        }
    }
}
