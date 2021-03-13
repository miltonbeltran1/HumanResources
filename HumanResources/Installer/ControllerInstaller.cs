using BAL.Implementation;
using BAL.Interfaces;
using BAL.Routes.V1;
using BAL.Utility.Factory;
using CommonUtility.Helpers;
using DAL.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HumanResources.Installer
{
    public class ControllerInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddHttpClient("EmployeeClient", client =>
            {
                client.BaseAddress = new Uri(configuration.GetSection(ApiRoutes.Employee.EmployeeBaseRouteSection).Value);
            });

            services.AddOptions();

            //Services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IConsumeExternalService, ConsumeExternalService>();
            services.AddScoped<IMapperToDAO, MapperToDAO>();
            services.AddScoped<CalculateSalaryFactory>();
            services.AddScoped<CalculateSalaryMonthly>().AddScoped<ICalculateSalary, CalculateSalaryMonthly>(service => service.GetService<CalculateSalaryMonthly>());
            services.AddScoped<CalculateSalaryHourly>().AddScoped<ICalculateSalary,CalculateSalaryHourly>(service => service.GetService<CalculateSalaryHourly>());

        }
    }
}
