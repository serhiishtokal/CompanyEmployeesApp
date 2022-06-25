using AutoMapper;
using CompanyEmployees.Domain.Repositories;
using MediatR;

namespace CompanyEmployees.Application.Commands.Companies.Delete
{
    public class DeleteCompanyCommand : IRequest<long>
    {
        public long Id { get; set; }

        public DeleteCompanyCommand(long id)
        {
            Id = id;
        }
    }
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, long>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            await _companyRepository.DeleteAsync(request.Id);
            await _companyRepository.SaveAsync();
            return request.Id;
        }
    }

}
