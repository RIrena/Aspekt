﻿namespace Aspekt.Domain.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CountryId { get; set; }  
        public Country Country { get; set; }

    }
}
