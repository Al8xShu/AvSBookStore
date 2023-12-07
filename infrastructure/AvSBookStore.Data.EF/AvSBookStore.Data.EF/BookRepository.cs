using System;
using System.Collections.Generic;

namespace AvSBookStore.Data.EF
{
    public class BookRepository : IBookRepository
    {
        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            throw new NotImplementedException();
        }

        public Book[] getAllByIsbn(string isbn)
        {
            throw new NotImplementedException();
        }

        public Book[] getAllByTitleOrAuthor(string titleOrAuthor)
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
