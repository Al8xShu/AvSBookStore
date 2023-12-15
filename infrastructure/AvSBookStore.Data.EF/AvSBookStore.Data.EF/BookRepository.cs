using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvSBookStore.Data.EF
{
    public class BookRepository : IBookRepository
    {
        private readonly DbContextFactory dbContextFactory;

        public BookRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Book[]> GetAllByIdsAsync(IEnumerable<int> bookIds)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            var dtos = await dbContext.Books.Where(book => bookIds.Contains(book.Id)).ToArrayAsync();

            return dtos.Select(Book.Mapper.Map).ToArray();
        }

        public async Task<Book[]> getAllByIsbnAsync(string isbn)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            if (Book.TryFormatIsbn(isbn, out string formatedIsbn))
            {
                var dtos = await dbContext.Books.Where(book => book.Isbn == formatedIsbn).ToArrayAsync();

                return dtos.Select(Book.Mapper.Map).ToArray();
            }

            return new Book[0];
        }

        public Book[] getAllByTitleOrAuthor(string titleOrAuthor)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            var parameter = new SqlParameter("@titleOrAuthor", titleOrAuthor);

            var dtos = dbContext.Books
                .FromSqlRaw("SELECT * FROM Books WHERE CONTAINS((Author, Title), @titleOrAuthor)", parameter).ToArray();

            return dtos.Select(Book.Mapper.Map).ToArray();
        }

        public async Task<Book[]> getAllByTitleOrAuthorAsync(string titleOrAuthor)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            var parameter = new SqlParameter("@titleOrAuthor", titleOrAuthor);

            var dtos = await dbContext.Books
                .FromSqlRaw("SELECT * FROM Books WHERE CONTAINS((Author, Title), @titleOrAuthor)", parameter)
                .ToArrayAsync();
               

            return dtos.Select(Book.Mapper.Map).ToArray();
        }

        public Book GetById(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            var dto = dbContext.Books.Single(book => book.Id == id);

            return Book.Mapper.Map(dto);
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            var dto = await dbContext.Books.SingleAsync(book => book.Id == id);

            return Book.Mapper.Map(dto);
        }
    }
}
