using System.Collections.Generic;

namespace AvSBookStore
{
    public interface IBookRepository
    {
        Book[] getAllByTitleOrAuthor(string titleOrAuthor);

        Book[] getAllByIsbn(string isbn);

        Book GetById(int id);

        Book[] GetAllByIds(IEnumerable<int> bookIds);
    }
}
