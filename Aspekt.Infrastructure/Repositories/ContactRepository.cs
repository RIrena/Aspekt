using Aspekt.Application.Repositories;
using Aspekt.Domain.Models;

namespace Aspekt.Infrastructure.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        public Contact Create(Contact entity)
        {
            var lastid = AspektStaticDb.Contacts.LastOrDefault()?.ContactId ?? 0;
            entity.ContactId = ++lastid;
            AspektStaticDb.Contacts.Add(entity);
            return entity;
        }

        public Contact Update(Contact entity)
        {
            var contact = GetById(entity.ContactId);
            if (contact != null)
            {
                contact = entity;
            }
            return entity;
        }

        public Contact? GetById(int id)
        {
            return AspektStaticDb.Contacts.FirstOrDefault(x => x.ContactId == id);
        }

        public void Delete(int id)
        {
            var contact = GetById(id);
            if (contact != null)
            {
                AspektStaticDb.Contacts.Remove(contact);
            }
        }

        public IList<Contact> GetAll()
        {
            return AspektStaticDb.Contacts.ToList();
        }
    }
}
