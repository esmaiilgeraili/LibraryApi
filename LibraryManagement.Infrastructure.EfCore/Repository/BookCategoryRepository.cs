using Framework.Application.Messages;
using Framework.Application.Model;
using LibraryManagement.Application.Contracts.BookCategory;
using LibraryManagement.Domain.BookCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.EfCore.Repository
{
    public class BookCategoryRepository : RepositoryBase<Guid, BookCategoryModel>, IBookCategoryRepository
    {
        private readonly LibraryContext _db;
        public BookCategoryRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }
        public async Task<OperationResultWithData<BookCategoryModel>> GetBy(string caption)
        {
            var operation = new OperationResultWithData<BookCategoryModel>();
            try
            {
                var res = await _db.BookCategoryModel.Where(x => x.Caption == caption).FirstOrDefaultAsync();
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.FetchError);
            }
        }
    }
}
