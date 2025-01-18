using Framework.Domain;
using LibraryManagement.Domain.BookAgg;

namespace LibraryManagement.Domain.BookCategoryAgg
{
    public class BookCategoryModel : EntityBase
    {
        public string Caption { get; set; }

        public List<BookModel> Books { get; set; }
    }
}
