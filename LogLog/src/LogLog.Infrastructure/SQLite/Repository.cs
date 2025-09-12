using LogLog.Domain.Interfaces.Repositories;
using LogLog.Infrastructure.SqlLite;
using Microsoft.EntityFrameworkCore;

namespace LogLog.Infrastructure.SQLite
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SQLiteDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected Repository(SQLiteDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(new object [] { id });
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public Task<IReadOnlyList<T>> GetAllByParentIdAsync(int parentId)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(new object[] { id });
        }

        public async Task<T?> GetByNameAsync(string name)
        {
            return await _dbSet.FindAsync(new object[] { name });
        }

        
    }
}
