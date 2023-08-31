using System;

namespace AvSBookStore
{
    public class Book
    {
        public string Title { get; }
        public int Id { get; }

        public Book(string title, int id)
        {
            Title = title;
            Id = id;
        }
    }
}
