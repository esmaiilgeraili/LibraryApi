using Framework.Application.Model;
using LibraryManagement.Application.Contracts.Book;
using LibraryManagement.Shared.Contracts.BookDTO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookApplication _bookApplication;
        public BookController(IBookApplication BookApplication)
        {
            _bookApplication = BookApplication;
        }

        [HttpPost(template: "List")]
        public async Task<OperationResultWithData<List<BookViewModelDTO>>> List()
        {
            return await _bookApplication.List();
        }


        [HttpGet(template: "Book")]
        public async Task<OperationResultWithData<BookViewModelDTO>> Book(Guid BookId)
        {
            return await _bookApplication.Get(BookId);
        }

        [HttpPost(template: "Create")]
        public async Task<OperationResult> Create(CreateBookDTO command)
        {
            return await _bookApplication.Create(command);
        }


        [HttpPut(template: "Edit")]
        public async Task<OperationResult> Edit(EditBookDTO command)
        {
            return await _bookApplication.Edit(command);
        }
    }
}
