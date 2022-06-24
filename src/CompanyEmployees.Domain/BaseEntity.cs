using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployees.Domain
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        protected BaseEntity()
        {
            CreateDate = DateTime.Now;
        }
    }
}
