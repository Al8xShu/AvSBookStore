using System;

namespace AvSBookStore
{
    public class OrderItem
    {
        public int BookId { get; }
        public int Count { get; }
        public decimal Price { get; }

        public OrderItem(int bookId, int count, decimal price)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count  nust be greater than zero!");
            }
            BookId = bookId;
            Count = count;
            Price = price;
        }
    }
}
