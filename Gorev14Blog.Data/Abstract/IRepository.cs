using System.Linq.Expressions; // lambda expression için

namespace Gorev14Blog.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> FindAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<int> SaveAsync();
        void Delete(T entity);
        void Update(T entity);
    }
}
