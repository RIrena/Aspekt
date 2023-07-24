using Aspekt.Application.Dto;

namespace Aspekt.Application.Services
{
    public interface IContactService
    {
        int CreateContact(ContactDto contact);
        void UpdateContact(ContactDto contact);
        void DeleteContact(int contactId);
        List<ContactDto> GetAll();
        List<ContactDto> GetContactsWithCompanyAndCountry(string companyName, string countryName);
        List<ContactDto> FilterContact(int companyId, int countryId);
    }
}
