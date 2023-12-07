using System;
using System.Collections.Generic;
using System.Linq;

namespace AvSBookStore
{
    public class Order
    {
        public int Id { get; }
        private List<OrderItem> items;

        public Order(int id, IEnumerable<OrderItem> items)
        {
            Id = id;
            Items = new OrderItemCollection(items);
        }

        public OrderItemCollection Items { get; }

        public string CellPhone { get; set; }

        public OrderDelivery Delivery { get; set; }

        public OrderPayment Payment { get; set; }

        public int TotalCount => Items.Sum(item => item.Count);

        public decimal TotalPrice => Items.Sum(item => item.Price * item.Count)
            + (Delivery?.Amount ?? 0m);

        public OrderItem GetItem(int bookId)
        {
            int index = items.FindIndex(item => item.BookId == bookId);

            if (index == -1)
            {
                ThrowBookException("Book not found.", bookId);
            }

            return items[index];
        }

        public void AddItem(Book book, int count)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var item = items.SingleOrDefault(x => x.BookId == book.Id);

            if (item == null)
            {
                items.Add(new OrderItem(book.Id, count, book.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(book.Id, item.Count + count, book.Price));
            }
        }

        public void RemoveItems(int bookId)
        {

            int index = items.FindIndex(item => item.BookId == bookId);

            if (index == -1)
            {

                ThrowBookException("Order does not contain specified book", bookId);
            }

            items.RemoveAt(index);
        }

        private void ThrowBookException(string message, int bookId)
        {
            var exception = new InvalidOperationException(message);

            exception.Data[nameof(bookId)] = bookId;

            throw exception;
        }

        public void AddOrUpdateItem(Book book, int count)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            var index = items.FindIndex(item => item.BookId == book.Id);

            if (index == -1)
            {
                items.Add(new OrderItem(book.Id, count, book.Price));
            }
            else
            {
                items[index].Count += count;
            }
        }
    }
}
