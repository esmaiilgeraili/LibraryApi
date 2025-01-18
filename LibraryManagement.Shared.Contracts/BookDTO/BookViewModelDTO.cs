namespace LibraryManagement.Shared.Contracts.BookDTO
{
    public class BookViewModelDTO
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CreationDate { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryCaption { get; set; }
    }
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Guid CategoryId { get; set; }
    }
    public class EditBookDTO : CreateBookDTO
    {
        public Guid BookId { get; set; }
    }
}
