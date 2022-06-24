using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Application.DTOs
{
    public class CompanyDto
    {
        [Required(AllowEmptyStrings = false)]
        public string? Name { get; set; }
        [Required]
        public int? EstablishmentYear { get; set; }
        [Required]
        public List<EmployeeDto>? Employees { get; set; }
    }
}
