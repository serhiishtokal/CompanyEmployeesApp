namespace CompanyEmployees.Domain.Repositories
{
    public class CompanyFilter
    {
        public string? Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrome { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public JobType? EmployeeJobTitles { get; set; }
    }
}
