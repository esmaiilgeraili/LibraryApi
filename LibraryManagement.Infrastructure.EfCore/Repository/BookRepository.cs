using LibraryManagement.Application.Contracts.Book;
using LibraryManagement.Domain.BookAgg;

namespace LibraryManagement.Infrastructure.EfCore.Repository
{
    public class BookRepository : RepositoryBase<Guid, BookModel>, IBookRepository
    {
        private readonly LibraryContext _db;
        public BookRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }
    }
}
