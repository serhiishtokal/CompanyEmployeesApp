using Autofac;
using CompanyEmployees.Domain.Repositories;
using CompanyEmployees.Infrastructure.EF;
using CompanyEmployees.Infrastructure.Repositories;
using CompanyEmployeesApplication.StartupTasks;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyEmployees.Infrastructure
{
    public class InfrastructureModule
    {
        public static void RegisterModuleServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>((sp, options) => options.UseInternalServiceProvider(sp));

            services.AddTransient<IStartupTask, AutoMigrationStartupTask>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
