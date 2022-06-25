namespace CompanyEmployees.Domain.Repositories
{
    public interface ICompanyRepository
    {
        Task<long> AddAsync(Company company);
        Task DeleteAsync(long companyId);
        Task<IEnumerable<Company>> GetAsync(CompanyFilter companyFilter);
        Task<Company> GetAsync(long id);
        Task<Company> GetWithTrackingAsync(long id);
        Task SaveAsync();
    }
}