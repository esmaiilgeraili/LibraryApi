using Framework.Domain;
using LibraryManagement.Domain.BookCategoryAgg;

namespace LibraryManagement.Domain.BookAgg
{
    public class BookModel : EntityBase
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Guid CategoryId { get; set; }
        public BookCategoryModel BookCategory { get; set; }
    }
}
