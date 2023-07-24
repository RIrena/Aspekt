using Aspekt.Application.Repositories;
using Aspekt.Domain.Models;

namespace Aspekt.Infrastructure.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        public Company Create(Company entity)
        {
            var id = AspektStaticDb.Companies.LastOrDefault(x => x.CompanyId == entity.CompanyId)?.CompanyId ?? 0;
            entity.CompanyId = ++id;

            AspektStaticDb.Companies.Add(entity);
            return entity;
        }

        public Company Update(Company entity)
        {
            var company = GetById(entity.CompanyId);
            if (company != null)
            {
                company = entity;
            }
            return entity;
        }

        public Company? GetById(int id)
        {
            return AspektStaticDb.Companies.FirstOrDefault(x => x.CompanyId == id);
        }

        public void Delete(int id)
        {
            var company = GetById(id);
            if (company != null)
            {
                AspektStaticDb.Companies.Remove(company);
            }
        }

        public IList<Company> GetAll()
        {
            return AspektStaticDb.Companies.ToList();
        }
    }
}
