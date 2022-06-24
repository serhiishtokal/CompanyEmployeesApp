using CompanyEmployees.Domain;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Application.DTOs
{
    public class EmployeeDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public JobType? JobTitle { get; set; }
    }
}
