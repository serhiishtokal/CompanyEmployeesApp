namespace CompanyEmployees.Domain.Repositories
{
    public class CompanyFilter
    {
        public string? Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public IEnumerable<JobType>? EmployeeJobTitles { get; set; }
    }
}
