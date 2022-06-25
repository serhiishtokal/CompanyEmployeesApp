using AutoMapper;
using CompanyEmployees.Application.DTOs;
using CompanyEmployees.Domain.Companies.Exceptions;
using CompanyEmployees.Domain.Repositories;
using MediatR;

namespace CompanyEmployeesApplication.Queries.Companies.Get
{
    public class GetCompanyQuery : IRequest<CompanyDto>
    {
        public GetCompanyQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync(request.Id);
            if(company == null)
            {
                throw new NotFoundException(ExceptionMessages.GetCompanyNotFoundString(request.Id));
            }
            var result = _mapper.Map<CompanyDto>(company);
            return result;
        }
    }
}
