using System;
using System.Linq;

namespace AvSBookStore.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art of program", "ISBN 12312-31231", "D. Knut"),
            new Book(2, "Refactoring", "ISBN 12312-31232", "M. Flowler"),
            new Book(3, "C++ program language", "ISBN 12312-31233", "B. Kernighan"),
        };

        public Book[] getAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query) || book.Title.Contains(query)).ToArray();
        }

        public Book[] getAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }
    }
}
