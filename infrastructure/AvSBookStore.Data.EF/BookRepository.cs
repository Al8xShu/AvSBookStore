using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvSBookStore.Data.EF
{
    public class BookRepository : IBookRepository
    {
        public Task<Book[]> GetAllByIdsAsync(IEnumerable<int> bookIds)
        {
            throw new NotImplementedException();
        }

        public Task<Book[]> GetAllByIsbnAsync(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<Book[]> GetAllByTitleOrAuthorAsync(string titleOrAuthor)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
