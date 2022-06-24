namespace CompanyEmployees.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<long> AddAsync(Company company);
        Task<IEnumerable<Company>> GetAsync(CompanyFilter companyFilter);
        Task<Company> GetAsync(long id);
    }
}