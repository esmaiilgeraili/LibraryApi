using Framework.Application.Model;
using LibraryManagement.Application.Contracts.RepositoryBase;
using LibraryManagement.Domain.BookAgg;

namespace LibraryManagement.Application.Contracts.Book
{
    public interface IBookRepository : IRepositoryBase<Guid, BookModel>
    {
        Task<OperationResultWithData<List<BookModel>>> GetAll();
        Task<OperationResultWithData<BookModel>> GetBy(Guid bookId);
        Task<OperationResultWithData<BookModel>> GetBy(string title);
    }
}
