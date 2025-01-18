using LibraryManagement.Application.Contracts.RepositoryBase;
using LibraryManagement.Domain.BookAgg;

namespace LibraryManagement.Application.Contracts.Book
{
    public interface IBookRepository : IRepositoryBase<Guid, BookModel>
    {
    }
}
