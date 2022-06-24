using AutoMapper;
using CompanyEmployees.Application.DTOs;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Repositories;
using MediatR;

namespace CompanyEmployeesApplication.Commands.Companies.Create
{
    public class AddCompanyCommand : IRequest<long>
    {
        public CompanyDto CompanyDto { get; set; }

        public AddCompanyCommand(CompanyDto companyDto)
        {
            CompanyDto = companyDto;
        }
    }

    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, long>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public AddCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request.CompanyDto);
            await _companyRepository.AddAsync(company);
            return company.Id;
        }
    }

}
