using Framework.Application.Model;
using LibraryManagement.Shared.Contracts.BookDTO;

namespace LibraryManagement.Application.Contracts.Book
{
    public interface IBookApplication
    {
        Task<OperationResultWithData<List<BookViewModelDTO>>> List();
        Task<OperationResultWithData<BookViewModelDTO>> Get(Guid BookId);
        Task<OperationResult> Create(CreateBookDTO command);
        Task<OperationResult> Edit(EditBookDTO command);
    }
}
