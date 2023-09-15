using System.Linq.Expressions;

namespace BillPayChecklist.Application.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>?> GetAll();
        Task<IEnumerable<T>?> Where(Expression<Func<T, bool>> predicate);
        Task<T?> Get(Guid id);

        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}