using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Repositories;
using CompanyEmployees.Infrastructure.EF;
using CompanyEmployees.Infrastructure.Extensions.RepositoryExtensions;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Infrastructure.Repositories
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Company> _companySet;
        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _companySet = appDbContext.Set<Company>();
        }

        public async Task<Company> GetAsync(long id)
        {
            var company = await _companySet
                .AsNoTracking()
                .Include(x => x.Employees)
                .FirstOrDefaultAsync(x => x.Id == id);
            return company;
        }

        public async Task<Company> GetWithTrackingAsync(long id)
        {
            var company = await _companySet
                .Include(x => x.Employees)
                .FirstOrDefaultAsync(x => x.Id == id);
            return company;
        }

        public async Task<IEnumerable<Company>> GetAsync(CompanyFilter companyFilter)
        {
            var companies = await _companySet.AsNoTracking()
                .Include(x => x.Employees)
                .FilterForKeyWord(companyFilter.Keyword)
                .FilterForEmployeeDateOfBirth(companyFilter.EmployeeDateOfBirthFrom, companyFilter.EmployeeDateOfBirthTo)
                .FilterForEmployeeJobTitle(companyFilter.EmployeeJobTitles)
                .ToArrayAsync();

            return companies;
        }

        public async Task<long> AddAsync(Company company)
        {
            await _companySet.AddAsync(company);
            return company.Id;
        }

        public void Update(Company company)
        {
            _companySet.Attach(company);
            _appDbContext.Entry(company).State = EntityState.Modified;
        }

        public async Task DeleteAsync(long companyId)
        {
            var company = await _companySet.FirstOrDefaultAsync(x => x.Id == companyId);
            if (company != null)
            {
                _companySet.Remove(company);
            }
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
