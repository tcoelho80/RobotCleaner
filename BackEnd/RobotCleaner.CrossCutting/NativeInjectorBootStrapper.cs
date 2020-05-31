using Microsoft.Extensions.DependencyInjection;
using RobotCleaner.AppServices.Interfaces;
using RobotCleaner.AppServices.Services;
using RobotCleaner.Domain.Interfaces;
using RobotCleaner.Infrastructure.Repository.Repositories;

namespace RobotCleaner.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IRobotCleanerServices, RobotCleanerServices>();

            //Repositories
            services.AddScoped<IRobotCleanerRepository, RobotCleanerRepository>();

        }
    }
}
