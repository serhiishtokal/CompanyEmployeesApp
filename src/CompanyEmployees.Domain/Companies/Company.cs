namespace CompanyEmployees.Domain
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<Employee>? Employees { get; set; }

        public Company(string name, int establishmentYear)
        {
            Name = name;
            EstablishmentYear = establishmentYear;
        }
        
        protected Company()
        {
        }
    }
}
