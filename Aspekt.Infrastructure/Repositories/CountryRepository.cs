using Aspekt.Application.Repositories;
using Aspekt.Domain.Models;

namespace Aspekt.Infrastructure.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        public Country Create(Country entity)
        {
            var lastid = AspektStaticDb.Countries.LastOrDefault()?.CountryId ?? 0;
            entity.CountryId = ++lastid;
            AspektStaticDb.Countries.Add(entity);
            return entity;
        }

        public Country Update(Country entity)
        {
            var country = GetById(entity.CountryId);
            if (country != null)
            {
                country = entity;
            }
            return entity;
        }

        public Country? GetById(int id)
        {
            return AspektStaticDb.Countries.FirstOrDefault(x => x.CountryId == id);
        }

        public void Delete(int id)
        {
            var country = GetById(id);
            if (country != null)
            {
                AspektStaticDb.Countries.Remove(country);
            }
        }

        public IList<Country> GetAll()
        {
            return AspektStaticDb.Countries.ToList();
        }
    }
}
