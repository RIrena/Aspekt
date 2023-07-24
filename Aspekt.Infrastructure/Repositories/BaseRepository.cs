using Aspekt.Application.Repositories;

namespace Aspekt.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Create(T entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public T? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Equals(id));
        }

        public void Delete(int id)
        {
            var deletingId = dbContext.Set<T>().Find(id);
            if (deletingId != null)
            {
                dbContext.Remove(deletingId);
                dbContext.SaveChanges();
            }
        }

        public IList<T> GetAll()
        {
            return dbContext.Set<T>().ToList();

        }
    }
}
