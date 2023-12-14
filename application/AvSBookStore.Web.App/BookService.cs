using AvSBookStore.Web.App;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvSBookStore.Web.App
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public BookModel GetById(int id)
        {
            var book = bookRepository.GetById(id);

            return Map(book);
        }

        public async Task<BookModel> GetByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            return Map(book);
        }

        public IReadOnlyCollection<BookModel> GetAllByQuery(string query)
        {
            var books = Book.IsIsbn(query)
                ? bookRepository.getAllByIsbn(query)
                : bookRepository.getAllByTitleOrAuthor(query);

            return books.Select(Map).ToArray();
        }

        public async Task<IReadOnlyCollection<BookModel>> GetAllByQueryAsync(string query)
        {
            var books = Book.IsIsbn(query)
                ? await bookRepository.getAllByIsbnAsync(query)
                : await bookRepository.getAllByTitleOrAuthorAsync(query);

            return books.Select(Map).ToArray();
        }

        private BookModel Map(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price
            };
        }
    }
}
