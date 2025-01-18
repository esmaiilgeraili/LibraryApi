namespace LibraryManagement.Shared.Contracts.BookCategoryDTO
{
    public class BookCategoryViewModelDTO
    {
        public Guid BookCategoryId { get; set; }
        public string Caption { get; set; }
        public string CreationDate { get; set; }
    }
    public class CreateBookCategoryDTO
    {
        public string Caption { get; set; }
    }
    public class EditBookCategoryDTO : CreateBookCategoryDTO
    {
        public Guid BookCategoryId { get; set; }
    }
}
