using LibraryManagement.Application.Contracts.BookCategory;
using LibraryManagement.Domain.BookCategoryAgg;

namespace LibraryManagement.Infrastructure.EfCore.Repository
{
    public class BookCategoryRepository : RepositoryBase<Guid, BookCategoryModel>, IBookCategoryRepository
    {
        private readonly LibraryContext _db;
        public BookCategoryRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }
    }
}
