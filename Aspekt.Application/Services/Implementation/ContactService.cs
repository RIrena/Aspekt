using Aspekt.Application.Dto;
using Aspekt.Application.Mapper;
using Aspekt.Application.Repositories;
using Aspekt.Domain.Models;

namespace Aspekt.Application.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public int CreateContact(ContactDto contact)
        {
            var mappedContact = contactRepository.Create(contact.ToDomain());
            return mappedContact.ContactId;
        }

        public void UpdateContact(ContactDto contact)
        {
            contactRepository.Update(contact.ToDomain());
        }

        public void DeleteContact(int contactId)
        {
            contactRepository.Delete(contactId);
        }

        public List<ContactDto> GetAll()
        {
            var contacts = contactRepository.GetAll();
            var contactsDto = new List<ContactDto>();
            foreach (var item in contacts)
            {
                contactsDto.Add(item.ToDto());
            }
            return contactsDto;
        }

        public List<ContactDto> GetContactsWithCompanyAndCountry(string companyName, string countryName)
        {
            var contactDetails = contactRepository.GetAll().Where(x => x.CountryId.Equals(companyName) && x.CompanyId.Equals(countryName)).ToList();
            var contactDetailsDto = new List<ContactDto>();
            return contactDetailsDto;
        }

        public List<ContactDto> FilterContact(int companyId, int countryId)
        {
            List<Contact> filteredContacts = new List<Contact>();
            List<ContactDto> contactsDto = new List<ContactDto>();

            filteredContacts = contactRepository.GetAll().Where(x => x.CountryId.Equals(countryId) && x.CompanyId.Equals(companyId)).ToList();

            foreach (Contact item in filteredContacts)
            {
                contactsDto.Add(item.ToDto());
            }
            return contactsDto;
        }
    }
}
