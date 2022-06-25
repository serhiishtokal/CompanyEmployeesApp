using CompanyEmployees.Domain;
using LinqKit;

namespace CompanyEmployees.Infrastructure.Extensions.RepositoryExtensions
{
    internal static class CompanyRepositoryExtensions
    {
        public static IQueryable<Company> FilterForKeyWord(this IQueryable<Company> query, string? keyword)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var fixedKeyword = keyword.ToLower();
                var predicate = PredicateBuilder.New<Company>(false)
                    .Or(x => x.Name.ToLower().Contains(keyword))
                    .Or(x => x.Employees.Any(x => x.FirstName.ToLower().Contains(keyword)))
                    .Or(x => x.Employees.Any(x => x.LastName.ToLower().Contains(keyword)));

                query = query.Where(predicate.Expand());
            }

            return query;
        }

        public static IQueryable<Company> FilterForEmployeeDateOfBirth(this IQueryable<Company> query, DateTime? employeeDateOfBirthFrom, DateTime? employeeDateOfBirthTo)
        {
            query = query
                .Where(x=>x.Employees
                    .Any(x=>(employeeDateOfBirthFrom ==null || x.DateOfBirth>= employeeDateOfBirthFrom) 
                        && (employeeDateOfBirthTo == null || x.DateOfBirth <= employeeDateOfBirthTo)));
            
            return query;
        }

        public static IQueryable<Company> FilterForEmployeeJobTitle(this IQueryable<Company> query, IEnumerable<JobType>? jobType)
        {
            if (jobType is not null && jobType.Any())
            {
                query = query
                    .Where(x => x.Employees.Any(x => jobType.Contains(x.JobTitle)));
            }

            return query;
        }
    }
}
