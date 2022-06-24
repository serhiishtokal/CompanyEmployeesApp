using AutoMapper;
using CompanyEmployees.Application.DTOs;
using CompanyEmployees.Domain;

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
        }
    }
}
