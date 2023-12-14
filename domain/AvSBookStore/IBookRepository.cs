using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvSBookStore
{
    public interface IBookRepository
    {
        Book[] getAllByTitleOrAuthor(string titleOrAuthor);

        Book[] getAllByIsbn(string isbn);

        Task<Book[]> getAllByTitleOrAuthorAsync(string titleOrAuthor);

        Task<Book[]> getAllByIsbnAsync(string isbn);

        Book GetById(int id);

        Task<Book> GetByIdAsync(int id);

        Book[] GetAllByIds(IEnumerable<int> bookIds);
    }
}
