using Aspekt.Domain.Models;

namespace Aspekt.Infrastructure
{
    public static class AspektStaticDb
    {
        public static IList<Company> Companies { get; set; } = new List<Company>();
        public static IList<Contact> Contacts { get; set; } = new List<Contact>();
        public static IList<Country> Countries { get; set; } = new List<Country>();  
    }
}