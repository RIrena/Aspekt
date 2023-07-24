using System.ComponentModel.DataAnnotations;

namespace Aspekt.Domain.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
    }
}
