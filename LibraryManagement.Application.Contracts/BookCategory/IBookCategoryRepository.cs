using LibraryManagement.Application.Contracts.RepositoryBase;
using LibraryManagement.Domain.BookCategoryAgg;

namespace LibraryManagement.Application.Contracts.BookCategory
{
    public interface IBookCategoryRepository : IRepositoryBase<Guid, BookCategoryModel>
    {
    }
}
