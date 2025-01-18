using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibraryManagement.Application.Contracts.RepositoryBase
{
    public interface IRepositoryBase<TKey, T> where T : class
    {
        Task<T> Get(TKey id);

        Task<List<T>> Get();

        Task<T> Create(T entity);

        Task<T> Edit(T command, TKey key);

        Task<bool> Delete(TKey id);

        Task<bool> Exists(Expression<Func<T, bool>> expression);

        Task SaveChanges();

        IQueryable<T> FindAll();

        IDbContextTransaction GetTransaction();
    }
}
