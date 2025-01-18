using System.Linq.Expressions;
using LibraryManagement.Application.Contracts.RepositoryBase;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.EfCore.Repository
{
    public class RepositoryBase<TKey, T> : IRepositoryBase<TKey, T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task<T> Edit(T command, TKey key)
        {
            try
            {
                T val = await _context.FindAsync<T>(new object[1] { key });
                if (val != null)
                {
                    _context.Entry(val).State = EntityState.Detached;
                }

                _context.Entry(command).State = EntityState.Modified;
                return command;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(TKey id)
        {
            try
            {
                T val = await _context.FindAsync<T>(new object[1] { id });
                if (val != null)
                {
                    _context.Remove(val);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> Get(TKey id)
        {
            return await _context.FindAsync<T>(new object[1] { id });
        }

        public async Task<List<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public IDbContextTransaction GetTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
