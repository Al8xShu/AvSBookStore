using System;
using System.Text.RegularExpressions;

namespace AvSBookStore
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public string Isbn { get; }
        public string Author { get; }

        public Book(int id, string title, string isbn, string author)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            Author = author;
        }

        internal static bool IsIsbn(string stroke)
        {
            if(stroke == null)
            {
                return false;
            }

            stroke = stroke.Replace("-", "").Replace(" ", "").ToUpper();

            return Regex.IsMatch(stroke, "ISBN\\d{10}(\\d{3})?$");
        }
    }
}
