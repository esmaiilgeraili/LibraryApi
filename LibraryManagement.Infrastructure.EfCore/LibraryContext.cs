using LibraryManagement.Domain.BookAgg;
using LibraryManagement.Domain.BookCategoryAgg;
using LibraryManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.EfCore
{
    public class LibraryContext : DbContext
    {
        public DbSet<BookCategoryModel> BookCategoryModel { get; set; }
        public DbSet<BookModel> BookModel { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(BookCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
