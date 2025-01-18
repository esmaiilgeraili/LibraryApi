using Framework.Application.Helper;
using Framework.Application.Messages;
using Framework.Application.Model;
using LibraryManagement.Application.Contracts.Book;
using LibraryManagement.Application.Contracts.BookCategory;
using LibraryManagement.Domain.BookAgg;
using LibraryManagement.Shared.Contracts.BookDTO;

namespace LibraryManagement.Application
{
    public class BookApplication : IBookApplication
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookCategoryRepository _bookCategoryRepository;
        public BookApplication(IBookRepository bookRepository, IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _bookCategoryRepository = bookCategoryRepository;
        }
        public async Task<OperationResultWithData<List<BookViewModelDTO>>> List()
        {
            var operation = new OperationResultWithData<List<BookViewModelDTO>>();
            try
            {
                var res = await _bookRepository.GetAll();
                if (res.IsSucceeded)
                    return operation.Failed(res.Message);

                var result = res.Result.Select(x => new BookViewModelDTO()
                {
                    BookId = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    CreationDate = x.CreationDate.ToShamsi(),
                    CategoryId = x.CategoryId,
                    CategoryCaption = x.BookCategory.Caption,
                }).ToList();
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.FetchError);
            }
        }
        public async Task<OperationResultWithData<BookViewModelDTO>> Get(Guid BookId)
        {
            var operation = new OperationResultWithData<BookViewModelDTO>();
            try
            {
                var res = await _bookRepository.GetBy(BookId);
                if (res.IsSucceeded)
                    return operation.Failed(res.Message);

                var x = res.Result;
                var result = new BookViewModelDTO()
                {
                    BookId = x.Id,
                    Title = x.Title,
                    Author = x.Author,
                    CreationDate = x.CreationDate.ToShamsi(),
                    CategoryId = x.CategoryId,
                    CategoryCaption = x.BookCategory.Caption,
                };
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.FetchError);
            }
        }
        public async Task<OperationResult> Create(CreateBookDTO command)
        {
            var operation = new OperationResult();
            try
            {
                var resBookDu = await _bookRepository.GetBy(command.Title);
                if (!resBookDu.IsSucceeded)
                    return operation.Failed(resBookDu.Message);
                if (resBookDu.Result != null)
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);

                var resBookCategory = await _bookCategoryRepository.Get(command.CategoryId);
                if (resBookCategory == null)
                    return operation.Failed(ApplicationMessages.RecordNotFound);

                var request = new BookModel()
                {
                    Title = command.Title,
                    Author = command.Author,
                    CategoryId = command.CategoryId,
                };
                var resCreate = await _bookRepository.Create(request);
                if (resCreate == null)
                    return operation.Failed(ApplicationMessages.CreateError);

                await _bookRepository.SaveChanges();
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.CreateError);
            }
        }
        public async Task<OperationResult> Edit(EditBookDTO command)
        {
            var operation = new OperationResult();
            try
            {
                var resBook = await _bookRepository.Get(command.BookId);
                if (resBook == null)
                    return operation.Failed(ApplicationMessages.RecordNotFound);

                var resBookDu = await _bookRepository.GetBy(command.Title);
                if (!resBookDu.IsSucceeded)
                    return operation.Failed(resBookDu.Message);
                if (resBookDu.Result != null && resBookDu.Result.Id != resBook.Id)
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);

                var resBookCategory = await _bookCategoryRepository.Get(command.CategoryId);
                if (resBookCategory == null)
                    return operation.Failed(ApplicationMessages.RecordNotFound);


                resBook.Title = command.Title;
                resBook.Author = command.Author;
                resBook.CategoryId = command.CategoryId;

                var resEdit = await _bookRepository.Edit(resBook, resBook.Id);
                if (resEdit == null)
                    return operation.Failed(ApplicationMessages.EditError);

                await _bookRepository.SaveChanges();
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.EditError);
            }
        }

    }
}
