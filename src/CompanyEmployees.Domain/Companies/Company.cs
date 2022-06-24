namespace CompanyEmployees.Domain
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public List<Employee>? Employees { get; protected set; }

        public Company(string name, int establishmentYear)
        {
            Name = name;
            EstablishmentYear = establishmentYear;
        }
        // todo add methods to set & validation
        protected Company()
        {
        }
    }
}
