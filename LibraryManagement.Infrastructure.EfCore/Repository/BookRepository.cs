using Framework.Application.Messages;
using Framework.Application.Model;
using LibraryManagement.Application.Contracts.Book;
using LibraryManagement.Domain.BookAgg;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.EfCore.Repository
{
    public class BookRepository : RepositoryBase<Guid, BookModel>, IBookRepository
    {
        private readonly LibraryContext _db;
        public BookRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }
        public async Task<OperationResultWithData<List<BookModel>>> GetAll()
        {
            var operation = new OperationResultWithData<List<BookModel>>();
            try
            {
                var res = await _db.BookModel.Include(x => x.BookCategory).ToListAsync();
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.FetchError);
            }
        }
        public async Task<OperationResultWithData<BookModel>> GetBy(Guid bookId)
        {
            var operation = new OperationResultWithData<BookModel>();
            try
            {
                var res = await _db.BookModel.Include(x => x.BookCategory).Where(x => x.Id == bookId).FirstOrDefaultAsync();
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.FetchError);
            }
        }
        public async Task<OperationResultWithData<BookModel>> GetBy(string title)
        {
            var operation = new OperationResultWithData<BookModel>();
            try
            {
                var res = await _db.BookModel.Include(x => x.BookCategory).Where(x => x.Title == title).FirstOrDefaultAsync();
                return operation.Succeeded(res);
            }
            catch (Exception ex)
            {
                return operation.Failed(ApplicationMessages.FetchError);
            }
        }
    }
}
