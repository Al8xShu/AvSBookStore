using System.Collections.Generic;
using System.Linq;

namespace AvSBookStore.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Art Of Programming, Vol. 1", "ISBN 12312-31231", "D. Knut",
                "This volume begins with basic programming concepts and techniques, " +
                "then focuses more particularly on information structures-the representation" +
                " of information inside a computer, the structural relationships between data" +
                " elements and how to deal with them efficiently.", 7.45m),
            new Book(2, "Refactoring", "ISBN 12312-31232", "M. Flowler",
                "As the application of object technology--particularly the Java programming " +
                "language--has become commonplace, a new problem has emerged to confront the " +
                "software development community.", 12.25m),
            new Book(3, "C++ programm language", "ISBN 12312-31233", "B. Kernighan",
                "Known as the bible of C, this classic bestseller introduces the C programming" +
                " language and illustrates algorithms, data structures, and programming " +
                "techniques.", 17.15m),
        };

        public Book[] getAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query) 
            || book.Title.Contains(query)).ToArray();
        }

        public Book[] getAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }
    }
}
