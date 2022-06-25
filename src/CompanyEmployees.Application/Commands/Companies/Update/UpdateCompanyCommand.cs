using AutoMapper;
using CompanyEmployees.Application.DTOs;
using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Companies.Exceptions;
using CompanyEmployees.Domain.Repositories;
using MediatR;

namespace CompanyEmployees.Application.Commands.Companies.Update
{
    public class UpdateCompanyCommand : IRequest<long>
    {
        public long Id { get; set; }
        public CompanyDto CompanyDto { get; set; }

        public UpdateCompanyCommand(long id, CompanyDto companyDto)
        {
            Id = id;
            CompanyDto = companyDto;
        }
    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, long>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetWithTrackingAsync(request.Id);
            if (company == null)
            {
                throw new NotFoundException(ExceptionMessages.GetCompanyNotFoundString(request.Id));
            }
            var updatedCompany = _mapper.Map<Company>(request.CompanyDto);
            company.Name = updatedCompany.Name;
            company.EstablishmentYear = updatedCompany.EstablishmentYear;
            company.Employees = updatedCompany.Employees;

            await _companyRepository.SaveAsync();
            return request.Id;
        }
    }
}
