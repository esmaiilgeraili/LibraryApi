using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Domain.BookCategoryAgg;

namespace LibraryManagement.Infrastructure.EfCore.Mapping
{
    public class BookCategoryMapping : IEntityTypeConfiguration<BookCategoryModel>
    {
        public void Configure(EntityTypeBuilder<BookCategoryModel> builder)
        {
            builder.ToTable("BookCategory");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Caption).HasMaxLength(100).IsRequired(); ;

            builder.HasMany(x => x.Books).WithOne(x => x.BookCategory).HasForeignKey(x => x.Id);
        }
    }
}
