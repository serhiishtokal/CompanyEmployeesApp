using AutoMapper;
using CompanyEmployees.Application.DTOs;
using CompanyEmployees.Domain.Repositories;
using MediatR;

namespace CompanyEmployees.Application.Queries.Companies.Search
{
    public class SearchCompaniesQuery : IRequest<SearchCompaniesResultDto>
    {
        public CompanyFilterDto CompanyFilter { get; set; }

        public SearchCompaniesQuery(CompanyFilterDto companyFilter)
        {
            CompanyFilter = companyFilter;
        }
    }
    public class SearchCompaniesResultDto
    {
        public IEnumerable<CompanyDto> Results { get; set; }

        public SearchCompaniesResultDto(IEnumerable<CompanyDto> results)
        {
            Results = results;
        }
    }

    public class SearchCompanyQueryHandler : IRequestHandler<SearchCompaniesQuery, SearchCompaniesResultDto>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public SearchCompanyQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<SearchCompaniesResultDto> Handle(SearchCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companyFilter = _mapper.Map<CompanyFilter>(request.CompanyFilter);
            var companies = await _companyRepository.GetAsync(companyFilter);
            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            var result = new SearchCompaniesResultDto(companyDtos);
            return result;
        }
    }
}
