using CompanyEmployees.Domain;

namespace CompanyEmployees.Application.DTOs
{
    public class CompanyFilterDto
    {
        public string? Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public IEnumerable<JobType>? EmployeeJobTitles { get; set; }
    }
}
