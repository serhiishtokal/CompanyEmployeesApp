using CompanyEmployees.Domain;
using CompanyEmployees.Domain.Repositories;
using CompanyEmployees.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Infrastructure.Repositories
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _appDbContext;
        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Company> GetAsync(long id)
        {
            var query = _appDbContext.Set<Company>().AsNoTrackingWithIdentityResolution();
            var company = await query
                .Include(x=>x.Employees)
                .FirstOrDefaultAsync(x => x.Id == id);
            return company;
        }

        public Task<IEnumerable<Company>> GetAsync(CompanyFilter companyFilter)
        {
            // todo
            throw new NotImplementedException();
        }

        public async Task<long> AddAsync(Company company)
        {
            await _appDbContext.AddAsync(company);
            await _appDbContext.SaveChangesAsync();
            return company.Id;
        }

        public async Task<long> UpdateAsync(Company company)
        {
            _appDbContext.Update(company);
            await _appDbContext.SaveChangesAsync();
            return company.Id;
        }
    }
}
