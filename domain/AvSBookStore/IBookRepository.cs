using System;
using System.Collections.Generic;
using System.Text;

namespace AvSBookStore
{
    public interface IBookRepository
    {
        Book[] getAllByTitleOrAuthor(string titleOrAuthor);

        Book[] getAllByIsbn(string isbn);

        Book getById(int id);
    }
}
