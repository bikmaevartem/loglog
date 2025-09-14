using LogLog.Domain.Interfaces.Repositories;
using LogLog.Infrastructure.SqlLite;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Xml.Linq;

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

        public async Task<T?> FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(new object[] { id });
        }

        public async Task<T?> FindByNameAsync(string name)
        {
            return await FindByProperty("Name", name);
        }

        protected async Task<T?> FindByProperty<P>(string propertyName, P propertyValue) where P : class
        {
            var property = typeof(T).GetProperty(propertyName);
            if (property == null)
                throw new InvalidOperationException($"Entity {typeof(T).Name} does not have a {propertyName} property.");

            return await _dbSet.FirstOrDefaultAsync(
            x => EF.Property<P>(x, propertyName) == propertyValue);
        }

        
    }
}
