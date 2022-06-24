using CompanyEmployees.Domain;
using CompanyEmployees.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Infrastructure.EF
{
    internal class AppDbContext : DbContext
    {
        public readonly ConnectionStringOptions _connectionStringOptions;
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }

        public AppDbContext(ConnectionStringOptions connectionStringOptions)
        {
            _connectionStringOptions = connectionStringOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(x => x.JobTitle).HasConversion<string>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringOptions.DefaultConnection, options => options.EnableRetryOnFailure(3));
        }

        public async Task<int> SaveChangesAndCommitAsync(CancellationToken cancellationToken = default)
        {
            var result = await SaveChangesAsync(cancellationToken);
            if (Database.CurrentTransaction != null)
            {
                await Database.CurrentTransaction.CommitAsync();
            }
            return result;
        }
    }
}
