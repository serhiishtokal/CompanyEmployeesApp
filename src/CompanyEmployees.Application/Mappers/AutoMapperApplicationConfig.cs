using AutoMapper;
using CompanyEmployees.Application.DTOs;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Repositories;

namespace CompanyEmployees.Application.Mappers
{
    public class AutoMapperApplicationConfig : Profile
    {
        public AutoMapperApplicationConfig()
        {
            CreateMap<CompanyDto, Company>();
            CreateMap<Company, CompanyDto>();

            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CompanyFilterDto, CompanyFilter>();
        }
    }
}
