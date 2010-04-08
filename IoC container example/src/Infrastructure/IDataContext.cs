using System.Linq;

namespace Infrastructure
{
    public interface IDataContext
    {
        IQueryable<T> Query<T>();
        void Save<T>(T entity);
        void Delete<T>(T entity);
        T Get<T>(int id);
    }
}