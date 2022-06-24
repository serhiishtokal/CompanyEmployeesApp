using Autofac;
using CompanyEmployeesApplication.Commands.Companies.Create;
using CompanyEmployeesApplication.Queries.Companies.Get;

namespace CompanyEmployeesApplication
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetCompanyQuery>().AsImplementedInterfaces();
            builder.RegisterType<GetProductQueryHandler>().AsImplementedInterfaces();

            builder.RegisterType<AddCompanyCommand>().AsImplementedInterfaces();
            builder.RegisterType<AddCompanyCommandHandler>().AsImplementedInterfaces();
        }
    }
}
