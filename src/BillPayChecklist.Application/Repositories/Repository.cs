using System.Linq.Expressions;
using BillPayChecklist.Application.Contexts;
using BillPayChecklist.Application.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BillPayChecklist.Application.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>?> GetAll() => await context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>?> Where(Expression<Func<T, bool>> predicate)
            => await context.Set<T>().Where(predicate).ToListAsync();

        public async Task<T?> Get(Guid id) => await context.Set<T>().FindAsync(id);

        public async Task Create(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}