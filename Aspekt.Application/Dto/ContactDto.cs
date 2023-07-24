namespace Aspekt.Application.Dto
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
    }
}
