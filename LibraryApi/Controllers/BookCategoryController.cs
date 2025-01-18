using System.Net;
using Framework.Application.Model;
using LibraryManagement.Application.Contracts.BookCategory;
using LibraryManagement.Shared.Contracts.BookCategoryDTO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public BookCategoryController(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }

        [HttpPost(template: "List")]
        public async Task<OperationResultWithData<List<BookCategoryViewModelDTO>>> List()
        {
            return await _bookCategoryApplication.List();
        }


        [HttpGet(template: "BookCategory")]
        public async Task<OperationResultWithData<BookCategoryViewModelDTO>> BookCategory(Guid bookCategoryId)
        {
            return await _bookCategoryApplication.Get(bookCategoryId);
        }

        [HttpPost(template: "Create")]
        public async Task<OperationResult> Create(CreateBookCategoryDTO command)
        {
            return await _bookCategoryApplication.Create(command);
        }


        [HttpPut(template: "Edit")]
        public async Task<OperationResult> Edit(EditBookCategoryDTO command)
        {
            return await _bookCategoryApplication.Edit(command);
        }
    }
}
