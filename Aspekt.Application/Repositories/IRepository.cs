namespace Aspekt.Application.Repositories
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        IList<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);

    }
}
