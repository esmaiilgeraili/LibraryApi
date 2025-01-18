using LibraryManagement.Application;
using LibraryManagement.Application.Contracts.Book;
using LibraryManagement.Application.Contracts.BookCategory;
using LibraryManagement.Infrastructure.EfCore;
using LibraryManagement.Infrastructure.EfCore.Repository;
using LibraryManagement.Shared.Contracts.ConfigurationDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.ConfigurationService
{
    public class LibraryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, ConfigurationModel privateConfiguration)
        {
            #region Config
            services.AddDbContext<LibraryContext>(x => x.UseSqlServer(privateConfiguration.ConnectionString.LibraryContextDB));
            #endregion


            #region Application
            //Book
            services.AddScoped<IBookApplication, BookApplication>();
            services.AddScoped<IBookRepository, BookRepository>();
            //gory
            services.AddScoped<IBookCategoryApplication, BookCategoryApplication>();
            services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            #endregion
        }
    }
}
