using Framework.Application.Helper;
using Framework.Application.Messages;
using Framework.Application.Model;
using LibraryManagement.Application.Contracts.BookCategory;
using LibraryManagement.Domain.BookCategoryAgg;
using LibraryManagement.Shared.Contracts.BookCategoryDTO;

namespace LibraryManagement.Application
{
    public class BookCategoryApplication : IBookCategoryApplication
    {
        private readonly IBookCategoryRepository _bookCategoryRepository;
        public BookCategoryApplication(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }
        public async Task<OperationResultWithData<List<BookCategoryViewModelDTO>>> List()
        {
            var operation = new OperationResultWithData<List<BookCategoryViewModelDTO>>();
            try
            {
                var res = await _bookCategoryRepository.Get();

                var result = res.Select(x => new BookCategoryViewModelDTO()
                {
                    BookCategoryId = x.Id,
                    Caption = x.Caption,
                    CreationDate = x.CreationDate.ToShamsi()
                }).ToList();
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.FetchError);
            }
        }
        public async Task<OperationResultWithData<BookCategoryViewModelDTO>> Get(Guid bookCategoryId)
        {
            var operation = new OperationResultWithData<BookCategoryViewModelDTO>();
            try
            {
                var res = await _bookCategoryRepository.Get(bookCategoryId);

                var result = new BookCategoryViewModelDTO()
                {
                    BookCategoryId = res.Id,
                    Caption = res.Caption,
                    CreationDate = res.CreationDate.ToShamsi()
                };
                return operation.Succeeded(result);
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.FetchError);
            }
        }
        public async Task<OperationResult> Create(CreateBookCategoryDTO command)
        {
            var operation = new OperationResult();
            try
            {
                var resBookCategoryDu = await _bookCategoryRepository.GetBy(command.Caption);
                if (!resBookCategoryDu.IsSucceeded)
                    return operation.Failed(resBookCategoryDu.Message);
                if (resBookCategoryDu.Result != null)
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);

                var request = new BookCategoryModel()
                {
                    Caption = command.Caption,
                };
                var resCreate = await _bookCategoryRepository.Create(request);
                if (resCreate == null)
                    return operation.Failed(ApplicationMessages.CreateError);

                await _bookCategoryRepository.SaveChanges();
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.CreateError);
            }
        }
        public async Task<OperationResult> Edit(EditBookCategoryDTO command)
        {
            var operation = new OperationResult();
            try
            {
                var resBookCategory = await _bookCategoryRepository.Get(command.BookCategoryId);
                if (resBookCategory == null)
                    return operation.Failed(ApplicationMessages.RecordNotFound);

                var resBookCategoryDu = await _bookCategoryRepository.GetBy(command.Caption);
                if (!resBookCategoryDu.IsSucceeded)
                    return operation.Failed(resBookCategoryDu.Message);
                if (resBookCategoryDu.Result != null && resBookCategoryDu.Result.Id != resBookCategory.Id)
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);

                resBookCategory.Caption = command.Caption;

                var resCreate = await _bookCategoryRepository.Edit(resBookCategory, resBookCategory.Id);
                if (resCreate == null)
                    return operation.Failed(ApplicationMessages.EditError);

                await _bookCategoryRepository.SaveChanges();
                return operation.Succeeded();
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.EditError);
            }
        }
    }
}
