using System.ComponentModel.DataAnnotations;


namespace Aspekt.Domain.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
    }
}
