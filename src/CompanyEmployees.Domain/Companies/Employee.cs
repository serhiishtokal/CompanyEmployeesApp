
namespace CompanyEmployees.Domain
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobType JobTitle { get; set; }

        public long CompanyId { get; set; }
        public Company? Company { get; set; }
        
        public Employee(string firstName, string lastName, DateTime dateOfBirth, JobType jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            JobTitle = jobTitle;
        }

        protected Employee()
        {

        }
    }
}
