using Framework.Application.Model;
using LibraryManagement.Shared.Contracts.BookCategoryDTO;

namespace LibraryManagement.Application.Contracts.BookCategory
{
    public interface IBookCategoryApplication
    {
        Task<OperationResultWithData<List<BookCategoryViewModelDTO>>> List();
        Task<OperationResultWithData<BookCategoryViewModelDTO>> Get(Guid bookCategoryId);
        Task<OperationResult> Create(CreateBookCategoryDTO command);
        Task<OperationResult> Edit(EditBookCategoryDTO command);
    }
}
