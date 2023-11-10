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
        public string Description { get; }
        public decimal Price { get; }

        public Book(int id, string title, string isbn, string author, string descriptions, decimal price)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            Author = author;
            Description = descriptions;
            Price = price;
        }

        internal static bool IsIsbn(string stroke)
        {
            if (stroke == null)
            {
                return false;
            }

            stroke = stroke.Replace("-", "").Replace(" ", "").ToUpper();

            return Regex.IsMatch(stroke, "ISBN\\d{10}(\\d{3})?$");
        }
    }
}