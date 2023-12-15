using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvSBookStore
{
    public interface IBookRepository
    {
        Task<Book[]> getAllByTitleOrAuthorAsync(string titleOrAuthor);

        Task<Book[]> getAllByIsbnAsync(string isbn);

        Task<Book> GetByIdAsync(int id);

        Task<Book[]> GetAllByIdsAsync(IEnumerable<int> bookIds);
    }
}
