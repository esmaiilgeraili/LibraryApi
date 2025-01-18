using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Domain.BookAgg;

namespace LibraryManagement.Infrastructure.EfCore.Mapping
{
    internal class BookMapping : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Author).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.BookCategory).WithMany(x => x.Books).HasForeignKey(x => x.CategoryId);
        }
    }
}
